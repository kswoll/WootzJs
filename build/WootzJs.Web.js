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
WootzJs.Web.Event = $define("WootzJs.Web.Event", System.Object);
(WootzJs.Web.Event.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Web$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Web.Event";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("Event", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Web.Event", WootzJs.Web.Event, System.Object, $arrayinit([], System.Type), $arrayinit([], System.Reflection.FieldInfo), $arrayinit([], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Web.Event.prototype.$ctor, $arrayinit([], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {};
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
}).call(null, WootzJs.Web.Event, WootzJs.Web.Event.prototype);
$WootzJs$Web$AssemblyTypes.push(WootzJs.Web.Event);
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
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("IParentNode", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Web.IParentNode", WootzJs.Web.IParentNode, null, $arrayinit([], System.Type), $arrayinit([], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("WootzJs$Web$IParentNode$get_ChildElementCount", WootzJs.Web.IParentNode.prototype.WootzJs$Web$IParentNode$get_ChildElementCount, $arrayinit([], System.Reflection.ParameterInfo), System.Int32, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("WootzJs$Web$IParentNode$get_Children", WootzJs.Web.IParentNode.prototype.WootzJs$Web$IParentNode$get_Children, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Web.HtmlCollection, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("WootzJs$Web$IParentNode$get_FirstElementChild", WootzJs.Web.IParentNode.prototype.WootzJs$Web$IParentNode$get_FirstElementChild, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Web.Node, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("WootzJs$Web$IParentNode$get_LastElementChild", WootzJs.Web.IParentNode.prototype.WootzJs$Web$IParentNode$get_LastElementChild, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Web.Node, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.MethodInfo), $arrayinit([System.Reflection.PropertyInfo.prototype.$ctor.$new("ChildElementCount", System.Int32, System.Reflection.MethodInfo.prototype.$ctor.$new("WootzJs$Web$IParentNode$get_ChildElementCount", WootzJs.Web.IParentNode.prototype.WootzJs$Web$IParentNode$get_ChildElementCount, $arrayinit([], System.Reflection.ParameterInfo), System.Int32, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), null, $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([(function() {var $obj$ = System.Runtime.WootzJs.JsAttribute.prototype.$ctor.$new();$obj$.set_Name("childElementCount");return $obj$;}).call(this)], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("Children", WootzJs.Web.HtmlCollection, System.Reflection.MethodInfo.prototype.$ctor.$new("WootzJs$Web$IParentNode$get_Children", WootzJs.Web.IParentNode.prototype.WootzJs$Web$IParentNode$get_Children, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Web.HtmlCollection, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), null, $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([(function() {var $obj$ = System.Runtime.WootzJs.JsAttribute.prototype.$ctor.$new();$obj$.set_Name("collection");return $obj$;}).call(this)], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("FirstElementChild", WootzJs.Web.Node, System.Reflection.MethodInfo.prototype.$ctor.$new("WootzJs$Web$IParentNode$get_FirstElementChild", WootzJs.Web.IParentNode.prototype.WootzJs$Web$IParentNode$get_FirstElementChild, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Web.Node, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), null, $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([(function() {var $obj$ = System.Runtime.WootzJs.JsAttribute.prototype.$ctor.$new();$obj$.set_Name("firstElementChild");return $obj$;}).call(this)], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("LastElementChild", WootzJs.Web.Node, System.Reflection.MethodInfo.prototype.$ctor.$new("WootzJs$Web$IParentNode$get_LastElementChild", WootzJs.Web.IParentNode.prototype.WootzJs$Web$IParentNode$get_LastElementChild, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Web.Node, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), null, $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([(function() {var $obj$ = System.Runtime.WootzJs.JsAttribute.prototype.$ctor.$new();$obj$.set_Name("lastElementChild");return $obj$;}).call(this)], System.Attribute))], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {};
    $p.WootzJs$Web$IParentNode$get_ChildElementCount = function() {};
    $p.WootzJs$Web$IParentNode$get_Children = function() {};
    $p.WootzJs$Web$IParentNode$get_FirstElementChild = function() {};
    $p.WootzJs$Web$IParentNode$get_LastElementChild = function() {};
}).call(null, WootzJs.Web.IParentNode, WootzJs.Web.IParentNode.prototype);
$WootzJs$Web$AssemblyTypes.push(WootzJs.Web.IParentNode);
WootzJs.Web.MouseEvent = $define("WootzJs.Web.MouseEvent", WootzJs.Web.Event);
(WootzJs.Web.MouseEvent.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Web$GetAssembly;
    $p.$type = $t;
    $t.$baseType = WootzJs.Web.Event;
    $p.$typeName = "WootzJs.Web.MouseEvent";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("MouseEvent", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Web.MouseEvent", WootzJs.Web.MouseEvent, WootzJs.Web.Event, $arrayinit([], System.Type), $arrayinit([], System.Reflection.FieldInfo), $arrayinit([], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Web.MouseEvent.prototype.$ctor, $arrayinit([], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {};
    $p.$ctor = function() {
        WootzJs.Web.Event.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
}).call(null, WootzJs.Web.MouseEvent, WootzJs.Web.MouseEvent.prototype);
$WootzJs$Web$AssemblyTypes.push(WootzJs.Web.MouseEvent);
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
    $t.$baseType = WootzJs.Web.Event;
    $p.$typeName = "WootzJs.Web.PopStateEvent";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("PopStateEvent", $arrayinit([(function() {var $obj$ = System.Runtime.WootzJs.JsAttribute.prototype.$ctor.$new();$obj$.set_Name("Event");$obj$.set_BuiltIn(true);return $obj$;}).call(this)], System.Attribute));this.$type.Init("Event", Event, WootzJs.Web.Event, $arrayinit([], System.Type), $arrayinit([], System.Reflection.FieldInfo), $arrayinit([], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", Event.prototype.$ctor, $arrayinit([], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {};
    $p.$ctor = function() {
        WootzJs.Web.Event.prototype.$ctor.call(this);
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
