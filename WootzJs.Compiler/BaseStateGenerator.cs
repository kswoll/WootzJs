using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using WootzJs.Compiler.JsAst;

namespace WootzJs.Compiler
{
    /// &lt;summary&gt;
    /// Base class for C# state generators.  These are used for await and yield functionality.  The following is 
    /// essentially my take on concepts that can be gleaned from a study of coroutines (1). The essential problem 
    /// is that in normal control flow, a method has a beginning and an end -- at the end, flow jumps to immediately 
    /// after the invocation of the method that has just been called.  However, await and yield require control 
    /// flow that is more flexible.  It's easiest to understand by starting with the most flexible operator, await.  
    /// 
    /// With await, you want to hand ask the awaiter (2) to do its thing and when it's done return the control flow 
    /// to immediately after the await expression (the next argument in a function call, the next statement, etc.). 
    /// In the meantime, the callstack is successively unwound; if the calling method is also async and awaiting, 
    /// this bubbles up the callstack until a non-async method is reached.  (Ultimately, the top of a callstack 
    /// cannot be async, be it a Main method or a Run on another thread.)  This allows the original thread to 
    /// continue on its merry way and perform other actions.  This is in stark contrast to a normal method 
    /// invocation.  Without async (or yield), the method must finish before the control flow can return to the 
    /// caller.
    /// 
    /// The way this is implemented is that when you start the awaiter, you provide the awaiter with a callback 
    /// function.  What's extremely special about this callback function is that its effect is to return the control 
    /// flow back to immediately after the awaiter was started (after the await or yield operator). Needless to say,
    /// except for await and yield, this is not otherwise possible in C#.  You can't create a lambda that will cause 
    /// control flow to resume in some arbitrary part of the method.
    /// 
    /// This ability to create a callback that can return to an arbitrary point in the method is the key ingredient 
    /// to both await and yield.  When implementing a yield iterator, you are asking the caller to do some work, then 
    /// the iterator to do some work, and then the caller, and then the iterator, and so on. Importantly each time 
    /// work is handed off between the two parties, control flow must resume from where it left off last time.  This 
    /// is achieved on the caller side by normal imperative control flow.  The caller does work and when it's ready 
    /// to wait for a new elemnt, it calls MoveNext() (like any other implementation of IEnumerator).  However, the 
    /// implementation of an iterator's MoveNext() method is the callback ingredient we have been describing.  This 
    /// callback returns control flow to arbitary points in the iterator (wherever the yield operator was last used).
    /// 
    /// So, to implement await and yield, we must figure out a way to create this callback that can return to 
    /// arbitrary points in a method.  The following applies to both C# and Javascript.  (In fact, the initial 
    /// implementation was a C# -&gt; C# translation, but is now a C# -&gt; JS translation.)  To create this callback we 
    /// must rip apart the abstract syntax tree of the method doing the awaiting or yielding.  The way this is 
    /// usually done is by creating a state machine.  Concretely, this means generating a switch statement that 
    /// switches on an integer state variable.  Each case statement represents some portion of logic (one or more 
    /// statements, and sometimes even individual expressions).  Modifying the value of this state variable 
    /// effectively changes where you are in the original method.  Thus it becomes possible to *return* from the 
    /// function and, the next time it is invoked, logically continue execution from where you left off before.
    /// 
    /// Generally speaking, this is straightforward.  However, control flow constructs (if, while, for, foreach, 
    /// try/catch, etc.), must be implemented in a new way in order to be able to exit from the function and somehow
    /// resume back into the middle of a control flow.  This can probably best be explained through example.  We'll 
    /// use yield in these examples because conceptually it's a bit more specific (caller and iterator) and thus 
    /// easier to reason about.  But all of this applies to await as well.  
    /// 
    /// To start, we'll start with the simplest possible yield iterator:
    /// 
    /// public IEnumerator&lt;string&gt; Empty()
    /// {
    ///     yield break;
    /// }
    /// 
    /// This iterator will produce an enumerator that will return false on the first invocation of MoveNext() (a 
    /// sequence with no elements).  Let's convert it into a state machine.  We'll use C# for consistency, but the 
    /// generated output is obviously Javascript.  Also, the implementation is simplified for clarity, but the real 
    /// output is more sophisticated (implements IEnumerable, IDisposable, etc.  Additionally, generated members 
    /// such as "state" are actually generated prefixed with "$" to avoid collisions with user code).
    /// 
    /// class YieldBreakIterator : IEnumerator&lt;string&gt;
    /// {
    ///     private int state;
    /// 
    ///     public string Current { get; private set; }
    /// 
    ///     public bool MoveNext() 
    ///     {
    ///         switch (state)
    ///         {
    ///             case 0: 
    ///                 return false;
    ///         }
    ///     }
    /// }
    /// 
    /// Here we have a simple state machine.  Technically, in this example, the property Current is not necessary, 
    /// but it will be used, of course, in any more sophisticated example.  Now let's change the iterator to:
    /// 
    /// public IEnumerator&lt;string&gt; ReturnFoo()
    /// {
    ///     yield return "foo";
    /// }
    /// 
    /// This iterator will be much the same as the first one, but it will first set the value of Current to "foo" 
    /// before returning true.
    /// 
    /// class YieldReturnFooIterator : IEnumerator&lt;string&gt;
    /// {
    ///     private int state;
    /// 
    ///     public string Current { get; private set; }
    /// 
    ///     public bool MoveNext() 
    ///     {
    ///         switch (state)
    ///         {
    ///             case 0: 
    ///                 state = 1;
    ///                 Current = "foo";
    ///                 return true;
    ///             case 1:
    ///                 return false;
    ///         }
    ///     }
    /// }
    /// 
    /// Here we can see that after the first invocation of MoveNext(), Current will contain the value "foo".  The 
    /// next invocation will arrive in state 2 and result in returning false and ending the iteration. 
    /// 
    /// The penultimate example is two yield statements in a row.  This finally illustrates jumping into an arbitrary 
    /// point in the iterator.
    /// 
    /// public IEnumerator&lt;string&gt; ReturnOneAndTwo()
    /// {
    ///     yield return 10;
    ///     yield return 42;
    /// }
    /// 
    /// Translating to the state machine:
    /// 
    /// class YieldReturnOneAndTwoIterator : IEnumerator&lt;string&gt;
    /// {
    ///     private int state;
    /// 
    ///     public int Current { get; private set; }
    /// 
    ///     public bool MoveNext() 
    ///     {
    ///         switch (state)
    ///         {
    ///             case 0: 
    ///                 state = 1;
    ///                 Current = 10;
    ///                 return true;
    ///             case 1:
    ///                 state = 2;
    ///                 Current = 42;
    ///                 return true;
    ///             case 2:
    ///                 return false;
    ///         }
    ///     }
    /// }
    /// 
    /// Now we get to see how the two statements in the iterator are broken down into two case statements.  Each case 
    /// statement is responsible for an individual yield return statement.  Each invocation of MoveNext() moves you 
    /// along, one statement at a time.
    /// 
    /// Finally, we will consider just one complex example -- the use of a for loop.  The key difference here is that 
    /// control flow now has to jump around between case statements.  The for loop is just one example.  All the 
    /// control flow statement operations in C# require similar transformations.
    /// 
    /// public IEnumerator&lt;int&gt; ForLoop(bool flag)
    /// {
    ///     for (var i = 0; i &lt; 2; i++)
    ///     {
    ///         yield return i;
    ///     }
    /// }
    /// 
    /// And now, let's look at the state machine:
    /// 
    /// class ForLoop : IEnumerator&lt;string&gt;
    /// {
    ///     private int state;
    ///     private int i;
    /// 
    ///     public string Current { get; private set; }
    /// 
    ///     public bool MoveNext() 
    ///     {
    ///         switch (state)
    ///         {
    ///             case 0: 
    ///                 i = 0;
    ///                 goto 1;
    ///             case 1:
    ///                 while (i &lt; 2)
    ///                 {
    ///                     goto 2;
    ///                 }
    ///                 break;
    ///             case 2:
    ///                 state = 1;
    ///                 Current = i;
    ///                 i++;
    ///                 return true;
    ///         }
    ///     }
    /// }
    /// 
    /// Here we jump around between different case statements, and various expressions from the original iterator are 
    /// decomposed into separate statements in the state machine.  For example, the for loop initializer is pulled 
    /// out and is expressed in the first line of case 0.  The for loop itself is converted into a while loop, using 
    /// the same condition.  The body of the loop jumps to state 2 (not strictly necessary in this example to have a 
    /// separate state, but in more complex examples this transformation becomes necessary).  State 2 is responsible 
    /// for updating the Current property to the new value, apply the incrementor of the for loop, change the state 
    /// to 1 (the top of the loop) and finally return true indicating that the next invocation should attempt to 
    /// continue the loop.
    /// 
    /// That's basically it.  All the transformations for the various control flow constructs are the same between 
    /// await and yield.  The only differences are in the handling of await expressions and yield statements.  Since 
    /// they are mutually exclusive within a method, this simplifies the implementation.
    /// 
    /// (1) http://en.wikipedia.org/wiki/Coroutine
    /// (2) http://codeblog.jonskeet.uk/2011/05/13/eduasync-part-3-the-shape-of-the-async-method-awaitable-boundary/
    /// &lt;/summary&gt;
    public class BaseStateGenerator : CSharpSyntaxWalker
    {
        public const string stateMachine = "$stateMachine";
        public const string state = "$state";
        public const string moveNext = "$moveNext";
        public const string @this = "$this";

