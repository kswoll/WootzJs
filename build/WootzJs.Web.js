"use strict";
var $WootzJs$Web$Assembly = null;
var $WootzJs$Web$AssemblyTypes = [];
window.$WootzJs$Web$GetAssembly = function() {
    if ($WootzJs$Web$Assembly == null)
        $WootzJs$Web$Assembly = System.Reflection.Assembly.prototype.$ctor.$new("WootzJs.Web", $WootzJs$Web$AssemblyTypes, $arrayinit([], System.Attribute));
    return $WootzJs$Web$Assembly;
};
$assemblies.push(window.$WootzJs$Web$GetAssembly);
window.WootzJs = window.WootzJs || {};
WootzJs.Web = WootzJs.Web || {};
(Event.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Web$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Web.PopStateEvent";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("PopStateEvent", $arrayinit([(function() {var $obj$ = System.Runtime.WootzJs.JsAttribute.prototype.$ctor.$new();$obj$.set_Name("Event");$obj$.set_BuiltIn(true);return $obj$;}).call(this)], System.Attribute));this.$type.Init("Event", Event, System.Object, $arrayinit([], System.Type), $arrayinit([], System.Reflection.FieldInfo), $arrayinit([], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", Event.prototype.$ctor, $arrayinit([], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {};
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type();
    };
}).call(null, Event, Event.prototype);
$WootzJs$Web$AssemblyTypes.push(Event);
WootzJs.Web.IHtmlElement = $define("WootzJs.Web.IHtmlElement", System.Object);
(WootzJs.Web.IHtmlElement.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Web$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Web.IHtmlElement";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("IHtmlElement", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Web.IHtmlElement", WootzJs.Web.IHtmlElement, System.Object, $arrayinit([], System.Type), $arrayinit([], System.Reflection.FieldInfo), $arrayinit([], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Web.IHtmlElement.prototype.$ctor, $arrayinit([], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {};
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
}).call(null, WootzJs.Web.IHtmlElement, WootzJs.Web.IHtmlElement.prototype);
$WootzJs$Web$AssemblyTypes.push(WootzJs.Web.IHtmlElement);
WootzJs.Web.PopStateEventHandler = $define("WootzJs.Web.PopStateEventHandler", System.MulticastDelegate);
(WootzJs.Web.PopStateEventHandler.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Web$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.MulticastDelegate;
    $p.$typeName = "WootzJs.Web.PopStateEventHandler";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("PopStateEventHandler", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Web.PopStateEventHandler", WootzJs.Web.PopStateEventHandler, System.MulticastDelegate, $arrayinit([], System.Type), $arrayinit([], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("BeginInvoke", WootzJs.Web.PopStateEventHandler.prototype.BeginInvoke, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("evt", Event, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("callback", System.AsyncCallback, 1, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("object", System.Object, 2, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.IAsyncResult, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("EndInvoke", WootzJs.Web.PopStateEventHandler.prototype.EndInvoke, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("result", System.IAsyncResult, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Invoke", WootzJs.Web.PopStateEventHandler.prototype.Invoke, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("evt", Event, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Web.PopStateEventHandler.prototype.$ctor, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("object", System.Object, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("method", System.IntPtr, 1, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {};
}).call(null, WootzJs.Web.PopStateEventHandler, WootzJs.Web.PopStateEventHandler.prototype);
$WootzJs$Web$AssemblyTypes.push(WootzJs.Web.PopStateEventHandler);
