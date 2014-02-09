"use strict";
var $WootzJs$JQuery$Assembly = null;
var $WootzJs$JQuery$AssemblyTypes = [];
window.$WootzJs$JQuery$GetAssembly = function() {
    if ($WootzJs$JQuery$Assembly == null)
        $WootzJs$JQuery$Assembly = System.Reflection.Assembly.prototype.$ctor.$new("WootzJs.JQuery", $WootzJs$JQuery$AssemblyTypes, $arrayinit([], System.Attribute));
    return $WootzJs$JQuery$Assembly;
};
$assemblies.push(window.$WootzJs$JQuery$GetAssembly);
window.WootzJs = window.WootzJs || {};
WootzJs.JQuery = WootzJs.JQuery || {};
(Event.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$JQuery$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.JQuery.JqEvent";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("JqEvent", $arrayinit([(function() {var $obj$ = System.Runtime.WootzJs.JsAttribute.prototype.$ctor.$new();$obj$.set_Name("Event");$obj$.set_BuiltIn(true);return $obj$;}).call(this)], System.Attribute));this.$type.Init("Event", Event, System.Object, $arrayinit([], System.Type), $arrayinit([], System.Reflection.FieldInfo), $arrayinit([], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", Event.prototype.$ctor, $arrayinit([], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {
        if (Event.$isStaticInitialized)
            return;
        Event.$isStaticInitialized = true;
        System.Object.$StaticInitializer();
    };
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type();
    };
}).call(null, Event, Event.prototype);
$WootzJs$JQuery$AssemblyTypes.push(Event);
WootzJs.JQuery.JqEventHandler = $define("WootzJs.JQuery.JqEventHandler", System.MulticastDelegate);
(WootzJs.JQuery.JqEventHandler.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$JQuery$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.MulticastDelegate;
    $p.$typeName = "WootzJs.JQuery.JqEventHandler";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("JqEventHandler", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.JQuery.JqEventHandler", WootzJs.JQuery.JqEventHandler, System.MulticastDelegate, $arrayinit([], System.Type), $arrayinit([], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("BeginInvoke", WootzJs.JQuery.JqEventHandler.prototype.BeginInvoke, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("evt", Event, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("callback", System.AsyncCallback, 1, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("object", System.Object, 2, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.IAsyncResult, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("EndInvoke", WootzJs.JQuery.JqEventHandler.prototype.EndInvoke, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("result", System.IAsyncResult, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Invoke", WootzJs.JQuery.JqEventHandler.prototype.Invoke, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("evt", Event, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.JQuery.JqEventHandler.prototype.$ctor, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("object", System.Object, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("method", System.IntPtr, 1, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {
        if (WootzJs.JQuery.JqEventHandler.$isStaticInitialized)
            return;
        WootzJs.JQuery.JqEventHandler.$isStaticInitialized = true;
        System.MulticastDelegate.$StaticInitializer();
    };
}).call(null, WootzJs.JQuery.JqEventHandler, WootzJs.JQuery.JqEventHandler.prototype);
$WootzJs$JQuery$AssemblyTypes.push(WootzJs.JQuery.JqEventHandler);