        private readonly JsTransformer transformer;

        private int currentStateIndex;
        private Dictionary<LiftedVariableKey, string> hoistedVariables = new Dictionary<LiftedVariableKey, string>();
        private JsBlockStatement stateMachineBody;
        private CSharpSyntaxNode node;
        private Stack<State> breakStates = new Stack<State>();
        private Stack<State> continueStates = new Stack<State>();
        private Dictionary<string, State> labeledStates = new Dictionary<string, State>();
        private IMethodSymbol method;
        private Idioms idioms;
        internal State topState = new State();
        
        public BaseStateGenerator(Func<BaseStateGenerator, JsTransformer> transformer, CSharpSyntaxNode node, JsBlockStatement stateMachineBody, Idioms idioms, IMethodSymbol method)
        {
            this.transformer = transformer(this);
            this.node = node;
            this.stateMachineBody = stateMachineBody;
            this.method = method;
            this.idioms = idioms;
        }

        public JsTransformer Transformer
        {
            get { return transformer; }
        }

        public IMethodSymbol Method
        {
            get { return method; }
        }

        public Idioms Idioms
        {
            get { return idioms; }
        }

        private string GenerateNewNamePrivate(LiftedVariableKey symbol)
        {
            var counter = 2;
            do
            {
                var currentName = symbol.Identifier + counter++;
                if (!hoistedVariables.ContainsKey(new LiftedVariableKey(SyntaxFactory.Identifier(currentName))))
                {
                    return currentName;
                }
            }
            while (true);
        }

