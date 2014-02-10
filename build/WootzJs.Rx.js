"use strict";
var $WootzJs$Rx$Assembly = null;
var $WootzJs$Rx$AssemblyTypes = [];
window.$WootzJs$Rx$GetAssembly = function() {
    if ($WootzJs$Rx$Assembly == null)
        $WootzJs$Rx$Assembly = System.Reflection.Assembly.prototype.$ctor.$new("WootzJs.Rx", $WootzJs$Rx$AssemblyTypes, $arrayinit([
            System.Reflection.AssemblyTitleAttribute.prototype.$ctor.$new("WootzJs.Rx"), 
            System.Reflection.AssemblyDescriptionAttribute.prototype.$ctor.$new(""), 
            System.Reflection.AssemblyConfigurationAttribute.prototype.$ctor.$new(""), 
            System.Reflection.AssemblyCompanyAttribute.prototype.$ctor.$new(""), 
            System.Reflection.AssemblyProductAttribute.prototype.$ctor.$new("WootzJs.Rx"), 
            System.Reflection.AssemblyCopyrightAttribute.prototype.$ctor.$new("Copyright ©  2014"), 
            System.Reflection.AssemblyTrademarkAttribute.prototype.$ctor.$new(""), 
            System.Reflection.AssemblyCultureAttribute.prototype.$ctor.$new(""), 
            System.Runtime.InteropServices.ComVisibleAttribute.prototype.$ctor.$new(false), 
            System.Runtime.InteropServices.GuidAttribute.prototype.$ctor.$new("f392f9be-84e8-48b1-98a4-be1d948f2118"), 
            System.Reflection.AssemblyVersionAttribute.prototype.$ctor.$new("1.0.0.0"), 
            System.Reflection.AssemblyFileVersionAttribute.prototype.$ctor.$new("1.0.0.0")
        ], System.Attribute));
    return $WootzJs$Rx$Assembly;
};
$assemblies.push(window.$WootzJs$Rx$GetAssembly);
window.System = window.System || {};
System.Reactive = System.Reactive || {};
System.Reactive.Disposables = System.Reactive.Disposables || {};
System.Reactive.Linq = System.Reactive.Linq || {};
System.Reactive.Linq.Observables = System.Reactive.Linq.Observables || {};
System.Reactive.PlatformServices = System.Reactive.PlatformServices || {};
System.Reactive.Subjects = System.Reactive.Subjects || {};
System.Reactive.ObserverBase$1 = $define("System.Reactive.ObserverBase<T>", System.Object);
(System.Reactive.ObserverBase$1.$TypeInitializer = function($t, $p, T) {
    $t.$GetAssembly = window.$WootzJs$Rx$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Object;
    $p.$typeName = "System.Reactive.ObserverBase`1";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("ObserverBase", $arrayinit([], System.Attribute));this.$type.Init("System.Reactive.ObserverBase`1", System.Reactive.ObserverBase$1, System.Object, $arrayinit([System.IDisposable, System.IObserver$1], System.Type), $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("isStopped", System.Int32, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("OnNext", System.Reactive.ObserverBase$1.prototype.OnNext, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", T, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("OnNextCore", System.Reactive.ObserverBase$1.prototype.OnNextCore, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", T, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Family, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("OnError", System.Reactive.ObserverBase$1.prototype.OnError, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("error", System.Exception, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("OnErrorCore", System.Reactive.ObserverBase$1.prototype.OnErrorCore, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("error", System.Exception, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Family, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("OnCompleted", System.Reactive.ObserverBase$1.prototype.OnCompleted, $arrayinit([], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("OnCompletedCore", System.Reactive.ObserverBase$1.prototype.OnCompletedCore, $arrayinit([], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Family, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Dispose", System.Reactive.ObserverBase$1.prototype.Dispose, $arrayinit([], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Dispose$1", System.Reactive.ObserverBase$1.prototype.Dispose$1, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("disposing", System.Boolean, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Family, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Fail", System.Reactive.ObserverBase$1.prototype.Fail, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("error", System.Exception, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Boolean, System.Reflection.MethodAttributes().Assembly, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", System.Reactive.ObserverBase$1.prototype.$ctor, $arrayinit([], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Family, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {
        if ($t.$isStaticInitialized)
            return;
        $t.$isStaticInitialized = true;
        System.Object.$StaticInitializer();
    };
    $t.$ = function() {
        return $generic.call(null, System.Reactive.ObserverBase$1, arguments)();
    };
    window.System.Reactive.ObserverBase$1$ = $t.$;
    $p.isStopped = 0;
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
        this.isStopped = 0;
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.OnNext = function(value) {
        if (this.isStopped == 0)
            this.OnNextCore(value);
    };
    $p.System$IObserver$1$OnNext = $p.OnNext;
    $p.System$IObserver$1$OnNext = $p.OnNext;
    $p.System$IObserver$1$OnNext = $p.OnNext;
    $p.OnNextCore = function(value) {};
    $p.OnError = function(error) {
        if (error == null)
            throw System.ArgumentNullException.prototype.$ctor.$new("error").InternalInit(new Error());
        if ((function() {
            var $anon$1 = {
                value: this.isStopped
            };
            var $result$ = System.Threading.Interlocked.Exchange(System.Int32, $anon$1, 1);
            this.isStopped = $anon$1.value;
            return $result$;
        }).call(this) == 0) {
            this.OnErrorCore(error);
        }
    };
    $p.System$IObserver$1$OnError = $p.OnError;
    $p.System$IObserver$1$OnError = $p.OnError;
    $p.System$IObserver$1$OnError = $p.OnError;
    $p.OnErrorCore = function(error) {};
    $p.OnCompleted = function() {
        if ((function() {
            var $anon$1 = {
                value: this.isStopped
            };
            var $result$ = System.Threading.Interlocked.Exchange(System.Int32, $anon$1, 1);
            this.isStopped = $anon$1.value;
            return $result$;
        }).call(this) == 0) {
            this.OnCompletedCore();
        }
    };
    $p.System$IObserver$1$OnCompleted = $p.OnCompleted;
    $p.System$IObserver$1$OnCompleted = $p.OnCompleted;
    $p.System$IObserver$1$OnCompleted = $p.OnCompleted;
    $p.OnCompletedCore = function() {};
    $p.Dispose = function() {
        this.Dispose$1(true);
    };
    $p.System$IDisposable$Dispose = $p.Dispose;
    $p.Dispose$1 = function(disposing) {
        if (disposing) {
            this.isStopped = 1;
        }
    };
    $p.Fail = function(error) {
        if ((function() {
            var $anon$1 = {
                value: this.isStopped
            };
            var $result$ = System.Threading.Interlocked.Exchange(System.Int32, $anon$1, 1);
            this.isStopped = $anon$1.value;
            return $result$;
        }).call(this) == 0) {
            this.OnErrorCore(error);
            return true;
        }
        return false;
    };
}).call(null, System.Reactive.ObserverBase$1, System.Reactive.ObserverBase$1.prototype);
$WootzJs$Rx$AssemblyTypes.push(System.Reactive.ObserverBase$1);
System.Reactive.ObservableBase$1 = $define("System.Reactive.ObservableBase<T>", System.Object);
(System.Reactive.ObservableBase$1.$TypeInitializer = function($t, $p, T) {
    $t.$GetAssembly = window.$WootzJs$Rx$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Object;
    $p.$typeName = "System.Reactive.ObservableBase`1";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("ObservableBase", $arrayinit([], System.Attribute));this.$type.Init("System.Reactive.ObservableBase`1", System.Reactive.ObservableBase$1, System.Object, $arrayinit([System.IObservable$1], System.Type), $arrayinit([], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("Subscribe", System.Reactive.ObservableBase$1.prototype.Subscribe, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("observer", System.IObserver$1, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.IDisposable, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("SubscribeCore", System.Reactive.ObservableBase$1.prototype.SubscribeCore, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("observer", System.IObserver$1, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.IDisposable, System.Reflection.MethodAttributes().Family, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", System.Reactive.ObservableBase$1.prototype.$ctor, $arrayinit([], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Family, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {
        if ($t.$isStaticInitialized)
            return;
        $t.$isStaticInitialized = true;
        System.Object.$StaticInitializer();
    };
    $t.$ = function() {
        return $generic.call(null, System.Reactive.ObservableBase$1, arguments)();
    };
    window.System.Reactive.ObservableBase$1$ = $t.$;
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.Subscribe = function(observer) {
        if (observer == null)
            throw System.ArgumentNullException.prototype.$ctor.$new("observer").InternalInit(new Error());
        var autoDetachObserver = System.Reactive.AutoDetachObserver$1$(T).prototype.$ctor.$new(observer);
        try {
            autoDetachObserver.set_Disposable(this.SubscribeCore(autoDetachObserver));
        }
        catch (exception) {
            if (!autoDetachObserver.Fail(exception))
                throw exception;
        }
        return autoDetachObserver;
    };
    $p.System$IObservable$1$Subscribe = $p.Subscribe;
    $p.System$IObservable$1$Subscribe = $p.Subscribe;
    $p.SubscribeCore = function(observer) {};
}).call(null, System.Reactive.ObservableBase$1, System.Reactive.ObservableBase$1.prototype);
$WootzJs$Rx$AssemblyTypes.push(System.Reactive.ObservableBase$1);
System.Reactive.Producer$1 = $define("System.Reactive.Producer<TSource>", System.Object);
(System.Reactive.Producer$1.$TypeInitializer = function($t, $p, TSource) {
    $t.$GetAssembly = window.$WootzJs$Rx$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Object;
    $p.$typeName = "System.Reactive.Producer`1";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("Producer", $arrayinit([], System.Attribute));this.$type.Init("System.Reactive.Producer`1", System.Reactive.Producer$1, System.Object, $arrayinit([System.IObservable$1], System.Type), $arrayinit([], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("Subscribe", System.Reactive.Producer$1.prototype.Subscribe, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("observer", System.IObserver$1, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.IDisposable, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("SubscribeRaw", System.Reactive.Producer$1.prototype.SubscribeRaw, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("observer", System.IObserver$1, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("enableSafeguard", System.Boolean, 1, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.IDisposable, System.Reflection.MethodAttributes().Assembly, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Run", System.Reactive.Producer$1.prototype.Run, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("observer", System.IObserver$1, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("cancel", System.IDisposable, 1, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("setSink", System.Action$1, 2, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.IDisposable, System.Reflection.MethodAttributes().Family, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", System.Reactive.Producer$1.prototype.$ctor, $arrayinit([], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Family, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {
        if ($t.$isStaticInitialized)
            return;
        $t.$isStaticInitialized = true;
        System.Object.$StaticInitializer();
    };
    $t.$ = function() {
        return $generic.call(null, System.Reactive.Producer$1, arguments)();
    };
    window.System.Reactive.Producer$1$ = $t.$;
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.Subscribe = function(observer) {
        if (observer == null)
            throw System.ArgumentNullException.prototype.$ctor.$new("observer").InternalInit(new Error());
        return this.SubscribeRaw(observer, true);
    };
    $p.System$IObservable$1$Subscribe = $p.Subscribe;
    $p.System$IObservable$1$Subscribe = $p.Subscribe;
    $p.System$IObservable$1$Subscribe = $p.Subscribe;
    $p.System$IObservable$1$Subscribe = $p.Subscribe;
    $p.System$IObservable$1$Subscribe = $p.Subscribe;
    $p.SubscribeRaw = function(observer, enableSafeguard) {
        var state = System.Reactive.Producer$1$(TSource).State$().prototype.$ctor.$new();
        state.observer = observer;
        state.sink = System.Reactive.Disposables.SingleAssignmentDisposable.prototype.$ctor.$new();
        state.subscription = System.Reactive.Disposables.SingleAssignmentDisposable.prototype.$ctor.$new();
        var d = (function() {
            var $obj$ = System.Reactive.Disposables.CompositeDisposable.prototype.$ctor$3.$new(2);
            $obj$.Add(state.sink);
            $obj$.Add(state.subscription);
            return $obj$;
        }).call(this);
        if (enableSafeguard) {
            state.observer = System.Reactive.SafeObserver$1$(TSource).Create(state.observer, d);
        }
        state.subscription.set_Disposable(this.Run(state.observer, state.subscription, $delegate(
            state, 
            System.Action$1$(System.IDisposable), 
            state.Assign, 
            "Assign$delegate"
        )));
        return d;
    };
    $t.State = $define("System.Reactive.Producer<TSource>.State", System.Object);
    ($t.State.$TypeInitializer = function($t, $p) {
        $t.$GetAssembly = window.$WootzJs$Rx$GetAssembly;
        $p.$type = $t;
        $t.$baseType = System.Object;
        $p.$typeName = "System.Reactive.Producer`1.State";
        $t.$typeName = $p.$typeName;
        $t.$GetType = function() {
            return System.Type._GetTypeFromTypeFunc(this);
        };
        $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("State", $arrayinit([], System.Attribute));this.$type.Init("System.Reactive.Producer`1.State", System.Reactive.Producer$1.State, System.Object, $arrayinit([], System.Type), $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("sink", System.Reactive.Disposables.SingleAssignmentDisposable, System.Reflection.FieldAttributes().Public, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("subscription", System.Reactive.Disposables.SingleAssignmentDisposable, System.Reflection.FieldAttributes().Public, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("observer", System.IObserver$1, System.Reflection.FieldAttributes().Public, null, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("Assign", System.Reactive.Producer$1.State.prototype.Assign, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("s", System.IDisposable, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", System.Reactive.Producer$1.State.prototype.$ctor, $arrayinit([], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
        $t.$StaticInitializer = function() {
            if ($t.$isStaticInitialized)
                return;
            $t.$isStaticInitialized = true;
            System.Object.$StaticInitializer();
        };
        $t.$ = function() {
            return $generic.call(this, this.State, arguments)();
        };
        this.State$ = $t.$;
        $p.$ctor = function() {
            System.Object.prototype.$ctor.call(this);
        };
        $p.$ctor.$type = $t;
        $p.$ctor.$new = function() {
            return new $p.$ctor.$type(this);
        };
        $p.sink = null;
        $p.subscription = null;
        $p.observer = null;
        $p.Assign = function(s) {
            this.sink.set_Disposable(s);
        };
    }).call($t, $t.State, $t.State.prototype);
    $WootzJs$Rx$AssemblyTypes.push($t.State);
    $p.Run = function(observer, cancel, setSink) {};
}).call(null, System.Reactive.Producer$1, System.Reactive.Producer$1.prototype);
$WootzJs$Rx$AssemblyTypes.push(System.Reactive.Producer$1);
System.Reactive.Sink$1 = $define("System.Reactive.Sink<TSource>", System.Object);
(System.Reactive.Sink$1.$TypeInitializer = function($t, $p, TSource) {
    $t.$GetAssembly = window.$WootzJs$Rx$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Object;
    $p.$typeName = "System.Reactive.Sink`1";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("Sink", $arrayinit([], System.Attribute));this.$type.Init("System.Reactive.Sink`1", System.Reactive.Sink$1, System.Object, $arrayinit([System.IDisposable], System.Type), $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("_observer", System.IObserver$1, System.Reflection.FieldAttributes().FamORAssem, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("_cancel", System.IDisposable, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("Dispose", System.Reactive.Sink$1.prototype.Dispose, $arrayinit([], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("GetForwarder", System.Reactive.Sink$1.prototype.GetForwarder, $arrayinit([], System.Reflection.ParameterInfo), System.IObserver$1, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", System.Reactive.Sink$1.prototype.$ctor, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("observer", System.IObserver$1, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("cancel", System.IDisposable, 1, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Family, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {
        if ($t.$isStaticInitialized)
            return;
        $t.$isStaticInitialized = true;
        System.Object.$StaticInitializer();
    };
    $t.$ = function() {
        return $generic.call(null, System.Reactive.Sink$1, arguments)();
    };
    window.System.Reactive.Sink$1$ = $t.$;
    $p._observer = null;
    $p._cancel = null;
    $p.$ctor = function(observer, cancel) {
        System.Object.prototype.$ctor.call(this);
        this._observer = observer;
        this._cancel = cancel;
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function(observer, cancel) {
        return new $p.$ctor.$type(this, observer, cancel);
    };
    $p.Dispose = function() {
        this._observer = System.Reactive.NopObserver$1$(TSource).Instance;
        var cancel = (function() {
            var $anon$1 = {
                value: this._cancel
            };
            var $result$ = System.Threading.Interlocked.Exchange(System.IDisposable, $anon$1, null);
            this._cancel = $anon$1.value;
            return $result$;
        }).call(this);
        if (cancel != null) {
            cancel.System$IDisposable$Dispose();
        }
    };
    $p.System$IDisposable$Dispose = $p.Dispose;
    $p.GetForwarder = function() {
        return System.Reactive.Sink$1$(TSource)._$().prototype.$ctor.$new(this);
    };
    $t._ = $define("System.Reactive.Sink<TSource>._", System.Object);
    ($t._.$TypeInitializer = function($t, $p) {
        $t.$GetAssembly = window.$WootzJs$Rx$GetAssembly;
        $p.$type = $t;
        $t.$baseType = System.Object;
        $p.$typeName = "System.Reactive.Sink`1._";
        $t.$typeName = $p.$typeName;
        $t.$GetType = function() {
            return System.Type._GetTypeFromTypeFunc(this);
        };
        $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("_", $arrayinit([], System.Attribute));this.$type.Init("System.Reactive.Sink`1._", System.Reactive.Sink$1._, System.Object, $arrayinit([System.IObserver$1], System.Type), $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("_forward", System.Reactive.Sink$1, System.Reflection.FieldAttributes().Private | System.Reflection.FieldAttributes().InitOnly, null, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("OnNext", System.Reactive.Sink$1._.prototype.OnNext, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", TSource, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("OnError", System.Reactive.Sink$1._.prototype.OnError, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("error", System.Exception, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("OnCompleted", System.Reactive.Sink$1._.prototype.OnCompleted, $arrayinit([], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", System.Reactive.Sink$1._.prototype.$ctor, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("forward", System.Reactive.Sink$1, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
        $t.$StaticInitializer = function() {
            if ($t.$isStaticInitialized)
                return;
            $t.$isStaticInitialized = true;
            System.Object.$StaticInitializer();
        };
        $t.$ = function() {
            return $generic.call(this, this._, arguments)();
        };
        this._$ = $t.$;
        $p._forward = null;
        $p.$ctor = function(forward) {
            System.Object.prototype.$ctor.call(this);
            this._forward = forward;
        };
        $p.$ctor.$type = $t;
        $p.$ctor.$new = function(forward) {
            return new $p.$ctor.$type(this, forward);
        };
        $p.OnNext = function(value) {
            this._forward._observer.System$IObserver$1$OnNext(value);
        };
        $p.System$IObserver$1$OnNext = $p.OnNext;
        $p.OnError = function(error) {
            this._forward._observer.System$IObserver$1$OnError(error);
            this._forward.Dispose();
        };
        $p.System$IObserver$1$OnError = $p.OnError;
        $p.OnCompleted = function() {
            this._forward._observer.System$IObserver$1$OnCompleted();
            this._forward.Dispose();
        };
        $p.System$IObserver$1$OnCompleted = $p.OnCompleted;
    }).call($t, $t._, $t._.prototype);
    $WootzJs$Rx$AssemblyTypes.push($t._);
}).call(null, System.Reactive.Sink$1, System.Reactive.Sink$1.prototype);
$WootzJs$Rx$AssemblyTypes.push(System.Reactive.Sink$1);
System.Reactive.AnonymousSafeObserver$1 = $define("System.Reactive.AnonymousSafeObserver<T>", System.Object);
(System.Reactive.AnonymousSafeObserver$1.$TypeInitializer = function($t, $p, T) {
    $t.$GetAssembly = window.$WootzJs$Rx$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Object;
    $p.$typeName = "System.Reactive.AnonymousSafeObserver`1";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("AnonymousSafeObserver", $arrayinit([], System.Attribute));this.$type.Init("System.Reactive.AnonymousSafeObserver`1", System.Reactive.AnonymousSafeObserver$1, System.Object, $arrayinit([System.IObserver$1], System.Type), $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("_onNext", System.Action$1, System.Reflection.FieldAttributes().Private | System.Reflection.FieldAttributes().InitOnly, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("_onError", System.Action$1, System.Reflection.FieldAttributes().Private | System.Reflection.FieldAttributes().InitOnly, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("_onCompleted", System.Action, System.Reflection.FieldAttributes().Private | System.Reflection.FieldAttributes().InitOnly, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("_disposable", System.IDisposable, System.Reflection.FieldAttributes().Private | System.Reflection.FieldAttributes().InitOnly, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("isStopped", System.Int32, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("OnNext", System.Reactive.AnonymousSafeObserver$1.prototype.OnNext, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", T, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("OnError", System.Reactive.AnonymousSafeObserver$1.prototype.OnError, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("error", System.Exception, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("OnCompleted", System.Reactive.AnonymousSafeObserver$1.prototype.OnCompleted, $arrayinit([], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", System.Reactive.AnonymousSafeObserver$1.prototype.$ctor, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("onNext", System.Action$1, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("onError", System.Action$1, 1, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("onCompleted", System.Action, 2, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("disposable", System.IDisposable, 3, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {
        if ($t.$isStaticInitialized)
            return;
        $t.$isStaticInitialized = true;
        System.Object.$StaticInitializer();
    };
    $t.$ = function() {
        return $generic.call(null, System.Reactive.AnonymousSafeObserver$1, arguments)();
    };
    window.System.Reactive.AnonymousSafeObserver$1$ = $t.$;
    $p._onNext = null;
    $p._onError = null;
    $p._onCompleted = null;
    $p._disposable = null;
    $p.isStopped = 0;
    $p.$ctor = function(onNext, onError, onCompleted, disposable) {
        System.Object.prototype.$ctor.call(this);
        this._onNext = onNext;
        this._onError = onError;
        this._onCompleted = onCompleted;
        this._disposable = disposable;
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function(onNext, onError, onCompleted, disposable) {
        return new $p.$ctor.$type(
            this, 
            onNext, 
            onError, 
            onCompleted, 
            disposable
        );
    };
    $p.OnNext = function(value) {
        if (this.isStopped == 0) {
            var __noError = false;
            try {
                this._onNext(value);
                __noError = true;
            }
            finally {
                if (!__noError)
                    this._disposable.System$IDisposable$Dispose();
            }
        }
    };
    $p.System$IObserver$1$OnNext = $p.OnNext;
    $p.OnError = function(error) {
        if ((function() {
            var $anon$1 = {
                value: this.isStopped
            };
            var $result$ = System.Threading.Interlocked.Exchange(System.Int32, $anon$1, 1);
            this.isStopped = $anon$1.value;
            return $result$;
        }).call(this) == 0) {
            try {
                this._onError(error);
            }
            finally {
                this._disposable.System$IDisposable$Dispose();
            }
        }
    };
    $p.System$IObserver$1$OnError = $p.OnError;
    $p.OnCompleted = function() {
        if ((function() {
            var $anon$1 = {
                value: this.isStopped
            };
            var $result$ = System.Threading.Interlocked.Exchange(System.Int32, $anon$1, 1);
            this.isStopped = $anon$1.value;
            return $result$;
        }).call(this) == 0) {
            try {
                this._onCompleted();
            }
            finally {
                this._disposable.System$IDisposable$Dispose();
            }
        }
    };
    $p.System$IObserver$1$OnCompleted = $p.OnCompleted;
}).call(null, System.Reactive.AnonymousSafeObserver$1, System.Reactive.AnonymousSafeObserver$1.prototype);
$WootzJs$Rx$AssemblyTypes.push(System.Reactive.AnonymousSafeObserver$1);
System.Reactive.AnonymousObserver$1 = $define("System.Reactive.AnonymousObserver<T>", System.Reactive.ObserverBase$1);
(System.Reactive.AnonymousObserver$1.$TypeInitializer = function($t, $p, T) {
    $t.$GetAssembly = window.$WootzJs$Rx$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Reactive.ObserverBase$1;
    $p.$typeName = "System.Reactive.AnonymousObserver`1";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("AnonymousObserver", $arrayinit([], System.Attribute));this.$type.Init("System.Reactive.AnonymousObserver`1", System.Reactive.AnonymousObserver$1, System.Reactive.ObserverBase$1$(T), $arrayinit([System.IDisposable, System.IObserver$1], System.Type), $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("_onNext", System.Action$1, System.Reflection.FieldAttributes().Private | System.Reflection.FieldAttributes().InitOnly, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("_onError", System.Action$1, System.Reflection.FieldAttributes().Private | System.Reflection.FieldAttributes().InitOnly, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("_onCompleted", System.Action, System.Reflection.FieldAttributes().Private | System.Reflection.FieldAttributes().InitOnly, null, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("OnNextCore", System.Reactive.AnonymousObserver$1.prototype.OnNextCore, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", T, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Family, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("OnErrorCore", System.Reactive.AnonymousObserver$1.prototype.OnErrorCore, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("error", System.Exception, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Family, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("OnCompletedCore", System.Reactive.AnonymousObserver$1.prototype.OnCompletedCore, $arrayinit([], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Family, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("MakeSafe", System.Reactive.AnonymousObserver$1.prototype.MakeSafe, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("disposable", System.IDisposable, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.IObserver$1, System.Reflection.MethodAttributes().Assembly, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor$3", System.Reactive.AnonymousObserver$1.prototype.$ctor$3, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("onNext", System.Action$1, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("onError", System.Action$1, 1, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("onCompleted", System.Action, 2, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", System.Reactive.AnonymousObserver$1.prototype.$ctor, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("onNext", System.Action$1, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor$2", System.Reactive.AnonymousObserver$1.prototype.$ctor$2, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("onNext", System.Action$1, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("onError", System.Action$1, 1, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor$1", System.Reactive.AnonymousObserver$1.prototype.$ctor$1, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("onNext", System.Action$1, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("onCompleted", System.Action, 1, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {
        if ($t.$isStaticInitialized)
            return;
        $t.$isStaticInitialized = true;
        System.Reactive.ObserverBase$1$(T).$StaticInitializer();
    };
    $t.$ = function() {
        return $generic.call(null, System.Reactive.AnonymousObserver$1, arguments)();
    };
    window.System.Reactive.AnonymousObserver$1$ = $t.$;
    $p._onNext = null;
    $p._onError = null;
    $p._onCompleted = null;
    $p.$ctor$3 = function(onNext, onError, onCompleted) {
        System.Reactive.ObserverBase$1$(T).prototype.$ctor.call(this);
        if (onNext == null)
            throw System.ArgumentNullException.prototype.$ctor.$new("onNext").InternalInit(new Error());
        if (onError == null)
            throw System.ArgumentNullException.prototype.$ctor.$new("onError").InternalInit(new Error());
        if (onCompleted == null)
            throw System.ArgumentNullException.prototype.$ctor.$new("onCompleted").InternalInit(new Error());
        this._onNext = onNext;
        this._onError = onError;
        this._onCompleted = onCompleted;
    };
    $p.$ctor$3.$type = $t;
    $p.$ctor$3.$new = function(onNext, onError, onCompleted) {
        return new $p.$ctor$3.$type(
            this, 
            onNext, 
            onError, 
            onCompleted
        );
    };
    $p.$ctor = function(onNext) {
        System.Reactive.AnonymousObserver$1$(T).prototype.$ctor$3.call(
            this, 
            onNext, 
            System.Reactive.Stubs().Throw, 
            System.Reactive.Stubs().Nop
        );
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function(onNext) {
        return new $p.$ctor.$type(this, onNext);
    };
    $p.$ctor$2 = function(onNext, onError) {
        System.Reactive.AnonymousObserver$1$(T).prototype.$ctor$3.call(
            this, 
            onNext, 
            onError, 
            System.Reactive.Stubs().Nop
        );
    };
    $p.$ctor$2.$type = $t;
    $p.$ctor$2.$new = function(onNext, onError) {
        return new $p.$ctor$2.$type(this, onNext, onError);
    };
    $p.$ctor$1 = function(onNext, onCompleted) {
        System.Reactive.AnonymousObserver$1$(T).prototype.$ctor$3.call(
            this, 
            onNext, 
            System.Reactive.Stubs().Throw, 
            onCompleted
        );
    };
    $p.$ctor$1.$type = $t;
    $p.$ctor$1.$new = function(onNext, onCompleted) {
        return new $p.$ctor$1.$type(this, onNext, onCompleted);
    };
    $p.OnNextCore = function(value) {
        this._onNext(value);
    };
    $p.OnErrorCore = function(error) {
        this._onError(error);
    };
    $p.OnCompletedCore = function() {
        this._onCompleted();
    };
    $p.MakeSafe = function(disposable) {
        return System.Reactive.AnonymousSafeObserver$1$(T).prototype.$ctor.$new(
            this._onNext, 
            this._onError, 
            this._onCompleted, 
            disposable
        );
    };
}).call(null, System.Reactive.AnonymousObserver$1, System.Reactive.AnonymousObserver$1.prototype);
$WootzJs$Rx$AssemblyTypes.push(System.Reactive.AnonymousObserver$1);
System.Reactive.AutoDetachObserver$1 = $define("System.Reactive.AutoDetachObserver<T>", System.Reactive.ObserverBase$1);
(System.Reactive.AutoDetachObserver$1.$TypeInitializer = function($t, $p, T) {
    $t.$GetAssembly = window.$WootzJs$Rx$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Reactive.ObserverBase$1;
    $p.$typeName = "System.Reactive.AutoDetachObserver`1";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("AutoDetachObserver", $arrayinit([], System.Attribute));this.$type.Init("System.Reactive.AutoDetachObserver`1", System.Reactive.AutoDetachObserver$1, System.Reactive.ObserverBase$1$(T), $arrayinit([System.IDisposable, System.IObserver$1], System.Type), $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("observer", System.IObserver$1, System.Reflection.FieldAttributes().Private | System.Reflection.FieldAttributes().InitOnly, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("m", System.Reactive.Disposables.SingleAssignmentDisposable, System.Reflection.FieldAttributes().Private | System.Reflection.FieldAttributes().InitOnly, null, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("set_Disposable", System.Reactive.AutoDetachObserver$1.prototype.set_Disposable, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.IDisposable, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("OnNextCore", System.Reactive.AutoDetachObserver$1.prototype.OnNextCore, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", T, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Family, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("OnErrorCore", System.Reactive.AutoDetachObserver$1.prototype.OnErrorCore, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("exception", System.Exception, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Family, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("OnCompletedCore", System.Reactive.AutoDetachObserver$1.prototype.OnCompletedCore, $arrayinit([], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Family, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Dispose$1", System.Reactive.AutoDetachObserver$1.prototype.Dispose$1, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("disposing", System.Boolean, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Family, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", System.Reactive.AutoDetachObserver$1.prototype.$ctor, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("observer", System.IObserver$1, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.PropertyInfo.prototype.$ctor.$new("Disposable", System.IDisposable, null, System.Reflection.MethodInfo.prototype.$ctor.$new("set_Disposable", System.Reactive.AutoDetachObserver$1.prototype.set_Disposable, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.IDisposable, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute))], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {
        if ($t.$isStaticInitialized)
            return;
        $t.$isStaticInitialized = true;
        System.Reactive.ObserverBase$1$(T).$StaticInitializer();
    };
    $t.$ = function() {
        return $generic.call(null, System.Reactive.AutoDetachObserver$1, arguments)();
    };
    window.System.Reactive.AutoDetachObserver$1$ = $t.$;
    $p.observer = null;
    $p.m = null;
    $p.$ctor = function(observer) {
        System.Reactive.ObserverBase$1$(T).prototype.$ctor.call(this);
        this.m = System.Reactive.Disposables.SingleAssignmentDisposable.prototype.$ctor.$new();
        this.observer = observer;
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function(observer) {
        return new $p.$ctor.$type(this, observer);
    };
    $p.set_Disposable = function(value) {
        this.m.set_Disposable(value);
    };
    $p.OnNextCore = function(value) {
        var __noError = false;
        try {
            this.observer.System$IObserver$1$OnNext(value);
            __noError = true;
        }
        finally {
            if (!__noError)
                this.Dispose();
        }
    };
    $p.OnErrorCore = function(exception) {
        try {
            this.observer.System$IObserver$1$OnError(exception);
        }
        finally {
            this.Dispose();
        }
    };
    $p.OnCompletedCore = function() {
        try {
            this.observer.System$IObserver$1$OnCompleted();
        }
        finally {
            this.Dispose();
        }
    };
    $p.Dispose$1 = function(disposing) {
        System.Reactive.ObserverBase$1$(T).prototype.Dispose$1.call(this, disposing);
        if (disposing)
            this.m.Dispose();
    };
}).call(null, System.Reactive.AutoDetachObserver$1, System.Reactive.AutoDetachObserver$1.prototype);
$WootzJs$Rx$AssemblyTypes.push(System.Reactive.AutoDetachObserver$1);
System.Reactive.Disposables.AnonymousDisposable = $define("System.Reactive.Disposables.AnonymousDisposable", System.Object);
(System.Reactive.Disposables.AnonymousDisposable.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Rx$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Object;
    $p.$typeName = "System.Reactive.Disposables.AnonymousDisposable";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("AnonymousDisposable", $arrayinit([], System.Attribute));this.$type.Init("System.Reactive.Disposables.AnonymousDisposable", System.Reactive.Disposables.AnonymousDisposable, System.Object, $arrayinit([System.Reactive.Disposables.ICancelable, System.IDisposable], System.Type), $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("_dispose", System.Action, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("get_IsDisposed", System.Reactive.Disposables.AnonymousDisposable.prototype.get_IsDisposed, $arrayinit([], System.Reflection.ParameterInfo), System.Boolean, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Dispose", System.Reactive.Disposables.AnonymousDisposable.prototype.Dispose, $arrayinit([], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", System.Reactive.Disposables.AnonymousDisposable.prototype.$ctor, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("dispose", System.Action, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.PropertyInfo.prototype.$ctor.$new("IsDisposed", System.Boolean, System.Reflection.MethodInfo.prototype.$ctor.$new("get_IsDisposed", System.Reactive.Disposables.AnonymousDisposable.prototype.get_IsDisposed, $arrayinit([], System.Reflection.ParameterInfo), System.Boolean, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), null, $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute))], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {
        if ($t.$isStaticInitialized)
            return;
        $t.$isStaticInitialized = true;
        System.Object.$StaticInitializer();
    };
    $p._dispose = null;
    $p.$ctor = function(dispose) {
        System.Object.prototype.$ctor.call(this);
        System.Diagnostics.Debug.Assert(dispose != null);
        this._dispose = dispose;
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function(dispose) {
        return new $p.$ctor.$type(this, dispose);
    };
    $p.get_IsDisposed = function() {
        return this._dispose == null;
    };
    $p.System$Reactive$Disposables$ICancelable$get_IsDisposed = $p.get_IsDisposed;
    $p.Dispose = function() {
        var dispose = (function() {
            var $anon$1 = {
                value: this._dispose
            };
            var $result$ = System.Threading.Interlocked.Exchange(System.Action, $anon$1, null);
            this._dispose = $anon$1.value;
            return $result$;
        }).call(this);
        if (dispose != null) {
            dispose();
        }
    };
    $p.System$IDisposable$Dispose = $p.Dispose;
}).call(null, System.Reactive.Disposables.AnonymousDisposable, System.Reactive.Disposables.AnonymousDisposable.prototype);
$WootzJs$Rx$AssemblyTypes.push(System.Reactive.Disposables.AnonymousDisposable);
System.Reactive.Disposables.BooleanDisposable = $define("System.Reactive.Disposables.BooleanDisposable", System.Object);
(System.Reactive.Disposables.BooleanDisposable.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Rx$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Object;
    $p.$typeName = "System.Reactive.Disposables.BooleanDisposable";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("BooleanDisposable", $arrayinit([], System.Attribute));this.$type.Init("System.Reactive.Disposables.BooleanDisposable", System.Reactive.Disposables.BooleanDisposable, System.Object, $arrayinit([System.Reactive.Disposables.ICancelable, System.IDisposable], System.Type), $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("True", System.Reactive.Disposables.BooleanDisposable, System.Reflection.FieldAttributes().Assembly | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().InitOnly, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("_isDisposed", System.Boolean, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("$cctor", System.Reactive.Disposables.BooleanDisposable.prototype.$cctor, $arrayinit([], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Private | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_IsDisposed", System.Reactive.Disposables.BooleanDisposable.prototype.get_IsDisposed, $arrayinit([], System.Reflection.ParameterInfo), System.Boolean, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Dispose", System.Reactive.Disposables.BooleanDisposable.prototype.Dispose, $arrayinit([], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", System.Reactive.Disposables.BooleanDisposable.prototype.$ctor, $arrayinit([], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor$1", System.Reactive.Disposables.BooleanDisposable.prototype.$ctor$1, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("isDisposed", System.Boolean, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Private, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.PropertyInfo.prototype.$ctor.$new("IsDisposed", System.Boolean, System.Reflection.MethodInfo.prototype.$ctor.$new("get_IsDisposed", System.Reactive.Disposables.BooleanDisposable.prototype.get_IsDisposed, $arrayinit([], System.Reflection.ParameterInfo), System.Boolean, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), null, $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute))], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {
        if ($t.$isStaticInitialized)
            return;
        $t.$isStaticInitialized = true;
        System.Object.$StaticInitializer();
        System.Reactive.Disposables.BooleanDisposable.True = System.Reactive.Disposables.BooleanDisposable.prototype.$ctor$1.$new(true);
    };
    $p.True = null;
    $p._isDisposed = false;
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.$ctor$1 = function(isDisposed) {
        System.Object.prototype.$ctor.call(this);
        this._isDisposed = isDisposed;
    };
    $p.$ctor$1.$type = $t;
    $p.$ctor$1.$new = function(isDisposed) {
        return new $p.$ctor$1.$type(this, isDisposed);
    };
    $p.get_IsDisposed = function() {
        return this._isDisposed;
    };
    $p.System$Reactive$Disposables$ICancelable$get_IsDisposed = $p.get_IsDisposed;
    $p.Dispose = function() {
        this._isDisposed = true;
    };
    $p.System$IDisposable$Dispose = $p.Dispose;
}).call(null, System.Reactive.Disposables.BooleanDisposable, System.Reactive.Disposables.BooleanDisposable.prototype);
$WootzJs$Rx$AssemblyTypes.push(System.Reactive.Disposables.BooleanDisposable);
System.Reactive.Disposables.CompositeDisposable = $define("System.Reactive.Disposables.CompositeDisposable", System.Object);
(System.Reactive.Disposables.CompositeDisposable.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Rx$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Object;
    $p.$typeName = "System.Reactive.Disposables.CompositeDisposable";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("CompositeDisposable", $arrayinit([], System.Attribute));this.$type.Init("System.Reactive.Disposables.CompositeDisposable", System.Reactive.Disposables.CompositeDisposable, System.Object, $arrayinit([System.Reactive.Disposables.ICancelable, System.IDisposable, System.Collections.Generic.ICollection$1, System.Collections.Generic.IEnumerable$1, System.Collections.IEnumerable], System.Type), $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("_disposed", System.Boolean, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("_disposables", System.Collections.Generic.List$1, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("_count", System.Int32, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("get_Count", System.Reactive.Disposables.CompositeDisposable.prototype.get_Count, $arrayinit([], System.Reflection.ParameterInfo), System.Int32, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Add", System.Reactive.Disposables.CompositeDisposable.prototype.Add, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("item", System.IDisposable, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Remove", System.Reactive.Disposables.CompositeDisposable.prototype.Remove, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("item", System.IDisposable, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Boolean, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Dispose", System.Reactive.Disposables.CompositeDisposable.prototype.Dispose, $arrayinit([], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Clear", System.Reactive.Disposables.CompositeDisposable.prototype.Clear, $arrayinit([], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Contains", System.Reactive.Disposables.CompositeDisposable.prototype.Contains, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("item", System.IDisposable, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Boolean, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("CopyTo", System.Reactive.Disposables.CompositeDisposable.prototype.CopyTo, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("array", $array(System.IDisposable), 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("arrayIndex", System.Int32, 1, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_IsReadOnly", System.Reactive.Disposables.CompositeDisposable.prototype.get_IsReadOnly, $arrayinit([], System.Reflection.ParameterInfo), System.Boolean, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("GetEnumerator", System.Reactive.Disposables.CompositeDisposable.prototype.GetEnumerator, $arrayinit([], System.Reflection.ParameterInfo), System.Collections.Generic.IEnumerator$1, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("System$Collections$IEnumerable$GetEnumerator", System.Reactive.Disposables.CompositeDisposable.prototype.System$Collections$IEnumerable$GetEnumerator, $arrayinit([], System.Reflection.ParameterInfo), System.Collections.IEnumerator, System.Reflection.MethodAttributes().Private, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_IsDisposed", System.Reactive.Disposables.CompositeDisposable.prototype.get_IsDisposed, $arrayinit([], System.Reflection.ParameterInfo), System.Boolean, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", System.Reactive.Disposables.CompositeDisposable.prototype.$ctor, $arrayinit([], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor$3", System.Reactive.Disposables.CompositeDisposable.prototype.$ctor$3, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("capacity", System.Int32, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor$2", System.Reactive.Disposables.CompositeDisposable.prototype.$ctor$2, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("disposables", $array(System.IDisposable), 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor$1", System.Reactive.Disposables.CompositeDisposable.prototype.$ctor$1, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("disposables", System.Collections.Generic.IEnumerable$1, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.PropertyInfo.prototype.$ctor.$new("Count", System.Int32, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Count", System.Reactive.Disposables.CompositeDisposable.prototype.get_Count, $arrayinit([], System.Reflection.ParameterInfo), System.Int32, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), null, $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("IsReadOnly", System.Boolean, System.Reflection.MethodInfo.prototype.$ctor.$new("get_IsReadOnly", System.Reactive.Disposables.CompositeDisposable.prototype.get_IsReadOnly, $arrayinit([], System.Reflection.ParameterInfo), System.Boolean, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), null, $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("IsDisposed", System.Boolean, System.Reflection.MethodInfo.prototype.$ctor.$new("get_IsDisposed", System.Reactive.Disposables.CompositeDisposable.prototype.get_IsDisposed, $arrayinit([], System.Reflection.ParameterInfo), System.Boolean, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), null, $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute))], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {
        if ($t.$isStaticInitialized)
            return;
        $t.$isStaticInitialized = true;
        System.Object.$StaticInitializer();
    };
    $p._disposed = false;
    $p._disposables = null;
    $p._count = 0;
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
        this._disposables = System.Collections.Generic.List$1$(System.IDisposable).prototype.$ctor.$new();
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.$ctor$3 = function(capacity) {
        System.Object.prototype.$ctor.call(this);
        if (capacity < 0)
            throw System.ArgumentOutOfRangeException.prototype.$ctor$1.$new("capacity").InternalInit(new Error());
        this._disposables = System.Collections.Generic.List$1$(System.IDisposable).prototype.$ctor.$new();
    };
    $p.$ctor$3.$type = $t;
    $p.$ctor$3.$new = function(capacity) {
        return new $p.$ctor$3.$type(this, capacity);
    };
    $p.$ctor$2 = function(disposables) {
        System.Object.prototype.$ctor.call(this);
        if (disposables == null)
            throw System.ArgumentNullException.prototype.$ctor.$new("disposables").InternalInit(new Error());
        this._disposables = System.Collections.Generic.List$1$(System.IDisposable).prototype.$ctor$1.$new(disposables);
        this._count = this._disposables.get_Count();
    };
    $p.$ctor$2.$type = $t;
    $p.$ctor$2.$new = function(disposables) {
        return new $p.$ctor$2.$type(this, disposables);
    };
    $p.$ctor$1 = function(disposables) {
        System.Object.prototype.$ctor.call(this);
        if (disposables == null)
            throw System.ArgumentNullException.prototype.$ctor.$new("disposables").InternalInit(new Error());
        this._disposables = System.Collections.Generic.List$1$(System.IDisposable).prototype.$ctor$1.$new(disposables);
        this._count = this._disposables.get_Count();
    };
    $p.$ctor$1.$type = $t;
    $p.$ctor$1.$new = function(disposables) {
        return new $p.$ctor$1.$type(this, disposables);
    };
    $p.get_Count = function() {
        return this._count;
    };
    $p.Add = function(item) {
        if (item == null)
            throw System.ArgumentNullException.prototype.$ctor.$new("item").InternalInit(new Error());
        var shouldDispose;
        shouldDispose = this._disposed;
        if (!this._disposed) {
            this._disposables.Add(item);
            this._count++;
        }
        if (shouldDispose)
            item.System$IDisposable$Dispose();
    };
    $p.System$Collections$Generic$ICollection$1$Add = $p.Add;
    $p.Remove = function(item) {
        if (item == null)
            throw System.ArgumentNullException.prototype.$ctor.$new("item").InternalInit(new Error());
        var shouldDispose = false;
        if (!this._disposed) {
            var i = this._disposables.IndexOf(item);
            if (i >= 0) {
                shouldDispose = true;
                this._disposables.set_Item(i, null);
                this._count--;
            }
        }
        if (shouldDispose)
            item.System$IDisposable$Dispose();
        return shouldDispose;
    };
    $p.System$Collections$Generic$ICollection$1$Remove = $p.Remove;
    $p.Dispose = function() {
        var currentDisposables = null;
        if (!this._disposed) {
            this._disposed = true;
            currentDisposables = System.Linq.Enumerable.ToArray(System.IDisposable, this._disposables);
            this._disposables.Clear();
            this._count = 0;
        }
        if (currentDisposables != null) {
            {
                var $anon$1iterator = currentDisposables;
                var $anon$2enumerator = $anon$1iterator.System$Collections$IEnumerable$GetEnumerator();
                while ($anon$2enumerator.System$Collections$IEnumerator$MoveNext()) {
                    var d = $anon$2enumerator.System$Collections$IEnumerator$get_Current();
                    if (d != null)
                        d.System$IDisposable$Dispose();
                }
            }
        }
    };
    $p.System$IDisposable$Dispose = $p.Dispose;
    $p.Clear = function() {
        var currentDisposables = System.Linq.Enumerable.ToArray(System.IDisposable, this._disposables);
        this._disposables.Clear();
        this._count = 0;
        {
            var $anon$1iterator = currentDisposables;
            var $anon$2enumerator = $anon$1iterator.System$Collections$IEnumerable$GetEnumerator();
            while ($anon$2enumerator.System$Collections$IEnumerator$MoveNext()) {
                var d = $anon$2enumerator.System$Collections$IEnumerator$get_Current();
                if (d != null)
                    d.System$IDisposable$Dispose();
            }
        }
    };
    $p.System$Collections$Generic$ICollection$1$Clear = $p.Clear;
    $p.Contains = function(item) {
        if (item == null)
            throw System.ArgumentNullException.prototype.$ctor.$new("item").InternalInit(new Error());
        return this._disposables.Contains(item);
    };
    $p.System$Collections$Generic$ICollection$1$Contains = $p.Contains;
    $p.CopyTo = function(array, arrayIndex) {
        if (array == null)
            throw System.ArgumentNullException.prototype.$ctor.$new("array").InternalInit(new Error());
        if (arrayIndex < 0 || arrayIndex >= array.length)
            throw System.ArgumentOutOfRangeException.prototype.$ctor$1.$new("arrayIndex").InternalInit(new Error());
        Array.Copy$2(
            System.Linq.Enumerable.ToArray(System.IDisposable, System.Linq.Enumerable.Where(System.IDisposable, this._disposables, $delegate(this, System.Func$2$(System.IDisposable, System.Boolean), function(d) {
                return d != null;
            }))), 
            0, 
            array, 
            arrayIndex, 
            array.length - arrayIndex
        );
    };
    $p.System$Collections$Generic$ICollection$1$CopyTo = $p.CopyTo;
    $p.get_IsReadOnly = function() {
        return false;
    };
    $p.System$Collections$Generic$ICollection$1$get_IsReadOnly = $p.get_IsReadOnly;
    $p.GetEnumerator = function() {
        var res = System.Linq.Enumerable.ToList(System.IDisposable, System.Linq.Enumerable.Where(System.IDisposable, this._disposables, $delegate(this, System.Func$2$(System.IDisposable, System.Boolean), function(d) {
            return d != null;
        })));
        return res.System$Collections$Generic$IEnumerable$1$GetEnumerator();
    };
    $p.System$Collections$Generic$IEnumerable$1$GetEnumerator = $p.GetEnumerator;
    $p.System$Collections$IEnumerable$GetEnumerator = function() {
        return this.GetEnumerator();
    };
    $p.System$Collections$IEnumerable$GetEnumerator = $p.System$Collections$IEnumerable$GetEnumerator;
    $p.get_IsDisposed = function() {
        return this._disposed;
    };
    $p.System$Reactive$Disposables$ICancelable$get_IsDisposed = $p.get_IsDisposed;
}).call(null, System.Reactive.Disposables.CompositeDisposable, System.Reactive.Disposables.CompositeDisposable.prototype);
$WootzJs$Rx$AssemblyTypes.push(System.Reactive.Disposables.CompositeDisposable);
System.Reactive.Disposables.DefaultDisposable = $define("System.Reactive.Disposables.DefaultDisposable", System.Object);
(System.Reactive.Disposables.DefaultDisposable.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Rx$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Object;
    $p.$typeName = "System.Reactive.Disposables.DefaultDisposable";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("DefaultDisposable", $arrayinit([], System.Attribute));this.$type.Init("System.Reactive.Disposables.DefaultDisposable", System.Reactive.Disposables.DefaultDisposable, System.Object, $arrayinit([System.IDisposable], System.Type), $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("Instance", System.Reactive.Disposables.DefaultDisposable, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().InitOnly, null, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("$cctor", System.Reactive.Disposables.DefaultDisposable.prototype.$cctor, $arrayinit([], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Private | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Dispose", System.Reactive.Disposables.DefaultDisposable.prototype.Dispose, $arrayinit([], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", System.Reactive.Disposables.DefaultDisposable.prototype.$ctor, $arrayinit([], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Private, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {
        if ($t.$isStaticInitialized)
            return;
        $t.$isStaticInitialized = true;
        System.Object.$StaticInitializer();
        System.Reactive.Disposables.DefaultDisposable.Instance = System.Reactive.Disposables.DefaultDisposable.prototype.$ctor.$new();
    };
    $p.Instance = null;
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.Dispose = function() {};
    $p.System$IDisposable$Dispose = $p.Dispose;
}).call(null, System.Reactive.Disposables.DefaultDisposable, System.Reactive.Disposables.DefaultDisposable.prototype);
$WootzJs$Rx$AssemblyTypes.push(System.Reactive.Disposables.DefaultDisposable);
System.Reactive.Disposables.Disposable = $define("System.Reactive.Disposables.Disposable", System.Object);
(System.Reactive.Disposables.Disposable.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Rx$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Object;
    $p.$typeName = "System.Reactive.Disposables.Disposable";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("Disposable", $arrayinit([], System.Attribute));this.$type.Init("System.Reactive.Disposables.Disposable", System.Reactive.Disposables.Disposable, System.Object, $arrayinit([], System.Type), $arrayinit([], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("get_Empty", System.Reactive.Disposables.Disposable.prototype.get_Empty, $arrayinit([], System.Reflection.ParameterInfo), System.IDisposable, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Create", System.Reactive.Disposables.Disposable.prototype.Create, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("dispose", System.Action, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.IDisposable, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.MethodInfo), $arrayinit([System.Reflection.PropertyInfo.prototype.$ctor.$new("Empty", System.IDisposable, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Empty", System.Reactive.Disposables.Disposable.prototype.get_Empty, $arrayinit([], System.Reflection.ParameterInfo), System.IDisposable, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute)), null, $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute))], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {
        if ($t.$isStaticInitialized)
            return;
        $t.$isStaticInitialized = true;
        System.Object.$StaticInitializer();
    };
    $t.get_Empty = function() {
        return System.Reactive.Disposables.DefaultDisposable().Instance;
    };
    $t.Create = function(dispose) {
        if (dispose == null)
            throw System.ArgumentNullException.prototype.$ctor.$new("dispose").InternalInit(new Error());
        return System.Reactive.Disposables.AnonymousDisposable.prototype.$ctor.$new(dispose);
    };
}).call(null, System.Reactive.Disposables.Disposable, System.Reactive.Disposables.Disposable.prototype);
$WootzJs$Rx$AssemblyTypes.push(System.Reactive.Disposables.Disposable);
System.Reactive.Disposables.ICancelable = $define("System.Reactive.Disposables.ICancelable", System.Object);
(System.Reactive.Disposables.ICancelable.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Rx$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Object;
    $p.$typeName = "System.Reactive.Disposables.ICancelable";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("ICancelable", $arrayinit([], System.Attribute));this.$type.Init("System.Reactive.Disposables.ICancelable", System.Reactive.Disposables.ICancelable, null, $arrayinit([System.IDisposable], System.Type), $arrayinit([], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("System$Reactive$Disposables$ICancelable$get_IsDisposed", System.Reactive.Disposables.ICancelable.prototype.System$Reactive$Disposables$ICancelable$get_IsDisposed, $arrayinit([], System.Reflection.ParameterInfo), System.Boolean, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.MethodInfo), $arrayinit([System.Reflection.PropertyInfo.prototype.$ctor.$new("IsDisposed", System.Boolean, System.Reflection.MethodInfo.prototype.$ctor.$new("System$Reactive$Disposables$ICancelable$get_IsDisposed", System.Reactive.Disposables.ICancelable.prototype.System$Reactive$Disposables$ICancelable$get_IsDisposed, $arrayinit([], System.Reflection.ParameterInfo), System.Boolean, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), null, $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute))], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {
        if ($t.$isStaticInitialized)
            return;
        $t.$isStaticInitialized = true;
    };
    $p.System$Reactive$Disposables$ICancelable$get_IsDisposed = function() {};
}).call(null, System.Reactive.Disposables.ICancelable, System.Reactive.Disposables.ICancelable.prototype);
$WootzJs$Rx$AssemblyTypes.push(System.Reactive.Disposables.ICancelable);
System.Reactive.Disposables.RefCountDisposable = $define("System.Reactive.Disposables.RefCountDisposable", System.Object);
(System.Reactive.Disposables.RefCountDisposable.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Rx$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Object;
    $p.$typeName = "System.Reactive.Disposables.RefCountDisposable";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("RefCountDisposable", $arrayinit([], System.Attribute));this.$type.Init("System.Reactive.Disposables.RefCountDisposable", System.Reactive.Disposables.RefCountDisposable, System.Object, $arrayinit([System.Reactive.Disposables.ICancelable, System.IDisposable], System.Type), $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("_disposable", System.IDisposable, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("_isPrimaryDisposed", System.Boolean, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("_count", System.Int32, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("get_IsDisposed", System.Reactive.Disposables.RefCountDisposable.prototype.get_IsDisposed, $arrayinit([], System.Reflection.ParameterInfo), System.Boolean, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("GetDisposable", System.Reactive.Disposables.RefCountDisposable.prototype.GetDisposable, $arrayinit([], System.Reflection.ParameterInfo), System.IDisposable, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Dispose", System.Reactive.Disposables.RefCountDisposable.prototype.Dispose, $arrayinit([], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Release", System.Reactive.Disposables.RefCountDisposable.prototype.Release, $arrayinit([], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Private, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", System.Reactive.Disposables.RefCountDisposable.prototype.$ctor, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("disposable", System.IDisposable, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.PropertyInfo.prototype.$ctor.$new("IsDisposed", System.Boolean, System.Reflection.MethodInfo.prototype.$ctor.$new("get_IsDisposed", System.Reactive.Disposables.RefCountDisposable.prototype.get_IsDisposed, $arrayinit([], System.Reflection.ParameterInfo), System.Boolean, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), null, $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute))], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {
        if ($t.$isStaticInitialized)
            return;
        $t.$isStaticInitialized = true;
        System.Object.$StaticInitializer();
    };
    $p._disposable = null;
    $p._isPrimaryDisposed = false;
    $p._count = 0;
    $p.$ctor = function(disposable) {
        System.Object.prototype.$ctor.call(this);
        if (disposable == null)
            throw System.ArgumentNullException.prototype.$ctor.$new("disposable").InternalInit(new Error());
        this._disposable = disposable;
        this._isPrimaryDisposed = false;
        this._count = 0;
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function(disposable) {
        return new $p.$ctor.$type(this, disposable);
    };
    $p.get_IsDisposed = function() {
        return this._disposable == null;
    };
    $p.System$Reactive$Disposables$ICancelable$get_IsDisposed = $p.get_IsDisposed;
    $p.GetDisposable = function() {
        if (this._disposable == null) {
            return System.Reactive.Disposables.Disposable().get_Empty();
        }
        else {
            this._count++;
            return System.Reactive.Disposables.RefCountDisposable.InnerDisposable.prototype.$ctor.$new(this);
        }
    };
    $p.Dispose = function() {
        var disposable = null;
        if (this._disposable != null) {
            if (!this._isPrimaryDisposed) {
                this._isPrimaryDisposed = true;
                if (this._count == 0) {
                    disposable = this._disposable;
                    this._disposable = null;
                }
            }
        }
        if (disposable != null)
            disposable.System$IDisposable$Dispose();
    };
    $p.System$IDisposable$Dispose = $p.Dispose;
    $p.Release = function() {
        var disposable = null;
        if (this._disposable != null) {
            this._count--;
            System.Diagnostics.Debug.Assert(this._count >= 0);
            if (this._isPrimaryDisposed) {
                if (this._count == 0) {
                    disposable = this._disposable;
                    this._disposable = null;
                }
            }
        }
        if (disposable != null)
            disposable.System$IDisposable$Dispose();
    };
    $t.InnerDisposable = $define("System.Reactive.Disposables.RefCountDisposable.InnerDisposable", System.Object);
    ($t.InnerDisposable.$TypeInitializer = function($t, $p) {
        $t.$GetAssembly = window.$WootzJs$Rx$GetAssembly;
        $p.$type = $t;
        $t.$baseType = System.Object;
        $p.$typeName = "System.Reactive.Disposables.RefCountDisposable.InnerDisposable";
        $t.$typeName = $p.$typeName;
        $t.$GetType = function() {
            return System.Type._GetTypeFromTypeFunc(this);
        };
        $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("InnerDisposable", $arrayinit([], System.Attribute));this.$type.Init("System.Reactive.Disposables.RefCountDisposable.InnerDisposable", System.Reactive.Disposables.RefCountDisposable.InnerDisposable, System.Object, $arrayinit([System.IDisposable], System.Type), $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("_parent", System.Reactive.Disposables.RefCountDisposable, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("Dispose", System.Reactive.Disposables.RefCountDisposable.InnerDisposable.prototype.Dispose, $arrayinit([], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", System.Reactive.Disposables.RefCountDisposable.InnerDisposable.prototype.$ctor, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("parent", System.Reactive.Disposables.RefCountDisposable, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
        $t.$StaticInitializer = function() {
            if ($t.$isStaticInitialized)
                return;
            $t.$isStaticInitialized = true;
            System.Object.$StaticInitializer();
        };
        $p._parent = null;
        $p.$ctor = function(parent) {
            System.Object.prototype.$ctor.call(this);
            this._parent = parent;
        };
        $p.$ctor.$type = $t;
        $p.$ctor.$new = function(parent) {
            return new $p.$ctor.$type(this, parent);
        };
        $p.Dispose = function() {
            var parent = (function() {
                var $anon$1 = {
                    value: this._parent
                };
                var $result$ = System.Threading.Interlocked.Exchange(System.Reactive.Disposables.RefCountDisposable, $anon$1, null);
                this._parent = $anon$1.value;
                return $result$;
            }).call(this);
            if (parent != null)
                parent.Release();
        };
        $p.System$IDisposable$Dispose = $p.Dispose;
    }).call($t, $t.InnerDisposable, $t.InnerDisposable.prototype);
    $WootzJs$Rx$AssemblyTypes.push($t.InnerDisposable);
}).call(null, System.Reactive.Disposables.RefCountDisposable, System.Reactive.Disposables.RefCountDisposable.prototype);
$WootzJs$Rx$AssemblyTypes.push(System.Reactive.Disposables.RefCountDisposable);
System.Reactive.Disposables.SingleAssignmentDisposable = $define("System.Reactive.Disposables.SingleAssignmentDisposable", System.Object);
(System.Reactive.Disposables.SingleAssignmentDisposable.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Rx$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Object;
    $p.$typeName = "System.Reactive.Disposables.SingleAssignmentDisposable";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("SingleAssignmentDisposable", $arrayinit([], System.Attribute));this.$type.Init("System.Reactive.Disposables.SingleAssignmentDisposable", System.Reactive.Disposables.SingleAssignmentDisposable, System.Object, $arrayinit([System.Reactive.Disposables.ICancelable, System.IDisposable], System.Type), $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("_current", System.IDisposable, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("get_IsDisposed", System.Reactive.Disposables.SingleAssignmentDisposable.prototype.get_IsDisposed, $arrayinit([], System.Reflection.ParameterInfo), System.Boolean, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_Disposable", System.Reactive.Disposables.SingleAssignmentDisposable.prototype.get_Disposable, $arrayinit([], System.Reflection.ParameterInfo), System.IDisposable, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Disposable", System.Reactive.Disposables.SingleAssignmentDisposable.prototype.set_Disposable, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.IDisposable, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Dispose", System.Reactive.Disposables.SingleAssignmentDisposable.prototype.Dispose, $arrayinit([], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", System.Reactive.Disposables.SingleAssignmentDisposable.prototype.$ctor, $arrayinit([], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.PropertyInfo.prototype.$ctor.$new("IsDisposed", System.Boolean, System.Reflection.MethodInfo.prototype.$ctor.$new("get_IsDisposed", System.Reactive.Disposables.SingleAssignmentDisposable.prototype.get_IsDisposed, $arrayinit([], System.Reflection.ParameterInfo), System.Boolean, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), null, $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("Disposable", System.IDisposable, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Disposable", System.Reactive.Disposables.SingleAssignmentDisposable.prototype.get_Disposable, $arrayinit([], System.Reflection.ParameterInfo), System.IDisposable, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Disposable", System.Reactive.Disposables.SingleAssignmentDisposable.prototype.set_Disposable, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.IDisposable, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute))], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {
        if ($t.$isStaticInitialized)
            return;
        $t.$isStaticInitialized = true;
        System.Object.$StaticInitializer();
    };
    $p._current = null;
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.get_IsDisposed = function() {
        return this._current == System.Reactive.Disposables.BooleanDisposable().True;
    };
    $p.System$Reactive$Disposables$ICancelable$get_IsDisposed = $p.get_IsDisposed;
    $p.get_Disposable = function() {
        var current = this._current;
        if (current == System.Reactive.Disposables.BooleanDisposable().True)
            return System.Reactive.Disposables.DefaultDisposable().Instance;
        return current;
    };
    $p.set_Disposable = function(value) {
        var old = (function() {
            var $anon$1 = {
                value: this._current
            };
            var $result$ = System.Threading.Interlocked.CompareExchange(
                System.IDisposable, 
                $anon$1, 
                value, 
                null
            );
            this._current = $anon$1.value;
            return $result$;
        }).call(this);
        if (old == null)
            return;
        if (old != System.Reactive.Disposables.BooleanDisposable().True)
            throw System.InvalidOperationException.prototype.$ctor$1.$new("DISPOSABLE_ALREADY_ASSIGNED").InternalInit(new Error());
        if (value != null)
            value.System$IDisposable$Dispose();
    };
    $p.Dispose = function() {
        var old = (function() {
            var $anon$1 = {
                value: this._current
            };
            var $result$ = System.Threading.Interlocked.Exchange(System.IDisposable, $anon$1, System.Reactive.Disposables.BooleanDisposable().True);
            this._current = $anon$1.value;
            return $result$;
        }).call(this);
        if (old != null)
            old.System$IDisposable$Dispose();
    };
    $p.System$IDisposable$Dispose = $p.Dispose;
}).call(null, System.Reactive.Disposables.SingleAssignmentDisposable, System.Reactive.Disposables.SingleAssignmentDisposable.prototype);
$WootzJs$Rx$AssemblyTypes.push(System.Reactive.Disposables.SingleAssignmentDisposable);
System.Reactive.ExceptionHelpers = $define("System.Reactive.ExceptionHelpers", System.Object);
(System.Reactive.ExceptionHelpers.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Rx$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Object;
    $p.$typeName = "System.Reactive.ExceptionHelpers";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("ExceptionHelpers", $arrayinit([], System.Attribute));this.$type.Init("System.Reactive.ExceptionHelpers", System.Reactive.ExceptionHelpers, System.Object, $arrayinit([], System.Type), $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("s_services", System.Lazy$1, System.Reflection.FieldAttributes().Private | System.Reflection.FieldAttributes().Static, null, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("$cctor", System.Reactive.ExceptionHelpers.prototype.$cctor, $arrayinit([], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Private | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Throw", System.Reactive.ExceptionHelpers.prototype.Throw, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("exception", System.Exception, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("ThrowIfNotNull", System.Reactive.ExceptionHelpers.prototype.ThrowIfNotNull, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("exception", System.Exception, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Initialize", System.Reactive.ExceptionHelpers.prototype.Initialize, $arrayinit([], System.Reflection.ParameterInfo), System.Reactive.PlatformServices.IExceptionServices, System.Reflection.MethodAttributes().Private | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {
        if ($t.$isStaticInitialized)
            return;
        $t.$isStaticInitialized = true;
        System.Object.$StaticInitializer();
        System.Reactive.ExceptionHelpers.s_services = System.Lazy$1$(System.Reactive.PlatformServices.IExceptionServices).prototype.$ctor$1.$new($delegate(
            this, 
            System.Func$1$(System.Reactive.PlatformServices.IExceptionServices), 
            System.Reactive.ExceptionHelpers.Initialize, 
            "Initialize$delegate"
        ));
    };
    $p.s_services = null;
    $t.Throw = function(exception) {
        System.Reactive.ExceptionHelpers().s_services.get_Value().System$Reactive$PlatformServices$IExceptionServices$Rethrow(exception);
    };
    $t.ThrowIfNotNull = function(exception) {
        if (exception != null)
            System.Reactive.ExceptionHelpers().s_services.get_Value().System$Reactive$PlatformServices$IExceptionServices$Rethrow(exception);
    };
    $t.Initialize = function() {
        return System.Reactive.PlatformServices.PlatformEnlightenmentProvider().get_Current().System$Reactive$PlatformServices$IPlatformEnlightenmentProvider$GetService(System.Reactive.PlatformServices.IExceptionServices, []) || System.Reactive.PlatformServices.DefaultExceptionServices.prototype.$ctor.$new();
    };
}).call(null, System.Reactive.ExceptionHelpers, System.Reactive.ExceptionHelpers.prototype);
$WootzJs$Rx$AssemblyTypes.push(System.Reactive.ExceptionHelpers);
System.Reactive.ImmutableList$1 = $define("System.Reactive.ImmutableList<T>", System.Object);
(System.Reactive.ImmutableList$1.$TypeInitializer = function($t, $p, T) {
    $t.$GetAssembly = window.$WootzJs$Rx$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Object;
    $p.$typeName = "System.Reactive.ImmutableList`1";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("ImmutableList", $arrayinit([], System.Attribute));this.$type.Init("System.Reactive.ImmutableList`1", System.Reactive.ImmutableList$1, System.Object, $arrayinit([], System.Type), $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("data", $array(T), System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("Add", System.Reactive.ImmutableList$1.prototype.Add, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", T, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reactive.ImmutableList$1, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Remove", System.Reactive.ImmutableList$1.prototype.Remove, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", T, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reactive.ImmutableList$1, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("IndexOf", System.Reactive.ImmutableList$1.prototype.IndexOf, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", T, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Int32, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_Data", System.Reactive.ImmutableList$1.prototype.get_Data, $arrayinit([], System.Reflection.ParameterInfo), $array(T), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", System.Reactive.ImmutableList$1.prototype.$ctor, $arrayinit([], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor$1", System.Reactive.ImmutableList$1.prototype.$ctor$1, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("data", $array(T), 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.PropertyInfo.prototype.$ctor.$new("Data", $array(T), System.Reflection.MethodInfo.prototype.$ctor.$new("get_Data", System.Reactive.ImmutableList$1.prototype.get_Data, $arrayinit([], System.Reflection.ParameterInfo), $array(T), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), null, $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute))], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {
        if ($t.$isStaticInitialized)
            return;
        $t.$isStaticInitialized = true;
        System.Object.$StaticInitializer();
    };
    $t.$ = function() {
        return $generic.call(null, System.Reactive.ImmutableList$1, arguments)();
    };
    window.System.Reactive.ImmutableList$1$ = $t.$;
    $p.data = null;
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
        this.data = $arrayinit(new Array(0), T);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.$ctor$1 = function(data) {
        System.Object.prototype.$ctor.call(this);
        this.data = data;
    };
    $p.$ctor$1.$type = $t;
    $p.$ctor$1.$new = function(data) {
        return new $p.$ctor$1.$type(this, data);
    };
    $p.Add = function(value) {
        var newData = $arrayinit(new Array(this.data.length + 1), T);
        Array.Copy(this.data, newData, this.data.length);
        newData[this.data.length] = value;
        return System.Reactive.ImmutableList$1$(T).prototype.$ctor$1.$new(newData);
    };
    $p.Remove = function(value) {
        var i = this.IndexOf(value);
        if (i < 0)
            return this;
        var newData = $arrayinit(new Array(this.data.length - 1), T);
        Array.Copy$2(
            this.data, 
            0, 
            newData, 
            0, 
            i
        );
        Array.Copy$2(
            this.data, 
            i + 1, 
            newData, 
            i, 
            this.data.length - i - 1
        );
        return System.Reactive.ImmutableList$1$(T).prototype.$ctor$1.$new(newData);
    };
    $p.IndexOf = function(value) {
        for (var i = 0; i < this.data.length; ++i) {
            if (this.data[i].Equals(value))
                return i;
        }
        return -1;
    };
    $p.get_Data = function() {
        return this.data;
    };
}).call(null, System.Reactive.ImmutableList$1, System.Reactive.ImmutableList$1.prototype);
$WootzJs$Rx$AssemblyTypes.push(System.Reactive.ImmutableList$1);
System.Reactive.ISubject$1 = $define("System.Reactive.ISubject<T>", System.Object);
(System.Reactive.ISubject$1.$TypeInitializer = function($t, $p, T) {
    $t.$GetAssembly = window.$WootzJs$Rx$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Object;
    $p.$typeName = "System.Reactive.ISubject`1";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("ISubject", $arrayinit([], System.Attribute));this.$type.Init("System.Reactive.ISubject`1", System.Reactive.ISubject$1, null, $arrayinit([System.Reactive.ISubject$2, System.IObservable$1, System.IObserver$1], System.Type), $arrayinit([], System.Reflection.FieldInfo), $arrayinit([], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {
        if ($t.$isStaticInitialized)
            return;
        $t.$isStaticInitialized = true;
    };
    $t.$ = function() {
        return $generic.call(null, System.Reactive.ISubject$1, arguments)();
    };
    window.System.Reactive.ISubject$1$ = $t.$;
}).call(null, System.Reactive.ISubject$1, System.Reactive.ISubject$1.prototype);
$WootzJs$Rx$AssemblyTypes.push(System.Reactive.ISubject$1);
System.Reactive.ISubject$2 = $define("System.Reactive.ISubject<TSource, TResult>", System.Object);
(System.Reactive.ISubject$2.$TypeInitializer = function($t, $p, TSource, TResult) {
    $t.$GetAssembly = window.$WootzJs$Rx$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Object;
    $p.$typeName = "System.Reactive.ISubject`2";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("ISubject", $arrayinit([], System.Attribute));this.$type.Init("System.Reactive.ISubject`2", System.Reactive.ISubject$2, null, $arrayinit([System.IObservable$1, System.IObserver$1], System.Type), $arrayinit([], System.Reflection.FieldInfo), $arrayinit([], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {
        if ($t.$isStaticInitialized)
            return;
        $t.$isStaticInitialized = true;
    };
    $t.$ = function() {
        return $generic.call(null, System.Reactive.ISubject$2, arguments)();
    };
    window.System.Reactive.ISubject$2$ = $t.$;
}).call(null, System.Reactive.ISubject$2, System.Reactive.ISubject$2.prototype);
$WootzJs$Rx$AssemblyTypes.push(System.Reactive.ISubject$2);
System.Reactive.Linq.GroupedObservable$2 = $define("System.Reactive.Linq.GroupedObservable<TKey, TElement>", System.Reactive.ObservableBase$1);
(System.Reactive.Linq.GroupedObservable$2.$TypeInitializer = function($t, $p, TKey, TElement) {
    $t.$GetAssembly = window.$WootzJs$Rx$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Reactive.ObservableBase$1;
    $p.$typeName = "System.Reactive.Linq.GroupedObservable`2";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("GroupedObservable", $arrayinit([], System.Attribute));this.$type.Init("System.Reactive.Linq.GroupedObservable`2", System.Reactive.Linq.GroupedObservable$2, System.Reactive.ObservableBase$1$(TElement), $arrayinit([System.Reactive.Linq.IGroupedObservable$2, System.IObservable$1], System.Type), $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("_key", TKey, System.Reflection.FieldAttributes().Private | System.Reflection.FieldAttributes().InitOnly, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("_subject", System.IObservable$1, System.Reflection.FieldAttributes().Private | System.Reflection.FieldAttributes().InitOnly, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("_refCount", System.Reactive.Disposables.RefCountDisposable, System.Reflection.FieldAttributes().Private | System.Reflection.FieldAttributes().InitOnly, null, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("get_Key", System.Reactive.Linq.GroupedObservable$2.prototype.get_Key, $arrayinit([], System.Reflection.ParameterInfo), TKey, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("SubscribeCore", System.Reactive.Linq.GroupedObservable$2.prototype.SubscribeCore, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("observer", System.IObserver$1, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.IDisposable, System.Reflection.MethodAttributes().Family, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor$1", System.Reactive.Linq.GroupedObservable$2.prototype.$ctor$1, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("key", TKey, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("subject", System.Reactive.ISubject$1, 1, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("refCount", System.Reactive.Disposables.RefCountDisposable, 2, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", System.Reactive.Linq.GroupedObservable$2.prototype.$ctor, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("key", TKey, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("subject", System.Reactive.ISubject$1, 1, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.PropertyInfo.prototype.$ctor.$new("Key", TKey, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Key", System.Reactive.Linq.GroupedObservable$2.prototype.get_Key, $arrayinit([], System.Reflection.ParameterInfo), TKey, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), null, $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute))], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {
        if ($t.$isStaticInitialized)
            return;
        $t.$isStaticInitialized = true;
        System.Reactive.ObservableBase$1$(TElement).$StaticInitializer();
    };
    $t.$ = function() {
        return $generic.call(null, System.Reactive.Linq.GroupedObservable$2, arguments)();
    };
    window.System.Reactive.Linq.GroupedObservable$2$ = $t.$;
    $p._key = null;
    $p._subject = null;
    $p._refCount = null;
    $p.$ctor$1 = function(key, subject, refCount) {
        System.Reactive.ObservableBase$1$(TElement).prototype.$ctor.call(this);
        this._key = key;
        this._subject = subject;
        this._refCount = refCount;
    };
    $p.$ctor$1.$type = $t;
    $p.$ctor$1.$new = function(key, subject, refCount) {
        return new $p.$ctor$1.$type(
            this, 
            key, 
            subject, 
            refCount
        );
    };
    $p.$ctor = function(key, subject) {
        System.Reactive.ObservableBase$1$(TElement).prototype.$ctor.call(this);
        this._key = key;
        this._subject = subject;
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function(key, subject) {
        return new $p.$ctor.$type(this, key, subject);
    };
    $p.get_Key = function() {
        return this._key;
    };
    $p.System$Reactive$Linq$IGroupedObservable$2$get_Key = $p.get_Key;
    $p.SubscribeCore = function(observer) {
        if (this._refCount != null) {
            var release = this._refCount.GetDisposable();
            var subscription = this._subject.System$IObservable$1$Subscribe(observer);
            return System.Reactive.Disposables.CompositeDisposable.prototype.$ctor$2.$new([release, subscription]);
        }
        else {
            return this._subject.System$IObservable$1$Subscribe(observer);
        }
    };
}).call(null, System.Reactive.Linq.GroupedObservable$2, System.Reactive.Linq.GroupedObservable$2.prototype);
$WootzJs$Rx$AssemblyTypes.push(System.Reactive.Linq.GroupedObservable$2);
System.Reactive.Linq.IGroupedObservable$2 = $define("System.Reactive.Linq.IGroupedObservable<TKey, TElement>", System.Object);
(System.Reactive.Linq.IGroupedObservable$2.$TypeInitializer = function($t, $p, TKey, TElement) {
    $t.$GetAssembly = window.$WootzJs$Rx$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Object;
    $p.$typeName = "System.Reactive.Linq.IGroupedObservable`2";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("IGroupedObservable", $arrayinit([], System.Attribute));this.$type.Init("System.Reactive.Linq.IGroupedObservable`2", System.Reactive.Linq.IGroupedObservable$2, null, $arrayinit([System.IObservable$1], System.Type), $arrayinit([], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("System$Reactive$Linq$IGroupedObservable$2$get_Key", System.Reactive.Linq.IGroupedObservable$2.prototype.System$Reactive$Linq$IGroupedObservable$2$get_Key, $arrayinit([], System.Reflection.ParameterInfo), TKey, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.MethodInfo), $arrayinit([System.Reflection.PropertyInfo.prototype.$ctor.$new("Key", TKey, System.Reflection.MethodInfo.prototype.$ctor.$new("System$Reactive$Linq$IGroupedObservable$2$get_Key", System.Reactive.Linq.IGroupedObservable$2.prototype.System$Reactive$Linq$IGroupedObservable$2$get_Key, $arrayinit([], System.Reflection.ParameterInfo), TKey, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), null, $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute))], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {
        if ($t.$isStaticInitialized)
            return;
        $t.$isStaticInitialized = true;
    };
    $t.$ = function() {
        return $generic.call(null, System.Reactive.Linq.IGroupedObservable$2, arguments)();
    };
    window.System.Reactive.Linq.IGroupedObservable$2$ = $t.$;
    $p.System$Reactive$Linq$IGroupedObservable$2$get_Key = function() {};
}).call(null, System.Reactive.Linq.IGroupedObservable$2, System.Reactive.Linq.IGroupedObservable$2.prototype);
$WootzJs$Rx$AssemblyTypes.push(System.Reactive.Linq.IGroupedObservable$2);
System.Reactive.Linq.Observable = $define("System.Reactive.Linq.Observable", System.Object);
(System.Reactive.Linq.Observable.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Rx$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Object;
    $p.$typeName = "System.Reactive.Linq.Observable";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("Observable", $arrayinit([], System.Attribute));this.$type.Init("System.Reactive.Linq.Observable", System.Reactive.Linq.Observable, System.Object, $arrayinit([], System.Type), $arrayinit([], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("GroupBy$2", System.Reactive.Linq.Observable.prototype.GroupBy$2, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("source", System.IObservable$1, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("keySelector", System.Func$2, 1, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("elementSelector", System.Func$2, 2, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.IObservable$1, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("GroupBy$1", System.Reactive.Linq.Observable.prototype.GroupBy$1, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("source", System.IObservable$1, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("keySelector", System.Func$2, 1, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("comparer", System.Collections.Generic.IEqualityComparer$1, 2, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.IObservable$1, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("GroupBy", System.Reactive.Linq.Observable.prototype.GroupBy, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("source", System.IObservable$1, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("keySelector", System.Func$2, 1, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.IObservable$1, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("GroupBy$3", System.Reactive.Linq.Observable.prototype.GroupBy$3, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("source", System.IObservable$1, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("keySelector", System.Func$2, 1, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("elementSelector", System.Func$2, 2, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("comparer", System.Collections.Generic.IEqualityComparer$1, 3, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.IObservable$1, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("GroupBy_", System.Reactive.Linq.Observable.prototype.GroupBy_, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("source", System.IObservable$1, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("keySelector", System.Func$2, 1, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("elementSelector", System.Func$2, 2, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("comparer", System.Collections.Generic.IEqualityComparer$1, 3, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.IObservable$1, System.Reflection.MethodAttributes().Private | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("SubscribeSafe", System.Reactive.Linq.Observable.prototype.SubscribeSafe, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("source", System.IObservable$1, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("observer", System.IObserver$1, 1, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.IDisposable, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Where", System.Reactive.Linq.Observable.prototype.Where, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("source", System.IObservable$1, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("predicate", System.Func$2, 1, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.IObservable$1, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Where$1", System.Reactive.Linq.Observable.prototype.Where$1, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("source", System.IObservable$1, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("predicate", System.Func$3, 1, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.IObservable$1, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("SelectMany$2", System.Reactive.Linq.Observable.prototype.SelectMany$2, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("source", System.IObservable$1, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("other", System.IObservable$1, 1, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.IObservable$1, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("SelectMany$1", System.Reactive.Linq.Observable.prototype.SelectMany$1, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("source", System.IObservable$1, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("selector", System.Func$2, 1, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.IObservable$1, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("SelectMany$5", System.Reactive.Linq.Observable.prototype.SelectMany$5, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("source", System.IObservable$1, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("collectionSelector", System.Func$2, 1, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("resultSelector", System.Func$3, 2, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.IObservable$1, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("SelectMany_", System.Reactive.Linq.Observable.prototype.SelectMany_, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("source", System.IObservable$1, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("selector", System.Func$2, 1, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.IObservable$1, System.Reflection.MethodAttributes().Private | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("SelectMany_$2", System.Reactive.Linq.Observable.prototype.SelectMany_$2, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("source", System.IObservable$1, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("collectionSelector", System.Func$2, 1, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("resultSelector", System.Func$3, 2, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.IObservable$1, System.Reflection.MethodAttributes().Private | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("SelectMany$3", System.Reactive.Linq.Observable.prototype.SelectMany$3, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("source", System.IObservable$1, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("onNext", System.Func$2, 1, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("onError", System.Func$2, 2, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("onCompleted", System.Func$1, 3, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.IObservable$1, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("SelectMany", System.Reactive.Linq.Observable.prototype.SelectMany, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("source", System.IObservable$1, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("selector", System.Func$2, 1, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.IObservable$1, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("SelectMany$4", System.Reactive.Linq.Observable.prototype.SelectMany$4, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("source", System.IObservable$1, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("collectionSelector", System.Func$2, 1, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("resultSelector", System.Func$3, 2, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.IObservable$1, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("SelectMany_$1", System.Reactive.Linq.Observable.prototype.SelectMany_$1, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("source", System.IObservable$1, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("collectionSelector", System.Func$2, 1, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("resultSelector", System.Func$3, 2, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.IObservable$1, System.Reflection.MethodAttributes().Private | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Subscribe", System.Reactive.Linq.Observable.prototype.Subscribe, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("source", System.IObservable$1, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.IDisposable, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Subscribe$1", System.Reactive.Linq.Observable.prototype.Subscribe$1, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("source", System.IObservable$1, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("onNext", System.Action$1, 1, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.IDisposable, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Subscribe$3", System.Reactive.Linq.Observable.prototype.Subscribe$3, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("source", System.IObservable$1, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("onNext", System.Action$1, 1, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("onError", System.Action$1, 2, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.IDisposable, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Subscribe$2", System.Reactive.Linq.Observable.prototype.Subscribe$2, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("source", System.IObservable$1, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("onNext", System.Action$1, 1, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("onCompleted", System.Action, 2, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.IDisposable, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Subscribe$4", System.Reactive.Linq.Observable.prototype.Subscribe$4, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("source", System.IObservable$1, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("onNext", System.Action$1, 1, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("onError", System.Action$1, 2, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("onCompleted", System.Action, 3, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.IDisposable, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {
        if ($t.$isStaticInitialized)
            return;
        $t.$isStaticInitialized = true;
        System.Object.$StaticInitializer();
    };
    $t.GroupBy$2 = function(TSource, TKey, TElement, source, keySelector, elementSelector) {
        return System.Reactive.Linq.Observable.GroupBy_(
            TSource, 
            TKey, 
            TElement, 
            System.Reactive.Linq.Observable, 
            source, 
            keySelector, 
            elementSelector, 
            System.Collections.Generic.EqualityComparer$1$(TKey).get_Default()
        );
    };
    $t.GroupBy$1 = function(TSource, TKey, source, keySelector, comparer) {
        return System.Reactive.Linq.Observable.GroupBy_(
            TSource, 
            TKey, 
            TSource, 
            System.Reactive.Linq.Observable, 
            source, 
            keySelector, 
            $delegate(this, System.Func$2$(TSource, TSource), function(x) {
                return x;
            }), 
            comparer
        );
    };
    $t.GroupBy = function(TSource, TKey, source, keySelector) {
        return System.Reactive.Linq.Observable.GroupBy_(
            TSource, 
            TKey, 
            TSource, 
            System.Reactive.Linq.Observable, 
            source, 
            keySelector, 
            $delegate(this, System.Func$2$(TSource, TSource), function(x) {
                return x;
            }), 
            System.Collections.Generic.EqualityComparer$1$(TKey).get_Default()
        );
    };
    $t.GroupBy$3 = function(TSource, TKey, TElement, source, keySelector, elementSelector, comparer) {
        return System.Reactive.Linq.Observable.GroupBy_(
            TSource, 
            TKey, 
            TElement, 
            System.Reactive.Linq.Observable, 
            source, 
            keySelector, 
            elementSelector, 
            comparer
        );
    };
    $t.GroupBy_ = function(TSource, TKey, TElement, source, keySelector, elementSelector, comparer) {
        return System.Reactive.Linq.Observables.GroupBy$3$(TSource, TKey, TElement).prototype.$ctor.$new(
            source, 
            keySelector, 
            elementSelector, 
            comparer
        );
    };
    $t.SubscribeSafe = function(T, source, observer) {
        if (source == null)
            throw System.ArgumentNullException.prototype.$ctor.$new("source").InternalInit(new Error());
        if (observer == null)
            throw System.ArgumentNullException.prototype.$ctor.$new("observer").InternalInit(new Error());
        if (System.Reactive.ObservableBase$1$(T).$GetType().IsInstanceOfType(source))
            return source.System$IObservable$1$Subscribe(observer);
        var producer = (function() {
            var $as$ = source;
            if (!System.Type.prototype.IsInstanceOfType.call(System.Reactive.Producer$1$(T).$GetType(), $as$))
                $as$ = null;
            return $as$;
        }).call(this);
        if (producer != null)
            return producer.SubscribeRaw(observer, false);
        var d = System.Reactive.Disposables.Disposable().get_Empty();
        try {
            d = source.System$IObservable$1$Subscribe(observer);
        }
        catch (exception) {
            observer.System$IObserver$1$OnError(exception);
        }
        return d;
    };
    $t.Where = function(TSource, source, predicate) {
        var where = (function() {
            var $as$ = source;
            if (!System.Type.prototype.IsInstanceOfType.call(System.Reactive.Linq.Observables.Where$1$(TSource).$GetType(), $as$))
                $as$ = null;
            return $as$;
        }).call(this);
        if (where != null)
            return where.Ω(predicate);
        return System.Reactive.Linq.Observables.Where$1$(TSource).prototype.$ctor.$new(source, predicate);
    };
    $t.Where$1 = function(TSource, source, predicate) {
        return System.Reactive.Linq.Observables.Where$1$(TSource).prototype.$ctor$1.$new(source, predicate);
    };
    $t.SelectMany$2 = function(TSource, TOther, source, other) {
        return System.Reactive.Linq.Observable.SelectMany_(
            TSource, 
            TOther, 
            System.Reactive.Linq.Observable, 
            source, 
            $delegate(this, System.Func$2$(TSource, System.IObservable$1$(TOther)), function(_) {
                return other;
            })
        );
    };
    $t.SelectMany$1 = function(TSource, TResult, source, selector) {
        return System.Reactive.Linq.Observable.SelectMany_(
            TSource, 
            TResult, 
            System.Reactive.Linq.Observable, 
            source, 
            selector
        );
    };
    $t.SelectMany$5 = function(TSource, TCollection, TResult, source, collectionSelector, resultSelector) {
        return System.Reactive.Linq.Observable.SelectMany_$2(
            TSource, 
            TCollection, 
            TResult, 
            System.Reactive.Linq.Observable, 
            source, 
            collectionSelector, 
            resultSelector
        );
    };
    $t.SelectMany_ = function(TSource, TResult, source, selector) {
        return System.Reactive.Linq.Observables.SelectMany$2$(TSource, TResult).prototype.$ctor$1.$new(source, selector);
    };
    $t.SelectMany_$2 = function(TSource, TCollection, TResult, source, collectionSelector, resultSelector) {
        return System.Reactive.Linq.Observables.SelectMany$3$(TSource, TCollection, TResult).prototype.$ctor$1.$new(source, collectionSelector, resultSelector);
    };
    $t.SelectMany$3 = function(TSource, TResult, source, onNext, onError, onCompleted) {
        return System.Reactive.Linq.Observables.SelectMany$2$(TSource, TResult).prototype.$ctor$2.$new(
            source, 
            onNext, 
            onError, 
            onCompleted
        );
    };
    $t.SelectMany = function(TSource, TResult, source, selector) {
        return System.Reactive.Linq.Observables.SelectMany$2$(TSource, TResult).prototype.$ctor.$new(source, selector);
    };
    $t.SelectMany$4 = function(TSource, TCollection, TResult, source, collectionSelector, resultSelector) {
        return System.Reactive.Linq.Observable.SelectMany_$1(
            TSource, 
            TCollection, 
            TResult, 
            System.Reactive.Linq.Observable, 
            source, 
            collectionSelector, 
            resultSelector
        );
    };
    $t.SelectMany_$1 = function(TSource, TCollection, TResult, source, collectionSelector, resultSelector) {
        return System.Reactive.Linq.Observables.SelectMany$3$(TSource, TCollection, TResult).prototype.$ctor.$new(source, collectionSelector, resultSelector);
    };
    $t.Subscribe = function(T, source) {
        if (source == null)
            throw System.ArgumentNullException.prototype.$ctor.$new("source").InternalInit(new Error());
        return source.System$IObservable$1$Subscribe(System.Reactive.AnonymousObserver$1$(T).prototype.$ctor$3.$new(System.Reactive.Stubs$1$(T).Ignore, System.Reactive.Stubs().Throw, System.Reactive.Stubs().Nop));
    };
    $t.Subscribe$1 = function(T, source, onNext) {
        if (source == null)
            throw System.ArgumentNullException.prototype.$ctor.$new("source").InternalInit(new Error());
        if (onNext == null)
            throw System.ArgumentNullException.prototype.$ctor.$new("onNext").InternalInit(new Error());
        return source.System$IObservable$1$Subscribe(System.Reactive.AnonymousObserver$1$(T).prototype.$ctor$3.$new(onNext, System.Reactive.Stubs().Throw, System.Reactive.Stubs().Nop));
    };
    $t.Subscribe$3 = function(T, source, onNext, onError) {
        if (source == null)
            throw System.ArgumentNullException.prototype.$ctor.$new("source").InternalInit(new Error());
        if (onNext == null)
            throw System.ArgumentNullException.prototype.$ctor.$new("onNext").InternalInit(new Error());
        if (onError == null)
            throw System.ArgumentNullException.prototype.$ctor.$new("onError").InternalInit(new Error());
        return source.System$IObservable$1$Subscribe(System.Reactive.AnonymousObserver$1$(T).prototype.$ctor$3.$new(onNext, onError, System.Reactive.Stubs().Nop));
    };
    $t.Subscribe$2 = function(T, source, onNext, onCompleted) {
        if (source == null)
            throw System.ArgumentNullException.prototype.$ctor.$new("source").InternalInit(new Error());
        if (onNext == null)
            throw System.ArgumentNullException.prototype.$ctor.$new("onNext").InternalInit(new Error());
        if (onCompleted == null)
            throw System.ArgumentNullException.prototype.$ctor.$new("onCompleted").InternalInit(new Error());
        return source.System$IObservable$1$Subscribe(System.Reactive.AnonymousObserver$1$(T).prototype.$ctor$3.$new(onNext, System.Reactive.Stubs().Throw, onCompleted));
    };
    $t.Subscribe$4 = function(T, source, onNext, onError, onCompleted) {
        if (source == null)
            throw System.ArgumentNullException.prototype.$ctor.$new("source").InternalInit(new Error());
        if (onNext == null)
            throw System.ArgumentNullException.prototype.$ctor.$new("onNext").InternalInit(new Error());
        if (onError == null)
            throw System.ArgumentNullException.prototype.$ctor.$new("onError").InternalInit(new Error());
        if (onCompleted == null)
            throw System.ArgumentNullException.prototype.$ctor.$new("onCompleted").InternalInit(new Error());
        return source.System$IObservable$1$Subscribe(System.Reactive.AnonymousObserver$1$(T).prototype.$ctor$3.$new(onNext, onError, onCompleted));
    };
}).call(null, System.Reactive.Linq.Observable, System.Reactive.Linq.Observable.prototype);
$WootzJs$Rx$AssemblyTypes.push(System.Reactive.Linq.Observable);
System.Reactive.Linq.Observables.GroupBy$3 = $define("System.Reactive.Linq.Observables.GroupBy<TSource, TKey, TElement>", System.Reactive.Producer$1);
(System.Reactive.Linq.Observables.GroupBy$3.$TypeInitializer = function($t, $p, TSource, TKey, TElement) {
    $t.$GetAssembly = window.$WootzJs$Rx$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Reactive.Producer$1;
    $p.$typeName = "System.Reactive.Linq.Observables.GroupBy`3";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("GroupBy", $arrayinit([], System.Attribute));this.$type.Init("System.Reactive.Linq.Observables.GroupBy`3", System.Reactive.Linq.Observables.GroupBy$3, System.Reactive.Producer$1$(System.Reactive.Linq.IGroupedObservable$2$(TKey, TElement)), $arrayinit([System.IObservable$1], System.Type), $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("_source", System.IObservable$1, System.Reflection.FieldAttributes().Private | System.Reflection.FieldAttributes().InitOnly, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("_keySelector", System.Func$2, System.Reflection.FieldAttributes().Private | System.Reflection.FieldAttributes().InitOnly, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("_elementSelector", System.Func$2, System.Reflection.FieldAttributes().Private | System.Reflection.FieldAttributes().InitOnly, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("_comparer", System.Collections.Generic.IEqualityComparer$1, System.Reflection.FieldAttributes().Private | System.Reflection.FieldAttributes().InitOnly, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("_groupDisposable", System.Reactive.Disposables.CompositeDisposable, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("_refCountDisposable", System.Reactive.Disposables.RefCountDisposable, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("Run", System.Reactive.Linq.Observables.GroupBy$3.prototype.Run, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("observer", System.IObserver$1, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("cancel", System.IDisposable, 1, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("setSink", System.Action$1, 2, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.IDisposable, System.Reflection.MethodAttributes().Family, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", System.Reactive.Linq.Observables.GroupBy$3.prototype.$ctor, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("source", System.IObservable$1, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("keySelector", System.Func$2, 1, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("elementSelector", System.Func$2, 2, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("comparer", System.Collections.Generic.IEqualityComparer$1, 3, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {
        if ($t.$isStaticInitialized)
            return;
        $t.$isStaticInitialized = true;
        System.Reactive.Producer$1$(System.Reactive.Linq.IGroupedObservable$2$(TKey, TElement)).$StaticInitializer();
    };
    $t.$ = function() {
        return $generic.call(null, System.Reactive.Linq.Observables.GroupBy$3, arguments)();
    };
    window.System.Reactive.Linq.Observables.GroupBy$3$ = $t.$;
    $p._source = null;
    $p._keySelector = null;
    $p._elementSelector = null;
    $p._comparer = null;
    $p.$ctor = function(source, keySelector, elementSelector, comparer) {
        System.Reactive.Producer$1$(System.Reactive.Linq.IGroupedObservable$2$(TKey, TElement)).prototype.$ctor.call(this);
        this._source = source;
        this._keySelector = keySelector;
        this._elementSelector = elementSelector;
        this._comparer = comparer;
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function(source, keySelector, elementSelector, comparer) {
        return new $p.$ctor.$type(
            this, 
            source, 
            keySelector, 
            elementSelector, 
            comparer
        );
    };
    $p._groupDisposable = null;
    $p._refCountDisposable = null;
    $p.Run = function(observer, cancel, setSink) {
        this._groupDisposable = System.Reactive.Disposables.CompositeDisposable.prototype.$ctor.$new();
        this._refCountDisposable = System.Reactive.Disposables.RefCountDisposable.prototype.$ctor.$new(this._groupDisposable);
        var sink = System.Reactive.Linq.Observables.GroupBy$3$(TSource, TKey, TElement)._$().prototype.$ctor.$new(this, observer, cancel);
        setSink(sink);
        this._groupDisposable.Add(System.Reactive.Linq.Observable.SubscribeSafe(TSource, this._source, sink));
        return this._refCountDisposable;
    };
    $t._ = $define("System.Reactive.Linq.Observables.GroupBy<TSource, TKey, TElement>._", System.Reactive.Sink$1);
    ($t._.$TypeInitializer = function($t, $p) {
        $t.$GetAssembly = window.$WootzJs$Rx$GetAssembly;
        $p.$type = $t;
        $t.$baseType = System.Reactive.Sink$1;
        $p.$typeName = "System.Reactive.Linq.Observables.GroupBy`3._";
        $t.$typeName = $p.$typeName;
        $t.$GetType = function() {
            return System.Type._GetTypeFromTypeFunc(this);
        };
        $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("_", $arrayinit([], System.Attribute));this.$type.Init("System.Reactive.Linq.Observables.GroupBy`3._", System.Reactive.Linq.Observables.GroupBy$3._, System.Reactive.Sink$1$(System.Reactive.Linq.IGroupedObservable$2$(TKey, TElement)), $arrayinit([System.IDisposable, System.IObserver$1], System.Type), $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("_parent", System.Reactive.Linq.Observables.GroupBy$3, System.Reflection.FieldAttributes().Private | System.Reflection.FieldAttributes().InitOnly, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("_map", System.Collections.Generic.Dictionary$2, System.Reflection.FieldAttributes().Private | System.Reflection.FieldAttributes().InitOnly, null, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("OnNext", System.Reactive.Linq.Observables.GroupBy$3._.prototype.OnNext, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", TSource, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("OnError", System.Reactive.Linq.Observables.GroupBy$3._.prototype.OnError, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("error", System.Exception, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("OnCompleted", System.Reactive.Linq.Observables.GroupBy$3._.prototype.OnCompleted, $arrayinit([], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Error", System.Reactive.Linq.Observables.GroupBy$3._.prototype.Error, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("exception", System.Exception, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Private, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", System.Reactive.Linq.Observables.GroupBy$3._.prototype.$ctor, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("parent", System.Reactive.Linq.Observables.GroupBy$3, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("observer", System.IObserver$1, 1, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("cancel", System.IDisposable, 2, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
        $t.$StaticInitializer = function() {
            if ($t.$isStaticInitialized)
                return;
            $t.$isStaticInitialized = true;
            System.Reactive.Sink$1$(System.Reactive.Linq.IGroupedObservable$2$(TKey, TElement)).$StaticInitializer();
        };
        $t.$ = function() {
            return $generic.call(this, this._, arguments)();
        };
        this._$ = $t.$;
        $p._parent = null;
        $p._map = null;
        $p.$ctor = function(parent, observer, cancel) {
            System.Reactive.Sink$1$(System.Reactive.Linq.IGroupedObservable$2$(TKey, TElement)).prototype.$ctor.call(this, observer, cancel);
            this._parent = parent;
            this._map = System.Collections.Generic.Dictionary$2$(TKey, System.Reactive.ISubject$1$(TElement)).prototype.$ctor$1.$new(this._parent._comparer);
        };
        $p.$ctor.$type = $t;
        $p.$ctor.$new = function(parent, observer, cancel) {
            return new $p.$ctor.$type(
                this, 
                parent, 
                observer, 
                cancel
            );
        };
        $p.OnNext = function(value) {
            var key;
            try {
                key = this._parent._keySelector(value);
            }
            catch (exception) {
                this.Error(exception);
                return;
            }
            var fireNewMapEntry = false;
            var writer;
            try {
                if (!(function() {
                    var $anon$1 = {
                        value: null
                    };
                    var $result$ = this._map.TryGetValue(key, $anon$1);
                    writer = $anon$1.value;
                    return $result$;
                }).call(this)) {
                    writer = System.Reactive.Subjects.Subject$1$(TElement).prototype.$ctor.$new();
                    this._map.Add$1(key, writer);
                    fireNewMapEntry = true;
                }
            }
            catch (exception) {
                this.Error(exception);
                return;
            }
            if (fireNewMapEntry) {
                var group = System.Reactive.Linq.GroupedObservable$2$(TKey, TElement).prototype.$ctor$1.$new(key, writer, this._parent._refCountDisposable);
                this._observer.System$IObserver$1$OnNext(group);
            }
            var element;
            try {
                element = this._parent._elementSelector(value);
            }
            catch (exception) {
                this.Error(exception);
                return;
            }
            writer.System$IObserver$1$OnNext(element);
        };
        $p.System$IObserver$1$OnNext = $p.OnNext;
        $p.OnError = function(error) {
            this.Error(error);
        };
        $p.System$IObserver$1$OnError = $p.OnError;
        $p.OnCompleted = function() {
            {
                var $anon$1iterator = this._map.get_Values();
                var $anon$2enumerator = $anon$1iterator.System$Collections$IEnumerable$GetEnumerator();
                while ($anon$2enumerator.System$Collections$IEnumerator$MoveNext()) {
                    var w = $anon$2enumerator.System$Collections$IEnumerator$get_Current();
                    w.System$IObserver$1$OnCompleted();
                }
            }
            this._observer.System$IObserver$1$OnCompleted();
            System.Reactive.Sink$1$(System.Reactive.Linq.IGroupedObservable$2$(TKey, TElement)).prototype.Dispose.call(this);
        };
        $p.System$IObserver$1$OnCompleted = $p.OnCompleted;
        $p.Error = function(exception) {
            {
                var $anon$1iterator = this._map.get_Values();
                var $anon$2enumerator = $anon$1iterator.System$Collections$IEnumerable$GetEnumerator();
                while ($anon$2enumerator.System$Collections$IEnumerator$MoveNext()) {
                    var w = $anon$2enumerator.System$Collections$IEnumerator$get_Current();
                    w.System$IObserver$1$OnError(exception);
                }
            }
            this._observer.System$IObserver$1$OnError(exception);
            System.Reactive.Sink$1$(System.Reactive.Linq.IGroupedObservable$2$(TKey, TElement)).prototype.Dispose.call(this);
        };
    }).call($t, $t._, $t._.prototype);
    $WootzJs$Rx$AssemblyTypes.push($t._);
}).call(null, System.Reactive.Linq.Observables.GroupBy$3, System.Reactive.Linq.Observables.GroupBy$3.prototype);
$WootzJs$Rx$AssemblyTypes.push(System.Reactive.Linq.Observables.GroupBy$3);
System.Reactive.Linq.Observables.SelectMany$3 = $define("System.Reactive.Linq.Observables.SelectMany<TSource, TCollection, TResult>", System.Reactive.Producer$1);
(System.Reactive.Linq.Observables.SelectMany$3.$TypeInitializer = function($t, $p, TSource, TCollection, TResult) {
    $t.$GetAssembly = window.$WootzJs$Rx$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Reactive.Producer$1;
    $p.$typeName = "System.Reactive.Linq.Observables.SelectMany`3";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("SelectMany", $arrayinit([], System.Attribute));this.$type.Init("System.Reactive.Linq.Observables.SelectMany`3", System.Reactive.Linq.Observables.SelectMany$3, System.Reactive.Producer$1$(TResult), $arrayinit([System.IObservable$1], System.Type), $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("_source", System.IObservable$1, System.Reflection.FieldAttributes().Private | System.Reflection.FieldAttributes().InitOnly, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("_collectionSelector", System.Func$2, System.Reflection.FieldAttributes().Private | System.Reflection.FieldAttributes().InitOnly, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("_collectionSelectorE", System.Func$2, System.Reflection.FieldAttributes().Private | System.Reflection.FieldAttributes().InitOnly, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("_resultSelector", System.Func$3, System.Reflection.FieldAttributes().Private | System.Reflection.FieldAttributes().InitOnly, null, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("Run", System.Reactive.Linq.Observables.SelectMany$3.prototype.Run, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("observer", System.IObserver$1, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("cancel", System.IDisposable, 1, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("setSink", System.Action$1, 2, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.IDisposable, System.Reflection.MethodAttributes().Family, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor$1", System.Reactive.Linq.Observables.SelectMany$3.prototype.$ctor$1, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("source", System.IObservable$1, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("collectionSelector", System.Func$2, 1, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("resultSelector", System.Func$3, 2, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", System.Reactive.Linq.Observables.SelectMany$3.prototype.$ctor, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("source", System.IObservable$1, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("collectionSelector", System.Func$2, 1, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("resultSelector", System.Func$3, 2, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {
        if ($t.$isStaticInitialized)
            return;
        $t.$isStaticInitialized = true;
        System.Reactive.Producer$1$(TResult).$StaticInitializer();
    };
    $t.$ = function() {
        return $generic.call(null, System.Reactive.Linq.Observables.SelectMany$3, arguments)();
    };
    window.System.Reactive.Linq.Observables.SelectMany$3$ = $t.$;
    $p._source = null;
    $p._collectionSelector = null;
    $p._collectionSelectorE = null;
    $p._resultSelector = null;
    $p.$ctor$1 = function(source, collectionSelector, resultSelector) {
        System.Reactive.Producer$1$(TResult).prototype.$ctor.call(this);
        this._source = source;
        this._collectionSelector = collectionSelector;
        this._resultSelector = resultSelector;
    };
    $p.$ctor$1.$type = $t;
    $p.$ctor$1.$new = function(source, collectionSelector, resultSelector) {
        return new $p.$ctor$1.$type(
            this, 
            source, 
            collectionSelector, 
            resultSelector
        );
    };
    $p.$ctor = function(source, collectionSelector, resultSelector) {
        System.Reactive.Producer$1$(TResult).prototype.$ctor.call(this);
        this._source = source;
        this._collectionSelectorE = collectionSelector;
        this._resultSelector = resultSelector;
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function(source, collectionSelector, resultSelector) {
        return new $p.$ctor.$type(
            this, 
            source, 
            collectionSelector, 
            resultSelector
        );
    };
    $p.Run = function(observer, cancel, setSink) {
        if (this._collectionSelector != null) {
            var sink = System.Reactive.Linq.Observables.SelectMany$3$(TSource, TCollection, TResult)._$().prototype.$ctor.$new(this, observer, cancel);
            setSink(sink);
            return sink.Run();
        }
        else {
            var sink = System.Reactive.Linq.Observables.SelectMany$3$(TSource, TCollection, TResult).ε$().prototype.$ctor.$new(this, observer, cancel);
            setSink(sink);
            return System.Reactive.Linq.Observable.SubscribeSafe(TSource, this._source, sink);
        }
    };
    $t._ = $define("System.Reactive.Linq.Observables.SelectMany<TSource, TCollection, TResult>._", System.Reactive.Sink$1);
    ($t._.$TypeInitializer = function($t, $p) {
        $t.$GetAssembly = window.$WootzJs$Rx$GetAssembly;
        $p.$type = $t;
        $t.$baseType = System.Reactive.Sink$1;
        $p.$typeName = "System.Reactive.Linq.Observables.SelectMany`3._";
        $t.$typeName = $p.$typeName;
        $t.$GetType = function() {
            return System.Type._GetTypeFromTypeFunc(this);
        };
        $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("_", $arrayinit([], System.Attribute));this.$type.Init("System.Reactive.Linq.Observables.SelectMany`3._", System.Reactive.Linq.Observables.SelectMany$3._, System.Reactive.Sink$1$(TResult), $arrayinit([System.IDisposable, System.IObserver$1], System.Type), $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("_parent", System.Reactive.Linq.Observables.SelectMany$3, System.Reflection.FieldAttributes().Private | System.Reflection.FieldAttributes().InitOnly, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("_isStopped", System.Boolean, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("_group", System.Reactive.Disposables.CompositeDisposable, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("_sourceSubscription", System.Reactive.Disposables.SingleAssignmentDisposable, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("Run", System.Reactive.Linq.Observables.SelectMany$3._.prototype.Run, $arrayinit([], System.Reflection.ParameterInfo), System.IDisposable, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("OnNext", System.Reactive.Linq.Observables.SelectMany$3._.prototype.OnNext, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", TSource, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("OnError", System.Reactive.Linq.Observables.SelectMany$3._.prototype.OnError, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("error", System.Exception, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("OnCompleted", System.Reactive.Linq.Observables.SelectMany$3._.prototype.OnCompleted, $arrayinit([], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", System.Reactive.Linq.Observables.SelectMany$3._.prototype.$ctor, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("parent", System.Reactive.Linq.Observables.SelectMany$3, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("observer", System.IObserver$1, 1, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("cancel", System.IDisposable, 2, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
        $t.$StaticInitializer = function() {
            if ($t.$isStaticInitialized)
                return;
            $t.$isStaticInitialized = true;
            System.Reactive.Sink$1$(TResult).$StaticInitializer();
        };
        $t.$ = function() {
            return $generic.call(this, this._, arguments)();
        };
        this._$ = $t.$;
        $p._parent = null;
        $p.$ctor = function(parent, observer, cancel) {
            System.Reactive.Sink$1$(TResult).prototype.$ctor.call(this, observer, cancel);
            this._parent = parent;
        };
        $p.$ctor.$type = $t;
        $p.$ctor.$new = function(parent, observer, cancel) {
            return new $p.$ctor.$type(
                this, 
                parent, 
                observer, 
                cancel
            );
        };
        $p._isStopped = false;
        $p._group = null;
        $p._sourceSubscription = null;
        $p.Run = function() {
            this._isStopped = false;
            this._group = System.Reactive.Disposables.CompositeDisposable.prototype.$ctor.$new();
            this._sourceSubscription = System.Reactive.Disposables.SingleAssignmentDisposable.prototype.$ctor.$new();
            this._group.Add(this._sourceSubscription);
            this._sourceSubscription.set_Disposable(System.Reactive.Linq.Observable.SubscribeSafe(TSource, this._parent._source, this));
            return this._group;
        };
        $p.OnNext = function(value) {
            var collection;
            try {
                collection = this._parent._collectionSelector(value);
            }
            catch (ex) {
                this._observer.System$IObserver$1$OnError(ex);
                System.Reactive.Sink$1$(TResult).prototype.Dispose.call(this);
                return;
            }
            var innerSubscription = System.Reactive.Disposables.SingleAssignmentDisposable.prototype.$ctor.$new();
            this._group.Add(innerSubscription);
            innerSubscription.set_Disposable(System.Reactive.Linq.Observable.SubscribeSafe(TCollection, collection, System.Reactive.Linq.Observables.SelectMany$3$(TSource, TCollection, TResult)._$().ι$().prototype.$ctor.$new(this, value, innerSubscription)));
        };
        $p.System$IObserver$1$OnNext = $p.OnNext;
        $p.OnError = function(error) {
            this._observer.System$IObserver$1$OnError(error);
            System.Reactive.Sink$1$(TResult).prototype.Dispose.call(this);
        };
        $p.System$IObserver$1$OnError = $p.OnError;
        $p.OnCompleted = function() {
            this._isStopped = true;
            if (this._group.get_Count() == 1) {
                this._observer.System$IObserver$1$OnCompleted();
                System.Reactive.Sink$1$(TResult).prototype.Dispose.call(this);
            }
            else {
                this._sourceSubscription.Dispose();
            }
        };
        $p.System$IObserver$1$OnCompleted = $p.OnCompleted;
        $t.ι = $define("System.Reactive.Linq.Observables.SelectMany<TSource, TCollection, TResult>._.ι", System.Object);
        ($t.ι.$TypeInitializer = function($t, $p) {
            $t.$GetAssembly = window.$WootzJs$Rx$GetAssembly;
            $p.$type = $t;
            $t.$baseType = System.Object;
            $p.$typeName = "System.Reactive.Linq.Observables.SelectMany`3._.ι";
            $t.$typeName = $p.$typeName;
            $t.$GetType = function() {
                return System.Type._GetTypeFromTypeFunc(this);
            };
            $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("ι", $arrayinit([], System.Attribute));this.$type.Init("System.Reactive.Linq.Observables.SelectMany`3._.ι", System.Reactive.Linq.Observables.SelectMany$3._.ι, System.Object, $arrayinit([System.IObserver$1], System.Type), $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("_parent", System.Reactive.Linq.Observables.SelectMany$3._, System.Reflection.FieldAttributes().Private | System.Reflection.FieldAttributes().InitOnly, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("_value", TSource, System.Reflection.FieldAttributes().Private | System.Reflection.FieldAttributes().InitOnly, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("_self", System.IDisposable, System.Reflection.FieldAttributes().Private | System.Reflection.FieldAttributes().InitOnly, null, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("OnNext", System.Reactive.Linq.Observables.SelectMany$3._.ι.prototype.OnNext, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", TCollection, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("OnError", System.Reactive.Linq.Observables.SelectMany$3._.ι.prototype.OnError, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("error", System.Exception, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("OnCompleted", System.Reactive.Linq.Observables.SelectMany$3._.ι.prototype.OnCompleted, $arrayinit([], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", System.Reactive.Linq.Observables.SelectMany$3._.ι.prototype.$ctor, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("parent", System.Reactive.Linq.Observables.SelectMany$3._, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("value", TSource, 1, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("self", System.IDisposable, 2, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
            $t.$StaticInitializer = function() {
                if ($t.$isStaticInitialized)
                    return;
                $t.$isStaticInitialized = true;
                System.Object.$StaticInitializer();
            };
            $t.$ = function() {
                return $generic.call(this, this.ι, arguments)();
            };
            this.ι$ = $t.$;
            $p._parent = null;
            $p._value = null;
            $p._self = null;
            $p.$ctor = function(parent, value, self) {
                System.Object.prototype.$ctor.call(this);
                this._parent = parent;
                this._value = value;
                this._self = self;
            };
            $p.$ctor.$type = $t;
            $p.$ctor.$new = function(parent, value, self) {
                return new $p.$ctor.$type(
                    this, 
                    parent, 
                    value, 
                    self
                );
            };
            $p.OnNext = function(value) {
                var res;
                try {
                    res = this._parent._parent._resultSelector(this._value, value);
                }
                catch (ex) {
                    this._parent._observer.System$IObserver$1$OnError(ex);
                    this._parent.Dispose();
                    return;
                }
                this._parent._observer.System$IObserver$1$OnNext(res);
            };
            $p.System$IObserver$1$OnNext = $p.OnNext;
            $p.OnError = function(error) {
                this._parent._observer.System$IObserver$1$OnError(error);
                this._parent.Dispose();
            };
            $p.System$IObserver$1$OnError = $p.OnError;
            $p.OnCompleted = function() {
                this._parent._group.Remove(this._self);
                if (this._parent._isStopped && this._parent._group.get_Count() == 1) {
                    this._parent._observer.System$IObserver$1$OnCompleted();
                    this._parent.Dispose();
                }
            };
            $p.System$IObserver$1$OnCompleted = $p.OnCompleted;
        }).call($t, $t.ι, $t.ι.prototype);
        $WootzJs$Rx$AssemblyTypes.push($t.ι);
    }).call($t, $t._, $t._.prototype);
    $WootzJs$Rx$AssemblyTypes.push($t._);
    $t.ε = $define("System.Reactive.Linq.Observables.SelectMany<TSource, TCollection, TResult>.ε", System.Reactive.Sink$1);
    ($t.ε.$TypeInitializer = function($t, $p) {
        $t.$GetAssembly = window.$WootzJs$Rx$GetAssembly;
        $p.$type = $t;
        $t.$baseType = System.Reactive.Sink$1;
        $p.$typeName = "System.Reactive.Linq.Observables.SelectMany`3.ε";
        $t.$typeName = $p.$typeName;
        $t.$GetType = function() {
            return System.Type._GetTypeFromTypeFunc(this);
        };
        $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("ε", $arrayinit([], System.Attribute));this.$type.Init("System.Reactive.Linq.Observables.SelectMany`3.ε", System.Reactive.Linq.Observables.SelectMany$3.ε, System.Reactive.Sink$1$(TResult), $arrayinit([System.IDisposable, System.IObserver$1], System.Type), $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("_parent", System.Reactive.Linq.Observables.SelectMany$3, System.Reflection.FieldAttributes().Private | System.Reflection.FieldAttributes().InitOnly, null, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("OnNext", System.Reactive.Linq.Observables.SelectMany$3.ε.prototype.OnNext, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", TSource, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("OnError", System.Reactive.Linq.Observables.SelectMany$3.ε.prototype.OnError, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("error", System.Exception, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("OnCompleted", System.Reactive.Linq.Observables.SelectMany$3.ε.prototype.OnCompleted, $arrayinit([], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", System.Reactive.Linq.Observables.SelectMany$3.ε.prototype.$ctor, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("parent", System.Reactive.Linq.Observables.SelectMany$3, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("observer", System.IObserver$1, 1, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("cancel", System.IDisposable, 2, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
        $t.$StaticInitializer = function() {
            if ($t.$isStaticInitialized)
                return;
            $t.$isStaticInitialized = true;
            System.Reactive.Sink$1$(TResult).$StaticInitializer();
        };
        $t.$ = function() {
            return $generic.call(this, this.ε, arguments)();
        };
        this.ε$ = $t.$;
        $p._parent = null;
        $p.$ctor = function(parent, observer, cancel) {
            System.Reactive.Sink$1$(TResult).prototype.$ctor.call(this, observer, cancel);
            this._parent = parent;
        };
        $p.$ctor.$type = $t;
        $p.$ctor.$new = function(parent, observer, cancel) {
            return new $p.$ctor.$type(
                this, 
                parent, 
                observer, 
                cancel
            );
        };
        $p.OnNext = function(value) {
            var xs;
            try {
                xs = this._parent._collectionSelectorE(value);
            }
            catch (exception) {
                this._observer.System$IObserver$1$OnError(exception);
                System.Reactive.Sink$1$(TResult).prototype.Dispose.call(this);
                return;
            }
            var e;
            try {
                e = xs.System$Collections$Generic$IEnumerable$1$GetEnumerator();
            }
            catch (exception) {
                this._observer.System$IObserver$1$OnError(exception);
                System.Reactive.Sink$1$(TResult).prototype.Dispose.call(this);
                return;
            }
            try {
                var hasNext = true;
                while (hasNext) {
                    var current = null;
                    try {
                        hasNext = e.System$Collections$IEnumerator$MoveNext();
                        if (hasNext)
                            current = this._parent._resultSelector(value, e.System$Collections$Generic$IEnumerator$1$get_Current());
                    }
                    catch (exception) {
                        this._observer.System$IObserver$1$OnError(exception);
                        System.Reactive.Sink$1$(TResult).prototype.Dispose.call(this);
                        return;
                    }
                    if (hasNext)
                        this._observer.System$IObserver$1$OnNext(current);
                }
            }
            finally {
                e.System$IDisposable$Dispose();
            }
        };
        $p.System$IObserver$1$OnNext = $p.OnNext;
        $p.OnError = function(error) {
            this._observer.System$IObserver$1$OnError(error);
            System.Reactive.Sink$1$(TResult).prototype.Dispose.call(this);
        };
        $p.System$IObserver$1$OnError = $p.OnError;
        $p.OnCompleted = function() {
            this._observer.System$IObserver$1$OnCompleted();
            System.Reactive.Sink$1$(TResult).prototype.Dispose.call(this);
        };
        $p.System$IObserver$1$OnCompleted = $p.OnCompleted;
    }).call($t, $t.ε, $t.ε.prototype);
    $WootzJs$Rx$AssemblyTypes.push($t.ε);
}).call(null, System.Reactive.Linq.Observables.SelectMany$3, System.Reactive.Linq.Observables.SelectMany$3.prototype);
$WootzJs$Rx$AssemblyTypes.push(System.Reactive.Linq.Observables.SelectMany$3);
System.Reactive.Linq.Observables.SelectMany$2 = $define("System.Reactive.Linq.Observables.SelectMany<TSource, TResult>", System.Reactive.Producer$1);
(System.Reactive.Linq.Observables.SelectMany$2.$TypeInitializer = function($t, $p, TSource, TResult) {
    $t.$GetAssembly = window.$WootzJs$Rx$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Reactive.Producer$1;
    $p.$typeName = "System.Reactive.Linq.Observables.SelectMany`2";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("SelectMany", $arrayinit([], System.Attribute));this.$type.Init("System.Reactive.Linq.Observables.SelectMany`2", System.Reactive.Linq.Observables.SelectMany$2, System.Reactive.Producer$1$(TResult), $arrayinit([System.IObservable$1], System.Type), $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("_source", System.IObservable$1, System.Reflection.FieldAttributes().Private | System.Reflection.FieldAttributes().InitOnly, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("_selector", System.Func$2, System.Reflection.FieldAttributes().Private | System.Reflection.FieldAttributes().InitOnly, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("_selectorOnError", System.Func$2, System.Reflection.FieldAttributes().Private | System.Reflection.FieldAttributes().InitOnly, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("_selectorOnCompleted", System.Func$1, System.Reflection.FieldAttributes().Private | System.Reflection.FieldAttributes().InitOnly, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("_selectorE", System.Func$2, System.Reflection.FieldAttributes().Private | System.Reflection.FieldAttributes().InitOnly, null, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("Run", System.Reactive.Linq.Observables.SelectMany$2.prototype.Run, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("observer", System.IObserver$1, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("cancel", System.IDisposable, 1, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("setSink", System.Action$1, 2, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.IDisposable, System.Reflection.MethodAttributes().Family, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor$1", System.Reactive.Linq.Observables.SelectMany$2.prototype.$ctor$1, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("source", System.IObservable$1, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("selector", System.Func$2, 1, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor$2", System.Reactive.Linq.Observables.SelectMany$2.prototype.$ctor$2, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("source", System.IObservable$1, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("selector", System.Func$2, 1, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("selectorOnError", System.Func$2, 2, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("selectorOnCompleted", System.Func$1, 3, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", System.Reactive.Linq.Observables.SelectMany$2.prototype.$ctor, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("source", System.IObservable$1, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("selector", System.Func$2, 1, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {
        if ($t.$isStaticInitialized)
            return;
        $t.$isStaticInitialized = true;
        System.Reactive.Producer$1$(TResult).$StaticInitializer();
    };
    $t.$ = function() {
        return $generic.call(null, System.Reactive.Linq.Observables.SelectMany$2, arguments)();
    };
    window.System.Reactive.Linq.Observables.SelectMany$2$ = $t.$;
    $p._source = null;
    $p._selector = null;
    $p._selectorOnError = null;
    $p._selectorOnCompleted = null;
    $p._selectorE = null;
    $p.$ctor$1 = function(source, selector) {
        System.Reactive.Producer$1$(TResult).prototype.$ctor.call(this);
        this._source = source;
        this._selector = selector;
    };
    $p.$ctor$1.$type = $t;
    $p.$ctor$1.$new = function(source, selector) {
        return new $p.$ctor$1.$type(this, source, selector);
    };
    $p.$ctor$2 = function(source, selector, selectorOnError, selectorOnCompleted) {
        System.Reactive.Producer$1$(TResult).prototype.$ctor.call(this);
        this._source = source;
        this._selector = selector;
        this._selectorOnError = selectorOnError;
        this._selectorOnCompleted = selectorOnCompleted;
    };
    $p.$ctor$2.$type = $t;
    $p.$ctor$2.$new = function(source, selector, selectorOnError, selectorOnCompleted) {
        return new $p.$ctor$2.$type(
            this, 
            source, 
            selector, 
            selectorOnError, 
            selectorOnCompleted
        );
    };
    $p.$ctor = function(source, selector) {
        System.Reactive.Producer$1$(TResult).prototype.$ctor.call(this);
        this._source = source;
        this._selectorE = selector;
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function(source, selector) {
        return new $p.$ctor.$type(this, source, selector);
    };
    $p.Run = function(observer, cancel, setSink) {
        if (this._selector != null) {
            var sink = System.Reactive.Linq.Observables.SelectMany$2$(TSource, TResult)._$().prototype.$ctor.$new(this, observer, cancel);
            setSink(sink);
            return sink.Run();
        }
        else {
            var sink = System.Reactive.Linq.Observables.SelectMany$2$(TSource, TResult).ε$().prototype.$ctor.$new(this, observer, cancel);
            setSink(sink);
            return System.Reactive.Linq.Observable.SubscribeSafe(TSource, this._source, sink);
        }
    };
    $t._ = $define("System.Reactive.Linq.Observables.SelectMany<TSource, TResult>._", System.Reactive.Sink$1);
    ($t._.$TypeInitializer = function($t, $p) {
        $t.$GetAssembly = window.$WootzJs$Rx$GetAssembly;
        $p.$type = $t;
        $t.$baseType = System.Reactive.Sink$1;
        $p.$typeName = "System.Reactive.Linq.Observables.SelectMany`2._";
        $t.$typeName = $p.$typeName;
        $t.$GetType = function() {
            return System.Type._GetTypeFromTypeFunc(this);
        };
        $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("_", $arrayinit([], System.Attribute));this.$type.Init("System.Reactive.Linq.Observables.SelectMany`2._", System.Reactive.Linq.Observables.SelectMany$2._, System.Reactive.Sink$1$(TResult), $arrayinit([System.IDisposable, System.IObserver$1], System.Type), $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("_parent", System.Reactive.Linq.Observables.SelectMany$2, System.Reflection.FieldAttributes().Private | System.Reflection.FieldAttributes().InitOnly, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("_isStopped", System.Boolean, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("_group", System.Reactive.Disposables.CompositeDisposable, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("_sourceSubscription", System.Reactive.Disposables.SingleAssignmentDisposable, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("Run", System.Reactive.Linq.Observables.SelectMany$2._.prototype.Run, $arrayinit([], System.Reflection.ParameterInfo), System.IDisposable, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("OnNext", System.Reactive.Linq.Observables.SelectMany$2._.prototype.OnNext, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", TSource, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("OnError", System.Reactive.Linq.Observables.SelectMany$2._.prototype.OnError, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("error", System.Exception, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("OnCompleted", System.Reactive.Linq.Observables.SelectMany$2._.prototype.OnCompleted, $arrayinit([], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Final", System.Reactive.Linq.Observables.SelectMany$2._.prototype.Final, $arrayinit([], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Private, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("SubscribeInner", System.Reactive.Linq.Observables.SelectMany$2._.prototype.SubscribeInner, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("inner", System.IObservable$1, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Private, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", System.Reactive.Linq.Observables.SelectMany$2._.prototype.$ctor, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("parent", System.Reactive.Linq.Observables.SelectMany$2, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("observer", System.IObserver$1, 1, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("cancel", System.IDisposable, 2, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
        $t.$StaticInitializer = function() {
            if ($t.$isStaticInitialized)
                return;
            $t.$isStaticInitialized = true;
            System.Reactive.Sink$1$(TResult).$StaticInitializer();
        };
        $t.$ = function() {
            return $generic.call(this, this._, arguments)();
        };
        this._$ = $t.$;
        $p._parent = null;
        $p.$ctor = function(parent, observer, cancel) {
            System.Reactive.Sink$1$(TResult).prototype.$ctor.call(this, observer, cancel);
            this._parent = parent;
        };
        $p.$ctor.$type = $t;
        $p.$ctor.$new = function(parent, observer, cancel) {
            return new $p.$ctor.$type(
                this, 
                parent, 
                observer, 
                cancel
            );
        };
        $p._isStopped = false;
        $p._group = null;
        $p._sourceSubscription = null;
        $p.Run = function() {
            this._isStopped = false;
            this._group = System.Reactive.Disposables.CompositeDisposable.prototype.$ctor.$new();
            this._sourceSubscription = System.Reactive.Disposables.SingleAssignmentDisposable.prototype.$ctor.$new();
            this._group.Add(this._sourceSubscription);
            this._sourceSubscription.set_Disposable(System.Reactive.Linq.Observable.SubscribeSafe(TSource, this._parent._source, this));
            return this._group;
        };
        $p.OnNext = function(value) {
            var inner;
            try {
                inner = this._parent._selector(value);
            }
            catch (ex) {
                this._observer.System$IObserver$1$OnError(ex);
                System.Reactive.Sink$1$(TResult).prototype.Dispose.call(this);
                return;
            }
            this.SubscribeInner(inner);
        };
        $p.System$IObserver$1$OnNext = $p.OnNext;
        $p.OnError = function(error) {
            if (this._parent._selectorOnError != null) {
                var inner;
                try {
                    inner = this._parent._selectorOnError(error);
                }
                catch (ex) {
                    this._observer.System$IObserver$1$OnError(ex);
                    System.Reactive.Sink$1$(TResult).prototype.Dispose.call(this);
                    return;
                }
                this.SubscribeInner(inner);
                this.Final();
            }
            else {
                this._observer.System$IObserver$1$OnError(error);
                System.Reactive.Sink$1$(TResult).prototype.Dispose.call(this);
            }
        };
        $p.System$IObserver$1$OnError = $p.OnError;
        $p.OnCompleted = function() {
            if (this._parent._selectorOnCompleted != null) {
                var inner;
                try {
                    inner = this._parent._selectorOnCompleted();
                }
                catch (ex) {
                    this._observer.System$IObserver$1$OnError(ex);
                    System.Reactive.Sink$1$(TResult).prototype.Dispose.call(this);
                    return;
                }
                this.SubscribeInner(inner);
            }
            this.Final();
        };
        $p.System$IObserver$1$OnCompleted = $p.OnCompleted;
        $p.Final = function() {
            this._isStopped = true;
            if (this._group.get_Count() == 1) {
                this._observer.System$IObserver$1$OnCompleted();
                System.Reactive.Sink$1$(TResult).prototype.Dispose.call(this);
            }
            else {
                this._sourceSubscription.Dispose();
            }
        };
        $p.SubscribeInner = function(inner) {
            var innerSubscription = System.Reactive.Disposables.SingleAssignmentDisposable.prototype.$ctor.$new();
            this._group.Add(innerSubscription);
            innerSubscription.set_Disposable(System.Reactive.Linq.Observable.SubscribeSafe(TResult, inner, System.Reactive.Linq.Observables.SelectMany$2$(TSource, TResult)._$().ι$().prototype.$ctor.$new(this, innerSubscription)));
        };
        $t.ι = $define("System.Reactive.Linq.Observables.SelectMany<TSource, TResult>._.ι", System.Object);
        ($t.ι.$TypeInitializer = function($t, $p) {
            $t.$GetAssembly = window.$WootzJs$Rx$GetAssembly;
            $p.$type = $t;
            $t.$baseType = System.Object;
            $p.$typeName = "System.Reactive.Linq.Observables.SelectMany`2._.ι";
            $t.$typeName = $p.$typeName;
            $t.$GetType = function() {
                return System.Type._GetTypeFromTypeFunc(this);
            };
            $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("ι", $arrayinit([], System.Attribute));this.$type.Init("System.Reactive.Linq.Observables.SelectMany`2._.ι", System.Reactive.Linq.Observables.SelectMany$2._.ι, System.Object, $arrayinit([System.IObserver$1], System.Type), $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("_parent", System.Reactive.Linq.Observables.SelectMany$2._, System.Reflection.FieldAttributes().Private | System.Reflection.FieldAttributes().InitOnly, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("_self", System.IDisposable, System.Reflection.FieldAttributes().Private | System.Reflection.FieldAttributes().InitOnly, null, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("OnNext", System.Reactive.Linq.Observables.SelectMany$2._.ι.prototype.OnNext, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", TResult, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("OnError", System.Reactive.Linq.Observables.SelectMany$2._.ι.prototype.OnError, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("error", System.Exception, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("OnCompleted", System.Reactive.Linq.Observables.SelectMany$2._.ι.prototype.OnCompleted, $arrayinit([], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", System.Reactive.Linq.Observables.SelectMany$2._.ι.prototype.$ctor, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("parent", System.Reactive.Linq.Observables.SelectMany$2._, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("self", System.IDisposable, 1, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
            $t.$StaticInitializer = function() {
                if ($t.$isStaticInitialized)
                    return;
                $t.$isStaticInitialized = true;
                System.Object.$StaticInitializer();
            };
            $t.$ = function() {
                return $generic.call(this, this.ι, arguments)();
            };
            this.ι$ = $t.$;
            $p._parent = null;
            $p._self = null;
            $p.$ctor = function(parent, self) {
                System.Object.prototype.$ctor.call(this);
                this._parent = parent;
                this._self = self;
            };
            $p.$ctor.$type = $t;
            $p.$ctor.$new = function(parent, self) {
                return new $p.$ctor.$type(this, parent, self);
            };
            $p.OnNext = function(value) {
                this._parent._observer.System$IObserver$1$OnNext(value);
            };
            $p.System$IObserver$1$OnNext = $p.OnNext;
            $p.OnError = function(error) {
                this._parent._observer.System$IObserver$1$OnError(error);
                this._parent.Dispose();
            };
            $p.System$IObserver$1$OnError = $p.OnError;
            $p.OnCompleted = function() {
                this._parent._group.Remove(this._self);
                if (this._parent._isStopped && this._parent._group.get_Count() == 1) {
                    this._parent._observer.System$IObserver$1$OnCompleted();
                    this._parent.Dispose();
                }
            };
            $p.System$IObserver$1$OnCompleted = $p.OnCompleted;
        }).call($t, $t.ι, $t.ι.prototype);
        $WootzJs$Rx$AssemblyTypes.push($t.ι);
    }).call($t, $t._, $t._.prototype);
    $WootzJs$Rx$AssemblyTypes.push($t._);
    $t.ε = $define("System.Reactive.Linq.Observables.SelectMany<TSource, TResult>.ε", System.Reactive.Sink$1);
    ($t.ε.$TypeInitializer = function($t, $p) {
        $t.$GetAssembly = window.$WootzJs$Rx$GetAssembly;
        $p.$type = $t;
        $t.$baseType = System.Reactive.Sink$1;
        $p.$typeName = "System.Reactive.Linq.Observables.SelectMany`2.ε";
        $t.$typeName = $p.$typeName;
        $t.$GetType = function() {
            return System.Type._GetTypeFromTypeFunc(this);
        };
        $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("ε", $arrayinit([], System.Attribute));this.$type.Init("System.Reactive.Linq.Observables.SelectMany`2.ε", System.Reactive.Linq.Observables.SelectMany$2.ε, System.Reactive.Sink$1$(TResult), $arrayinit([System.IDisposable, System.IObserver$1], System.Type), $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("_parent", System.Reactive.Linq.Observables.SelectMany$2, System.Reflection.FieldAttributes().Private | System.Reflection.FieldAttributes().InitOnly, null, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("OnNext", System.Reactive.Linq.Observables.SelectMany$2.ε.prototype.OnNext, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", TSource, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("OnError", System.Reactive.Linq.Observables.SelectMany$2.ε.prototype.OnError, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("error", System.Exception, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("OnCompleted", System.Reactive.Linq.Observables.SelectMany$2.ε.prototype.OnCompleted, $arrayinit([], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", System.Reactive.Linq.Observables.SelectMany$2.ε.prototype.$ctor, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("parent", System.Reactive.Linq.Observables.SelectMany$2, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("observer", System.IObserver$1, 1, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("cancel", System.IDisposable, 2, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
        $t.$StaticInitializer = function() {
            if ($t.$isStaticInitialized)
                return;
            $t.$isStaticInitialized = true;
            System.Reactive.Sink$1$(TResult).$StaticInitializer();
        };
        $t.$ = function() {
            return $generic.call(this, this.ε, arguments)();
        };
        this.ε$ = $t.$;
        $p._parent = null;
        $p.$ctor = function(parent, observer, cancel) {
            System.Reactive.Sink$1$(TResult).prototype.$ctor.call(this, observer, cancel);
            this._parent = parent;
        };
        $p.$ctor.$type = $t;
        $p.$ctor.$new = function(parent, observer, cancel) {
            return new $p.$ctor.$type(
                this, 
                parent, 
                observer, 
                cancel
            );
        };
        $p.OnNext = function(value) {
            var xs;
            try {
                xs = this._parent._selectorE(value);
            }
            catch (exception) {
                this._observer.System$IObserver$1$OnError(exception);
                System.Reactive.Sink$1$(TResult).prototype.Dispose.call(this);
                return;
            }
            var e;
            try {
                e = xs.System$Collections$Generic$IEnumerable$1$GetEnumerator();
            }
            catch (exception) {
                this._observer.System$IObserver$1$OnError(exception);
                System.Reactive.Sink$1$(TResult).prototype.Dispose.call(this);
                return;
            }
            try {
                var hasNext = true;
                while (hasNext) {
                    var current = null;
                    try {
                        hasNext = e.System$Collections$IEnumerator$MoveNext();
                        if (hasNext)
                            current = e.System$Collections$Generic$IEnumerator$1$get_Current();
                    }
                    catch (exception) {
                        this._observer.System$IObserver$1$OnError(exception);
                        System.Reactive.Sink$1$(TResult).prototype.Dispose.call(this);
                        return;
                    }
                    if (hasNext)
                        this._observer.System$IObserver$1$OnNext(current);
                }
            }
            finally {
                e.System$IDisposable$Dispose();
            }
        };
        $p.System$IObserver$1$OnNext = $p.OnNext;
        $p.OnError = function(error) {
            this._observer.System$IObserver$1$OnError(error);
            System.Reactive.Sink$1$(TResult).prototype.Dispose.call(this);
        };
        $p.System$IObserver$1$OnError = $p.OnError;
        $p.OnCompleted = function() {
            this._observer.System$IObserver$1$OnCompleted();
            System.Reactive.Sink$1$(TResult).prototype.Dispose.call(this);
        };
        $p.System$IObserver$1$OnCompleted = $p.OnCompleted;
    }).call($t, $t.ε, $t.ε.prototype);
    $WootzJs$Rx$AssemblyTypes.push($t.ε);
}).call(null, System.Reactive.Linq.Observables.SelectMany$2, System.Reactive.Linq.Observables.SelectMany$2.prototype);
$WootzJs$Rx$AssemblyTypes.push(System.Reactive.Linq.Observables.SelectMany$2);
System.Reactive.Linq.Observables.Where$1 = $define("System.Reactive.Linq.Observables.Where<TSource>", System.Reactive.Producer$1);
(System.Reactive.Linq.Observables.Where$1.$TypeInitializer = function($t, $p, TSource) {
    $t.$GetAssembly = window.$WootzJs$Rx$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Reactive.Producer$1;
    $p.$typeName = "System.Reactive.Linq.Observables.Where`1";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("Where", $arrayinit([], System.Attribute));this.$type.Init("System.Reactive.Linq.Observables.Where`1", System.Reactive.Linq.Observables.Where$1, System.Reactive.Producer$1$(TSource), $arrayinit([System.IObservable$1], System.Type), $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("_source", System.IObservable$1, System.Reflection.FieldAttributes().Private | System.Reflection.FieldAttributes().InitOnly, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("_predicate", System.Func$2, System.Reflection.FieldAttributes().Private | System.Reflection.FieldAttributes().InitOnly, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("_predicateI", System.Func$3, System.Reflection.FieldAttributes().Private | System.Reflection.FieldAttributes().InitOnly, null, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("Ω", System.Reactive.Linq.Observables.Where$1.prototype.Ω, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("predicate", System.Func$2, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.IObservable$1, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Run", System.Reactive.Linq.Observables.Where$1.prototype.Run, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("observer", System.IObserver$1, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("cancel", System.IDisposable, 1, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("setSink", System.Action$1, 2, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.IDisposable, System.Reflection.MethodAttributes().Family, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", System.Reactive.Linq.Observables.Where$1.prototype.$ctor, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("source", System.IObservable$1, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("predicate", System.Func$2, 1, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor$1", System.Reactive.Linq.Observables.Where$1.prototype.$ctor$1, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("source", System.IObservable$1, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("predicate", System.Func$3, 1, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {
        if ($t.$isStaticInitialized)
            return;
        $t.$isStaticInitialized = true;
        System.Reactive.Producer$1$(TSource).$StaticInitializer();
    };
    $t.$ = function() {
        return $generic.call(null, System.Reactive.Linq.Observables.Where$1, arguments)();
    };
    window.System.Reactive.Linq.Observables.Where$1$ = $t.$;
    $p._source = null;
    $p._predicate = null;
    $p._predicateI = null;
    $p.$ctor = function(source, predicate) {
        System.Reactive.Producer$1$(TSource).prototype.$ctor.call(this);
        this._source = source;
        this._predicate = predicate;
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function(source, predicate) {
        return new $p.$ctor.$type(this, source, predicate);
    };
    $p.$ctor$1 = function(source, predicate) {
        System.Reactive.Producer$1$(TSource).prototype.$ctor.call(this);
        this._source = source;
        this._predicateI = predicate;
    };
    $p.$ctor$1.$type = $t;
    $p.$ctor$1.$new = function(source, predicate) {
        return new $p.$ctor$1.$type(this, source, predicate);
    };
    $p.Ω = function(predicate) {
        if (this._predicate != null)
            return System.Reactive.Linq.Observables.Where$1$(TSource).prototype.$ctor.$new(this._source, $delegate(this, System.Func$2$(TSource, System.Boolean), function(x) {
                return this._predicate(x) && predicate(x);
            }));
        else
            return System.Reactive.Linq.Observables.Where$1$(TSource).prototype.$ctor.$new(this, predicate);
    };
    $p.Run = function(observer, cancel, setSink) {
        if (this._predicate != null) {
            var sink = System.Reactive.Linq.Observables.Where$1$(TSource)._$().prototype.$ctor.$new(this, observer, cancel);
            setSink(sink);
            return System.Reactive.Linq.Observable.SubscribeSafe(TSource, this._source, sink);
        }
        else {
            var sink = System.Reactive.Linq.Observables.Where$1$(TSource).τ$().prototype.$ctor.$new(this, observer, cancel);
            setSink(sink);
            return System.Reactive.Linq.Observable.SubscribeSafe(TSource, this._source, sink);
        }
    };
    $t._ = $define("System.Reactive.Linq.Observables.Where<TSource>._", System.Reactive.Sink$1);
    ($t._.$TypeInitializer = function($t, $p) {
        $t.$GetAssembly = window.$WootzJs$Rx$GetAssembly;
        $p.$type = $t;
        $t.$baseType = System.Reactive.Sink$1;
        $p.$typeName = "System.Reactive.Linq.Observables.Where`1._";
        $t.$typeName = $p.$typeName;
        $t.$GetType = function() {
            return System.Type._GetTypeFromTypeFunc(this);
        };
        $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("_", $arrayinit([], System.Attribute));this.$type.Init("System.Reactive.Linq.Observables.Where`1._", System.Reactive.Linq.Observables.Where$1._, System.Reactive.Sink$1$(TSource), $arrayinit([System.IDisposable, System.IObserver$1], System.Type), $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("_parent", System.Reactive.Linq.Observables.Where$1, System.Reflection.FieldAttributes().Private | System.Reflection.FieldAttributes().InitOnly, null, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("OnNext", System.Reactive.Linq.Observables.Where$1._.prototype.OnNext, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", TSource, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("OnError", System.Reactive.Linq.Observables.Where$1._.prototype.OnError, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("error", System.Exception, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("OnCompleted", System.Reactive.Linq.Observables.Where$1._.prototype.OnCompleted, $arrayinit([], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", System.Reactive.Linq.Observables.Where$1._.prototype.$ctor, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("parent", System.Reactive.Linq.Observables.Where$1, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("observer", System.IObserver$1, 1, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("cancel", System.IDisposable, 2, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
        $t.$StaticInitializer = function() {
            if ($t.$isStaticInitialized)
                return;
            $t.$isStaticInitialized = true;
            System.Reactive.Sink$1$(TSource).$StaticInitializer();
        };
        $t.$ = function() {
            return $generic.call(this, this._, arguments)();
        };
        this._$ = $t.$;
        $p._parent = null;
        $p.$ctor = function(parent, observer, cancel) {
            System.Reactive.Sink$1$(TSource).prototype.$ctor.call(this, observer, cancel);
            this._parent = parent;
        };
        $p.$ctor.$type = $t;
        $p.$ctor.$new = function(parent, observer, cancel) {
            return new $p.$ctor.$type(
                this, 
                parent, 
                observer, 
                cancel
            );
        };
        $p.OnNext = function(value) {
            var shouldRun;
            try {
                shouldRun = this._parent._predicate(value);
            }
            catch (exception) {
                this._observer.System$IObserver$1$OnError(exception);
                System.Reactive.Sink$1$(TSource).prototype.Dispose.call(this);
                return;
            }
            if (shouldRun)
                this._observer.System$IObserver$1$OnNext(value);
        };
        $p.System$IObserver$1$OnNext = $p.OnNext;
        $p.OnError = function(error) {
            this._observer.System$IObserver$1$OnError(error);
            System.Reactive.Sink$1$(TSource).prototype.Dispose.call(this);
        };
        $p.System$IObserver$1$OnError = $p.OnError;
        $p.OnCompleted = function() {
            this._observer.System$IObserver$1$OnCompleted();
            System.Reactive.Sink$1$(TSource).prototype.Dispose.call(this);
        };
        $p.System$IObserver$1$OnCompleted = $p.OnCompleted;
    }).call($t, $t._, $t._.prototype);
    $WootzJs$Rx$AssemblyTypes.push($t._);
    $t.τ = $define("System.Reactive.Linq.Observables.Where<TSource>.τ", System.Reactive.Sink$1);
    ($t.τ.$TypeInitializer = function($t, $p) {
        $t.$GetAssembly = window.$WootzJs$Rx$GetAssembly;
        $p.$type = $t;
        $t.$baseType = System.Reactive.Sink$1;
        $p.$typeName = "System.Reactive.Linq.Observables.Where`1.τ";
        $t.$typeName = $p.$typeName;
        $t.$GetType = function() {
            return System.Type._GetTypeFromTypeFunc(this);
        };
        $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("τ", $arrayinit([], System.Attribute));this.$type.Init("System.Reactive.Linq.Observables.Where`1.τ", System.Reactive.Linq.Observables.Where$1.τ, System.Reactive.Sink$1$(TSource), $arrayinit([System.IDisposable, System.IObserver$1], System.Type), $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("_parent", System.Reactive.Linq.Observables.Where$1, System.Reflection.FieldAttributes().Private | System.Reflection.FieldAttributes().InitOnly, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("_index", System.Int32, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("OnNext", System.Reactive.Linq.Observables.Where$1.τ.prototype.OnNext, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", TSource, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("OnError", System.Reactive.Linq.Observables.Where$1.τ.prototype.OnError, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("error", System.Exception, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("OnCompleted", System.Reactive.Linq.Observables.Where$1.τ.prototype.OnCompleted, $arrayinit([], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", System.Reactive.Linq.Observables.Where$1.τ.prototype.$ctor, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("parent", System.Reactive.Linq.Observables.Where$1, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("observer", System.IObserver$1, 1, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("cancel", System.IDisposable, 2, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
        $t.$StaticInitializer = function() {
            if ($t.$isStaticInitialized)
                return;
            $t.$isStaticInitialized = true;
            System.Reactive.Sink$1$(TSource).$StaticInitializer();
        };
        $t.$ = function() {
            return $generic.call(this, this.τ, arguments)();
        };
        this.τ$ = $t.$;
        $p._parent = null;
        $p._index = 0;
        $p.$ctor = function(parent, observer, cancel) {
            System.Reactive.Sink$1$(TSource).prototype.$ctor.call(this, observer, cancel);
            this._parent = parent;
            this._index = 0;
        };
        $p.$ctor.$type = $t;
        $p.$ctor.$new = function(parent, observer, cancel) {
            return new $p.$ctor.$type(
                this, 
                parent, 
                observer, 
                cancel
            );
        };
        $p.OnNext = function(value) {
            var shouldRun;
            try {
                shouldRun = this._parent._predicateI(value, this._index++);
            }
            catch (exception) {
                this._observer.System$IObserver$1$OnError(exception);
                System.Reactive.Sink$1$(TSource).prototype.Dispose.call(this);
                return;
            }
            if (shouldRun)
                this._observer.System$IObserver$1$OnNext(value);
        };
        $p.System$IObserver$1$OnNext = $p.OnNext;
        $p.OnError = function(error) {
            this._observer.System$IObserver$1$OnError(error);
            System.Reactive.Sink$1$(TSource).prototype.Dispose.call(this);
        };
        $p.System$IObserver$1$OnError = $p.OnError;
        $p.OnCompleted = function() {
            this._observer.System$IObserver$1$OnCompleted();
            System.Reactive.Sink$1$(TSource).prototype.Dispose.call(this);
        };
        $p.System$IObserver$1$OnCompleted = $p.OnCompleted;
    }).call($t, $t.τ, $t.τ.prototype);
    $WootzJs$Rx$AssemblyTypes.push($t.τ);
}).call(null, System.Reactive.Linq.Observables.Where$1, System.Reactive.Linq.Observables.Where$1.prototype);
$WootzJs$Rx$AssemblyTypes.push(System.Reactive.Linq.Observables.Where$1);
System.Reactive.NopObserver$1 = $define("System.Reactive.NopObserver<T>", System.Object);
(System.Reactive.NopObserver$1.$TypeInitializer = function($t, $p, T) {
    $t.$GetAssembly = window.$WootzJs$Rx$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Object;
    $p.$typeName = "System.Reactive.NopObserver`1";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("NopObserver", $arrayinit([], System.Attribute));this.$type.Init("System.Reactive.NopObserver`1", System.Reactive.NopObserver$1, System.Object, $arrayinit([System.IObserver$1], System.Type), $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("Instance", System.IObserver$1, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().InitOnly, null, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("$cctor", System.Reactive.NopObserver$1.prototype.$cctor, $arrayinit([], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Private | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("OnCompleted", System.Reactive.NopObserver$1.prototype.OnCompleted, $arrayinit([], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("OnError", System.Reactive.NopObserver$1.prototype.OnError, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("error", System.Exception, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("OnNext", System.Reactive.NopObserver$1.prototype.OnNext, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", T, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", System.Reactive.NopObserver$1.prototype.$ctor, $arrayinit([], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {
        if ($t.$isStaticInitialized)
            return;
        $t.$isStaticInitialized = true;
        System.Object.$StaticInitializer();
        System.Reactive.NopObserver$1$(T).Instance = System.Reactive.NopObserver$1$(T).prototype.$ctor.$new();
    };
    $t.$ = function() {
        return $generic.call(null, System.Reactive.NopObserver$1, arguments)();
    };
    window.System.Reactive.NopObserver$1$ = $t.$;
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.Instance = null;
    $p.OnCompleted = function() {};
    $p.System$IObserver$1$OnCompleted = $p.OnCompleted;
    $p.OnError = function(error) {};
    $p.System$IObserver$1$OnError = $p.OnError;
    $p.OnNext = function(value) {};
    $p.System$IObserver$1$OnNext = $p.OnNext;
}).call(null, System.Reactive.NopObserver$1, System.Reactive.NopObserver$1.prototype);
$WootzJs$Rx$AssemblyTypes.push(System.Reactive.NopObserver$1);
System.Reactive.DoneObserver$1 = $define("System.Reactive.DoneObserver<T>", System.Object);
(System.Reactive.DoneObserver$1.$TypeInitializer = function($t, $p, T) {
    $t.$GetAssembly = window.$WootzJs$Rx$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Object;
    $p.$typeName = "System.Reactive.DoneObserver`1";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("DoneObserver", $arrayinit([], System.Attribute));this.$type.Init("System.Reactive.DoneObserver`1", System.Reactive.DoneObserver$1, System.Object, $arrayinit([System.IObserver$1], System.Type), $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("Completed", System.IObserver$1, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().InitOnly, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("$Exception$k__BackingField", System.Exception, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("$cctor", System.Reactive.DoneObserver$1.prototype.$cctor, $arrayinit([], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Private | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_Exception", System.Reactive.DoneObserver$1.prototype.get_Exception, $arrayinit([], System.Reflection.ParameterInfo), System.Exception, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Exception", System.Reactive.DoneObserver$1.prototype.set_Exception, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Exception, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("OnCompleted", System.Reactive.DoneObserver$1.prototype.OnCompleted, $arrayinit([], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("OnError", System.Reactive.DoneObserver$1.prototype.OnError, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("error", System.Exception, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("OnNext", System.Reactive.DoneObserver$1.prototype.OnNext, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", T, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", System.Reactive.DoneObserver$1.prototype.$ctor, $arrayinit([], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.PropertyInfo.prototype.$ctor.$new("Exception", System.Exception, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Exception", System.Reactive.DoneObserver$1.prototype.get_Exception, $arrayinit([], System.Reflection.ParameterInfo), System.Exception, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Exception", System.Reactive.DoneObserver$1.prototype.set_Exception, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Exception, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute))], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {
        if ($t.$isStaticInitialized)
            return;
        $t.$isStaticInitialized = true;
        System.Object.$StaticInitializer();
        System.Reactive.DoneObserver$1$(T).Completed = System.Reactive.DoneObserver$1$(T).prototype.$ctor.$new();
    };
    $t.$ = function() {
        return $generic.call(null, System.Reactive.DoneObserver$1, arguments)();
    };
    window.System.Reactive.DoneObserver$1$ = $t.$;
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.Completed = null;
    $p.$Exception$k__BackingField = null;
    $p.get_Exception = function() {return this.$Exception$k__BackingField;};
    $p.set_Exception = function(value) {this.$Exception$k__BackingField = value;};
    $p.OnCompleted = function() {};
    $p.System$IObserver$1$OnCompleted = $p.OnCompleted;
    $p.OnError = function(error) {};
    $p.System$IObserver$1$OnError = $p.OnError;
    $p.OnNext = function(value) {};
    $p.System$IObserver$1$OnNext = $p.OnNext;
}).call(null, System.Reactive.DoneObserver$1, System.Reactive.DoneObserver$1.prototype);
$WootzJs$Rx$AssemblyTypes.push(System.Reactive.DoneObserver$1);
System.Reactive.DisposedObserver$1 = $define("System.Reactive.DisposedObserver<T>", System.Object);
(System.Reactive.DisposedObserver$1.$TypeInitializer = function($t, $p, T) {
    $t.$GetAssembly = window.$WootzJs$Rx$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Object;
    $p.$typeName = "System.Reactive.DisposedObserver`1";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("DisposedObserver", $arrayinit([], System.Attribute));this.$type.Init("System.Reactive.DisposedObserver`1", System.Reactive.DisposedObserver$1, System.Object, $arrayinit([System.IObserver$1], System.Type), $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("Instance", System.IObserver$1, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().InitOnly, null, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("$cctor", System.Reactive.DisposedObserver$1.prototype.$cctor, $arrayinit([], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Private | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("OnCompleted", System.Reactive.DisposedObserver$1.prototype.OnCompleted, $arrayinit([], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("OnError", System.Reactive.DisposedObserver$1.prototype.OnError, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("error", System.Exception, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("OnNext", System.Reactive.DisposedObserver$1.prototype.OnNext, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", T, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", System.Reactive.DisposedObserver$1.prototype.$ctor, $arrayinit([], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {
        if ($t.$isStaticInitialized)
            return;
        $t.$isStaticInitialized = true;
        System.Object.$StaticInitializer();
        System.Reactive.DisposedObserver$1$(T).Instance = System.Reactive.DisposedObserver$1$(T).prototype.$ctor.$new();
    };
    $t.$ = function() {
        return $generic.call(null, System.Reactive.DisposedObserver$1, arguments)();
    };
    window.System.Reactive.DisposedObserver$1$ = $t.$;
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.Instance = null;
    $p.OnCompleted = function() {
        throw System.ObjectDisposedException.prototype.$ctor$1.$new("").InternalInit(new Error());
    };
    $p.System$IObserver$1$OnCompleted = $p.OnCompleted;
    $p.OnError = function(error) {
        throw System.ObjectDisposedException.prototype.$ctor$1.$new("").InternalInit(new Error());
    };
    $p.System$IObserver$1$OnError = $p.OnError;
    $p.OnNext = function(value) {
        throw System.ObjectDisposedException.prototype.$ctor$1.$new("").InternalInit(new Error());
    };
    $p.System$IObserver$1$OnNext = $p.OnNext;
}).call(null, System.Reactive.DisposedObserver$1, System.Reactive.DisposedObserver$1.prototype);
$WootzJs$Rx$AssemblyTypes.push(System.Reactive.DisposedObserver$1);
System.Reactive.Observer$1 = $define("System.Reactive.Observer<T>", System.Object);
(System.Reactive.Observer$1.$TypeInitializer = function($t, $p, T) {
    $t.$GetAssembly = window.$WootzJs$Rx$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Object;
    $p.$typeName = "System.Reactive.Observer`1";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("Observer", $arrayinit([], System.Attribute));this.$type.Init("System.Reactive.Observer`1", System.Reactive.Observer$1, System.Object, $arrayinit([System.IObserver$1], System.Type), $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("_observers", System.Reactive.ImmutableList$1, System.Reflection.FieldAttributes().Private | System.Reflection.FieldAttributes().InitOnly, null, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("OnCompleted", System.Reactive.Observer$1.prototype.OnCompleted, $arrayinit([], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("OnError", System.Reactive.Observer$1.prototype.OnError, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("error", System.Exception, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("OnNext", System.Reactive.Observer$1.prototype.OnNext, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", T, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Add", System.Reactive.Observer$1.prototype.Add, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("observer", System.IObserver$1, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.IObserver$1, System.Reflection.MethodAttributes().Assembly, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Remove", System.Reactive.Observer$1.prototype.Remove, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("observer", System.IObserver$1, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.IObserver$1, System.Reflection.MethodAttributes().Assembly, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", System.Reactive.Observer$1.prototype.$ctor, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("observers", System.Reactive.ImmutableList$1, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {
        if ($t.$isStaticInitialized)
            return;
        $t.$isStaticInitialized = true;
        System.Object.$StaticInitializer();
    };
    $t.$ = function() {
        return $generic.call(null, System.Reactive.Observer$1, arguments)();
    };
    window.System.Reactive.Observer$1$ = $t.$;
    $p._observers = null;
    $p.$ctor = function(observers) {
        System.Object.prototype.$ctor.call(this);
        this._observers = observers;
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function(observers) {
        return new $p.$ctor.$type(this, observers);
    };
    $p.OnCompleted = function() {
        {
            var $anon$1iterator = this._observers.get_Data();
            var $anon$2enumerator = $anon$1iterator.System$Collections$IEnumerable$GetEnumerator();
            while ($anon$2enumerator.System$Collections$IEnumerator$MoveNext()) {
                var observer = $anon$2enumerator.System$Collections$IEnumerator$get_Current();
                observer.System$IObserver$1$OnCompleted();
            }
        }
    };
    $p.System$IObserver$1$OnCompleted = $p.OnCompleted;
    $p.OnError = function(error) {
        {
            var $anon$1iterator = this._observers.get_Data();
            var $anon$2enumerator = $anon$1iterator.System$Collections$IEnumerable$GetEnumerator();
            while ($anon$2enumerator.System$Collections$IEnumerator$MoveNext()) {
                var observer = $anon$2enumerator.System$Collections$IEnumerator$get_Current();
                observer.System$IObserver$1$OnError(error);
            }
        }
    };
    $p.System$IObserver$1$OnError = $p.OnError;
    $p.OnNext = function(value) {
        {
            var $anon$1iterator = this._observers.get_Data();
            var $anon$2enumerator = $anon$1iterator.System$Collections$IEnumerable$GetEnumerator();
            while ($anon$2enumerator.System$Collections$IEnumerator$MoveNext()) {
                var observer = $anon$2enumerator.System$Collections$IEnumerator$get_Current();
                observer.System$IObserver$1$OnNext(value);
            }
        }
    };
    $p.System$IObserver$1$OnNext = $p.OnNext;
    $p.Add = function(observer) {
        return System.Reactive.Observer$1$(T).prototype.$ctor.$new(this._observers.Add(observer));
    };
    $p.Remove = function(observer) {
        var i = Array.IndexOf$1(this._observers.get_Data(), observer);
        if (i < 0)
            return this;
        if (this._observers.get_Data().length == 2) {
            return this._observers.get_Data()[1 - i];
        }
        else {
            return System.Reactive.Observer$1$(T).prototype.$ctor.$new(this._observers.Remove(observer));
        }
    };
}).call(null, System.Reactive.Observer$1, System.Reactive.Observer$1.prototype);
$WootzJs$Rx$AssemblyTypes.push(System.Reactive.Observer$1);
System.Reactive.PlatformServices.DefaultExceptionServices = $define("System.Reactive.PlatformServices.DefaultExceptionServices", System.Object);
(System.Reactive.PlatformServices.DefaultExceptionServices.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Rx$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Object;
    $p.$typeName = "System.Reactive.PlatformServices.DefaultExceptionServices";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("DefaultExceptionServices", $arrayinit([], System.Attribute));this.$type.Init("System.Reactive.PlatformServices.DefaultExceptionServices", System.Reactive.PlatformServices.DefaultExceptionServices, System.Object, $arrayinit([System.Reactive.PlatformServices.IExceptionServices], System.Type), $arrayinit([], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("Rethrow", System.Reactive.PlatformServices.DefaultExceptionServices.prototype.Rethrow, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("exception", System.Exception, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", System.Reactive.PlatformServices.DefaultExceptionServices.prototype.$ctor, $arrayinit([], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {
        if ($t.$isStaticInitialized)
            return;
        $t.$isStaticInitialized = true;
        System.Object.$StaticInitializer();
    };
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.Rethrow = function(exception) {
        throw exception.InternalInit(new Error());
    };
    $p.System$Reactive$PlatformServices$IExceptionServices$Rethrow = $p.Rethrow;
}).call(null, System.Reactive.PlatformServices.DefaultExceptionServices, System.Reactive.PlatformServices.DefaultExceptionServices.prototype);
$WootzJs$Rx$AssemblyTypes.push(System.Reactive.PlatformServices.DefaultExceptionServices);
System.Reactive.PlatformServices.IExceptionServices = $define("System.Reactive.PlatformServices.IExceptionServices", System.Object);
(System.Reactive.PlatformServices.IExceptionServices.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Rx$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Object;
    $p.$typeName = "System.Reactive.PlatformServices.IExceptionServices";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("IExceptionServices", $arrayinit([], System.Attribute));this.$type.Init("System.Reactive.PlatformServices.IExceptionServices", System.Reactive.PlatformServices.IExceptionServices, null, $arrayinit([], System.Type), $arrayinit([], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("System$Reactive$PlatformServices$IExceptionServices$Rethrow", System.Reactive.PlatformServices.IExceptionServices.prototype.System$Reactive$PlatformServices$IExceptionServices$Rethrow, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("exception", System.Exception, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {
        if ($t.$isStaticInitialized)
            return;
        $t.$isStaticInitialized = true;
    };
    $p.System$Reactive$PlatformServices$IExceptionServices$Rethrow = function(exception) {};
}).call(null, System.Reactive.PlatformServices.IExceptionServices, System.Reactive.PlatformServices.IExceptionServices.prototype);
$WootzJs$Rx$AssemblyTypes.push(System.Reactive.PlatformServices.IExceptionServices);
System.Reactive.PlatformServices.IPlatformEnlightenmentProvider = $define("System.Reactive.PlatformServices.IPlatformEnlightenmentProvider", System.Object);
(System.Reactive.PlatformServices.IPlatformEnlightenmentProvider.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Rx$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Object;
    $p.$typeName = "System.Reactive.PlatformServices.IPlatformEnlightenmentProvider";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("IPlatformEnlightenmentProvider", $arrayinit([], System.Attribute));this.$type.Init("System.Reactive.PlatformServices.IPlatformEnlightenmentProvider", System.Reactive.PlatformServices.IPlatformEnlightenmentProvider, null, $arrayinit([], System.Type), $arrayinit([], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("System$Reactive$PlatformServices$IPlatformEnlightenmentProvider$GetService", System.Reactive.PlatformServices.IPlatformEnlightenmentProvider.prototype.System$Reactive$PlatformServices$IPlatformEnlightenmentProvider$GetService, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("args", $array(System.Object), 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Object, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {
        if ($t.$isStaticInitialized)
            return;
        $t.$isStaticInitialized = true;
    };
    $p.System$Reactive$PlatformServices$IPlatformEnlightenmentProvider$GetService = function(T, args) {};
}).call(null, System.Reactive.PlatformServices.IPlatformEnlightenmentProvider, System.Reactive.PlatformServices.IPlatformEnlightenmentProvider.prototype);
$WootzJs$Rx$AssemblyTypes.push(System.Reactive.PlatformServices.IPlatformEnlightenmentProvider);
System.Reactive.PlatformServices.PlatformEnlightenmentProvider = $define("System.Reactive.PlatformServices.PlatformEnlightenmentProvider", System.Object);
(System.Reactive.PlatformServices.PlatformEnlightenmentProvider.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Rx$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Object;
    $p.$typeName = "System.Reactive.PlatformServices.PlatformEnlightenmentProvider";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("PlatformEnlightenmentProvider", $arrayinit([], System.Attribute));this.$type.Init("System.Reactive.PlatformServices.PlatformEnlightenmentProvider", System.Reactive.PlatformServices.PlatformEnlightenmentProvider, System.Object, $arrayinit([], System.Type), $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("s_current", System.Reactive.PlatformServices.IPlatformEnlightenmentProvider, System.Reflection.FieldAttributes().Private | System.Reflection.FieldAttributes().Static, null, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("get_Current", System.Reactive.PlatformServices.PlatformEnlightenmentProvider.prototype.get_Current, $arrayinit([], System.Reflection.ParameterInfo), System.Reactive.PlatformServices.IPlatformEnlightenmentProvider, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Current", System.Reactive.PlatformServices.PlatformEnlightenmentProvider.prototype.set_Current, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Reactive.PlatformServices.IPlatformEnlightenmentProvider, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.MethodInfo), $arrayinit([System.Reflection.PropertyInfo.prototype.$ctor.$new("Current", System.Reactive.PlatformServices.IPlatformEnlightenmentProvider, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Current", System.Reactive.PlatformServices.PlatformEnlightenmentProvider.prototype.get_Current, $arrayinit([], System.Reflection.ParameterInfo), System.Reactive.PlatformServices.IPlatformEnlightenmentProvider, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Current", System.Reactive.PlatformServices.PlatformEnlightenmentProvider.prototype.set_Current, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Reactive.PlatformServices.IPlatformEnlightenmentProvider, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute))], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {
        if ($t.$isStaticInitialized)
            return;
        $t.$isStaticInitialized = true;
        System.Object.$StaticInitializer();
    };
    $p.s_current = null;
    $t.get_Current = function() {
        if (System.Reactive.PlatformServices.PlatformEnlightenmentProvider().s_current == null) {
            if (System.Reactive.PlatformServices.PlatformEnlightenmentProvider().s_current == null) {
                var ifType = System.Reactive.PlatformServices.IPlatformEnlightenmentProvider.$GetType();
                var asm = System.Reflection.AssemblyName.prototype.$ctor$1.$new(ifType.get_Assembly().get_FullName());
                asm.set_Name("System.Reactive.PlatformServices");
                var name = "System.Reactive.PlatformServices.CurrentPlatformEnlightenmentProvider, " + asm.get_FullName();
                var t = System.Type.GetType$1(name);
                if (t != null)
                    System.Reactive.PlatformServices.PlatformEnlightenmentProvider().s_current = $cast(System.Reactive.PlatformServices.IPlatformEnlightenmentProvider, System.Reflection.Activator.CreateInstance(t));
                else
                    System.Reactive.PlatformServices.PlatformEnlightenmentProvider().s_current = System.Reactive.PlatformServices.DefaultPlatformEnlightenmentProvider.prototype.$ctor.$new();
            }
        }
        return System.Reactive.PlatformServices.PlatformEnlightenmentProvider().s_current;
    };
    $t.set_Current = function(value) {
        System.Reactive.PlatformServices.PlatformEnlightenmentProvider().s_current = value;
    };
}).call(null, System.Reactive.PlatformServices.PlatformEnlightenmentProvider, System.Reactive.PlatformServices.PlatformEnlightenmentProvider.prototype);
$WootzJs$Rx$AssemblyTypes.push(System.Reactive.PlatformServices.PlatformEnlightenmentProvider);
System.Reactive.PlatformServices.DefaultPlatformEnlightenmentProvider = $define("System.Reactive.PlatformServices.DefaultPlatformEnlightenmentProvider", System.Object);
(System.Reactive.PlatformServices.DefaultPlatformEnlightenmentProvider.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Rx$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Object;
    $p.$typeName = "System.Reactive.PlatformServices.DefaultPlatformEnlightenmentProvider";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("DefaultPlatformEnlightenmentProvider", $arrayinit([], System.Attribute));this.$type.Init("System.Reactive.PlatformServices.DefaultPlatformEnlightenmentProvider", System.Reactive.PlatformServices.DefaultPlatformEnlightenmentProvider, System.Object, $arrayinit([System.Reactive.PlatformServices.IPlatformEnlightenmentProvider], System.Type), $arrayinit([], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("GetService", System.Reactive.PlatformServices.DefaultPlatformEnlightenmentProvider.prototype.GetService, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("args", $array(System.Object), 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Object, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", System.Reactive.PlatformServices.DefaultPlatformEnlightenmentProvider.prototype.$ctor, $arrayinit([], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {
        if ($t.$isStaticInitialized)
            return;
        $t.$isStaticInitialized = true;
        System.Object.$StaticInitializer();
    };
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.GetService = function(T, args) {
        return null;
    };
    $p.System$Reactive$PlatformServices$IPlatformEnlightenmentProvider$GetService = $p.GetService;
}).call(null, System.Reactive.PlatformServices.DefaultPlatformEnlightenmentProvider, System.Reactive.PlatformServices.DefaultPlatformEnlightenmentProvider.prototype);
$WootzJs$Rx$AssemblyTypes.push(System.Reactive.PlatformServices.DefaultPlatformEnlightenmentProvider);
System.Reactive.SafeObserver$1 = $define("System.Reactive.SafeObserver<TSource>", System.Object);
(System.Reactive.SafeObserver$1.$TypeInitializer = function($t, $p, TSource) {
    $t.$GetAssembly = window.$WootzJs$Rx$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Object;
    $p.$typeName = "System.Reactive.SafeObserver`1";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("SafeObserver", $arrayinit([], System.Attribute));this.$type.Init("System.Reactive.SafeObserver`1", System.Reactive.SafeObserver$1, System.Object, $arrayinit([System.IObserver$1], System.Type), $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("_observer", System.IObserver$1, System.Reflection.FieldAttributes().Private | System.Reflection.FieldAttributes().InitOnly, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("_disposable", System.IDisposable, System.Reflection.FieldAttributes().Private | System.Reflection.FieldAttributes().InitOnly, null, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("Create", System.Reactive.SafeObserver$1.prototype.Create, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("observer", System.IObserver$1, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("disposable", System.IDisposable, 1, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.IObserver$1, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("OnNext", System.Reactive.SafeObserver$1.prototype.OnNext, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", TSource, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("OnError", System.Reactive.SafeObserver$1.prototype.OnError, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("error", System.Exception, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("OnCompleted", System.Reactive.SafeObserver$1.prototype.OnCompleted, $arrayinit([], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", System.Reactive.SafeObserver$1.prototype.$ctor, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("observer", System.IObserver$1, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("disposable", System.IDisposable, 1, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Private, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {
        if ($t.$isStaticInitialized)
            return;
        $t.$isStaticInitialized = true;
        System.Object.$StaticInitializer();
    };
    $t.$ = function() {
        return $generic.call(null, System.Reactive.SafeObserver$1, arguments)();
    };
    window.System.Reactive.SafeObserver$1$ = $t.$;
    $p._observer = null;
    $p._disposable = null;
    $t.Create = function(observer, disposable) {
        var a = (function() {
            var $as$ = observer;
            if (!System.Type.prototype.IsInstanceOfType.call(System.Reactive.AnonymousObserver$1$(TSource).$GetType(), $as$))
                $as$ = null;
            return $as$;
        }).call(this);
        if (a != null)
            return a.MakeSafe(disposable);
        else
            return System.Reactive.SafeObserver$1$(TSource).prototype.$ctor.$new(observer, disposable);
    };
    $p.$ctor = function(observer, disposable) {
        System.Object.prototype.$ctor.call(this);
        this._observer = observer;
        this._disposable = disposable;
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function(observer, disposable) {
        return new $p.$ctor.$type(this, observer, disposable);
    };
    $p.OnNext = function(value) {
        var __noError = false;
        try {
            this._observer.System$IObserver$1$OnNext(value);
            __noError = true;
        }
        finally {
            if (!__noError)
                this._disposable.System$IDisposable$Dispose();
        }
    };
    $p.System$IObserver$1$OnNext = $p.OnNext;
    $p.OnError = function(error) {
        try {
            this._observer.System$IObserver$1$OnError(error);
        }
        finally {
            this._disposable.System$IDisposable$Dispose();
        }
    };
    $p.System$IObserver$1$OnError = $p.OnError;
    $p.OnCompleted = function() {
        try {
            this._observer.System$IObserver$1$OnCompleted();
        }
        finally {
            this._disposable.System$IDisposable$Dispose();
        }
    };
    $p.System$IObserver$1$OnCompleted = $p.OnCompleted;
}).call(null, System.Reactive.SafeObserver$1, System.Reactive.SafeObserver$1.prototype);
$WootzJs$Rx$AssemblyTypes.push(System.Reactive.SafeObserver$1);
System.Reactive.Stubs$1 = $define("System.Reactive.Stubs<T>", System.Object);
(System.Reactive.Stubs$1.$TypeInitializer = function($t, $p, T) {
    $t.$GetAssembly = window.$WootzJs$Rx$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Object;
    $p.$typeName = "System.Reactive.Stubs`1";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("Stubs", $arrayinit([], System.Attribute));this.$type.Init("System.Reactive.Stubs`1", System.Reactive.Stubs$1, System.Object, $arrayinit([], System.Type), $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("Ignore", System.Action$1, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().InitOnly, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("I", System.Func$2, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().InitOnly, null, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("$cctor", System.Reactive.Stubs$1.prototype.$cctor, $arrayinit([], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Private | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {
        if ($t.$isStaticInitialized)
            return;
        $t.$isStaticInitialized = true;
        System.Object.$StaticInitializer();
        System.Reactive.Stubs$1$(T).Ignore = $delegate(this, System.Action$1$(T), function(_) {});
        System.Reactive.Stubs$1$(T).I = $delegate(this, System.Func$2$(T, T), function(_) {
            return _;
        });
    };
    $t.$ = function() {
        return $generic.call(null, System.Reactive.Stubs$1, arguments)();
    };
    window.System.Reactive.Stubs$1$ = $t.$;
    $p.Ignore = null;
    $p.I = null;
}).call(null, System.Reactive.Stubs$1, System.Reactive.Stubs$1.prototype);
$WootzJs$Rx$AssemblyTypes.push(System.Reactive.Stubs$1);
System.Reactive.Stubs = $define("System.Reactive.Stubs", System.Object);
(System.Reactive.Stubs.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Rx$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Object;
    $p.$typeName = "System.Reactive.Stubs";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("Stubs", $arrayinit([], System.Attribute));this.$type.Init("System.Reactive.Stubs", System.Reactive.Stubs, System.Object, $arrayinit([], System.Type), $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("Nop", System.Action, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().InitOnly, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("Throw", System.Action$1, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().InitOnly, null, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("$cctor", System.Reactive.Stubs.prototype.$cctor, $arrayinit([], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Private | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {
        if ($t.$isStaticInitialized)
            return;
        $t.$isStaticInitialized = true;
        System.Object.$StaticInitializer();
        System.Reactive.Stubs.Nop = $delegate(this, System.Action, function() {});
        System.Reactive.Stubs.Throw = $delegate(this, System.Action$1$(System.Exception), function(ex) {
            System.Reactive.ExceptionHelpers.Throw(ex);
        });
    };
    $p.Nop = null;
    $p.Throw = null;
}).call(null, System.Reactive.Stubs, System.Reactive.Stubs.prototype);
$WootzJs$Rx$AssemblyTypes.push(System.Reactive.Stubs);
System.Reactive.Subjects.Subject$1 = $define("System.Reactive.Subjects.Subject<T>", System.Object);
(System.Reactive.Subjects.Subject$1.$TypeInitializer = function($t, $p, T) {
    $t.$GetAssembly = window.$WootzJs$Rx$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Object;
    $p.$typeName = "System.Reactive.Subjects.Subject`1";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("Subject", $arrayinit([], System.Attribute));this.$type.Init("System.Reactive.Subjects.Subject`1", System.Reactive.Subjects.Subject$1, System.Object, $arrayinit([System.IDisposable, System.Reactive.ISubject$1, System.Reactive.ISubject$2, System.IObservable$1, System.IObserver$1], System.Type), $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("_observer", System.IObserver$1, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("OnCompleted", System.Reactive.Subjects.Subject$1.prototype.OnCompleted, $arrayinit([], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("OnError", System.Reactive.Subjects.Subject$1.prototype.OnError, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("error", System.Exception, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("OnNext", System.Reactive.Subjects.Subject$1.prototype.OnNext, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", T, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Subscribe", System.Reactive.Subjects.Subject$1.prototype.Subscribe, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("observer", System.IObserver$1, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.IDisposable, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Unsubscribe", System.Reactive.Subjects.Subject$1.prototype.Unsubscribe, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("observer", System.IObserver$1, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Private, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Dispose", System.Reactive.Subjects.Subject$1.prototype.Dispose, $arrayinit([], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", System.Reactive.Subjects.Subject$1.prototype.$ctor, $arrayinit([], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {
        if ($t.$isStaticInitialized)
            return;
        $t.$isStaticInitialized = true;
        System.Object.$StaticInitializer();
    };
    $t.$ = function() {
        return $generic.call(null, System.Reactive.Subjects.Subject$1, arguments)();
    };
    window.System.Reactive.Subjects.Subject$1$ = $t.$;
    $p._observer = null;
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
        this._observer = System.Reactive.NopObserver$1$(T).Instance;
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.OnCompleted = function() {
        var oldObserver;
        var newObserver = System.Reactive.DoneObserver$1$(T).Completed;
        do {
            oldObserver = this._observer;
            if (oldObserver == System.Reactive.DisposedObserver$1$(T).Instance || System.Reactive.DoneObserver$1$(T).$GetType().IsInstanceOfType(oldObserver))
                break;
        }
        while ((function() {
            var $anon$1 = {
                value: this._observer
            };
            var $result$ = System.Threading.Interlocked.CompareExchange(
                System.IObserver$1$(T), 
                $anon$1, 
                newObserver, 
                oldObserver
            );
            this._observer = $anon$1.value;
            return $result$;
        }).call(this) != oldObserver);
        oldObserver.System$IObserver$1$OnCompleted();
    };
    $p.System$IObserver$1$OnCompleted = $p.OnCompleted;
    $p.OnError = function(error) {
        if (error == null)
            throw System.ArgumentNullException.prototype.$ctor.$new("error").InternalInit(new Error());
        var oldObserver;
        var newObserver = (function() {
            var $obj$ = System.Reactive.DoneObserver$1$(T).prototype.$ctor.$new();
            $obj$.set_Exception(error);
            return $obj$;
        }).call(this);
        do {
            oldObserver = this._observer;
            if (oldObserver == System.Reactive.DisposedObserver$1$(T).Instance || System.Reactive.DoneObserver$1$(T).$GetType().IsInstanceOfType(oldObserver))
                break;
        }
        while ((function() {
            var $anon$1 = {
                value: this._observer
            };
            var $result$ = System.Threading.Interlocked.CompareExchange(
                System.IObserver$1$(T), 
                $anon$1, 
                newObserver, 
                oldObserver
            );
            this._observer = $anon$1.value;
            return $result$;
        }).call(this) != oldObserver);
        oldObserver.System$IObserver$1$OnError(error);
    };
    $p.System$IObserver$1$OnError = $p.OnError;
    $p.OnNext = function(value) {
        this._observer.System$IObserver$1$OnNext(value);
    };
    $p.System$IObserver$1$OnNext = $p.OnNext;
    $p.Subscribe = function(observer) {
        if (observer == null)
            throw System.ArgumentNullException.prototype.$ctor.$new("observer").InternalInit(new Error());
        var oldObserver;
        var newObserver;
        do {
            oldObserver = this._observer;
            if (oldObserver == System.Reactive.DisposedObserver$1$(T).Instance) {
                throw System.ObjectDisposedException.prototype.$ctor$1.$new("").InternalInit(new Error());
            }
            if (oldObserver == System.Reactive.DoneObserver$1$(T).Completed) {
                observer.System$IObserver$1$OnCompleted();
                return System.Reactive.Disposables.Disposable().get_Empty();
            }
            var done = (function() {
                var $as$ = oldObserver;
                if (!System.Type.prototype.IsInstanceOfType.call(System.Reactive.DoneObserver$1$(T).$GetType(), $as$))
                    $as$ = null;
                return $as$;
            }).call(this);
            if (done != null) {
                observer.System$IObserver$1$OnError(done.get_Exception());
                return System.Reactive.Disposables.Disposable().get_Empty();
            }
            if (oldObserver == System.Reactive.NopObserver$1$(T).Instance) {
                newObserver = observer;
            }
            else {
                var obs = (function() {
                    var $as$ = oldObserver;
                    if (!System.Type.prototype.IsInstanceOfType.call(System.Reactive.Observer$1$(T).$GetType(), $as$))
                        $as$ = null;
                    return $as$;
                }).call(this);
                if (obs != null) {
                    newObserver = obs.Add(observer);
                }
                else {
                    newObserver = System.Reactive.Observer$1$(T).prototype.$ctor.$new(System.Reactive.ImmutableList$1$(System.IObserver$1$(T)).prototype.$ctor$1.$new($arrayinit([oldObserver, observer], System.IObserver$1$(T))));
                }
            }
        }
        while ((function() {
            var $anon$1 = {
                value: this._observer
            };
            var $result$ = System.Threading.Interlocked.CompareExchange(
                System.IObserver$1$(T), 
                $anon$1, 
                newObserver, 
                oldObserver
            );
            this._observer = $anon$1.value;
            return $result$;
        }).call(this) != oldObserver);
        return System.Reactive.Subjects.Subject$1$(T).Subscription$().prototype.$ctor.$new(this, observer);
    };
    $p.System$IObservable$1$Subscribe = $p.Subscribe;
    $t.Subscription = $define("System.Reactive.Subjects.Subject<T>.Subscription", System.Object);
    ($t.Subscription.$TypeInitializer = function($t, $p) {
        $t.$GetAssembly = window.$WootzJs$Rx$GetAssembly;
        $p.$type = $t;
        $t.$baseType = System.Object;
        $p.$typeName = "System.Reactive.Subjects.Subject`1.Subscription";
        $t.$typeName = $p.$typeName;
        $t.$GetType = function() {
            return System.Type._GetTypeFromTypeFunc(this);
        };
        $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("Subscription", $arrayinit([], System.Attribute));this.$type.Init("System.Reactive.Subjects.Subject`1.Subscription", System.Reactive.Subjects.Subject$1.Subscription, System.Object, $arrayinit([System.IDisposable], System.Type), $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("_subject", System.Reactive.Subjects.Subject$1, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("_observer", System.IObserver$1, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("Dispose", System.Reactive.Subjects.Subject$1.Subscription.prototype.Dispose, $arrayinit([], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", System.Reactive.Subjects.Subject$1.Subscription.prototype.$ctor, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("subject", System.Reactive.Subjects.Subject$1, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("observer", System.IObserver$1, 1, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
        $t.$StaticInitializer = function() {
            if ($t.$isStaticInitialized)
                return;
            $t.$isStaticInitialized = true;
            System.Object.$StaticInitializer();
        };
        $t.$ = function() {
            return $generic.call(this, this.Subscription, arguments)();
        };
        this.Subscription$ = $t.$;
        $p._subject = null;
        $p._observer = null;
        $p.$ctor = function(subject, observer) {
            System.Object.prototype.$ctor.call(this);
            this._subject = subject;
            this._observer = observer;
        };
        $p.$ctor.$type = $t;
        $p.$ctor.$new = function(subject, observer) {
            return new $p.$ctor.$type(this, subject, observer);
        };
        $p.Dispose = function() {
            var observer = (function() {
                var $anon$1 = {
                    value: this._observer
                };
                var $result$ = System.Threading.Interlocked.Exchange(System.IObserver$1$(T), $anon$1, null);
                this._observer = $anon$1.value;
                return $result$;
            }).call(this);
            if (observer == null)
                return;
            this._subject.Unsubscribe(observer);
            this._subject = null;
        };
        $p.System$IDisposable$Dispose = $p.Dispose;
    }).call($t, $t.Subscription, $t.Subscription.prototype);
    $WootzJs$Rx$AssemblyTypes.push($t.Subscription);
    $p.Unsubscribe = function(observer) {
        var oldObserver;
        var newObserver;
        do {
            oldObserver = this._observer;
            if (oldObserver == System.Reactive.DisposedObserver$1$(T).Instance || System.Reactive.DoneObserver$1$(T).$GetType().IsInstanceOfType(oldObserver))
                return;
            var obs = (function() {
                var $as$ = oldObserver;
                if (!System.Type.prototype.IsInstanceOfType.call(System.Reactive.Observer$1$(T).$GetType(), $as$))
                    $as$ = null;
                return $as$;
            }).call(this);
            if (obs != null) {
                newObserver = obs.Remove(observer);
            }
            else {
                if (oldObserver != observer)
                    return;
                newObserver = System.Reactive.NopObserver$1$(T).Instance;
            }
        }
        while ((function() {
            var $anon$1 = {
                value: this._observer
            };
            var $result$ = System.Threading.Interlocked.CompareExchange(
                System.IObserver$1$(T), 
                $anon$1, 
                newObserver, 
                oldObserver
            );
            this._observer = $anon$1.value;
            return $result$;
        }).call(this) != oldObserver);
    };
    $p.Dispose = function() {
        this._observer = System.Reactive.DisposedObserver$1$(T).Instance;
    };
    $p.System$IDisposable$Dispose = $p.Dispose;
}).call(null, System.Reactive.Subjects.Subject$1, System.Reactive.Subjects.Subject$1.prototype);
$WootzJs$Rx$AssemblyTypes.push(System.Reactive.Subjects.Subject$1);
