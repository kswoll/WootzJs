using System.Collections.Generic;

namespace System.Linq.Expressions
{
    public abstract class LambdaExpression : Expression
    {
        private string name;
        private Expression body;
        private List<ParameterExpression> parameters;
        private Type delegateType;
        private bool tailCall;

        internal LambdaExpression(Type delegateType, string name, Expression body, bool tailCall, ParameterExpression[] parameters) : base(ExpressionType.Lambda)
        {
            this.name = name;
            this.body = body;
            this.parameters = parameters.ToList();
            this.delegateType = delegateType;
            this.tailCall = tailCall;
        }

        public override Type Type
        {
            get { throw new NotImplementedException(); }
        }

        public string Name
        {
            get { return name; }
        }

        public Expression Body
        {
            get { return body; }
        }

        public List<ParameterExpression> Parameters
        {
            get { return parameters; }
        }

        public Type DelegateType
        {
            get { return delegateType; }
        }

        public bool TailCall
        {
            get { return tailCall; }
        }

        public LambdaExpression Update(Expression body, List<ParameterExpression> parameters)
        {
            return this;
        }
    }
}