        public JsVariableDeclarator HoistVariable(LiftedVariableKey symbol)
        {
            var identifier = symbol.Identifier;
            if (hoistedVariables.ContainsKey(symbol) || hoistedVariables.ContainsKey(new LiftedVariableKey(symbol.Identifier)))
            {
                identifier = GenerateNewNamePrivate(symbol);
                symbol = new LiftedVariableKey(identifier, symbol.Symbol);
            }
            
            // Register the variable so we avoid collisions.
            hoistedVariables[symbol] = identifier;
            if (symbol.Symbol == null)
                hoistedVariables[new LiftedVariableKey(symbol.Identifier)] = identifier;

            // Declare a local variable (of the top-level function so available as closures to the state
            // machine) to store the symbol.
            var declaration = stateMachineBody.Local(identifier, Js.Null());

            // If we have a true symbol associated with the key, then declare it in the base transformer
            if (symbol.Symbol != null)
                transformer.DeclareInCurrentScope(symbol.Symbol, declaration);

            return declaration;
        }

        protected string UniqueName(string identifier)
        {
            var key = new LiftedVariableKey(identifier);
            if (hoistedVariables.ContainsKey(key))
            {
                identifier = GenerateNewNamePrivate(key);
                hoistedVariables[key] = identifier;
            }
            return identifier;            
        }

        public void GenerateStates()
        {
            topState.CurrentState = NewState();
            node.Accept(this);
            if (!topState.Substates.Last().Statements.Any())
                topState.Substates.Remove(topState.Substates.Last());

            OnBaseStateGenerated();
        }

