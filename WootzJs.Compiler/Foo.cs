namespace WootzJs.Compiler
{
    class Async_SubInvocationTest : System.Runtime.CompilerServices.IAsyncStateMachine
            {
                WootzJs.Compiler.Tests.AsyncTests.SubInvocationClass _this;
                int _state;
                private void _Base_MyMethod()
                {
                    base.MyMethod();
                }

                System.Runtime.CompilerServices.AsyncTaskMethodBuilder _builder;
                public Async_SubInvocationTest(WootzJs.Compiler.Tests.AsyncTests.SubInvocationClass _this)
                {
                    this._this = _this;
                    this._builder = System.Runtime.CompilerServices.AsyncTaskMethodBuilder.Create();
                    System.Runtime.CompilerServices.IAsyncStateMachine _self = this;
                    this._builder.Start(ref _self);
                }

                public void MoveNext()
                {
                    try
                    {
                        _top:
                            while (true)
                            {
                                switch (this._state)
                                {
                                    case 0:
                                        _Base_MyMethod();
                                        _builder.SetResult();
                                        return;
                                }

                                break;
                            }
                    }
                    catch (System.Exception ex)
                    {
                        this._state = -1;
                        this._builder.SetException(ex);
                        return;
                    }
                }

                public void SetStateMachine(System.Runtime.CompilerServices.IAsyncStateMachine stateMachine)
                {
                }
            }}