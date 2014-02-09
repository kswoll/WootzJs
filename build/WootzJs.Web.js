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
WootzJs.Web.Attr = $define("WootzJs.Web.Attr", System.Object);
(WootzJs.Web.Attr.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Web$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Web.Attr";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("Attr", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Web.Attr", WootzJs.Web.Attr, System.Object, $arrayinit([], System.Type), $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("idId", System.Boolean, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().InitOnly, null, $arrayinit([(function() {var $obj$ = System.Runtime.WootzJs.JsAttribute.prototype.$ctor.$new();$obj$.set_Name("idId");return $obj$;}).call(this)], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("name", String, System.Reflection.FieldAttributes().Public, null, $arrayinit([(function() {var $obj$ = System.Runtime.WootzJs.JsAttribute.prototype.$ctor.$new();$obj$.set_Name("name");return $obj$;}).call(this)], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("value", String, System.Reflection.FieldAttributes().Public, null, $arrayinit([(function() {var $obj$ = System.Runtime.WootzJs.JsAttribute.prototype.$ctor.$new();$obj$.set_Name("value");return $obj$;}).call(this)], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Web.Attr.prototype.$ctor, $arrayinit([], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {};
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.idId = false;
    $p.name = null;
    $p.value = null;
}).call(null, WootzJs.Web.Attr, WootzJs.Web.Attr.prototype);
$WootzJs$Web$AssemblyTypes.push(WootzJs.Web.Attr);
WootzJs.Web.Browser = $define("WootzJs.Web.Browser", System.Object);
(WootzJs.Web.Browser.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Web$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Web.Browser";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("Browser", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Web.Browser", WootzJs.Web.Browser, System.Object, $arrayinit([], System.Type), $arrayinit([], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("get_Window", WootzJs.Web.Browser.prototype.get_Window, $arrayinit([], System.Reflection.ParameterInfo), window, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_Document", WootzJs.Web.Browser.prototype.get_Document, $arrayinit([], System.Reflection.ParameterInfo), document, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Web.Browser.prototype.$ctor, $arrayinit([], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.PropertyInfo.prototype.$ctor.$new("Window", window, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Window", WootzJs.Web.Browser.prototype.get_Window, $arrayinit([], System.Reflection.ParameterInfo), window, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute)), null, $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("Document", document, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Document", WootzJs.Web.Browser.prototype.get_Document, $arrayinit([], System.Reflection.ParameterInfo), document, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute)), null, $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute))], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {};
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $t.get_Window = function() {
        return window;
    };
    $t.get_Document = function() {
        return document;
    };
}).call(null, WootzJs.Web.Browser, WootzJs.Web.Browser.prototype);
$WootzJs$Web$AssemblyTypes.push(WootzJs.Web.Browser);
WootzJs.Web.DocumentExtensions = $define("WootzJs.Web.DocumentExtensions", System.Object);
(WootzJs.Web.DocumentExtensions.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Web$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Web.DocumentExtensions";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("DocumentExtensions", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Web.DocumentExtensions", WootzJs.Web.DocumentExtensions, System.Object, $arrayinit([], System.Type), $arrayinit([], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("GetElementByTagName", WootzJs.Web.DocumentExtensions.prototype.GetElementByTagName, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("document", document, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("tagName", String, 1, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), Element, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("CreateCustomEvent", WootzJs.Web.DocumentExtensions.prototype.CreateCustomEvent, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("document", document, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("eventType", String, 1, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("args", System.Object, 2, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), Event, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {};
    $t.GetElementByTagName = function(document, tagName) {
        var result = document.getElementsByTagName(tagName);
        return result.length > 0 ? result.item(0) : null;
    };
    $t.CreateCustomEvent = function(document, eventType, args) {
        try {
            return new CustomEvent(eventType, args);
        }
        catch (e) {
            var evt = document.createEvent("CustomEvent");
            evt.initCustomEvent(
                eventType, 
                false, 
                true, 
                args
            );
            return evt;
        }
    };
}).call(null, WootzJs.Web.DocumentExtensions, WootzJs.Web.DocumentExtensions.prototype);
$WootzJs$Web$AssemblyTypes.push(WootzJs.Web.DocumentExtensions);
WootzJs.Web.ElementExtensions = $define("WootzJs.Web.ElementExtensions", System.Object);
(WootzJs.Web.ElementExtensions.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Web$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Web.ElementExtensions";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("ElementExtensions", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Web.ElementExtensions", WootzJs.Web.ElementExtensions, System.Object, $arrayinit([], System.Type), $arrayinit([], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("IsDescendentOf", WootzJs.Web.ElementExtensions.prototype.IsDescendentOf, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("descendent", Element, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("ancestor", Element, 1, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Boolean, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("IsAncestorOf", WootzJs.Web.ElementExtensions.prototype.IsAncestorOf, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("ancestor", Element, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("descendent", Element, 1, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Boolean, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Clear", WootzJs.Web.ElementExtensions.prototype.Clear, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("parent", Element, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("IsAttachedToDom", WootzJs.Web.ElementExtensions.prototype.IsAttachedToDom, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("element", Element, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Boolean, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {};
    $t.IsDescendentOf = function(descendent, ancestor) {
        return ancestor.contains(descendent);
    };
    $t.IsAncestorOf = function(ancestor, descendent) {
        return ancestor.contains(descendent);
    };
    $t.Clear = function(parent) {
        parent.innerHTML = "";
    };
    $t.IsAttachedToDom = function(element) {
        var current = element;
        while (current.parentElement != null) {
            current = current.parentElement;
        }
        return current == WootzJs.Web.Browser().get_Document().body.parentElement;
    };
}).call(null, WootzJs.Web.ElementExtensions, WootzJs.Web.ElementExtensions.prototype);
$WootzJs$Web$AssemblyTypes.push(WootzJs.Web.ElementExtensions);
WootzJs.Web.IChildNode = $define("WootzJs.Web.IChildNode", System.Object);
(WootzJs.Web.IChildNode.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Web$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Web.IChildNode";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("IChildNode", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Web.IChildNode", WootzJs.Web.IChildNode, null, $arrayinit([], System.Type), $arrayinit([], System.Reflection.FieldInfo), $arrayinit([], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {};
}).call(null, WootzJs.Web.IChildNode, WootzJs.Web.IChildNode.prototype);
$WootzJs$Web$AssemblyTypes.push(WootzJs.Web.IChildNode);
WootzJs.Web.IParentNode = $define("WootzJs.Web.IParentNode", System.Object);
(WootzJs.Web.IParentNode.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Web$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Web.IParentNode";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("IParentNode", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Web.IParentNode", WootzJs.Web.IParentNode, null, $arrayinit([], System.Type), $arrayinit([], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("WootzJs$Web$IParentNode$get_ChildElementCount", WootzJs.Web.IParentNode.prototype.WootzJs$Web$IParentNode$get_ChildElementCount, $arrayinit([], System.Reflection.ParameterInfo), System.Int32, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("WootzJs$Web$IParentNode$get_Children", WootzJs.Web.IParentNode.prototype.WootzJs$Web$IParentNode$get_Children, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Web.HtmlCollection, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("WootzJs$Web$IParentNode$get_FirstElementChild", WootzJs.Web.IParentNode.prototype.WootzJs$Web$IParentNode$get_FirstElementChild, $arrayinit([], System.Reflection.ParameterInfo), Node, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("WootzJs$Web$IParentNode$get_LastElementChild", WootzJs.Web.IParentNode.prototype.WootzJs$Web$IParentNode$get_LastElementChild, $arrayinit([], System.Reflection.ParameterInfo), Node, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.MethodInfo), $arrayinit([System.Reflection.PropertyInfo.prototype.$ctor.$new("ChildElementCount", System.Int32, System.Reflection.MethodInfo.prototype.$ctor.$new("WootzJs$Web$IParentNode$get_ChildElementCount", WootzJs.Web.IParentNode.prototype.WootzJs$Web$IParentNode$get_ChildElementCount, $arrayinit([], System.Reflection.ParameterInfo), System.Int32, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), null, $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([(function() {var $obj$ = System.Runtime.WootzJs.JsAttribute.prototype.$ctor.$new();$obj$.set_Name("childElementCount");return $obj$;}).call(this)], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("Children", WootzJs.Web.HtmlCollection, System.Reflection.MethodInfo.prototype.$ctor.$new("WootzJs$Web$IParentNode$get_Children", WootzJs.Web.IParentNode.prototype.WootzJs$Web$IParentNode$get_Children, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Web.HtmlCollection, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), null, $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([(function() {var $obj$ = System.Runtime.WootzJs.JsAttribute.prototype.$ctor.$new();$obj$.set_Name("collection");return $obj$;}).call(this)], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("FirstElementChild", Node, System.Reflection.MethodInfo.prototype.$ctor.$new("WootzJs$Web$IParentNode$get_FirstElementChild", WootzJs.Web.IParentNode.prototype.WootzJs$Web$IParentNode$get_FirstElementChild, $arrayinit([], System.Reflection.ParameterInfo), Node, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), null, $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([(function() {var $obj$ = System.Runtime.WootzJs.JsAttribute.prototype.$ctor.$new();$obj$.set_Name("firstElementChild");return $obj$;}).call(this)], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("LastElementChild", Node, System.Reflection.MethodInfo.prototype.$ctor.$new("WootzJs$Web$IParentNode$get_LastElementChild", WootzJs.Web.IParentNode.prototype.WootzJs$Web$IParentNode$get_LastElementChild, $arrayinit([], System.Reflection.ParameterInfo), Node, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), null, $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([(function() {var $obj$ = System.Runtime.WootzJs.JsAttribute.prototype.$ctor.$new();$obj$.set_Name("lastElementChild");return $obj$;}).call(this)], System.Attribute))], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {};
    $p.WootzJs$Web$IParentNode$get_ChildElementCount = function() {};
    $p.WootzJs$Web$IParentNode$get_Children = function() {};
    $p.WootzJs$Web$IParentNode$get_FirstElementChild = function() {};
    $p.WootzJs$Web$IParentNode$get_LastElementChild = function() {};
}).call(null, WootzJs.Web.IParentNode, WootzJs.Web.IParentNode.prototype);
$WootzJs$Web$AssemblyTypes.push(WootzJs.Web.IParentNode);
WootzJs.Web.NodeExtensions = $define("WootzJs.Web.NodeExtensions", System.Object);
(WootzJs.Web.NodeExtensions.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Web$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Web.NodeExtensions";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("NodeExtensions", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Web.NodeExtensions", WootzJs.Web.NodeExtensions, System.Object, $arrayinit([], System.Type), $arrayinit([], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("Prepend", WootzJs.Web.NodeExtensions.prototype.Prepend, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("node", Node, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("child", Node, 1, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("InsertBefore", WootzJs.Web.NodeExtensions.prototype.InsertBefore, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("child", Node, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("referenceNode", Node, 1, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("InsertAfter", WootzJs.Web.NodeExtensions.prototype.InsertAfter, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("child", Node, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("referenceNode", Node, 1, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("InsertAfter$1", WootzJs.Web.NodeExtensions.prototype.InsertAfter$1, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("parent", Node, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("child", Node, 1, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("referenceNode", Node, 2, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Remove", WootzJs.Web.NodeExtensions.prototype.Remove, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("node", Node, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {};
    $t.Prepend = function(node, child) {
        node.insertBefore(child, node.firstChild);
    };
    $t.InsertBefore = function(child, referenceNode) {
        referenceNode.parentNode.insertBefore(child, referenceNode);
    };
    $t.InsertAfter = function(child, referenceNode) {
        WootzJs.Web.NodeExtensions.InsertAfter$1(referenceNode.parentNode, child, referenceNode);
    };
    $t.InsertAfter$1 = function(parent, child, referenceNode) {
        var nextReferenceNode = referenceNode.nextSibling;
        if (nextReferenceNode == null)
            parent.appendChild(child);
        else
            parent.insertBefore(child, nextReferenceNode);
    };
    $t.Remove = function(node) {
        node.parentNode.removeChild(node);
    };
}).call(null, WootzJs.Web.NodeExtensions, WootzJs.Web.NodeExtensions.prototype);
$WootzJs$Web$AssemblyTypes.push(WootzJs.Web.NodeExtensions);
WootzJs.Web.NodeType = $define("WootzJs.Web.NodeType", System.Enum);
(WootzJs.Web.NodeType.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Web$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Enum;
    $p.$typeName = "WootzJs.Web.NodeType";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("NodeType", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Web.NodeType", WootzJs.Web.NodeType, System.Enum, $arrayinit([], System.Type), $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("ElementType", WootzJs.Web.NodeType, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().Literal, 1, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("AttributeNode", WootzJs.Web.NodeType, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().Literal, 2, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("TextNode", WootzJs.Web.NodeType, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().Literal, 3, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("CDataSectionNode", WootzJs.Web.NodeType, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().Literal, 4, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("EntityReferenceNode", WootzJs.Web.NodeType, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().Literal, 5, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("EntityNode", WootzJs.Web.NodeType, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().Literal, 6, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("ProcessingInstructionNode", WootzJs.Web.NodeType, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().Literal, 7, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("CommentNode", WootzJs.Web.NodeType, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().Literal, 8, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("DocumentNode", WootzJs.Web.NodeType, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().Literal, 9, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("DocumentTypeNode", WootzJs.Web.NodeType, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().Literal, 10, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("DocumentFragmentNode", WootzJs.Web.NodeType, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().Literal, 11, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("NotationNode", WootzJs.Web.NodeType, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().Literal, 12, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Web.NodeType.prototype.$ctor, $arrayinit([], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), true);return this.$type;};
    $t.$StaticInitializer = function() {
        $t.ElementType = 1;
        $t.ElementType$ = $p.$ctor.$new("ElementType", WootzJs.Web.NodeType().ElementType);
        $t.AttributeNode = 2;
        $t.AttributeNode$ = $p.$ctor.$new("AttributeNode", WootzJs.Web.NodeType().AttributeNode);
        $t.TextNode = 3;
        $t.TextNode$ = $p.$ctor.$new("TextNode", WootzJs.Web.NodeType().TextNode);
        $t.CDataSectionNode = 4;
        $t.CDataSectionNode$ = $p.$ctor.$new("CDataSectionNode", WootzJs.Web.NodeType().CDataSectionNode);
        $t.EntityReferenceNode = 5;
        $t.EntityReferenceNode$ = $p.$ctor.$new("EntityReferenceNode", WootzJs.Web.NodeType().EntityReferenceNode);
        $t.EntityNode = 6;
        $t.EntityNode$ = $p.$ctor.$new("EntityNode", WootzJs.Web.NodeType().EntityNode);
        $t.ProcessingInstructionNode = 7;
        $t.ProcessingInstructionNode$ = $p.$ctor.$new("ProcessingInstructionNode", WootzJs.Web.NodeType().ProcessingInstructionNode);
        $t.CommentNode = 8;
        $t.CommentNode$ = $p.$ctor.$new("CommentNode", WootzJs.Web.NodeType().CommentNode);
        $t.DocumentNode = 9;
        $t.DocumentNode$ = $p.$ctor.$new("DocumentNode", WootzJs.Web.NodeType().DocumentNode);
        $t.DocumentTypeNode = 10;
        $t.DocumentTypeNode$ = $p.$ctor.$new("DocumentTypeNode", WootzJs.Web.NodeType().DocumentTypeNode);
        $t.DocumentFragmentNode = 11;
        $t.DocumentFragmentNode$ = $p.$ctor.$new("DocumentFragmentNode", WootzJs.Web.NodeType().DocumentFragmentNode);
        $t.NotationNode = 12;
        $t.NotationNode$ = $p.$ctor.$new("NotationNode", WootzJs.Web.NodeType().NotationNode);
    };
    $p.$ctor = function(name, value) {
        System.Enum.prototype.$ctor.call(this, name, value);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function(name, value) {
        return new $p.$ctor.$type(this, name, value);
    };
}).call(null, WootzJs.Web.NodeType, WootzJs.Web.NodeType.prototype);
$WootzJs$Web$AssemblyTypes.push(WootzJs.Web.NodeType);
(Event.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Web$GetAssembly;
    $p.$type = $t;
    $t.$baseType = Event;
    $p.$typeName = "WootzJs.Web.PopStateEvent";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("PopStateEvent", $arrayinit([(function() {var $obj$ = System.Runtime.WootzJs.JsAttribute.prototype.$ctor.$new();$obj$.set_Name("Event");$obj$.set_BuiltIn(true);return $obj$;}).call(this)], System.Attribute));this.$type.Init("Event", Event, Event, $arrayinit([], System.Type), $arrayinit([], System.Reflection.FieldInfo), $arrayinit([], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", Event.prototype.$ctor, $arrayinit([], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {};
    $p.$ctor = function() {
        Event.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type();
    };
}).call(null, Event, Event.prototype);
$WootzJs$Web$AssemblyTypes.push(Event);
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
WootzJs.Web.StyleSheet = $define("WootzJs.Web.StyleSheet", System.Object);
(WootzJs.Web.StyleSheet.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Web$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Web.StyleSheet";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("StyleSheet", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Web.StyleSheet", WootzJs.Web.StyleSheet, System.Object, $arrayinit([], System.Type), $arrayinit([], System.Reflection.FieldInfo), $arrayinit([], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Web.StyleSheet.prototype.$ctor, $arrayinit([], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {};
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
}).call(null, WootzJs.Web.StyleSheet, WootzJs.Web.StyleSheet.prototype);
$WootzJs$Web$AssemblyTypes.push(WootzJs.Web.StyleSheet);