        protected virtual void OnBaseStateGenerated()
        {
        }

        public State TopState
        {
            get { return topState; }
        }

        protected State NewState()
        {
            var newState = new State();
            newState.Parent = topState;
            newState.Index = currentStateIndex++;
            topState.Substates.Add(newState);            
            return newState;
        }

        protected State FindLabeledState(string label)
        {
            if (labeledStates.ContainsKey(label))
                return labeledStates[label];
            else
            {
                var labeledState = new State();
                labeledState.Index = currentStateIndex++;
                labeledStates[label] = labeledState;
                return labeledState;
            }
        }

        protected State NewLabeledState(string label)
        {
            if (!labeledStates.ContainsKey(label))
            {
                var labeledState = GetNextState();
                labeledStates[label] = labeledState;
                return labeledState;                
            }
            else
            {
                var labeledState = labeledStates[label];
                labeledState.Parent = topState;
                topState.Substates.Add(labeledState);
                return labeledState;
            }
        }

        protected State NewSubstate()
        {
            var newState = NewState();
            return newState;
        }

        protected void StartSubstate(State substate)
        {
            topState = substate;
            CurrentState = NewState();            
        }

        protected void EndSubstate()
        {
            topState.InternalAdd(GenerateSwitch(topState));
            topState = topState.Parent;
        }

        protected State GetNextState()
        {
            if (topState.CurrentState.Next != null)
            {
                return topState.CurrentState.Next;
            }
            else
            {
                var nextState = NewState();
                return nextState;                
            }
        }

        public State InsertState()
        {
            var nextState = NewState();
            nextState.Next = topState.CurrentState.Next;
            return nextState;
        }

        public State CurrentState
        {
            get { return topState.CurrentState; }
            set { topState.CurrentState = value; }
        }

        public JsStatement GotoTop()
        {
            return Js.Continue("$top");
        }

        public JsStatement ChangeState(State newState)
        {
            return Js.Reference(state).Assign(Js.Primitive(newState.Index)).Express();
        }

        public void GotoState(State newState)
        {
            if (newState == CurrentState)
                return;
            var lastStatement = CurrentState.Statements.LastOrDefault();
            if (lastStatement is JsContinueStatement || lastStatement is JsBreakStatement || lastStatement is JsReturnStatement)
                return;
            CurrentState.Add(ChangeState(newState));
            CurrentState.Add(GotoTop());
        }

        public JsBlockStatement GotoStateBlock(State newState)
        {
            return Js.Block(
                ChangeState(newState),
                GotoTop()
            );
        }

        public JsStatement[] GotoStateStatements(State newState)
        {
            return new[]
            {
                ChangeState(newState),
                GotoTop()                
            };
        }

        public JsStatement GenerateSwitch(State state)
        {
            var sections = new List<JsSwitchSection>();
            if (state.Parent != null)
            {
                var stateSection = Js.Section(Js.Primitive(state.Index));
                stateSection.Statements.AddRange(GotoStateStatements(state.Substates.First()));
                sections.Add(stateSection);
            }
            sections.AddRange(state.Substates.Select(substate =>
            {
                var section = Js.Section(substate.GetAllIndices().Select(index => Js.Primitive(index)).ToArray());
                section.Statements.AddRange(substate.Statements);
                return section;
            }));
            return state.Wrap(Js.Switch(Js.Reference(BaseStateGenerator.state), sections.ToArray()));
        }

        protected void AcceptStatement(StatementSyntax statement, State breakState = null, State continueState = null)
        {
            if (breakState != null)
                breakStates.Push(breakState);
            if (continueState != null)
                continueStates.Push(continueState);
            statement.Accept(this);
            if (breakState != null)
                breakStates.Pop();
            if (continueState !=  null)
                continueStates.Pop();
        }

        protected void Accept(Action action, State breakState = null, State continueState = null)
        {
            if (breakState != null)
                breakStates.Push(breakState);
            if (continueState != null)
                continueStates.Push(continueState);
            action();
            if (breakState != null)
                breakStates.Pop();
            if (continueState !=  null)
                continueStates.Pop();
        }

        public override void VisitBreakStatement(BreakStatementSyntax node)
        {
            GotoState(breakStates.Peek());
        }

        public override void VisitContinueStatement(ContinueStatementSyntax node)
        {
            GotoState(continueStates.Peek());
        }

        public override void VisitExpressionStatement(ExpressionStatementSyntax node)
        {
            CurrentState.Add(((JsExpression)node.Expression.Accept(Transformer)).Express());
        }

        public override void VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
        {
            // Convert the variable declaration to an assignment expression statement
            foreach (var variable in node.Declaration.Variables)
            {
                // Hoist the variable into a field
                var symbol = (ILocalSymbol)Transformer.Model.GetDeclaredSymbol(variable);
                var identifier = HoistVariable(new LiftedVariableKey(variable.Identifier, symbol));

                if (variable.Initializer != null)
                {
                    var assignment = identifier.GetReference().Assign((JsExpression)variable.Initializer.Value.Accept(Transformer));
                    CurrentState.Add(assignment.Express());
                }
            }
        }

        public override void VisitBlock(BlockSyntax node)
        {
            foreach (var statement in node.Statements)
            {
                AcceptStatement(statement);
            }
        }

        public override void VisitIfStatement(IfStatementSyntax node)
        {
            var afterIfState = GetNextState();
            var ifTrueState = GetNextState();
            var ifFalseState = node.Else != null ? GetNextState() : null;

            var newIfStatement = Js.If(
                (JsExpression)node.Condition.Accept(Transformer),
                GotoStateBlock(ifTrueState));

            if (node.Else != null)
                newIfStatement.IfFalse = GotoStateBlock(ifFalseState);

            CurrentState.Add(newIfStatement);
            GotoState(afterIfState);

            CurrentState = ifTrueState;
            AcceptStatement(node.Statement);
            GotoState(afterIfState);

            if (ifFalseState != null)
            {
                CurrentState = ifFalseState;
                AcceptStatement(node.Else.Statement);
                GotoState(afterIfState);
            }

            CurrentState = afterIfState;
        }

        public override void VisitDoStatement(DoStatementSyntax node)
        {
            var topOfLoop = GetNextState();
            var afterWhileStatement = GetNextState();
            var bodyState = GetNextState();

            // The first thing that needs to happen is that the body should execute once,
            // regardless of the condition.  After that, we can just use a while loop,
            // since from that point on it's equivalent.
            GotoState(bodyState);

            CurrentState = bodyState;
            AcceptStatement(node.Statement, afterWhileStatement, topOfLoop);
            GotoState(topOfLoop);

            CurrentState = topOfLoop;
            var newWhileStatement = Js.While(
                (JsExpression)node.Condition.Accept(Transformer),
                GotoStateBlock(bodyState));

            CurrentState.Add(newWhileStatement);
            GotoState(afterWhileStatement);

            CurrentState = afterWhileStatement;
        }

        public override void VisitWhileStatement(WhileStatementSyntax node)
        {
            var topOfLoop = GetNextState();

            GotoState(topOfLoop);
            CurrentState = topOfLoop;

            var afterWhileStatement = GetNextState();
            var bodyState = NewState();

            var newWhileStatement = Js.While(
                (JsExpression)node.Condition.Accept(Transformer),
                GotoStateBlock(bodyState));

            CurrentState.Add(newWhileStatement);
            GotoState(afterWhileStatement);

            CurrentState = bodyState;
            AcceptStatement(node.Statement, afterWhileStatement, topOfLoop);
            GotoState(topOfLoop);

            CurrentState = afterWhileStatement;
        }

        public override void VisitForStatement(ForStatementSyntax node)
        {            
            // Convert the variable declaration to an assignment expression statement
            if (node.Declaration != null)
            {
                foreach (var variable in node.Declaration.Variables)
                {
                    // Hoist the variable into a field
                    var symbol = (ILocalSymbol)ModelExtensions.GetDeclaredSymbol(Transformer.Model, variable);
                    var identifier = HoistVariable(new LiftedVariableKey(variable.Identifier, symbol));

                    if (variable.Initializer != null)
                    {
                        var assignment = identifier.GetReference().Assign((JsExpression)variable.Initializer.Value.Accept(Transformer));
                        CurrentState.Add(assignment.Express());
                    }
                }                
            }
            else if (node.Initializers.Any())
            {
                foreach (var initializer in node.Initializers)
                {
                    var assignment = (JsExpression)initializer.Accept(Transformer);
                    CurrentState.Add(assignment.Express());
                }
            }

            var topOfLoop = GetNextState();

            GotoState(topOfLoop);
            CurrentState = topOfLoop;

            var afterLoop = GetNextState();
            var bodyState = NewState();
            var incrementorState = NewState();

            var newWhileStatement = Js.While(
                node.Condition == null ? Js.Primitive(true) : (JsExpression)node.Condition.Accept(Transformer),
                GotoStateBlock(bodyState));

            CurrentState.Add(newWhileStatement);
            GotoState(afterLoop);

            CurrentState = bodyState;
            AcceptStatement(node.Statement, afterLoop, incrementorState);
            GotoState(incrementorState);

            CurrentState = incrementorState;
            foreach (var incrementor in node.Incrementors)
            {
                CurrentState.Add(((JsExpression)incrementor.Accept(Transformer)).Express());
            }
            GotoState(topOfLoop);

            CurrentState = afterLoop;
        }

        public override void VisitForEachStatement(ForEachStatementSyntax node)
        {
            // Hoist the variable into a field
            var symbol = (ILocalSymbol)ModelExtensions.GetDeclaredSymbol(Transformer.Model, node);
            var identifier = HoistVariable(new LiftedVariableKey(node.Identifier, symbol));

            // Hoist the enumerator into a field
            var enumerator = HoistVariable(new LiftedVariableKey(identifier.Name + "$enumerator"));
            CurrentState.Add(
                enumerator.GetReference().Assign(
                    ((JsExpression)node.Expression.Accept(Transformer)).Member("GetEnumerator").Invoke()
                ).Express()
            );

            var topOfLoop = GetNextState();

            GotoState(topOfLoop);
            CurrentState = topOfLoop;

            var afterLoop = GetNextState();
            var bodyState = GetNextState();

            var moveNext = enumerator.GetReference().Member("MoveNext").Invoke();
            var newWhileStatement = Js.While(moveNext, GotoStateBlock(bodyState));

            CurrentState.Add(newWhileStatement);
            GotoState(afterLoop);

            CurrentState = bodyState;
            CurrentState.Add(identifier.GetReference().Assign(enumerator.GetReference().Member("get_Current").Invoke()).Express());
            
            AcceptStatement(node.Statement, afterLoop, topOfLoop);
            GotoState(topOfLoop);

            CurrentState = afterLoop;
        }

        public override void VisitThrowStatement(ThrowStatementSyntax node)
        {
            var exception = node.Expression;
            
            // For naked "throw" statements, we need to find the exception object
            if (exception == null)
            {
                var catchClause = node.FirstAncestorOrSelf<CatchClauseSyntax>();
                var symbol = Transformer.model.GetDeclaredSymbol(catchClause.Declaration);
                var identifier = Transformer.ReferenceDeclarationInScope(symbol);
                CurrentState.Add(Js.Throw(identifier.GetReference()));
            }
            else
            {
                CurrentState.Add(Js.Throw((JsExpression)exception.Accept(Transformer)));
            }
        }

        public override void VisitTryStatement(TryStatementSyntax node)
        {
            var afterTry = GetNextState();
            var newTryStatement = Js.Try();

            var tryState = NewSubstate();
            GotoState(tryState);

            // Keep track of exception, if any, so we can rethrow
            var exceptionIdentifier = HoistVariable(new LiftedVariableKey("$ex"));
            var exceptionVariable = UniqueName("$caughtex");

            State finallyState = node.Finally == null ? null : GetNextState();

            // Declare a block to store all the catch statements the try statement's only catch clause. (No
            // type-specific catch clauses in Javascript
            var catchBlock = Js.Block();

            // Make sure that the exception is stored in a variable accessible to the entire state machine.
            catchBlock.Express(exceptionIdentifier.GetReference().Assign(Js.Reference(exceptionVariable)));

            foreach (var catchClause in node.Catches)
            {
                // Get the symbol that represents the exception declaration (identifier and type)
                var symbol = Transformer.Model.GetDeclaredSymbol(catchClause.Declaration);
                var exceptionType = symbol == null ? null : symbol.Type;
                if (exceptionType == null && catchClause.Declaration != null && catchClause.Declaration.Type != null)
                    exceptionType = (ITypeSymbol)Transformer.Model.GetSymbolInfo(catchClause.Declaration.Type).Symbol;

                // True if it is actually declaring the variable (as opposed to a catch clause that specifies
                // merely an exception type
                var hasDeclaration = catchClause.Declaration.Identifier.CSharpKind() != SyntaxKind.None;

                // A variable to store the new unique identifier to store the exception
                IJsDeclaration newIdentifier;

                // Hoist the variable into a field
                if (hasDeclaration)
                    newIdentifier = HoistVariable(new LiftedVariableKey(catchClause.Declaration.Identifier, symbol));
                else
                    newIdentifier = HoistVariable(new LiftedVariableKey(SyntaxFactory.Identifier("ex")));

                // Collect all the catch statements into the catchState by making that state current
                var catchState = GetNextState();
                CurrentState = catchState;
                AcceptStatement(catchClause.Block);

                // Add onto the catch state some commands to go to the next state.  
                if (finallyState != null)
                    GotoState(finallyState);
                else
                    GotoState(afterTry);

                // Create the statements that will live in the actual catch handler, which directs the logic
                // to the actual catch state and also stores the exception in the correct identifier.
                var thisCatchStatements = Js.Block();
                thisCatchStatements.Express(newIdentifier.SetReference().Assign(exceptionIdentifier.GetReference()));
                thisCatchStatements.AddRange(GotoStateStatements(catchState));

                // Only do the above if the current exception is of the type expected by the catch handler.
                catchBlock.Add(Js.If(Idioms.Is(exceptionIdentifier.GetReference(), exceptionType), thisCatchStatements));
            }
            if (node.Finally != null)
            {
                // Collect the statements of the finally block into the finally state
                CurrentState = finallyState;
                AcceptStatement(node.Finally.Block);

                // If the exception object is not null, then rethrow it.  In other words, if this is a finally 
                // clause that has responded to an exception, we need to propagate the exception rather than 
                // continue after the try statement.  Otherwise, go to the code after the try block.
                CurrentState.Add(Js.If(exceptionIdentifier.GetReference().NotEqualTo(Js.Null()), 
                    Js.Throw(exceptionIdentifier.GetReference()), 
                    Js.Block(GotoStateStatements(afterTry))));

                // Finally, at the very end of the catch clause (and we can only get here if the logic didn't break
                // out as it would with the logic in the catch handlers) go to the finally state.
                catchBlock.AddRange(GotoStateStatements(finallyState).ToArray());
            }

            newTryStatement.Catch = Js.Catch(Js.Variable(exceptionVariable));
            newTryStatement.Catch.Body = catchBlock;
            tryState.Wrap = switchStatement =>
            {
                newTryStatement.Body = Js.Block(switchStatement);
                return newTryStatement;
            };

            StartSubstate(tryState);
            AcceptStatement(node.Block);
            if (node.Finally != null)
                GotoState(finallyState);
            else
                GotoState(afterTry);
            EndSubstate();

            CurrentState = afterTry;
        }

        public override void VisitSwitchStatement(SwitchStatementSyntax node)
        {
            var afterSwitchState = GetNextState();

            var sectionStates = node.Sections.Select(x => GetNextState()).ToArray();
            var newSwitchStatement = Js.Switch(
                (JsExpression)node.Expression.Accept(Transformer),
                node.Sections
                    .Select((x, i) =>
                    {
                        var section = Js.Section(x.Labels.Select(y => y.Value != null ? Js.CaseLabel((JsExpression)y.Value.Accept(Transformer)) : Js.DefaultLabel()).ToArray());
                        section.Statements.AddRange(GotoStateStatements(sectionStates[i]));
                        return section;
                    })
                    .ToArray());

            CurrentState.Add(newSwitchStatement);
            GotoState(afterSwitchState);

            Accept(() =>
            {
                for (var i = 0; i < node.Sections.Count; i++)
                {
                    var section = node.Sections[i];
                    var sectionState = sectionStates[i];
                    CurrentState = sectionState;
                    foreach (var statement in section.Statements)
                    {
                        AcceptStatement(statement);
                    }
                }                
            }, afterSwitchState);

            CurrentState = afterSwitchState;
        }

        public override void VisitUsingStatement(UsingStatementSyntax node)
        {
            var afterTry = GetNextState();
            var newTryStatement = Js.Try();

            // Keep track of exception, if any, so we can rethrow
            var exceptionIdentifier = HoistVariable(new LiftedVariableKey("$usingex"));

            // Identifier for caught exception
            var caughtExceptionIdentifier = UniqueName("$caughtex");

            // Hoist the variable into a field
            var disposables = new List<JsExpression>();
            if (node.Declaration != null) 
            {
                foreach (var variable in node.Declaration.Variables)
                {
                    var symbol = (ILocalSymbol)Transformer.Model.GetDeclaredSymbol(variable);
                    var identifier = HoistVariable(new LiftedVariableKey(variable.Identifier, symbol));
                    var name = identifier.GetReference();
                    disposables.Add(name);
                    CurrentState.Add(name.Assign((JsExpression)variable.Initializer.Value.Accept(Transformer)).Express());
                }
            }
            if (node.Expression != null)
            {
                var identifier = Js.Reference(UniqueName("$using"));
                disposables.Add(identifier);
                CurrentState.Add(identifier.Assign((JsExpression)node.Expression.Accept(Transformer)).Express());
            }

            var tryState = NewSubstate();
            GotoState(tryState);

            var finallyState = GetNextState();
            CurrentState = finallyState;
            foreach (var disposable in disposables)
            {
                CurrentState.Add(disposable.Member("Dispose").Invoke().Express());
            }
            CurrentState.Add(Js.If(exceptionIdentifier.GetReference().NotEqualTo(Js.Null()), Js.Throw(exceptionIdentifier.GetReference())));
            GotoState(afterTry);
            newTryStatement.Catch = Js.Catch(Js.Variable(caughtExceptionIdentifier));
            newTryStatement.Catch.Body = Js.Block(
                new[] { exceptionIdentifier.GetReference().Assign(Js.Reference(caughtExceptionIdentifier)).Express() }
                    .Concat(GotoStateStatements(finallyState))
                    .ToArray()
            );

            tryState.Wrap = switchStatement =>
            {
                newTryStatement.Body = Js.Block(switchStatement);
                return newTryStatement;
            };

            StartSubstate(tryState);
            AcceptStatement(node.Statement);
            GotoState(finallyState);
            EndSubstate();

            CurrentState = afterTry;
        }

        public override void VisitLabeledStatement(LabeledStatementSyntax node)
        {
            var label = node.Identifier.ToString();
            var labelState = NewLabeledState(label);
            GotoState(labelState);

            CurrentState = labelState;
            AcceptStatement(node.Statement);
        }

        public override void VisitGotoStatement(GotoStatementSyntax node)
        {
            var label = ((IdentifierNameSyntax)node.Expression).Identifier.ToString();
            var labelState = FindLabeledState(label);
            GotoState(labelState);
        }

        public struct LiftedVariableKey
        {
            private readonly string identifier;
            private readonly ISymbol symbol;

            public LiftedVariableKey(SyntaxToken identifier, ISymbol symbol)
            {
                this.identifier = identifier.ToString();
                this.symbol = symbol;
            }

            public LiftedVariableKey(string identifier, ISymbol symbol)
            {
                this.identifier = identifier;
                this.symbol = symbol;
            }

            public LiftedVariableKey(SyntaxToken identifier) : this()
            {
                this.identifier = identifier.ToString();
            }

            public LiftedVariableKey(string identifier) : this()
            {
                this.identifier = identifier;
            }

            public string Identifier
            {
                get { return identifier; }
            }

            public ISymbol Symbol
            {
                get { return symbol; }
            }

            public bool Equals(LiftedVariableKey other)
            {
                return string.Equals(identifier, other.identifier) && (Equals(symbol, other.symbol) || symbol == null || other.symbol == null);
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                return obj is LiftedVariableKey && Equals((LiftedVariableKey) obj);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    return identifier.GetHashCode();
                }
            }
        }
     }
}