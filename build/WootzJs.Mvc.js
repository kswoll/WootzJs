"use strict";
var $WootzJs$Mvc$Assembly = null;
var $WootzJs$Mvc$AssemblyTypes = [];
window.$WootzJs$Mvc$GetAssembly = function() {
    if ($WootzJs$Mvc$Assembly == null)
        $WootzJs$Mvc$Assembly = System.Reflection.Assembly.prototype.$ctor.$new("WootzJs.Mvc", $WootzJs$Mvc$AssemblyTypes, $arrayinit([
            System.Reflection.AssemblyTitleAttribute.prototype.$ctor.$new("WootzJs.Mvc"), 
            System.Reflection.AssemblyDescriptionAttribute.prototype.$ctor.$new(""), 
            System.Reflection.AssemblyConfigurationAttribute.prototype.$ctor.$new(""), 
            System.Reflection.AssemblyCompanyAttribute.prototype.$ctor.$new(""), 
            System.Reflection.AssemblyProductAttribute.prototype.$ctor.$new("WootzJs.Mvc"), 
            System.Reflection.AssemblyCopyrightAttribute.prototype.$ctor.$new("Copyright ©  2014"), 
            System.Reflection.AssemblyTrademarkAttribute.prototype.$ctor.$new(""), 
            System.Reflection.AssemblyCultureAttribute.prototype.$ctor.$new(""), 
            System.Runtime.InteropServices.ComVisibleAttribute.prototype.$ctor.$new(false), 
            System.Runtime.InteropServices.GuidAttribute.prototype.$ctor.$new("22a7431a-fb4e-4810-bdf9-afd3c516cd9b"), 
            System.Reflection.AssemblyVersionAttribute.prototype.$ctor.$new("1.0.0.0"), 
            System.Reflection.AssemblyFileVersionAttribute.prototype.$ctor.$new("1.0.0.0")
        ], System.Attribute));
    return $WootzJs$Mvc$Assembly;
};
$assemblies.push(window.$WootzJs$Mvc$GetAssembly);
window.WootzJs = window.WootzJs || {};
WootzJs.Mvc = WootzJs.Mvc || {};
WootzJs.Mvc.ExpressionTrees = WootzJs.Mvc.ExpressionTrees || {};
WootzJs.Mvc.Mvc = WootzJs.Mvc.Mvc || {};
WootzJs.Mvc.Mvc.Routes = WootzJs.Mvc.Mvc.Routes || {};
WootzJs.Mvc.Mvc.Views = WootzJs.Mvc.Mvc.Views || {};
WootzJs.Mvc.Mvc.Views.Css = WootzJs.Mvc.Mvc.Views.Css || {};
WootzJs.Mvc.Mvc.Views.Control = $define("WootzJs.Mvc.Mvc.Views.Control", System.Object);
(WootzJs.Mvc.Mvc.Views.Control.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Mvc$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Mvc.Mvc.Views.Control";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("Control", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Mvc.Mvc.Views.Control", WootzJs.Mvc.Mvc.Views.Control, System.Object, $arrayinit([], System.Type), $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("$Parent$k__BackingField", WootzJs.Mvc.Mvc.Views.Control, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("$View$k__BackingField", WootzJs.Mvc.Mvc.Views.View, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("$TagName$k__BackingField", String, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("children", System.Collections.Generic.List$1, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("style", WootzJs.Mvc.Mvc.Views.Css.Style, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("click", System.Collections.Generic.List$1, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("mouseEnter", System.Collections.Generic.List$1, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("mouseLeave", System.Collections.Generic.List$1, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("$cctor", WootzJs.Mvc.Mvc.Views.Control.prototype.$cctor, $arrayinit([], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Private | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_Parent", WootzJs.Mvc.Mvc.Views.Control.prototype.get_Parent, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Control, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Parent", WootzJs.Mvc.Mvc.Views.Control.prototype.set_Parent, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Control, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Private, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_View", WootzJs.Mvc.Mvc.Views.Control.prototype.get_View, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.View, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_View", WootzJs.Mvc.Mvc.Views.Control.prototype.set_View, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.View, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Assembly, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_TagName", WootzJs.Mvc.Mvc.Views.Control.prototype.get_TagName, $arrayinit([], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Family, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_TagName", WootzJs.Mvc.Mvc.Views.Control.prototype.set_TagName, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", String, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Family, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_ViewContext", WootzJs.Mvc.Mvc.Views.Control.prototype.get_ViewContext, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.ViewContext, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_Style", WootzJs.Mvc.Mvc.Views.Control.prototype.get_Style, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Css.Style, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Style", WootzJs.Mvc.Mvc.Views.Control.prototype.set_Style, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Css.Style, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_Node", WootzJs.Mvc.Mvc.Views.Control.prototype.get_Node, $arrayinit([], System.Reflection.ParameterInfo), Element, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Node", WootzJs.Mvc.Mvc.Views.Control.prototype.set_Node, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", Element, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Private, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("GetControlForElement", WootzJs.Mvc.Mvc.Views.Control.prototype.GetControlForElement, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("element", Element, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Control, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("CreateNode", WootzJs.Mvc.Mvc.Views.Control.prototype.CreateNode, $arrayinit([], System.Reflection.ParameterInfo), Element, System.Reflection.MethodAttributes().Family, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("EnsureNodeExists", WootzJs.Mvc.Mvc.Views.Control.prototype.EnsureNodeExists, $arrayinit([], System.Reflection.ParameterInfo), Element, System.Reflection.MethodAttributes().Family, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Add", WootzJs.Mvc.Mvc.Views.Control.prototype.Add, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("child", WootzJs.Mvc.Mvc.Views.Control, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Family, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Remove", WootzJs.Mvc.Mvc.Views.Control.prototype.Remove, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("child", WootzJs.Mvc.Mvc.Views.Control, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Family, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_Count", WootzJs.Mvc.Mvc.Views.Control.prototype.get_Count, $arrayinit([], System.Reflection.ParameterInfo), System.Int32, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_Children", WootzJs.Mvc.Mvc.Views.Control.prototype.get_Children, $arrayinit([], System.Reflection.ParameterInfo), System.Collections.Generic.IEnumerable$1, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("OnAdded", WootzJs.Mvc.Mvc.Views.Control.prototype.OnAdded, $arrayinit([], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Family, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("OnRemoved", WootzJs.Mvc.Mvc.Views.Control.prototype.OnRemoved, $arrayinit([], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Family, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Click", WootzJs.Mvc.Mvc.Views.Control.prototype.Click, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("handler", System.Action, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("UnClick", WootzJs.Mvc.Mvc.Views.Control.prototype.UnClick, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("handler", System.Action, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("MouseEnter", WootzJs.Mvc.Mvc.Views.Control.prototype.MouseEnter, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("handler", System.Action, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("UnMouseEnter", WootzJs.Mvc.Mvc.Views.Control.prototype.UnMouseEnter, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("handler", System.Action, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("MouseLeave", WootzJs.Mvc.Mvc.Views.Control.prototype.MouseLeave, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("handler", System.Action, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("UnMouseLeave", WootzJs.Mvc.Mvc.Views.Control.prototype.UnMouseLeave, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("handler", System.Action, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("OnJsClick", WootzJs.Mvc.Mvc.Views.Control.prototype.OnJsClick, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("evt", Event, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Private, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("OnJsMouseEnter", WootzJs.Mvc.Mvc.Views.Control.prototype.OnJsMouseEnter, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("evt", Event, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Private, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("OnJsMouseLeave", WootzJs.Mvc.Mvc.Views.Control.prototype.OnJsMouseLeave, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("evt", Event, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Private, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("OnClick", WootzJs.Mvc.Mvc.Views.Control.prototype.OnClick, $arrayinit([], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Family, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("OnMouseEnter", WootzJs.Mvc.Mvc.Views.Control.prototype.OnMouseEnter, $arrayinit([], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Family, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("OnMouseLeave", WootzJs.Mvc.Mvc.Views.Control.prototype.OnMouseLeave, $arrayinit([], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Family, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("op_Implicit", WootzJs.Mvc.Mvc.Views.Control.prototype.op_Implicit, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("text", String, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Control, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Mvc.Mvc.Views.Control.prototype.$ctor, $arrayinit([], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor$1", WootzJs.Mvc.Mvc.Views.Control.prototype.$ctor$1, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("node", Element, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.PropertyInfo.prototype.$ctor.$new("Parent", WootzJs.Mvc.Mvc.Views.Control, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Parent", WootzJs.Mvc.Mvc.Views.Control.prototype.get_Parent, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Control, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Parent", WootzJs.Mvc.Mvc.Views.Control.prototype.set_Parent, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Control, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Private, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("View", WootzJs.Mvc.Mvc.Views.View, System.Reflection.MethodInfo.prototype.$ctor.$new("get_View", WootzJs.Mvc.Mvc.Views.Control.prototype.get_View, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.View, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_View", WootzJs.Mvc.Mvc.Views.Control.prototype.set_View, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.View, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Assembly, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("TagName", String, System.Reflection.MethodInfo.prototype.$ctor.$new("get_TagName", WootzJs.Mvc.Mvc.Views.Control.prototype.get_TagName, $arrayinit([], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Family, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_TagName", WootzJs.Mvc.Mvc.Views.Control.prototype.set_TagName, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", String, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Family, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("ViewContext", WootzJs.Mvc.Mvc.ViewContext, System.Reflection.MethodInfo.prototype.$ctor.$new("get_ViewContext", WootzJs.Mvc.Mvc.Views.Control.prototype.get_ViewContext, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.ViewContext, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), null, $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("Style", WootzJs.Mvc.Mvc.Views.Css.Style, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Style", WootzJs.Mvc.Mvc.Views.Control.prototype.get_Style, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Css.Style, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Style", WootzJs.Mvc.Mvc.Views.Control.prototype.set_Style, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Css.Style, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("Node", Element, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Node", WootzJs.Mvc.Mvc.Views.Control.prototype.get_Node, $arrayinit([], System.Reflection.ParameterInfo), Element, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Node", WootzJs.Mvc.Mvc.Views.Control.prototype.set_Node, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", Element, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Private, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("Count", System.Int32, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Count", WootzJs.Mvc.Mvc.Views.Control.prototype.get_Count, $arrayinit([], System.Reflection.ParameterInfo), System.Int32, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), null, $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("Children", System.Collections.Generic.IEnumerable$1, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Children", WootzJs.Mvc.Mvc.Views.Control.prototype.get_Children, $arrayinit([], System.Reflection.ParameterInfo), System.Collections.Generic.IEnumerable$1, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), null, $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute))], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {
        WootzJs.Mvc.Mvc.Views.MouseTrackingEngine.prototype.$ctor.$new().Initialize();
    };
    $p.$cctor = function() {
        System.Object.prototype.$ctor.call(this);
        this.children = System.Collections.Generic.List$1$(WootzJs.Mvc.Mvc.Views.Control).prototype.$ctor.$new();
        WootzJs.Mvc.Mvc.Views.MouseTrackingEngine.prototype.$ctor.$new().Initialize();
    };
    $p.$cctor.$type = $t;
    $p.$cctor.$new = function() {
        return new $p.$cctor.$type(this);
    };
    $p.$Parent$k__BackingField = null;
    $p.get_Parent = function() {return this.$Parent$k__BackingField;};
    $p.set_Parent = function(value) {this.$Parent$k__BackingField = value;};
    $p.$View$k__BackingField = null;
    $p.get_View = function() {return this.$View$k__BackingField;};
    $p.set_View = function(value) {this.$View$k__BackingField = value;};
    $p.$TagName$k__BackingField = null;
    $p.get_TagName = function() {return this.$TagName$k__BackingField;};
    $p.set_TagName = function(value) {this.$TagName$k__BackingField = value;};
    $p.node = null;
    $p.children = null;
    $p.style = null;
    $p.click = null;
    $p.mouseEnter = null;
    $p.mouseLeave = null;
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
        this.children = System.Collections.Generic.List$1$(WootzJs.Mvc.Mvc.Views.Control).prototype.$ctor.$new();
        this.set_TagName("div");
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.$ctor$1 = function(node) {
        System.Object.prototype.$ctor.call(this);
        this.children = System.Collections.Generic.List$1$(WootzJs.Mvc.Mvc.Views.Control).prototype.$ctor.$new();
        this.set_Node(node);
    };
    $p.$ctor$1.$type = $t;
    $p.$ctor$1.$new = function(node) {
        return new $p.$ctor$1.$type(this, node);
    };
    $p.get_ViewContext = function() {
        if (this.get_View() != null)
            return this.get_View().get_ViewContext();
        else
            if (this.get_Parent() != null)
                return this.get_Parent().get_ViewContext();
            else
                return null;
    };
    $p.get_Style = function() {
        if (this.style == null)
            this.set_Style(WootzJs.Mvc.Mvc.Views.Css.Style.prototype.$ctor.$new());
        return this.style;
    };
    $p.set_Style = function(value) {
        this.style = value;
        this.style.Attach(this.get_Node().style);
    };
    $p.get_Node = function() {
        return this.EnsureNodeExists();
    };
    $p.set_Node = function(value) {
        this.node = value;
        this.node.$control = this;
    };
    $t.GetControlForElement = function(element) {
        return element.$control;
    };
    $p.CreateNode = function() {
        return WootzJs.Web.Browser().get_Document().createElement(this.get_TagName());
    };
    $p.EnsureNodeExists = function() {
        if (this.node == null) {
            this.set_Node(this.CreateNode());
            this.node.setAttribute("data-class-name", this.GetType().get_FullName());
            if (this.style != null)
                this.style.Attach(this.node.style);
        }
        return this.node;
    };
    $p.Add = function(child) {
        if (child.get_Parent() == this)
            throw System.Exception.prototype.$ctor$1.$new("The speciifed child is already present in this container").InternalInit(new Error());
        this.children.Add(child);
        child.set_Parent(this);
        this.EnsureNodeExists();
        child.OnAdded();
    };
    $p.Remove = function(child) {
        if (child.get_Parent() != this)
            throw System.Exception.prototype.$ctor$1.$new("The specified child is not contained in this container").InternalInit(new Error());
        this.children.Remove(child);
        child.set_Parent(null);
        child.OnRemoved();
    };
    $p.get_Count = function() {
        return this.children.get_Count();
    };
    $p.get_Children = function() {
        return this.children;
    };
    $p.OnAdded = function() {};
    $p.OnRemoved = function() {};
    $p.Click = function(handler) {
        if (this.click == null) {
            this.get_Node().addEventListener("click", $delegate(
                this, 
                System.Action$1$(Event), 
                this.OnJsClick, 
                "OnJsClick$delegate"
            ));
            this.click = System.Collections.Generic.List$1$(System.Action).prototype.$ctor.$new();
        }
        this.click.Add(handler);
    };
    $p.UnClick = function(handler) {
        if (this.click != null) {
            this.click.Remove(handler);
            if (!System.Linq.Enumerable.Any(System.Action, this.click)) {
                this.click = null;
                this.get_Node().removeEventListener("click", $delegate(
                    this, 
                    System.Action$1$(Event), 
                    this.OnJsClick, 
                    "OnJsClick$delegate"
                ));
            }
        }
    };
    $p.MouseEnter = function(handler) {
        if (this.mouseEnter == null) {
            this.get_Node().addEventListener("mouseentered", $delegate(
                this, 
                System.Action$1$(Event), 
                this.OnJsMouseEnter, 
                "OnJsMouseEnter$delegate"
            ));
            this.mouseEnter = System.Collections.Generic.List$1$(System.Action).prototype.$ctor.$new();
        }
        this.mouseEnter.Add(handler);
    };
    $p.UnMouseEnter = function(handler) {
        if (this.mouseEnter != null) {
            this.mouseEnter.Remove(handler);
            if (!System.Linq.Enumerable.Any(System.Action, this.mouseEnter)) {
                this.mouseEnter = null;
                this.get_Node().removeEventListener("mouseentered", $delegate(
                    this, 
                    System.Action$1$(Event), 
                    this.OnJsMouseEnter, 
                    "OnJsMouseEnter$delegate"
                ));
            }
        }
    };
    $p.MouseLeave = function(handler) {
        if (this.mouseLeave == null) {
            this.get_Node().addEventListener("mouseexited", $delegate(
                this, 
                System.Action$1$(Event), 
                this.OnJsMouseLeave, 
                "OnJsMouseLeave$delegate"
            ));
            this.mouseLeave = System.Collections.Generic.List$1$(System.Action).prototype.$ctor.$new();
        }
        this.mouseLeave.Add(handler);
    };
    $p.UnMouseLeave = function(handler) {
        if (this.mouseLeave != null) {
            this.mouseLeave.Remove(handler);
            if (!System.Linq.Enumerable.Any(System.Action, this.mouseLeave)) {
                this.mouseLeave = null;
                this.get_Node().removeEventListener("mouseexited", $delegate(
                    this, 
                    System.Action$1$(Event), 
                    this.OnJsMouseLeave, 
                    "OnJsMouseLeave$delegate"
                ));
            }
        }
    };
    $p.OnJsClick = function(evt) {
        this.OnClick();
    };
    $p.OnJsMouseEnter = function(evt) {
        this.OnMouseEnter();
    };
    $p.OnJsMouseLeave = function(evt) {
        this.OnMouseLeave();
    };
    $p.OnClick = function() {
        if (this.click != null) {
            var click = System.Linq.Enumerable.ToArray(System.Action, this.click);
            {
                var $anon$1iterator = click;
                var $anon$2enumerator = $anon$1iterator.System$Collections$IEnumerable$GetEnumerator();
                while ($anon$2enumerator.System$Collections$IEnumerator$MoveNext()) {
                    var handler = $anon$2enumerator.System$Collections$IEnumerator$get_Current();
                    handler();
                }
            }
        }
    };
    $p.OnMouseEnter = function() {
        if (this.mouseEnter != null) {
            var mouseEnter = System.Linq.Enumerable.ToArray(System.Action, this.mouseEnter);
            {
                var $anon$1iterator = mouseEnter;
                var $anon$2enumerator = $anon$1iterator.System$Collections$IEnumerable$GetEnumerator();
                while ($anon$2enumerator.System$Collections$IEnumerator$MoveNext()) {
                    var handler = $anon$2enumerator.System$Collections$IEnumerator$get_Current();
                    handler();
                }
            }
        }
    };
    $p.OnMouseLeave = function() {
        if (this.mouseLeave != null) {
            var mouseLeave = System.Linq.Enumerable.ToArray(System.Action, this.mouseLeave);
            {
                var $anon$1iterator = mouseLeave;
                var $anon$2enumerator = $anon$1iterator.System$Collections$IEnumerable$GetEnumerator();
                while ($anon$2enumerator.System$Collections$IEnumerator$MoveNext()) {
                    var handler = $anon$2enumerator.System$Collections$IEnumerator$get_Current();
                    handler();
                }
            }
        }
    };
    $t.op_Implicit = function(text) {
        return WootzJs.Mvc.Mvc.Views.Text.prototype.$ctor$1.$new(text);
    };
}).call(null, WootzJs.Mvc.Mvc.Views.Control, WootzJs.Mvc.Mvc.Views.Control.prototype);
$WootzJs$Mvc$AssemblyTypes.push(WootzJs.Mvc.Mvc.Views.Control);
WootzJs.Mvc.Mvc.Routes.RoutePart = $define("WootzJs.Mvc.Mvc.Routes.RoutePart", System.Object);
(WootzJs.Mvc.Mvc.Routes.RoutePart.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Mvc$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Mvc.Mvc.Routes.RoutePart";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("RoutePart", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Mvc.Mvc.Routes.RoutePart", WootzJs.Mvc.Mvc.Routes.RoutePart, System.Object, $arrayinit([WootzJs.Mvc.Mvc.Routes.IRoutePart], System.Type), $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("$RouteData$k__BackingField", System.Collections.Generic.IDictionary$2, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("Accept", WootzJs.Mvc.Mvc.Routes.RoutePart.prototype.Accept, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("path", WootzJs.Mvc.Mvc.Routes.RoutePath, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Boolean, System.Reflection.MethodAttributes().Family, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_RouteData", WootzJs.Mvc.Mvc.Routes.RoutePart.prototype.get_RouteData, $arrayinit([], System.Reflection.ParameterInfo), System.Collections.Generic.IDictionary$2, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_RouteData", WootzJs.Mvc.Mvc.Routes.RoutePart.prototype.set_RouteData, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Collections.Generic.IDictionary$2, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Private, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("FindDuplicate", WootzJs.Mvc.Mvc.Routes.RoutePart.prototype.FindDuplicate, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("parts", System.Collections.Generic.IEnumerable$1, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Routes.IRoutePart, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("IsDuplicate", WootzJs.Mvc.Mvc.Routes.RoutePart.prototype.IsDuplicate, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("part", WootzJs.Mvc.Mvc.Routes.IRoutePart, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Boolean, System.Reflection.MethodAttributes().Family, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_RequiredHttpMethod", WootzJs.Mvc.Mvc.Routes.RoutePart.prototype.get_RequiredHttpMethod, $arrayinit([], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_RequiredHttpMethod", WootzJs.Mvc.Mvc.Routes.RoutePart.prototype.set_RequiredHttpMethod, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", String, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("AcceptPath", WootzJs.Mvc.Mvc.Routes.RoutePart.prototype.AcceptPath, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("path", WootzJs.Mvc.Mvc.Routes.RoutePath, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("httpMethod", String, 1, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Boolean, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("ConsumePath", WootzJs.Mvc.Mvc.Routes.RoutePart.prototype.ConsumePath, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("path", WootzJs.Mvc.Mvc.Routes.RoutePath, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Family, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("ProcessData", WootzJs.Mvc.Mvc.Routes.RoutePart.prototype.ProcessData, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("path", WootzJs.Mvc.Mvc.Routes.RoutePath, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("data", WootzJs.Mvc.Mvc.Routes.RouteData, 1, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("ToString", WootzJs.Mvc.Mvc.Routes.RoutePart.prototype.ToString, $arrayinit([], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Mvc.Mvc.Routes.RoutePart.prototype.$ctor, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("routeData", System.Collections.Generic.IDictionary$2, 0, System.Reflection.ParameterAttributes().HasDefault, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Family, $arrayinit([], System.Attribute)), System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor$1", WootzJs.Mvc.Mvc.Routes.RoutePart.prototype.$ctor$1, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("key", String, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Object, 1, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Family, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.PropertyInfo.prototype.$ctor.$new("RouteData", System.Collections.Generic.IDictionary$2, System.Reflection.MethodInfo.prototype.$ctor.$new("get_RouteData", WootzJs.Mvc.Mvc.Routes.RoutePart.prototype.get_RouteData, $arrayinit([], System.Reflection.ParameterInfo), System.Collections.Generic.IDictionary$2, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_RouteData", WootzJs.Mvc.Mvc.Routes.RoutePart.prototype.set_RouteData, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Collections.Generic.IDictionary$2, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Private, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("RequiredHttpMethod", String, System.Reflection.MethodInfo.prototype.$ctor.$new("get_RequiredHttpMethod", WootzJs.Mvc.Mvc.Routes.RoutePart.prototype.get_RequiredHttpMethod, $arrayinit([], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_RequiredHttpMethod", WootzJs.Mvc.Mvc.Routes.RoutePart.prototype.set_RequiredHttpMethod, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", String, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute))], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {};
    $p.Accept = function(path) {};
    $p.$RouteData$k__BackingField = null;
    $p.get_RouteData = function() {return this.$RouteData$k__BackingField;};
    $p.set_RouteData = function(value) {this.$RouteData$k__BackingField = value;};
    $p.WootzJs$Mvc$Mvc$Routes$IRoutePart$get_RouteData = $p.get_RouteData;
    $p.$ctor = function(routeData) {
        System.Object.prototype.$ctor.call(this);
        this.set_RouteData(routeData || System.Collections.Generic.Dictionary$2$(String, System.Object).prototype.$ctor.$new());
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function(routeData) {
        return new $p.$ctor.$type(this, routeData);
    };
    $p.FindDuplicate = function(parts) {
        return System.Linq.Enumerable.FirstOrDefault$1(WootzJs.Mvc.Mvc.Routes.IRoutePart, parts, $delegate(this, System.Func$2$(WootzJs.Mvc.Mvc.Routes.IRoutePart, System.Boolean), function(x) {
            return this.IsDuplicate(x);
        }));
    };
    $p.WootzJs$Mvc$Mvc$Routes$IRoutePart$FindDuplicate = $p.FindDuplicate;
    $p.IsDuplicate = function(part) {
        var otherMethodObj;
        (function() {
            var $anon$1 = {
                value: null
            };
            var $result$ = part.WootzJs$Mvc$Mvc$Routes$IRoutePart$get_RouteData().System$Collections$Generic$IDictionary$2$TryGetValue(WootzJs.Mvc.Mvc.Routes.RouteData().RequiredHttpMethodKey, $anon$1);
            otherMethodObj = $anon$1.value;
            return $result$;
        }).call(this);
        var otherMethod = $cast(String, otherMethodObj);
        var result = (this.get_RequiredHttpMethod() == null && otherMethod == null) || this.get_RequiredHttpMethod() == otherMethod;
        return result;
    };
    $p.get_RequiredHttpMethod = function() {
        var requiredHttpMethod;
        if ((function() {
            var $anon$1 = {
                value: null
            };
            var $result$ = this.get_RouteData().System$Collections$Generic$IDictionary$2$TryGetValue(WootzJs.Mvc.Mvc.Routes.RouteData().RequiredHttpMethodKey, $anon$1);
            requiredHttpMethod = $anon$1.value;
            return $result$;
        }).call(this)) {
            return $cast(String, requiredHttpMethod);
        }
        return null;
    };
    $p.set_RequiredHttpMethod = function(value) {
        this.get_RouteData().set_Item(WootzJs.Mvc.Mvc.Routes.RouteData().RequiredHttpMethodKey, value);
    };
    $p.$ctor$1 = function(key, value) {
        WootzJs.Mvc.Mvc.Routes.RoutePart.prototype.$ctor.call(this, (function() {
            var $obj$ = System.Collections.Generic.Dictionary$2$(String, System.Object).prototype.$ctor.$new();
            $obj$.Add$1(key, value);
            return $obj$;
        }).call(this));
    };
    $p.$ctor$1.$type = $t;
    $p.$ctor$1.$new = function(key, value) {
        return new $p.$ctor$1.$type(this, key, value);
    };
    $p.AcceptPath = function(path, httpMethod) {
        var requiredHttpMethod = this.get_RequiredHttpMethod();
        if (requiredHttpMethod != null && httpMethod != $cast(String, requiredHttpMethod))
            return false;
        return this.Accept(path);
    };
    $p.WootzJs$Mvc$Mvc$Routes$IRoutePart$AcceptPath = $p.AcceptPath;
    $p.ConsumePath = function(path) {
        path.Consume();
    };
    $p.ProcessData = function(path, data) {
        this.ConsumePath(path);
        {
            var $anon$1iterator = this.get_RouteData();
            var $anon$2enumerator = $anon$1iterator.System$Collections$IEnumerable$GetEnumerator();
            while ($anon$2enumerator.System$Collections$IEnumerator$MoveNext()) {
                var item = $anon$2enumerator.System$Collections$IEnumerator$get_Current();
                data.set_Item(item.get_Key(), item.get_Value());
            }
        }
    };
    $p.WootzJs$Mvc$Mvc$Routes$IRoutePart$ProcessData = $p.ProcessData;
    $p.ToString = function() {
        return "{ " + String.Join$1(String, ", ", System.Linq.Enumerable.Select(
            System.Collections.Generic.KeyValuePair$2$(String, System.Object), 
            String, 
            this.get_RouteData(), 
            $delegate(this, System.Func$2$(System.Collections.Generic.KeyValuePair$2$(String, System.Object), String), function(x) {
                return x.get_Key() + "=" + $safeToString(x.get_Value());
            })
        )) + " }";
    };
}).call(null, WootzJs.Mvc.Mvc.Routes.RoutePart, WootzJs.Mvc.Mvc.Routes.RoutePart.prototype);
$WootzJs$Mvc$AssemblyTypes.push(WootzJs.Mvc.Mvc.Routes.RoutePart);
WootzJs.Mvc.Mvc.Views.TablePanel = $define("WootzJs.Mvc.Mvc.Views.TablePanel", WootzJs.Mvc.Mvc.Views.Control);
(WootzJs.Mvc.Mvc.Views.TablePanel.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Mvc$GetAssembly;
    $p.$type = $t;
    $t.$baseType = WootzJs.Mvc.Mvc.Views.Control;
    $p.$typeName = "WootzJs.Mvc.Mvc.Views.TablePanel";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("TablePanel", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Mvc.Mvc.Views.TablePanel", WootzJs.Mvc.Mvc.Views.TablePanel, WootzJs.Mvc.Mvc.Views.Control, $arrayinit([], System.Type), $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("columnWidths", $array(WootzJs.Mvc.Mvc.Views.TableWidth), System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("rows", System.Collections.Generic.List$1, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("cells", System.Collections.Generic.List$1, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("defaultConstraint", WootzJs.Mvc.Mvc.Views.TableConstraint, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("$CellSpacing$k__BackingField", System.Int32, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("get_CellSpacing", WootzJs.Mvc.Mvc.Views.TablePanel.prototype.get_CellSpacing, $arrayinit([], System.Reflection.ParameterInfo), System.Int32, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_CellSpacing", WootzJs.Mvc.Mvc.Views.TablePanel.prototype.set_CellSpacing, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Int32, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("CreateNode", WootzJs.Mvc.Mvc.Views.TablePanel.prototype.CreateNode, $arrayinit([], System.Reflection.ParameterInfo), Element, System.Reflection.MethodAttributes().Family, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("GetNextEmptyCell", WootzJs.Mvc.Mvc.Views.TablePanel.prototype.GetNextEmptyCell, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.TablePanel.Point, System.Reflection.MethodAttributes().Private, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Add$1", WootzJs.Mvc.Mvc.Views.TablePanel.prototype.Add$1, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("cell", WootzJs.Mvc.Mvc.Views.Control, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Add$2", WootzJs.Mvc.Mvc.Views.TablePanel.prototype.Add$2, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("cell", WootzJs.Mvc.Mvc.Views.Control, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("constraint", WootzJs.Mvc.Mvc.Views.TableConstraint, 1, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Mvc.Mvc.Views.TablePanel.prototype.$ctor, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("columnWidths", $array(WootzJs.Mvc.Mvc.Views.TableWidth), 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.PropertyInfo.prototype.$ctor.$new("CellSpacing", System.Int32, System.Reflection.MethodInfo.prototype.$ctor.$new("get_CellSpacing", WootzJs.Mvc.Mvc.Views.TablePanel.prototype.get_CellSpacing, $arrayinit([], System.Reflection.ParameterInfo), System.Int32, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_CellSpacing", WootzJs.Mvc.Mvc.Views.TablePanel.prototype.set_CellSpacing, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Int32, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute))], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {};
    $p.columnWidths = null;
    $p.rows = null;
    $p.cells = null;
    $p.defaultConstraint = null;
    $p.$ctor = function(columnWidths) {
        WootzJs.Mvc.Mvc.Views.Control.prototype.$ctor.call(this);
        this.rows = System.Collections.Generic.List$1$(Element).prototype.$ctor.$new();
        this.cells = System.Collections.Generic.List$1$($array(WootzJs.Mvc.Mvc.Views.Control)).prototype.$ctor.$new();
        this.defaultConstraint = WootzJs.Mvc.Mvc.Views.TableConstraint.prototype.$ctor.$new(
            3, 
            3, 
            1, 
            1
        );
        this.columnWidths = columnWidths;
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function(columnWidths) {
        return new $p.$ctor.$type(this, columnWidths);
    };
    $p.$CellSpacing$k__BackingField = 0;
    $p.get_CellSpacing = function() {return this.$CellSpacing$k__BackingField;};
    $p.set_CellSpacing = function(value) {this.$CellSpacing$k__BackingField = value;};
    $p.CreateNode = function() {
        var table = WootzJs.Web.Browser().get_Document().createElement("table");
        var totalNumberOfWeights = System.Linq.Enumerable.Sum$2(WootzJs.Mvc.Mvc.Views.TableWidth, System.Linq.Enumerable.Where(WootzJs.Mvc.Mvc.Views.TableWidth, this.columnWidths, $delegate(this, System.Func$2$(WootzJs.Mvc.Mvc.Views.TableWidth, System.Boolean), function(x) {
            return x.get_Style() == WootzJs.Mvc.Mvc.Views.TableWidthStyle().Weight;
        })), $delegate(this, System.Func$2$(WootzJs.Mvc.Mvc.Views.TableWidth, System.Int32), function(x) {
            return x.get_Value();
        }));
        var totalPercent = System.Linq.Enumerable.Sum$2(WootzJs.Mvc.Mvc.Views.TableWidth, System.Linq.Enumerable.Where(WootzJs.Mvc.Mvc.Views.TableWidth, this.columnWidths, $delegate(this, System.Func$2$(WootzJs.Mvc.Mvc.Views.TableWidth, System.Boolean), function(x) {
            return x.get_Style() == WootzJs.Mvc.Mvc.Views.TableWidthStyle().Percent;
        })), $delegate(this, System.Func$2$(WootzJs.Mvc.Mvc.Views.TableWidth, System.Int32), function(x) {
            return x.get_Value();
        }));
        var percentAvailableToWeights = 100 - totalPercent;
        if (percentAvailableToWeights < 0)
            throw System.InvalidOperationException.prototype.$ctor$1.$new("Total amount of percent specified is greater than 100").InternalInit(new Error());
        var percentToEachWeight = percentAvailableToWeights / totalNumberOfWeights;
        var extraPercent = percentAvailableToWeights - percentToEachWeight * totalNumberOfWeights;
        var colgroup = WootzJs.Web.Browser().get_Document().createElement("colgroup");
        {
            var $anon$1iterator = this.columnWidths;
            var $anon$2enumerator = $anon$1iterator.System$Collections$IEnumerable$GetEnumerator();
            while ($anon$2enumerator.System$Collections$IEnumerator$MoveNext()) {
                var width = $anon$2enumerator.System$Collections$IEnumerator$get_Current();
                var col = WootzJs.Web.Browser().get_Document().createElement("col");
                switch (width.get_Style()) {
                    case WootzJs.Mvc.Mvc.Views.TableWidthStyle().Pixels:
                        col.style.width = $safeToString(width.get_Value()) + "px";
                        break;
                    case WootzJs.Mvc.Mvc.Views.TableWidthStyle().Weight:
                        var currentWeight = percentToEachWeight * width.get_Value();
                        currentWeight += extraPercent;
                        extraPercent = 0;
                        col.style.width = $safeToString(currentWeight) + "%";
                        break;
                    case WootzJs.Mvc.Mvc.Views.TableWidthStyle().Percent:
                        col.style.width = $safeToString(width.get_Value()) + "%";
                        break;
                }
                colgroup.appendChild(col);
            }
        }
        table.appendChild(colgroup);
        return table;
    };
    $p.GetNextEmptyCell = function() {
        var x = 0;
        var y = 0;
        {
            var $anon$1iterator = this.cells;
            var $anon$2enumerator = $anon$1iterator.System$Collections$IEnumerable$GetEnumerator();
            while ($anon$2enumerator.System$Collections$IEnumerator$MoveNext()) {
                var row = $anon$2enumerator.System$Collections$IEnumerator$get_Current();
                {
                    var $anon$3iterator = row;
                    var $anon$4enumerator = $anon$3iterator.System$Collections$IEnumerable$GetEnumerator();
                    while ($anon$4enumerator.System$Collections$IEnumerator$MoveNext()) {
                        var cell = $anon$4enumerator.System$Collections$IEnumerator$get_Current();
                        if (cell == null)
                            return WootzJs.Mvc.Mvc.Views.TablePanel.Point.prototype.$ctor.$new(x, y);
                        x++;
                    }
                }
                x = 0;
                y++;
            }
        }
        return WootzJs.Mvc.Mvc.Views.TablePanel.Point.prototype.$ctor.$new(x, y);
    };
    $p.Add$1 = function(cell) {
        this.Add$2(cell, null);
    };
    $p.Add$2 = function(cell, constraint) {
        WootzJs.Mvc.Mvc.Views.Control.prototype.Add.call(this, cell);
        var nextEmptyCell = this.GetNextEmptyCell();
        constraint = constraint || this.defaultConstraint;
        if (nextEmptyCell.X + constraint.get_ColumnSpan() > this.columnWidths.length)
            throw System.InvalidOperationException.prototype.$ctor$1.$new(String.Format("Added a cell at position ({0},{1}), but the column ({2}) exceeds teh available remaining space in the row ({3}).", [
                nextEmptyCell.X, 
                nextEmptyCell.Y, 
                constraint.get_ColumnSpan(), 
                this.columnWidths.length - nextEmptyCell.X
            ])).InternalInit(new Error());
        var jsCell = WootzJs.Web.Browser().get_Document().createElement("td");
        if (constraint.get_ColumnSpan() != 1)
            jsCell.setAttribute("colspan", constraint.get_ColumnSpan().ToString());
        if (constraint.get_RowSpan() != 1)
            jsCell.setAttribute("rowspan", constraint.get_RowSpan().ToString());
        var jsCellDiv = WootzJs.Web.Browser().get_Document().createElement("div");
        jsCell.appendChild(jsCellDiv);
        switch (constraint.get_HorizontalAlignment()) {
            case WootzJs.Mvc.Mvc.Views.HorizontalAlignment().Left:
                jsCell.setAttribute("align", "left");
                break;
            case WootzJs.Mvc.Mvc.Views.HorizontalAlignment().Center:
                jsCell.setAttribute("align", "center");
                break;
            case WootzJs.Mvc.Mvc.Views.HorizontalAlignment().Right:
                jsCell.setAttribute("align", "right");
                break;
            case WootzJs.Mvc.Mvc.Views.HorizontalAlignment().Fill:
                jsCellDiv.style.width = "100%";
                cell.get_Node().style.width = "100%";
                break;
        }
        switch (constraint.get_VerticalAlignment()) {
            case WootzJs.Mvc.Mvc.Views.VerticalAlignment().Top:
                jsCell.style.verticalAlign = "top";
                break;
            case WootzJs.Mvc.Mvc.Views.VerticalAlignment().Middle:
                jsCell.style.verticalAlign = "middle";
                break;
            case WootzJs.Mvc.Mvc.Views.VerticalAlignment().Bottom:
                jsCell.style.verticalAlign = "bottom";
                break;
            case WootzJs.Mvc.Mvc.Views.VerticalAlignment().Fill:
                cell.get_Node().style.height = "100%";
                jsCellDiv.style.height = "100%";
                break;
        }
        jsCellDiv.appendChild(cell.get_Node());
        for (var row = nextEmptyCell.Y; row < nextEmptyCell.Y + constraint.get_RowSpan(); row++) {
            for (var col = nextEmptyCell.X; col < nextEmptyCell.X + constraint.get_ColumnSpan(); col++) {
                while (this.cells.get_Count() <= row) {
                    this.cells.Add($arrayinit(new Array(this.columnWidths.length), WootzJs.Mvc.Mvc.Views.Control));
                    var newRow = WootzJs.Web.Browser().get_Document().createElement("tr");
                    this.get_Node().appendChild(newRow);
                    this.rows.Add(newRow);
                }
                if (this.cells.get_Item(row)[col] != null)
                    throw System.InvalidOperationException.prototype.$ctor$1.$new("Illegal layout: cannot add a view at row " + $safeToString(row) + ", column " + $safeToString(col) + " as another view is already present: " + $safeToString(this.cells.get_Item(row)[col])).InternalInit(new Error());
                this.cells.get_Item(row)[col] = cell;
            }
        }
        var jsRow = this.rows.get_Item(nextEmptyCell.Y);
        jsRow.appendChild(jsCell);
    };
    $t.Point = $define("WootzJs.Mvc.Mvc.Views.TablePanel.Point", System.Object);
    ($t.Point.$TypeInitializer = function($t, $p) {
        $t.$GetAssembly = window.$WootzJs$Mvc$GetAssembly;
        $p.$type = $t;
        $t.$baseType = System.Object;
        $p.$typeName = "WootzJs.Mvc.Mvc.Views.TablePanel.Point";
        $t.$typeName = $p.$typeName;
        $t.$GetType = function() {
            return System.Type._GetTypeFromTypeFunc(this);
        };
        $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("Point", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Mvc.Mvc.Views.TablePanel.Point", WootzJs.Mvc.Mvc.Views.TablePanel.Point, System.Object, $arrayinit([], System.Type), $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("X", System.Int32, System.Reflection.FieldAttributes().Assembly, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("Y", System.Int32, System.Reflection.FieldAttributes().Assembly, null, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Mvc.Mvc.Views.TablePanel.Point.prototype.$ctor, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("x", System.Int32, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("y", System.Int32, 1, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
        $t.$StaticInitializer = function() {};
        $p.X = 0;
        $p.Y = 0;
        $p.$ctor = function(x, y) {
            System.Object.prototype.$ctor.call(this);
            this.X = x;
            this.Y = y;
        };
        $p.$ctor.$type = $t;
        $p.$ctor.$new = function(x, y) {
            return new $p.$ctor.$type(this, x, y);
        };
    }).call($t, $t.Point, $t.Point.prototype);
    $WootzJs$Mvc$AssemblyTypes.push($t.Point);
}).call(null, WootzJs.Mvc.Mvc.Views.TablePanel, WootzJs.Mvc.Mvc.Views.TablePanel.prototype);
$WootzJs$Mvc$AssemblyTypes.push(WootzJs.Mvc.Mvc.Views.TablePanel);
WootzJs.Mvc.Mvc.Views.Css.CssDeclaration = $define("WootzJs.Mvc.Mvc.Views.Css.CssDeclaration", System.Object);
(WootzJs.Mvc.Mvc.Views.Css.CssDeclaration.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Mvc$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Mvc.Mvc.Views.Css.CssDeclaration";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("CssDeclaration", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Mvc.Mvc.Views.Css.CssDeclaration", WootzJs.Mvc.Mvc.Views.Css.CssDeclaration, System.Object, $arrayinit([], System.Type), $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("actions", System.Collections.Generic.List$1, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("Attach", WootzJs.Mvc.Mvc.Views.Css.CssDeclaration.prototype.Attach, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("node", WootzJs.Web.ElementStyle, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Assembly, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Act", WootzJs.Mvc.Mvc.Views.Css.CssDeclaration.prototype.Act, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("action", System.Action, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Family, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Get", WootzJs.Mvc.Mvc.Views.Css.CssDeclaration.prototype.Get, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("name", String, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Family, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Set", WootzJs.Mvc.Mvc.Views.Css.CssDeclaration.prototype.Set, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("name", String, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Object, 1, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Family, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("IsSet", WootzJs.Mvc.Mvc.Views.Css.CssDeclaration.prototype.IsSet, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("name", String, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Boolean, System.Reflection.MethodAttributes().Family, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("ToString", WootzJs.Mvc.Mvc.Views.Css.CssDeclaration.prototype.ToString, $arrayinit([], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Mvc.Mvc.Views.Css.CssDeclaration.prototype.$ctor, $arrayinit([], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {};
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
        this.actions = System.Collections.Generic.List$1$(System.Action).prototype.$ctor.$new();
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.node = null;
    $p.actions = null;
    $p.Attach = function(node) {
        this.node = node;
        {
            var $anon$1iterator = this.actions;
            var $anon$2enumerator = $anon$1iterator.System$Collections$IEnumerable$GetEnumerator();
            while ($anon$2enumerator.System$Collections$IEnumerator$MoveNext()) {
                var action = $anon$2enumerator.System$Collections$IEnumerator$get_Current();
                action();
            }
        }
    };
    $p.Act = function(action) {
        if (this.node == null)
            this.actions.Add(action);
        else
            action();
    };
    $p.Get = function(name) {
        if (this.node != null)
            return this.node[name];
        throw System.InvalidOperationException.prototype.$ctor$1.$new("Not attached").InternalInit(new Error());
    };
    $p.Set = function(name, value) {
        var val = value.ToString();
        if (this.node == null)
            this.Act($delegate(this, System.Action, function() {
                return this.Set(name, value);
            }));
        else
            this.node[name] = val;
    };
    $p.IsSet = function(name) {
        return this.node[name] != "";
    };
    $p.ToString = function() {
        var builder = System.Text.StringBuilder.prototype.$ctor.$new();
        {
            var $anon$1iterator = this.GetType().GetProperties();
            var $anon$2enumerator = $anon$1iterator.System$Collections$IEnumerable$GetEnumerator();
            while ($anon$2enumerator.System$Collections$IEnumerator$MoveNext()) {
                var property = $anon$2enumerator.System$Collections$IEnumerator$get_Current();
                var value = property.GetValue$1(this, null);
                if (value != null) {
                    builder.Append$2(property.get_Name() + ":" + $safeToString(value) + ";");
                }
            }
        }
        return builder.ToString();
    };
}).call(null, WootzJs.Mvc.Mvc.Views.Css.CssDeclaration, WootzJs.Mvc.Mvc.Views.Css.CssDeclaration.prototype);
$WootzJs$Mvc$AssemblyTypes.push(WootzJs.Mvc.Mvc.Views.Css.CssDeclaration);
WootzJs.Mvc.Mvc.Views.Css.CssValue = $define("WootzJs.Mvc.Mvc.Views.Css.CssValue", System.Object);
(WootzJs.Mvc.Mvc.Views.Css.CssValue.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Mvc$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Mvc.Mvc.Views.Css.CssValue";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("CssValue", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Mvc.Mvc.Views.Css.CssValue", WootzJs.Mvc.Mvc.Views.Css.CssValue, System.Object, $arrayinit([], System.Type), $arrayinit([], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("Parse", WootzJs.Mvc.Mvc.Views.Css.CssValue.prototype.Parse, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", String, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Css.CssValue, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Mvc.Mvc.Views.Css.CssValue.prototype.$ctor, $arrayinit([], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {};
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $t.Parse = function(value) {
        if (value == "inherit")
            return WootzJs.Mvc.Mvc.Views.Css.CssInherit().get_Instance();
        if (value == "inset")
            return WootzJs.Mvc.Mvc.Views.Css.CssInset().Instance;
        var result = WootzJs.Mvc.Mvc.Views.Css.CssColor.Parse$1(value);
        if (result != null)
            return result;
        return WootzJs.Mvc.Mvc.Views.Css.CssNumericValue.Parse$1(value);
    };
}).call(null, WootzJs.Mvc.Mvc.Views.Css.CssValue, WootzJs.Mvc.Mvc.Views.Css.CssValue.prototype);
$WootzJs$Mvc$AssemblyTypes.push(WootzJs.Mvc.Mvc.Views.Css.CssValue);
WootzJs.Mvc.Mvc.Views.View = $define("WootzJs.Mvc.Mvc.Views.View", System.Object);
(WootzJs.Mvc.Mvc.Views.View.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Mvc$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Mvc.Mvc.Views.View";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("View", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Mvc.Mvc.Views.View", WootzJs.Mvc.Mvc.Views.View, System.Object, $arrayinit([], System.Type), $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("$Layout$k__BackingField", WootzJs.Mvc.Mvc.Views.Layout, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("$LayoutType$k__BackingField", System.Type, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("$Title$k__BackingField", String, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("$ViewContext$k__BackingField", WootzJs.Mvc.Mvc.ViewContext, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("_content", WootzJs.Mvc.Mvc.Views.Control, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("get_Layout", WootzJs.Mvc.Mvc.Views.View.prototype.get_Layout, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Layout, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Layout", WootzJs.Mvc.Mvc.Views.View.prototype.set_Layout, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Layout, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Private, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_LayoutType", WootzJs.Mvc.Mvc.Views.View.prototype.get_LayoutType, $arrayinit([], System.Reflection.ParameterInfo), System.Type, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_LayoutType", WootzJs.Mvc.Mvc.Views.View.prototype.set_LayoutType, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Type, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_Title", WootzJs.Mvc.Mvc.Views.View.prototype.get_Title, $arrayinit([], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Title", WootzJs.Mvc.Mvc.Views.View.prototype.set_Title, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", String, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_ViewContext", WootzJs.Mvc.Mvc.Views.View.prototype.get_ViewContext, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.ViewContext, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_ViewContext", WootzJs.Mvc.Mvc.Views.View.prototype.set_ViewContext, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.ViewContext, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Private, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Initialize", WootzJs.Mvc.Mvc.Views.View.prototype.Initialize, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("context", WootzJs.Mvc.Mvc.ViewContext, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_Content", WootzJs.Mvc.Mvc.Views.View.prototype.get_Content, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Control, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Content", WootzJs.Mvc.Mvc.Views.View.prototype.set_Content, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Control, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("VerifyLayouts", WootzJs.Mvc.Mvc.Views.View.prototype.VerifyLayouts, $arrayinit([], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Family, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("GetRootView", WootzJs.Mvc.Mvc.Views.View.prototype.GetRootView, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.View, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("CreateLayout", WootzJs.Mvc.Mvc.Views.View.prototype.CreateLayout, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Layout, System.Reflection.MethodAttributes().Family, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Mvc.Mvc.Views.View.prototype.$ctor, $arrayinit([], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.PropertyInfo.prototype.$ctor.$new("Layout", WootzJs.Mvc.Mvc.Views.Layout, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Layout", WootzJs.Mvc.Mvc.Views.View.prototype.get_Layout, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Layout, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Layout", WootzJs.Mvc.Mvc.Views.View.prototype.set_Layout, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Layout, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Private, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("LayoutType", System.Type, System.Reflection.MethodInfo.prototype.$ctor.$new("get_LayoutType", WootzJs.Mvc.Mvc.Views.View.prototype.get_LayoutType, $arrayinit([], System.Reflection.ParameterInfo), System.Type, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_LayoutType", WootzJs.Mvc.Mvc.Views.View.prototype.set_LayoutType, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Type, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("Title", String, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Title", WootzJs.Mvc.Mvc.Views.View.prototype.get_Title, $arrayinit([], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Title", WootzJs.Mvc.Mvc.Views.View.prototype.set_Title, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", String, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("ViewContext", WootzJs.Mvc.Mvc.ViewContext, System.Reflection.MethodInfo.prototype.$ctor.$new("get_ViewContext", WootzJs.Mvc.Mvc.Views.View.prototype.get_ViewContext, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.ViewContext, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_ViewContext", WootzJs.Mvc.Mvc.Views.View.prototype.set_ViewContext, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.ViewContext, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Private, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("Content", WootzJs.Mvc.Mvc.Views.Control, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Content", WootzJs.Mvc.Mvc.Views.View.prototype.get_Content, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Control, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Content", WootzJs.Mvc.Mvc.Views.View.prototype.set_Content, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Control, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute))], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {};
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.$Layout$k__BackingField = null;
    $p.get_Layout = function() {return this.$Layout$k__BackingField;};
    $p.set_Layout = function(value) {this.$Layout$k__BackingField = value;};
    $p.$LayoutType$k__BackingField = null;
    $p.get_LayoutType = function() {return this.$LayoutType$k__BackingField;};
    $p.set_LayoutType = function(value) {this.$LayoutType$k__BackingField = value;};
    $p.$Title$k__BackingField = null;
    $p.get_Title = function() {return this.$Title$k__BackingField;};
    $p.set_Title = function(value) {this.$Title$k__BackingField = value;};
    $p.$ViewContext$k__BackingField = null;
    $p.get_ViewContext = function() {return this.$ViewContext$k__BackingField;};
    $p.set_ViewContext = function(value) {this.$ViewContext$k__BackingField = value;};
    $p._content = null;
    $p.Initialize = function(context) {
        this.set_ViewContext(context);
    };
    $p.get_Content = function() {
        return this._content;
    };
    $p.set_Content = function(value) {
        this._content = value;
        value.set_View(this);
    };
    $p.VerifyLayouts = function() {
        if (this.get_Layout() == null && this.get_LayoutType() != null) {
            this.set_Layout(this.CreateLayout());
            if (this.get_ViewContext() == null)
                throw System.Exception.prototype.$ctor$1.$new("ControllerContext not set yet").InternalInit(new Error());
            this.get_Layout().Initialize(this.get_ViewContext());
            this.get_Layout().AddView(this);
        }
    };
    $p.GetRootView = function() {
        this.VerifyLayouts();
        if (this.get_Layout() != null)
            return this.get_Layout().GetRootView();
        else
            return this;
    };
    $p.CreateLayout = function() {
        return $cast(WootzJs.Mvc.Mvc.Views.Layout, System.Reflection.Activator.CreateInstance(this.get_LayoutType()));
    };
}).call(null, WootzJs.Mvc.Mvc.Views.View, WootzJs.Mvc.Mvc.Views.View.prototype);
$WootzJs$Mvc$AssemblyTypes.push(WootzJs.Mvc.Mvc.Views.View);
window.$AnonymousType$1 = $define("<anonymous type: string Name, object Value>", System.Object);
($AnonymousType$1.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Mvc$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Object;
    $p.$typeName = "$AnonymousType$1";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("", $arrayinit([], System.Attribute));this.$type.Init("$AnonymousType$1", $AnonymousType$1, System.Object, $arrayinit([], System.Type), $arrayinit([], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("get_Name", $AnonymousType$1.prototype.get_Name, $arrayinit([], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_Value", $AnonymousType$1.prototype.get_Value, $arrayinit([], System.Reflection.ParameterInfo), System.Object, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", $AnonymousType$1.prototype.$ctor, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("Name", String, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("Value", System.Object, 1, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.PropertyInfo.prototype.$ctor.$new("Name", String, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Name", $AnonymousType$1.prototype.get_Name, $arrayinit([], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), null, $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("Value", System.Object, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Value", $AnonymousType$1.prototype.get_Value, $arrayinit([], System.Reflection.ParameterInfo), System.Object, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), null, $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute))], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {};
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.$Name$k__BackingField = null;
    $p.get_Name = function() {
        return this.$Name$k__BackingField;
    };
    $p.$Value$k__BackingField = null;
    $p.get_Value = function() {
        return this.$Value$k__BackingField;
    };
}).call(null, $AnonymousType$1, $AnonymousType$1.prototype);
$WootzJs$Mvc$AssemblyTypes.push($AnonymousType$1);
WootzJs.Mvc.ExpressionTrees.Evaluator = $define("WootzJs.Mvc.ExpressionTrees.Evaluator", System.Linq.Expressions.ExpressionVisitor);
(WootzJs.Mvc.ExpressionTrees.Evaluator.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Mvc$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Linq.Expressions.ExpressionVisitor;
    $p.$typeName = "WootzJs.Mvc.ExpressionTrees.Evaluator";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("Evaluator", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Mvc.ExpressionTrees.Evaluator", WootzJs.Mvc.ExpressionTrees.Evaluator, System.Linq.Expressions.ExpressionVisitor, $arrayinit([], System.Type), $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("expression", System.Linq.Expressions.Expression, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("stack", System.Collections.Generic.Stack$1, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("Evaluate", WootzJs.Mvc.ExpressionTrees.Evaluator.prototype.Evaluate, $arrayinit([], System.Reflection.ParameterInfo), System.Object, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("VisitConstant", WootzJs.Mvc.ExpressionTrees.Evaluator.prototype.VisitConstant, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("node", System.Linq.Expressions.ConstantExpression, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Linq.Expressions.Expression, System.Reflection.MethodAttributes().Family, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("VisitBinary", WootzJs.Mvc.ExpressionTrees.Evaluator.prototype.VisitBinary, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("node", System.Linq.Expressions.BinaryExpression, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Linq.Expressions.Expression, System.Reflection.MethodAttributes().Family, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("VisitConditional", WootzJs.Mvc.ExpressionTrees.Evaluator.prototype.VisitConditional, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("node", System.Linq.Expressions.ConditionalExpression, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Linq.Expressions.Expression, System.Reflection.MethodAttributes().Family, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("VisitMember", WootzJs.Mvc.ExpressionTrees.Evaluator.prototype.VisitMember, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("node", System.Linq.Expressions.MemberExpression, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Linq.Expressions.Expression, System.Reflection.MethodAttributes().Family, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("VisitMethodCall", WootzJs.Mvc.ExpressionTrees.Evaluator.prototype.VisitMethodCall, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("node", System.Linq.Expressions.MethodCallExpression, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Linq.Expressions.Expression, System.Reflection.MethodAttributes().Family, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("VisitNew", WootzJs.Mvc.ExpressionTrees.Evaluator.prototype.VisitNew, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("node", System.Linq.Expressions.NewExpression, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Linq.Expressions.Expression, System.Reflection.MethodAttributes().Family, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("VisitMemberInit", WootzJs.Mvc.ExpressionTrees.Evaluator.prototype.VisitMemberInit, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("node", System.Linq.Expressions.MemberInitExpression, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Linq.Expressions.Expression, System.Reflection.MethodAttributes().Family, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("VisitListInit", WootzJs.Mvc.ExpressionTrees.Evaluator.prototype.VisitListInit, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("node", System.Linq.Expressions.ListInitExpression, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Linq.Expressions.Expression, System.Reflection.MethodAttributes().Family, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("VisitUnary", WootzJs.Mvc.ExpressionTrees.Evaluator.prototype.VisitUnary, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("node", System.Linq.Expressions.UnaryExpression, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Linq.Expressions.Expression, System.Reflection.MethodAttributes().Family, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("VisitInvocation", WootzJs.Mvc.ExpressionTrees.Evaluator.prototype.VisitInvocation, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("node", System.Linq.Expressions.InvocationExpression, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Linq.Expressions.Expression, System.Reflection.MethodAttributes().Family, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("VisitTypeBinary", WootzJs.Mvc.ExpressionTrees.Evaluator.prototype.VisitTypeBinary, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("node", System.Linq.Expressions.TypeBinaryExpression, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Linq.Expressions.Expression, System.Reflection.MethodAttributes().Family, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("VisitNewArray", WootzJs.Mvc.ExpressionTrees.Evaluator.prototype.VisitNewArray, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("node", System.Linq.Expressions.NewArrayExpression, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Linq.Expressions.Expression, System.Reflection.MethodAttributes().Family, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("VisitLambda", WootzJs.Mvc.ExpressionTrees.Evaluator.prototype.VisitLambda, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("node", System.Linq.Expressions.Expression$1, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Linq.Expressions.Expression, System.Reflection.MethodAttributes().Family, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Mvc.ExpressionTrees.Evaluator.prototype.$ctor, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("expression", System.Linq.Expressions.Expression, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {};
    $p.expression = null;
    $p.stack = null;
    $p.$ctor = function(expression) {
        System.Linq.Expressions.ExpressionVisitor.prototype.$ctor.call(this);
        this.stack = System.Collections.Generic.Stack$1$(System.Object).prototype.$ctor.$new();
        this.expression = expression;
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function(expression) {
        return new $p.$ctor.$type(this, expression);
    };
    $p.Evaluate = function() {
        this.Visit$1(this.expression);
        return this.stack.Peek();
    };
    $p.VisitConstant = function(node) {
        System.Linq.Expressions.ExpressionVisitor.prototype.VisitConstant.call(this, node);
        this.stack.Push(node.get_Value());
        return node;
    };
    $p.VisitBinary = function(node) {
        System.Linq.Expressions.ExpressionVisitor.prototype.VisitBinary.call(this, node);
        var right = this.stack.Pop();
        var left = this.stack.Pop();
        switch (node.get_NodeType()) {
            case System.Linq.Expressions.ExpressionType().Add:
                this.stack.Push(WootzJs.Mvc.ExpressionTrees.GenericMath.Add(left, right));
                break;
            case System.Linq.Expressions.ExpressionType().Subtract:
                this.stack.Push(WootzJs.Mvc.ExpressionTrees.GenericMath.Subtract(left, right));
                break;
            case System.Linq.Expressions.ExpressionType().Multiply:
                this.stack.Push(WootzJs.Mvc.ExpressionTrees.GenericMath.Multiply(left, right));
                break;
            case System.Linq.Expressions.ExpressionType().Divide:
                this.stack.Push(WootzJs.Mvc.ExpressionTrees.GenericMath.Divide(left, right));
                break;
            case System.Linq.Expressions.ExpressionType().Modulo:
                this.stack.Push(WootzJs.Mvc.ExpressionTrees.GenericMath.Modulus(left, right));
                break;
            case System.Linq.Expressions.ExpressionType().ArrayIndex:
                var array = $cast(Array, left);
                var index = $cast(System.Int64, System.Convert.ChangeType(right, System.Int64.$GetType()));
                var value = array.GetValue$1(index);
                this.stack.Push(value);
                break;
        }
        return node;
    };
    $p.VisitConditional = function(node) {
        System.Linq.Expressions.ExpressionVisitor.prototype.VisitConditional.call(this, node);
        var ifFalse = this.stack.Pop();
        var ifTrue = this.stack.Pop();
        var test = $cast(System.Boolean, this.stack.Pop());
        this.stack.Push(test ? ifTrue : ifFalse);
        return node;
    };
    $p.VisitMember = function(node) {
        System.Linq.Expressions.ExpressionVisitor.prototype.VisitMember.call(this, node);
        var obj = this.stack.Pop();
        var fieldInfo = (function() {
            var $as$ = node.get_Member();
            if (!System.Type.prototype.IsInstanceOfType.call(System.Reflection.FieldInfo.$GetType(), $as$))
                $as$ = null;
            return $as$;
        }).call(this);
        if (fieldInfo != null) {
            var field = fieldInfo;
            var value = field.GetValue(obj);
            this.stack.Push(value);
        }
        else {
            var property = $cast(System.Reflection.PropertyInfo, node.get_Member());
            var value = property.GetValue$1(obj, null);
            this.stack.Push(value);
        }
        return node;
    };
    $p.VisitMethodCall = function(node) {
        System.Linq.Expressions.ExpressionVisitor.prototype.VisitMethodCall.call(this, node);
        var args = System.Linq.Enumerable.ToArray(System.Object, System.Linq.Enumerable.Reverse(System.Object, System.Linq.Enumerable.Select(
            System.Linq.Expressions.Expression, 
            System.Object, 
            node.get_Arguments(), 
            $delegate(this, System.Func$2$(System.Linq.Expressions.Expression, System.Object), function(_) {
                return this.stack.Pop();
            })
        )));
        var obj = this.stack.Pop();
        var value = node.get_Method().Invoke(obj, args);
        this.stack.Push(value);
        return node;
    };
    $p.VisitNew = function(node) {
        System.Linq.Expressions.ExpressionVisitor.prototype.VisitNew.call(this, node);
        var args = System.Linq.Enumerable.ToArray(System.Object, System.Linq.Enumerable.Reverse(System.Object, System.Linq.Enumerable.Select(
            System.Linq.Expressions.Expression, 
            System.Object, 
            node.get_Arguments(), 
            $delegate(this, System.Func$2$(System.Linq.Expressions.Expression, System.Object), function(_) {
                return this.stack.Pop();
            })
        )));
        var obj = node.get_Constructor().Invoke$2(args);
        this.stack.Push(obj);
        return node;
    };
    $p.VisitMemberInit = function(node) {
        System.Linq.Expressions.ExpressionVisitor.prototype.VisitMemberInit.call(this, node);
        var bindings = System.Linq.Enumerable.ToArray(System.Object, System.Linq.Enumerable.Reverse(System.Object, System.Linq.Enumerable.Select(
            System.Linq.Expressions.MemberBinding, 
            System.Object, 
            node.get_Bindings(), 
            $delegate(this, System.Func$2$(System.Linq.Expressions.MemberBinding, System.Object), function(_) {
                return this.stack.Pop();
            })
        )));
        var obj = this.stack.Pop();
        for (var i = 0; i < node.get_Bindings().get_Count(); i++) {
            var binding = node.get_Bindings().get_Item(i);
            var fieldInfo = (function() {
                var $as$ = binding.get_Member();
                if (!System.Type.prototype.IsInstanceOfType.call(System.Reflection.FieldInfo.$GetType(), $as$))
                    $as$ = null;
                return $as$;
            }).call(this);
            if (fieldInfo != null) {
                fieldInfo.SetValue(obj, bindings[i]);
            }
            else {
                var propertyInfo = (function() {
                    var $as$ = binding.get_Member();
                    if (!System.Type.prototype.IsInstanceOfType.call(System.Reflection.PropertyInfo.$GetType(), $as$))
                        $as$ = null;
                    return $as$;
                }).call(this);
                if (propertyInfo != null) {
                    propertyInfo.SetValue$1(obj, bindings[i], null);
                }
            }
        }
        this.stack.Push(obj);
        return node;
    };
    $p.VisitListInit = function(node) {
        System.Linq.Expressions.ExpressionVisitor.prototype.VisitListInit.call(this, node);
        var args = System.Linq.Enumerable.ToArray($array(System.Object), System.Linq.Enumerable.Reverse($array(System.Object), System.Linq.Enumerable.Select(
            System.Linq.Expressions.ElementInit, 
            $array(System.Object), 
            node.get_Initializers(), 
            $delegate(this, System.Func$2$(System.Linq.Expressions.ElementInit, $array(System.Object)), function(init) {
                return System.Linq.Enumerable.ToArray(System.Object, System.Linq.Enumerable.Reverse(System.Object, System.Linq.Enumerable.Select(
                    System.Linq.Expressions.Expression, 
                    System.Object, 
                    init.get_Arguments(), 
                    $delegate(this, System.Func$2$(System.Linq.Expressions.Expression, System.Object), function(_) {
                        return this.stack.Pop();
                    })
                )));
            })
        )));
        var list = this.stack.Pop();
        for (var i = 0; i < node.get_Initializers().get_Count(); i++) {
            var binding = node.get_Initializers().get_Item(i);
            var argument = args[i];
            binding.get_AddMethod().Invoke(list, argument);
        }
        this.stack.Push(list);
        return node;
    };
    $p.VisitUnary = function(node) {
        System.Linq.Expressions.ExpressionVisitor.prototype.VisitUnary.call(this, node);
        var value = this.stack.Pop();
        switch (node.get_NodeType()) {
            case System.Linq.Expressions.ExpressionType().Not:
                this.stack.Push(!$cast(System.Boolean, value));
                break;
            case System.Linq.Expressions.ExpressionType().Convert:
                this.stack.Push(System.Convert.ChangeType(value, node.get_Type()));
                break;
            case System.Linq.Expressions.ExpressionType().TypeAs:
                this.stack.Push(node.get_Type().IsInstanceOfType(value) ? value : null);
                break;
        }
        return node;
    };
    $p.VisitInvocation = function(node) {
        System.Linq.Expressions.ExpressionVisitor.prototype.VisitInvocation.call(this, node);
        var args = System.Linq.Enumerable.ToArray(System.Object, System.Linq.Enumerable.Reverse(System.Object, System.Linq.Enumerable.Select(
            System.Linq.Expressions.Expression, 
            System.Object, 
            node.get_Arguments(), 
            $delegate(this, System.Func$2$(System.Linq.Expressions.Expression, System.Object), function(_) {
                return this.stack.Pop();
            })
        )));
        var lambda = $cast(System.Delegate, this.stack.Pop());
        var value = lambda.DynamicInvoke(args);
        this.stack.Push(value);
        return node;
    };
    $p.VisitTypeBinary = function(node) {
        System.Linq.Expressions.ExpressionVisitor.prototype.VisitTypeBinary.call(this, node);
        var expression = this.stack.Pop();
        var value = node.get_TypeOperand().IsInstanceOfType(expression);
        this.stack.Push(value);
        return node;
    };
    $p.VisitNewArray = function(node) {
        System.Linq.Expressions.ExpressionVisitor.prototype.VisitNewArray.call(this, node);
        var args = System.Linq.Enumerable.ToArray(System.Object, System.Linq.Enumerable.Reverse(System.Object, System.Linq.Enumerable.Select(
            System.Linq.Expressions.Expression, 
            System.Object, 
            node.get_Expressions(), 
            $delegate(this, System.Func$2$(System.Linq.Expressions.Expression, System.Object), function(_) {
                return this.stack.Pop();
            })
        )));
        var array = Array.CreateInstance(node.get_Type().GetElementType(), node.get_Expressions().get_Count());
        for (var i = 0; i < array.length; i++) {
            array.SetValue(args[i], i);
        }
        this.stack.Push(array);
        return node;
    };
    $p.VisitLambda = function(T, node) {
        this.stack.Push(node.Compile());
        return node;
    };
}).call(null, WootzJs.Mvc.ExpressionTrees.Evaluator, WootzJs.Mvc.ExpressionTrees.Evaluator.prototype);
$WootzJs$Mvc$AssemblyTypes.push(WootzJs.Mvc.ExpressionTrees.Evaluator);
WootzJs.Mvc.ExpressionTrees.EvaluatorExtensions = $define("WootzJs.Mvc.ExpressionTrees.EvaluatorExtensions", System.Object);
(WootzJs.Mvc.ExpressionTrees.EvaluatorExtensions.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Mvc$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Mvc.ExpressionTrees.EvaluatorExtensions";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("EvaluatorExtensions", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Mvc.ExpressionTrees.EvaluatorExtensions", WootzJs.Mvc.ExpressionTrees.EvaluatorExtensions, System.Object, $arrayinit([], System.Type), $arrayinit([], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("Evaluate", WootzJs.Mvc.ExpressionTrees.EvaluatorExtensions.prototype.Evaluate, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("expression", System.Linq.Expressions.Expression, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Object, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("ExtractArguments", WootzJs.Mvc.ExpressionTrees.EvaluatorExtensions.prototype.ExtractArguments, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("expression", System.Linq.Expressions.InvocationExpression, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), $array(System.Object), System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("ExtractArguments$1", WootzJs.Mvc.ExpressionTrees.EvaluatorExtensions.prototype.ExtractArguments$1, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("expression", System.Linq.Expressions.MethodCallExpression, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Collections.Generic.Dictionary$2, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {};
    $t.Evaluate = function(expression) {
        return WootzJs.Mvc.ExpressionTrees.Evaluator.prototype.$ctor.$new(expression).Evaluate();
    };
    $t.ExtractArguments = function(expression) {
        return System.Linq.Enumerable.ToArray(System.Object, System.Linq.Enumerable.Select(
            System.Linq.Expressions.Expression, 
            System.Object, 
            expression.get_Arguments(), 
            $delegate(this, System.Func$2$(System.Linq.Expressions.Expression, System.Object), function(x) {
                return WootzJs.Mvc.ExpressionTrees.EvaluatorExtensions.Evaluate(x);
            })
        ));
    };
    $t.ExtractArguments$1 = function(expression) {
        var parameters = expression.get_Method().GetParameters();
        return System.Linq.Enumerable.ToDictionary$1(
            $AnonymousType$1, 
            String, 
            System.Object, 
            System.Linq.Enumerable.Select$1(
                System.Linq.Expressions.Expression, 
                $AnonymousType$1, 
                expression.get_Arguments(), 
                $delegate(this, System.Func$3$(System.Linq.Expressions.Expression, System.Int32, $AnonymousType$1), function(x, i) {
                    return (function() {
                        var $obj$ = $AnonymousType$1.prototype.$ctor.$new();
                        $obj$.$Name$k__BackingField = parameters[i].get_Name();
                        $obj$.$Value$k__BackingField = WootzJs.Mvc.ExpressionTrees.EvaluatorExtensions.Evaluate(x);
                        return $obj$;
                    }).call(this);
                })
            ), 
            $delegate(this, System.Func$2$($AnonymousType$1, String), function(x) {
                return x.get_Name();
            }), 
            $delegate(this, System.Func$2$($AnonymousType$1, System.Object), function(x) {
                return x.get_Value();
            })
        );
    };
}).call(null, WootzJs.Mvc.ExpressionTrees.EvaluatorExtensions, WootzJs.Mvc.ExpressionTrees.EvaluatorExtensions.prototype);
$WootzJs$Mvc$AssemblyTypes.push(WootzJs.Mvc.ExpressionTrees.EvaluatorExtensions);
WootzJs.Mvc.ExpressionTrees.GenericMath = $define("WootzJs.Mvc.ExpressionTrees.GenericMath", System.Object);
(WootzJs.Mvc.ExpressionTrees.GenericMath.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Mvc$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Mvc.ExpressionTrees.GenericMath";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("GenericMath", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Mvc.ExpressionTrees.GenericMath", WootzJs.Mvc.ExpressionTrees.GenericMath, System.Object, $arrayinit([], System.Type), $arrayinit([], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("IsInteger", WootzJs.Mvc.ExpressionTrees.GenericMath.prototype.IsInteger, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("type", System.Type, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Boolean, System.Reflection.MethodAttributes().Private | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("IsBinaryFloat", WootzJs.Mvc.ExpressionTrees.GenericMath.prototype.IsBinaryFloat, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("type", System.Type, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Boolean, System.Reflection.MethodAttributes().Private | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("IsDecimal", WootzJs.Mvc.ExpressionTrees.GenericMath.prototype.IsDecimal, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("type", System.Type, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Boolean, System.Reflection.MethodAttributes().Private | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("GetWidestType", WootzJs.Mvc.ExpressionTrees.GenericMath.prototype.GetWidestType, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("type1", System.Type, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("type2", System.Type, 1, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Type, System.Reflection.MethodAttributes().Private | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Add", WootzJs.Mvc.ExpressionTrees.GenericMath.prototype.Add, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("left", System.Object, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("right", System.Object, 1, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Object, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Subtract", WootzJs.Mvc.ExpressionTrees.GenericMath.prototype.Subtract, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("left", System.Object, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("right", System.Object, 1, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Object, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Multiply", WootzJs.Mvc.ExpressionTrees.GenericMath.prototype.Multiply, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("left", System.Object, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("right", System.Object, 1, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Object, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Divide", WootzJs.Mvc.ExpressionTrees.GenericMath.prototype.Divide, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("left", System.Object, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("right", System.Object, 1, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Object, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Modulus", WootzJs.Mvc.ExpressionTrees.GenericMath.prototype.Modulus, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("left", System.Object, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("right", System.Object, 1, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Object, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Mvc.ExpressionTrees.GenericMath.prototype.$ctor, $arrayinit([], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {};
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $t.IsInteger = function(type) {
        return type == System.Byte.$GetType() || type == System.Int16.$GetType() || type == System.Int32.$GetType() || type == System.Int64.$GetType();
    };
    $t.IsBinaryFloat = function(type) {
        return type == System.Single.$GetType() || type == System.Double.$GetType();
    };
    $t.IsDecimal = function(type) {
        return false;
    };
    $t.GetWidestType = function(type1, type2) {
        if (type1 == type2)
            return type1;
        if (WootzJs.Mvc.ExpressionTrees.GenericMath.IsInteger(type1))
            return type2;
        if (WootzJs.Mvc.ExpressionTrees.GenericMath.IsBinaryFloat(type1)) {
            if (!WootzJs.Mvc.ExpressionTrees.GenericMath.IsDecimal(type2))
                return type1;
        }
        if (WootzJs.Mvc.ExpressionTrees.GenericMath.IsDecimal(type1)) {
            if (!WootzJs.Mvc.ExpressionTrees.GenericMath.IsBinaryFloat(type2))
                return type1;
        }
        throw System.InvalidOperationException.prototype.$ctor$1.$new("There is no implicit conversion between " + type1.get_FullName() + " and " + type2.get_FullName()).InternalInit(new Error());
    };
    $t.Add = function(left, right) {
        var widestType = WootzJs.Mvc.ExpressionTrees.GenericMath.GetWidestType(left.GetType(), right.GetType());
        left = System.Convert.ChangeType(left, widestType);
        right = System.Convert.ChangeType(right, widestType);
        if (System.Byte.$GetType().IsInstanceOfType(left))
            return $cast(System.Int32, left) + $cast(System.Int32, right);
        else
            if (System.Int16.$GetType().IsInstanceOfType(left))
                return $cast(System.Int32, left) + $cast(System.Int32, right);
            else
                if (System.Int32.$GetType().IsInstanceOfType(left))
                    return $cast(System.Int32, left) + $cast(System.Int32, right);
                else
                    if (System.Int64.$GetType().IsInstanceOfType(left))
                        return $cast(System.Int64, left) + $cast(System.Int64, right);
                    else
                        if (System.Single.$GetType().IsInstanceOfType(left))
                            return $cast(System.Single, left) + $cast(System.Single, right);
                        else
                            if (System.Decimal.$GetType().IsInstanceOfType(left))
                                return $cast(System.Decimal, left) + $cast(System.Decimal, right);
                            else
                                return $cast(System.Double, left) + $cast(System.Double, right);
    };
    $t.Subtract = function(left, right) {
        var widestType = WootzJs.Mvc.ExpressionTrees.GenericMath.GetWidestType(left.GetType(), right.GetType());
        left = System.Convert.ChangeType(left, widestType);
        right = System.Convert.ChangeType(right, widestType);
        if (System.Byte.$GetType().IsInstanceOfType(left))
            return $cast(System.Int32, left) - $cast(System.Int32, right);
        else
            if (System.Int16.$GetType().IsInstanceOfType(left))
                return $cast(System.Int32, left) - $cast(System.Int32, right);
            else
                if (System.Int32.$GetType().IsInstanceOfType(left))
                    return $cast(System.Int32, left) - $cast(System.Int32, right);
                else
                    if (System.Int64.$GetType().IsInstanceOfType(left))
                        return $cast(System.Int64, left) - $cast(System.Int64, right);
                    else
                        if (System.Single.$GetType().IsInstanceOfType(left))
                            return $cast(System.Single, left) - $cast(System.Single, right);
                        else
                            if (System.Decimal.$GetType().IsInstanceOfType(left))
                                return $cast(System.Decimal, left) - $cast(System.Decimal, right);
                            else
                                return $cast(System.Double, left) - $cast(System.Double, right);
    };
    $t.Multiply = function(left, right) {
        var widestType = WootzJs.Mvc.ExpressionTrees.GenericMath.GetWidestType(left.GetType(), right.GetType());
        left = System.Convert.ChangeType(left, widestType);
        right = System.Convert.ChangeType(right, widestType);
        if (System.Byte.$GetType().IsInstanceOfType(left))
            return $cast(System.Int32, left) * $cast(System.Int32, right);
        else
            if (System.Int16.$GetType().IsInstanceOfType(left))
                return $cast(System.Int32, left) * $cast(System.Int32, right);
            else
                if (System.Int32.$GetType().IsInstanceOfType(left))
                    return $cast(System.Int32, left) * $cast(System.Int32, right);
                else
                    if (System.Int64.$GetType().IsInstanceOfType(left))
                        return $cast(System.Int64, left) * $cast(System.Int64, right);
                    else
                        if (System.Single.$GetType().IsInstanceOfType(left))
                            return $cast(System.Single, left) * $cast(System.Single, right);
                        else
                            if (System.Decimal.$GetType().IsInstanceOfType(left))
                                return $cast(System.Decimal, left) * $cast(System.Decimal, right);
                            else
                                return $cast(System.Double, left) * $cast(System.Double, right);
    };
    $t.Divide = function(left, right) {
        var widestType = WootzJs.Mvc.ExpressionTrees.GenericMath.GetWidestType(left.GetType(), right.GetType());
        left = System.Convert.ChangeType(left, widestType);
        right = System.Convert.ChangeType(right, widestType);
        if (System.Byte.$GetType().IsInstanceOfType(left))
            return $cast(System.Int32, left) / $cast(System.Int32, right);
        else
            if (System.Int16.$GetType().IsInstanceOfType(left))
                return $cast(System.Int32, left) / $cast(System.Int32, right);
            else
                if (System.Int32.$GetType().IsInstanceOfType(left))
                    return $cast(System.Int32, left) / $cast(System.Int32, right);
                else
                    if (System.Int64.$GetType().IsInstanceOfType(left))
                        return $cast(System.Int64, left) / $cast(System.Int64, right);
                    else
                        if (System.Single.$GetType().IsInstanceOfType(left))
                            return $cast(System.Single, left) / $cast(System.Single, right);
                        else
                            if (System.Decimal.$GetType().IsInstanceOfType(left))
                                return $cast(System.Decimal, left) / $cast(System.Decimal, right);
                            else
                                return $cast(System.Double, left) / $cast(System.Double, right);
    };
    $t.Modulus = function(left, right) {
        var widestType = WootzJs.Mvc.ExpressionTrees.GenericMath.GetWidestType(left.GetType(), right.GetType());
        left = System.Convert.ChangeType(left, widestType);
        right = System.Convert.ChangeType(right, widestType);
        if (System.Byte.$GetType().IsInstanceOfType(left))
            return $cast(System.Int32, left) % $cast(System.Int32, right);
        else
            if (System.Int16.$GetType().IsInstanceOfType(left))
                return $cast(System.Int32, left) % $cast(System.Int32, right);
            else
                if (System.Int32.$GetType().IsInstanceOfType(left))
                    return $cast(System.Int32, left) % $cast(System.Int32, right);
                else
                    if (System.Int64.$GetType().IsInstanceOfType(left))
                        return $cast(System.Int64, left) % $cast(System.Int64, right);
                    else
                        if (System.Single.$GetType().IsInstanceOfType(left))
                            return $cast(System.Single, left) % $cast(System.Single, right);
                        else
                            if (System.Decimal.$GetType().IsInstanceOfType(left))
                                return $cast(System.Decimal, left) % $cast(System.Decimal, right);
                            else
                                return $cast(System.Double, left) % $cast(System.Double, right);
    };
}).call(null, WootzJs.Mvc.ExpressionTrees.GenericMath, WootzJs.Mvc.ExpressionTrees.GenericMath.prototype);
$WootzJs$Mvc$AssemblyTypes.push(WootzJs.Mvc.ExpressionTrees.GenericMath);
WootzJs.Mvc.Mvc.ActionResult = $define("WootzJs.Mvc.Mvc.ActionResult", System.Object);
(WootzJs.Mvc.Mvc.ActionResult.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Mvc$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Mvc.Mvc.ActionResult";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("ActionResult", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Mvc.Mvc.ActionResult", WootzJs.Mvc.Mvc.ActionResult, System.Object, $arrayinit([], System.Type), $arrayinit([], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("ExecuteResult", WootzJs.Mvc.Mvc.ActionResult.prototype.ExecuteResult, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("context", WootzJs.Mvc.Mvc.NavigationContext, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Mvc.Mvc.ActionResult.prototype.$ctor, $arrayinit([], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Family, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {};
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.ExecuteResult = function(context) {};
}).call(null, WootzJs.Mvc.Mvc.ActionResult, WootzJs.Mvc.Mvc.ActionResult.prototype);
$WootzJs$Mvc$AssemblyTypes.push(WootzJs.Mvc.Mvc.ActionResult);
WootzJs.Mvc.Mvc.Controller = $define("WootzJs.Mvc.Mvc.Controller", System.Object);
(WootzJs.Mvc.Mvc.Controller.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Mvc$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Mvc.Mvc.Controller";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("Controller", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Mvc.Mvc.Controller", WootzJs.Mvc.Mvc.Controller, System.Object, $arrayinit([], System.Type), $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("$ControllerContext$k__BackingField", WootzJs.Mvc.Mvc.ControllerContext, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("$NavigationContext$k__BackingField", WootzJs.Mvc.Mvc.NavigationContext, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("$ActionInvoker$k__BackingField", WootzJs.Mvc.Mvc.IActionInvoker, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("get_ControllerContext", WootzJs.Mvc.Mvc.Controller.prototype.get_ControllerContext, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.ControllerContext, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_ControllerContext", WootzJs.Mvc.Mvc.Controller.prototype.set_ControllerContext, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.ControllerContext, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Private, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_NavigationContext", WootzJs.Mvc.Mvc.Controller.prototype.get_NavigationContext, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.NavigationContext, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_NavigationContext", WootzJs.Mvc.Mvc.Controller.prototype.set_NavigationContext, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.NavigationContext, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Private, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_ActionInvoker", WootzJs.Mvc.Mvc.Controller.prototype.get_ActionInvoker, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.IActionInvoker, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_ActionInvoker", WootzJs.Mvc.Mvc.Controller.prototype.set_ActionInvoker, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.IActionInvoker, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Private, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Initialize", WootzJs.Mvc.Mvc.Controller.prototype.Initialize, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("application", WootzJs.Mvc.Mvc.MvcApplication, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("requestContext", WootzJs.Mvc.Mvc.NavigationContext, 1, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Family, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Execute", WootzJs.Mvc.Mvc.Controller.prototype.Execute, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("application", WootzJs.Mvc.Mvc.MvcApplication, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("context", WootzJs.Mvc.Mvc.NavigationContext, 1, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_RouteData", WootzJs.Mvc.Mvc.Controller.prototype.get_RouteData, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Routes.RouteData, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("View", WootzJs.Mvc.Mvc.Controller.prototype.View, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.ViewResult, System.Reflection.MethodAttributes().Family, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("View$1", WootzJs.Mvc.Mvc.Controller.prototype.View$1, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("view", WootzJs.Mvc.Mvc.Views.View, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.ViewResult, System.Reflection.MethodAttributes().Family, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("FindView", WootzJs.Mvc.Mvc.Controller.prototype.FindView, $arrayinit([], System.Reflection.ParameterInfo), System.Type, System.Reflection.MethodAttributes().Family, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Mvc.Mvc.Controller.prototype.$ctor, $arrayinit([], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.PropertyInfo.prototype.$ctor.$new("ControllerContext", WootzJs.Mvc.Mvc.ControllerContext, System.Reflection.MethodInfo.prototype.$ctor.$new("get_ControllerContext", WootzJs.Mvc.Mvc.Controller.prototype.get_ControllerContext, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.ControllerContext, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_ControllerContext", WootzJs.Mvc.Mvc.Controller.prototype.set_ControllerContext, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.ControllerContext, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Private, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("NavigationContext", WootzJs.Mvc.Mvc.NavigationContext, System.Reflection.MethodInfo.prototype.$ctor.$new("get_NavigationContext", WootzJs.Mvc.Mvc.Controller.prototype.get_NavigationContext, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.NavigationContext, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_NavigationContext", WootzJs.Mvc.Mvc.Controller.prototype.set_NavigationContext, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.NavigationContext, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Private, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("ActionInvoker", WootzJs.Mvc.Mvc.IActionInvoker, System.Reflection.MethodInfo.prototype.$ctor.$new("get_ActionInvoker", WootzJs.Mvc.Mvc.Controller.prototype.get_ActionInvoker, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.IActionInvoker, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_ActionInvoker", WootzJs.Mvc.Mvc.Controller.prototype.set_ActionInvoker, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.IActionInvoker, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Private, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("RouteData", WootzJs.Mvc.Mvc.Routes.RouteData, System.Reflection.MethodInfo.prototype.$ctor.$new("get_RouteData", WootzJs.Mvc.Mvc.Controller.prototype.get_RouteData, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Routes.RouteData, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), null, $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute))], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {};
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.$ControllerContext$k__BackingField = null;
    $p.get_ControllerContext = function() {return this.$ControllerContext$k__BackingField;};
    $p.set_ControllerContext = function(value) {this.$ControllerContext$k__BackingField = value;};
    $p.$NavigationContext$k__BackingField = null;
    $p.get_NavigationContext = function() {return this.$NavigationContext$k__BackingField;};
    $p.set_NavigationContext = function(value) {this.$NavigationContext$k__BackingField = value;};
    $p.$ActionInvoker$k__BackingField = null;
    $p.get_ActionInvoker = function() {return this.$ActionInvoker$k__BackingField;};
    $p.set_ActionInvoker = function(value) {this.$ActionInvoker$k__BackingField = value;};
    $p.Initialize = function(application, requestContext) {
        this.set_NavigationContext(requestContext);
        this.set_ActionInvoker(WootzJs.Mvc.Mvc.ControllerActionInvoker.prototype.$ctor.$new());
        this.set_ControllerContext((function() {
            var $obj$ = WootzJs.Mvc.Mvc.ControllerContext.prototype.$ctor.$new();
            $obj$.set_Application(application);
            $obj$.set_NavigationContext(this.get_NavigationContext());
            $obj$.set_Controller(this);
            return $obj$;
        }).call(this));
    };
    $p.Execute = function(application, context) {
        this.Initialize(application, context);
        var action = this.get_RouteData().get_Action();
        var view = ($cast(WootzJs.Mvc.Mvc.ViewResult, this.get_ActionInvoker().WootzJs$Mvc$Mvc$IActionInvoker$InvokeAction(this.get_ControllerContext(), action))).get_View();
        view.Initialize((function() {
            var $obj$ = WootzJs.Mvc.Mvc.ViewContext.prototype.$ctor.$new();
            $obj$.set_ControllerContext(this.get_ControllerContext());
            return $obj$;
        }).call(this));
        context.get_Response().set_View(view);
    };
    $p.get_RouteData = function() {
        return this.get_NavigationContext().get_Request().get_RouteData();
    };
    $p.View = function() {
        var viewType = this.FindView();
        var view = $cast(WootzJs.Mvc.Mvc.Views.View, System.Reflection.Activator.CreateInstance(viewType));
        return WootzJs.Mvc.Mvc.ViewResult.prototype.$ctor.$new(view);
    };
    $p.View$1 = function(view) {
        return WootzJs.Mvc.Mvc.ViewResult.prototype.$ctor.$new(view);
    };
    $p.FindView = function() {
        var fullName = this.GetType().get_FullName();
        var controllerNamespace = String.prototype.Substring.call(fullName, 0, fullName.lastIndexOf("."));
        var rootNamespace = WootzJs.Mvc.Mvc.MiscExtensions.ChopEnd(controllerNamespace, ".Controllers");
        var viewNamespace = rootNamespace + ".Views";
        var controllerName = this.GetType().get_Name();
        controllerName = WootzJs.Mvc.Mvc.MiscExtensions.ChopEnd(controllerName, "Controller");
        var controllerViewNamespace = viewNamespace + "." + controllerName;
        var action = this.get_ControllerContext().get_NavigationContext().get_Request().get_RouteData().get_Action().get_Name();
        var viewName = action;
        viewName = controllerViewNamespace + "." + viewName + "View";
        var type = this.GetType().get_Assembly().GetType$1(viewName);
        if (type == null)
            throw System.Exception.prototype.$ctor$1.$new(String.Format("No view found for {0}.{1} at {2}", [this.GetType().get_FullName(), action, viewName])).InternalInit(new Error());
        return type;
    };
}).call(null, WootzJs.Mvc.Mvc.Controller, WootzJs.Mvc.Mvc.Controller.prototype);
$WootzJs$Mvc$AssemblyTypes.push(WootzJs.Mvc.Mvc.Controller);
WootzJs.Mvc.Mvc.ControllerActionInvoker = $define("WootzJs.Mvc.Mvc.ControllerActionInvoker", System.Object);
(WootzJs.Mvc.Mvc.ControllerActionInvoker.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Mvc$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Mvc.Mvc.ControllerActionInvoker";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("ControllerActionInvoker", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Mvc.Mvc.ControllerActionInvoker", WootzJs.Mvc.Mvc.ControllerActionInvoker, System.Object, $arrayinit([WootzJs.Mvc.Mvc.IActionInvoker], System.Type), $arrayinit([], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("InvokeAction", WootzJs.Mvc.Mvc.ControllerActionInvoker.prototype.InvokeAction, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("context", WootzJs.Mvc.Mvc.ControllerContext, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("action", System.Reflection.MethodInfo, 1, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.ActionResult, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Mvc.Mvc.ControllerActionInvoker.prototype.$ctor, $arrayinit([], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {};
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.InvokeAction = function(context, action) {
        return $cast(WootzJs.Mvc.Mvc.ActionResult, action.Invoke(context.get_Controller(), $arrayinit(new Array(0), System.Object)));
    };
    $p.WootzJs$Mvc$Mvc$IActionInvoker$InvokeAction = $p.InvokeAction;
}).call(null, WootzJs.Mvc.Mvc.ControllerActionInvoker, WootzJs.Mvc.Mvc.ControllerActionInvoker.prototype);
$WootzJs$Mvc$AssemblyTypes.push(WootzJs.Mvc.Mvc.ControllerActionInvoker);
WootzJs.Mvc.Mvc.ControllerContext = $define("WootzJs.Mvc.Mvc.ControllerContext", System.Object);
(WootzJs.Mvc.Mvc.ControllerContext.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Mvc$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Mvc.Mvc.ControllerContext";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("ControllerContext", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Mvc.Mvc.ControllerContext", WootzJs.Mvc.Mvc.ControllerContext, System.Object, $arrayinit([], System.Type), $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("$Application$k__BackingField", WootzJs.Mvc.Mvc.MvcApplication, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("$NavigationContext$k__BackingField", WootzJs.Mvc.Mvc.NavigationContext, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("$Controller$k__BackingField", WootzJs.Mvc.Mvc.Controller, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("get_Application", WootzJs.Mvc.Mvc.ControllerContext.prototype.get_Application, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.MvcApplication, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Application", WootzJs.Mvc.Mvc.ControllerContext.prototype.set_Application, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.MvcApplication, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_NavigationContext", WootzJs.Mvc.Mvc.ControllerContext.prototype.get_NavigationContext, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.NavigationContext, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_NavigationContext", WootzJs.Mvc.Mvc.ControllerContext.prototype.set_NavigationContext, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.NavigationContext, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_Controller", WootzJs.Mvc.Mvc.ControllerContext.prototype.get_Controller, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Controller, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Controller", WootzJs.Mvc.Mvc.ControllerContext.prototype.set_Controller, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Controller, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Mvc.Mvc.ControllerContext.prototype.$ctor, $arrayinit([], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.PropertyInfo.prototype.$ctor.$new("Application", WootzJs.Mvc.Mvc.MvcApplication, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Application", WootzJs.Mvc.Mvc.ControllerContext.prototype.get_Application, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.MvcApplication, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Application", WootzJs.Mvc.Mvc.ControllerContext.prototype.set_Application, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.MvcApplication, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("NavigationContext", WootzJs.Mvc.Mvc.NavigationContext, System.Reflection.MethodInfo.prototype.$ctor.$new("get_NavigationContext", WootzJs.Mvc.Mvc.ControllerContext.prototype.get_NavigationContext, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.NavigationContext, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_NavigationContext", WootzJs.Mvc.Mvc.ControllerContext.prototype.set_NavigationContext, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.NavigationContext, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("Controller", WootzJs.Mvc.Mvc.Controller, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Controller", WootzJs.Mvc.Mvc.ControllerContext.prototype.get_Controller, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Controller, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Controller", WootzJs.Mvc.Mvc.ControllerContext.prototype.set_Controller, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Controller, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute))], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {};
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.$Application$k__BackingField = null;
    $p.get_Application = function() {return this.$Application$k__BackingField;};
    $p.set_Application = function(value) {this.$Application$k__BackingField = value;};
    $p.$NavigationContext$k__BackingField = null;
    $p.get_NavigationContext = function() {return this.$NavigationContext$k__BackingField;};
    $p.set_NavigationContext = function(value) {this.$NavigationContext$k__BackingField = value;};
    $p.$Controller$k__BackingField = null;
    $p.get_Controller = function() {return this.$Controller$k__BackingField;};
    $p.set_Controller = function(value) {this.$Controller$k__BackingField = value;};
}).call(null, WootzJs.Mvc.Mvc.ControllerContext, WootzJs.Mvc.Mvc.ControllerContext.prototype);
$WootzJs$Mvc$AssemblyTypes.push(WootzJs.Mvc.Mvc.ControllerContext);
WootzJs.Mvc.Mvc.DefaultAttribute = $define("WootzJs.Mvc.Mvc.DefaultAttribute", System.Attribute);
(WootzJs.Mvc.Mvc.DefaultAttribute.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Mvc$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Attribute;
    $p.$typeName = "WootzJs.Mvc.Mvc.DefaultAttribute";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("DefaultAttribute", $arrayinit([System.AttributeUsageAttribute.prototype.$ctor.$new(68)], System.Attribute));this.$type.Init("WootzJs.Mvc.Mvc.DefaultAttribute", WootzJs.Mvc.Mvc.DefaultAttribute, System.Attribute, $arrayinit([], System.Type), $arrayinit([], System.Reflection.FieldInfo), $arrayinit([], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Mvc.Mvc.DefaultAttribute.prototype.$ctor, $arrayinit([], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {};
    $p.$ctor = function() {
        System.Attribute.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
}).call(null, WootzJs.Mvc.Mvc.DefaultAttribute, WootzJs.Mvc.Mvc.DefaultAttribute.prototype);
$WootzJs$Mvc$AssemblyTypes.push(WootzJs.Mvc.Mvc.DefaultAttribute);
WootzJs.Mvc.Mvc.DefaultControllerFactory = $define("WootzJs.Mvc.Mvc.DefaultControllerFactory", System.Object);
(WootzJs.Mvc.Mvc.DefaultControllerFactory.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Mvc$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Mvc.Mvc.DefaultControllerFactory";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("DefaultControllerFactory", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Mvc.Mvc.DefaultControllerFactory", WootzJs.Mvc.Mvc.DefaultControllerFactory, System.Object, $arrayinit([WootzJs.Mvc.Mvc.IControllerFactory], System.Type), $arrayinit([], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("CreateController", WootzJs.Mvc.Mvc.DefaultControllerFactory.prototype.CreateController, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("context", WootzJs.Mvc.Mvc.NavigationContext, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Controller, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Mvc.Mvc.DefaultControllerFactory.prototype.$ctor, $arrayinit([], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {};
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.CreateController = function(context) {
        var controllerType = $cast(System.Type, context.get_Request().get_RouteData().get_Item(WootzJs.Mvc.Mvc.Routes.RouteData().ControllerKey));
        return $cast(WootzJs.Mvc.Mvc.Controller, System.Reflection.Activator.CreateInstance(controllerType));
    };
    $p.WootzJs$Mvc$Mvc$IControllerFactory$CreateController = $p.CreateController;
}).call(null, WootzJs.Mvc.Mvc.DefaultControllerFactory, WootzJs.Mvc.Mvc.DefaultControllerFactory.prototype);
$WootzJs$Mvc$AssemblyTypes.push(WootzJs.Mvc.Mvc.DefaultControllerFactory);
WootzJs.Mvc.Mvc.HttpPostAttribute = $define("WootzJs.Mvc.Mvc.HttpPostAttribute", System.Attribute);
(WootzJs.Mvc.Mvc.HttpPostAttribute.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Mvc$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Attribute;
    $p.$typeName = "WootzJs.Mvc.Mvc.HttpPostAttribute";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("HttpPostAttribute", $arrayinit([System.AttributeUsageAttribute.prototype.$ctor.$new(64)], System.Attribute));this.$type.Init("WootzJs.Mvc.Mvc.HttpPostAttribute", WootzJs.Mvc.Mvc.HttpPostAttribute, System.Attribute, $arrayinit([], System.Type), $arrayinit([], System.Reflection.FieldInfo), $arrayinit([], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Mvc.Mvc.HttpPostAttribute.prototype.$ctor, $arrayinit([], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {};
    $p.$ctor = function() {
        System.Attribute.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
}).call(null, WootzJs.Mvc.Mvc.HttpPostAttribute, WootzJs.Mvc.Mvc.HttpPostAttribute.prototype);
$WootzJs$Mvc$AssemblyTypes.push(WootzJs.Mvc.Mvc.HttpPostAttribute);
WootzJs.Mvc.Mvc.IActionInvoker = $define("WootzJs.Mvc.Mvc.IActionInvoker", System.Object);
(WootzJs.Mvc.Mvc.IActionInvoker.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Mvc$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Mvc.Mvc.IActionInvoker";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("IActionInvoker", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Mvc.Mvc.IActionInvoker", WootzJs.Mvc.Mvc.IActionInvoker, null, $arrayinit([], System.Type), $arrayinit([], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("WootzJs$Mvc$Mvc$IActionInvoker$InvokeAction", WootzJs.Mvc.Mvc.IActionInvoker.prototype.WootzJs$Mvc$Mvc$IActionInvoker$InvokeAction, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("context", WootzJs.Mvc.Mvc.ControllerContext, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("action", System.Reflection.MethodInfo, 1, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.ActionResult, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {};
    $p.WootzJs$Mvc$Mvc$IActionInvoker$InvokeAction = function(context, action) {};
}).call(null, WootzJs.Mvc.Mvc.IActionInvoker, WootzJs.Mvc.Mvc.IActionInvoker.prototype);
$WootzJs$Mvc$AssemblyTypes.push(WootzJs.Mvc.Mvc.IActionInvoker);
WootzJs.Mvc.Mvc.IControllerFactory = $define("WootzJs.Mvc.Mvc.IControllerFactory", System.Object);
(WootzJs.Mvc.Mvc.IControllerFactory.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Mvc$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Mvc.Mvc.IControllerFactory";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("IControllerFactory", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Mvc.Mvc.IControllerFactory", WootzJs.Mvc.Mvc.IControllerFactory, null, $arrayinit([], System.Type), $arrayinit([], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("WootzJs$Mvc$Mvc$IControllerFactory$CreateController", WootzJs.Mvc.Mvc.IControllerFactory.prototype.WootzJs$Mvc$Mvc$IControllerFactory$CreateController, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("request", WootzJs.Mvc.Mvc.NavigationContext, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Controller, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {};
    $p.WootzJs$Mvc$Mvc$IControllerFactory$CreateController = function(request) {};
}).call(null, WootzJs.Mvc.Mvc.IControllerFactory, WootzJs.Mvc.Mvc.IControllerFactory.prototype);
$WootzJs$Mvc$AssemblyTypes.push(WootzJs.Mvc.Mvc.IControllerFactory);
WootzJs.Mvc.Mvc.MvcApplication = $define("WootzJs.Mvc.Mvc.MvcApplication", System.Object);
(WootzJs.Mvc.Mvc.MvcApplication.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Mvc$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Mvc.Mvc.MvcApplication";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("MvcApplication", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Mvc.Mvc.MvcApplication", WootzJs.Mvc.Mvc.MvcApplication, System.Object, $arrayinit([], System.Type), $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("$Host$k__BackingField", String, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("$Port$k__BackingField", String, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("$Scheme$k__BackingField", String, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("$ControllerFactory$k__BackingField", WootzJs.Mvc.Mvc.IControllerFactory, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("routeTree", WootzJs.Mvc.Mvc.Routes.RouteTree, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("view", WootzJs.Mvc.Mvc.Views.View, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("html", WootzJs.Mvc.Mvc.Views.HtmlControl, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("body", WootzJs.Mvc.Mvc.Views.HtmlControl, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("initialPath", String, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("currentPath", String, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("get_Host", WootzJs.Mvc.Mvc.MvcApplication.prototype.get_Host, $arrayinit([], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Host", WootzJs.Mvc.Mvc.MvcApplication.prototype.set_Host, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", String, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_Port", WootzJs.Mvc.Mvc.MvcApplication.prototype.get_Port, $arrayinit([], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Port", WootzJs.Mvc.Mvc.MvcApplication.prototype.set_Port, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", String, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_Scheme", WootzJs.Mvc.Mvc.MvcApplication.prototype.get_Scheme, $arrayinit([], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Scheme", WootzJs.Mvc.Mvc.MvcApplication.prototype.set_Scheme, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", String, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_ControllerFactory", WootzJs.Mvc.Mvc.MvcApplication.prototype.get_ControllerFactory, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.IControllerFactory, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_ControllerFactory", WootzJs.Mvc.Mvc.MvcApplication.prototype.set_ControllerFactory, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.IControllerFactory, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Family, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_Html", WootzJs.Mvc.Mvc.MvcApplication.prototype.get_Html, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.HtmlControl, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_Body", WootzJs.Mvc.Mvc.MvcApplication.prototype.get_Body, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.HtmlControl, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Start", WootzJs.Mvc.Mvc.MvcApplication.prototype.Start, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("assembly", System.Reflection.Assembly, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("OnStarted", WootzJs.Mvc.Mvc.MvcApplication.prototype.OnStarted, $arrayinit([], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Family, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("OnPopState", WootzJs.Mvc.Mvc.MvcApplication.prototype.OnPopState, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("evt", Event, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Private, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Open", WootzJs.Mvc.Mvc.MvcApplication.prototype.Open, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("url", String, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Open$1", WootzJs.Mvc.Mvc.MvcApplication.prototype.Open$1, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("url", String, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("pushState", System.Boolean, 1, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("CreateNavigationContext", WootzJs.Mvc.Mvc.MvcApplication.prototype.CreateNavigationContext, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("path", String, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("queryString", String, 1, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.NavigationContext, System.Reflection.MethodAttributes().Private, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Execute", WootzJs.Mvc.Mvc.MvcApplication.prototype.Execute, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("path", String, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("queryString", String, 1, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.View, System.Reflection.MethodAttributes().Family, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Mvc.Mvc.MvcApplication.prototype.$ctor, $arrayinit([], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.PropertyInfo.prototype.$ctor.$new("Host", String, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Host", WootzJs.Mvc.Mvc.MvcApplication.prototype.get_Host, $arrayinit([], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Host", WootzJs.Mvc.Mvc.MvcApplication.prototype.set_Host, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", String, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("Port", String, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Port", WootzJs.Mvc.Mvc.MvcApplication.prototype.get_Port, $arrayinit([], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Port", WootzJs.Mvc.Mvc.MvcApplication.prototype.set_Port, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", String, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("Scheme", String, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Scheme", WootzJs.Mvc.Mvc.MvcApplication.prototype.get_Scheme, $arrayinit([], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Scheme", WootzJs.Mvc.Mvc.MvcApplication.prototype.set_Scheme, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", String, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("ControllerFactory", WootzJs.Mvc.Mvc.IControllerFactory, System.Reflection.MethodInfo.prototype.$ctor.$new("get_ControllerFactory", WootzJs.Mvc.Mvc.MvcApplication.prototype.get_ControllerFactory, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.IControllerFactory, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_ControllerFactory", WootzJs.Mvc.Mvc.MvcApplication.prototype.set_ControllerFactory, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.IControllerFactory, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Family, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("Html", WootzJs.Mvc.Mvc.Views.HtmlControl, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Html", WootzJs.Mvc.Mvc.MvcApplication.prototype.get_Html, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.HtmlControl, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), null, $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("Body", WootzJs.Mvc.Mvc.Views.HtmlControl, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Body", WootzJs.Mvc.Mvc.MvcApplication.prototype.get_Body, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.HtmlControl, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), null, $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute))], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {};
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
        this.html = WootzJs.Mvc.Mvc.Views.HtmlControl.prototype.$ctor.$new(WootzJs.Web.DocumentExtensions.GetElementByTagName(WootzJs.Web.Browser().get_Document(), "html"));
        this.body = WootzJs.Mvc.Mvc.Views.HtmlControl.prototype.$ctor.$new(WootzJs.Web.DocumentExtensions.GetElementByTagName(WootzJs.Web.Browser().get_Document(), "body"));
        this.initialPath = WootzJs.Web.Browser().get_Window().location.pathname;
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.$Host$k__BackingField = null;
    $p.get_Host = function() {return this.$Host$k__BackingField;};
    $p.set_Host = function(value) {this.$Host$k__BackingField = value;};
    $p.$Port$k__BackingField = null;
    $p.get_Port = function() {return this.$Port$k__BackingField;};
    $p.set_Port = function(value) {this.$Port$k__BackingField = value;};
    $p.$Scheme$k__BackingField = null;
    $p.get_Scheme = function() {return this.$Scheme$k__BackingField;};
    $p.set_Scheme = function(value) {this.$Scheme$k__BackingField = value;};
    $p.$ControllerFactory$k__BackingField = null;
    $p.get_ControllerFactory = function() {return this.$ControllerFactory$k__BackingField;};
    $p.set_ControllerFactory = function(value) {this.$ControllerFactory$k__BackingField = value;};
    $p.routeTree = null;
    $p.view = null;
    $p.html = null;
    $p.body = null;
    $p.initialPath = null;
    $p.currentPath = null;
    $p.get_Html = function() {
        return this.html;
    };
    $p.get_Body = function() {
        return this.body;
    };
    $p.Start = function(assembly) {
        this.set_Host(WootzJs.Web.Browser().get_Window().location.host);
        this.set_Port(WootzJs.Web.Browser().get_Window().location.port);
        this.set_Scheme(WootzJs.Web.Browser().get_Window().location.protocol);
        WootzJs.Web.Browser().get_Window().addEventListener("onpopstate", $delegate(this, System.Action$1$(Event), function(evt) {
            return this.OnPopState($cast(Event, evt));
        }));
        var path = WootzJs.Web.Browser().get_Window().location.pathname;
        System.Console.WriteLine$1(path);
        this.set_ControllerFactory(WootzJs.Mvc.Mvc.DefaultControllerFactory.prototype.$ctor.$new());
        var routeGenerator = WootzJs.Mvc.Mvc.Routes.RouteGenerator.prototype.$ctor.$new();
        this.routeTree = routeGenerator.GenerateRoutes$1(assembly);
        this.Open$1(path + (!String.IsNullOrEmpty(WootzJs.Web.Browser().get_Window().location.search) ? "?" + WootzJs.Web.Browser().get_Window().location.search : ""), false);
        this.OnStarted();
    };
    $p.OnStarted = function() {};
    $p.OnPopState = function(evt) {
        var path = $cast(String, evt.state) || this.initialPath;
        if (path != this.currentPath)
            this.Open$1(path, false);
    };
    $p.Open = function(url) {
        this.Open$1(url, true);
    };
    $p.Open$1 = function(url, pushState) {
        var parts = String.prototype.Split.call(url, ["?"]);
        var path = parts[0];
        var queryString = url.length > 1 ? parts[1] : null;
        this.currentPath = path;
        var view = this.Execute(path, queryString);
        if (pushState)
            WootzJs.Web.Browser().get_Window().history.pushState(url, view.get_Title(), url);
        if (WootzJs.Mvc.Mvc.Views.Layout.$GetType().IsInstanceOfType(this.view) && view.get_LayoutType() != null) {
            var layout = $cast(WootzJs.Mvc.Mvc.Views.Layout, this.view);
            var container = layout.FindLayout(view.get_LayoutType());
            container.AddView(view);
        }
        else {
            if (this.view != null)
                this.body.Remove$1(this.view.get_Content());
            var rootView = view.GetRootView();
            this.body.Add$1(rootView.get_Content());
            this.view = rootView;
        }
    };
    $p.CreateNavigationContext = function(path, queryString) {
        var queryStringDictionary = System.Collections.Generic.Dictionary$2$(String, String).prototype.$ctor.$new();
        if (queryString != null) {
            var parts = String.prototype.Split.call(queryString, $arrayinit(["&"], System.Char));
            {
                var $anon$1iterator = parts;
                var $anon$2enumerator = $anon$1iterator.System$Collections$IEnumerable$GetEnumerator();
                while ($anon$2enumerator.System$Collections$IEnumerator$MoveNext()) {
                    var part = $anon$2enumerator.System$Collections$IEnumerator$get_Current();
                    var pair = String.prototype.Split.call(part, $arrayinit(["="], System.Char));
                    var key = System.Web.HttpUtility.UrlDecode(pair[0]);
                    var value = System.Web.HttpUtility.UrlDecode(pair[1]);
                    queryStringDictionary.set_Item(key, value);
                }
            }
        }
        var routeData = this.routeTree.Apply(path, "GET");
        var request = (function() {
            var $obj$ = WootzJs.Mvc.Mvc.NavigationRequest.prototype.$ctor.$new();
            $obj$.set_Path(path);
            $obj$.set_QueryString(queryStringDictionary);
            $obj$.set_RouteData(routeData);
            return $obj$;
        }).call(this);
        var response = WootzJs.Mvc.Mvc.NavigationResponse.prototype.$ctor.$new();
        var navigationContext = (function() {
            var $obj$ = WootzJs.Mvc.Mvc.NavigationContext.prototype.$ctor.$new();
            $obj$.set_Request(request);
            $obj$.set_Response(response);
            return $obj$;
        }).call(this);
        return navigationContext;
    };
    $p.Execute = function(path, queryString) {
        var context = this.CreateNavigationContext(path, queryString);
        var controller = this.get_ControllerFactory().WootzJs$Mvc$Mvc$IControllerFactory$CreateController(context);
        controller.Execute(this, context);
        return context.get_Response().get_View();
    };
}).call(null, WootzJs.Mvc.Mvc.MvcApplication, WootzJs.Mvc.Mvc.MvcApplication.prototype);
$WootzJs$Mvc$AssemblyTypes.push(WootzJs.Mvc.Mvc.MvcApplication);
WootzJs.Mvc.Mvc.NavigationContext = $define("WootzJs.Mvc.Mvc.NavigationContext", System.Object);
(WootzJs.Mvc.Mvc.NavigationContext.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Mvc$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Mvc.Mvc.NavigationContext";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("NavigationContext", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Mvc.Mvc.NavigationContext", WootzJs.Mvc.Mvc.NavigationContext, System.Object, $arrayinit([], System.Type), $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("$Request$k__BackingField", WootzJs.Mvc.Mvc.NavigationRequest, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("$Response$k__BackingField", WootzJs.Mvc.Mvc.NavigationResponse, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("get_Request", WootzJs.Mvc.Mvc.NavigationContext.prototype.get_Request, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.NavigationRequest, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Request", WootzJs.Mvc.Mvc.NavigationContext.prototype.set_Request, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.NavigationRequest, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_Response", WootzJs.Mvc.Mvc.NavigationContext.prototype.get_Response, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.NavigationResponse, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Response", WootzJs.Mvc.Mvc.NavigationContext.prototype.set_Response, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.NavigationResponse, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Mvc.Mvc.NavigationContext.prototype.$ctor, $arrayinit([], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.PropertyInfo.prototype.$ctor.$new("Request", WootzJs.Mvc.Mvc.NavigationRequest, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Request", WootzJs.Mvc.Mvc.NavigationContext.prototype.get_Request, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.NavigationRequest, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Request", WootzJs.Mvc.Mvc.NavigationContext.prototype.set_Request, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.NavigationRequest, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("Response", WootzJs.Mvc.Mvc.NavigationResponse, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Response", WootzJs.Mvc.Mvc.NavigationContext.prototype.get_Response, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.NavigationResponse, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Response", WootzJs.Mvc.Mvc.NavigationContext.prototype.set_Response, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.NavigationResponse, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute))], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {};
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.$Request$k__BackingField = null;
    $p.get_Request = function() {return this.$Request$k__BackingField;};
    $p.set_Request = function(value) {this.$Request$k__BackingField = value;};
    $p.$Response$k__BackingField = null;
    $p.get_Response = function() {return this.$Response$k__BackingField;};
    $p.set_Response = function(value) {this.$Response$k__BackingField = value;};
}).call(null, WootzJs.Mvc.Mvc.NavigationContext, WootzJs.Mvc.Mvc.NavigationContext.prototype);
$WootzJs$Mvc$AssemblyTypes.push(WootzJs.Mvc.Mvc.NavigationContext);
WootzJs.Mvc.Mvc.NavigationRequest = $define("WootzJs.Mvc.Mvc.NavigationRequest", System.Object);
(WootzJs.Mvc.Mvc.NavigationRequest.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Mvc$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Mvc.Mvc.NavigationRequest";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("NavigationRequest", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Mvc.Mvc.NavigationRequest", WootzJs.Mvc.Mvc.NavigationRequest, System.Object, $arrayinit([], System.Type), $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("$Path$k__BackingField", String, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("$QueryString$k__BackingField", System.Collections.Generic.Dictionary$2, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("$RouteData$k__BackingField", WootzJs.Mvc.Mvc.Routes.RouteData, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("get_Path", WootzJs.Mvc.Mvc.NavigationRequest.prototype.get_Path, $arrayinit([], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Path", WootzJs.Mvc.Mvc.NavigationRequest.prototype.set_Path, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", String, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_QueryString", WootzJs.Mvc.Mvc.NavigationRequest.prototype.get_QueryString, $arrayinit([], System.Reflection.ParameterInfo), System.Collections.Generic.Dictionary$2, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_QueryString", WootzJs.Mvc.Mvc.NavigationRequest.prototype.set_QueryString, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Collections.Generic.Dictionary$2, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_RouteData", WootzJs.Mvc.Mvc.NavigationRequest.prototype.get_RouteData, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Routes.RouteData, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_RouteData", WootzJs.Mvc.Mvc.NavigationRequest.prototype.set_RouteData, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Routes.RouteData, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Mvc.Mvc.NavigationRequest.prototype.$ctor, $arrayinit([], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.PropertyInfo.prototype.$ctor.$new("Path", String, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Path", WootzJs.Mvc.Mvc.NavigationRequest.prototype.get_Path, $arrayinit([], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Path", WootzJs.Mvc.Mvc.NavigationRequest.prototype.set_Path, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", String, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("QueryString", System.Collections.Generic.Dictionary$2, System.Reflection.MethodInfo.prototype.$ctor.$new("get_QueryString", WootzJs.Mvc.Mvc.NavigationRequest.prototype.get_QueryString, $arrayinit([], System.Reflection.ParameterInfo), System.Collections.Generic.Dictionary$2, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_QueryString", WootzJs.Mvc.Mvc.NavigationRequest.prototype.set_QueryString, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Collections.Generic.Dictionary$2, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("RouteData", WootzJs.Mvc.Mvc.Routes.RouteData, System.Reflection.MethodInfo.prototype.$ctor.$new("get_RouteData", WootzJs.Mvc.Mvc.NavigationRequest.prototype.get_RouteData, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Routes.RouteData, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_RouteData", WootzJs.Mvc.Mvc.NavigationRequest.prototype.set_RouteData, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Routes.RouteData, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute))], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {};
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.$Path$k__BackingField = null;
    $p.get_Path = function() {return this.$Path$k__BackingField;};
    $p.set_Path = function(value) {this.$Path$k__BackingField = value;};
    $p.$QueryString$k__BackingField = null;
    $p.get_QueryString = function() {return this.$QueryString$k__BackingField;};
    $p.set_QueryString = function(value) {this.$QueryString$k__BackingField = value;};
    $p.$RouteData$k__BackingField = null;
    $p.get_RouteData = function() {return this.$RouteData$k__BackingField;};
    $p.set_RouteData = function(value) {this.$RouteData$k__BackingField = value;};
}).call(null, WootzJs.Mvc.Mvc.NavigationRequest, WootzJs.Mvc.Mvc.NavigationRequest.prototype);
$WootzJs$Mvc$AssemblyTypes.push(WootzJs.Mvc.Mvc.NavigationRequest);
WootzJs.Mvc.Mvc.NavigationResponse = $define("WootzJs.Mvc.Mvc.NavigationResponse", System.Object);
(WootzJs.Mvc.Mvc.NavigationResponse.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Mvc$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Mvc.Mvc.NavigationResponse";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("NavigationResponse", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Mvc.Mvc.NavigationResponse", WootzJs.Mvc.Mvc.NavigationResponse, System.Object, $arrayinit([], System.Type), $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("$View$k__BackingField", WootzJs.Mvc.Mvc.Views.View, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("get_View", WootzJs.Mvc.Mvc.NavigationResponse.prototype.get_View, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.View, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_View", WootzJs.Mvc.Mvc.NavigationResponse.prototype.set_View, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.View, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Mvc.Mvc.NavigationResponse.prototype.$ctor, $arrayinit([], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.PropertyInfo.prototype.$ctor.$new("View", WootzJs.Mvc.Mvc.Views.View, System.Reflection.MethodInfo.prototype.$ctor.$new("get_View", WootzJs.Mvc.Mvc.NavigationResponse.prototype.get_View, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.View, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_View", WootzJs.Mvc.Mvc.NavigationResponse.prototype.set_View, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.View, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute))], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {};
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.$View$k__BackingField = null;
    $p.get_View = function() {return this.$View$k__BackingField;};
    $p.set_View = function(value) {this.$View$k__BackingField = value;};
}).call(null, WootzJs.Mvc.Mvc.NavigationResponse, WootzJs.Mvc.Mvc.NavigationResponse.prototype);
$WootzJs$Mvc$AssemblyTypes.push(WootzJs.Mvc.Mvc.NavigationResponse);
WootzJs.Mvc.Mvc.RouteAttribute = $define("WootzJs.Mvc.Mvc.RouteAttribute", System.Attribute);
(WootzJs.Mvc.Mvc.RouteAttribute.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Mvc$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Attribute;
    $p.$typeName = "WootzJs.Mvc.Mvc.RouteAttribute";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("RouteAttribute", $arrayinit([System.AttributeUsageAttribute.prototype.$ctor.$new(68)], System.Attribute));this.$type.Init("WootzJs.Mvc.Mvc.RouteAttribute", WootzJs.Mvc.Mvc.RouteAttribute, System.Attribute, $arrayinit([], System.Type), $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("$Value$k__BackingField", String, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("get_Value", WootzJs.Mvc.Mvc.RouteAttribute.prototype.get_Value, $arrayinit([], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Value", WootzJs.Mvc.Mvc.RouteAttribute.prototype.set_Value, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", String, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Mvc.Mvc.RouteAttribute.prototype.$ctor, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", String, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.PropertyInfo.prototype.$ctor.$new("Value", String, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Value", WootzJs.Mvc.Mvc.RouteAttribute.prototype.get_Value, $arrayinit([], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Value", WootzJs.Mvc.Mvc.RouteAttribute.prototype.set_Value, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", String, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute))], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {};
    $p.$Value$k__BackingField = null;
    $p.get_Value = function() {return this.$Value$k__BackingField;};
    $p.set_Value = function(value) {this.$Value$k__BackingField = value;};
    $p.$ctor = function(value) {
        System.Attribute.prototype.$ctor.call(this);
        this.set_Value(value);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function(value) {
        return new $p.$ctor.$type(this, value);
    };
}).call(null, WootzJs.Mvc.Mvc.RouteAttribute, WootzJs.Mvc.Mvc.RouteAttribute.prototype);
$WootzJs$Mvc$AssemblyTypes.push(WootzJs.Mvc.Mvc.RouteAttribute);
WootzJs.Mvc.Mvc.Routes.DuplicateRouteException = $define("WootzJs.Mvc.Mvc.Routes.DuplicateRouteException", System.Exception);
(WootzJs.Mvc.Mvc.Routes.DuplicateRouteException.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Mvc$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Exception;
    $p.$typeName = "WootzJs.Mvc.Mvc.Routes.DuplicateRouteException";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("DuplicateRouteException", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Mvc.Mvc.Routes.DuplicateRouteException", WootzJs.Mvc.Mvc.Routes.DuplicateRouteException, System.Exception, $arrayinit([], System.Type), $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("$ParentNode$k__BackingField", WootzJs.Mvc.Mvc.Routes.IRouteNode, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("$DuplicateNode$k__BackingField", WootzJs.Mvc.Mvc.Routes.IRouteNode, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("$DuplicatedNode$k__BackingField", WootzJs.Mvc.Mvc.Routes.IRouteNode, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("get_ParentNode", WootzJs.Mvc.Mvc.Routes.DuplicateRouteException.prototype.get_ParentNode, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Routes.IRouteNode, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_ParentNode", WootzJs.Mvc.Mvc.Routes.DuplicateRouteException.prototype.set_ParentNode, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Routes.IRouteNode, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_DuplicateNode", WootzJs.Mvc.Mvc.Routes.DuplicateRouteException.prototype.get_DuplicateNode, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Routes.IRouteNode, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_DuplicateNode", WootzJs.Mvc.Mvc.Routes.DuplicateRouteException.prototype.set_DuplicateNode, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Routes.IRouteNode, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_DuplicatedNode", WootzJs.Mvc.Mvc.Routes.DuplicateRouteException.prototype.get_DuplicatedNode, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Routes.IRouteNode, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_DuplicatedNode", WootzJs.Mvc.Mvc.Routes.DuplicateRouteException.prototype.set_DuplicatedNode, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Routes.IRouteNode, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Mvc.Mvc.Routes.DuplicateRouteException.prototype.$ctor, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("parentNode", WootzJs.Mvc.Mvc.Routes.IRouteNode, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("duplicateNode", WootzJs.Mvc.Mvc.Routes.IRouteNode, 1, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("duplicatedNode", WootzJs.Mvc.Mvc.Routes.IRouteNode, 2, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.PropertyInfo.prototype.$ctor.$new("ParentNode", WootzJs.Mvc.Mvc.Routes.IRouteNode, System.Reflection.MethodInfo.prototype.$ctor.$new("get_ParentNode", WootzJs.Mvc.Mvc.Routes.DuplicateRouteException.prototype.get_ParentNode, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Routes.IRouteNode, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_ParentNode", WootzJs.Mvc.Mvc.Routes.DuplicateRouteException.prototype.set_ParentNode, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Routes.IRouteNode, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("DuplicateNode", WootzJs.Mvc.Mvc.Routes.IRouteNode, System.Reflection.MethodInfo.prototype.$ctor.$new("get_DuplicateNode", WootzJs.Mvc.Mvc.Routes.DuplicateRouteException.prototype.get_DuplicateNode, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Routes.IRouteNode, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_DuplicateNode", WootzJs.Mvc.Mvc.Routes.DuplicateRouteException.prototype.set_DuplicateNode, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Routes.IRouteNode, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("DuplicatedNode", WootzJs.Mvc.Mvc.Routes.IRouteNode, System.Reflection.MethodInfo.prototype.$ctor.$new("get_DuplicatedNode", WootzJs.Mvc.Mvc.Routes.DuplicateRouteException.prototype.get_DuplicatedNode, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Routes.IRouteNode, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_DuplicatedNode", WootzJs.Mvc.Mvc.Routes.DuplicateRouteException.prototype.set_DuplicatedNode, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Routes.IRouteNode, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute))], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {};
    $p.$ParentNode$k__BackingField = null;
    $p.get_ParentNode = function() {return this.$ParentNode$k__BackingField;};
    $p.set_ParentNode = function(value) {this.$ParentNode$k__BackingField = value;};
    $p.$DuplicateNode$k__BackingField = null;
    $p.get_DuplicateNode = function() {return this.$DuplicateNode$k__BackingField;};
    $p.set_DuplicateNode = function(value) {this.$DuplicateNode$k__BackingField = value;};
    $p.$DuplicatedNode$k__BackingField = null;
    $p.get_DuplicatedNode = function() {return this.$DuplicatedNode$k__BackingField;};
    $p.set_DuplicatedNode = function(value) {this.$DuplicatedNode$k__BackingField = value;};
    $p.$ctor = function(parentNode, duplicateNode, duplicatedNode) {
        System.Exception.prototype.$ctor$1.call(this, "Cannot add node " + $safeToString(duplicateNode) + " to parent node " + $safeToString(parentNode) + ".  Child collides with existing node " + $safeToString(duplicatedNode));
        this.set_ParentNode(parentNode);
        this.set_DuplicateNode(duplicateNode);
        this.set_DuplicatedNode(duplicatedNode);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function(parentNode, duplicateNode, duplicatedNode) {
        return new $p.$ctor.$type(
            this, 
            parentNode, 
            duplicateNode, 
            duplicatedNode
        );
    };
}).call(null, WootzJs.Mvc.Mvc.Routes.DuplicateRouteException, WootzJs.Mvc.Mvc.Routes.DuplicateRouteException.prototype);
$WootzJs$Mvc$AssemblyTypes.push(WootzJs.Mvc.Mvc.Routes.DuplicateRouteException);
WootzJs.Mvc.Mvc.Routes.IRouteNode = $define("WootzJs.Mvc.Mvc.Routes.IRouteNode", System.Object);
(WootzJs.Mvc.Mvc.Routes.IRouteNode.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Mvc$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Mvc.Mvc.Routes.IRouteNode";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("IRouteNode", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Mvc.Mvc.Routes.IRouteNode", WootzJs.Mvc.Mvc.Routes.IRouteNode, null, $arrayinit([], System.Type), $arrayinit([], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("WootzJs$Mvc$Mvc$Routes$IRouteNode$get_Children", WootzJs.Mvc.Mvc.Routes.IRouteNode.prototype.WootzJs$Mvc$Mvc$Routes$IRouteNode$get_Children, $arrayinit([], System.Reflection.ParameterInfo), System.Collections.Generic.List$1, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("WootzJs$Mvc$Mvc$Routes$IRouteNode$FindDuplicate", WootzJs.Mvc.Mvc.Routes.IRouteNode.prototype.WootzJs$Mvc$Mvc$Routes$IRouteNode$FindDuplicate, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("parent", WootzJs.Mvc.Mvc.Routes.IRouteNode, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Routes.IRouteNode, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.MethodInfo), $arrayinit([System.Reflection.PropertyInfo.prototype.$ctor.$new("Children", System.Collections.Generic.List$1, System.Reflection.MethodInfo.prototype.$ctor.$new("WootzJs$Mvc$Mvc$Routes$IRouteNode$get_Children", WootzJs.Mvc.Mvc.Routes.IRouteNode.prototype.WootzJs$Mvc$Mvc$Routes$IRouteNode$get_Children, $arrayinit([], System.Reflection.ParameterInfo), System.Collections.Generic.List$1, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), null, $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute))], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {};
    $p.WootzJs$Mvc$Mvc$Routes$IRouteNode$get_Children = function() {};
    $p.WootzJs$Mvc$Mvc$Routes$IRouteNode$FindDuplicate = function(parent) {};
}).call(null, WootzJs.Mvc.Mvc.Routes.IRouteNode, WootzJs.Mvc.Mvc.Routes.IRouteNode.prototype);
$WootzJs$Mvc$AssemblyTypes.push(WootzJs.Mvc.Mvc.Routes.IRouteNode);
WootzJs.Mvc.Mvc.Routes.IRoutePart = $define("WootzJs.Mvc.Mvc.Routes.IRoutePart", System.Object);
(WootzJs.Mvc.Mvc.Routes.IRoutePart.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Mvc$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Mvc.Mvc.Routes.IRoutePart";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("IRoutePart", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Mvc.Mvc.Routes.IRoutePart", WootzJs.Mvc.Mvc.Routes.IRoutePart, null, $arrayinit([], System.Type), $arrayinit([], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("WootzJs$Mvc$Mvc$Routes$IRoutePart$AcceptPath", WootzJs.Mvc.Mvc.Routes.IRoutePart.prototype.WootzJs$Mvc$Mvc$Routes$IRoutePart$AcceptPath, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("path", WootzJs.Mvc.Mvc.Routes.RoutePath, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("httpMethod", String, 1, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Boolean, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("WootzJs$Mvc$Mvc$Routes$IRoutePart$ProcessData", WootzJs.Mvc.Mvc.Routes.IRoutePart.prototype.WootzJs$Mvc$Mvc$Routes$IRoutePart$ProcessData, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("path", WootzJs.Mvc.Mvc.Routes.RoutePath, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("data", WootzJs.Mvc.Mvc.Routes.RouteData, 1, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("WootzJs$Mvc$Mvc$Routes$IRoutePart$FindDuplicate", WootzJs.Mvc.Mvc.Routes.IRoutePart.prototype.WootzJs$Mvc$Mvc$Routes$IRoutePart$FindDuplicate, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("parts", System.Collections.Generic.IEnumerable$1, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Routes.IRoutePart, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("WootzJs$Mvc$Mvc$Routes$IRoutePart$get_RouteData", WootzJs.Mvc.Mvc.Routes.IRoutePart.prototype.WootzJs$Mvc$Mvc$Routes$IRoutePart$get_RouteData, $arrayinit([], System.Reflection.ParameterInfo), System.Collections.Generic.IDictionary$2, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.MethodInfo), $arrayinit([System.Reflection.PropertyInfo.prototype.$ctor.$new("RouteData", System.Collections.Generic.IDictionary$2, System.Reflection.MethodInfo.prototype.$ctor.$new("WootzJs$Mvc$Mvc$Routes$IRoutePart$get_RouteData", WootzJs.Mvc.Mvc.Routes.IRoutePart.prototype.WootzJs$Mvc$Mvc$Routes$IRoutePart$get_RouteData, $arrayinit([], System.Reflection.ParameterInfo), System.Collections.Generic.IDictionary$2, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), null, $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute))], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {};
    $p.WootzJs$Mvc$Mvc$Routes$IRoutePart$AcceptPath = function(path, httpMethod) {};
    $p.WootzJs$Mvc$Mvc$Routes$IRoutePart$ProcessData = function(path, data) {};
    $p.WootzJs$Mvc$Mvc$Routes$IRoutePart$FindDuplicate = function(parts) {};
    $p.WootzJs$Mvc$Mvc$Routes$IRoutePart$get_RouteData = function() {};
}).call(null, WootzJs.Mvc.Mvc.Routes.IRoutePart, WootzJs.Mvc.Mvc.Routes.IRoutePart.prototype);
$WootzJs$Mvc$AssemblyTypes.push(WootzJs.Mvc.Mvc.Routes.IRoutePart);
WootzJs.Mvc.Mvc.Routes.RouteBuilder = $define("WootzJs.Mvc.Mvc.Routes.RouteBuilder", System.Object);
(WootzJs.Mvc.Mvc.Routes.RouteBuilder.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Mvc$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Mvc.Mvc.Routes.RouteBuilder";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("RouteBuilder", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Mvc.Mvc.Routes.RouteBuilder", WootzJs.Mvc.Mvc.Routes.RouteBuilder, System.Object, $arrayinit([], System.Type), $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("parts", System.Collections.Generic.List$1, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("pinning", System.Collections.Generic.Stack$1, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("Pin", WootzJs.Mvc.Mvc.Routes.RouteBuilder.prototype.Pin, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Routes.RouteBuilder.Pinned, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Unpin", WootzJs.Mvc.Mvc.Routes.RouteBuilder.prototype.Unpin, $arrayinit([], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("ToArray", WootzJs.Mvc.Mvc.Routes.RouteBuilder.prototype.ToArray, $arrayinit([], System.Reflection.ParameterInfo), $array(WootzJs.Mvc.Mvc.Routes.IRoutePart), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Add", WootzJs.Mvc.Mvc.Routes.RouteBuilder.prototype.Add, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("part", WootzJs.Mvc.Mvc.Routes.IRoutePart, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Mvc.Mvc.Routes.RouteBuilder.prototype.$ctor, $arrayinit([], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {};
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
        this.parts = System.Collections.Generic.List$1$(WootzJs.Mvc.Mvc.Routes.IRoutePart).prototype.$ctor.$new();
        this.pinning = System.Collections.Generic.Stack$1$(System.Int32).prototype.$ctor.$new();
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.parts = null;
    $p.pinning = null;
    $p.Pin = function() {
        this.pinning.Push(this.parts.get_Count());
        return WootzJs.Mvc.Mvc.Routes.RouteBuilder.Pinned.prototype.$ctor.$new(this);
    };
    $p.Unpin = function() {
        var pin = this.pinning.Pop();
        while (this.parts.get_Count() > pin) {
            this.parts.RemoveAt(this.parts.get_Count() - 1);
        }
    };
    $p.ToArray = function() {
        return System.Linq.Enumerable.ToArray(WootzJs.Mvc.Mvc.Routes.IRoutePart, this.parts);
    };
    $p.Add = function(part) {
        this.parts.Add(part);
    };
    $t.Pinned = $define("WootzJs.Mvc.Mvc.Routes.RouteBuilder.Pinned", System.Object);
    ($t.Pinned.$TypeInitializer = function($t, $p) {
        $t.$GetAssembly = window.$WootzJs$Mvc$GetAssembly;
        $p.$type = $t;
        $t.$baseType = System.Object;
        $p.$typeName = "WootzJs.Mvc.Mvc.Routes.RouteBuilder.Pinned";
        $t.$typeName = $p.$typeName;
        $t.$GetType = function() {
            return System.Type._GetTypeFromTypeFunc(this);
        };
        $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("Pinned", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Mvc.Mvc.Routes.RouteBuilder.Pinned", WootzJs.Mvc.Mvc.Routes.RouteBuilder.Pinned, System.Object, $arrayinit([System.IDisposable], System.Type), $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("builder", WootzJs.Mvc.Mvc.Routes.RouteBuilder, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("accepted", System.Boolean, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("Accept", WootzJs.Mvc.Mvc.Routes.RouteBuilder.Pinned.prototype.Accept, $arrayinit([], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Dispose", WootzJs.Mvc.Mvc.Routes.RouteBuilder.Pinned.prototype.Dispose, $arrayinit([], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Mvc.Mvc.Routes.RouteBuilder.Pinned.prototype.$ctor, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("builder", WootzJs.Mvc.Mvc.Routes.RouteBuilder, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
        $t.$StaticInitializer = function() {};
        $p.builder = null;
        $p.accepted = false;
        $p.$ctor = function(builder) {
            System.Object.prototype.$ctor.call(this);
            this.builder = builder;
        };
        $p.$ctor.$type = $t;
        $p.$ctor.$new = function(builder) {
            return new $p.$ctor.$type(this, builder);
        };
        $p.Accept = function() {
            this.accepted = true;
        };
        $p.Dispose = function() {
            if (!this.accepted)
                this.builder.Unpin();
        };
        $p.System$IDisposable$Dispose = $p.Dispose;
    }).call($t, $t.Pinned, $t.Pinned.prototype);
    $WootzJs$Mvc$AssemblyTypes.push($t.Pinned);
}).call(null, WootzJs.Mvc.Mvc.Routes.RouteBuilder, WootzJs.Mvc.Mvc.Routes.RouteBuilder.prototype);
$WootzJs$Mvc$AssemblyTypes.push(WootzJs.Mvc.Mvc.Routes.RouteBuilder);
WootzJs.Mvc.Mvc.Routes.RouteData = $define("WootzJs.Mvc.Mvc.Routes.RouteData", System.Object);
(WootzJs.Mvc.Mvc.Routes.RouteData.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Mvc$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Mvc.Mvc.Routes.RouteData";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("RouteData", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Mvc.Mvc.Routes.RouteData", WootzJs.Mvc.Mvc.Routes.RouteData, System.Object, $arrayinit([], System.Type), $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("ControllerKey", String, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().Literal, "@controller", $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("ActionKey", String, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().Literal, "@action", $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("RequiredHttpMethodKey", String, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().Literal, "@requiredHttpMethod", $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("values", System.Collections.Generic.Dictionary$2, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("get_Item", WootzJs.Mvc.Mvc.Routes.RouteData.prototype.get_Item, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("key", String, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Object, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Item", WootzJs.Mvc.Mvc.Routes.RouteData.prototype.set_Item, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("key", String, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Object, 1, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_Action", WootzJs.Mvc.Mvc.Routes.RouteData.prototype.get_Action, $arrayinit([], System.Reflection.ParameterInfo), System.Reflection.MethodInfo, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_Controller", WootzJs.Mvc.Mvc.Routes.RouteData.prototype.get_Controller, $arrayinit([], System.Reflection.ParameterInfo), System.Type, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_RequiredHttpMethod", WootzJs.Mvc.Mvc.Routes.RouteData.prototype.get_RequiredHttpMethod, $arrayinit([], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Mvc.Mvc.Routes.RouteData.prototype.$ctor, $arrayinit([], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.PropertyInfo.prototype.$ctor.$new("this[]", System.Object, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Item", WootzJs.Mvc.Mvc.Routes.RouteData.prototype.get_Item, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("key", String, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Object, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Item", WootzJs.Mvc.Mvc.Routes.RouteData.prototype.set_Item, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("key", String, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Object, 1, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("key", String, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("Action", System.Reflection.MethodInfo, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Action", WootzJs.Mvc.Mvc.Routes.RouteData.prototype.get_Action, $arrayinit([], System.Reflection.ParameterInfo), System.Reflection.MethodInfo, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), null, $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("Controller", System.Type, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Controller", WootzJs.Mvc.Mvc.Routes.RouteData.prototype.get_Controller, $arrayinit([], System.Reflection.ParameterInfo), System.Type, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), null, $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("RequiredHttpMethod", String, System.Reflection.MethodInfo.prototype.$ctor.$new("get_RequiredHttpMethod", WootzJs.Mvc.Mvc.Routes.RouteData.prototype.get_RequiredHttpMethod, $arrayinit([], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), null, $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute))], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {
        WootzJs.Mvc.Mvc.Routes.RouteData.ControllerKey = "@controller";
        WootzJs.Mvc.Mvc.Routes.RouteData.ActionKey = "@action";
        WootzJs.Mvc.Mvc.Routes.RouteData.RequiredHttpMethodKey = "@requiredHttpMethod";
    };
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
        this.values = System.Collections.Generic.Dictionary$2$(String, System.Object).prototype.$ctor.$new();
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.ControllerKey = null;
    $p.ActionKey = null;
    $p.RequiredHttpMethodKey = null;
    $p.values = null;
    $p.get_Item = function(key) {
        return WootzJs.Mvc.Mvc.MiscExtensions.Get(
            String, 
            System.Object, 
            this.values, 
            key, 
            null
        );
    };
    $p.set_Item = function(key, value) {
        this.values.set_Item(key, value);
    };
    $p.get_Action = function() {
        return $cast(System.Reflection.MethodInfo, this.get_Item(WootzJs.Mvc.Mvc.Routes.RouteData().ActionKey));
    };
    $p.get_Controller = function() {
        return $cast(System.Type, this.get_Item(WootzJs.Mvc.Mvc.Routes.RouteData().ControllerKey));
    };
    $p.get_RequiredHttpMethod = function() {
        return $cast(String, this.get_Item(this.get_RequiredHttpMethod()));
    };
}).call(null, WootzJs.Mvc.Mvc.Routes.RouteData, WootzJs.Mvc.Mvc.Routes.RouteData.prototype);
$WootzJs$Mvc$AssemblyTypes.push(WootzJs.Mvc.Mvc.Routes.RouteData);
WootzJs.Mvc.Mvc.Routes.RouteDefault = $define("WootzJs.Mvc.Mvc.Routes.RouteDefault", WootzJs.Mvc.Mvc.Routes.RoutePart);
(WootzJs.Mvc.Mvc.Routes.RouteDefault.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Mvc$GetAssembly;
    $p.$type = $t;
    $t.$baseType = WootzJs.Mvc.Mvc.Routes.RoutePart;
    $p.$typeName = "WootzJs.Mvc.Mvc.Routes.RouteDefault";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("RouteDefault", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Mvc.Mvc.Routes.RouteDefault", WootzJs.Mvc.Mvc.Routes.RouteDefault, WootzJs.Mvc.Mvc.Routes.RoutePart, $arrayinit([WootzJs.Mvc.Mvc.Routes.IRoutePart], System.Type), $arrayinit([], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("IsDuplicate", WootzJs.Mvc.Mvc.Routes.RouteDefault.prototype.IsDuplicate, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("part", WootzJs.Mvc.Mvc.Routes.IRoutePart, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Boolean, System.Reflection.MethodAttributes().Family, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Accept", WootzJs.Mvc.Mvc.Routes.RouteDefault.prototype.Accept, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("path", WootzJs.Mvc.Mvc.Routes.RoutePath, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Boolean, System.Reflection.MethodAttributes().Family, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("ConsumePath", WootzJs.Mvc.Mvc.Routes.RouteDefault.prototype.ConsumePath, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("path", WootzJs.Mvc.Mvc.Routes.RoutePath, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Family, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("ToString", WootzJs.Mvc.Mvc.Routes.RouteDefault.prototype.ToString, $arrayinit([], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Mvc.Mvc.Routes.RouteDefault.prototype.$ctor, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("routeData", System.Collections.Generic.IDictionary$2, 0, System.Reflection.ParameterAttributes().HasDefault, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor$1", WootzJs.Mvc.Mvc.Routes.RouteDefault.prototype.$ctor$1, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("key", String, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Object, 1, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {};
    $p.$ctor = function(routeData) {
        WootzJs.Mvc.Mvc.Routes.RoutePart.prototype.$ctor.call(this, routeData);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function(routeData) {
        return new $p.$ctor.$type(this, routeData);
    };
    $p.$ctor$1 = function(key, value) {
        WootzJs.Mvc.Mvc.Routes.RoutePart.prototype.$ctor$1.call(this, key, value);
    };
    $p.$ctor$1.$type = $t;
    $p.$ctor$1.$new = function(key, value) {
        return new $p.$ctor$1.$type(this, key, value);
    };
    $p.IsDuplicate = function(part) {
        return WootzJs.Mvc.Mvc.Routes.RouteDefault.$GetType().IsInstanceOfType(part);
    };
    $p.Accept = function(path) {
        return path.get_Current() == null;
    };
    $p.ConsumePath = function(path) {};
    $p.ToString = function() {
        return "(default) " + WootzJs.Mvc.Mvc.Routes.RoutePart.prototype.ToString.call(this);
    };
}).call(null, WootzJs.Mvc.Mvc.Routes.RouteDefault, WootzJs.Mvc.Mvc.Routes.RouteDefault.prototype);
$WootzJs$Mvc$AssemblyTypes.push(WootzJs.Mvc.Mvc.Routes.RouteDefault);
WootzJs.Mvc.Mvc.Routes.RouteGenerator = $define("WootzJs.Mvc.Mvc.Routes.RouteGenerator", System.Object);
(WootzJs.Mvc.Mvc.Routes.RouteGenerator.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Mvc$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Mvc.Mvc.Routes.RouteGenerator";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("RouteGenerator", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Mvc.Mvc.Routes.RouteGenerator", WootzJs.Mvc.Mvc.Routes.RouteGenerator, System.Object, $arrayinit([], System.Type), $arrayinit([], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("GenerateRoutes$1", WootzJs.Mvc.Mvc.Routes.RouteGenerator.prototype.GenerateRoutes$1, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("assembly", System.Reflection.Assembly, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Routes.RouteTree, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("GenerateRoutes", WootzJs.Mvc.Mvc.Routes.RouteGenerator.prototype.GenerateRoutes, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("controllerTypes", System.Collections.Generic.IEnumerable$1, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Routes.RouteTree, System.Reflection.MethodAttributes().Private, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("GenerateRoutesForController", WootzJs.Mvc.Mvc.Routes.RouteGenerator.prototype.GenerateRoutesForController, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("routeTree", WootzJs.Mvc.Mvc.Routes.RouteTree, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("controllerType", System.Type, 1, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("GenerateRoutesForAction", WootzJs.Mvc.Mvc.Routes.RouteGenerator.prototype.GenerateRoutesForAction, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("routeTree", WootzJs.Mvc.Mvc.Routes.RouteTree, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("controllerType", System.Type, 1, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("parentNodes", System.Collections.Generic.List$1, 2, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("actionMethod", System.Reflection.MethodInfo, 3, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Private, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("AddNode", WootzJs.Mvc.Mvc.Routes.RouteGenerator.prototype.AddNode, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("parent", WootzJs.Mvc.Mvc.Routes.IRouteNode, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("child", WootzJs.Mvc.Mvc.Routes.RouteNode, 1, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Routes.RouteNode, System.Reflection.MethodAttributes().Private, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("GenerateDefaultRouteForController", WootzJs.Mvc.Mvc.Routes.RouteGenerator.prototype.GenerateDefaultRouteForController, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("controllerType", System.Type, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Private, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("GenerateDefaultRouteForAction", WootzJs.Mvc.Mvc.Routes.RouteGenerator.prototype.GenerateDefaultRouteForAction, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("actionMethod", System.Reflection.MethodInfo, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Private, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Mvc.Mvc.Routes.RouteGenerator.prototype.$ctor, $arrayinit([], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {};
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.GenerateRoutes$1 = function(assembly) {
        var controllerTypes = System.Linq.Enumerable.Where(System.Type, assembly.GetTypes(), $delegate(this, System.Func$2$(System.Type, System.Boolean), function(x) {
            return WootzJs.Mvc.Mvc.Controller.$GetType().IsAssignableFrom(x);
        }));
        return this.GenerateRoutes(controllerTypes);
    };
    $p.GenerateRoutes = function(controllerTypes) {
        var pathTree = WootzJs.Mvc.Mvc.Routes.RouteTree.prototype.$ctor.$new();
        {
            var $anon$1iterator = controllerTypes;
            var $anon$2enumerator = $anon$1iterator.System$Collections$IEnumerable$GetEnumerator();
            while ($anon$2enumerator.System$Collections$IEnumerator$MoveNext()) {
                var type = $anon$2enumerator.System$Collections$IEnumerator$get_Current();
                System.Console.WriteLine$1(type.get_FullName());
                this.GenerateRoutesForController(pathTree, type);
            }
        }
        return pathTree;
    };
    $p.GenerateRoutesForController = function(routeTree, controllerType) {
        var routeAttributes = controllerType.GetCustomAttributes$1(WootzJs.Mvc.Mvc.RouteAttribute.$GetType(), true);
        var routeAttribute = routeAttributes.length > 0 ? $cast(WootzJs.Mvc.Mvc.RouteAttribute, routeAttributes[0]) : null;
        var route;
        if (routeAttribute == null)
            route = this.GenerateDefaultRouteForController(controllerType);
        else
            route = routeAttribute.get_Value();
        var routePath = WootzJs.Mvc.Mvc.Routes.RoutePath.prototype.$ctor.$new(route);
        var currentNode = $cast(WootzJs.Mvc.Mvc.Routes.IRouteNode, routeTree);
        var leafNodes = System.Collections.Generic.List$1$(WootzJs.Mvc.Mvc.Routes.RouteNode).prototype.$ctor.$new();
        do {
            var nextNode = null;
            if (routePath.get_Current() != null) {
                var routePart = routePath.Consume();
                var part = WootzJs.Mvc.Mvc.Routes.RouteLiteral.prototype.$ctor.$new(routePart, true, null);
                nextNode = WootzJs.Mvc.Mvc.Routes.RouteNode.prototype.$ctor.$new(part);
                this.AddNode(currentNode, nextNode);
                if (routePath.get_Current() == null) {
                    part.get_RouteData().set_Item(WootzJs.Mvc.Mvc.Routes.RouteData().ControllerKey, controllerType);
                    leafNodes.Add(nextNode);
                }
            }
            if (routePath.get_Current() == null) {
                var defaultAttributes = controllerType.GetCustomAttributes$1(WootzJs.Mvc.Mvc.DefaultAttribute.$GetType(), true);
                if (defaultAttributes.length > 0) {
                    var defaultNode = WootzJs.Mvc.Mvc.Routes.RouteNode.prototype.$ctor.$new(WootzJs.Mvc.Mvc.Routes.RouteDefault.prototype.$ctor$1.$new(WootzJs.Mvc.Mvc.Routes.RouteData().ControllerKey, controllerType));
                    this.AddNode(currentNode, defaultNode);
                    leafNodes.Add(defaultNode);
                }
            }
            currentNode = nextNode;
        }
        while (routePath.get_Current() != null);
        {
            var $anon$1iterator = System.Linq.Enumerable.Where(System.Reflection.MethodInfo, controllerType.GetMethods(), $delegate(this, System.Func$2$(System.Reflection.MethodInfo, System.Boolean), function(x) {
                return x.get_IsPublic() && !x.get_IsStatic() && WootzJs.Mvc.Mvc.ActionResult.$GetType().IsAssignableFrom(x.get_ReturnType());
            }));
            var $anon$2enumerator = $anon$1iterator.System$Collections$IEnumerable$GetEnumerator();
            while ($anon$2enumerator.System$Collections$IEnumerator$MoveNext()) {
                var method = $anon$2enumerator.System$Collections$IEnumerator$get_Current();
                this.GenerateRoutesForAction(
                    routeTree, 
                    controllerType, 
                    leafNodes, 
                    method
                );
            }
        }
    };
    $p.GenerateRoutesForAction = function(routeTree, controllerType, parentNodes, actionMethod) {
        var routeAttributes = actionMethod.GetCustomAttributes$1(WootzJs.Mvc.Mvc.RouteAttribute.$GetType(), true);
        var routeAttribute = routeAttributes.length > 0 ? $cast(WootzJs.Mvc.Mvc.RouteAttribute, routeAttributes[0]) : null;
        var route;
        if (routeAttribute == null)
            route = this.GenerateDefaultRouteForAction(actionMethod);
        else
            route = routeAttribute.get_Value();
        var httpMethod = null;
        if (actionMethod.IsDefined(WootzJs.Mvc.Mvc.HttpPostAttribute.$GetType(), false)) {
            httpMethod = "POST";
        }
        var addToRoot = false;
        if (String.prototype.StartsWith.call(route, "/")) {
            addToRoot = true;
        }
        var effectiveNodes = addToRoot ? $arrayinit([$cast(WootzJs.Mvc.Mvc.Routes.IRouteNode, routeTree)], WootzJs.Mvc.Mvc.Routes.IRouteNode) : System.Linq.Enumerable.ToArray(WootzJs.Mvc.Mvc.Routes.RouteNode, parentNodes);
        {
            var $anon$1iterator = effectiveNodes;
            var $anon$2enumerator = $anon$1iterator.System$Collections$IEnumerable$GetEnumerator();
            while ($anon$2enumerator.System$Collections$IEnumerator$MoveNext())
                (function() {
                    var node = $anon$2enumerator.System$Collections$IEnumerator$get_Current();
                    var routePath = WootzJs.Mvc.Mvc.Routes.RoutePath.prototype.$ctor.$new(route);
                    var currentNode = node;
                    do
                        (function() {
                            var nextNode = null;
                            if (routePath.get_Current() != null) {
                                var part = routePath.Consume();
                                if (part == "@") {
                                    part = this.GenerateDefaultRouteForAction(actionMethod);
                                }
                                var routePart;
                                if (part == "*") {
                                    var parameter = System.Linq.Enumerable.Single(System.Reflection.ParameterInfo, actionMethod.GetParameters());
                                    routePart = WootzJs.Mvc.Mvc.Routes.RouteWildcard.prototype.$ctor.$new(parameter);
                                }
                                else
                                    if (String.prototype.StartsWith.call(part, "{") && String.prototype.EndsWith.call(part, "}")) {
                                        var id = WootzJs.Mvc.Mvc.MiscExtensions.ChopEnd(WootzJs.Mvc.Mvc.MiscExtensions.ChopStart(part, "{"), "}");
                                        var parameter = System.Linq.Enumerable.Single$1(System.Reflection.ParameterInfo, actionMethod.GetParameters(), $delegate(this, System.Func$2$(System.Reflection.ParameterInfo, System.Boolean), function(x) {
                                            return x.get_Name() == id;
                                        }));
                                        routePart = WootzJs.Mvc.Mvc.Routes.RouteVariable.prototype.$ctor.$new(routePath.get_Current() == null, parameter);
                                    }
                                    else {
                                        routePart = WootzJs.Mvc.Mvc.Routes.RouteLiteral.prototype.$ctor.$new(part, routePath.get_Current() == null, null);
                                    }
                                nextNode = WootzJs.Mvc.Mvc.Routes.RouteNode.prototype.$ctor.$new(routePart);
                                if (routePath.get_Current() == null) {
                                    routePart.get_RouteData().set_Item(WootzJs.Mvc.Mvc.Routes.RouteData().ActionKey, actionMethod);
                                    routePart.get_RouteData().set_Item(WootzJs.Mvc.Mvc.Routes.RouteData().ControllerKey, controllerType);
                                    if (httpMethod != null)
                                        routePart.get_RouteData().set_Item(WootzJs.Mvc.Mvc.Routes.RouteData().RequiredHttpMethodKey, httpMethod);
                                }
                                nextNode = this.AddNode(currentNode, nextNode);
                            }
                            if (routePath.get_Current() == null) {
                                if (actionMethod.IsDefined(WootzJs.Mvc.Mvc.DefaultAttribute.$GetType(), false))
                                    this.AddNode(currentNode, WootzJs.Mvc.Mvc.Routes.RouteNode.prototype.$ctor.$new(WootzJs.Mvc.Mvc.Routes.RouteDefault.prototype.$ctor$1.$new(WootzJs.Mvc.Mvc.Routes.RouteData().ActionKey, actionMethod)));
                            }
                            currentNode = nextNode;
                        }).call(this);
                    while (routePath.get_Current() != null);
                }).call(this);
        }
    };
    $p.AddNode = function(parent, child) {
        if (WootzJs.Mvc.Mvc.Routes.RouteLiteral.$GetType().IsInstanceOfType(child.get_Part())) {
            var routeLiteral = $cast(WootzJs.Mvc.Mvc.Routes.RouteLiteral, child.get_Part());
            if (!routeLiteral.get_IsTerminal()) {
                var commonChild = System.Linq.Enumerable.SingleOrDefault$1(WootzJs.Mvc.Mvc.Routes.RouteNode, parent.WootzJs$Mvc$Mvc$Routes$IRouteNode$get_Children(), $delegate(this, System.Func$2$(WootzJs.Mvc.Mvc.Routes.RouteNode, System.Boolean), function(x) {
                    return WootzJs.Mvc.Mvc.Routes.RouteLiteral.$GetType().IsInstanceOfType(x.get_Part()) && ($cast(WootzJs.Mvc.Mvc.Routes.RouteLiteral, x.get_Part())).get_Literal() == routeLiteral.get_Literal() && !($cast(WootzJs.Mvc.Mvc.Routes.RouteLiteral, x.get_Part())).get_IsTerminal();
                }));
                if (commonChild != null) {
                    return commonChild;
                }
            }
        }
        if (WootzJs.Mvc.Mvc.Routes.RouteVariable.$GetType().IsInstanceOfType(child.get_Part())) {
            var routeVariable = $cast(WootzJs.Mvc.Mvc.Routes.RouteVariable, child.get_Part());
            if (!routeVariable.get_IsTerminal()) {
                var commonChild = System.Linq.Enumerable.SingleOrDefault$1(WootzJs.Mvc.Mvc.Routes.RouteNode, parent.WootzJs$Mvc$Mvc$Routes$IRouteNode$get_Children(), $delegate(this, System.Func$2$(WootzJs.Mvc.Mvc.Routes.RouteNode, System.Boolean), function(x) {
                    return WootzJs.Mvc.Mvc.Routes.RouteVariable.$GetType().IsInstanceOfType(x.get_Part()) && !($cast(WootzJs.Mvc.Mvc.Routes.RouteVariable, x.get_Part())).get_IsTerminal();
                }));
                if (commonChild != null) {
                    return commonChild;
                }
            }
        }
        if (child.get_Part().WootzJs$Mvc$Mvc$Routes$IRoutePart$get_RouteData().System$Collections$Generic$IDictionary$2$ContainsKey(WootzJs.Mvc.Mvc.Routes.RouteData().RequiredHttpMethodKey) || WootzJs.Mvc.Mvc.Routes.RouteLiteral.$GetType().IsInstanceOfType(child.get_Part()))
            parent.WootzJs$Mvc$Mvc$Routes$IRouteNode$get_Children().Insert(0, child);
        else
            parent.WootzJs$Mvc$Mvc$Routes$IRouteNode$get_Children().Add(child);
        return child;
    };
    $p.GenerateDefaultRouteForController = function(controllerType) {
        var controllerName = WootzJs.Mvc.Mvc.MiscExtensions.ChopEnd(controllerType.get_Name(), "Controller");
        return controllerName;
    };
    $p.GenerateDefaultRouteForAction = function(actionMethod) {
        var builder = System.Text.StringBuilder.prototype.$ctor.$new();
        builder.Append$2(actionMethod.get_Name());
        return builder.ToString();
    };
}).call(null, WootzJs.Mvc.Mvc.Routes.RouteGenerator, WootzJs.Mvc.Mvc.Routes.RouteGenerator.prototype);
$WootzJs$Mvc$AssemblyTypes.push(WootzJs.Mvc.Mvc.Routes.RouteGenerator);
WootzJs.Mvc.Mvc.Routes.RouteLiteral = $define("WootzJs.Mvc.Mvc.Routes.RouteLiteral", WootzJs.Mvc.Mvc.Routes.RoutePart);
(WootzJs.Mvc.Mvc.Routes.RouteLiteral.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Mvc$GetAssembly;
    $p.$type = $t;
    $t.$baseType = WootzJs.Mvc.Mvc.Routes.RoutePart;
    $p.$typeName = "WootzJs.Mvc.Mvc.Routes.RouteLiteral";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("RouteLiteral", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Mvc.Mvc.Routes.RouteLiteral", WootzJs.Mvc.Mvc.Routes.RouteLiteral, WootzJs.Mvc.Mvc.Routes.RoutePart, $arrayinit([WootzJs.Mvc.Mvc.Routes.IRoutePart], System.Type), $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("$Literal$k__BackingField", String, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("$IsTerminal$k__BackingField", System.Boolean, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("get_Literal", WootzJs.Mvc.Mvc.Routes.RouteLiteral.prototype.get_Literal, $arrayinit([], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Literal", WootzJs.Mvc.Mvc.Routes.RouteLiteral.prototype.set_Literal, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", String, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Private, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_IsTerminal", WootzJs.Mvc.Mvc.Routes.RouteLiteral.prototype.get_IsTerminal, $arrayinit([], System.Reflection.ParameterInfo), System.Boolean, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_IsTerminal", WootzJs.Mvc.Mvc.Routes.RouteLiteral.prototype.set_IsTerminal, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Boolean, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Private, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("IsDuplicate", WootzJs.Mvc.Mvc.Routes.RouteLiteral.prototype.IsDuplicate, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("part", WootzJs.Mvc.Mvc.Routes.IRoutePart, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Boolean, System.Reflection.MethodAttributes().Family, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Accept", WootzJs.Mvc.Mvc.Routes.RouteLiteral.prototype.Accept, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("path", WootzJs.Mvc.Mvc.Routes.RoutePath, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Boolean, System.Reflection.MethodAttributes().Family, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("ToString", WootzJs.Mvc.Mvc.Routes.RouteLiteral.prototype.ToString, $arrayinit([], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Mvc.Mvc.Routes.RouteLiteral.prototype.$ctor, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("literal", String, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("isTerminal", System.Boolean, 1, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("routeData", System.Collections.Generic.IDictionary$2, 2, System.Reflection.ParameterAttributes().HasDefault, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor$1", WootzJs.Mvc.Mvc.Routes.RouteLiteral.prototype.$ctor$1, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("literal", String, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("isTerminal", System.Boolean, 1, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("key", String, 2, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("value", String, 3, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.PropertyInfo.prototype.$ctor.$new("Literal", String, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Literal", WootzJs.Mvc.Mvc.Routes.RouteLiteral.prototype.get_Literal, $arrayinit([], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Literal", WootzJs.Mvc.Mvc.Routes.RouteLiteral.prototype.set_Literal, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", String, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Private, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("IsTerminal", System.Boolean, System.Reflection.MethodInfo.prototype.$ctor.$new("get_IsTerminal", WootzJs.Mvc.Mvc.Routes.RouteLiteral.prototype.get_IsTerminal, $arrayinit([], System.Reflection.ParameterInfo), System.Boolean, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_IsTerminal", WootzJs.Mvc.Mvc.Routes.RouteLiteral.prototype.set_IsTerminal, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Boolean, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Private, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute))], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {};
    $p.$Literal$k__BackingField = null;
    $p.get_Literal = function() {return this.$Literal$k__BackingField;};
    $p.set_Literal = function(value) {this.$Literal$k__BackingField = value;};
    $p.$IsTerminal$k__BackingField = false;
    $p.get_IsTerminal = function() {return this.$IsTerminal$k__BackingField;};
    $p.set_IsTerminal = function(value) {this.$IsTerminal$k__BackingField = value;};
    $p.$ctor = function(literal, isTerminal, routeData) {
        WootzJs.Mvc.Mvc.Routes.RoutePart.prototype.$ctor.call(this, routeData);
        this.set_Literal(literal.toLowerCase());
        this.set_IsTerminal(isTerminal);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function(literal, isTerminal, routeData) {
        return new $p.$ctor.$type(
            this, 
            literal, 
            isTerminal, 
            routeData
        );
    };
    $p.$ctor$1 = function(literal, isTerminal, key, value) {
        WootzJs.Mvc.Mvc.Routes.RouteLiteral.prototype.$ctor.call(
            this, 
            literal, 
            isTerminal, 
            (function() {
                var $obj$ = System.Collections.Generic.Dictionary$2$(String, System.Object).prototype.$ctor.$new();
                $obj$.Add$1(key, value);
                return $obj$;
            }).call(this)
        );
    };
    $p.$ctor$1.$type = $t;
    $p.$ctor$1.$new = function(literal, isTerminal, key, value) {
        return new $p.$ctor$1.$type(
            this, 
            literal, 
            isTerminal, 
            key, 
            value
        );
    };
    $p.IsDuplicate = function(part) {
        return WootzJs.Mvc.Mvc.Routes.RoutePart.prototype.IsDuplicate.call(this, part) && (WootzJs.Mvc.Mvc.Routes.RouteLiteral.$GetType().IsInstanceOfType(part) && ($cast(WootzJs.Mvc.Mvc.Routes.RouteLiteral, part)).get_IsTerminal() ? ($cast(WootzJs.Mvc.Mvc.Routes.RouteLiteral, part)).get_Literal() == this.get_Literal() && this.get_IsTerminal() : WootzJs.Mvc.Mvc.Routes.RouteVariable.$GetType().IsInstanceOfType(part) && ($cast(WootzJs.Mvc.Mvc.Routes.RouteVariable, part)).get_IsTerminal());
    };
    $p.Accept = function(path) {
        if (path.get_Current() != null && path.get_Current().Equals$2(this.get_Literal(), System.StringComparison().OrdinalIgnoreCase)) {
            path.Consume();
            return true;
        }
        return false;
    };
    $p.ToString = function() {
        return this.get_Literal() + " " + WootzJs.Mvc.Mvc.Routes.RoutePart.prototype.ToString.call(this);
    };
}).call(null, WootzJs.Mvc.Mvc.Routes.RouteLiteral, WootzJs.Mvc.Mvc.Routes.RouteLiteral.prototype);
$WootzJs$Mvc$AssemblyTypes.push(WootzJs.Mvc.Mvc.Routes.RouteLiteral);
WootzJs.Mvc.Mvc.Routes.RouteNode = $define("WootzJs.Mvc.Mvc.Routes.RouteNode", System.Object);
(WootzJs.Mvc.Mvc.Routes.RouteNode.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Mvc$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Mvc.Mvc.Routes.RouteNode";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("RouteNode", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Mvc.Mvc.Routes.RouteNode", WootzJs.Mvc.Mvc.Routes.RouteNode, System.Object, $arrayinit([WootzJs.Mvc.Mvc.Routes.IRouteNode], System.Type), $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("$Part$k__BackingField", WootzJs.Mvc.Mvc.Routes.IRoutePart, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("$Children$k__BackingField", System.Collections.Generic.List$1, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("get_Part", WootzJs.Mvc.Mvc.Routes.RouteNode.prototype.get_Part, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Routes.IRoutePart, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Part", WootzJs.Mvc.Mvc.Routes.RouteNode.prototype.set_Part, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Routes.IRoutePart, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_Children", WootzJs.Mvc.Mvc.Routes.RouteNode.prototype.get_Children, $arrayinit([], System.Reflection.ParameterInfo), System.Collections.Generic.List$1, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Children", WootzJs.Mvc.Mvc.Routes.RouteNode.prototype.set_Children, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Collections.Generic.List$1, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("FindDuplicate", WootzJs.Mvc.Mvc.Routes.RouteNode.prototype.FindDuplicate, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("parent", WootzJs.Mvc.Mvc.Routes.IRouteNode, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Routes.IRouteNode, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("ToString", WootzJs.Mvc.Mvc.Routes.RouteNode.prototype.ToString, $arrayinit([], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Mvc.Mvc.Routes.RouteNode.prototype.$ctor, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("part", WootzJs.Mvc.Mvc.Routes.IRoutePart, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.PropertyInfo.prototype.$ctor.$new("Part", WootzJs.Mvc.Mvc.Routes.IRoutePart, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Part", WootzJs.Mvc.Mvc.Routes.RouteNode.prototype.get_Part, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Routes.IRoutePart, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Part", WootzJs.Mvc.Mvc.Routes.RouteNode.prototype.set_Part, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Routes.IRoutePart, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("Children", System.Collections.Generic.List$1, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Children", WootzJs.Mvc.Mvc.Routes.RouteNode.prototype.get_Children, $arrayinit([], System.Reflection.ParameterInfo), System.Collections.Generic.List$1, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Children", WootzJs.Mvc.Mvc.Routes.RouteNode.prototype.set_Children, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Collections.Generic.List$1, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute))], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {};
    $p.$Part$k__BackingField = null;
    $p.get_Part = function() {return this.$Part$k__BackingField;};
    $p.set_Part = function(value) {this.$Part$k__BackingField = value;};
    $p.$Children$k__BackingField = null;
    $p.get_Children = function() {return this.$Children$k__BackingField;};
    $p.set_Children = function(value) {this.$Children$k__BackingField = value;};
    $p.WootzJs$Mvc$Mvc$Routes$IRouteNode$get_Children = $p.get_Children;
    $p.$ctor = function(part) {
        System.Object.prototype.$ctor.call(this);
        this.set_Part(part);
        this.set_Children(System.Collections.Generic.List$1$(WootzJs.Mvc.Mvc.Routes.RouteNode).prototype.$ctor.$new());
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function(part) {
        return new $p.$ctor.$type(this, part);
    };
    $p.FindDuplicate = function(parent) {
        var duplicate = this.get_Part().WootzJs$Mvc$Mvc$Routes$IRoutePart$FindDuplicate(System.Linq.Enumerable.Select(
            WootzJs.Mvc.Mvc.Routes.RouteNode, 
            WootzJs.Mvc.Mvc.Routes.IRoutePart, 
            parent.WootzJs$Mvc$Mvc$Routes$IRouteNode$get_Children(), 
            $delegate(this, System.Func$2$(WootzJs.Mvc.Mvc.Routes.RouteNode, WootzJs.Mvc.Mvc.Routes.IRoutePart), function(x) {
                return x.get_Part();
            })
        ));
        if (duplicate != null) {
            return System.Linq.Enumerable.Single$1(WootzJs.Mvc.Mvc.Routes.RouteNode, parent.WootzJs$Mvc$Mvc$Routes$IRouteNode$get_Children(), $delegate(this, System.Func$2$(WootzJs.Mvc.Mvc.Routes.RouteNode, System.Boolean), function(x) {
                return x.get_Part() == duplicate;
            }));
        }
        return null;
    };
    $p.WootzJs$Mvc$Mvc$Routes$IRouteNode$FindDuplicate = $p.FindDuplicate;
    $p.ToString = function() {
        return this.get_Part().ToString();
    };
}).call(null, WootzJs.Mvc.Mvc.Routes.RouteNode, WootzJs.Mvc.Mvc.Routes.RouteNode.prototype);
$WootzJs$Mvc$AssemblyTypes.push(WootzJs.Mvc.Mvc.Routes.RouteNode);
WootzJs.Mvc.Mvc.Routes.RoutePath = $define("WootzJs.Mvc.Mvc.Routes.RoutePath", System.Object);
(WootzJs.Mvc.Mvc.Routes.RoutePath.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Mvc$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Mvc.Mvc.Routes.RoutePath";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("RoutePath", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Mvc.Mvc.Routes.RoutePath", WootzJs.Mvc.Mvc.Routes.RoutePath, System.Object, $arrayinit([], System.Type), $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("remaining", System.Collections.Generic.Stack$1, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("consumed", System.Collections.Generic.Stack$1, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("pinning", System.Collections.Generic.Stack$1, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("Pin", WootzJs.Mvc.Mvc.Routes.RoutePath.prototype.Pin, $arrayinit([], System.Reflection.ParameterInfo), System.IDisposable, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Unpin", WootzJs.Mvc.Mvc.Routes.RoutePath.prototype.Unpin, $arrayinit([], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_Location", WootzJs.Mvc.Mvc.Routes.RoutePath.prototype.get_Location, $arrayinit([], System.Reflection.ParameterInfo), System.Int32, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Reset$1", WootzJs.Mvc.Mvc.Routes.RoutePath.prototype.Reset$1, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("location", System.Int32, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Private, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Any", WootzJs.Mvc.Mvc.Routes.RoutePath.prototype.Any, $arrayinit([], System.Reflection.ParameterInfo), System.Boolean, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_Remaining", WootzJs.Mvc.Mvc.Routes.RoutePath.prototype.get_Remaining, $arrayinit([], System.Reflection.ParameterInfo), System.Int32, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("StartsWith", WootzJs.Mvc.Mvc.Routes.RoutePath.prototype.StartsWith, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("routePath", WootzJs.Mvc.Mvc.Routes.RoutePath, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Boolean, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_Current", WootzJs.Mvc.Mvc.Routes.RoutePath.prototype.get_Current, $arrayinit([], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Consume", WootzJs.Mvc.Mvc.Routes.RoutePath.prototype.Consume, $arrayinit([], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("ConsumeAll", WootzJs.Mvc.Mvc.Routes.RoutePath.prototype.ConsumeAll, $arrayinit([], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Consume$1", WootzJs.Mvc.Mvc.Routes.RoutePath.prototype.Consume$1, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("path", WootzJs.Mvc.Mvc.Routes.RoutePath, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Back", WootzJs.Mvc.Mvc.Routes.RoutePath.prototype.Back, $arrayinit([], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Reset", WootzJs.Mvc.Mvc.Routes.RoutePath.prototype.Reset, $arrayinit([], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("ToString", WootzJs.Mvc.Mvc.Routes.RoutePath.prototype.ToString, $arrayinit([], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Mvc.Mvc.Routes.RoutePath.prototype.$ctor, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("path", String, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.PropertyInfo.prototype.$ctor.$new("Location", System.Int32, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Location", WootzJs.Mvc.Mvc.Routes.RoutePath.prototype.get_Location, $arrayinit([], System.Reflection.ParameterInfo), System.Int32, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), null, $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("Remaining", System.Int32, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Remaining", WootzJs.Mvc.Mvc.Routes.RoutePath.prototype.get_Remaining, $arrayinit([], System.Reflection.ParameterInfo), System.Int32, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), null, $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("Current", String, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Current", WootzJs.Mvc.Mvc.Routes.RoutePath.prototype.get_Current, $arrayinit([], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), null, $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute))], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {};
    $p.remaining = null;
    $p.consumed = null;
    $p.pinning = null;
    $p.$ctor = function(path) {
        System.Object.prototype.$ctor.call(this);
        this.remaining = System.Collections.Generic.Stack$1$(String).prototype.$ctor.$new();
        this.consumed = System.Collections.Generic.Stack$1$(String).prototype.$ctor.$new();
        this.pinning = System.Collections.Generic.Stack$1$(System.Int32).prototype.$ctor.$new();
        path = WootzJs.Mvc.Mvc.MiscExtensions.ChopStart(path, "/");
        if (path != "") {
            var parts = String.prototype.Split.call(path, ["/"]);
            {
                var $anon$1iterator = System.Linq.Enumerable.Reverse(String, parts);
                var $anon$2enumerator = $anon$1iterator.System$Collections$IEnumerable$GetEnumerator();
                while ($anon$2enumerator.System$Collections$IEnumerator$MoveNext()) {
                    var part = $anon$2enumerator.System$Collections$IEnumerator$get_Current();
                    this.remaining.Push(part);
                }
            }
        }
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function(path) {
        return new $p.$ctor.$type(this, path);
    };
    $p.Pin = function() {
        this.pinning.Push(this.get_Location());
        return WootzJs.Mvc.Mvc.Routes.RoutePath.Pinned.prototype.$ctor.$new(this);
    };
    $p.Unpin = function() {
        this.Reset$1(this.pinning.Pop());
    };
    $p.get_Location = function() {
        return this.consumed.get_Count();
    };
    $p.Reset$1 = function(location) {
        if (location > this.consumed.get_Count()) {
            throw System.InvalidOperationException.prototype.$ctor$1.$new("Illegal location " + $safeToString(location) + ", only " + $safeToString(this.consumed.get_Count()) + " items in the back stack.").InternalInit(new Error());
        }
        while (this.consumed.get_Count() > location) {
            this.Back();
        }
    };
    $p.Any = function() {
        return System.Linq.Enumerable.Any(String, this.remaining);
    };
    $p.get_Remaining = function() {
        return this.remaining.get_Count();
    };
    $p.StartsWith = function(routePath) {
        if (routePath.remaining.get_Count() > this.remaining.get_Count())
            return false;
        if (System.Linq.Enumerable.SequenceEqual(String, System.Linq.Enumerable.Take(String, this.remaining, routePath.remaining.get_Count()), routePath.remaining))
            return true;
        return false;
    };
    $p.get_Current = function() {
        return System.Linq.Enumerable.Any(String, this.remaining) ? this.remaining.Peek() : null;
    };
    $p.Consume = function() {
        var part = this.remaining.Pop();
        this.consumed.Push(part);
        return part;
    };
    $p.ConsumeAll = function() {
        var builder = System.Text.StringBuilder.prototype.$ctor.$new();
        while (this.Any()) {
            if (builder.get_Length() > 0)
                builder.Append$2("/");
            builder.Append$2(this.Consume());
        }
        return builder.ToString();
    };
    $p.Consume$1 = function(path) {
        for (var i = 0; i < path.remaining.get_Count(); i++) {
            this.Consume();
        }
    };
    $p.Back = function() {
        var part = this.consumed.Pop();
        this.remaining.Push(part);
        return part;
    };
    $p.Reset = function() {
        while (System.Linq.Enumerable.Any(String, this.consumed)) {
            var part = this.consumed.Pop();
            this.remaining.Push(part);
        }
    };
    $p.ToString = function() {
        var builder = System.Text.StringBuilder.prototype.$ctor.$new();
        if (System.Linq.Enumerable.Any(String, this.consumed)) {
            builder.Append$2(String.Join$1(String, "/", System.Linq.Enumerable.Reverse(String, this.consumed)));
        }
        if (System.Linq.Enumerable.Any(String, this.remaining)) {
            builder.Append$2("/*" + this.remaining.Peek() + "*");
            if (this.remaining.get_Count() > 1) {
                builder.Append$2("/");
                builder.Append$2(String.Join$1(String, "/", System.Linq.Enumerable.Skip(String, this.remaining, 1)));
            }
        }
        return builder.ToString();
    };
    $t.Pinned = $define("WootzJs.Mvc.Mvc.Routes.RoutePath.Pinned", System.Object);
    ($t.Pinned.$TypeInitializer = function($t, $p) {
        $t.$GetAssembly = window.$WootzJs$Mvc$GetAssembly;
        $p.$type = $t;
        $t.$baseType = System.Object;
        $p.$typeName = "WootzJs.Mvc.Mvc.Routes.RoutePath.Pinned";
        $t.$typeName = $p.$typeName;
        $t.$GetType = function() {
            return System.Type._GetTypeFromTypeFunc(this);
        };
        $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("Pinned", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Mvc.Mvc.Routes.RoutePath.Pinned", WootzJs.Mvc.Mvc.Routes.RoutePath.Pinned, System.Object, $arrayinit([System.IDisposable], System.Type), $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("path", WootzJs.Mvc.Mvc.Routes.RoutePath, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("Dispose", WootzJs.Mvc.Mvc.Routes.RoutePath.Pinned.prototype.Dispose, $arrayinit([], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Mvc.Mvc.Routes.RoutePath.Pinned.prototype.$ctor, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("path", WootzJs.Mvc.Mvc.Routes.RoutePath, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
        $t.$StaticInitializer = function() {};
        $p.path = null;
        $p.$ctor = function(path) {
            System.Object.prototype.$ctor.call(this);
            this.path = path;
        };
        $p.$ctor.$type = $t;
        $p.$ctor.$new = function(path) {
            return new $p.$ctor.$type(this, path);
        };
        $p.Dispose = function() {
            this.path.Unpin();
        };
        $p.System$IDisposable$Dispose = $p.Dispose;
    }).call($t, $t.Pinned, $t.Pinned.prototype);
    $WootzJs$Mvc$AssemblyTypes.push($t.Pinned);
}).call(null, WootzJs.Mvc.Mvc.Routes.RoutePath, WootzJs.Mvc.Mvc.Routes.RoutePath.prototype);
$WootzJs$Mvc$AssemblyTypes.push(WootzJs.Mvc.Mvc.Routes.RoutePath);
WootzJs.Mvc.Mvc.Routes.RouteTree = $define("WootzJs.Mvc.Mvc.Routes.RouteTree", System.Object);
(WootzJs.Mvc.Mvc.Routes.RouteTree.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Mvc$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Mvc.Mvc.Routes.RouteTree";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("RouteTree", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Mvc.Mvc.Routes.RouteTree", WootzJs.Mvc.Mvc.Routes.RouteTree, System.Object, $arrayinit([WootzJs.Mvc.Mvc.Routes.IRouteNode], System.Type), $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("$RootPaths$k__BackingField", System.Collections.Generic.List$1, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("get_RootPaths", WootzJs.Mvc.Mvc.Routes.RouteTree.prototype.get_RootPaths, $arrayinit([], System.Reflection.ParameterInfo), System.Collections.Generic.List$1, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_RootPaths", WootzJs.Mvc.Mvc.Routes.RouteTree.prototype.set_RootPaths, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Collections.Generic.List$1, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_Children", WootzJs.Mvc.Mvc.Routes.RouteTree.prototype.get_Children, $arrayinit([], System.Reflection.ParameterInfo), System.Collections.Generic.List$1, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("FindDuplicate", WootzJs.Mvc.Mvc.Routes.RouteTree.prototype.FindDuplicate, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("parent", WootzJs.Mvc.Mvc.Routes.IRouteNode, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Routes.IRouteNode, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Apply", WootzJs.Mvc.Mvc.Routes.RouteTree.prototype.Apply, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("path", String, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("method", String, 1, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Routes.RouteData, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("CalculateRoute", WootzJs.Mvc.Mvc.Routes.RouteTree.prototype.CalculateRoute, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("path", String, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("httpMethod", String, 1, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), $array(WootzJs.Mvc.Mvc.Routes.IRoutePart), System.Reflection.MethodAttributes().Private, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("CalculateRoute$1", WootzJs.Mvc.Mvc.Routes.RouteTree.prototype.CalculateRoute$1, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("path", WootzJs.Mvc.Mvc.Routes.RoutePath, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("httpMethod", String, 1, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("route", WootzJs.Mvc.Mvc.Routes.RouteBuilder, 2, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("node", WootzJs.Mvc.Mvc.Routes.RouteNode, 3, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Boolean, System.Reflection.MethodAttributes().Private, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("ToString", WootzJs.Mvc.Mvc.Routes.RouteTree.prototype.ToString, $arrayinit([], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Mvc.Mvc.Routes.RouteTree.prototype.$ctor, $arrayinit([], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.PropertyInfo.prototype.$ctor.$new("RootPaths", System.Collections.Generic.List$1, System.Reflection.MethodInfo.prototype.$ctor.$new("get_RootPaths", WootzJs.Mvc.Mvc.Routes.RouteTree.prototype.get_RootPaths, $arrayinit([], System.Reflection.ParameterInfo), System.Collections.Generic.List$1, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_RootPaths", WootzJs.Mvc.Mvc.Routes.RouteTree.prototype.set_RootPaths, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Collections.Generic.List$1, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("Children", System.Collections.Generic.List$1, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Children", WootzJs.Mvc.Mvc.Routes.RouteTree.prototype.get_Children, $arrayinit([], System.Reflection.ParameterInfo), System.Collections.Generic.List$1, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), null, $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute))], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {};
    $p.$RootPaths$k__BackingField = null;
    $p.get_RootPaths = function() {return this.$RootPaths$k__BackingField;};
    $p.set_RootPaths = function(value) {this.$RootPaths$k__BackingField = value;};
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
        this.set_RootPaths(System.Collections.Generic.List$1$(WootzJs.Mvc.Mvc.Routes.RouteNode).prototype.$ctor.$new());
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.get_Children = function() {
        return this.get_RootPaths();
    };
    $p.WootzJs$Mvc$Mvc$Routes$IRouteNode$get_Children = $p.get_Children;
    $p.FindDuplicate = function(parent) {
        return null;
    };
    $p.WootzJs$Mvc$Mvc$Routes$IRouteNode$FindDuplicate = $p.FindDuplicate;
    $p.Apply = function(path, method) {
        path = WootzJs.Mvc.Mvc.MiscExtensions.ChopEnd(path, "/");
        var routePath = WootzJs.Mvc.Mvc.Routes.RoutePath.prototype.$ctor.$new(path.toLowerCase());
        var route = this.CalculateRoute(path, method);
        if (route == null) {
            throw System.InvalidOperationException.prototype.$ctor$1.$new("Could not apply the URL path \'" + path + "\'.  No route supports this path.").InternalInit(new Error());
        }
        var routeData = WootzJs.Mvc.Mvc.Routes.RouteData.prototype.$ctor.$new();
        routePath = WootzJs.Mvc.Mvc.Routes.RoutePath.prototype.$ctor.$new(path);
        {
            var $anon$1iterator = route;
            var $anon$2enumerator = $anon$1iterator.System$Collections$IEnumerable$GetEnumerator();
            while ($anon$2enumerator.System$Collections$IEnumerator$MoveNext()) {
                var part = $anon$2enumerator.System$Collections$IEnumerator$get_Current();
                part.WootzJs$Mvc$Mvc$Routes$IRoutePart$ProcessData(routePath, routeData);
            }
        }
        return routeData;
    };
    $p.CalculateRoute = function(path, httpMethod) {
        var routePath = WootzJs.Mvc.Mvc.Routes.RoutePath.prototype.$ctor.$new(path);
        var route = WootzJs.Mvc.Mvc.Routes.RouteBuilder.prototype.$ctor.$new();
        {
            var $anon$1iterator = this.get_RootPaths();
            var $anon$2enumerator = $anon$1iterator.System$Collections$IEnumerable$GetEnumerator();
            while ($anon$2enumerator.System$Collections$IEnumerator$MoveNext()) {
                var node = $anon$2enumerator.System$Collections$IEnumerator$get_Current();
                if (this.CalculateRoute$1(
                    routePath, 
                    httpMethod, 
                    route, 
                    node
                )) {
                    return route.ToArray();
                }
            }
        }
        return null;
    };
    $p.CalculateRoute$1 = function(path, httpMethod, route, node) {
        var $anon$1 = path.Pin();
        try {
            var pin = route.Pin();
            try {
                if (node.get_Part().WootzJs$Mvc$Mvc$Routes$IRoutePart$AcceptPath(path, httpMethod)) {
                    route.Add(node.get_Part());
                    if (System.Linq.Enumerable.Any(WootzJs.Mvc.Mvc.Routes.RouteNode, node.get_Children())) {
                        {
                            var $anon$2iterator = node.get_Children();
                            var $anon$3enumerator = $anon$2iterator.System$Collections$IEnumerable$GetEnumerator();
                            while ($anon$3enumerator.System$Collections$IEnumerator$MoveNext()) {
                                var child = $anon$3enumerator.System$Collections$IEnumerator$get_Current();
                                if (this.CalculateRoute$1(
                                    path, 
                                    httpMethod, 
                                    route, 
                                    child
                                )) {
                                    pin.Accept();
                                    return true;
                                }
                            }
                        }
                    }
                    else
                        if (!path.Any()) {
                            pin.Accept();
                            return true;
                        }
                }
                return false;
            }
            finally {
                pin.System$IDisposable$Dispose();
            }
        }
        finally {
            $anon$1.System$IDisposable$Dispose();
        }

    };
    $p.ToString = function() {
        return "(root)";
    };
}).call(null, WootzJs.Mvc.Mvc.Routes.RouteTree, WootzJs.Mvc.Mvc.Routes.RouteTree.prototype);
$WootzJs$Mvc$AssemblyTypes.push(WootzJs.Mvc.Mvc.Routes.RouteTree);
WootzJs.Mvc.Mvc.Routes.RouteVariable = $define("WootzJs.Mvc.Mvc.Routes.RouteVariable", WootzJs.Mvc.Mvc.Routes.RoutePart);
(WootzJs.Mvc.Mvc.Routes.RouteVariable.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Mvc$GetAssembly;
    $p.$type = $t;
    $t.$baseType = WootzJs.Mvc.Mvc.Routes.RoutePart;
    $p.$typeName = "WootzJs.Mvc.Mvc.Routes.RouteVariable";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("RouteVariable", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Mvc.Mvc.Routes.RouteVariable", WootzJs.Mvc.Mvc.Routes.RouteVariable, WootzJs.Mvc.Mvc.Routes.RoutePart, $arrayinit([WootzJs.Mvc.Mvc.Routes.IRoutePart], System.Type), $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("$IsTerminal$k__BackingField", System.Boolean, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("$Parameter$k__BackingField", System.Reflection.ParameterInfo, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("get_IsTerminal", WootzJs.Mvc.Mvc.Routes.RouteVariable.prototype.get_IsTerminal, $arrayinit([], System.Reflection.ParameterInfo), System.Boolean, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_IsTerminal", WootzJs.Mvc.Mvc.Routes.RouteVariable.prototype.set_IsTerminal, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Boolean, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Private, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_Parameter", WootzJs.Mvc.Mvc.Routes.RouteVariable.prototype.get_Parameter, $arrayinit([], System.Reflection.ParameterInfo), System.Reflection.ParameterInfo, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Parameter", WootzJs.Mvc.Mvc.Routes.RouteVariable.prototype.set_Parameter, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Reflection.ParameterInfo, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Private, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("IsDuplicate", WootzJs.Mvc.Mvc.Routes.RouteVariable.prototype.IsDuplicate, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("part", WootzJs.Mvc.Mvc.Routes.IRoutePart, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Boolean, System.Reflection.MethodAttributes().Family, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Accept", WootzJs.Mvc.Mvc.Routes.RouteVariable.prototype.Accept, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("path", WootzJs.Mvc.Mvc.Routes.RoutePath, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Boolean, System.Reflection.MethodAttributes().Family, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("ConsumePath", WootzJs.Mvc.Mvc.Routes.RouteVariable.prototype.ConsumePath, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("path", WootzJs.Mvc.Mvc.Routes.RoutePath, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Family, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("ProcessData", WootzJs.Mvc.Mvc.Routes.RouteVariable.prototype.ProcessData, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("path", WootzJs.Mvc.Mvc.Routes.RoutePath, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("data", WootzJs.Mvc.Mvc.Routes.RouteData, 1, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("ToString", WootzJs.Mvc.Mvc.Routes.RouteVariable.prototype.ToString, $arrayinit([], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Mvc.Mvc.Routes.RouteVariable.prototype.$ctor, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("isTerminal", System.Boolean, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("parameter", System.Reflection.ParameterInfo, 1, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.PropertyInfo.prototype.$ctor.$new("IsTerminal", System.Boolean, System.Reflection.MethodInfo.prototype.$ctor.$new("get_IsTerminal", WootzJs.Mvc.Mvc.Routes.RouteVariable.prototype.get_IsTerminal, $arrayinit([], System.Reflection.ParameterInfo), System.Boolean, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_IsTerminal", WootzJs.Mvc.Mvc.Routes.RouteVariable.prototype.set_IsTerminal, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Boolean, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Private, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("Parameter", System.Reflection.ParameterInfo, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Parameter", WootzJs.Mvc.Mvc.Routes.RouteVariable.prototype.get_Parameter, $arrayinit([], System.Reflection.ParameterInfo), System.Reflection.ParameterInfo, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Parameter", WootzJs.Mvc.Mvc.Routes.RouteVariable.prototype.set_Parameter, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Reflection.ParameterInfo, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Private, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute))], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {};
    $p.$IsTerminal$k__BackingField = false;
    $p.get_IsTerminal = function() {return this.$IsTerminal$k__BackingField;};
    $p.set_IsTerminal = function(value) {this.$IsTerminal$k__BackingField = value;};
    $p.$Parameter$k__BackingField = null;
    $p.get_Parameter = function() {return this.$Parameter$k__BackingField;};
    $p.set_Parameter = function(value) {this.$Parameter$k__BackingField = value;};
    $p.$ctor = function(isTerminal, parameter) {
        WootzJs.Mvc.Mvc.Routes.RoutePart.prototype.$ctor.call(this);
        this.set_IsTerminal(isTerminal);
        this.set_Parameter(parameter);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function(isTerminal, parameter) {
        return new $p.$ctor.$type(this, isTerminal, parameter);
    };
    $p.IsDuplicate = function(part) {
        return WootzJs.Mvc.Mvc.Routes.RoutePart.prototype.IsDuplicate.call(this, part) && this.get_IsTerminal() && (WootzJs.Mvc.Mvc.Routes.RouteLiteral.$GetType().IsInstanceOfType(part) && ($cast(WootzJs.Mvc.Mvc.Routes.RouteLiteral, part)).get_IsTerminal() || WootzJs.Mvc.Mvc.Routes.RouteVariable.$GetType().IsInstanceOfType(part) && ($cast(WootzJs.Mvc.Mvc.Routes.RouteVariable, part)).get_IsTerminal());
    };
    $p.Accept = function(path) {
        if (path.get_Current() != null) {
            path.Consume();
            return true;
        }
        return false;
    };
    $p.ConsumePath = function(path) {};
    $p.ProcessData = function(path, data) {
        WootzJs.Mvc.Mvc.Routes.RoutePart.prototype.ProcessData.call(this, path, data);
        var part = path.Consume();
        part = System.Web.HttpUtility.UrlDecode(part);
        var value = System.Convert.ChangeType(part, this.get_Parameter().get_ParameterType());
        data.set_Item(this.get_Parameter().get_Name(), value);
    };
    $p.WootzJs$Mvc$Mvc$Routes$IRoutePart$ProcessData = $p.ProcessData;
    $p.ToString = function() {
        return "{" + this.get_Parameter().get_Name() + "} " + WootzJs.Mvc.Mvc.Routes.RoutePart.prototype.ToString.call(this);
    };
}).call(null, WootzJs.Mvc.Mvc.Routes.RouteVariable, WootzJs.Mvc.Mvc.Routes.RouteVariable.prototype);
$WootzJs$Mvc$AssemblyTypes.push(WootzJs.Mvc.Mvc.Routes.RouteVariable);
WootzJs.Mvc.Mvc.Routes.RouteWildcard = $define("WootzJs.Mvc.Mvc.Routes.RouteWildcard", WootzJs.Mvc.Mvc.Routes.RoutePart);
(WootzJs.Mvc.Mvc.Routes.RouteWildcard.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Mvc$GetAssembly;
    $p.$type = $t;
    $t.$baseType = WootzJs.Mvc.Mvc.Routes.RoutePart;
    $p.$typeName = "WootzJs.Mvc.Mvc.Routes.RouteWildcard";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("RouteWildcard", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Mvc.Mvc.Routes.RouteWildcard", WootzJs.Mvc.Mvc.Routes.RouteWildcard, WootzJs.Mvc.Mvc.Routes.RoutePart, $arrayinit([WootzJs.Mvc.Mvc.Routes.IRoutePart], System.Type), $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("parameter", System.Reflection.ParameterInfo, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("Accept", WootzJs.Mvc.Mvc.Routes.RouteWildcard.prototype.Accept, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("path", WootzJs.Mvc.Mvc.Routes.RoutePath, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Boolean, System.Reflection.MethodAttributes().Family, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("ConsumePath", WootzJs.Mvc.Mvc.Routes.RouteWildcard.prototype.ConsumePath, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("path", WootzJs.Mvc.Mvc.Routes.RoutePath, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Family, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("ProcessData", WootzJs.Mvc.Mvc.Routes.RouteWildcard.prototype.ProcessData, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("path", WootzJs.Mvc.Mvc.Routes.RoutePath, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("data", WootzJs.Mvc.Mvc.Routes.RouteData, 1, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Mvc.Mvc.Routes.RouteWildcard.prototype.$ctor, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("parameter", System.Reflection.ParameterInfo, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {};
    $p.parameter = null;
    $p.$ctor = function(parameter) {
        WootzJs.Mvc.Mvc.Routes.RoutePart.prototype.$ctor.call(this, null);
        this.parameter = parameter;
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function(parameter) {
        return new $p.$ctor.$type(this, parameter);
    };
    $p.Accept = function(path) {
        if (path.get_Current() != null) {
            path.ConsumeAll();
            return true;
        }
        return false;
    };
    $p.ConsumePath = function(path) {};
    $p.ProcessData = function(path, data) {
        WootzJs.Mvc.Mvc.Routes.RoutePart.prototype.ProcessData.call(this, path, data);
        var s = path.ConsumeAll();
        data.set_Item(this.parameter.get_Name(), System.Convert.ChangeType(s, this.parameter.get_ParameterType()));
    };
    $p.WootzJs$Mvc$Mvc$Routes$IRoutePart$ProcessData = $p.ProcessData;
}).call(null, WootzJs.Mvc.Mvc.Routes.RouteWildcard, WootzJs.Mvc.Mvc.Routes.RouteWildcard.prototype);
$WootzJs$Mvc$AssemblyTypes.push(WootzJs.Mvc.Mvc.Routes.RouteWildcard);
WootzJs.Mvc.Mvc.MiscExtensions = $define("WootzJs.Mvc.Mvc.MiscExtensions", System.Object);
(WootzJs.Mvc.Mvc.MiscExtensions.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Mvc$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Mvc.Mvc.MiscExtensions";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("MiscExtensions", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Mvc.Mvc.MiscExtensions", WootzJs.Mvc.Mvc.MiscExtensions, System.Object, $arrayinit([], System.Type), $arrayinit([], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("ChopStart", WootzJs.Mvc.Mvc.MiscExtensions.prototype.ChopStart, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("s", String, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("start", String, 1, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("ChopEnd", WootzJs.Mvc.Mvc.MiscExtensions.prototype.ChopEnd, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("s", String, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("end", String, 1, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("ToHex", WootzJs.Mvc.Mvc.MiscExtensions.prototype.ToHex, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("i", System.Int32, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("minimumDigits", System.Int32, 1, System.Reflection.ParameterAttributes().HasDefault, 0, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Get", WootzJs.Mvc.Mvc.MiscExtensions.prototype.Get, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("dictionary", System.Collections.Generic.IDictionary$2, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("key", T, 1, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("returnIfNotFound", U, 2, System.Reflection.ParameterAttributes().HasDefault, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Object, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {};
    $t.ChopStart = function(s, start) {
        if (!String.prototype.StartsWith.call(s, start))
            return s;
        return String.prototype.Substring.call(s, start.length, 0);
    };
    $t.ChopEnd = function(s, end) {
        if (!String.prototype.EndsWith.call(s, end))
            return s;
        return String.prototype.Substring.call(s, 0, s.length - end.length);
    };
    $t.ToHex = function(i, minimumDigits) {
        var s = i.ToString$2("X" + $safeToString(minimumDigits));
        return s;
    };
    $t.Get = function(T, U, dictionary, key, returnIfNotFound) {
        if (dictionary == null)
            return returnIfNotFound;
        if (key == null)
            return returnIfNotFound;
        var result;
        if ((function() {
            var $anon$1 = {
                value: null
            };
            var $result$ = dictionary.System$Collections$Generic$IDictionary$2$TryGetValue(key, $anon$1);
            result = $anon$1.value;
            return $result$;
        }).call(this))
            return result;
        else
            return returnIfNotFound;
    };
}).call(null, WootzJs.Mvc.Mvc.MiscExtensions, WootzJs.Mvc.Mvc.MiscExtensions.prototype);
$WootzJs$Mvc$AssemblyTypes.push(WootzJs.Mvc.Mvc.MiscExtensions);
WootzJs.Mvc.Mvc.ViewContext = $define("WootzJs.Mvc.Mvc.ViewContext", System.Object);
(WootzJs.Mvc.Mvc.ViewContext.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Mvc$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Mvc.Mvc.ViewContext";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("ViewContext", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Mvc.Mvc.ViewContext", WootzJs.Mvc.Mvc.ViewContext, System.Object, $arrayinit([], System.Type), $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("$ControllerContext$k__BackingField", WootzJs.Mvc.Mvc.ControllerContext, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("$Action$k__BackingField", WootzJs.Mvc.Mvc.Views.ActionHelper, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("get_ControllerContext", WootzJs.Mvc.Mvc.ViewContext.prototype.get_ControllerContext, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.ControllerContext, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_ControllerContext", WootzJs.Mvc.Mvc.ViewContext.prototype.set_ControllerContext, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.ControllerContext, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_Action", WootzJs.Mvc.Mvc.ViewContext.prototype.get_Action, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.ActionHelper, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Action", WootzJs.Mvc.Mvc.ViewContext.prototype.set_Action, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.ActionHelper, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Mvc.Mvc.ViewContext.prototype.$ctor, $arrayinit([], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.PropertyInfo.prototype.$ctor.$new("ControllerContext", WootzJs.Mvc.Mvc.ControllerContext, System.Reflection.MethodInfo.prototype.$ctor.$new("get_ControllerContext", WootzJs.Mvc.Mvc.ViewContext.prototype.get_ControllerContext, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.ControllerContext, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_ControllerContext", WootzJs.Mvc.Mvc.ViewContext.prototype.set_ControllerContext, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.ControllerContext, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("Action", WootzJs.Mvc.Mvc.Views.ActionHelper, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Action", WootzJs.Mvc.Mvc.ViewContext.prototype.get_Action, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.ActionHelper, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Action", WootzJs.Mvc.Mvc.ViewContext.prototype.set_Action, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.ActionHelper, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute))], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {};
    $p.$ControllerContext$k__BackingField = null;
    $p.get_ControllerContext = function() {return this.$ControllerContext$k__BackingField;};
    $p.set_ControllerContext = function(value) {this.$ControllerContext$k__BackingField = value;};
    $p.$Action$k__BackingField = null;
    $p.get_Action = function() {return this.$Action$k__BackingField;};
    $p.set_Action = function(value) {this.$Action$k__BackingField = value;};
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
        this.set_Action(WootzJs.Mvc.Mvc.Views.ActionHelper.prototype.$ctor.$new(this));
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
}).call(null, WootzJs.Mvc.Mvc.ViewContext, WootzJs.Mvc.Mvc.ViewContext.prototype);
$WootzJs$Mvc$AssemblyTypes.push(WootzJs.Mvc.Mvc.ViewContext);
WootzJs.Mvc.Mvc.ViewResult = $define("WootzJs.Mvc.Mvc.ViewResult", WootzJs.Mvc.Mvc.ActionResult);
(WootzJs.Mvc.Mvc.ViewResult.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Mvc$GetAssembly;
    $p.$type = $t;
    $t.$baseType = WootzJs.Mvc.Mvc.ActionResult;
    $p.$typeName = "WootzJs.Mvc.Mvc.ViewResult";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("ViewResult", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Mvc.Mvc.ViewResult", WootzJs.Mvc.Mvc.ViewResult, WootzJs.Mvc.Mvc.ActionResult, $arrayinit([], System.Type), $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("$View$k__BackingField", WootzJs.Mvc.Mvc.Views.View, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("get_View", WootzJs.Mvc.Mvc.ViewResult.prototype.get_View, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.View, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_View", WootzJs.Mvc.Mvc.ViewResult.prototype.set_View, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.View, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Private, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("ExecuteResult", WootzJs.Mvc.Mvc.ViewResult.prototype.ExecuteResult, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("context", WootzJs.Mvc.Mvc.NavigationContext, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Mvc.Mvc.ViewResult.prototype.$ctor, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("view", WootzJs.Mvc.Mvc.Views.View, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.PropertyInfo.prototype.$ctor.$new("View", WootzJs.Mvc.Mvc.Views.View, System.Reflection.MethodInfo.prototype.$ctor.$new("get_View", WootzJs.Mvc.Mvc.ViewResult.prototype.get_View, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.View, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_View", WootzJs.Mvc.Mvc.ViewResult.prototype.set_View, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.View, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Private, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute))], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {};
    $p.$View$k__BackingField = null;
    $p.get_View = function() {return this.$View$k__BackingField;};
    $p.set_View = function(value) {this.$View$k__BackingField = value;};
    $p.$ctor = function(view) {
        WootzJs.Mvc.Mvc.ActionResult.prototype.$ctor.call(this);
        this.set_View(view);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function(view) {
        return new $p.$ctor.$type(this, view);
    };
    $p.ExecuteResult = function(context) {};
}).call(null, WootzJs.Mvc.Mvc.ViewResult, WootzJs.Mvc.Mvc.ViewResult.prototype);
$WootzJs$Mvc$AssemblyTypes.push(WootzJs.Mvc.Mvc.ViewResult);
WootzJs.Mvc.Mvc.Views.ActionHelper = $define("WootzJs.Mvc.Mvc.Views.ActionHelper", System.Object);
(WootzJs.Mvc.Mvc.Views.ActionHelper.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Mvc$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Mvc.Mvc.Views.ActionHelper";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("ActionHelper", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Mvc.Mvc.Views.ActionHelper", WootzJs.Mvc.Mvc.Views.ActionHelper, System.Object, $arrayinit([], System.Type), $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("viewContext", WootzJs.Mvc.Mvc.ViewContext, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("On", WootzJs.Mvc.Mvc.Views.ActionHelper.prototype.On, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.ActionHelper.ActionControllerHelper$1, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Mvc.Mvc.Views.ActionHelper.prototype.$ctor, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("viewContext", WootzJs.Mvc.Mvc.ViewContext, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {};
    $p.viewContext = null;
    $p.$ctor = function(viewContext) {
        System.Object.prototype.$ctor.call(this);
        this.viewContext = viewContext;
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function(viewContext) {
        return new $p.$ctor.$type(this, viewContext);
    };
    $p.On = function(TController) {
        return WootzJs.Mvc.Mvc.Views.ActionHelper.ActionControllerHelper$1$(TController).prototype.$ctor.$new(this.viewContext);
    };
    $t.ActionControllerHelper$1 = $define("WootzJs.Mvc.Mvc.Views.ActionHelper.ActionControllerHelper<TController>", System.Object);
    ($t.ActionControllerHelper$1.$TypeInitializer = function($t, $p, TController) {
        $t.$GetAssembly = window.$WootzJs$Mvc$GetAssembly;
        $p.$type = $t;
        $t.$baseType = System.Object;
        $p.$typeName = "WootzJs.Mvc.Mvc.Views.ActionHelper.ActionControllerHelper`1";
        $t.$typeName = $p.$typeName;
        $t.$GetType = function() {
            return System.Type._GetTypeFromTypeFunc(this);
        };
        $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("ActionControllerHelper", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Mvc.Mvc.Views.ActionHelper.ActionControllerHelper`1", WootzJs.Mvc.Mvc.Views.ActionHelper.ActionControllerHelper$1, System.Object, $arrayinit([], System.Type), $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("viewContext", WootzJs.Mvc.Mvc.ViewContext, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("To", WootzJs.Mvc.Mvc.Views.ActionHelper.ActionControllerHelper$1.prototype.To, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("action", System.Linq.Expressions.Expression$1, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Mvc.Mvc.Views.ActionHelper.ActionControllerHelper$1.prototype.$ctor, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("viewContext", WootzJs.Mvc.Mvc.ViewContext, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
        $t.$StaticInitializer = function() {};
        this.ActionControllerHelper$1$ = function() {
            return $generic.call(this, this.ActionControllerHelper$1, arguments);
        };
        $p.viewContext = null;
        $p.$ctor = function(viewContext) {
            System.Object.prototype.$ctor.call(this);
            this.viewContext = viewContext;
        };
        $p.$ctor.$type = $t;
        $p.$ctor.$new = function(viewContext) {
            return new $p.$ctor.$type(this, viewContext);
        };
        $p.To = function(TActionResult, action) {
            this.viewContext.get_ControllerContext().get_Application().Open(WootzJs.Mvc.Mvc.Views.UrlGenerator.GenerateUrl(action));
        };
    }).call($t, $t.ActionControllerHelper$1, $t.ActionControllerHelper$1.prototype);
    $WootzJs$Mvc$AssemblyTypes.push($t.ActionControllerHelper$1);
}).call(null, WootzJs.Mvc.Mvc.Views.ActionHelper, WootzJs.Mvc.Mvc.Views.ActionHelper.prototype);
$WootzJs$Mvc$AssemblyTypes.push(WootzJs.Mvc.Mvc.Views.ActionHelper);
WootzJs.Mvc.Mvc.Views.AlignmentPanel = $define("WootzJs.Mvc.Mvc.Views.AlignmentPanel", WootzJs.Mvc.Mvc.Views.TablePanel);
(WootzJs.Mvc.Mvc.Views.AlignmentPanel.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Mvc$GetAssembly;
    $p.$type = $t;
    $t.$baseType = WootzJs.Mvc.Mvc.Views.TablePanel;
    $p.$typeName = "WootzJs.Mvc.Mvc.Views.AlignmentPanel";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("AlignmentPanel", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Mvc.Mvc.Views.AlignmentPanel", WootzJs.Mvc.Mvc.Views.AlignmentPanel, WootzJs.Mvc.Mvc.Views.TablePanel, $arrayinit([], System.Type), $arrayinit([], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("Top", WootzJs.Mvc.Mvc.Views.AlignmentPanel.prototype.Top, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("content", WootzJs.Mvc.Mvc.Views.Control, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.AlignmentPanel, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Mvc.Mvc.Views.AlignmentPanel.prototype.$ctor, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("content", WootzJs.Mvc.Mvc.Views.Control, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("horizontalAlignment", WootzJs.Mvc.Mvc.Views.HorizontalAlignment, 1, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("verticalAlignment", WootzJs.Mvc.Mvc.Views.VerticalAlignment, 2, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {};
    $t.Top = function(content) {
        return WootzJs.Mvc.Mvc.Views.AlignmentPanel.prototype.$ctor.$new(content, WootzJs.Mvc.Mvc.Views.HorizontalAlignment().Fill, WootzJs.Mvc.Mvc.Views.VerticalAlignment().Top);
    };
    $p.$ctor = function(content, horizontalAlignment, verticalAlignment) {
        WootzJs.Mvc.Mvc.Views.TablePanel.prototype.$ctor.call(this, WootzJs.Mvc.Mvc.Views.TableWidth.AllWeight(1));
        this.Add$2(content, WootzJs.Mvc.Mvc.Views.TableConstraint.prototype.$ctor.$new(
            horizontalAlignment, 
            verticalAlignment, 
            1, 
            1
        ));
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function(content, horizontalAlignment, verticalAlignment) {
        return new $p.$ctor.$type(
            this, 
            content, 
            horizontalAlignment, 
            verticalAlignment
        );
    };
}).call(null, WootzJs.Mvc.Mvc.Views.AlignmentPanel, WootzJs.Mvc.Mvc.Views.AlignmentPanel.prototype);
$WootzJs$Mvc$AssemblyTypes.push(WootzJs.Mvc.Mvc.Views.AlignmentPanel);
WootzJs.Mvc.Mvc.Views.CenteredPanel = $define("WootzJs.Mvc.Mvc.Views.CenteredPanel", WootzJs.Mvc.Mvc.Views.Control);
(WootzJs.Mvc.Mvc.Views.CenteredPanel.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Mvc$GetAssembly;
    $p.$type = $t;
    $t.$baseType = WootzJs.Mvc.Mvc.Views.Control;
    $p.$typeName = "WootzJs.Mvc.Mvc.Views.CenteredPanel";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("CenteredPanel", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Mvc.Mvc.Views.CenteredPanel", WootzJs.Mvc.Mvc.Views.CenteredPanel, WootzJs.Mvc.Mvc.Views.Control, $arrayinit([], System.Type), $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("content", WootzJs.Mvc.Mvc.Views.Control, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("CreateNode", WootzJs.Mvc.Mvc.Views.CenteredPanel.prototype.CreateNode, $arrayinit([], System.Reflection.ParameterInfo), Element, System.Reflection.MethodAttributes().Family, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_Content", WootzJs.Mvc.Mvc.Views.CenteredPanel.prototype.get_Content, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Control, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Content", WootzJs.Mvc.Mvc.Views.CenteredPanel.prototype.set_Content, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Control, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Mvc.Mvc.Views.CenteredPanel.prototype.$ctor, $arrayinit([], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor$1", WootzJs.Mvc.Mvc.Views.CenteredPanel.prototype.$ctor$1, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("content", WootzJs.Mvc.Mvc.Views.Control, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.PropertyInfo.prototype.$ctor.$new("Content", WootzJs.Mvc.Mvc.Views.Control, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Content", WootzJs.Mvc.Mvc.Views.CenteredPanel.prototype.get_Content, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Control, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Content", WootzJs.Mvc.Mvc.Views.CenteredPanel.prototype.set_Content, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Control, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute))], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {};
    $p.content = null;
    $p.contentContainer = null;
    $p.$ctor = function() {
        WootzJs.Mvc.Mvc.Views.Control.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.$ctor$1 = function(content) {
        WootzJs.Mvc.Mvc.Views.Control.prototype.$ctor.call(this);
        this.set_Content(content);
    };
    $p.$ctor$1.$type = $t;
    $p.$ctor$1.$new = function(content) {
        return new $p.$ctor$1.$type(this, content);
    };
    $p.CreateNode = function() {
        var table = WootzJs.Web.Browser().get_Document().createElement("table");
        table.style.width = "100%";
        table.style.height = "100%";
        table.style.borderCollapse = "collapse";
        var row = WootzJs.Web.Browser().get_Document().createElement("tr");
        table.appendChild(row);
        var td = WootzJs.Web.Browser().get_Document().createElement("td");
        td.setAttribute("align", "center");
        td.style.verticalAlign = "middle";
        this.contentContainer = WootzJs.Web.Browser().get_Document().createElement("div");
        td.appendChild(this.contentContainer);
        row.appendChild(td);
        var outerDiv = WootzJs.Web.Browser().get_Document().createElement("div");
        outerDiv.style.width = "100%";
        outerDiv.style.height = "100%";
        outerDiv.appendChild(table);
        return outerDiv;
    };
    $p.get_Content = function() {
        return this.content;
    };
    $p.set_Content = function(value) {
        if (this.content != null) {
            this.Remove(this.content);
            WootzJs.Web.NodeExtensions.Remove(this.content.get_Node());
        }
        this.content = value;
        if (this.content != null) {
            this.Add(this.content);
            var childNode = value.get_Node();
            this.contentContainer.appendChild(childNode);
        }
    };
}).call(null, WootzJs.Mvc.Mvc.Views.CenteredPanel, WootzJs.Mvc.Mvc.Views.CenteredPanel.prototype);
$WootzJs$Mvc$AssemblyTypes.push(WootzJs.Mvc.Mvc.Views.CenteredPanel);
WootzJs.Mvc.Mvc.Views.CheckBox = $define("WootzJs.Mvc.Mvc.Views.CheckBox", WootzJs.Mvc.Mvc.Views.Control);
(WootzJs.Mvc.Mvc.Views.CheckBox.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Mvc$GetAssembly;
    $p.$type = $t;
    $t.$baseType = WootzJs.Mvc.Mvc.Views.Control;
    $p.$typeName = "WootzJs.Mvc.Mvc.Views.CheckBox";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("CheckBox", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Mvc.Mvc.Views.CheckBox", WootzJs.Mvc.Mvc.Views.CheckBox, WootzJs.Mvc.Mvc.Views.Control, $arrayinit([], System.Type), $arrayinit([], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("add_Changed", WootzJs.Mvc.Mvc.Views.CheckBox.prototype.add_Changed, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Action, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("remove_Changed", WootzJs.Mvc.Mvc.Views.CheckBox.prototype.remove_Changed, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Action, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("CreateNode", WootzJs.Mvc.Mvc.Views.CheckBox.prototype.CreateNode, $arrayinit([], System.Reflection.ParameterInfo), Element, System.Reflection.MethodAttributes().Family, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("OnJsChanged", WootzJs.Mvc.Mvc.Views.CheckBox.prototype.OnJsChanged, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("evt", Event, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Private, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_IsChecked", WootzJs.Mvc.Mvc.Views.CheckBox.prototype.get_IsChecked, $arrayinit([], System.Reflection.ParameterInfo), System.Boolean, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_IsChecked", WootzJs.Mvc.Mvc.Views.CheckBox.prototype.set_IsChecked, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Boolean, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_Text", WootzJs.Mvc.Mvc.Views.CheckBox.prototype.get_Text, $arrayinit([], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Text", WootzJs.Mvc.Mvc.Views.CheckBox.prototype.set_Text, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", String, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Mvc.Mvc.Views.CheckBox.prototype.$ctor, $arrayinit([], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor$1", WootzJs.Mvc.Mvc.Views.CheckBox.prototype.$ctor$1, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("text", String, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.PropertyInfo.prototype.$ctor.$new("IsChecked", System.Boolean, System.Reflection.MethodInfo.prototype.$ctor.$new("get_IsChecked", WootzJs.Mvc.Mvc.Views.CheckBox.prototype.get_IsChecked, $arrayinit([], System.Reflection.ParameterInfo), System.Boolean, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_IsChecked", WootzJs.Mvc.Mvc.Views.CheckBox.prototype.set_IsChecked, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Boolean, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("Text", String, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Text", WootzJs.Mvc.Mvc.Views.CheckBox.prototype.get_Text, $arrayinit([], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Text", WootzJs.Mvc.Mvc.Views.CheckBox.prototype.set_Text, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", String, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute))], System.Reflection.PropertyInfo), $arrayinit([System.Reflection.EventInfo.prototype.$ctor.$new("Changed", System.Action, System.Reflection.MethodInfo.prototype.$ctor.$new("add_Changed", WootzJs.Mvc.Mvc.Views.CheckBox.prototype.add_Changed, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Action, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("remove_Changed", WootzJs.Mvc.Mvc.Views.CheckBox.prototype.remove_Changed, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Action, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Attribute))], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {};
    $p.$Changed$k__BackingField = null;
    $p.add_Changed = function(value) {
        this.$Changed$k__BackingField = System.Delegate.Combine(this.$Changed$k__BackingField, value);
    };
    $p.remove_Changed = function(value) {
        this.$Changed$k__BackingField = System.Delegate.Remove(this.$Changed$k__BackingField, value);
    };
    $p.label = null;
    $p.checkbox = null;
    $p.$ctor = function() {
        WootzJs.Mvc.Mvc.Views.Control.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.$ctor$1 = function(text) {
        WootzJs.Mvc.Mvc.Views.Control.prototype.$ctor.call(this);
        this.set_Text(text);
    };
    $p.$ctor$1.$type = $t;
    $p.$ctor$1.$new = function(text) {
        return new $p.$ctor$1.$type(this, text);
    };
    $p.CreateNode = function() {
        this.label = WootzJs.Web.Browser().get_Document().createElement("span");
        var span = WootzJs.Web.Browser().get_Document().createElement("span");
        this.checkbox = WootzJs.Web.Browser().get_Document().createElement("input");
        this.checkbox.setAttribute("type", "checkbox");
        this.checkbox.addEventListener("change", $delegate(
            this, 
            System.Action$1$(Event), 
            this.OnJsChanged, 
            "OnJsChanged$delegate"
        ));
        span.appendChild(this.checkbox);
        span.appendChild(this.label);
        return span;
    };
    $p.OnJsChanged = function(evt) {
        var changed = this.$Changed$k__BackingField;
        if (changed != null)
            changed();
    };
    $p.get_IsChecked = function() {
        this.EnsureNodeExists();
        return this.checkbox.hasAttribute("checked");
    };
    $p.set_IsChecked = function(value) {
        this.EnsureNodeExists();
        if (value)
            this.checkbox.setAttribute("checked", "checked");
        else
            this.checkbox.removeAttribute("checked");
    };
    $p.get_Text = function() {
        this.EnsureNodeExists();
        return this.label.innerHTML;
    };
    $p.set_Text = function(value) {
        this.EnsureNodeExists();
        this.label.innerHTML = value;
    };
}).call(null, WootzJs.Mvc.Mvc.Views.CheckBox, WootzJs.Mvc.Mvc.Views.CheckBox.prototype);
$WootzJs$Mvc$AssemblyTypes.push(WootzJs.Mvc.Mvc.Views.CheckBox);
WootzJs.Mvc.Mvc.Views.Css.CssBorder = $define("WootzJs.Mvc.Mvc.Views.Css.CssBorder", WootzJs.Mvc.Mvc.Views.Css.CssDeclaration);
(WootzJs.Mvc.Mvc.Views.Css.CssBorder.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Mvc$GetAssembly;
    $p.$type = $t;
    $t.$baseType = WootzJs.Mvc.Mvc.Views.Css.CssDeclaration;
    $p.$typeName = "WootzJs.Mvc.Mvc.Views.Css.CssBorder";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("CssBorder", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Mvc.Mvc.Views.Css.CssBorder", WootzJs.Mvc.Mvc.Views.Css.CssBorder, WootzJs.Mvc.Mvc.Views.Css.CssDeclaration, $arrayinit([], System.Type), $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("left", WootzJs.Mvc.Mvc.Views.Css.CssBorderSide, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("top", WootzJs.Mvc.Mvc.Views.Css.CssBorderSide, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("right", WootzJs.Mvc.Mvc.Views.Css.CssBorderSide, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("bottom", WootzJs.Mvc.Mvc.Views.Css.CssBorderSide, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("ClearGlobals", WootzJs.Mvc.Mvc.Views.Css.CssBorder.prototype.ClearGlobals, $arrayinit([], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Assembly, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Attach", WootzJs.Mvc.Mvc.Views.Css.CssBorder.prototype.Attach, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("node", WootzJs.Web.ElementStyle, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Assembly, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_Left", WootzJs.Mvc.Mvc.Views.Css.CssBorder.prototype.get_Left, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Css.CssBorderSide, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Left", WootzJs.Mvc.Mvc.Views.Css.CssBorder.prototype.set_Left, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Css.CssBorderSide, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_Top", WootzJs.Mvc.Mvc.Views.Css.CssBorder.prototype.get_Top, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Css.CssBorderSide, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Top", WootzJs.Mvc.Mvc.Views.Css.CssBorder.prototype.set_Top, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Css.CssBorderSide, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_Right", WootzJs.Mvc.Mvc.Views.Css.CssBorder.prototype.get_Right, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Css.CssBorderSide, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Right", WootzJs.Mvc.Mvc.Views.Css.CssBorder.prototype.set_Right, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Css.CssBorderSide, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_Bottom", WootzJs.Mvc.Mvc.Views.Css.CssBorder.prototype.get_Bottom, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Css.CssBorderSide, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Bottom", WootzJs.Mvc.Mvc.Views.Css.CssBorder.prototype.set_Bottom, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Css.CssBorderSide, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_Width", WootzJs.Mvc.Mvc.Views.Css.CssBorder.prototype.get_Width, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Width", WootzJs.Mvc.Mvc.Views.Css.CssBorder.prototype.set_Width, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Mvc.Mvc.Views.Css.CssBorder.prototype.$ctor, $arrayinit([], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.PropertyInfo.prototype.$ctor.$new("Left", WootzJs.Mvc.Mvc.Views.Css.CssBorderSide, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Left", WootzJs.Mvc.Mvc.Views.Css.CssBorder.prototype.get_Left, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Css.CssBorderSide, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Left", WootzJs.Mvc.Mvc.Views.Css.CssBorder.prototype.set_Left, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Css.CssBorderSide, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("Top", WootzJs.Mvc.Mvc.Views.Css.CssBorderSide, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Top", WootzJs.Mvc.Mvc.Views.Css.CssBorder.prototype.get_Top, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Css.CssBorderSide, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Top", WootzJs.Mvc.Mvc.Views.Css.CssBorder.prototype.set_Top, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Css.CssBorderSide, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("Right", WootzJs.Mvc.Mvc.Views.Css.CssBorderSide, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Right", WootzJs.Mvc.Mvc.Views.Css.CssBorder.prototype.get_Right, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Css.CssBorderSide, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Right", WootzJs.Mvc.Mvc.Views.Css.CssBorder.prototype.set_Right, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Css.CssBorderSide, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("Bottom", WootzJs.Mvc.Mvc.Views.Css.CssBorderSide, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Bottom", WootzJs.Mvc.Mvc.Views.Css.CssBorder.prototype.get_Bottom, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Css.CssBorderSide, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Bottom", WootzJs.Mvc.Mvc.Views.Css.CssBorder.prototype.set_Bottom, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Css.CssBorderSide, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("Width", WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Width", WootzJs.Mvc.Mvc.Views.Css.CssBorder.prototype.get_Width, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Width", WootzJs.Mvc.Mvc.Views.Css.CssBorder.prototype.set_Width, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute))], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {};
    $p.$ctor = function() {
        WootzJs.Mvc.Mvc.Views.Css.CssDeclaration.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.left = null;
    $p.top = null;
    $p.right = null;
    $p.bottom = null;
    $p.ClearGlobals = function() {
        this.Set("border-size", "");
        this.Set("border-style", "");
        this.Set("border-color", "");
    };
    $p.Attach = function(node) {
        WootzJs.Mvc.Mvc.Views.Css.CssDeclaration.prototype.Attach.call(this, node);
        if (this.get_Left() != null)
            this.get_Left().Attach$1(node, this, "left");
        if (this.get_Top() != null)
            this.get_Top().Attach$1(node, this, "top");
        if (this.get_Right() != null)
            this.get_Right().Attach$1(node, this, "right");
        if (this.get_Bottom() != null)
            this.get_Bottom().Attach$1(node, this, "bottom");
    };
    $p.get_Left = function() {
        return this.left;
    };
    $p.set_Left = function(value) {
        this.left = value;
        if (this.node != null)
            value.Attach$1(this.node, this, "left");
    };
    $p.get_Top = function() {
        return this.top;
    };
    $p.set_Top = function(value) {
        this.top = value;
        if (this.node != null)
            value.Attach$1(this.node, this, "top");
    };
    $p.get_Right = function() {
        return this.right;
    };
    $p.set_Right = function(value) {
        this.right = value;
        if (this.node != null)
            value.Attach$1(this.node, this, "right");
    };
    $p.get_Bottom = function() {
        return this.bottom;
    };
    $p.set_Bottom = function(value) {
        this.bottom = value;
        if (this.node != null)
            value.Attach$1(this.node, this, "bottom");
    };
    $p.get_Width = function() {
        return WootzJs.Mvc.Mvc.Views.Css.CssNumericValue.Parse$1(this.Get("border-width"));
    };
    $p.set_Width = function(value) {
        this.Act($delegate(this, System.Action, function() {
            if (this.Get("border-style") == "")
                this.Set("border-style", "solid");
            this.Set("border-width", value);
        }));
    };
}).call(null, WootzJs.Mvc.Mvc.Views.Css.CssBorder, WootzJs.Mvc.Mvc.Views.Css.CssBorder.prototype);
$WootzJs$Mvc$AssemblyTypes.push(WootzJs.Mvc.Mvc.Views.Css.CssBorder);
WootzJs.Mvc.Mvc.Views.Css.CssBorderCollapse = $define("WootzJs.Mvc.Mvc.Views.Css.CssBorderCollapse", System.Enum);
(WootzJs.Mvc.Mvc.Views.Css.CssBorderCollapse.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Mvc$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Enum;
    $p.$typeName = "WootzJs.Mvc.Mvc.Views.Css.CssBorderCollapse";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("CssBorderCollapse", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Mvc.Mvc.Views.Css.CssBorderCollapse", WootzJs.Mvc.Mvc.Views.Css.CssBorderCollapse, System.Enum, $arrayinit([], System.Type), $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("Collapse", WootzJs.Mvc.Mvc.Views.Css.CssBorderCollapse, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().Literal, 0, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Mvc.Mvc.Views.Css.CssBorderCollapse.prototype.$ctor, $arrayinit([], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), true);return this.$type;};
    $t.$StaticInitializer = function() {
        $t.Collapse = 0;
        $t.Collapse$ = $p.$ctor.$new("Collapse", WootzJs.Mvc.Mvc.Views.Css.CssBorderCollapse().Collapse);
    };
    $p.$ctor = function(name, value) {
        System.Enum.prototype.$ctor.call(this, name, value);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function(name, value) {
        return new $p.$ctor.$type(this, name, value);
    };
}).call(null, WootzJs.Mvc.Mvc.Views.Css.CssBorderCollapse, WootzJs.Mvc.Mvc.Views.Css.CssBorderCollapse.prototype);
$WootzJs$Mvc$AssemblyTypes.push(WootzJs.Mvc.Mvc.Views.Css.CssBorderCollapse);
WootzJs.Mvc.Mvc.Views.Css.CssBorderCollapses = $define("WootzJs.Mvc.Mvc.Views.Css.CssBorderCollapses", System.Object);
(WootzJs.Mvc.Mvc.Views.Css.CssBorderCollapses.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Mvc$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Mvc.Mvc.Views.Css.CssBorderCollapses";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("CssBorderCollapses", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Mvc.Mvc.Views.Css.CssBorderCollapses", WootzJs.Mvc.Mvc.Views.Css.CssBorderCollapses, System.Object, $arrayinit([], System.Type), $arrayinit([], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("GetValue", WootzJs.Mvc.Mvc.Views.Css.CssBorderCollapses.prototype.GetValue, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Css.CssBorderCollapse, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Parse", WootzJs.Mvc.Mvc.Views.Css.CssBorderCollapses.prototype.Parse, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("s", String, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Css.CssBorderCollapse, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {};
    $t.GetValue = function(value) {
        switch (value) {
            case WootzJs.Mvc.Mvc.Views.Css.CssBorderCollapse().Collapse:
                return "collapse";
            default:
                throw System.InvalidOperationException.prototype.$ctor$1.$new("Unknown border-collapse: " + $safeToString(value)).InternalInit(new Error());
        }
    };
    $t.Parse = function(s) {
        switch (s) {
            case "collapse":
                return WootzJs.Mvc.Mvc.Views.Css.CssBorderCollapse().Collapse;
            default:
                throw System.InvalidOperationException.prototype.$ctor$1.$new("Unknown value for border-collapse: " + s).InternalInit(new Error());
        }
    };
}).call(null, WootzJs.Mvc.Mvc.Views.Css.CssBorderCollapses, WootzJs.Mvc.Mvc.Views.Css.CssBorderCollapses.prototype);
$WootzJs$Mvc$AssemblyTypes.push(WootzJs.Mvc.Mvc.Views.Css.CssBorderCollapses);
WootzJs.Mvc.Mvc.Views.Css.CssBorderSide = $define("WootzJs.Mvc.Mvc.Views.Css.CssBorderSide", WootzJs.Mvc.Mvc.Views.Css.CssDeclaration);
(WootzJs.Mvc.Mvc.Views.Css.CssBorderSide.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Mvc$GetAssembly;
    $p.$type = $t;
    $t.$baseType = WootzJs.Mvc.Mvc.Views.Css.CssDeclaration;
    $p.$typeName = "WootzJs.Mvc.Mvc.Views.Css.CssBorderSide";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("CssBorderSide", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Mvc.Mvc.Views.Css.CssBorderSide", WootzJs.Mvc.Mvc.Views.Css.CssBorderSide, WootzJs.Mvc.Mvc.Views.Css.CssDeclaration, $arrayinit([], System.Type), $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("border", WootzJs.Mvc.Mvc.Views.Css.CssBorder, System.Reflection.FieldAttributes().Assembly, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("side", String, System.Reflection.FieldAttributes().Assembly, null, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("Attach$1", WootzJs.Mvc.Mvc.Views.Css.CssBorderSide.prototype.Attach$1, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("node", WootzJs.Web.ElementStyle, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("border", WootzJs.Mvc.Mvc.Views.Css.CssBorder, 1, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("side", String, 2, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Assembly, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_Width", WootzJs.Mvc.Mvc.Views.Css.CssBorderSide.prototype.get_Width, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Width", WootzJs.Mvc.Mvc.Views.Css.CssBorderSide.prototype.set_Width, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Mvc.Mvc.Views.Css.CssBorderSide.prototype.$ctor, $arrayinit([], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.PropertyInfo.prototype.$ctor.$new("Width", WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Width", WootzJs.Mvc.Mvc.Views.Css.CssBorderSide.prototype.get_Width, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Width", WootzJs.Mvc.Mvc.Views.Css.CssBorderSide.prototype.set_Width, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute))], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {};
    $p.$ctor = function() {
        WootzJs.Mvc.Mvc.Views.Css.CssDeclaration.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.border = null;
    $p.side = null;
    $p.Attach$1 = function(node, border, side) {
        this.border = border;
        this.side = side;
        WootzJs.Mvc.Mvc.Views.Css.CssDeclaration.prototype.Attach.call(this, node);
    };
    $p.get_Width = function() {
        return WootzJs.Mvc.Mvc.Views.Css.CssNumericValue.Parse$1(this.Get("border-" + this.side + "-width"));
    };
    $p.set_Width = function(value) {
        this.Act($delegate(this, System.Action, function() {
            if (this.Get("border-" + this.side + "-style") == "")
                this.Set("border-" + this.side + "-style", "solid");
            this.Set("border-" + this.side + "-width", value);
        }));
    };
}).call(null, WootzJs.Mvc.Mvc.Views.Css.CssBorderSide, WootzJs.Mvc.Mvc.Views.Css.CssBorderSide.prototype);
$WootzJs$Mvc$AssemblyTypes.push(WootzJs.Mvc.Mvc.Views.Css.CssBorderSide);
WootzJs.Mvc.Mvc.Views.Css.CssBoxShadow = $define("WootzJs.Mvc.Mvc.Views.Css.CssBoxShadow", WootzJs.Mvc.Mvc.Views.Css.CssDeclaration);
(WootzJs.Mvc.Mvc.Views.Css.CssBoxShadow.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Mvc$GetAssembly;
    $p.$type = $t;
    $t.$baseType = WootzJs.Mvc.Mvc.Views.Css.CssDeclaration;
    $p.$typeName = "WootzJs.Mvc.Mvc.Views.Css.CssBoxShadow";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("CssBoxShadow", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Mvc.Mvc.Views.Css.CssBoxShadow", WootzJs.Mvc.Mvc.Views.Css.CssBoxShadow, WootzJs.Mvc.Mvc.Views.Css.CssDeclaration, $arrayinit([], System.Type), $arrayinit([], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("GetComponent", WootzJs.Mvc.Mvc.Views.Css.CssBoxShadow.prototype.GetComponent, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("index", System.Int32, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Private, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("SetComponent", WootzJs.Mvc.Mvc.Views.Css.CssBoxShadow.prototype.SetComponent, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("index", System.Int32, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Css.CssValue, 1, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_HShadow", WootzJs.Mvc.Mvc.Views.Css.CssBoxShadow.prototype.get_HShadow, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_HShadow", WootzJs.Mvc.Mvc.Views.Css.CssBoxShadow.prototype.set_HShadow, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_VShadow", WootzJs.Mvc.Mvc.Views.Css.CssBoxShadow.prototype.get_VShadow, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_VShadow", WootzJs.Mvc.Mvc.Views.Css.CssBoxShadow.prototype.set_VShadow, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_Blur", WootzJs.Mvc.Mvc.Views.Css.CssBoxShadow.prototype.get_Blur, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Blur", WootzJs.Mvc.Mvc.Views.Css.CssBoxShadow.prototype.set_Blur, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_Spread", WootzJs.Mvc.Mvc.Views.Css.CssBoxShadow.prototype.get_Spread, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Spread", WootzJs.Mvc.Mvc.Views.Css.CssBoxShadow.prototype.set_Spread, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_Color", WootzJs.Mvc.Mvc.Views.Css.CssBoxShadow.prototype.get_Color, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Css.CssColor, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Color", WootzJs.Mvc.Mvc.Views.Css.CssBoxShadow.prototype.set_Color, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Css.CssColor, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_Inset", WootzJs.Mvc.Mvc.Views.Css.CssBoxShadow.prototype.get_Inset, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Css.CssInset, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Inset", WootzJs.Mvc.Mvc.Views.Css.CssBoxShadow.prototype.set_Inset, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Css.CssInset, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Mvc.Mvc.Views.Css.CssBoxShadow.prototype.$ctor, $arrayinit([], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor$1", WootzJs.Mvc.Mvc.Views.Css.CssBoxShadow.prototype.$ctor$1, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("hshadow", WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("vshadow", WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, 1, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("blur", WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, 2, System.Reflection.ParameterAttributes().HasDefault, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("spread", WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, 3, System.Reflection.ParameterAttributes().HasDefault, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("color", WootzJs.Mvc.Mvc.Views.Css.CssColor, 4, System.Reflection.ParameterAttributes().HasDefault, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("inset", System.Boolean, 5, System.Reflection.ParameterAttributes().HasDefault, false, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.PropertyInfo.prototype.$ctor.$new("HShadow", WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, System.Reflection.MethodInfo.prototype.$ctor.$new("get_HShadow", WootzJs.Mvc.Mvc.Views.Css.CssBoxShadow.prototype.get_HShadow, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_HShadow", WootzJs.Mvc.Mvc.Views.Css.CssBoxShadow.prototype.set_HShadow, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("VShadow", WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, System.Reflection.MethodInfo.prototype.$ctor.$new("get_VShadow", WootzJs.Mvc.Mvc.Views.Css.CssBoxShadow.prototype.get_VShadow, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_VShadow", WootzJs.Mvc.Mvc.Views.Css.CssBoxShadow.prototype.set_VShadow, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("Blur", WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Blur", WootzJs.Mvc.Mvc.Views.Css.CssBoxShadow.prototype.get_Blur, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Blur", WootzJs.Mvc.Mvc.Views.Css.CssBoxShadow.prototype.set_Blur, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("Spread", WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Spread", WootzJs.Mvc.Mvc.Views.Css.CssBoxShadow.prototype.get_Spread, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Spread", WootzJs.Mvc.Mvc.Views.Css.CssBoxShadow.prototype.set_Spread, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("Color", WootzJs.Mvc.Mvc.Views.Css.CssColor, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Color", WootzJs.Mvc.Mvc.Views.Css.CssBoxShadow.prototype.get_Color, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Css.CssColor, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Color", WootzJs.Mvc.Mvc.Views.Css.CssBoxShadow.prototype.set_Color, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Css.CssColor, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("Inset", WootzJs.Mvc.Mvc.Views.Css.CssInset, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Inset", WootzJs.Mvc.Mvc.Views.Css.CssBoxShadow.prototype.get_Inset, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Css.CssInset, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Inset", WootzJs.Mvc.Mvc.Views.Css.CssBoxShadow.prototype.set_Inset, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Css.CssInset, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute))], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {};
    $p.$ctor = function() {
        WootzJs.Mvc.Mvc.Views.Css.CssDeclaration.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.$ctor$1 = function(hshadow, vshadow, blur, spread, color, inset) {
        WootzJs.Mvc.Mvc.Views.Css.CssDeclaration.prototype.$ctor.call(this);
        this.set_HShadow(hshadow);
        this.set_VShadow(vshadow);
        this.set_Blur(blur);
        this.set_Spread(spread);
        this.set_Color(color);
        this.set_Inset(inset ? WootzJs.Mvc.Mvc.Views.Css.CssInset().Instance : null);
    };
    $p.$ctor$1.$type = $t;
    $p.$ctor$1.$new = function(hshadow, vshadow, blur, spread, color, inset) {
        return new $p.$ctor$1.$type(
            this, 
            hshadow, 
            vshadow, 
            blur, 
            spread, 
            color, 
            inset
        );
    };
    $p.GetComponent = function(index) {
        var parts = String.prototype.Split.call(this.Get("box-shadow"), [" "]);
        if (index < parts.length)
            return parts[index];
        else
            return null;
    };
    $p.SetComponent = function(index, value) {
        if (value == null && index < 2)
            throw System.Exception.prototype.$ctor$1.$new("HShadow and VShadow are required").InternalInit(new Error());
        this.Act($delegate(this, System.Action, function() {
            var hshadow = this.get_HShadow();
            var vshadow = this.get_VShadow();
            if (hshadow == null)
                hshadow = WootzJs.Mvc.Mvc.Views.Css.CssNumericValue.op_Implicit(1);
            if (vshadow == null)
                vshadow = WootzJs.Mvc.Mvc.Views.Css.CssNumericValue.op_Implicit(1);
            var blur = this.get_Blur();
            if (blur == null && index > 2)
                blur = WootzJs.Mvc.Mvc.Views.Css.CssNumericValue.op_Implicit(1);
            var spread = this.get_Spread();
            if (spread == null && index > 3)
                spread = WootzJs.Mvc.Mvc.Views.Css.CssNumericValue.op_Implicit(1);
            var color = this.get_Color();
            if (color == null && index > 4)
                color = WootzJs.Mvc.Mvc.Views.Css.CssColor().Black;
            var inset = this.get_Inset();
            if (value == null) {
                if (index < 5)
                    inset = null;
                if (index < 4)
                    color = null;
                if (index < 3)
                    spread = null;
            }
            var args = $arrayinit([
                hshadow, 
                vshadow, 
                blur, 
                spread, 
                color, 
                inset
            ], WootzJs.Mvc.Mvc.Views.Css.CssValue);
            args[index] = value;
            args = System.Linq.Enumerable.ToArray(WootzJs.Mvc.Mvc.Views.Css.CssValue, System.Linq.Enumerable.Where(WootzJs.Mvc.Mvc.Views.Css.CssValue, args, $delegate(this, System.Func$2$(WootzJs.Mvc.Mvc.Views.Css.CssValue, System.Boolean), function(x) {
                return x != null;
            })));
            var builder = System.Text.StringBuilder.prototype.$ctor.$new();
            {
                var $anon$1iterator = args;
                var $anon$2enumerator = $anon$1iterator.System$Collections$IEnumerable$GetEnumerator();
                while ($anon$2enumerator.System$Collections$IEnumerator$MoveNext()) {
                    var argument = $anon$2enumerator.System$Collections$IEnumerator$get_Current();
                    if (builder.get_Length() > 0)
                        builder.Append$2(" ");
                    builder.Append$1(argument);
                }
            }
            this.Set("box-shadow", builder.ToString());
        }));
    };
    $p.get_HShadow = function() {
        return WootzJs.Mvc.Mvc.Views.Css.CssNumericValue.Parse$1(this.GetComponent(0));
    };
    $p.set_HShadow = function(value) {
        this.SetComponent(0, value);
    };
    $p.get_VShadow = function() {
        return WootzJs.Mvc.Mvc.Views.Css.CssNumericValue.Parse$1(this.GetComponent(1));
    };
    $p.set_VShadow = function(value) {
        this.SetComponent(1, value);
    };
    $p.get_Blur = function() {
        return WootzJs.Mvc.Mvc.Views.Css.CssNumericValue.Parse$1(this.GetComponent(2));
    };
    $p.set_Blur = function(value) {
        this.SetComponent(2, value);
    };
    $p.get_Spread = function() {
        return WootzJs.Mvc.Mvc.Views.Css.CssNumericValue.Parse$1(this.GetComponent(3));
    };
    $p.set_Spread = function(value) {
        this.SetComponent(3, value);
    };
    $p.get_Color = function() {
        return WootzJs.Mvc.Mvc.Views.Css.CssColor.Parse$1(this.GetComponent(4));
    };
    $p.set_Color = function(value) {
        this.SetComponent(4, value);
    };
    $p.get_Inset = function() {
        return this.GetComponent(5) == "inset" ? WootzJs.Mvc.Mvc.Views.Css.CssInset().Instance : null;
    };
    $p.set_Inset = function(value) {
        this.SetComponent(5, value);
    };
}).call(null, WootzJs.Mvc.Mvc.Views.Css.CssBoxShadow, WootzJs.Mvc.Mvc.Views.Css.CssBoxShadow.prototype);
$WootzJs$Mvc$AssemblyTypes.push(WootzJs.Mvc.Mvc.Views.Css.CssBoxShadow);
WootzJs.Mvc.Mvc.Views.Css.CssColor = $define("WootzJs.Mvc.Mvc.Views.Css.CssColor", WootzJs.Mvc.Mvc.Views.Css.CssValue);
(WootzJs.Mvc.Mvc.Views.Css.CssColor.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Mvc$GetAssembly;
    $p.$type = $t;
    $t.$baseType = WootzJs.Mvc.Mvc.Views.Css.CssValue;
    $p.$typeName = "WootzJs.Mvc.Mvc.Views.Css.CssColor";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("CssColor", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Mvc.Mvc.Views.Css.CssColor", WootzJs.Mvc.Mvc.Views.Css.CssColor, WootzJs.Mvc.Mvc.Views.Css.CssValue, $arrayinit([], System.Type), $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("Inherit", WootzJs.Mvc.Mvc.Views.Css.CssColor, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().InitOnly, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("Black", WootzJs.Mvc.Mvc.Views.Css.CssColor, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().InitOnly, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("Blue", WootzJs.Mvc.Mvc.Views.Css.CssColor, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().InitOnly, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("Fuchsia", WootzJs.Mvc.Mvc.Views.Css.CssColor, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().InitOnly, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("Gray", WootzJs.Mvc.Mvc.Views.Css.CssColor, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().InitOnly, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("Green", WootzJs.Mvc.Mvc.Views.Css.CssColor, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().InitOnly, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("Lime", WootzJs.Mvc.Mvc.Views.Css.CssColor, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().InitOnly, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("Maroon", WootzJs.Mvc.Mvc.Views.Css.CssColor, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().InitOnly, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("Navy", WootzJs.Mvc.Mvc.Views.Css.CssColor, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().InitOnly, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("Olive", WootzJs.Mvc.Mvc.Views.Css.CssColor, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().InitOnly, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("Orange", WootzJs.Mvc.Mvc.Views.Css.CssColor, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().InitOnly, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("Purple", WootzJs.Mvc.Mvc.Views.Css.CssColor, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().InitOnly, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("Red", WootzJs.Mvc.Mvc.Views.Css.CssColor, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().InitOnly, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("Silver", WootzJs.Mvc.Mvc.Views.Css.CssColor, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().InitOnly, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("Teal", WootzJs.Mvc.Mvc.Views.Css.CssColor, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().InitOnly, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("White", WootzJs.Mvc.Mvc.Views.Css.CssColor, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().InitOnly, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("Yellow", WootzJs.Mvc.Mvc.Views.Css.CssColor, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().InitOnly, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("value", String, System.Reflection.FieldAttributes().Public, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("$Value$k__BackingField", String, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("$cctor", WootzJs.Mvc.Mvc.Views.Css.CssColor.prototype.$cctor, $arrayinit([], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Private | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_Value", WootzJs.Mvc.Mvc.Views.Css.CssColor.prototype.get_Value, $arrayinit([], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Value", WootzJs.Mvc.Mvc.Views.Css.CssColor.prototype.set_Value, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", String, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("ToString", WootzJs.Mvc.Mvc.Views.Css.CssColor.prototype.ToString, $arrayinit([], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Parse$1", WootzJs.Mvc.Mvc.Views.Css.CssColor.prototype.Parse$1, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("s", String, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Css.CssColor, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Mvc.Mvc.Views.Css.CssColor.prototype.$ctor, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", String, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor$1", WootzJs.Mvc.Mvc.Views.Css.CssColor.prototype.$ctor$1, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("red", System.Int32, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("green", System.Int32, 1, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("blue", System.Int32, 2, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.PropertyInfo.prototype.$ctor.$new("Value", String, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Value", WootzJs.Mvc.Mvc.Views.Css.CssColor.prototype.get_Value, $arrayinit([], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Value", WootzJs.Mvc.Mvc.Views.Css.CssColor.prototype.set_Value, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", String, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute))], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {
        WootzJs.Mvc.Mvc.Views.Css.CssColor.Inherit = WootzJs.Mvc.Mvc.Views.Css.CssColor.prototype.$ctor.$new("inherit");
        WootzJs.Mvc.Mvc.Views.Css.CssColor.Black = WootzJs.Mvc.Mvc.Views.Css.CssColor.prototype.$ctor.$new("black");
        WootzJs.Mvc.Mvc.Views.Css.CssColor.Blue = WootzJs.Mvc.Mvc.Views.Css.CssColor.prototype.$ctor.$new("blue");
        WootzJs.Mvc.Mvc.Views.Css.CssColor.Fuchsia = WootzJs.Mvc.Mvc.Views.Css.CssColor.prototype.$ctor.$new("fuchsia");
        WootzJs.Mvc.Mvc.Views.Css.CssColor.Gray = WootzJs.Mvc.Mvc.Views.Css.CssColor.prototype.$ctor.$new("gray");
        WootzJs.Mvc.Mvc.Views.Css.CssColor.Green = WootzJs.Mvc.Mvc.Views.Css.CssColor.prototype.$ctor.$new("green");
        WootzJs.Mvc.Mvc.Views.Css.CssColor.Lime = WootzJs.Mvc.Mvc.Views.Css.CssColor.prototype.$ctor.$new("lime");
        WootzJs.Mvc.Mvc.Views.Css.CssColor.Maroon = WootzJs.Mvc.Mvc.Views.Css.CssColor.prototype.$ctor.$new("maroon");
        WootzJs.Mvc.Mvc.Views.Css.CssColor.Navy = WootzJs.Mvc.Mvc.Views.Css.CssColor.prototype.$ctor.$new("navy");
        WootzJs.Mvc.Mvc.Views.Css.CssColor.Olive = WootzJs.Mvc.Mvc.Views.Css.CssColor.prototype.$ctor.$new("olive");
        WootzJs.Mvc.Mvc.Views.Css.CssColor.Orange = WootzJs.Mvc.Mvc.Views.Css.CssColor.prototype.$ctor.$new("orange");
        WootzJs.Mvc.Mvc.Views.Css.CssColor.Purple = WootzJs.Mvc.Mvc.Views.Css.CssColor.prototype.$ctor.$new("purple");
        WootzJs.Mvc.Mvc.Views.Css.CssColor.Red = WootzJs.Mvc.Mvc.Views.Css.CssColor.prototype.$ctor.$new("red");
        WootzJs.Mvc.Mvc.Views.Css.CssColor.Silver = WootzJs.Mvc.Mvc.Views.Css.CssColor.prototype.$ctor.$new("silver");
        WootzJs.Mvc.Mvc.Views.Css.CssColor.Teal = WootzJs.Mvc.Mvc.Views.Css.CssColor.prototype.$ctor.$new("teal");
        WootzJs.Mvc.Mvc.Views.Css.CssColor.White = WootzJs.Mvc.Mvc.Views.Css.CssColor.prototype.$ctor.$new("white");
        WootzJs.Mvc.Mvc.Views.Css.CssColor.Yellow = WootzJs.Mvc.Mvc.Views.Css.CssColor.prototype.$ctor.$new("yellow");
    };
    $p.Inherit = null;
    $p.Black = null;
    $p.Blue = null;
    $p.Fuchsia = null;
    $p.Gray = null;
    $p.Green = null;
    $p.Lime = null;
    $p.Maroon = null;
    $p.Navy = null;
    $p.Olive = null;
    $p.Orange = null;
    $p.Purple = null;
    $p.Red = null;
    $p.Silver = null;
    $p.Teal = null;
    $p.White = null;
    $p.Yellow = null;
    $p.value = null;
    $p.$ctor = function(value) {
        WootzJs.Mvc.Mvc.Views.Css.CssValue.prototype.$ctor.call(this);
        this.value = value;
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function(value) {
        return new $p.$ctor.$type(this, value);
    };
    $p.$ctor$1 = function(red, green, blue) {
        WootzJs.Mvc.Mvc.Views.Css.CssValue.prototype.$ctor.call(this);
        var _red = WootzJs.Mvc.Mvc.MiscExtensions.ToHex(red, 2);
        var _green = WootzJs.Mvc.Mvc.MiscExtensions.ToHex(green, 2);
        var _blue = WootzJs.Mvc.Mvc.MiscExtensions.ToHex(blue, 2);
        this.value = "#" + _red + _green + _blue;
    };
    $p.$ctor$1.$type = $t;
    $p.$ctor$1.$new = function(red, green, blue) {
        return new $p.$ctor$1.$type(
            this, 
            red, 
            green, 
            blue
        );
    };
    $p.$Value$k__BackingField = null;
    $p.get_Value = function() {return this.$Value$k__BackingField;};
    $p.set_Value = function(value) {this.$Value$k__BackingField = value;};
    $p.ToString = function() {
        return this.value;
    };
    $t.Parse$1 = function(s) {
        if (s == null)
            return null;
        if (String.prototype.StartsWith.call(s, "#"))
            return WootzJs.Mvc.Mvc.Views.Css.CssColor.prototype.$ctor.$new(s);
        switch (s) {
            case "red":
            case "green":
            case "blue":
                return WootzJs.Mvc.Mvc.Views.Css.CssColor.prototype.$ctor.$new(s);
        }
        return null;
    };
}).call(null, WootzJs.Mvc.Mvc.Views.Css.CssColor, WootzJs.Mvc.Mvc.Views.Css.CssColor.prototype);
$WootzJs$Mvc$AssemblyTypes.push(WootzJs.Mvc.Mvc.Views.Css.CssColor);
WootzJs.Mvc.Mvc.Views.Css.CssCursor = $define("WootzJs.Mvc.Mvc.Views.Css.CssCursor", System.Enum);
(WootzJs.Mvc.Mvc.Views.Css.CssCursor.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Mvc$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Enum;
    $p.$typeName = "WootzJs.Mvc.Mvc.Views.Css.CssCursor";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("CssCursor", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Mvc.Mvc.Views.Css.CssCursor", WootzJs.Mvc.Mvc.Views.Css.CssCursor, System.Enum, $arrayinit([], System.Type), $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("Alias", WootzJs.Mvc.Mvc.Views.Css.CssCursor, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().Literal, 0, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("AllScroll", WootzJs.Mvc.Mvc.Views.Css.CssCursor, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().Literal, 1, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("Auto", WootzJs.Mvc.Mvc.Views.Css.CssCursor, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().Literal, 2, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("Cell", WootzJs.Mvc.Mvc.Views.Css.CssCursor, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().Literal, 3, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("ContextMenu", WootzJs.Mvc.Mvc.Views.Css.CssCursor, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().Literal, 4, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("ColResize", WootzJs.Mvc.Mvc.Views.Css.CssCursor, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().Literal, 5, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("Copy", WootzJs.Mvc.Mvc.Views.Css.CssCursor, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().Literal, 6, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("Crosshair", WootzJs.Mvc.Mvc.Views.Css.CssCursor, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().Literal, 7, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("Default", WootzJs.Mvc.Mvc.Views.Css.CssCursor, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().Literal, 8, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("EResize", WootzJs.Mvc.Mvc.Views.Css.CssCursor, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().Literal, 9, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("EWResize", WootzJs.Mvc.Mvc.Views.Css.CssCursor, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().Literal, 10, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("Help", WootzJs.Mvc.Mvc.Views.Css.CssCursor, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().Literal, 11, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("Move", WootzJs.Mvc.Mvc.Views.Css.CssCursor, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().Literal, 12, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("NResize", WootzJs.Mvc.Mvc.Views.Css.CssCursor, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().Literal, 13, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("NeResize", WootzJs.Mvc.Mvc.Views.Css.CssCursor, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().Literal, 14, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("NeswResize", WootzJs.Mvc.Mvc.Views.Css.CssCursor, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().Literal, 15, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("NsResize", WootzJs.Mvc.Mvc.Views.Css.CssCursor, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().Literal, 16, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("NwResize", WootzJs.Mvc.Mvc.Views.Css.CssCursor, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().Literal, 17, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("NwseResize", WootzJs.Mvc.Mvc.Views.Css.CssCursor, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().Literal, 18, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("NoDrop", WootzJs.Mvc.Mvc.Views.Css.CssCursor, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().Literal, 19, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("None", WootzJs.Mvc.Mvc.Views.Css.CssCursor, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().Literal, 20, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("NotAllowed", WootzJs.Mvc.Mvc.Views.Css.CssCursor, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().Literal, 21, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("Pointer", WootzJs.Mvc.Mvc.Views.Css.CssCursor, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().Literal, 22, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("Progress", WootzJs.Mvc.Mvc.Views.Css.CssCursor, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().Literal, 23, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("RowResize", WootzJs.Mvc.Mvc.Views.Css.CssCursor, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().Literal, 24, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("SResize", WootzJs.Mvc.Mvc.Views.Css.CssCursor, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().Literal, 25, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("SeResize", WootzJs.Mvc.Mvc.Views.Css.CssCursor, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().Literal, 26, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("SwResize", WootzJs.Mvc.Mvc.Views.Css.CssCursor, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().Literal, 27, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("Text", WootzJs.Mvc.Mvc.Views.Css.CssCursor, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().Literal, 28, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("Url", WootzJs.Mvc.Mvc.Views.Css.CssCursor, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().Literal, 29, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("VerticalText", WootzJs.Mvc.Mvc.Views.Css.CssCursor, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().Literal, 30, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("WResize", WootzJs.Mvc.Mvc.Views.Css.CssCursor, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().Literal, 31, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("Wait", WootzJs.Mvc.Mvc.Views.Css.CssCursor, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().Literal, 32, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("ZoomIn", WootzJs.Mvc.Mvc.Views.Css.CssCursor, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().Literal, 33, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("ZoomOut", WootzJs.Mvc.Mvc.Views.Css.CssCursor, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().Literal, 34, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("Inherit", WootzJs.Mvc.Mvc.Views.Css.CssCursor, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().Literal, 35, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Mvc.Mvc.Views.Css.CssCursor.prototype.$ctor, $arrayinit([], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), true);return this.$type;};
    $t.$StaticInitializer = function() {
        $t.Alias = 0;
        $t.Alias$ = $p.$ctor.$new("Alias", WootzJs.Mvc.Mvc.Views.Css.CssCursor().Alias);
        $t.AllScroll = WootzJs.Mvc.Mvc.Views.Css.CssCursor().Alias + 1;
        $t.AllScroll$ = $p.$ctor.$new("AllScroll", WootzJs.Mvc.Mvc.Views.Css.CssCursor().AllScroll);
        $t.Auto = WootzJs.Mvc.Mvc.Views.Css.CssCursor().AllScroll + 1;
        $t.Auto$ = $p.$ctor.$new("Auto", WootzJs.Mvc.Mvc.Views.Css.CssCursor().Auto);
        $t.Cell = WootzJs.Mvc.Mvc.Views.Css.CssCursor().Auto + 1;
        $t.Cell$ = $p.$ctor.$new("Cell", WootzJs.Mvc.Mvc.Views.Css.CssCursor().Cell);
        $t.ContextMenu = WootzJs.Mvc.Mvc.Views.Css.CssCursor().Cell + 1;
        $t.ContextMenu$ = $p.$ctor.$new("ContextMenu", WootzJs.Mvc.Mvc.Views.Css.CssCursor().ContextMenu);
        $t.ColResize = WootzJs.Mvc.Mvc.Views.Css.CssCursor().ContextMenu + 1;
        $t.ColResize$ = $p.$ctor.$new("ColResize", WootzJs.Mvc.Mvc.Views.Css.CssCursor().ColResize);
        $t.Copy = WootzJs.Mvc.Mvc.Views.Css.CssCursor().ColResize + 1;
        $t.Copy$ = $p.$ctor.$new("Copy", WootzJs.Mvc.Mvc.Views.Css.CssCursor().Copy);
        $t.Crosshair = WootzJs.Mvc.Mvc.Views.Css.CssCursor().Copy + 1;
        $t.Crosshair$ = $p.$ctor.$new("Crosshair", WootzJs.Mvc.Mvc.Views.Css.CssCursor().Crosshair);
        $t.Default = WootzJs.Mvc.Mvc.Views.Css.CssCursor().Crosshair + 1;
        $t.Default$ = $p.$ctor.$new("Default", WootzJs.Mvc.Mvc.Views.Css.CssCursor().Default);
        $t.EResize = WootzJs.Mvc.Mvc.Views.Css.CssCursor().Default + 1;
        $t.EResize$ = $p.$ctor.$new("EResize", WootzJs.Mvc.Mvc.Views.Css.CssCursor().EResize);
        $t.EWResize = WootzJs.Mvc.Mvc.Views.Css.CssCursor().EResize + 1;
        $t.EWResize$ = $p.$ctor.$new("EWResize", WootzJs.Mvc.Mvc.Views.Css.CssCursor().EWResize);
        $t.Help = WootzJs.Mvc.Mvc.Views.Css.CssCursor().EWResize + 1;
        $t.Help$ = $p.$ctor.$new("Help", WootzJs.Mvc.Mvc.Views.Css.CssCursor().Help);
        $t.Move = WootzJs.Mvc.Mvc.Views.Css.CssCursor().Help + 1;
        $t.Move$ = $p.$ctor.$new("Move", WootzJs.Mvc.Mvc.Views.Css.CssCursor().Move);
        $t.NResize = WootzJs.Mvc.Mvc.Views.Css.CssCursor().Move + 1;
        $t.NResize$ = $p.$ctor.$new("NResize", WootzJs.Mvc.Mvc.Views.Css.CssCursor().NResize);
        $t.NeResize = WootzJs.Mvc.Mvc.Views.Css.CssCursor().NResize + 1;
        $t.NeResize$ = $p.$ctor.$new("NeResize", WootzJs.Mvc.Mvc.Views.Css.CssCursor().NeResize);
        $t.NeswResize = WootzJs.Mvc.Mvc.Views.Css.CssCursor().NeResize + 1;
        $t.NeswResize$ = $p.$ctor.$new("NeswResize", WootzJs.Mvc.Mvc.Views.Css.CssCursor().NeswResize);
        $t.NsResize = WootzJs.Mvc.Mvc.Views.Css.CssCursor().NeswResize + 1;
        $t.NsResize$ = $p.$ctor.$new("NsResize", WootzJs.Mvc.Mvc.Views.Css.CssCursor().NsResize);
        $t.NwResize = WootzJs.Mvc.Mvc.Views.Css.CssCursor().NsResize + 1;
        $t.NwResize$ = $p.$ctor.$new("NwResize", WootzJs.Mvc.Mvc.Views.Css.CssCursor().NwResize);
        $t.NwseResize = WootzJs.Mvc.Mvc.Views.Css.CssCursor().NwResize + 1;
        $t.NwseResize$ = $p.$ctor.$new("NwseResize", WootzJs.Mvc.Mvc.Views.Css.CssCursor().NwseResize);
        $t.NoDrop = WootzJs.Mvc.Mvc.Views.Css.CssCursor().NwseResize + 1;
        $t.NoDrop$ = $p.$ctor.$new("NoDrop", WootzJs.Mvc.Mvc.Views.Css.CssCursor().NoDrop);
        $t.None = WootzJs.Mvc.Mvc.Views.Css.CssCursor().NoDrop + 1;
        $t.None$ = $p.$ctor.$new("None", WootzJs.Mvc.Mvc.Views.Css.CssCursor().None);
        $t.NotAllowed = WootzJs.Mvc.Mvc.Views.Css.CssCursor().None + 1;
        $t.NotAllowed$ = $p.$ctor.$new("NotAllowed", WootzJs.Mvc.Mvc.Views.Css.CssCursor().NotAllowed);
        $t.Pointer = WootzJs.Mvc.Mvc.Views.Css.CssCursor().NotAllowed + 1;
        $t.Pointer$ = $p.$ctor.$new("Pointer", WootzJs.Mvc.Mvc.Views.Css.CssCursor().Pointer);
        $t.Progress = WootzJs.Mvc.Mvc.Views.Css.CssCursor().Pointer + 1;
        $t.Progress$ = $p.$ctor.$new("Progress", WootzJs.Mvc.Mvc.Views.Css.CssCursor().Progress);
        $t.RowResize = WootzJs.Mvc.Mvc.Views.Css.CssCursor().Progress + 1;
        $t.RowResize$ = $p.$ctor.$new("RowResize", WootzJs.Mvc.Mvc.Views.Css.CssCursor().RowResize);
        $t.SResize = WootzJs.Mvc.Mvc.Views.Css.CssCursor().RowResize + 1;
        $t.SResize$ = $p.$ctor.$new("SResize", WootzJs.Mvc.Mvc.Views.Css.CssCursor().SResize);
        $t.SeResize = WootzJs.Mvc.Mvc.Views.Css.CssCursor().SResize + 1;
        $t.SeResize$ = $p.$ctor.$new("SeResize", WootzJs.Mvc.Mvc.Views.Css.CssCursor().SeResize);
        $t.SwResize = WootzJs.Mvc.Mvc.Views.Css.CssCursor().SeResize + 1;
        $t.SwResize$ = $p.$ctor.$new("SwResize", WootzJs.Mvc.Mvc.Views.Css.CssCursor().SwResize);
        $t.Text = WootzJs.Mvc.Mvc.Views.Css.CssCursor().SwResize + 1;
        $t.Text$ = $p.$ctor.$new("Text", WootzJs.Mvc.Mvc.Views.Css.CssCursor().Text);
        $t.Url = WootzJs.Mvc.Mvc.Views.Css.CssCursor().Text + 1;
        $t.Url$ = $p.$ctor.$new("Url", WootzJs.Mvc.Mvc.Views.Css.CssCursor().Url);
        $t.VerticalText = WootzJs.Mvc.Mvc.Views.Css.CssCursor().Url + 1;
        $t.VerticalText$ = $p.$ctor.$new("VerticalText", WootzJs.Mvc.Mvc.Views.Css.CssCursor().VerticalText);
        $t.WResize = WootzJs.Mvc.Mvc.Views.Css.CssCursor().VerticalText + 1;
        $t.WResize$ = $p.$ctor.$new("WResize", WootzJs.Mvc.Mvc.Views.Css.CssCursor().WResize);
        $t.Wait = WootzJs.Mvc.Mvc.Views.Css.CssCursor().WResize + 1;
        $t.Wait$ = $p.$ctor.$new("Wait", WootzJs.Mvc.Mvc.Views.Css.CssCursor().Wait);
        $t.ZoomIn = WootzJs.Mvc.Mvc.Views.Css.CssCursor().Wait + 1;
        $t.ZoomIn$ = $p.$ctor.$new("ZoomIn", WootzJs.Mvc.Mvc.Views.Css.CssCursor().ZoomIn);
        $t.ZoomOut = WootzJs.Mvc.Mvc.Views.Css.CssCursor().ZoomIn + 1;
        $t.ZoomOut$ = $p.$ctor.$new("ZoomOut", WootzJs.Mvc.Mvc.Views.Css.CssCursor().ZoomOut);
        $t.Inherit = WootzJs.Mvc.Mvc.Views.Css.CssCursor().ZoomOut + 1;
        $t.Inherit$ = $p.$ctor.$new("Inherit", WootzJs.Mvc.Mvc.Views.Css.CssCursor().Inherit);
    };
    $p.$ctor = function(name, value) {
        System.Enum.prototype.$ctor.call(this, name, value);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function(name, value) {
        return new $p.$ctor.$type(this, name, value);
    };
}).call(null, WootzJs.Mvc.Mvc.Views.Css.CssCursor, WootzJs.Mvc.Mvc.Views.Css.CssCursor.prototype);
$WootzJs$Mvc$AssemblyTypes.push(WootzJs.Mvc.Mvc.Views.Css.CssCursor);
WootzJs.Mvc.Mvc.Views.Css.CssCursors = $define("WootzJs.Mvc.Mvc.Views.Css.CssCursors", System.Object);
(WootzJs.Mvc.Mvc.Views.Css.CssCursors.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Mvc$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Mvc.Mvc.Views.Css.CssCursors";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("CssCursors", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Mvc.Mvc.Views.Css.CssCursors", WootzJs.Mvc.Mvc.Views.Css.CssCursors, System.Object, $arrayinit([], System.Type), $arrayinit([], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("GetName", WootzJs.Mvc.Mvc.Views.Css.CssCursors.prototype.GetName, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("cursor", WootzJs.Mvc.Mvc.Views.Css.CssCursor, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Parse", WootzJs.Mvc.Mvc.Views.Css.CssCursors.prototype.Parse, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("s", String, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Css.CssCursor, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {};
    $t.GetName = function(cursor) {
        switch (cursor) {
            case WootzJs.Mvc.Mvc.Views.Css.CssCursor().Alias:
                return "alias";
            case WootzJs.Mvc.Mvc.Views.Css.CssCursor().Auto:
                return "auto";
            case WootzJs.Mvc.Mvc.Views.Css.CssCursor().Inherit:
                return "inherit";
            case WootzJs.Mvc.Mvc.Views.Css.CssCursor().AllScroll:
                return "all-scroll";
            case WootzJs.Mvc.Mvc.Views.Css.CssCursor().Cell:
                return "cell";
            case WootzJs.Mvc.Mvc.Views.Css.CssCursor().ColResize:
                return "col-resize";
            case WootzJs.Mvc.Mvc.Views.Css.CssCursor().ContextMenu:
                return "context-menu";
            case WootzJs.Mvc.Mvc.Views.Css.CssCursor().Copy:
                return "copy";
            case WootzJs.Mvc.Mvc.Views.Css.CssCursor().Crosshair:
                return "crosshair";
            case WootzJs.Mvc.Mvc.Views.Css.CssCursor().Default:
                return "default";
            case WootzJs.Mvc.Mvc.Views.Css.CssCursor().EResize:
                return "e-resize";
            case WootzJs.Mvc.Mvc.Views.Css.CssCursor().EWResize:
                return "ew-resize";
            case WootzJs.Mvc.Mvc.Views.Css.CssCursor().Help:
                return "help";
            case WootzJs.Mvc.Mvc.Views.Css.CssCursor().Move:
                return "move";
            case WootzJs.Mvc.Mvc.Views.Css.CssCursor().NResize:
                return "n-resize";
            case WootzJs.Mvc.Mvc.Views.Css.CssCursor().NeResize:
                return "ne-resize";
            case WootzJs.Mvc.Mvc.Views.Css.CssCursor().NeswResize:
                return "nesw-resize";
            case WootzJs.Mvc.Mvc.Views.Css.CssCursor().NoDrop:
                return "no-drop";
            case WootzJs.Mvc.Mvc.Views.Css.CssCursor().None:
                return "none";
            case WootzJs.Mvc.Mvc.Views.Css.CssCursor().NotAllowed:
                return "not-allowed";
            case WootzJs.Mvc.Mvc.Views.Css.CssCursor().NsResize:
                return "ns-resize";
            case WootzJs.Mvc.Mvc.Views.Css.CssCursor().NwResize:
                return "nw-resize";
            case WootzJs.Mvc.Mvc.Views.Css.CssCursor().NwseResize:
                return "nwse-resize";
            case WootzJs.Mvc.Mvc.Views.Css.CssCursor().Pointer:
                return "pointer";
            case WootzJs.Mvc.Mvc.Views.Css.CssCursor().Progress:
                return "progress";
            case WootzJs.Mvc.Mvc.Views.Css.CssCursor().RowResize:
                return "row-resize";
            case WootzJs.Mvc.Mvc.Views.Css.CssCursor().SResize:
                return "s-resize";
            case WootzJs.Mvc.Mvc.Views.Css.CssCursor().SeResize:
                return "se-resize";
            case WootzJs.Mvc.Mvc.Views.Css.CssCursor().SwResize:
                return "sw-resize";
            case WootzJs.Mvc.Mvc.Views.Css.CssCursor().Text:
                return "text";
            case WootzJs.Mvc.Mvc.Views.Css.CssCursor().Url:
                return "URL";
            case WootzJs.Mvc.Mvc.Views.Css.CssCursor().VerticalText:
                return "vertical-text";
            case WootzJs.Mvc.Mvc.Views.Css.CssCursor().WResize:
                return "w-resize";
            case WootzJs.Mvc.Mvc.Views.Css.CssCursor().Wait:
                return "wait";
            case WootzJs.Mvc.Mvc.Views.Css.CssCursor().ZoomIn:
                return "zoom-in";
            default:
                throw System.Exception.prototype.$ctor$1.$new("Unknown enum type: " + $safeToString(cursor)).InternalInit(new Error());
        }
    };
    $t.Parse = function(s) {
        switch (s) {
            case "alias":
                return WootzJs.Mvc.Mvc.Views.Css.CssCursor().Alias;
            case "auto":
                return WootzJs.Mvc.Mvc.Views.Css.CssCursor().Auto;
            case "inherit":
                return WootzJs.Mvc.Mvc.Views.Css.CssCursor().Inherit;
            case "all-scroll":
                return WootzJs.Mvc.Mvc.Views.Css.CssCursor().AllScroll;
            case "cell":
                return WootzJs.Mvc.Mvc.Views.Css.CssCursor().Cell;
            case "col-resize":
                return WootzJs.Mvc.Mvc.Views.Css.CssCursor().ColResize;
            case "context-menu":
                return WootzJs.Mvc.Mvc.Views.Css.CssCursor().ContextMenu;
            case "copy":
                return WootzJs.Mvc.Mvc.Views.Css.CssCursor().Copy;
            case "crosshair":
                return WootzJs.Mvc.Mvc.Views.Css.CssCursor().Crosshair;
            case "default":
                return WootzJs.Mvc.Mvc.Views.Css.CssCursor().Default;
            case "e-resize":
                return WootzJs.Mvc.Mvc.Views.Css.CssCursor().EResize;
            case "ew-resize":
                return WootzJs.Mvc.Mvc.Views.Css.CssCursor().EWResize;
            case "help":
                return WootzJs.Mvc.Mvc.Views.Css.CssCursor().Help;
            case "move":
                return WootzJs.Mvc.Mvc.Views.Css.CssCursor().Move;
            case "n-resize":
                return WootzJs.Mvc.Mvc.Views.Css.CssCursor().NResize;
            case "ne-resize":
                return WootzJs.Mvc.Mvc.Views.Css.CssCursor().NeResize;
            case "nesw-resize":
                return WootzJs.Mvc.Mvc.Views.Css.CssCursor().NeswResize;
            case "no-drop":
                return WootzJs.Mvc.Mvc.Views.Css.CssCursor().NoDrop;
            case "none":
                return WootzJs.Mvc.Mvc.Views.Css.CssCursor().None;
            case "not-allowed":
                return WootzJs.Mvc.Mvc.Views.Css.CssCursor().NotAllowed;
            case "ns-resize":
                return WootzJs.Mvc.Mvc.Views.Css.CssCursor().NsResize;
            case "nw-resize":
                return WootzJs.Mvc.Mvc.Views.Css.CssCursor().NwResize;
            case "nwse-resize":
                return WootzJs.Mvc.Mvc.Views.Css.CssCursor().NwseResize;
            case "pointer":
                return WootzJs.Mvc.Mvc.Views.Css.CssCursor().Pointer;
            case "progress":
                return WootzJs.Mvc.Mvc.Views.Css.CssCursor().Progress;
            case "row-resize":
                return WootzJs.Mvc.Mvc.Views.Css.CssCursor().RowResize;
            case "s-resize":
                return WootzJs.Mvc.Mvc.Views.Css.CssCursor().SResize;
            case "se-resize":
                return WootzJs.Mvc.Mvc.Views.Css.CssCursor().SeResize;
            case "sw-resize":
                return WootzJs.Mvc.Mvc.Views.Css.CssCursor().SwResize;
            case "text":
                return WootzJs.Mvc.Mvc.Views.Css.CssCursor().Text;
            case "URL":
                return WootzJs.Mvc.Mvc.Views.Css.CssCursor().Url;
            case "vertical-text":
                return WootzJs.Mvc.Mvc.Views.Css.CssCursor().VerticalText;
            case "w-resize":
                return WootzJs.Mvc.Mvc.Views.Css.CssCursor().WResize;
            case "wait":
                return WootzJs.Mvc.Mvc.Views.Css.CssCursor().Wait;
            case "zoom-in":
                return WootzJs.Mvc.Mvc.Views.Css.CssCursor().ZoomIn;
            default:
                throw System.Exception.prototype.$ctor$1.$new("Unknown enum type: " + s).InternalInit(new Error());
        }
    };
}).call(null, WootzJs.Mvc.Mvc.Views.Css.CssCursors, WootzJs.Mvc.Mvc.Views.Css.CssCursors.prototype);
$WootzJs$Mvc$AssemblyTypes.push(WootzJs.Mvc.Mvc.Views.Css.CssCursors);
WootzJs.Mvc.Mvc.Views.Css.CssFont = $define("WootzJs.Mvc.Mvc.Views.Css.CssFont", WootzJs.Mvc.Mvc.Views.Css.CssDeclaration);
(WootzJs.Mvc.Mvc.Views.Css.CssFont.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Mvc$GetAssembly;
    $p.$type = $t;
    $t.$baseType = WootzJs.Mvc.Mvc.Views.Css.CssDeclaration;
    $p.$typeName = "WootzJs.Mvc.Mvc.Views.Css.CssFont";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("CssFont", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Mvc.Mvc.Views.Css.CssFont", WootzJs.Mvc.Mvc.Views.Css.CssFont, WootzJs.Mvc.Mvc.Views.Css.CssDeclaration, $arrayinit([], System.Type), $arrayinit([], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("get_Families", WootzJs.Mvc.Mvc.Views.Css.CssFont.prototype.get_Families, $arrayinit([], System.Reflection.ParameterInfo), $array(String), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Families", WootzJs.Mvc.Mvc.Views.Css.CssFont.prototype.set_Families, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", $array(String), 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_Family", WootzJs.Mvc.Mvc.Views.Css.CssFont.prototype.get_Family, $arrayinit([], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Family", WootzJs.Mvc.Mvc.Views.Css.CssFont.prototype.set_Family, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", String, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_Size", WootzJs.Mvc.Mvc.Views.Css.CssFont.prototype.get_Size, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Size", WootzJs.Mvc.Mvc.Views.Css.CssFont.prototype.set_Size, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_Style", WootzJs.Mvc.Mvc.Views.Css.CssFont.prototype.get_Style, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Css.CssFontStyle, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Style", WootzJs.Mvc.Mvc.Views.Css.CssFont.prototype.set_Style, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Css.CssFontStyle, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_Weight", WootzJs.Mvc.Mvc.Views.Css.CssFont.prototype.get_Weight, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Css.CssFontWeight, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Weight", WootzJs.Mvc.Mvc.Views.Css.CssFont.prototype.set_Weight, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Css.CssFontWeight, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Mvc.Mvc.Views.Css.CssFont.prototype.$ctor, $arrayinit([], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.PropertyInfo.prototype.$ctor.$new("Families", $array(String), System.Reflection.MethodInfo.prototype.$ctor.$new("get_Families", WootzJs.Mvc.Mvc.Views.Css.CssFont.prototype.get_Families, $arrayinit([], System.Reflection.ParameterInfo), $array(String), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Families", WootzJs.Mvc.Mvc.Views.Css.CssFont.prototype.set_Families, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", $array(String), 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("Family", String, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Family", WootzJs.Mvc.Mvc.Views.Css.CssFont.prototype.get_Family, $arrayinit([], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Family", WootzJs.Mvc.Mvc.Views.Css.CssFont.prototype.set_Family, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", String, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("Size", WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Size", WootzJs.Mvc.Mvc.Views.Css.CssFont.prototype.get_Size, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Size", WootzJs.Mvc.Mvc.Views.Css.CssFont.prototype.set_Size, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("Style", WootzJs.Mvc.Mvc.Views.Css.CssFontStyle, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Style", WootzJs.Mvc.Mvc.Views.Css.CssFont.prototype.get_Style, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Css.CssFontStyle, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Style", WootzJs.Mvc.Mvc.Views.Css.CssFont.prototype.set_Style, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Css.CssFontStyle, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("Weight", WootzJs.Mvc.Mvc.Views.Css.CssFontWeight, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Weight", WootzJs.Mvc.Mvc.Views.Css.CssFont.prototype.get_Weight, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Css.CssFontWeight, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Weight", WootzJs.Mvc.Mvc.Views.Css.CssFont.prototype.set_Weight, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Css.CssFontWeight, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute))], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {};
    $p.$ctor = function() {
        WootzJs.Mvc.Mvc.Views.Css.CssDeclaration.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.get_Families = function() {
        var family = this.Get("font-family");
        if (family == null)
            return null;
        else
            return String.prototype.Split.call(family, [" "]);
    };
    $p.set_Families = function(value) {
        this.Set("font-family", String.Join(",", System.Linq.Enumerable.ToArray(String, System.Linq.Enumerable.Select(
            String, 
            String, 
            value, 
            $delegate(this, System.Func$2$(String, String), function(x) {
                return x.Contains(" ") ? "\"" + x + "\"" : x;
            })
        ))));
    };
    $p.get_Family = function() {
        return this.Get("font-family");
    };
    $p.set_Family = function(value) {
        this.Set("font-family", value.Contains(" ") ? "\"" + value + "\"" : value);
    };
    $p.get_Size = function() {
        return WootzJs.Mvc.Mvc.Views.Css.CssNumericValue.Parse$1(this.Get("font-size"));
    };
    $p.set_Size = function(value) {
        this.Set("font-size", value);
    };
    $p.get_Style = function() {
        return WootzJs.Mvc.Mvc.Views.Css.CssFontStyles.Parse(this.Get("font-style"));
    };
    $p.set_Style = function(value) {
        this.Set("font-style", WootzJs.Mvc.Mvc.Views.Css.CssFontStyles.GetName(value));
    };
    $p.get_Weight = function() {
        return WootzJs.Mvc.Mvc.Views.Css.CssFontWeight.Parse(this.Get("font-weight"));
    };
    $p.set_Weight = function(value) {
        this.Set("font-weight", value);
    };
}).call(null, WootzJs.Mvc.Mvc.Views.Css.CssFont, WootzJs.Mvc.Mvc.Views.Css.CssFont.prototype);
$WootzJs$Mvc$AssemblyTypes.push(WootzJs.Mvc.Mvc.Views.Css.CssFont);
WootzJs.Mvc.Mvc.Views.Css.CssFontStyle = $define("WootzJs.Mvc.Mvc.Views.Css.CssFontStyle", System.Enum);
(WootzJs.Mvc.Mvc.Views.Css.CssFontStyle.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Mvc$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Enum;
    $p.$typeName = "WootzJs.Mvc.Mvc.Views.Css.CssFontStyle";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("CssFontStyle", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Mvc.Mvc.Views.Css.CssFontStyle", WootzJs.Mvc.Mvc.Views.Css.CssFontStyle, System.Enum, $arrayinit([], System.Type), $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("Normal", WootzJs.Mvc.Mvc.Views.Css.CssFontStyle, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().Literal, 0, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("Italic", WootzJs.Mvc.Mvc.Views.Css.CssFontStyle, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().Literal, 1, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("Oblique", WootzJs.Mvc.Mvc.Views.Css.CssFontStyle, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().Literal, 2, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("Inherit", WootzJs.Mvc.Mvc.Views.Css.CssFontStyle, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().Literal, 3, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Mvc.Mvc.Views.Css.CssFontStyle.prototype.$ctor, $arrayinit([], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), true);return this.$type;};
    $t.$StaticInitializer = function() {
        $t.Normal = 0;
        $t.Normal$ = $p.$ctor.$new("Normal", WootzJs.Mvc.Mvc.Views.Css.CssFontStyle().Normal);
        $t.Italic = WootzJs.Mvc.Mvc.Views.Css.CssFontStyle().Normal + 1;
        $t.Italic$ = $p.$ctor.$new("Italic", WootzJs.Mvc.Mvc.Views.Css.CssFontStyle().Italic);
        $t.Oblique = WootzJs.Mvc.Mvc.Views.Css.CssFontStyle().Italic + 1;
        $t.Oblique$ = $p.$ctor.$new("Oblique", WootzJs.Mvc.Mvc.Views.Css.CssFontStyle().Oblique);
        $t.Inherit = WootzJs.Mvc.Mvc.Views.Css.CssFontStyle().Oblique + 1;
        $t.Inherit$ = $p.$ctor.$new("Inherit", WootzJs.Mvc.Mvc.Views.Css.CssFontStyle().Inherit);
    };
    $p.$ctor = function(name, value) {
        System.Enum.prototype.$ctor.call(this, name, value);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function(name, value) {
        return new $p.$ctor.$type(this, name, value);
    };
}).call(null, WootzJs.Mvc.Mvc.Views.Css.CssFontStyle, WootzJs.Mvc.Mvc.Views.Css.CssFontStyle.prototype);
$WootzJs$Mvc$AssemblyTypes.push(WootzJs.Mvc.Mvc.Views.Css.CssFontStyle);
WootzJs.Mvc.Mvc.Views.Css.CssFontStyles = $define("WootzJs.Mvc.Mvc.Views.Css.CssFontStyles", System.Object);
(WootzJs.Mvc.Mvc.Views.Css.CssFontStyles.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Mvc$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Mvc.Mvc.Views.Css.CssFontStyles";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("CssFontStyles", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Mvc.Mvc.Views.Css.CssFontStyles", WootzJs.Mvc.Mvc.Views.Css.CssFontStyles, System.Object, $arrayinit([], System.Type), $arrayinit([], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("GetName", WootzJs.Mvc.Mvc.Views.Css.CssFontStyles.prototype.GetName, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Css.CssFontStyle, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Parse", WootzJs.Mvc.Mvc.Views.Css.CssFontStyles.prototype.Parse, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("s", String, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Css.CssFontStyle, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {};
    $t.GetName = function(value) {
        switch (value) {
            case WootzJs.Mvc.Mvc.Views.Css.CssFontStyle().Inherit:
                return "inherit";
            case WootzJs.Mvc.Mvc.Views.Css.CssFontStyle().Italic:
                return "italic";
            case WootzJs.Mvc.Mvc.Views.Css.CssFontStyle().Normal:
                return "normal";
            case WootzJs.Mvc.Mvc.Views.Css.CssFontStyle().Oblique:
                return "oblique";
            default:
                throw System.Exception.prototype.$ctor$1.$new("Unable to get name for: " + $safeToString(value)).InternalInit(new Error());
        }
    };
    $t.Parse = function(s) {
        switch (s) {
            case null:
            case "normal":
                return WootzJs.Mvc.Mvc.Views.Css.CssFontStyle().Normal;
            case "italic":
                return WootzJs.Mvc.Mvc.Views.Css.CssFontStyle().Italic;
            case "oblique":
                return WootzJs.Mvc.Mvc.Views.Css.CssFontStyle().Oblique;
            case "inherit":
                return WootzJs.Mvc.Mvc.Views.Css.CssFontStyle().Inherit;
            default:
                throw System.Exception.prototype.$ctor$1.$new("Unable to parse: " + s).InternalInit(new Error());
        }
    };
}).call(null, WootzJs.Mvc.Mvc.Views.Css.CssFontStyles, WootzJs.Mvc.Mvc.Views.Css.CssFontStyles.prototype);
$WootzJs$Mvc$AssemblyTypes.push(WootzJs.Mvc.Mvc.Views.Css.CssFontStyles);
WootzJs.Mvc.Mvc.Views.Css.CssFontWeight = $define("WootzJs.Mvc.Mvc.Views.Css.CssFontWeight", System.Object);
(WootzJs.Mvc.Mvc.Views.Css.CssFontWeight.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Mvc$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Mvc.Mvc.Views.Css.CssFontWeight";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("CssFontWeight", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Mvc.Mvc.Views.Css.CssFontWeight", WootzJs.Mvc.Mvc.Views.Css.CssFontWeight, System.Object, $arrayinit([], System.Type), $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("value", String, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("op_Implicit$1", WootzJs.Mvc.Mvc.Views.Css.CssFontWeight.prototype.op_Implicit$1, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Int32, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Css.CssFontWeight, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("op_Implicit", WootzJs.Mvc.Mvc.Views.Css.CssFontWeight.prototype.op_Implicit, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Css.CssFontWeightType, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Css.CssFontWeight, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("ToString", WootzJs.Mvc.Mvc.Views.Css.CssFontWeight.prototype.ToString, $arrayinit([], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Parse", WootzJs.Mvc.Mvc.Views.Css.CssFontWeight.prototype.Parse, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("s", String, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Css.CssFontWeight, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor$1", WootzJs.Mvc.Mvc.Views.Css.CssFontWeight.prototype.$ctor$1, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Int32, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Mvc.Mvc.Views.Css.CssFontWeight.prototype.$ctor, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("type", WootzJs.Mvc.Mvc.Views.Css.CssFontWeightType, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {};
    $p.value = null;
    $p.$ctor$1 = function(value) {
        System.Object.prototype.$ctor.call(this);
        this.value = value.ToString();
    };
    $p.$ctor$1.$type = $t;
    $p.$ctor$1.$new = function(value) {
        return new $p.$ctor$1.$type(this, value);
    };
    $p.$ctor = function(type) {
        System.Object.prototype.$ctor.call(this);
        this.value = WootzJs.Mvc.Mvc.Views.Css.CssFontWeightTypes.GetName(type);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function(type) {
        return new $p.$ctor.$type(this, type);
    };
    $t.op_Implicit$1 = function(value) {
        return WootzJs.Mvc.Mvc.Views.Css.CssFontWeight.prototype.$ctor$1.$new(value);
    };
    $t.op_Implicit = function(value) {
        return WootzJs.Mvc.Mvc.Views.Css.CssFontWeight.prototype.$ctor.$new(value);
    };
    $p.ToString = function() {
        return this.value;
    };
    $t.Parse = function(s) {
        var value;
        if ((function() {
            var $anon$1 = {
                value: null
            };
            var $result$ = System.Int32.TryParse(s, $anon$1);
            value = $anon$1.value;
            return $result$;
        }).call(this))
            return WootzJs.Mvc.Mvc.Views.Css.CssFontWeight.prototype.$ctor$1.$new(value);
        else
            return WootzJs.Mvc.Mvc.Views.Css.CssFontWeight.prototype.$ctor.$new(WootzJs.Mvc.Mvc.Views.Css.CssFontWeightTypes.Parse(s));
    };
}).call(null, WootzJs.Mvc.Mvc.Views.Css.CssFontWeight, WootzJs.Mvc.Mvc.Views.Css.CssFontWeight.prototype);
$WootzJs$Mvc$AssemblyTypes.push(WootzJs.Mvc.Mvc.Views.Css.CssFontWeight);
WootzJs.Mvc.Mvc.Views.Css.CssFontWeightType = $define("WootzJs.Mvc.Mvc.Views.Css.CssFontWeightType", System.Enum);
(WootzJs.Mvc.Mvc.Views.Css.CssFontWeightType.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Mvc$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Enum;
    $p.$typeName = "WootzJs.Mvc.Mvc.Views.Css.CssFontWeightType";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("CssFontWeightType", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Mvc.Mvc.Views.Css.CssFontWeightType", WootzJs.Mvc.Mvc.Views.Css.CssFontWeightType, System.Enum, $arrayinit([], System.Type), $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("Normal", WootzJs.Mvc.Mvc.Views.Css.CssFontWeightType, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().Literal, 0, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("Bold", WootzJs.Mvc.Mvc.Views.Css.CssFontWeightType, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().Literal, 1, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("Bolder", WootzJs.Mvc.Mvc.Views.Css.CssFontWeightType, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().Literal, 2, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("Lighter", WootzJs.Mvc.Mvc.Views.Css.CssFontWeightType, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().Literal, 3, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("Inherit", WootzJs.Mvc.Mvc.Views.Css.CssFontWeightType, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().Literal, 4, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Mvc.Mvc.Views.Css.CssFontWeightType.prototype.$ctor, $arrayinit([], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), true);return this.$type;};
    $t.$StaticInitializer = function() {
        $t.Normal = 0;
        $t.Normal$ = $p.$ctor.$new("Normal", WootzJs.Mvc.Mvc.Views.Css.CssFontWeightType().Normal);
        $t.Bold = WootzJs.Mvc.Mvc.Views.Css.CssFontWeightType().Normal + 1;
        $t.Bold$ = $p.$ctor.$new("Bold", WootzJs.Mvc.Mvc.Views.Css.CssFontWeightType().Bold);
        $t.Bolder = WootzJs.Mvc.Mvc.Views.Css.CssFontWeightType().Bold + 1;
        $t.Bolder$ = $p.$ctor.$new("Bolder", WootzJs.Mvc.Mvc.Views.Css.CssFontWeightType().Bolder);
        $t.Lighter = WootzJs.Mvc.Mvc.Views.Css.CssFontWeightType().Bolder + 1;
        $t.Lighter$ = $p.$ctor.$new("Lighter", WootzJs.Mvc.Mvc.Views.Css.CssFontWeightType().Lighter);
        $t.Inherit = WootzJs.Mvc.Mvc.Views.Css.CssFontWeightType().Lighter + 1;
        $t.Inherit$ = $p.$ctor.$new("Inherit", WootzJs.Mvc.Mvc.Views.Css.CssFontWeightType().Inherit);
    };
    $p.$ctor = function(name, value) {
        System.Enum.prototype.$ctor.call(this, name, value);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function(name, value) {
        return new $p.$ctor.$type(this, name, value);
    };
}).call(null, WootzJs.Mvc.Mvc.Views.Css.CssFontWeightType, WootzJs.Mvc.Mvc.Views.Css.CssFontWeightType.prototype);
$WootzJs$Mvc$AssemblyTypes.push(WootzJs.Mvc.Mvc.Views.Css.CssFontWeightType);
WootzJs.Mvc.Mvc.Views.Css.CssFontWeightTypes = $define("WootzJs.Mvc.Mvc.Views.Css.CssFontWeightTypes", System.Object);
(WootzJs.Mvc.Mvc.Views.Css.CssFontWeightTypes.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Mvc$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Mvc.Mvc.Views.Css.CssFontWeightTypes";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("CssFontWeightTypes", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Mvc.Mvc.Views.Css.CssFontWeightTypes", WootzJs.Mvc.Mvc.Views.Css.CssFontWeightTypes, System.Object, $arrayinit([], System.Type), $arrayinit([], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("GetName", WootzJs.Mvc.Mvc.Views.Css.CssFontWeightTypes.prototype.GetName, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Css.CssFontWeightType, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Parse", WootzJs.Mvc.Mvc.Views.Css.CssFontWeightTypes.prototype.Parse, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("s", String, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Css.CssFontWeightType, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {};
    $t.GetName = function(value) {
        switch (value) {
            case WootzJs.Mvc.Mvc.Views.Css.CssFontWeightType().Bold:
                return "bold";
            case WootzJs.Mvc.Mvc.Views.Css.CssFontWeightType().Bolder:
                return "bolder";
            case WootzJs.Mvc.Mvc.Views.Css.CssFontWeightType().Inherit:
                return "inherit";
            case WootzJs.Mvc.Mvc.Views.Css.CssFontWeightType().Lighter:
                return "lighter";
            case WootzJs.Mvc.Mvc.Views.Css.CssFontWeightType().Normal:
                return "normal";
            default:
                throw System.Exception.prototype.$ctor$1.$new("Unknown value: " + $safeToString(value)).InternalInit(new Error());
        }
    };
    $t.Parse = function(s) {
        switch (s) {
            case null:
            case "normal":
                return WootzJs.Mvc.Mvc.Views.Css.CssFontWeightType().Normal;
            case "bold":
                return WootzJs.Mvc.Mvc.Views.Css.CssFontWeightType().Normal;
            case "bolder":
                return WootzJs.Mvc.Mvc.Views.Css.CssFontWeightType().Normal;
            case "lighter":
                return WootzJs.Mvc.Mvc.Views.Css.CssFontWeightType().Normal;
            case "inherit":
                return WootzJs.Mvc.Mvc.Views.Css.CssFontWeightType().Normal;
            default:
                throw System.Exception.prototype.$ctor$1.$new("Unexpected value: " + s).InternalInit(new Error());
        }
    };
}).call(null, WootzJs.Mvc.Mvc.Views.Css.CssFontWeightTypes, WootzJs.Mvc.Mvc.Views.Css.CssFontWeightTypes.prototype);
$WootzJs$Mvc$AssemblyTypes.push(WootzJs.Mvc.Mvc.Views.Css.CssFontWeightTypes);
WootzJs.Mvc.Mvc.Views.Css.CssInherit = $define("WootzJs.Mvc.Mvc.Views.Css.CssInherit", WootzJs.Mvc.Mvc.Views.Css.CssValue);
(WootzJs.Mvc.Mvc.Views.Css.CssInherit.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Mvc$GetAssembly;
    $p.$type = $t;
    $t.$baseType = WootzJs.Mvc.Mvc.Views.Css.CssValue;
    $p.$typeName = "WootzJs.Mvc.Mvc.Views.Css.CssInherit";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("CssInherit", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Mvc.Mvc.Views.Css.CssInherit", WootzJs.Mvc.Mvc.Views.Css.CssInherit, WootzJs.Mvc.Mvc.Views.Css.CssValue, $arrayinit([], System.Type), $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("instance", WootzJs.Mvc.Mvc.Views.Css.CssInherit, System.Reflection.FieldAttributes().Private | System.Reflection.FieldAttributes().Static, null, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("$cctor", WootzJs.Mvc.Mvc.Views.Css.CssInherit.prototype.$cctor, $arrayinit([], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Private | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_Instance", WootzJs.Mvc.Mvc.Views.Css.CssInherit.prototype.get_Instance, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Css.CssInherit, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Mvc.Mvc.Views.Css.CssInherit.prototype.$ctor, $arrayinit([], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.PropertyInfo.prototype.$ctor.$new("Instance", WootzJs.Mvc.Mvc.Views.Css.CssInherit, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Instance", WootzJs.Mvc.Mvc.Views.Css.CssInherit.prototype.get_Instance, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Css.CssInherit, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute)), null, $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute))], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {
        WootzJs.Mvc.Mvc.Views.Css.CssInherit.instance = WootzJs.Mvc.Mvc.Views.Css.CssInherit.prototype.$ctor.$new();
    };
    $p.$ctor = function() {
        WootzJs.Mvc.Mvc.Views.Css.CssValue.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.instance = null;
    $t.get_Instance = function() {
        return WootzJs.Mvc.Mvc.Views.Css.CssInherit().instance;
    };
}).call(null, WootzJs.Mvc.Mvc.Views.Css.CssInherit, WootzJs.Mvc.Mvc.Views.Css.CssInherit.prototype);
$WootzJs$Mvc$AssemblyTypes.push(WootzJs.Mvc.Mvc.Views.Css.CssInherit);
WootzJs.Mvc.Mvc.Views.Css.CssInset = $define("WootzJs.Mvc.Mvc.Views.Css.CssInset", WootzJs.Mvc.Mvc.Views.Css.CssValue);
(WootzJs.Mvc.Mvc.Views.Css.CssInset.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Mvc$GetAssembly;
    $p.$type = $t;
    $t.$baseType = WootzJs.Mvc.Mvc.Views.Css.CssValue;
    $p.$typeName = "WootzJs.Mvc.Mvc.Views.Css.CssInset";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("CssInset", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Mvc.Mvc.Views.Css.CssInset", WootzJs.Mvc.Mvc.Views.Css.CssInset, WootzJs.Mvc.Mvc.Views.Css.CssValue, $arrayinit([], System.Type), $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("Instance", WootzJs.Mvc.Mvc.Views.Css.CssInset, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().InitOnly, null, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("$cctor", WootzJs.Mvc.Mvc.Views.Css.CssInset.prototype.$cctor, $arrayinit([], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Private | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("ToString", WootzJs.Mvc.Mvc.Views.Css.CssInset.prototype.ToString, $arrayinit([], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("op_Implicit", WootzJs.Mvc.Mvc.Views.Css.CssInset.prototype.op_Implicit, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Boolean, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Css.CssInset, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Mvc.Mvc.Views.Css.CssInset.prototype.$ctor, $arrayinit([], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {
        WootzJs.Mvc.Mvc.Views.Css.CssInset.Instance = WootzJs.Mvc.Mvc.Views.Css.CssInset.prototype.$ctor.$new();
    };
    $p.$ctor = function() {
        WootzJs.Mvc.Mvc.Views.Css.CssValue.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.Instance = null;
    $p.ToString = function() {
        return "inset";
    };
    $t.op_Implicit = function(value) {
        return WootzJs.Mvc.Mvc.Views.Css.CssInset.prototype.$ctor.$new();
    };
}).call(null, WootzJs.Mvc.Mvc.Views.Css.CssInset, WootzJs.Mvc.Mvc.Views.Css.CssInset.prototype);
$WootzJs$Mvc$AssemblyTypes.push(WootzJs.Mvc.Mvc.Views.Css.CssInset);
WootzJs.Mvc.Mvc.Views.Css.CssMargin = $define("WootzJs.Mvc.Mvc.Views.Css.CssMargin", WootzJs.Mvc.Mvc.Views.Css.CssDeclaration);
(WootzJs.Mvc.Mvc.Views.Css.CssMargin.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Mvc$GetAssembly;
    $p.$type = $t;
    $t.$baseType = WootzJs.Mvc.Mvc.Views.Css.CssDeclaration;
    $p.$typeName = "WootzJs.Mvc.Mvc.Views.Css.CssMargin";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("CssMargin", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Mvc.Mvc.Views.Css.CssMargin", WootzJs.Mvc.Mvc.Views.Css.CssMargin, WootzJs.Mvc.Mvc.Views.Css.CssDeclaration, $arrayinit([], System.Type), $arrayinit([], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("get_Size", WootzJs.Mvc.Mvc.Views.Css.CssMargin.prototype.get_Size, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Size", WootzJs.Mvc.Mvc.Views.Css.CssMargin.prototype.set_Size, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_Left", WootzJs.Mvc.Mvc.Views.Css.CssMargin.prototype.get_Left, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Left", WootzJs.Mvc.Mvc.Views.Css.CssMargin.prototype.set_Left, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_Top", WootzJs.Mvc.Mvc.Views.Css.CssMargin.prototype.get_Top, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Top", WootzJs.Mvc.Mvc.Views.Css.CssMargin.prototype.set_Top, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_Right", WootzJs.Mvc.Mvc.Views.Css.CssMargin.prototype.get_Right, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Right", WootzJs.Mvc.Mvc.Views.Css.CssMargin.prototype.set_Right, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_Bottom", WootzJs.Mvc.Mvc.Views.Css.CssMargin.prototype.get_Bottom, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Bottom", WootzJs.Mvc.Mvc.Views.Css.CssMargin.prototype.set_Bottom, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Mvc.Mvc.Views.Css.CssMargin.prototype.$ctor, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("size", WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.PropertyInfo.prototype.$ctor.$new("Size", WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Size", WootzJs.Mvc.Mvc.Views.Css.CssMargin.prototype.get_Size, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Size", WootzJs.Mvc.Mvc.Views.Css.CssMargin.prototype.set_Size, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("Left", WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Left", WootzJs.Mvc.Mvc.Views.Css.CssMargin.prototype.get_Left, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Left", WootzJs.Mvc.Mvc.Views.Css.CssMargin.prototype.set_Left, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("Top", WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Top", WootzJs.Mvc.Mvc.Views.Css.CssMargin.prototype.get_Top, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Top", WootzJs.Mvc.Mvc.Views.Css.CssMargin.prototype.set_Top, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("Right", WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Right", WootzJs.Mvc.Mvc.Views.Css.CssMargin.prototype.get_Right, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Right", WootzJs.Mvc.Mvc.Views.Css.CssMargin.prototype.set_Right, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("Bottom", WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Bottom", WootzJs.Mvc.Mvc.Views.Css.CssMargin.prototype.get_Bottom, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Bottom", WootzJs.Mvc.Mvc.Views.Css.CssMargin.prototype.set_Bottom, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute))], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {};
    $p.$ctor = function(size) {
        WootzJs.Mvc.Mvc.Views.Css.CssDeclaration.prototype.$ctor.call(this);
        this.set_Size(size);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function(size) {
        return new $p.$ctor.$type(this, size);
    };
    $p.get_Size = function() {
        return WootzJs.Mvc.Mvc.Views.Css.CssNumericValue.Parse$1(this.Get("margin"));
    };
    $p.set_Size = function(value) {
        this.Set("margin", value);
    };
    $p.get_Left = function() {
        return WootzJs.Mvc.Mvc.Views.Css.CssNumericValue.Parse$1(this.Get("margin-left"));
    };
    $p.set_Left = function(value) {
        this.Set("margin-left", value);
    };
    $p.get_Top = function() {
        return WootzJs.Mvc.Mvc.Views.Css.CssNumericValue.Parse$1(this.Get("margin-top"));
    };
    $p.set_Top = function(value) {
        this.Set("margin-top", value);
    };
    $p.get_Right = function() {
        return WootzJs.Mvc.Mvc.Views.Css.CssNumericValue.Parse$1(this.Get("margin-right"));
    };
    $p.set_Right = function(value) {
        this.Set("margin-right", value);
    };
    $p.get_Bottom = function() {
        return WootzJs.Mvc.Mvc.Views.Css.CssNumericValue.Parse$1(this.Get("margin-bottom"));
    };
    $p.set_Bottom = function(value) {
        this.Set("margin-bottom", value);
    };
}).call(null, WootzJs.Mvc.Mvc.Views.Css.CssMargin, WootzJs.Mvc.Mvc.Views.Css.CssMargin.prototype);
$WootzJs$Mvc$AssemblyTypes.push(WootzJs.Mvc.Mvc.Views.Css.CssMargin);
WootzJs.Mvc.Mvc.Views.Css.CssNameAttribute = $define("WootzJs.Mvc.Mvc.Views.Css.CssNameAttribute", System.Attribute);
(WootzJs.Mvc.Mvc.Views.Css.CssNameAttribute.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Mvc$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Attribute;
    $p.$typeName = "WootzJs.Mvc.Mvc.Views.Css.CssNameAttribute";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("CssNameAttribute", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Mvc.Mvc.Views.Css.CssNameAttribute", WootzJs.Mvc.Mvc.Views.Css.CssNameAttribute, System.Attribute, $arrayinit([], System.Type), $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("name", String, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("get_Name", WootzJs.Mvc.Mvc.Views.Css.CssNameAttribute.prototype.get_Name, $arrayinit([], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Mvc.Mvc.Views.Css.CssNameAttribute.prototype.$ctor, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("name", String, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.PropertyInfo.prototype.$ctor.$new("Name", String, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Name", WootzJs.Mvc.Mvc.Views.Css.CssNameAttribute.prototype.get_Name, $arrayinit([], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), null, $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute))], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {};
    $p.name = null;
    $p.$ctor = function(name) {
        System.Attribute.prototype.$ctor.call(this);
        this.name = name;
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function(name) {
        return new $p.$ctor.$type(this, name);
    };
    $p.get_Name = function() {
        return this.name;
    };
}).call(null, WootzJs.Mvc.Mvc.Views.Css.CssNameAttribute, WootzJs.Mvc.Mvc.Views.Css.CssNameAttribute.prototype);
$WootzJs$Mvc$AssemblyTypes.push(WootzJs.Mvc.Mvc.Views.Css.CssNameAttribute);
WootzJs.Mvc.Mvc.Views.Css.CssNumericValue = $define("WootzJs.Mvc.Mvc.Views.Css.CssNumericValue", WootzJs.Mvc.Mvc.Views.Css.CssValue);
(WootzJs.Mvc.Mvc.Views.Css.CssNumericValue.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Mvc$GetAssembly;
    $p.$type = $t;
    $t.$baseType = WootzJs.Mvc.Mvc.Views.Css.CssValue;
    $p.$typeName = "WootzJs.Mvc.Mvc.Views.Css.CssNumericValue";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("CssNumericValue", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Mvc.Mvc.Views.Css.CssNumericValue", WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, WootzJs.Mvc.Mvc.Views.Css.CssValue, $arrayinit([], System.Type), $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("OneHundredPercent", WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().InitOnly, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("$Value$k__BackingField", String, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("$Unit$k__BackingField", WootzJs.Mvc.Mvc.Views.Css.CssUnit, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("$cctor", WootzJs.Mvc.Mvc.Views.Css.CssNumericValue.prototype.$cctor, $arrayinit([], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Private | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_Value", WootzJs.Mvc.Mvc.Views.Css.CssNumericValue.prototype.get_Value, $arrayinit([], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Value", WootzJs.Mvc.Mvc.Views.Css.CssNumericValue.prototype.set_Value, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", String, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_Unit", WootzJs.Mvc.Mvc.Views.Css.CssNumericValue.prototype.get_Unit, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Css.CssUnit, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Unit", WootzJs.Mvc.Mvc.Views.Css.CssNumericValue.prototype.set_Unit, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Css.CssUnit, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("ToString", WootzJs.Mvc.Mvc.Views.Css.CssNumericValue.prototype.ToString, $arrayinit([], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("op_Implicit", WootzJs.Mvc.Mvc.Views.Css.CssNumericValue.prototype.op_Implicit, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Int32, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Parse$1", WootzJs.Mvc.Mvc.Views.Css.CssNumericValue.prototype.Parse$1, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", String, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor$2", WootzJs.Mvc.Mvc.Views.Css.CssNumericValue.prototype.$ctor$2, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", String, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("unit", WootzJs.Mvc.Mvc.Views.Css.CssUnit, 1, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Mvc.Mvc.Views.Css.CssNumericValue.prototype.$ctor, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("unit", WootzJs.Mvc.Mvc.Views.Css.CssUnit, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor$1", WootzJs.Mvc.Mvc.Views.Css.CssNumericValue.prototype.$ctor$1, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Int32, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("unit", WootzJs.Mvc.Mvc.Views.Css.CssUnit, 1, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.PropertyInfo.prototype.$ctor.$new("Value", String, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Value", WootzJs.Mvc.Mvc.Views.Css.CssNumericValue.prototype.get_Value, $arrayinit([], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Value", WootzJs.Mvc.Mvc.Views.Css.CssNumericValue.prototype.set_Value, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", String, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("Unit", WootzJs.Mvc.Mvc.Views.Css.CssUnit, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Unit", WootzJs.Mvc.Mvc.Views.Css.CssNumericValue.prototype.get_Unit, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Css.CssUnit, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Unit", WootzJs.Mvc.Mvc.Views.Css.CssNumericValue.prototype.set_Unit, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Css.CssUnit, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute))], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {
        WootzJs.Mvc.Mvc.Views.Css.CssNumericValue.OneHundredPercent = WootzJs.Mvc.Mvc.Views.Css.CssNumericValue.prototype.$ctor$1.$new(100, WootzJs.Mvc.Mvc.Views.Css.CssUnit().Percent);
    };
    $p.OneHundredPercent = null;
    $p.$Value$k__BackingField = null;
    $p.get_Value = function() {return this.$Value$k__BackingField;};
    $p.set_Value = function(value) {this.$Value$k__BackingField = value;};
    $p.$Unit$k__BackingField = 0;
    $p.get_Unit = function() {return this.$Unit$k__BackingField;};
    $p.set_Unit = function(value) {this.$Unit$k__BackingField = value;};
    $p.$ctor$2 = function(value, unit) {
        WootzJs.Mvc.Mvc.Views.Css.CssValue.prototype.$ctor.call(this);
        this.set_Value(value);
        this.set_Unit(unit);
    };
    $p.$ctor$2.$type = $t;
    $p.$ctor$2.$new = function(value, unit) {
        return new $p.$ctor$2.$type(this, value, unit);
    };
    $p.$ctor = function(unit) {
        WootzJs.Mvc.Mvc.Views.Css.CssValue.prototype.$ctor.call(this);
        this.set_Unit(unit);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function(unit) {
        return new $p.$ctor.$type(this, unit);
    };
    $p.$ctor$1 = function(value, unit) {
        WootzJs.Mvc.Mvc.Views.Css.CssNumericValue.prototype.$ctor$2.call(this, value.ToString(), unit);
    };
    $p.$ctor$1.$type = $t;
    $p.$ctor$1.$new = function(value, unit) {
        return new $p.$ctor$1.$type(this, value, unit);
    };
    $p.ToString = function() {
        if (this.get_Unit() == WootzJs.Mvc.Mvc.Views.Css.CssUnit().Auto)
            return "auto";
        return this.get_Value() + WootzJs.Mvc.Mvc.Views.Css.CssUnits.GetAbbreviation(this.get_Unit());
    };
    $t.op_Implicit = function(value) {
        return WootzJs.Mvc.Mvc.Views.Css.CssNumericValue.prototype.$ctor$2.$new(value.ToString(), WootzJs.Mvc.Mvc.Views.Css.CssUnit().Pixels);
    };
    $t.Parse$1 = function(value) {
        if (value == null)
            return null;
        if (value == "auto")
            return WootzJs.Mvc.Mvc.Views.Css.CssNumericValue.prototype.$ctor$1.$new(0, WootzJs.Mvc.Mvc.Views.Css.CssUnit().Auto);
        var numeric = System.Text.StringBuilder.prototype.$ctor.$new();
        {
            var $anon$1iterator = value;
            var $anon$2enumerator = $anon$1iterator.System$Collections$IEnumerable$GetEnumerator();
            while ($anon$2enumerator.System$Collections$IEnumerator$MoveNext()) {
                var c = $anon$2enumerator.System$Collections$IEnumerator$get_Current();
                if (System.Char.IsDigit(c))
                    numeric.Append(c);
                else
                    break;
            }
        }
        var number = numeric.ToString();
        var unit = String.prototype.Substring.call(value, number.length, 0);
        if (number.length == 0)
            return null;
        var cssUnit = WootzJs.Mvc.Mvc.Views.Css.CssUnits.Parse(unit);
        return WootzJs.Mvc.Mvc.Views.Css.CssNumericValue.prototype.$ctor$2.$new(number, cssUnit);
    };
}).call(null, WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, WootzJs.Mvc.Mvc.Views.Css.CssNumericValue.prototype);
$WootzJs$Mvc$AssemblyTypes.push(WootzJs.Mvc.Mvc.Views.Css.CssNumericValue);
WootzJs.Mvc.Mvc.Views.Css.CssPadding = $define("WootzJs.Mvc.Mvc.Views.Css.CssPadding", WootzJs.Mvc.Mvc.Views.Css.CssDeclaration);
(WootzJs.Mvc.Mvc.Views.Css.CssPadding.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Mvc$GetAssembly;
    $p.$type = $t;
    $t.$baseType = WootzJs.Mvc.Mvc.Views.Css.CssDeclaration;
    $p.$typeName = "WootzJs.Mvc.Mvc.Views.Css.CssPadding";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("CssPadding", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Mvc.Mvc.Views.Css.CssPadding", WootzJs.Mvc.Mvc.Views.Css.CssPadding, WootzJs.Mvc.Mvc.Views.Css.CssDeclaration, $arrayinit([], System.Type), $arrayinit([], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("get_Size", WootzJs.Mvc.Mvc.Views.Css.CssPadding.prototype.get_Size, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Size", WootzJs.Mvc.Mvc.Views.Css.CssPadding.prototype.set_Size, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_Left", WootzJs.Mvc.Mvc.Views.Css.CssPadding.prototype.get_Left, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Left", WootzJs.Mvc.Mvc.Views.Css.CssPadding.prototype.set_Left, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_Top", WootzJs.Mvc.Mvc.Views.Css.CssPadding.prototype.get_Top, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Top", WootzJs.Mvc.Mvc.Views.Css.CssPadding.prototype.set_Top, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_Right", WootzJs.Mvc.Mvc.Views.Css.CssPadding.prototype.get_Right, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Right", WootzJs.Mvc.Mvc.Views.Css.CssPadding.prototype.set_Right, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_Bottom", WootzJs.Mvc.Mvc.Views.Css.CssPadding.prototype.get_Bottom, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Bottom", WootzJs.Mvc.Mvc.Views.Css.CssPadding.prototype.set_Bottom, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("op_Implicit", WootzJs.Mvc.Mvc.Views.Css.CssPadding.prototype.op_Implicit, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("sizeInPixels", System.Int32, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Css.CssPadding, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Mvc.Mvc.Views.Css.CssPadding.prototype.$ctor, $arrayinit([], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor$1", WootzJs.Mvc.Mvc.Views.Css.CssPadding.prototype.$ctor$1, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("size", WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.PropertyInfo.prototype.$ctor.$new("Size", WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Size", WootzJs.Mvc.Mvc.Views.Css.CssPadding.prototype.get_Size, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Size", WootzJs.Mvc.Mvc.Views.Css.CssPadding.prototype.set_Size, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("Left", WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Left", WootzJs.Mvc.Mvc.Views.Css.CssPadding.prototype.get_Left, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Left", WootzJs.Mvc.Mvc.Views.Css.CssPadding.prototype.set_Left, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("Top", WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Top", WootzJs.Mvc.Mvc.Views.Css.CssPadding.prototype.get_Top, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Top", WootzJs.Mvc.Mvc.Views.Css.CssPadding.prototype.set_Top, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("Right", WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Right", WootzJs.Mvc.Mvc.Views.Css.CssPadding.prototype.get_Right, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Right", WootzJs.Mvc.Mvc.Views.Css.CssPadding.prototype.set_Right, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("Bottom", WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Bottom", WootzJs.Mvc.Mvc.Views.Css.CssPadding.prototype.get_Bottom, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Bottom", WootzJs.Mvc.Mvc.Views.Css.CssPadding.prototype.set_Bottom, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute))], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {};
    $p.$ctor = function() {
        WootzJs.Mvc.Mvc.Views.Css.CssDeclaration.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.$ctor$1 = function(size) {
        WootzJs.Mvc.Mvc.Views.Css.CssDeclaration.prototype.$ctor.call(this);
        this.set_Size(size);
    };
    $p.$ctor$1.$type = $t;
    $p.$ctor$1.$new = function(size) {
        return new $p.$ctor$1.$type(this, size);
    };
    $p.get_Size = function() {
        return WootzJs.Mvc.Mvc.Views.Css.CssNumericValue.Parse$1(this.Get("padding"));
    };
    $p.set_Size = function(value) {
        this.Set("padding", value);
    };
    $p.get_Left = function() {
        return WootzJs.Mvc.Mvc.Views.Css.CssNumericValue.Parse$1(this.Get("padding-left"));
    };
    $p.set_Left = function(value) {
        this.Set("padding-left", value);
    };
    $p.get_Top = function() {
        return WootzJs.Mvc.Mvc.Views.Css.CssNumericValue.Parse$1(this.Get("padding-top"));
    };
    $p.set_Top = function(value) {
        this.Set("padding-top", value);
    };
    $p.get_Right = function() {
        return WootzJs.Mvc.Mvc.Views.Css.CssNumericValue.Parse$1(this.Get("padding-right"));
    };
    $p.set_Right = function(value) {
        this.Set("padding-right", value);
    };
    $p.get_Bottom = function() {
        return WootzJs.Mvc.Mvc.Views.Css.CssNumericValue.Parse$1(this.Get("padding-bottom"));
    };
    $p.set_Bottom = function(value) {
        this.Set("padding-bottom", value);
    };
    $t.op_Implicit = function(sizeInPixels) {
        return WootzJs.Mvc.Mvc.Views.Css.CssPadding.prototype.$ctor$1.$new(WootzJs.Mvc.Mvc.Views.Css.CssNumericValue.op_Implicit(sizeInPixels));
    };
}).call(null, WootzJs.Mvc.Mvc.Views.Css.CssPadding, WootzJs.Mvc.Mvc.Views.Css.CssPadding.prototype);
$WootzJs$Mvc$AssemblyTypes.push(WootzJs.Mvc.Mvc.Views.Css.CssPadding);
WootzJs.Mvc.Mvc.Views.Css.CssPercent = $define("WootzJs.Mvc.Mvc.Views.Css.CssPercent", WootzJs.Mvc.Mvc.Views.Css.CssValue);
(WootzJs.Mvc.Mvc.Views.Css.CssPercent.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Mvc$GetAssembly;
    $p.$type = $t;
    $t.$baseType = WootzJs.Mvc.Mvc.Views.Css.CssValue;
    $p.$typeName = "WootzJs.Mvc.Mvc.Views.Css.CssPercent";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("CssPercent", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Mvc.Mvc.Views.Css.CssPercent", WootzJs.Mvc.Mvc.Views.Css.CssPercent, WootzJs.Mvc.Mvc.Views.Css.CssValue, $arrayinit([], System.Type), $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("value", System.Single, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("op_Implicit", WootzJs.Mvc.Mvc.Views.Css.CssPercent.prototype.op_Implicit, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Single, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Css.CssPercent, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_Value", WootzJs.Mvc.Mvc.Views.Css.CssPercent.prototype.get_Value, $arrayinit([], System.Reflection.ParameterInfo), System.Single, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("ToString", WootzJs.Mvc.Mvc.Views.Css.CssPercent.prototype.ToString, $arrayinit([], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Parse$1", WootzJs.Mvc.Mvc.Views.Css.CssPercent.prototype.Parse$1, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("s", String, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Css.CssPercent, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Mvc.Mvc.Views.Css.CssPercent.prototype.$ctor, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Single, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.PropertyInfo.prototype.$ctor.$new("Value", System.Single, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Value", WootzJs.Mvc.Mvc.Views.Css.CssPercent.prototype.get_Value, $arrayinit([], System.Reflection.ParameterInfo), System.Single, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), null, $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute))], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {};
    $p.value = 0;
    $p.$ctor = function(value) {
        WootzJs.Mvc.Mvc.Views.Css.CssValue.prototype.$ctor.call(this);
        this.value = value;
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function(value) {
        return new $p.$ctor.$type(this, value);
    };
    $t.op_Implicit = function(value) {
        return WootzJs.Mvc.Mvc.Views.Css.CssPercent.prototype.$ctor.$new(value);
    };
    $p.get_Value = function() {
        return this.value;
    };
    $p.ToString = function() {
        return this.value.ToString();
    };
    $t.Parse$1 = function(s) {
        return System.Single.Parse(s);
    };
}).call(null, WootzJs.Mvc.Mvc.Views.Css.CssPercent, WootzJs.Mvc.Mvc.Views.Css.CssPercent.prototype);
$WootzJs$Mvc$AssemblyTypes.push(WootzJs.Mvc.Mvc.Views.Css.CssPercent);
WootzJs.Mvc.Mvc.Views.Css.CssString = $define("WootzJs.Mvc.Mvc.Views.Css.CssString", WootzJs.Mvc.Mvc.Views.Css.CssValue);
(WootzJs.Mvc.Mvc.Views.Css.CssString.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Mvc$GetAssembly;
    $p.$type = $t;
    $t.$baseType = WootzJs.Mvc.Mvc.Views.Css.CssValue;
    $p.$typeName = "WootzJs.Mvc.Mvc.Views.Css.CssString";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("CssString", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Mvc.Mvc.Views.Css.CssString", WootzJs.Mvc.Mvc.Views.Css.CssString, WootzJs.Mvc.Mvc.Views.Css.CssValue, $arrayinit([], System.Type), $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("value", String, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("get_Value", WootzJs.Mvc.Mvc.Views.Css.CssString.prototype.get_Value, $arrayinit([], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("ToString", WootzJs.Mvc.Mvc.Views.Css.CssString.prototype.ToString, $arrayinit([], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Mvc.Mvc.Views.Css.CssString.prototype.$ctor, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", String, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.PropertyInfo.prototype.$ctor.$new("Value", String, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Value", WootzJs.Mvc.Mvc.Views.Css.CssString.prototype.get_Value, $arrayinit([], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), null, $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute))], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {};
    $p.value = null;
    $p.$ctor = function(value) {
        WootzJs.Mvc.Mvc.Views.Css.CssValue.prototype.$ctor.call(this);
        this.value = value;
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function(value) {
        return new $p.$ctor.$type(this, value);
    };
    $p.get_Value = function() {
        return this.value;
    };
    $p.ToString = function() {
        return this.value;
    };
}).call(null, WootzJs.Mvc.Mvc.Views.Css.CssString, WootzJs.Mvc.Mvc.Views.Css.CssString.prototype);
$WootzJs$Mvc$AssemblyTypes.push(WootzJs.Mvc.Mvc.Views.Css.CssString);
WootzJs.Mvc.Mvc.Views.Css.CssTextAlign = $define("WootzJs.Mvc.Mvc.Views.Css.CssTextAlign", System.Enum);
(WootzJs.Mvc.Mvc.Views.Css.CssTextAlign.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Mvc$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Enum;
    $p.$typeName = "WootzJs.Mvc.Mvc.Views.Css.CssTextAlign";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("CssTextAlign", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Mvc.Mvc.Views.Css.CssTextAlign", WootzJs.Mvc.Mvc.Views.Css.CssTextAlign, System.Enum, $arrayinit([], System.Type), $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("Left", WootzJs.Mvc.Mvc.Views.Css.CssTextAlign, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().Literal, 0, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("Right", WootzJs.Mvc.Mvc.Views.Css.CssTextAlign, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().Literal, 1, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("Center", WootzJs.Mvc.Mvc.Views.Css.CssTextAlign, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().Literal, 2, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("Justified", WootzJs.Mvc.Mvc.Views.Css.CssTextAlign, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().Literal, 3, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Mvc.Mvc.Views.Css.CssTextAlign.prototype.$ctor, $arrayinit([], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), true);return this.$type;};
    $t.$StaticInitializer = function() {
        $t.Left = 0;
        $t.Left$ = $p.$ctor.$new("Left", WootzJs.Mvc.Mvc.Views.Css.CssTextAlign().Left);
        $t.Right = WootzJs.Mvc.Mvc.Views.Css.CssTextAlign().Left + 1;
        $t.Right$ = $p.$ctor.$new("Right", WootzJs.Mvc.Mvc.Views.Css.CssTextAlign().Right);
        $t.Center = WootzJs.Mvc.Mvc.Views.Css.CssTextAlign().Right + 1;
        $t.Center$ = $p.$ctor.$new("Center", WootzJs.Mvc.Mvc.Views.Css.CssTextAlign().Center);
        $t.Justified = WootzJs.Mvc.Mvc.Views.Css.CssTextAlign().Center + 1;
        $t.Justified$ = $p.$ctor.$new("Justified", WootzJs.Mvc.Mvc.Views.Css.CssTextAlign().Justified);
    };
    $p.$ctor = function(name, value) {
        System.Enum.prototype.$ctor.call(this, name, value);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function(name, value) {
        return new $p.$ctor.$type(this, name, value);
    };
}).call(null, WootzJs.Mvc.Mvc.Views.Css.CssTextAlign, WootzJs.Mvc.Mvc.Views.Css.CssTextAlign.prototype);
$WootzJs$Mvc$AssemblyTypes.push(WootzJs.Mvc.Mvc.Views.Css.CssTextAlign);
WootzJs.Mvc.Mvc.Views.Css.CssTextAligns = $define("WootzJs.Mvc.Mvc.Views.Css.CssTextAligns", System.Object);
(WootzJs.Mvc.Mvc.Views.Css.CssTextAligns.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Mvc$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Mvc.Mvc.Views.Css.CssTextAligns";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("CssTextAligns", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Mvc.Mvc.Views.Css.CssTextAligns", WootzJs.Mvc.Mvc.Views.Css.CssTextAligns, System.Object, $arrayinit([], System.Type), $arrayinit([], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("GetValue", WootzJs.Mvc.Mvc.Views.Css.CssTextAligns.prototype.GetValue, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Css.CssTextAlign, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Parse", WootzJs.Mvc.Mvc.Views.Css.CssTextAligns.prototype.Parse, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("s", String, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Css.CssTextAlign, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {};
    $t.GetValue = function(value) {
        return System.Enum.InternalToObject(WootzJs.Mvc.Mvc.Views.Css.CssTextAlign, value).ToString().toLowerCase();
    };
    $t.Parse = function(s) {
        switch (s) {
            case "left":
                return WootzJs.Mvc.Mvc.Views.Css.CssTextAlign().Left;
            case "center":
                return WootzJs.Mvc.Mvc.Views.Css.CssTextAlign().Center;
            case "right":
                return WootzJs.Mvc.Mvc.Views.Css.CssTextAlign().Right;
            case "justified":
                return WootzJs.Mvc.Mvc.Views.Css.CssTextAlign().Justified;
            default:
                throw System.InvalidOperationException.prototype.$ctor$1.$new("Unknown text align: " + s).InternalInit(new Error());
        }
    };
}).call(null, WootzJs.Mvc.Mvc.Views.Css.CssTextAligns, WootzJs.Mvc.Mvc.Views.Css.CssTextAligns.prototype);
$WootzJs$Mvc$AssemblyTypes.push(WootzJs.Mvc.Mvc.Views.Css.CssTextAligns);
WootzJs.Mvc.Mvc.Views.Css.CssUnit = $define("WootzJs.Mvc.Mvc.Views.Css.CssUnit", System.Enum);
(WootzJs.Mvc.Mvc.Views.Css.CssUnit.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Mvc$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Enum;
    $p.$typeName = "WootzJs.Mvc.Mvc.Views.Css.CssUnit";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("CssUnit", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Mvc.Mvc.Views.Css.CssUnit", WootzJs.Mvc.Mvc.Views.Css.CssUnit, System.Enum, $arrayinit([], System.Type), $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("Pixels", WootzJs.Mvc.Mvc.Views.Css.CssUnit, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().Literal, 0, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("Percent", WootzJs.Mvc.Mvc.Views.Css.CssUnit, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().Literal, 1, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("Auto", WootzJs.Mvc.Mvc.Views.Css.CssUnit, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().Literal, 2, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Mvc.Mvc.Views.Css.CssUnit.prototype.$ctor, $arrayinit([], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), true);return this.$type;};
    $t.$StaticInitializer = function() {
        $t.Pixels = 0;
        $t.Pixels$ = $p.$ctor.$new("Pixels", WootzJs.Mvc.Mvc.Views.Css.CssUnit().Pixels);
        $t.Percent = WootzJs.Mvc.Mvc.Views.Css.CssUnit().Pixels + 1;
        $t.Percent$ = $p.$ctor.$new("Percent", WootzJs.Mvc.Mvc.Views.Css.CssUnit().Percent);
        $t.Auto = WootzJs.Mvc.Mvc.Views.Css.CssUnit().Percent + 1;
        $t.Auto$ = $p.$ctor.$new("Auto", WootzJs.Mvc.Mvc.Views.Css.CssUnit().Auto);
    };
    $p.$ctor = function(name, value) {
        System.Enum.prototype.$ctor.call(this, name, value);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function(name, value) {
        return new $p.$ctor.$type(this, name, value);
    };
}).call(null, WootzJs.Mvc.Mvc.Views.Css.CssUnit, WootzJs.Mvc.Mvc.Views.Css.CssUnit.prototype);
$WootzJs$Mvc$AssemblyTypes.push(WootzJs.Mvc.Mvc.Views.Css.CssUnit);
WootzJs.Mvc.Mvc.Views.Css.CssUnits = $define("WootzJs.Mvc.Mvc.Views.Css.CssUnits", System.Object);
(WootzJs.Mvc.Mvc.Views.Css.CssUnits.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Mvc$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Mvc.Mvc.Views.Css.CssUnits";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("CssUnits", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Mvc.Mvc.Views.Css.CssUnits", WootzJs.Mvc.Mvc.Views.Css.CssUnits, System.Object, $arrayinit([], System.Type), $arrayinit([], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("GetAbbreviation", WootzJs.Mvc.Mvc.Views.Css.CssUnits.prototype.GetAbbreviation, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("unit", WootzJs.Mvc.Mvc.Views.Css.CssUnit, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Parse", WootzJs.Mvc.Mvc.Views.Css.CssUnits.prototype.Parse, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("s", String, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Css.CssUnit, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {};
    $t.GetAbbreviation = function(unit) {
        switch (unit) {
            case WootzJs.Mvc.Mvc.Views.Css.CssUnit().Pixels:
                return "px";
            case WootzJs.Mvc.Mvc.Views.Css.CssUnit().Percent:
                return "%";
            default:
                throw System.InvalidOperationException.prototype.$ctor$1.$new("Unknown unit: " + $safeToString(unit)).InternalInit(new Error());
        }
    };
    $t.Parse = function(s) {
        switch (s) {
            case "px":
            case "":
                return WootzJs.Mvc.Mvc.Views.Css.CssUnit().Pixels;
            case "%":
                return WootzJs.Mvc.Mvc.Views.Css.CssUnit().Percent;
            default:
                throw System.InvalidOperationException.prototype.$ctor$1.$new("Unknown unit: " + s).InternalInit(new Error());
        }
    };
}).call(null, WootzJs.Mvc.Mvc.Views.Css.CssUnits, WootzJs.Mvc.Mvc.Views.Css.CssUnits.prototype);
$WootzJs$Mvc$AssemblyTypes.push(WootzJs.Mvc.Mvc.Views.Css.CssUnits);
WootzJs.Mvc.Mvc.Views.Css.CssVerticalAlign = $define("WootzJs.Mvc.Mvc.Views.Css.CssVerticalAlign", System.Enum);
(WootzJs.Mvc.Mvc.Views.Css.CssVerticalAlign.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Mvc$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Enum;
    $p.$typeName = "WootzJs.Mvc.Mvc.Views.Css.CssVerticalAlign";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("CssVerticalAlign", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Mvc.Mvc.Views.Css.CssVerticalAlign", WootzJs.Mvc.Mvc.Views.Css.CssVerticalAlign, System.Enum, $arrayinit([], System.Type), $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("Top", WootzJs.Mvc.Mvc.Views.Css.CssVerticalAlign, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().Literal, 0, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("Middle", WootzJs.Mvc.Mvc.Views.Css.CssVerticalAlign, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().Literal, 1, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("Bottom", WootzJs.Mvc.Mvc.Views.Css.CssVerticalAlign, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().Literal, 2, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Mvc.Mvc.Views.Css.CssVerticalAlign.prototype.$ctor, $arrayinit([], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), true);return this.$type;};
    $t.$StaticInitializer = function() {
        $t.Top = 0;
        $t.Top$ = $p.$ctor.$new("Top", WootzJs.Mvc.Mvc.Views.Css.CssVerticalAlign().Top);
        $t.Middle = WootzJs.Mvc.Mvc.Views.Css.CssVerticalAlign().Top + 1;
        $t.Middle$ = $p.$ctor.$new("Middle", WootzJs.Mvc.Mvc.Views.Css.CssVerticalAlign().Middle);
        $t.Bottom = WootzJs.Mvc.Mvc.Views.Css.CssVerticalAlign().Middle + 1;
        $t.Bottom$ = $p.$ctor.$new("Bottom", WootzJs.Mvc.Mvc.Views.Css.CssVerticalAlign().Bottom);
    };
    $p.$ctor = function(name, value) {
        System.Enum.prototype.$ctor.call(this, name, value);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function(name, value) {
        return new $p.$ctor.$type(this, name, value);
    };
}).call(null, WootzJs.Mvc.Mvc.Views.Css.CssVerticalAlign, WootzJs.Mvc.Mvc.Views.Css.CssVerticalAlign.prototype);
$WootzJs$Mvc$AssemblyTypes.push(WootzJs.Mvc.Mvc.Views.Css.CssVerticalAlign);
WootzJs.Mvc.Mvc.Views.Css.Style = $define("WootzJs.Mvc.Mvc.Views.Css.Style", WootzJs.Mvc.Mvc.Views.Css.CssDeclaration);
(WootzJs.Mvc.Mvc.Views.Css.Style.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Mvc$GetAssembly;
    $p.$type = $t;
    $t.$baseType = WootzJs.Mvc.Mvc.Views.Css.CssDeclaration;
    $p.$typeName = "WootzJs.Mvc.Mvc.Views.Css.Style";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("Style", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Mvc.Mvc.Views.Css.Style", WootzJs.Mvc.Mvc.Views.Css.Style, WootzJs.Mvc.Mvc.Views.Css.CssDeclaration, $arrayinit([], System.Type), $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("padding", WootzJs.Mvc.Mvc.Views.Css.CssPadding, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("border", WootzJs.Mvc.Mvc.Views.Css.CssBorder, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("boxShadow", WootzJs.Mvc.Mvc.Views.Css.CssBoxShadow, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("font", WootzJs.Mvc.Mvc.Views.Css.CssFont, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("Attach", WootzJs.Mvc.Mvc.Views.Css.Style.prototype.Attach, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("node", WootzJs.Web.ElementStyle, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Assembly, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_Border", WootzJs.Mvc.Mvc.Views.Css.Style.prototype.get_Border, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Css.CssBorder, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Border", WootzJs.Mvc.Mvc.Views.Css.Style.prototype.set_Border, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Css.CssBorder, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_Padding", WootzJs.Mvc.Mvc.Views.Css.Style.prototype.get_Padding, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Css.CssPadding, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Padding", WootzJs.Mvc.Mvc.Views.Css.Style.prototype.set_Padding, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Css.CssPadding, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_BoxShadow", WootzJs.Mvc.Mvc.Views.Css.Style.prototype.get_BoxShadow, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Css.CssBoxShadow, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_BoxShadow", WootzJs.Mvc.Mvc.Views.Css.Style.prototype.set_BoxShadow, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Css.CssBoxShadow, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_Font", WootzJs.Mvc.Mvc.Views.Css.Style.prototype.get_Font, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Css.CssFont, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Font", WootzJs.Mvc.Mvc.Views.Css.Style.prototype.set_Font, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Css.CssFont, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_BackgroundColor", WootzJs.Mvc.Mvc.Views.Css.Style.prototype.get_BackgroundColor, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Css.CssColor, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_BackgroundColor", WootzJs.Mvc.Mvc.Views.Css.Style.prototype.set_BackgroundColor, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Css.CssColor, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_Color", WootzJs.Mvc.Mvc.Views.Css.Style.prototype.get_Color, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Css.CssColor, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Color", WootzJs.Mvc.Mvc.Views.Css.Style.prototype.set_Color, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Css.CssColor, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_Cursor", WootzJs.Mvc.Mvc.Views.Css.Style.prototype.get_Cursor, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Css.CssCursor, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Cursor", WootzJs.Mvc.Mvc.Views.Css.Style.prototype.set_Cursor, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Css.CssCursor, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_Width", WootzJs.Mvc.Mvc.Views.Css.Style.prototype.get_Width, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Width", WootzJs.Mvc.Mvc.Views.Css.Style.prototype.set_Width, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_Height", WootzJs.Mvc.Mvc.Views.Css.Style.prototype.get_Height, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Height", WootzJs.Mvc.Mvc.Views.Css.Style.prototype.set_Height, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_MinWidth", WootzJs.Mvc.Mvc.Views.Css.Style.prototype.get_MinWidth, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_MinWidth", WootzJs.Mvc.Mvc.Views.Css.Style.prototype.set_MinWidth, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_MinHeight", WootzJs.Mvc.Mvc.Views.Css.Style.prototype.get_MinHeight, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_MinHeight", WootzJs.Mvc.Mvc.Views.Css.Style.prototype.set_MinHeight, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_MaxWidth", WootzJs.Mvc.Mvc.Views.Css.Style.prototype.get_MaxWidth, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_MaxWidth", WootzJs.Mvc.Mvc.Views.Css.Style.prototype.set_MaxWidth, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_MaxHeight", WootzJs.Mvc.Mvc.Views.Css.Style.prototype.get_MaxHeight, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_MaxHeight", WootzJs.Mvc.Mvc.Views.Css.Style.prototype.set_MaxHeight, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_BorderCollapse", WootzJs.Mvc.Mvc.Views.Css.Style.prototype.get_BorderCollapse, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Css.CssBorderCollapse, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_BorderCollapse", WootzJs.Mvc.Mvc.Views.Css.Style.prototype.set_BorderCollapse, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Css.CssBorderCollapse, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_Opacity", WootzJs.Mvc.Mvc.Views.Css.Style.prototype.get_Opacity, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Css.CssPercent, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Opacity", WootzJs.Mvc.Mvc.Views.Css.Style.prototype.set_Opacity, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Css.CssPercent, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Mvc.Mvc.Views.Css.Style.prototype.$ctor, $arrayinit([], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.PropertyInfo.prototype.$ctor.$new("Border", WootzJs.Mvc.Mvc.Views.Css.CssBorder, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Border", WootzJs.Mvc.Mvc.Views.Css.Style.prototype.get_Border, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Css.CssBorder, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Border", WootzJs.Mvc.Mvc.Views.Css.Style.prototype.set_Border, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Css.CssBorder, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("Padding", WootzJs.Mvc.Mvc.Views.Css.CssPadding, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Padding", WootzJs.Mvc.Mvc.Views.Css.Style.prototype.get_Padding, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Css.CssPadding, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Padding", WootzJs.Mvc.Mvc.Views.Css.Style.prototype.set_Padding, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Css.CssPadding, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("BoxShadow", WootzJs.Mvc.Mvc.Views.Css.CssBoxShadow, System.Reflection.MethodInfo.prototype.$ctor.$new("get_BoxShadow", WootzJs.Mvc.Mvc.Views.Css.Style.prototype.get_BoxShadow, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Css.CssBoxShadow, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_BoxShadow", WootzJs.Mvc.Mvc.Views.Css.Style.prototype.set_BoxShadow, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Css.CssBoxShadow, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("Font", WootzJs.Mvc.Mvc.Views.Css.CssFont, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Font", WootzJs.Mvc.Mvc.Views.Css.Style.prototype.get_Font, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Css.CssFont, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Font", WootzJs.Mvc.Mvc.Views.Css.Style.prototype.set_Font, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Css.CssFont, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("BackgroundColor", WootzJs.Mvc.Mvc.Views.Css.CssColor, System.Reflection.MethodInfo.prototype.$ctor.$new("get_BackgroundColor", WootzJs.Mvc.Mvc.Views.Css.Style.prototype.get_BackgroundColor, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Css.CssColor, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_BackgroundColor", WootzJs.Mvc.Mvc.Views.Css.Style.prototype.set_BackgroundColor, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Css.CssColor, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("Color", WootzJs.Mvc.Mvc.Views.Css.CssColor, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Color", WootzJs.Mvc.Mvc.Views.Css.Style.prototype.get_Color, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Css.CssColor, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Color", WootzJs.Mvc.Mvc.Views.Css.Style.prototype.set_Color, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Css.CssColor, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("Cursor", WootzJs.Mvc.Mvc.Views.Css.CssCursor, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Cursor", WootzJs.Mvc.Mvc.Views.Css.Style.prototype.get_Cursor, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Css.CssCursor, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Cursor", WootzJs.Mvc.Mvc.Views.Css.Style.prototype.set_Cursor, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Css.CssCursor, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("Width", WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Width", WootzJs.Mvc.Mvc.Views.Css.Style.prototype.get_Width, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Width", WootzJs.Mvc.Mvc.Views.Css.Style.prototype.set_Width, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("Height", WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Height", WootzJs.Mvc.Mvc.Views.Css.Style.prototype.get_Height, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Height", WootzJs.Mvc.Mvc.Views.Css.Style.prototype.set_Height, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("MinWidth", WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, System.Reflection.MethodInfo.prototype.$ctor.$new("get_MinWidth", WootzJs.Mvc.Mvc.Views.Css.Style.prototype.get_MinWidth, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_MinWidth", WootzJs.Mvc.Mvc.Views.Css.Style.prototype.set_MinWidth, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("MinHeight", WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, System.Reflection.MethodInfo.prototype.$ctor.$new("get_MinHeight", WootzJs.Mvc.Mvc.Views.Css.Style.prototype.get_MinHeight, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_MinHeight", WootzJs.Mvc.Mvc.Views.Css.Style.prototype.set_MinHeight, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("MaxWidth", WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, System.Reflection.MethodInfo.prototype.$ctor.$new("get_MaxWidth", WootzJs.Mvc.Mvc.Views.Css.Style.prototype.get_MaxWidth, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_MaxWidth", WootzJs.Mvc.Mvc.Views.Css.Style.prototype.set_MaxWidth, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("MaxHeight", WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, System.Reflection.MethodInfo.prototype.$ctor.$new("get_MaxHeight", WootzJs.Mvc.Mvc.Views.Css.Style.prototype.get_MaxHeight, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_MaxHeight", WootzJs.Mvc.Mvc.Views.Css.Style.prototype.set_MaxHeight, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("BorderCollapse", WootzJs.Mvc.Mvc.Views.Css.CssBorderCollapse, System.Reflection.MethodInfo.prototype.$ctor.$new("get_BorderCollapse", WootzJs.Mvc.Mvc.Views.Css.Style.prototype.get_BorderCollapse, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Css.CssBorderCollapse, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_BorderCollapse", WootzJs.Mvc.Mvc.Views.Css.Style.prototype.set_BorderCollapse, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Css.CssBorderCollapse, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("Opacity", WootzJs.Mvc.Mvc.Views.Css.CssPercent, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Opacity", WootzJs.Mvc.Mvc.Views.Css.Style.prototype.get_Opacity, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Css.CssPercent, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Opacity", WootzJs.Mvc.Mvc.Views.Css.Style.prototype.set_Opacity, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Css.CssPercent, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute))], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {};
    $p.$ctor = function() {
        WootzJs.Mvc.Mvc.Views.Css.CssDeclaration.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.padding = null;
    $p.border = null;
    $p.boxShadow = null;
    $p.font = null;
    $p.Attach = function(node) {
        WootzJs.Mvc.Mvc.Views.Css.CssDeclaration.prototype.Attach.call(this, node);
        if (this.padding != null)
            this.padding.Attach(node);
        if (this.border != null)
            this.border.Attach(node);
        if (this.boxShadow != null)
            this.boxShadow.Attach(node);
        if (this.font != null)
            this.font.Attach(node);
    };
    $p.get_Border = function() {
        if (this.border == null)
            this.set_Border(WootzJs.Mvc.Mvc.Views.Css.CssBorder.prototype.$ctor.$new());
        return this.border;
    };
    $p.set_Border = function(value) {
        this.border = value;
        if (this.node != null)
            value.Attach(this.node);
    };
    $p.get_Padding = function() {
        return this.padding;
    };
    $p.set_Padding = function(value) {
        this.padding = value;
        if (this.node != null)
            value.Attach(this.node);
    };
    $p.get_BoxShadow = function() {
        return this.boxShadow;
    };
    $p.set_BoxShadow = function(value) {
        this.boxShadow = value;
        if (this.node != null)
            value.Attach(this.node);
    };
    $p.get_Font = function() {
        if (this.font == null)
            this.set_Font(WootzJs.Mvc.Mvc.Views.Css.CssFont.prototype.$ctor.$new());
        return this.font;
    };
    $p.set_Font = function(value) {
        this.font = value;
        if (this.node != null)
            value.Attach(this.node);
    };
    $p.get_BackgroundColor = function() {
        return WootzJs.Mvc.Mvc.Views.Css.CssColor.Parse$1(this.Get("background-color"));
    };
    $p.set_BackgroundColor = function(value) {
        this.Set("background-color", value);
    };
    $p.get_Color = function() {
        return WootzJs.Mvc.Mvc.Views.Css.CssColor.Parse$1(this.Get("color"));
    };
    $p.set_Color = function(value) {
        this.Set("color", value);
    };
    $p.get_Cursor = function() {
        return WootzJs.Mvc.Mvc.Views.Css.CssCursors.Parse(this.Get("cursor"));
    };
    $p.set_Cursor = function(value) {
        this.Set("cursor", WootzJs.Mvc.Mvc.Views.Css.CssCursors.GetName(value));
    };
    $p.get_Width = function() {
        return WootzJs.Mvc.Mvc.Views.Css.CssNumericValue.Parse$1(this.Get("width"));
    };
    $p.set_Width = function(value) {
        this.Set("width", value);
    };
    $p.get_Height = function() {
        return WootzJs.Mvc.Mvc.Views.Css.CssNumericValue.Parse$1(this.Get("height"));
    };
    $p.set_Height = function(value) {
        this.Set("height", value);
    };
    $p.get_MinWidth = function() {
        return WootzJs.Mvc.Mvc.Views.Css.CssNumericValue.Parse$1(this.Get("min-width"));
    };
    $p.set_MinWidth = function(value) {
        this.Set("min-width", value);
    };
    $p.get_MinHeight = function() {
        return WootzJs.Mvc.Mvc.Views.Css.CssNumericValue.Parse$1(this.Get("min-height"));
    };
    $p.set_MinHeight = function(value) {
        this.Set("min-height", value);
    };
    $p.get_MaxWidth = function() {
        return WootzJs.Mvc.Mvc.Views.Css.CssNumericValue.Parse$1(this.Get("max-width"));
    };
    $p.set_MaxWidth = function(value) {
        this.Set("max-width", value);
    };
    $p.get_MaxHeight = function() {
        return WootzJs.Mvc.Mvc.Views.Css.CssNumericValue.Parse$1(this.Get("max-height"));
    };
    $p.set_MaxHeight = function(value) {
        this.Set("max-height", value);
    };
    $p.get_BorderCollapse = function() {
        return WootzJs.Mvc.Mvc.Views.Css.CssBorderCollapses.Parse(this.Get("border-collapse"));
    };
    $p.set_BorderCollapse = function(value) {
        this.Set("border-collapse", value);
    };
    $p.get_Opacity = function() {
        return WootzJs.Mvc.Mvc.Views.Css.CssPercent.Parse$1(this.Get("opacity"));
    };
    $p.set_Opacity = function(value) {
        this.Set("opacity", value);
    };
}).call(null, WootzJs.Mvc.Mvc.Views.Css.Style, WootzJs.Mvc.Mvc.Views.Css.Style.prototype);
$WootzJs$Mvc$AssemblyTypes.push(WootzJs.Mvc.Mvc.Views.Css.Style);
WootzJs.Mvc.Mvc.Views.DropDown = $define("WootzJs.Mvc.Mvc.Views.DropDown", WootzJs.Mvc.Mvc.Views.Control);
(WootzJs.Mvc.Mvc.Views.DropDown.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Mvc$GetAssembly;
    $p.$type = $t;
    $t.$baseType = WootzJs.Mvc.Mvc.Views.Control;
    $p.$typeName = "WootzJs.Mvc.Mvc.Views.DropDown";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("DropDown", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Mvc.Mvc.Views.DropDown", WootzJs.Mvc.Mvc.Views.DropDown, WootzJs.Mvc.Mvc.Views.Control, $arrayinit([], System.Type), $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("content", WootzJs.Mvc.Mvc.Views.Control, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("overlay", WootzJs.Mvc.Mvc.Views.Control, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("get_Content", WootzJs.Mvc.Mvc.Views.DropDown.prototype.get_Content, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Control, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Content", WootzJs.Mvc.Mvc.Views.DropDown.prototype.set_Content, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Control, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_Overlay", WootzJs.Mvc.Mvc.Views.DropDown.prototype.get_Overlay, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Control, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Overlay", WootzJs.Mvc.Mvc.Views.DropDown.prototype.set_Overlay, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Control, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("CreateNode", WootzJs.Mvc.Mvc.Views.DropDown.prototype.CreateNode, $arrayinit([], System.Reflection.ParameterInfo), Element, System.Reflection.MethodAttributes().Family, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("OnJsContentMouseEnter", WootzJs.Mvc.Mvc.Views.DropDown.prototype.OnJsContentMouseEnter, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("arg", Event, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Private, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("OnJsContentMouseLeave", WootzJs.Mvc.Mvc.Views.DropDown.prototype.OnJsContentMouseLeave, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("arg", Event, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Private, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Mvc.Mvc.Views.DropDown.prototype.$ctor, $arrayinit([], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor$1", WootzJs.Mvc.Mvc.Views.DropDown.prototype.$ctor$1, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("content", WootzJs.Mvc.Mvc.Views.Control, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("overlay", WootzJs.Mvc.Mvc.Views.Control, 1, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.PropertyInfo.prototype.$ctor.$new("Content", WootzJs.Mvc.Mvc.Views.Control, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Content", WootzJs.Mvc.Mvc.Views.DropDown.prototype.get_Content, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Control, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Content", WootzJs.Mvc.Mvc.Views.DropDown.prototype.set_Content, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Control, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("Overlay", WootzJs.Mvc.Mvc.Views.Control, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Overlay", WootzJs.Mvc.Mvc.Views.DropDown.prototype.get_Overlay, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Control, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Overlay", WootzJs.Mvc.Mvc.Views.DropDown.prototype.set_Overlay, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Control, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute))], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {};
    $p.content = null;
    $p.overlay = null;
    $p.contentNode = null;
    $p.overlayContainer = null;
    $p.$ctor = function() {
        WootzJs.Mvc.Mvc.Views.Control.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.$ctor$1 = function(content, overlay) {
        WootzJs.Mvc.Mvc.Views.Control.prototype.$ctor.call(this);
        this.set_Content(content);
        this.set_Overlay(overlay);
    };
    $p.$ctor$1.$type = $t;
    $p.$ctor$1.$new = function(content, overlay) {
        return new $p.$ctor$1.$type(this, content, overlay);
    };
    $p.get_Content = function() {
        return this.content;
    };
    $p.set_Content = function(value) {
        if (this.content != null) {
            this.Remove(this.content);
            WootzJs.Web.NodeExtensions.Remove(this.content.get_Node());
        }
        this.content = value;
        if (this.content != null) {
            this.Add(value);
            this.contentNode.appendChild(this.content.get_Node());
        }
    };
    $p.get_Overlay = function() {
        return this.overlay;
    };
    $p.set_Overlay = function(value) {
        if (this.overlay != null) {
            this.Remove(this.overlay);
            WootzJs.Web.NodeExtensions.Remove(this.overlay.get_Node());
        }
        this.overlay = value;
        if (this.overlay != null) {
            this.Add(this.overlay);
            this.overlayContainer.appendChild(this.overlay.get_Node());
        }
    };
    $p.CreateNode = function() {
        this.contentNode = WootzJs.Web.Browser().get_Document().createElement("div");
        this.overlayContainer = WootzJs.Web.Browser().get_Document().createElement("div");
        this.overlayContainer.style.position = "absolute";
        this.overlayContainer.style.display = "none";
        var overlayAnchor = WootzJs.Web.Browser().get_Document().createElement("div");
        overlayAnchor.style.position = "relative";
        overlayAnchor.appendChild(this.overlayContainer);
        var result = WootzJs.Web.Browser().get_Document().createElement("div");
        result.appendChild(this.contentNode);
        result.appendChild(overlayAnchor);
        result.addEventListener("mouseenter", $delegate(
            this, 
            System.Action$1$(Event), 
            this.OnJsContentMouseEnter, 
            "OnJsContentMouseEnter$delegate"
        ));
        result.addEventListener("mouseleave", $delegate(
            this, 
            System.Action$1$(Event), 
            this.OnJsContentMouseLeave, 
            "OnJsContentMouseLeave$delegate"
        ));
        return result;
    };
    $p.OnJsContentMouseEnter = function(arg) {
        if (this.overlay != null)
            this.overlayContainer.style.display = "";
    };
    $p.OnJsContentMouseLeave = function(arg) {
        if (this.overlay != null)
            this.overlayContainer.style.display = "none";
    };
}).call(null, WootzJs.Mvc.Mvc.Views.DropDown, WootzJs.Mvc.Mvc.Views.DropDown.prototype);
$WootzJs$Mvc$AssemblyTypes.push(WootzJs.Mvc.Mvc.Views.DropDown);
WootzJs.Mvc.Mvc.Views.FillPanel = $define("WootzJs.Mvc.Mvc.Views.FillPanel", WootzJs.Mvc.Mvc.Views.Control);
(WootzJs.Mvc.Mvc.Views.FillPanel.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Mvc$GetAssembly;
    $p.$type = $t;
    $t.$baseType = WootzJs.Mvc.Mvc.Views.Control;
    $p.$typeName = "WootzJs.Mvc.Mvc.Views.FillPanel";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("FillPanel", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Mvc.Mvc.Views.FillPanel", WootzJs.Mvc.Mvc.Views.FillPanel, WootzJs.Mvc.Mvc.Views.Control, $arrayinit([], System.Type), $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("content", WootzJs.Mvc.Mvc.Views.Control, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("CreateNode", WootzJs.Mvc.Mvc.Views.FillPanel.prototype.CreateNode, $arrayinit([], System.Reflection.ParameterInfo), Element, System.Reflection.MethodAttributes().Family, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_Content", WootzJs.Mvc.Mvc.Views.FillPanel.prototype.get_Content, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Control, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Content", WootzJs.Mvc.Mvc.Views.FillPanel.prototype.set_Content, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Control, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Mvc.Mvc.Views.FillPanel.prototype.$ctor, $arrayinit([], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor$1", WootzJs.Mvc.Mvc.Views.FillPanel.prototype.$ctor$1, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("content", WootzJs.Mvc.Mvc.Views.Control, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.PropertyInfo.prototype.$ctor.$new("Content", WootzJs.Mvc.Mvc.Views.Control, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Content", WootzJs.Mvc.Mvc.Views.FillPanel.prototype.get_Content, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Control, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Content", WootzJs.Mvc.Mvc.Views.FillPanel.prototype.set_Content, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Control, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute))], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {};
    $p.content = null;
    $p.$ctor = function() {
        WootzJs.Mvc.Mvc.Views.Control.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.$ctor$1 = function(content) {
        WootzJs.Mvc.Mvc.Views.Control.prototype.$ctor.call(this);
        this.set_Content(content);
    };
    $p.$ctor$1.$type = $t;
    $p.$ctor$1.$new = function(content) {
        return new $p.$ctor$1.$type(this, content);
    };
    $p.CreateNode = function() {
        var container = WootzJs.Web.Browser().get_Document().createElement("div");
        container.style.width = "100%";
        container.style.height = "100%";
        return container;
    };
    $p.get_Content = function() {
        return this.content;
    };
    $p.set_Content = function(value) {
        if (this.content != null) {
            this.Remove(this.content);
            WootzJs.Web.NodeExtensions.Remove(this.content.get_Node());
        }
        this.content = value;
        if (this.content != null) {
            this.Add(this.content);
            var childNode = value.get_Node();
            childNode.style.width = "100%";
            childNode.style.height = "100%";
            this.get_Node().appendChild(childNode);
        }
    };
}).call(null, WootzJs.Mvc.Mvc.Views.FillPanel, WootzJs.Mvc.Mvc.Views.FillPanel.prototype);
$WootzJs$Mvc$AssemblyTypes.push(WootzJs.Mvc.Mvc.Views.FillPanel);
WootzJs.Mvc.Mvc.Views.FixedPanel = $define("WootzJs.Mvc.Mvc.Views.FixedPanel", WootzJs.Mvc.Mvc.Views.Control);
(WootzJs.Mvc.Mvc.Views.FixedPanel.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Mvc$GetAssembly;
    $p.$type = $t;
    $t.$baseType = WootzJs.Mvc.Mvc.Views.Control;
    $p.$typeName = "WootzJs.Mvc.Mvc.Views.FixedPanel";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("FixedPanel", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Mvc.Mvc.Views.FixedPanel", WootzJs.Mvc.Mvc.Views.FixedPanel, WootzJs.Mvc.Mvc.Views.Control, $arrayinit([], System.Type), $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("content", WootzJs.Mvc.Mvc.Views.Control, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("CreateNode", WootzJs.Mvc.Mvc.Views.FixedPanel.prototype.CreateNode, $arrayinit([], System.Reflection.ParameterInfo), Element, System.Reflection.MethodAttributes().Family, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_Content", WootzJs.Mvc.Mvc.Views.FixedPanel.prototype.get_Content, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Control, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Content", WootzJs.Mvc.Mvc.Views.FixedPanel.prototype.set_Content, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Control, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Mvc.Mvc.Views.FixedPanel.prototype.$ctor, $arrayinit([], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor$1", WootzJs.Mvc.Mvc.Views.FixedPanel.prototype.$ctor$1, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("width", WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("height", WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, 1, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor$2", WootzJs.Mvc.Mvc.Views.FixedPanel.prototype.$ctor$2, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("width", WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("height", WootzJs.Mvc.Mvc.Views.Css.CssNumericValue, 1, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("content", WootzJs.Mvc.Mvc.Views.Control, 2, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.PropertyInfo.prototype.$ctor.$new("Content", WootzJs.Mvc.Mvc.Views.Control, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Content", WootzJs.Mvc.Mvc.Views.FixedPanel.prototype.get_Content, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Control, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Content", WootzJs.Mvc.Mvc.Views.FixedPanel.prototype.set_Content, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Control, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute))], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {};
    $p.content = null;
    $p.$ctor = function() {
        WootzJs.Mvc.Mvc.Views.Control.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.$ctor$1 = function(width, height) {
        WootzJs.Mvc.Mvc.Views.Control.prototype.$ctor.call(this);
        this.get_Style().set_Width(width);
        this.get_Style().set_Height(height);
    };
    $p.$ctor$1.$type = $t;
    $p.$ctor$1.$new = function(width, height) {
        return new $p.$ctor$1.$type(this, width, height);
    };
    $p.$ctor$2 = function(width, height, content) {
        WootzJs.Mvc.Mvc.Views.Control.prototype.$ctor.call(this);
        this.get_Style().set_Width(width);
        this.get_Style().set_Height(height);
        this.set_Content(content);
    };
    $p.$ctor$2.$type = $t;
    $p.$ctor$2.$new = function(width, height, content) {
        return new $p.$ctor$2.$type(
            this, 
            width, 
            height, 
            content
        );
    };
    $p.CreateNode = function() {
        var div = WootzJs.Web.Browser().get_Document().createElement("div");
        return div;
    };
    $p.get_Content = function() {
        return this.content;
    };
    $p.set_Content = function(value) {
        if (this.content != null) {
            this.Remove(this.content);
            WootzJs.Web.NodeExtensions.Remove(this.content.get_Node());
        }
        this.content = value;
        if (this.content != null) {
            this.Add(this.content);
            this.get_Node().appendChild(this.content.get_Node());
            this.content.get_Node().style.width = "100%";
            this.content.get_Node().style.height = "100%";
        }
    };
}).call(null, WootzJs.Mvc.Mvc.Views.FixedPanel, WootzJs.Mvc.Mvc.Views.FixedPanel.prototype);
$WootzJs$Mvc$AssemblyTypes.push(WootzJs.Mvc.Mvc.Views.FixedPanel);
WootzJs.Mvc.Mvc.Views.FlowPanel = $define("WootzJs.Mvc.Mvc.Views.FlowPanel", System.Object);
(WootzJs.Mvc.Mvc.Views.FlowPanel.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Mvc$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Mvc.Mvc.Views.FlowPanel";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("FlowPanel", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Mvc.Mvc.Views.FlowPanel", WootzJs.Mvc.Mvc.Views.FlowPanel, System.Object, $arrayinit([], System.Type), $arrayinit([], System.Reflection.FieldInfo), $arrayinit([], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Mvc.Mvc.Views.FlowPanel.prototype.$ctor, $arrayinit([], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {};
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
}).call(null, WootzJs.Mvc.Mvc.Views.FlowPanel, WootzJs.Mvc.Mvc.Views.FlowPanel.prototype);
$WootzJs$Mvc$AssemblyTypes.push(WootzJs.Mvc.Mvc.Views.FlowPanel);
WootzJs.Mvc.Mvc.Views.HorizontalAlignment = $define("WootzJs.Mvc.Mvc.Views.HorizontalAlignment", System.Enum);
(WootzJs.Mvc.Mvc.Views.HorizontalAlignment.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Mvc$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Enum;
    $p.$typeName = "WootzJs.Mvc.Mvc.Views.HorizontalAlignment";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("HorizontalAlignment", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Mvc.Mvc.Views.HorizontalAlignment", WootzJs.Mvc.Mvc.Views.HorizontalAlignment, System.Enum, $arrayinit([], System.Type), $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("Left", WootzJs.Mvc.Mvc.Views.HorizontalAlignment, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().Literal, 0, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("Center", WootzJs.Mvc.Mvc.Views.HorizontalAlignment, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().Literal, 1, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("Right", WootzJs.Mvc.Mvc.Views.HorizontalAlignment, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().Literal, 2, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("Fill", WootzJs.Mvc.Mvc.Views.HorizontalAlignment, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().Literal, 3, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Mvc.Mvc.Views.HorizontalAlignment.prototype.$ctor, $arrayinit([], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), true);return this.$type;};
    $t.$StaticInitializer = function() {
        $t.Left = 0;
        $t.Left$ = $p.$ctor.$new("Left", WootzJs.Mvc.Mvc.Views.HorizontalAlignment().Left);
        $t.Center = WootzJs.Mvc.Mvc.Views.HorizontalAlignment().Left + 1;
        $t.Center$ = $p.$ctor.$new("Center", WootzJs.Mvc.Mvc.Views.HorizontalAlignment().Center);
        $t.Right = WootzJs.Mvc.Mvc.Views.HorizontalAlignment().Center + 1;
        $t.Right$ = $p.$ctor.$new("Right", WootzJs.Mvc.Mvc.Views.HorizontalAlignment().Right);
        $t.Fill = WootzJs.Mvc.Mvc.Views.HorizontalAlignment().Right + 1;
        $t.Fill$ = $p.$ctor.$new("Fill", WootzJs.Mvc.Mvc.Views.HorizontalAlignment().Fill);
    };
    $p.$ctor = function(name, value) {
        System.Enum.prototype.$ctor.call(this, name, value);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function(name, value) {
        return new $p.$ctor.$type(this, name, value);
    };
}).call(null, WootzJs.Mvc.Mvc.Views.HorizontalAlignment, WootzJs.Mvc.Mvc.Views.HorizontalAlignment.prototype);
$WootzJs$Mvc$AssemblyTypes.push(WootzJs.Mvc.Mvc.Views.HorizontalAlignment);
WootzJs.Mvc.Mvc.Views.HorizontalPanel = $define("WootzJs.Mvc.Mvc.Views.HorizontalPanel", WootzJs.Mvc.Mvc.Views.Control);
(WootzJs.Mvc.Mvc.Views.HorizontalPanel.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Mvc$GetAssembly;
    $p.$type = $t;
    $t.$baseType = WootzJs.Mvc.Mvc.Views.Control;
    $p.$typeName = "WootzJs.Mvc.Mvc.Views.HorizontalPanel";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("HorizontalPanel", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Mvc.Mvc.Views.HorizontalPanel", WootzJs.Mvc.Mvc.Views.HorizontalPanel, WootzJs.Mvc.Mvc.Views.Control, $arrayinit([], System.Type), $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("$Spacing$k__BackingField", System.Int32, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("get_Spacing", WootzJs.Mvc.Mvc.Views.HorizontalPanel.prototype.get_Spacing, $arrayinit([], System.Reflection.ParameterInfo), System.Int32, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Spacing", WootzJs.Mvc.Mvc.Views.HorizontalPanel.prototype.set_Spacing, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Int32, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_HorizontalAlignment", WootzJs.Mvc.Mvc.Views.HorizontalPanel.prototype.get_HorizontalAlignment, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.HorizontalAlignment, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_HorizontalAlignment", WootzJs.Mvc.Mvc.Views.HorizontalPanel.prototype.set_HorizontalAlignment, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.HorizontalAlignment, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("CreateNode", WootzJs.Mvc.Mvc.Views.HorizontalPanel.prototype.CreateNode, $arrayinit([], System.Reflection.ParameterInfo), Element, System.Reflection.MethodAttributes().Family, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Add$1", WootzJs.Mvc.Mvc.Views.HorizontalPanel.prototype.Add$1, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("child", WootzJs.Mvc.Mvc.Views.Control, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Add$2", WootzJs.Mvc.Mvc.Views.HorizontalPanel.prototype.Add$2, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("child", WootzJs.Mvc.Mvc.Views.Control, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("alignment", WootzJs.Mvc.Mvc.Views.VerticalAlignment, 1, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Add$3", WootzJs.Mvc.Mvc.Views.HorizontalPanel.prototype.Add$3, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("child", WootzJs.Mvc.Mvc.Views.Control, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("spaceBefore", System.Int32, 1, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Add$4", WootzJs.Mvc.Mvc.Views.HorizontalPanel.prototype.Add$4, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("child", WootzJs.Mvc.Mvc.Views.Control, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("alignment", WootzJs.Mvc.Mvc.Views.VerticalAlignment, 1, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("spaceBefore", System.Int32, 2, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Mvc.Mvc.Views.HorizontalPanel.prototype.$ctor, $arrayinit([], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.PropertyInfo.prototype.$ctor.$new("Spacing", System.Int32, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Spacing", WootzJs.Mvc.Mvc.Views.HorizontalPanel.prototype.get_Spacing, $arrayinit([], System.Reflection.ParameterInfo), System.Int32, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Spacing", WootzJs.Mvc.Mvc.Views.HorizontalPanel.prototype.set_Spacing, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Int32, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("HorizontalAlignment", WootzJs.Mvc.Mvc.Views.HorizontalAlignment, System.Reflection.MethodInfo.prototype.$ctor.$new("get_HorizontalAlignment", WootzJs.Mvc.Mvc.Views.HorizontalPanel.prototype.get_HorizontalAlignment, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.HorizontalAlignment, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_HorizontalAlignment", WootzJs.Mvc.Mvc.Views.HorizontalPanel.prototype.set_HorizontalAlignment, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.HorizontalAlignment, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute))], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {};
    $p.$ctor = function() {
        WootzJs.Mvc.Mvc.Views.Control.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.$Spacing$k__BackingField = 0;
    $p.get_Spacing = function() {return this.$Spacing$k__BackingField;};
    $p.set_Spacing = function(value) {this.$Spacing$k__BackingField = value;};
    $p.row = null;
    $p.firstSpacer = null;
    $p.lastSpacer = null;
    $p.get_HorizontalAlignment = function() {
        if (this.firstSpacer == null && this.lastSpacer == null)
            return WootzJs.Mvc.Mvc.Views.HorizontalAlignment().Fill;
        else
            if (this.firstSpacer != null && this.lastSpacer != null)
                return WootzJs.Mvc.Mvc.Views.HorizontalAlignment().Center;
            else
                if (this.firstSpacer != null)
                    return WootzJs.Mvc.Mvc.Views.HorizontalAlignment().Right;
                else
                    if (this.lastSpacer != null)
                        return WootzJs.Mvc.Mvc.Views.HorizontalAlignment().Left;
                    else
                        throw System.InvalidOperationException.prototype.$ctor.$new().InternalInit(new Error());
    };
    $p.set_HorizontalAlignment = function(value) {
        this.EnsureNodeExists();
        if (this.firstSpacer != null) {
            WootzJs.Web.NodeExtensions.Remove(this.firstSpacer);
            this.firstSpacer = null;
        }
        if (this.lastSpacer != null) {
            WootzJs.Web.NodeExtensions.Remove(this.lastSpacer);
            this.lastSpacer = null;
        }
        switch (value) {
            case WootzJs.Mvc.Mvc.Views.HorizontalAlignment().Fill:
                break;
            case WootzJs.Mvc.Mvc.Views.HorizontalAlignment().Center:
                this.firstSpacer = WootzJs.Web.Browser().get_Document().createElement("td");
                this.firstSpacer.style.width = "50%";
                WootzJs.Web.NodeExtensions.Prepend(this.row, this.firstSpacer);
                this.lastSpacer = WootzJs.Web.Browser().get_Document().createElement("td");
                this.lastSpacer.style.width = "50%";
                this.row.appendChild(this.lastSpacer);
                break;
            case WootzJs.Mvc.Mvc.Views.HorizontalAlignment().Left:
                this.lastSpacer = WootzJs.Web.Browser().get_Document().createElement("td");
                this.lastSpacer.style.width = "100%";
                this.row.appendChild(this.lastSpacer);
                break;
            case WootzJs.Mvc.Mvc.Views.HorizontalAlignment().Right:
                this.firstSpacer = WootzJs.Web.Browser().get_Document().createElement("td");
                this.firstSpacer.style.width = "100%";
                WootzJs.Web.NodeExtensions.Prepend(this.row, this.firstSpacer);
                break;
            default:
                throw System.InvalidOperationException.prototype.$ctor.$new().InternalInit(new Error());
        }
    };
    $p.CreateNode = function() {
        var table = WootzJs.Web.Browser().get_Document().createElement("table");
        this.row = WootzJs.Web.Browser().get_Document().createElement("tr");
        table.appendChild(this.row);
        return table;
    };
    $p.Add$1 = function(child) {
        this.Add$4(child, WootzJs.Mvc.Mvc.Views.VerticalAlignment().Fill, this.get_Count() == 0 ? 0 : this.get_Spacing());
    };
    $p.Add$2 = function(child, alignment) {
        this.Add$4(child, alignment, this.get_Count() == 0 ? 0 : this.get_Spacing());
    };
    $p.Add$3 = function(child, spaceBefore) {
        this.Add$4(child, WootzJs.Mvc.Mvc.Views.VerticalAlignment().Fill, (this.get_Count() == 0 ? 0 : this.get_Spacing()) + spaceBefore);
    };
    $p.Add$4 = function(child, alignment, spaceBefore) {
        WootzJs.Mvc.Mvc.Views.Control.prototype.Add.call(this, child);
        var cell = WootzJs.Web.Browser().get_Document().createElement("td");
        var div = WootzJs.Web.Browser().get_Document().createElement("div");
        cell.appendChild(div);
        switch (alignment) {
            case WootzJs.Mvc.Mvc.Views.VerticalAlignment().Fill:
                child.get_Node().style.height = "100%";
                div.style.height = "100%";
                break;
            case WootzJs.Mvc.Mvc.Views.VerticalAlignment().Top:
                cell.style.verticalAlign = "top";
                break;
            case WootzJs.Mvc.Mvc.Views.VerticalAlignment().Middle:
                cell.style.verticalAlign = "middle";
                break;
            case WootzJs.Mvc.Mvc.Views.VerticalAlignment().Bottom:
                cell.style.verticalAlign = "bottom";
                break;
        }
        if (spaceBefore != 0) {
            div.style.marginLeft = $safeToString(spaceBefore) + "px";
        }
        div.appendChild(child.get_Node());
        if (this.lastSpacer != null)
            WootzJs.Web.NodeExtensions.InsertBefore(cell, this.lastSpacer);
        else
            this.row.appendChild(cell);
    };
}).call(null, WootzJs.Mvc.Mvc.Views.HorizontalPanel, WootzJs.Mvc.Mvc.Views.HorizontalPanel.prototype);
$WootzJs$Mvc$AssemblyTypes.push(WootzJs.Mvc.Mvc.Views.HorizontalPanel);
WootzJs.Mvc.Mvc.Views.HtmlControl = $define("WootzJs.Mvc.Mvc.Views.HtmlControl", WootzJs.Mvc.Mvc.Views.Control);
(WootzJs.Mvc.Mvc.Views.HtmlControl.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Mvc$GetAssembly;
    $p.$type = $t;
    $t.$baseType = WootzJs.Mvc.Mvc.Views.Control;
    $p.$typeName = "WootzJs.Mvc.Mvc.Views.HtmlControl";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("HtmlControl", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Mvc.Mvc.Views.HtmlControl", WootzJs.Mvc.Mvc.Views.HtmlControl, WootzJs.Mvc.Mvc.Views.Control, $arrayinit([], System.Type), $arrayinit([], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("Add$1", WootzJs.Mvc.Mvc.Views.HtmlControl.prototype.Add$1, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("child", WootzJs.Mvc.Mvc.Views.Control, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Remove$1", WootzJs.Mvc.Mvc.Views.HtmlControl.prototype.Remove$1, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("child", WootzJs.Mvc.Mvc.Views.Control, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Mvc.Mvc.Views.HtmlControl.prototype.$ctor, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("node", Element, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {};
    $p.$ctor = function(node) {
        WootzJs.Mvc.Mvc.Views.Control.prototype.$ctor$1.call(this, node);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function(node) {
        return new $p.$ctor.$type(this, node);
    };
    $p.Add$1 = function(child) {
        WootzJs.Mvc.Mvc.Views.Control.prototype.Add.call(this, child);
        this.get_Node().appendChild(child.get_Node());
    };
    $p.Remove$1 = function(child) {
        WootzJs.Mvc.Mvc.Views.Control.prototype.Remove.call(this, child);
        WootzJs.Web.NodeExtensions.Remove(child.get_Node());
    };
}).call(null, WootzJs.Mvc.Mvc.Views.HtmlControl, WootzJs.Mvc.Mvc.Views.HtmlControl.prototype);
$WootzJs$Mvc$AssemblyTypes.push(WootzJs.Mvc.Mvc.Views.HtmlControl);
WootzJs.Mvc.Mvc.Views.IInlineControl = $define("WootzJs.Mvc.Mvc.Views.IInlineControl", System.Object);
(WootzJs.Mvc.Mvc.Views.IInlineControl.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Mvc$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Mvc.Mvc.Views.IInlineControl";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("IInlineControl", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Mvc.Mvc.Views.IInlineControl", WootzJs.Mvc.Mvc.Views.IInlineControl, null, $arrayinit([], System.Type), $arrayinit([], System.Reflection.FieldInfo), $arrayinit([], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {};
}).call(null, WootzJs.Mvc.Mvc.Views.IInlineControl, WootzJs.Mvc.Mvc.Views.IInlineControl.prototype);
$WootzJs$Mvc$AssemblyTypes.push(WootzJs.Mvc.Mvc.Views.IInlineControl);
WootzJs.Mvc.Mvc.Views.Image = $define("WootzJs.Mvc.Mvc.Views.Image", WootzJs.Mvc.Mvc.Views.Control);
(WootzJs.Mvc.Mvc.Views.Image.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Mvc$GetAssembly;
    $p.$type = $t;
    $t.$baseType = WootzJs.Mvc.Mvc.Views.Control;
    $p.$typeName = "WootzJs.Mvc.Mvc.Views.Image";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("Image", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Mvc.Mvc.Views.Image", WootzJs.Mvc.Mvc.Views.Image, WootzJs.Mvc.Mvc.Views.Control, $arrayinit([WootzJs.Mvc.Mvc.Views.IInlineControl], System.Type), $arrayinit([], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("get_Source", WootzJs.Mvc.Mvc.Views.Image.prototype.get_Source, $arrayinit([], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Source", WootzJs.Mvc.Mvc.Views.Image.prototype.set_Source, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", String, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("CreateNode", WootzJs.Mvc.Mvc.Views.Image.prototype.CreateNode, $arrayinit([], System.Reflection.ParameterInfo), Element, System.Reflection.MethodAttributes().Family, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Mvc.Mvc.Views.Image.prototype.$ctor, $arrayinit([], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor$1", WootzJs.Mvc.Mvc.Views.Image.prototype.$ctor$1, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("source", String, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor$2", WootzJs.Mvc.Mvc.Views.Image.prototype.$ctor$2, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("defaultSource", String, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("highlightedSource", String, 1, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor$3", WootzJs.Mvc.Mvc.Views.Image.prototype.$ctor$3, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("defaultSource", String, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("highlightedSource", String, 1, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("highlightColor", WootzJs.Mvc.Mvc.Views.Css.CssColor, 2, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.PropertyInfo.prototype.$ctor.$new("Source", String, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Source", WootzJs.Mvc.Mvc.Views.Image.prototype.get_Source, $arrayinit([], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Source", WootzJs.Mvc.Mvc.Views.Image.prototype.set_Source, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", String, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute))], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {};
    $p.$ctor = function() {
        WootzJs.Mvc.Mvc.Views.Control.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.$ctor$1 = function(source) {
        WootzJs.Mvc.Mvc.Views.Control.prototype.$ctor.call(this);
        this.set_Source(source);
    };
    $p.$ctor$1.$type = $t;
    $p.$ctor$1.$new = function(source) {
        return new $p.$ctor$1.$type(this, source);
    };
    $p.$ctor$2 = function(defaultSource, highlightedSource) {
        WootzJs.Mvc.Mvc.Views.Control.prototype.$ctor.call(this);
        this.set_Source(defaultSource);
        this.MouseEnter($delegate(this, System.Action, function() {
            return this.set_Source(highlightedSource);
        }));
        this.MouseLeave($delegate(this, System.Action, function() {
            return this.set_Source(defaultSource);
        }));
    };
    $p.$ctor$2.$type = $t;
    $p.$ctor$2.$new = function(defaultSource, highlightedSource) {
        return new $p.$ctor$2.$type(this, defaultSource, highlightedSource);
    };
    $p.$ctor$3 = function(defaultSource, highlightedSource, highlightColor) {
        WootzJs.Mvc.Mvc.Views.Control.prototype.$ctor.call(this);
        this.set_Source(defaultSource);
        this.MouseEnter($delegate(this, System.Action, function() {
            this.set_Source(highlightedSource);
            this.get_Style().set_BackgroundColor(highlightColor);
        }));
        this.MouseLeave($delegate(this, System.Action, function() {
            this.set_Source(defaultSource);
            this.get_Style().set_BackgroundColor(WootzJs.Mvc.Mvc.Views.Css.CssColor().Inherit);
        }));
    };
    $p.$ctor$3.$type = $t;
    $p.$ctor$3.$new = function(defaultSource, highlightedSource, highlightColor) {
        return new $p.$ctor$3.$type(
            this, 
            defaultSource, 
            highlightedSource, 
            highlightColor
        );
    };
    $p.get_Source = function() {
        return this.get_Node().getAttribute("src");
    };
    $p.set_Source = function(value) {
        this.get_Node().setAttribute("src", value);
    };
    $p.CreateNode = function() {
        var node = WootzJs.Web.Browser().get_Document().createElement("img");
        node.style.display = "block";
        return node;
    };
}).call(null, WootzJs.Mvc.Mvc.Views.Image, WootzJs.Mvc.Mvc.Views.Image.prototype);
$WootzJs$Mvc$AssemblyTypes.push(WootzJs.Mvc.Mvc.Views.Image);
WootzJs.Mvc.Mvc.Views.Layout = $define("WootzJs.Mvc.Mvc.Views.Layout", WootzJs.Mvc.Mvc.Views.View);
(WootzJs.Mvc.Mvc.Views.Layout.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Mvc$GetAssembly;
    $p.$type = $t;
    $t.$baseType = WootzJs.Mvc.Mvc.Views.View;
    $p.$typeName = "WootzJs.Mvc.Mvc.Views.Layout";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("Layout", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Mvc.Mvc.Views.Layout", WootzJs.Mvc.Mvc.Views.Layout, WootzJs.Mvc.Mvc.Views.View, $arrayinit([], System.Type), $arrayinit([], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("AddView", WootzJs.Mvc.Mvc.Views.Layout.prototype.AddView, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("view", WootzJs.Mvc.Mvc.Views.View, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("FindLayout", WootzJs.Mvc.Mvc.Views.Layout.prototype.FindLayout, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("layoutType", System.Type, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Layout, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Mvc.Mvc.Views.Layout.prototype.$ctor, $arrayinit([], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Family, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {};
    $p.$ctor = function() {
        WootzJs.Mvc.Mvc.Views.View.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.AddView = function(view) {};
    $p.FindLayout = function(layoutType) {
        if (layoutType == this.GetType())
            return this;
        else
            return null;
    };
}).call(null, WootzJs.Mvc.Mvc.Views.Layout, WootzJs.Mvc.Mvc.Views.Layout.prototype);
$WootzJs$Mvc$AssemblyTypes.push(WootzJs.Mvc.Mvc.Views.Layout);
WootzJs.Mvc.Mvc.Views.Link = $define("WootzJs.Mvc.Mvc.Views.Link", WootzJs.Mvc.Mvc.Views.Control);
(WootzJs.Mvc.Mvc.Views.Link.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Mvc$GetAssembly;
    $p.$type = $t;
    $t.$baseType = WootzJs.Mvc.Mvc.Views.Control;
    $p.$typeName = "WootzJs.Mvc.Mvc.Views.Link";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("Link", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Mvc.Mvc.Views.Link", WootzJs.Mvc.Mvc.Views.Link, WootzJs.Mvc.Mvc.Views.Control, $arrayinit([WootzJs.Mvc.Mvc.Views.IInlineControl], System.Type), $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("useTextMode", System.Boolean, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("CreateNode", WootzJs.Mvc.Mvc.Views.Link.prototype.CreateNode, $arrayinit([], System.Reflection.ParameterInfo), Element, System.Reflection.MethodAttributes().Family, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_Text", WootzJs.Mvc.Mvc.Views.Link.prototype.get_Text, $arrayinit([], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Text", WootzJs.Mvc.Mvc.Views.Link.prototype.set_Text, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", String, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Add$1", WootzJs.Mvc.Mvc.Views.Link.prototype.Add$1, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("child", WootzJs.Mvc.Mvc.Views.IInlineControl, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Remove$1", WootzJs.Mvc.Mvc.Views.Link.prototype.Remove$1, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("child", WootzJs.Mvc.Mvc.Views.IInlineControl, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Mvc.Mvc.Views.Link.prototype.$ctor, $arrayinit([], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor$1", WootzJs.Mvc.Mvc.Views.Link.prototype.$ctor$1, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("text", String, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.PropertyInfo.prototype.$ctor.$new("Text", String, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Text", WootzJs.Mvc.Mvc.Views.Link.prototype.get_Text, $arrayinit([], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Text", WootzJs.Mvc.Mvc.Views.Link.prototype.set_Text, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", String, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute))], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {};
    $p.useTextMode = false;
    $p.$ctor = function() {
        WootzJs.Mvc.Mvc.Views.Control.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.$ctor$1 = function(text) {
        WootzJs.Mvc.Mvc.Views.Control.prototype.$ctor.call(this);
        this.set_Text(text);
    };
    $p.$ctor$1.$type = $t;
    $p.$ctor$1.$new = function(text) {
        return new $p.$ctor$1.$type(this, text);
    };
    $p.CreateNode = function() {
        var a = WootzJs.Web.Browser().get_Document().createElement("a");
        a.setAttribute("href", "javascript:void(0);");
        return a;
    };
    $p.get_Text = function() {
        return this.get_Node().innerHTML;
    };
    $p.set_Text = function(value) {
        this.get_Node().innerHTML = value;
        this.useTextMode = true;
    };
    $p.Add$1 = function(child) {
        if (this.useTextMode)
            this.get_Node().innerHTML = "";
        this.Add($cast(WootzJs.Mvc.Mvc.Views.Control, child));
        this.useTextMode = false;
    };
    $p.Remove$1 = function(child) {
        this.Remove($cast(WootzJs.Mvc.Mvc.Views.Control, child));
    };
}).call(null, WootzJs.Mvc.Mvc.Views.Link, WootzJs.Mvc.Mvc.Views.Link.prototype);
$WootzJs$Mvc$AssemblyTypes.push(WootzJs.Mvc.Mvc.Views.Link);
WootzJs.Mvc.Mvc.Views.LinkPanel = $define("WootzJs.Mvc.Mvc.Views.LinkPanel", WootzJs.Mvc.Mvc.Views.Control);
(WootzJs.Mvc.Mvc.Views.LinkPanel.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Mvc$GetAssembly;
    $p.$type = $t;
    $t.$baseType = WootzJs.Mvc.Mvc.Views.Control;
    $p.$typeName = "WootzJs.Mvc.Mvc.Views.LinkPanel";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("LinkPanel", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Mvc.Mvc.Views.LinkPanel", WootzJs.Mvc.Mvc.Views.LinkPanel, WootzJs.Mvc.Mvc.Views.Control, $arrayinit([], System.Type), $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("useTextMode", System.Boolean, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("CreateNode", WootzJs.Mvc.Mvc.Views.LinkPanel.prototype.CreateNode, $arrayinit([], System.Reflection.ParameterInfo), Element, System.Reflection.MethodAttributes().Family, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_Text", WootzJs.Mvc.Mvc.Views.LinkPanel.prototype.get_Text, $arrayinit([], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Text", WootzJs.Mvc.Mvc.Views.LinkPanel.prototype.set_Text, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", String, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Add$1", WootzJs.Mvc.Mvc.Views.LinkPanel.prototype.Add$1, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("child", WootzJs.Mvc.Mvc.Views.IInlineControl, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Remove$1", WootzJs.Mvc.Mvc.Views.LinkPanel.prototype.Remove$1, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("child", WootzJs.Mvc.Mvc.Views.IInlineControl, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Mvc.Mvc.Views.LinkPanel.prototype.$ctor, $arrayinit([], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor$1", WootzJs.Mvc.Mvc.Views.LinkPanel.prototype.$ctor$1, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("text", String, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.PropertyInfo.prototype.$ctor.$new("Text", String, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Text", WootzJs.Mvc.Mvc.Views.LinkPanel.prototype.get_Text, $arrayinit([], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Text", WootzJs.Mvc.Mvc.Views.LinkPanel.prototype.set_Text, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", String, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute))], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {};
    $p.useTextMode = false;
    $p.$ctor = function() {
        WootzJs.Mvc.Mvc.Views.Control.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.$ctor$1 = function(text) {
        WootzJs.Mvc.Mvc.Views.Control.prototype.$ctor.call(this);
        this.set_Text(text);
    };
    $p.$ctor$1.$type = $t;
    $p.$ctor$1.$new = function(text) {
        return new $p.$ctor$1.$type(this, text);
    };
    $p.CreateNode = function() {
        var a = WootzJs.Web.Browser().get_Document().createElement("a");
        a.setAttribute("href", "javascript:void(0);");
        a.style.display = "block";
        return a;
    };
    $p.get_Text = function() {
        return this.get_Node().nodeValue;
    };
    $p.set_Text = function(value) {
        this.get_Node().innerHTML = value;
        this.useTextMode = true;
    };
    $p.Add$1 = function(child) {
        if (this.useTextMode)
            this.get_Node().innerHTML = "";
        this.Add($cast(WootzJs.Mvc.Mvc.Views.Control, child));
        this.useTextMode = false;
    };
    $p.Remove$1 = function(child) {
        this.Remove($cast(WootzJs.Mvc.Mvc.Views.Control, child));
    };
}).call(null, WootzJs.Mvc.Mvc.Views.LinkPanel, WootzJs.Mvc.Mvc.Views.LinkPanel.prototype);
$WootzJs$Mvc$AssemblyTypes.push(WootzJs.Mvc.Mvc.Views.LinkPanel);
WootzJs.Mvc.Mvc.Views.MouseTrackingEngine = $define("WootzJs.Mvc.Mvc.Views.MouseTrackingEngine", System.Object);
(WootzJs.Mvc.Mvc.Views.MouseTrackingEngine.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Mvc$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Mvc.Mvc.Views.MouseTrackingEngine";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("MouseTrackingEngine", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Mvc.Mvc.Views.MouseTrackingEngine", WootzJs.Mvc.Mvc.Views.MouseTrackingEngine, System.Object, $arrayinit([], System.Type), $arrayinit([], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("Initialize", WootzJs.Mvc.Mvc.Views.MouseTrackingEngine.prototype.Initialize, $arrayinit([], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Assembly, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("OnMouseMove", WootzJs.Mvc.Mvc.Views.MouseTrackingEngine.prototype.OnMouseMove, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("evt", Event, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Private, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("FireMouseEntered", WootzJs.Mvc.Mvc.Views.MouseTrackingEngine.prototype.FireMouseEntered, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("element", Element, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Private, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("FireMouseExited", WootzJs.Mvc.Mvc.Views.MouseTrackingEngine.prototype.FireMouseExited, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("element", Element, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Private, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("OnMouseOut", WootzJs.Mvc.Mvc.Views.MouseTrackingEngine.prototype.OnMouseOut, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("evt", Event, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Private, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Mvc.Mvc.Views.MouseTrackingEngine.prototype.$ctor, $arrayinit([], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {};
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.lastElement = null;
    $p.Initialize = function() {
        WootzJs.Web.Browser().get_Window().addEventListener("mousemove", $delegate(
            this, 
            System.Action$1$(Event), 
            this.OnMouseMove, 
            "OnMouseMove$delegate"
        ));
        WootzJs.Web.Browser().get_Window().addEventListener("mouseout", $delegate(
            this, 
            System.Action$1$(Event), 
            this.OnMouseOut, 
            "OnMouseOut$delegate"
        ));
    };
    $p.OnMouseMove = function(evt) {
        var currentElement = evt.target;
        if (this.lastElement != currentElement) {
            var current = currentElement;
            while (current != null) {
                var hasMouse = current.$hasMouse;
                if (!hasMouse) {
                    this.FireMouseEntered(current);
                }
                else {
                    break;
                }
                current = current.parentElement;
            }
            if (this.lastElement != null && !WootzJs.Web.ElementExtensions.IsDescendentOf(currentElement, this.lastElement)) {
                var last = this.lastElement;
                while (last != null) {
                    if (!last.contains(currentElement))
                        this.FireMouseExited(last);
                    last = last.parentElement;
                }
            }
            this.lastElement = currentElement;
        }
    };
    $p.FireMouseEntered = function(element) {
        element.$hasMouse = true;
        var mouseEnterEvent = WootzJs.Web.DocumentExtensions.CreateCustomEvent(WootzJs.Web.Browser().get_Document(), "mouseentered", null);
        element.dispatchEvent(mouseEnterEvent);
    };
    $p.FireMouseExited = function(element) {
        element.$hasMouse = false;
        var mouseExitedEvent = WootzJs.Web.DocumentExtensions.CreateCustomEvent(WootzJs.Web.Browser().get_Document(), "mouseexited", null);
        element.dispatchEvent(mouseExitedEvent);
    };
    $p.OnMouseOut = function(evt) {
        if (evt.relatedTarget == null) {
            var current = this.lastElement;
            while (current != null) {
                this.FireMouseExited(this.lastElement);
                current = current.parentElement;
            }
        }
    };
}).call(null, WootzJs.Mvc.Mvc.Views.MouseTrackingEngine, WootzJs.Mvc.Mvc.Views.MouseTrackingEngine.prototype);
$WootzJs$Mvc$AssemblyTypes.push(WootzJs.Mvc.Mvc.Views.MouseTrackingEngine);
WootzJs.Mvc.Mvc.Views.SidePanel = $define("WootzJs.Mvc.Mvc.Views.SidePanel", WootzJs.Mvc.Mvc.Views.Control);
(WootzJs.Mvc.Mvc.Views.SidePanel.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Mvc$GetAssembly;
    $p.$type = $t;
    $t.$baseType = WootzJs.Mvc.Mvc.Views.Control;
    $p.$typeName = "WootzJs.Mvc.Mvc.Views.SidePanel";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("SidePanel", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Mvc.Mvc.Views.SidePanel", WootzJs.Mvc.Mvc.Views.SidePanel, WootzJs.Mvc.Mvc.Views.Control, $arrayinit([], System.Type), $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("top", WootzJs.Mvc.Mvc.Views.Control, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("bottom", WootzJs.Mvc.Mvc.Views.Control, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("left", WootzJs.Mvc.Mvc.Views.Control, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("right", WootzJs.Mvc.Mvc.Views.Control, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("center", WootzJs.Mvc.Mvc.Views.Control, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("spacing", System.Int32, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("CreateNode", WootzJs.Mvc.Mvc.Views.SidePanel.prototype.CreateNode, $arrayinit([], System.Reflection.ParameterInfo), Element, System.Reflection.MethodAttributes().Family, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("GetTopRow", WootzJs.Mvc.Mvc.Views.SidePanel.prototype.GetTopRow, $arrayinit([], System.Reflection.ParameterInfo), Element, System.Reflection.MethodAttributes().Private, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("GetMiddleRow", WootzJs.Mvc.Mvc.Views.SidePanel.prototype.GetMiddleRow, $arrayinit([], System.Reflection.ParameterInfo), Element, System.Reflection.MethodAttributes().Private, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("GetBottomRow", WootzJs.Mvc.Mvc.Views.SidePanel.prototype.GetBottomRow, $arrayinit([], System.Reflection.ParameterInfo), Element, System.Reflection.MethodAttributes().Private, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("GetTopCell", WootzJs.Mvc.Mvc.Views.SidePanel.prototype.GetTopCell, $arrayinit([], System.Reflection.ParameterInfo), Element, System.Reflection.MethodAttributes().Private, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("GetBottomCell", WootzJs.Mvc.Mvc.Views.SidePanel.prototype.GetBottomCell, $arrayinit([], System.Reflection.ParameterInfo), Element, System.Reflection.MethodAttributes().Private, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("AdjustColSpan", WootzJs.Mvc.Mvc.Views.SidePanel.prototype.AdjustColSpan, $arrayinit([], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Private, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("GetLeftCell", WootzJs.Mvc.Mvc.Views.SidePanel.prototype.GetLeftCell, $arrayinit([], System.Reflection.ParameterInfo), Element, System.Reflection.MethodAttributes().Private, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("GetCenterCell", WootzJs.Mvc.Mvc.Views.SidePanel.prototype.GetCenterCell, $arrayinit([], System.Reflection.ParameterInfo), Element, System.Reflection.MethodAttributes().Private, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("GetRightCell", WootzJs.Mvc.Mvc.Views.SidePanel.prototype.GetRightCell, $arrayinit([], System.Reflection.ParameterInfo), Element, System.Reflection.MethodAttributes().Private, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("RemoveTopRow", WootzJs.Mvc.Mvc.Views.SidePanel.prototype.RemoveTopRow, $arrayinit([], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Private, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("RemoveMiddleRow", WootzJs.Mvc.Mvc.Views.SidePanel.prototype.RemoveMiddleRow, $arrayinit([], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Private, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("RemoveBottomRow", WootzJs.Mvc.Mvc.Views.SidePanel.prototype.RemoveBottomRow, $arrayinit([], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Private, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("RemoveMiddleRowIfEmpty", WootzJs.Mvc.Mvc.Views.SidePanel.prototype.RemoveMiddleRowIfEmpty, $arrayinit([], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Private, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("RemoveTopCell", WootzJs.Mvc.Mvc.Views.SidePanel.prototype.RemoveTopCell, $arrayinit([], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Private, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("RemoveBottomCell", WootzJs.Mvc.Mvc.Views.SidePanel.prototype.RemoveBottomCell, $arrayinit([], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Private, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("RemoveLeftCell", WootzJs.Mvc.Mvc.Views.SidePanel.prototype.RemoveLeftCell, $arrayinit([], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Private, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("RemoveCenterCell", WootzJs.Mvc.Mvc.Views.SidePanel.prototype.RemoveCenterCell, $arrayinit([], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Private, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("RemoveRightCell", WootzJs.Mvc.Mvc.Views.SidePanel.prototype.RemoveRightCell, $arrayinit([], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Private, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_Top", WootzJs.Mvc.Mvc.Views.SidePanel.prototype.get_Top, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Control, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Top", WootzJs.Mvc.Mvc.Views.SidePanel.prototype.set_Top, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Control, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_Bottom", WootzJs.Mvc.Mvc.Views.SidePanel.prototype.get_Bottom, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Control, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Bottom", WootzJs.Mvc.Mvc.Views.SidePanel.prototype.set_Bottom, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Control, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_Left", WootzJs.Mvc.Mvc.Views.SidePanel.prototype.get_Left, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Control, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Left", WootzJs.Mvc.Mvc.Views.SidePanel.prototype.set_Left, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Control, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_Center", WootzJs.Mvc.Mvc.Views.SidePanel.prototype.get_Center, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Control, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Center", WootzJs.Mvc.Mvc.Views.SidePanel.prototype.set_Center, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Control, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_Right", WootzJs.Mvc.Mvc.Views.SidePanel.prototype.get_Right, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Control, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Right", WootzJs.Mvc.Mvc.Views.SidePanel.prototype.set_Right, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Control, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_Spacing", WootzJs.Mvc.Mvc.Views.SidePanel.prototype.get_Spacing, $arrayinit([], System.Reflection.ParameterInfo), System.Int32, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Spacing", WootzJs.Mvc.Mvc.Views.SidePanel.prototype.set_Spacing, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Int32, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Mvc.Mvc.Views.SidePanel.prototype.$ctor, $arrayinit([], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.PropertyInfo.prototype.$ctor.$new("Top", WootzJs.Mvc.Mvc.Views.Control, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Top", WootzJs.Mvc.Mvc.Views.SidePanel.prototype.get_Top, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Control, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Top", WootzJs.Mvc.Mvc.Views.SidePanel.prototype.set_Top, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Control, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("Bottom", WootzJs.Mvc.Mvc.Views.Control, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Bottom", WootzJs.Mvc.Mvc.Views.SidePanel.prototype.get_Bottom, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Control, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Bottom", WootzJs.Mvc.Mvc.Views.SidePanel.prototype.set_Bottom, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Control, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("Left", WootzJs.Mvc.Mvc.Views.Control, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Left", WootzJs.Mvc.Mvc.Views.SidePanel.prototype.get_Left, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Control, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Left", WootzJs.Mvc.Mvc.Views.SidePanel.prototype.set_Left, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Control, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("Center", WootzJs.Mvc.Mvc.Views.Control, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Center", WootzJs.Mvc.Mvc.Views.SidePanel.prototype.get_Center, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Control, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Center", WootzJs.Mvc.Mvc.Views.SidePanel.prototype.set_Center, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Control, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("Right", WootzJs.Mvc.Mvc.Views.Control, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Right", WootzJs.Mvc.Mvc.Views.SidePanel.prototype.get_Right, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.Control, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Right", WootzJs.Mvc.Mvc.Views.SidePanel.prototype.set_Right, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.Control, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("Spacing", System.Int32, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Spacing", WootzJs.Mvc.Mvc.Views.SidePanel.prototype.get_Spacing, $arrayinit([], System.Reflection.ParameterInfo), System.Int32, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Spacing", WootzJs.Mvc.Mvc.Views.SidePanel.prototype.set_Spacing, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Int32, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute))], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {};
    $p.$ctor = function() {
        WootzJs.Mvc.Mvc.Views.Control.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.top = null;
    $p.bottom = null;
    $p.left = null;
    $p.right = null;
    $p.center = null;
    $p.spacing = 0;
    $p.topRow = null;
    $p.bottomRow = null;
    $p.middleRow = null;
    $p.topCell = null;
    $p.bottomCell = null;
    $p.leftCell = null;
    $p.rightCell = null;
    $p.centerCell = null;
    $p.topCellContent = null;
    $p.bottomCellContent = null;
    $p.leftCellContent = null;
    $p.rightCellContent = null;
    $p.centerCellContent = null;
    $p.CreateNode = function() {
        var table = WootzJs.Web.Browser().get_Document().createElement("table");
        return table;
    };
    $p.GetTopRow = function() {
        if (this.topRow == null) {
            this.topRow = WootzJs.Web.Browser().get_Document().createElement("tr");
            WootzJs.Web.NodeExtensions.Prepend(this.get_Node(), this.topRow);
        }
        return this.topRow;
    };
    $p.GetMiddleRow = function() {
        if (this.middleRow == null) {
            this.middleRow = WootzJs.Web.Browser().get_Document().createElement("tr");
            if (this.topRow != null)
                WootzJs.Web.NodeExtensions.InsertAfter(this.middleRow, this.topRow);
            else
                WootzJs.Web.NodeExtensions.Prepend(this.get_Node(), this.middleRow);
            if (this.get_Spacing() != 0 && this.topRow != null) {
                this.topCellContent.style.paddingBottom = $safeToString(this.get_Spacing()) + "px";
            }
        }
        return this.middleRow;
    };
    $p.GetBottomRow = function() {
        if (this.bottomRow == null) {
            this.bottomRow = WootzJs.Web.Browser().get_Document().createElement("tr");
            this.get_Node().appendChild(this.bottomRow);
        }
        return this.bottomRow;
    };
    $p.GetTopCell = function() {
        if (this.topCell == null) {
            this.topCell = WootzJs.Web.Browser().get_Document().createElement("td");
            this.topCell.setAttribute("colspan", "3");
            this.GetTopRow().appendChild(this.topCell);
            this.topCellContent = WootzJs.Web.Browser().get_Document().createElement("div");
            this.topCellContent.style.width = "100%";
            this.topCellContent.style.height = "100%";
            this.topCell.appendChild(this.topCellContent);
            if (this.get_Spacing() != 0 && (this.middleRow != null || this.bottomRow != null)) {
                this.topCellContent.style.paddingBottom = $safeToString(this.get_Spacing()) + "px";
            }
        }
        return this.topCellContent;
    };
    $p.GetBottomCell = function() {
        if (this.bottomCell == null) {
            this.bottomCell = WootzJs.Web.Browser().get_Document().createElement("td");
            this.bottomCell.setAttribute("colspan", "3");
            this.GetBottomRow().appendChild(this.bottomCell);
            this.bottomCellContent = WootzJs.Web.Browser().get_Document().createElement("div");
            this.bottomCellContent.style.width = "100%";
            this.bottomCellContent.style.height = "100%";
            this.bottomCell.appendChild(this.bottomCellContent);
            if (this.get_Spacing() != 0 && (this.middleRow != null)) {
                this.bottomCellContent.style.paddingTop = $safeToString(this.get_Spacing()) + "px";
            }
        }
        return this.bottomCellContent;
    };
    $p.AdjustColSpan = function() {
        if (this.leftCell != null)
            this.leftCell.setAttribute("colspan", this.center == null && this.right == null ? "3" : "1");
        if (this.centerCell != null)
            this.centerCell.setAttribute("colspan", this.left != null && this.right != null ? "1" : this.left != null || this.right != null ? "2" : "3");
        if (this.rightCell != null)
            this.rightCell.setAttribute("colspan", this.center == null && this.left == null ? "3" : "1");
    };
    $p.GetLeftCell = function() {
        if (this.leftCell == null) {
            this.leftCell = WootzJs.Web.Browser().get_Document().createElement("td");
            this.leftCell.style.height = "100%";
            this.AdjustColSpan();
            WootzJs.Web.NodeExtensions.Prepend(this.GetMiddleRow(), this.leftCell);
            this.leftCellContent = WootzJs.Web.Browser().get_Document().createElement("div");
            this.leftCellContent.style.width = "100%";
            this.leftCellContent.style.height = "100%";
            this.leftCell.appendChild(this.leftCellContent);
            if (this.get_Spacing() != 0 && (this.centerCell != null || this.rightCell != null)) {
                this.leftCellContent.style.paddingLeft = $safeToString(this.get_Spacing()) + "px";
            }
        }
        return this.leftCellContent;
    };
    $p.GetCenterCell = function() {
        if (this.centerCell == null) {
            this.centerCell = WootzJs.Web.Browser().get_Document().createElement("td");
            this.centerCell.style.height = "100%";
            this.centerCell.style.width = "100%";
            this.AdjustColSpan();
            if (this.leftCell != null)
                WootzJs.Web.NodeExtensions.InsertAfter(this.centerCell, this.leftCell);
            else
                WootzJs.Web.NodeExtensions.Prepend(this.GetMiddleRow(), this.centerCell);
            this.centerCellContent = WootzJs.Web.Browser().get_Document().createElement("div");
            this.centerCellContent.style.width = "100%";
            this.centerCellContent.style.height = "100%";
            this.centerCell.appendChild(this.centerCellContent);
        }
        return this.centerCellContent;
    };
    $p.GetRightCell = function() {
        if (this.rightCell == null) {
            this.rightCell = WootzJs.Web.Browser().get_Document().createElement("td");
            this.rightCell.style.height = "100%";
            this.AdjustColSpan();
            this.GetMiddleRow().appendChild(this.rightCell);
            this.rightCellContent = WootzJs.Web.Browser().get_Document().createElement("div");
            this.rightCellContent.style.width = "100%";
            this.rightCellContent.style.height = "100%";
            this.rightCell.appendChild(this.rightCellContent);
            if (this.get_Spacing() != 0 && this.middleRow != null) {
                this.rightCellContent.style.paddingLeft = $safeToString(this.get_Spacing()) + "px";
            }
        }
        return this.rightCellContent;
    };
    $p.RemoveTopRow = function() {
        if (this.topRow != null)
            WootzJs.Web.NodeExtensions.Remove(this.topRow);
        this.topRow = null;
    };
    $p.RemoveMiddleRow = function() {
        if (this.middleRow != null) {
            WootzJs.Web.NodeExtensions.Remove(this.middleRow);
            if (this.topCell != null && this.bottom == null)
                this.topCell.style.paddingBottom = "";
        }
        this.middleRow = null;
    };
    $p.RemoveBottomRow = function() {
        if (this.bottomRow != null)
            WootzJs.Web.NodeExtensions.Remove(this.bottomRow);
        this.bottomRow = null;
    };
    $p.RemoveMiddleRowIfEmpty = function() {
        if (this.leftCell == null && this.centerCell == null && this.rightCell == null)
            this.RemoveMiddleRow();
    };
    $p.RemoveTopCell = function() {
        if (this.topCell != null)
            WootzJs.Web.NodeExtensions.Remove(this.topCell);
        this.topCell = null;
        this.topCellContent = null;
        this.RemoveTopRow();
    };
    $p.RemoveBottomCell = function() {
        if (this.bottomCell != null)
            WootzJs.Web.NodeExtensions.Remove(this.bottomCell);
        this.bottomCell = null;
        this.bottomCellContent = null;
        this.RemoveBottomRow();
    };
    $p.RemoveLeftCell = function() {
        if (this.leftCell != null)
            WootzJs.Web.NodeExtensions.Remove(this.leftCell);
        this.leftCell = null;
        this.leftCellContent = null;
        this.RemoveMiddleRowIfEmpty();
    };
    $p.RemoveCenterCell = function() {
        if (this.centerCell != null) {
            WootzJs.Web.NodeExtensions.Remove(this.centerCell);
            if (this.leftCell != null && this.right == null)
                this.leftCell.style.paddingRight = "";
        }
        this.centerCell = null;
        this.centerCellContent = null;
        this.RemoveMiddleRowIfEmpty();
    };
    $p.RemoveRightCell = function() {
        if (this.rightCell != null)
            WootzJs.Web.NodeExtensions.Remove(this.rightCell);
        this.rightCell = null;
        this.rightCellContent = null;
        this.RemoveMiddleRowIfEmpty();
    };
    $p.get_Top = function() {
        return this.top;
    };
    $p.set_Top = function(value) {
        if (this.top != null) {
            this.Remove(this.top);
            this.RemoveTopCell();
        }
        this.top = value;
        if (this.top != null) {
            this.Add(this.top);
            this.GetTopCell().appendChild(value.get_Node());
        }
    };
    $p.get_Bottom = function() {
        return this.bottom;
    };
    $p.set_Bottom = function(value) {
        if (this.bottom != null) {
            this.Remove(this.bottom);
            this.RemoveBottomCell();
        }
        this.bottom = value;
        if (this.bottom != null) {
            this.Add(this.bottom);
            this.GetBottomCell().appendChild(value.get_Node());
        }
    };
    $p.get_Left = function() {
        return this.left;
    };
    $p.set_Left = function(value) {
        if (this.left != null) {
            this.Remove(this.left);
            this.RemoveLeftCell();
        }
        this.left = value;
        if (this.left != null) {
            this.Add(this.left);
            this.GetLeftCell().appendChild(value.get_Node());
        }
    };
    $p.get_Center = function() {
        return this.center;
    };
    $p.set_Center = function(value) {
        if (this.center != null) {
            this.Remove(this.center);
            this.RemoveCenterCell();
        }
        this.center = value;
        if (this.center != null) {
            this.Add(this.center);
            this.GetCenterCell().appendChild(value.get_Node());
        }
    };
    $p.get_Right = function() {
        return this.right;
    };
    $p.set_Right = function(value) {
        if (this.right != null) {
            this.Remove(this.right);
            this.RemoveRightCell();
        }
        this.right = value;
        if (this.right != null) {
            this.Add(this.right);
            this.GetRightCell().appendChild(value.get_Node());
        }
    };
    $p.get_Spacing = function() {
        return this.spacing;
    };
    $p.set_Spacing = function(value) {
        this.spacing = value;
        if (this.get_Top() != null && (this.get_Left() != null || this.get_Center() != null || this.get_Right() != null || this.get_Bottom() != null)) {
            this.GetTopCell().style.paddingBottom = $safeToString(value) + "px";
        }
        if (this.get_Left() != null && (this.get_Center() != null || this.get_Right() != null)) {
            this.GetLeftCell().style.paddingRight = $safeToString(value) + "px";
        }
        if (this.get_Right() != null && this.get_Center() != null) {
            this.GetRightCell().style.paddingLeft = $safeToString(value) + "px";
        }
        if (this.get_Bottom() != null && (this.get_Left() != null || this.get_Center() != null || this.get_Right() != null)) {
            this.GetBottomCell().style.paddingTop = $safeToString(value) + "px";
        }
    };
}).call(null, WootzJs.Mvc.Mvc.Views.SidePanel, WootzJs.Mvc.Mvc.Views.SidePanel.prototype);
$WootzJs$Mvc$AssemblyTypes.push(WootzJs.Mvc.Mvc.Views.SidePanel);
WootzJs.Mvc.Mvc.Views.TableConstraint = $define("WootzJs.Mvc.Mvc.Views.TableConstraint", System.Object);
(WootzJs.Mvc.Mvc.Views.TableConstraint.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Mvc$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Mvc.Mvc.Views.TableConstraint";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("TableConstraint", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Mvc.Mvc.Views.TableConstraint", WootzJs.Mvc.Mvc.Views.TableConstraint, System.Object, $arrayinit([], System.Type), $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("$HorizontalAlignment$k__BackingField", WootzJs.Mvc.Mvc.Views.HorizontalAlignment, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("$VerticalAlignment$k__BackingField", WootzJs.Mvc.Mvc.Views.VerticalAlignment, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("$ColumnSpan$k__BackingField", System.Int32, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("$RowSpan$k__BackingField", System.Int32, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("get_HorizontalAlignment", WootzJs.Mvc.Mvc.Views.TableConstraint.prototype.get_HorizontalAlignment, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.HorizontalAlignment, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_HorizontalAlignment", WootzJs.Mvc.Mvc.Views.TableConstraint.prototype.set_HorizontalAlignment, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.HorizontalAlignment, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Private, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_VerticalAlignment", WootzJs.Mvc.Mvc.Views.TableConstraint.prototype.get_VerticalAlignment, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.VerticalAlignment, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_VerticalAlignment", WootzJs.Mvc.Mvc.Views.TableConstraint.prototype.set_VerticalAlignment, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.VerticalAlignment, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Private, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_ColumnSpan", WootzJs.Mvc.Mvc.Views.TableConstraint.prototype.get_ColumnSpan, $arrayinit([], System.Reflection.ParameterInfo), System.Int32, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_ColumnSpan", WootzJs.Mvc.Mvc.Views.TableConstraint.prototype.set_ColumnSpan, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Int32, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Private, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_RowSpan", WootzJs.Mvc.Mvc.Views.TableConstraint.prototype.get_RowSpan, $arrayinit([], System.Reflection.ParameterInfo), System.Int32, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_RowSpan", WootzJs.Mvc.Mvc.Views.TableConstraint.prototype.set_RowSpan, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Int32, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Private, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Alignment", WootzJs.Mvc.Mvc.Views.TableConstraint.prototype.Alignment, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("alignment", WootzJs.Mvc.Mvc.Views.HorizontalAlignment, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.TableConstraint, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Alignment$1", WootzJs.Mvc.Mvc.Views.TableConstraint.prototype.Alignment$1, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("alignment", WootzJs.Mvc.Mvc.Views.VerticalAlignment, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.TableConstraint, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("SpanCols", WootzJs.Mvc.Mvc.Views.TableConstraint.prototype.SpanCols, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("span", System.Int32, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.TableConstraint, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("SpanRows", WootzJs.Mvc.Mvc.Views.TableConstraint.prototype.SpanRows, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("span", System.Int32, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.TableConstraint, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Centered", WootzJs.Mvc.Mvc.Views.TableConstraint.prototype.Centered, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.TableConstraint, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Left", WootzJs.Mvc.Mvc.Views.TableConstraint.prototype.Left, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.TableConstraint, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Right", WootzJs.Mvc.Mvc.Views.TableConstraint.prototype.Right, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.TableConstraint, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Mvc.Mvc.Views.TableConstraint.prototype.$ctor, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("horizontalAlignment", WootzJs.Mvc.Mvc.Views.HorizontalAlignment, 0, System.Reflection.ParameterAttributes().HasDefault, 3, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("verticalAlignment", WootzJs.Mvc.Mvc.Views.VerticalAlignment, 1, System.Reflection.ParameterAttributes().HasDefault, 3, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("columnSpan", System.Int32, 2, System.Reflection.ParameterAttributes().HasDefault, 1, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("rowSpan", System.Int32, 3, System.Reflection.ParameterAttributes().HasDefault, 1, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.PropertyInfo.prototype.$ctor.$new("HorizontalAlignment", WootzJs.Mvc.Mvc.Views.HorizontalAlignment, System.Reflection.MethodInfo.prototype.$ctor.$new("get_HorizontalAlignment", WootzJs.Mvc.Mvc.Views.TableConstraint.prototype.get_HorizontalAlignment, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.HorizontalAlignment, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_HorizontalAlignment", WootzJs.Mvc.Mvc.Views.TableConstraint.prototype.set_HorizontalAlignment, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.HorizontalAlignment, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Private, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("VerticalAlignment", WootzJs.Mvc.Mvc.Views.VerticalAlignment, System.Reflection.MethodInfo.prototype.$ctor.$new("get_VerticalAlignment", WootzJs.Mvc.Mvc.Views.TableConstraint.prototype.get_VerticalAlignment, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.VerticalAlignment, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_VerticalAlignment", WootzJs.Mvc.Mvc.Views.TableConstraint.prototype.set_VerticalAlignment, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.VerticalAlignment, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Private, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("ColumnSpan", System.Int32, System.Reflection.MethodInfo.prototype.$ctor.$new("get_ColumnSpan", WootzJs.Mvc.Mvc.Views.TableConstraint.prototype.get_ColumnSpan, $arrayinit([], System.Reflection.ParameterInfo), System.Int32, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_ColumnSpan", WootzJs.Mvc.Mvc.Views.TableConstraint.prototype.set_ColumnSpan, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Int32, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Private, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("RowSpan", System.Int32, System.Reflection.MethodInfo.prototype.$ctor.$new("get_RowSpan", WootzJs.Mvc.Mvc.Views.TableConstraint.prototype.get_RowSpan, $arrayinit([], System.Reflection.ParameterInfo), System.Int32, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_RowSpan", WootzJs.Mvc.Mvc.Views.TableConstraint.prototype.set_RowSpan, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Int32, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Private, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute))], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {};
    $p.$HorizontalAlignment$k__BackingField = 0;
    $p.get_HorizontalAlignment = function() {return this.$HorizontalAlignment$k__BackingField;};
    $p.set_HorizontalAlignment = function(value) {this.$HorizontalAlignment$k__BackingField = value;};
    $p.$VerticalAlignment$k__BackingField = 0;
    $p.get_VerticalAlignment = function() {return this.$VerticalAlignment$k__BackingField;};
    $p.set_VerticalAlignment = function(value) {this.$VerticalAlignment$k__BackingField = value;};
    $p.$ColumnSpan$k__BackingField = 0;
    $p.get_ColumnSpan = function() {return this.$ColumnSpan$k__BackingField;};
    $p.set_ColumnSpan = function(value) {this.$ColumnSpan$k__BackingField = value;};
    $p.$RowSpan$k__BackingField = 0;
    $p.get_RowSpan = function() {return this.$RowSpan$k__BackingField;};
    $p.set_RowSpan = function(value) {this.$RowSpan$k__BackingField = value;};
    $p.$ctor = function(horizontalAlignment, verticalAlignment, columnSpan, rowSpan) {
        System.Object.prototype.$ctor.call(this);
        this.set_HorizontalAlignment(horizontalAlignment);
        this.set_VerticalAlignment(verticalAlignment);
        this.set_ColumnSpan(columnSpan);
        this.set_RowSpan(rowSpan);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function(horizontalAlignment, verticalAlignment, columnSpan, rowSpan) {
        return new $p.$ctor.$type(
            this, 
            horizontalAlignment, 
            verticalAlignment, 
            columnSpan, 
            rowSpan
        );
    };
    $t.Alignment = function(alignment) {
        return WootzJs.Mvc.Mvc.Views.TableConstraint.prototype.$ctor.$new(
            alignment, 
            3, 
            1, 
            1
        );
    };
    $t.Alignment$1 = function(alignment) {
        return WootzJs.Mvc.Mvc.Views.TableConstraint.prototype.$ctor.$new(
            alignment, 
            3, 
            1, 
            1
        );
    };
    $t.SpanCols = function(span) {
        return WootzJs.Mvc.Mvc.Views.TableConstraint.prototype.$ctor.$new(
            span, 
            3, 
            1, 
            1
        );
    };
    $t.SpanRows = function(span) {
        return WootzJs.Mvc.Mvc.Views.TableConstraint.prototype.$ctor.$new(
            span, 
            3, 
            1, 
            1
        );
    };
    $t.Centered = function() {
        return WootzJs.Mvc.Mvc.Views.TableConstraint.prototype.$ctor.$new(
            WootzJs.Mvc.Mvc.Views.HorizontalAlignment().Center, 
            WootzJs.Mvc.Mvc.Views.VerticalAlignment().Middle, 
            1, 
            1
        );
    };
    $t.Left = function() {
        return WootzJs.Mvc.Mvc.Views.TableConstraint.prototype.$ctor.$new(
            WootzJs.Mvc.Mvc.Views.HorizontalAlignment().Left, 
            WootzJs.Mvc.Mvc.Views.VerticalAlignment().Middle, 
            1, 
            1
        );
    };
    $t.Right = function() {
        return WootzJs.Mvc.Mvc.Views.TableConstraint.prototype.$ctor.$new(
            WootzJs.Mvc.Mvc.Views.HorizontalAlignment().Right, 
            WootzJs.Mvc.Mvc.Views.VerticalAlignment().Middle, 
            1, 
            1
        );
    };
}).call(null, WootzJs.Mvc.Mvc.Views.TableConstraint, WootzJs.Mvc.Mvc.Views.TableConstraint.prototype);
$WootzJs$Mvc$AssemblyTypes.push(WootzJs.Mvc.Mvc.Views.TableConstraint);
WootzJs.Mvc.Mvc.Views.TableWidth = $define("WootzJs.Mvc.Mvc.Views.TableWidth", System.Object);
(WootzJs.Mvc.Mvc.Views.TableWidth.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Mvc$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Mvc.Mvc.Views.TableWidth";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("TableWidth", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Mvc.Mvc.Views.TableWidth", WootzJs.Mvc.Mvc.Views.TableWidth, System.Object, $arrayinit([], System.Type), $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("$Style$k__BackingField", WootzJs.Mvc.Mvc.Views.TableWidthStyle, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("$Value$k__BackingField", System.Int32, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("get_Style", WootzJs.Mvc.Mvc.Views.TableWidth.prototype.get_Style, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.TableWidthStyle, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Style", WootzJs.Mvc.Mvc.Views.TableWidth.prototype.set_Style, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.TableWidthStyle, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Private, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_Value", WootzJs.Mvc.Mvc.Views.TableWidth.prototype.get_Value, $arrayinit([], System.Reflection.ParameterInfo), System.Int32, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Value", WootzJs.Mvc.Mvc.Views.TableWidth.prototype.set_Value, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Int32, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Private, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Percent", WootzJs.Mvc.Mvc.Views.TableWidth.prototype.Percent, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("percent", System.Int32, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.TableWidth, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Exact", WootzJs.Mvc.Mvc.Views.TableWidth.prototype.Exact, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("pixels", System.Int32, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.TableWidth, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Weight", WootzJs.Mvc.Mvc.Views.TableWidth.prototype.Weight, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("weight", System.Int32, 0, System.Reflection.ParameterAttributes().HasDefault, 1, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.TableWidth, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Preferred", WootzJs.Mvc.Mvc.Views.TableWidth.prototype.Preferred, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.TableWidth, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("AllPreferred", WootzJs.Mvc.Mvc.Views.TableWidth.prototype.AllPreferred, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("numberOfColumns", System.Int32, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), $array(WootzJs.Mvc.Mvc.Views.TableWidth), System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("AllWeight", WootzJs.Mvc.Mvc.Views.TableWidth.prototype.AllWeight, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("numberOfColumns", System.Int32, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), $array(WootzJs.Mvc.Mvc.Views.TableWidth), System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Mvc.Mvc.Views.TableWidth.prototype.$ctor, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("style", WootzJs.Mvc.Mvc.Views.TableWidthStyle, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Int32, 1, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.PropertyInfo.prototype.$ctor.$new("Style", WootzJs.Mvc.Mvc.Views.TableWidthStyle, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Style", WootzJs.Mvc.Mvc.Views.TableWidth.prototype.get_Style, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Mvc.Mvc.Views.TableWidthStyle, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Style", WootzJs.Mvc.Mvc.Views.TableWidth.prototype.set_Style, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Mvc.Mvc.Views.TableWidthStyle, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Private, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("Value", System.Int32, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Value", WootzJs.Mvc.Mvc.Views.TableWidth.prototype.get_Value, $arrayinit([], System.Reflection.ParameterInfo), System.Int32, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Value", WootzJs.Mvc.Mvc.Views.TableWidth.prototype.set_Value, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Int32, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Private, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute))], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {};
    $p.$Style$k__BackingField = 0;
    $p.get_Style = function() {return this.$Style$k__BackingField;};
    $p.set_Style = function(value) {this.$Style$k__BackingField = value;};
    $p.$Value$k__BackingField = 0;
    $p.get_Value = function() {return this.$Value$k__BackingField;};
    $p.set_Value = function(value) {this.$Value$k__BackingField = value;};
    $p.$ctor = function(style, value) {
        System.Object.prototype.$ctor.call(this);
        this.set_Style(style);
        this.set_Value(value);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function(style, value) {
        return new $p.$ctor.$type(this, style, value);
    };
    $t.Percent = function(percent) {
        return WootzJs.Mvc.Mvc.Views.TableWidth.prototype.$ctor.$new(WootzJs.Mvc.Mvc.Views.TableWidthStyle().Percent, percent);
    };
    $t.Exact = function(pixels) {
        return WootzJs.Mvc.Mvc.Views.TableWidth.prototype.$ctor.$new(WootzJs.Mvc.Mvc.Views.TableWidthStyle().Pixels, pixels);
    };
    $t.Weight = function(weight) {
        return WootzJs.Mvc.Mvc.Views.TableWidth.prototype.$ctor.$new(WootzJs.Mvc.Mvc.Views.TableWidthStyle().Weight, weight);
    };
    $t.Preferred = function() {
        return WootzJs.Mvc.Mvc.Views.TableWidth.prototype.$ctor.$new(WootzJs.Mvc.Mvc.Views.TableWidthStyle().MaxPreferredWidth, 0);
    };
    $t.AllPreferred = function(numberOfColumns) {
        return System.Linq.Enumerable.ToArray(WootzJs.Mvc.Mvc.Views.TableWidth, System.Linq.Enumerable.Repeat(WootzJs.Mvc.Mvc.Views.TableWidth, WootzJs.Mvc.Mvc.Views.TableWidth.Preferred(), numberOfColumns));
    };
    $t.AllWeight = function(numberOfColumns) {
        return System.Linq.Enumerable.ToArray(WootzJs.Mvc.Mvc.Views.TableWidth, System.Linq.Enumerable.Repeat(WootzJs.Mvc.Mvc.Views.TableWidth, WootzJs.Mvc.Mvc.Views.TableWidth.Weight(1), numberOfColumns));
    };
}).call(null, WootzJs.Mvc.Mvc.Views.TableWidth, WootzJs.Mvc.Mvc.Views.TableWidth.prototype);
$WootzJs$Mvc$AssemblyTypes.push(WootzJs.Mvc.Mvc.Views.TableWidth);
WootzJs.Mvc.Mvc.Views.TableWidthStyle = $define("WootzJs.Mvc.Mvc.Views.TableWidthStyle", System.Enum);
(WootzJs.Mvc.Mvc.Views.TableWidthStyle.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Mvc$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Enum;
    $p.$typeName = "WootzJs.Mvc.Mvc.Views.TableWidthStyle";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("TableWidthStyle", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Mvc.Mvc.Views.TableWidthStyle", WootzJs.Mvc.Mvc.Views.TableWidthStyle, System.Enum, $arrayinit([], System.Type), $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("Pixels", WootzJs.Mvc.Mvc.Views.TableWidthStyle, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().Literal, 0, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("Percent", WootzJs.Mvc.Mvc.Views.TableWidthStyle, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().Literal, 1, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("Weight", WootzJs.Mvc.Mvc.Views.TableWidthStyle, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().Literal, 2, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("MaxPreferredWidth", WootzJs.Mvc.Mvc.Views.TableWidthStyle, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().Literal, 3, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Mvc.Mvc.Views.TableWidthStyle.prototype.$ctor, $arrayinit([], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), true);return this.$type;};
    $t.$StaticInitializer = function() {
        $t.Pixels = 0;
        $t.Pixels$ = $p.$ctor.$new("Pixels", WootzJs.Mvc.Mvc.Views.TableWidthStyle().Pixels);
        $t.Percent = WootzJs.Mvc.Mvc.Views.TableWidthStyle().Pixels + 1;
        $t.Percent$ = $p.$ctor.$new("Percent", WootzJs.Mvc.Mvc.Views.TableWidthStyle().Percent);
        $t.Weight = WootzJs.Mvc.Mvc.Views.TableWidthStyle().Percent + 1;
        $t.Weight$ = $p.$ctor.$new("Weight", WootzJs.Mvc.Mvc.Views.TableWidthStyle().Weight);
        $t.MaxPreferredWidth = WootzJs.Mvc.Mvc.Views.TableWidthStyle().Weight + 1;
        $t.MaxPreferredWidth$ = $p.$ctor.$new("MaxPreferredWidth", WootzJs.Mvc.Mvc.Views.TableWidthStyle().MaxPreferredWidth);
    };
    $p.$ctor = function(name, value) {
        System.Enum.prototype.$ctor.call(this, name, value);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function(name, value) {
        return new $p.$ctor.$type(this, name, value);
    };
}).call(null, WootzJs.Mvc.Mvc.Views.TableWidthStyle, WootzJs.Mvc.Mvc.Views.TableWidthStyle.prototype);
$WootzJs$Mvc$AssemblyTypes.push(WootzJs.Mvc.Mvc.Views.TableWidthStyle);
WootzJs.Mvc.Mvc.Views.Text = $define("WootzJs.Mvc.Mvc.Views.Text", WootzJs.Mvc.Mvc.Views.Control);
(WootzJs.Mvc.Mvc.Views.Text.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Mvc$GetAssembly;
    $p.$type = $t;
    $t.$baseType = WootzJs.Mvc.Mvc.Views.Control;
    $p.$typeName = "WootzJs.Mvc.Mvc.Views.Text";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("Text", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Mvc.Mvc.Views.Text", WootzJs.Mvc.Mvc.Views.Text, WootzJs.Mvc.Mvc.Views.Control, $arrayinit([WootzJs.Mvc.Mvc.Views.IInlineControl], System.Type), $arrayinit([], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("get_Value", WootzJs.Mvc.Mvc.Views.Text.prototype.get_Value, $arrayinit([], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Value", WootzJs.Mvc.Mvc.Views.Text.prototype.set_Value, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", String, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Mvc.Mvc.Views.Text.prototype.$ctor, $arrayinit([], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor$1", WootzJs.Mvc.Mvc.Views.Text.prototype.$ctor$1, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", String, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.PropertyInfo.prototype.$ctor.$new("Value", String, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Value", WootzJs.Mvc.Mvc.Views.Text.prototype.get_Value, $arrayinit([], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Value", WootzJs.Mvc.Mvc.Views.Text.prototype.set_Value, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", String, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute))], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {};
    $p.$ctor = function() {
        WootzJs.Mvc.Mvc.Views.Control.prototype.$ctor.call(this);
        this.set_TagName("span");
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.$ctor$1 = function(value) {
        WootzJs.Mvc.Mvc.Views.Control.prototype.$ctor.call(this);
        this.set_Value(value);
    };
    $p.$ctor$1.$type = $t;
    $p.$ctor$1.$new = function(value) {
        return new $p.$ctor$1.$type(this, value);
    };
    $p.get_Value = function() {
        return this.get_Node().innerHTML;
    };
    $p.set_Value = function(value) {
        this.get_Node().innerHTML = value;
    };
}).call(null, WootzJs.Mvc.Mvc.Views.Text, WootzJs.Mvc.Mvc.Views.Text.prototype);
$WootzJs$Mvc$AssemblyTypes.push(WootzJs.Mvc.Mvc.Views.Text);
WootzJs.Mvc.Mvc.Views.TextBox = $define("WootzJs.Mvc.Mvc.Views.TextBox", WootzJs.Mvc.Mvc.Views.Control);
(WootzJs.Mvc.Mvc.Views.TextBox.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Mvc$GetAssembly;
    $p.$type = $t;
    $t.$baseType = WootzJs.Mvc.Mvc.Views.Control;
    $p.$typeName = "WootzJs.Mvc.Mvc.Views.TextBox";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("TextBox", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Mvc.Mvc.Views.TextBox", WootzJs.Mvc.Mvc.Views.TextBox, WootzJs.Mvc.Mvc.Views.Control, $arrayinit([], System.Type), $arrayinit([], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("add_Changed", WootzJs.Mvc.Mvc.Views.TextBox.prototype.add_Changed, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Action, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("remove_Changed", WootzJs.Mvc.Mvc.Views.TextBox.prototype.remove_Changed, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Action, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_Node$1", WootzJs.Mvc.Mvc.Views.TextBox.prototype.get_Node$1, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Web.InputElement, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("CreateNode", WootzJs.Mvc.Mvc.Views.TextBox.prototype.CreateNode, $arrayinit([], System.Reflection.ParameterInfo), Element, System.Reflection.MethodAttributes().Family, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("OnJsChanged", WootzJs.Mvc.Mvc.Views.TextBox.prototype.OnJsChanged, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("evt", Event, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Private, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_Text", WootzJs.Mvc.Mvc.Views.TextBox.prototype.get_Text, $arrayinit([], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Text", WootzJs.Mvc.Mvc.Views.TextBox.prototype.set_Text, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", String, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Mvc.Mvc.Views.TextBox.prototype.$ctor, $arrayinit([], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.PropertyInfo.prototype.$ctor.$new("Node", WootzJs.Web.InputElement, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Node$1", WootzJs.Mvc.Mvc.Views.TextBox.prototype.get_Node$1, $arrayinit([], System.Reflection.ParameterInfo), WootzJs.Web.InputElement, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), null, $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("Text", String, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Text", WootzJs.Mvc.Mvc.Views.TextBox.prototype.get_Text, $arrayinit([], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Text", WootzJs.Mvc.Mvc.Views.TextBox.prototype.set_Text, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", String, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute))], System.Reflection.PropertyInfo), $arrayinit([System.Reflection.EventInfo.prototype.$ctor.$new("Changed", System.Action, System.Reflection.MethodInfo.prototype.$ctor.$new("add_Changed", WootzJs.Mvc.Mvc.Views.TextBox.prototype.add_Changed, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Action, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("remove_Changed", WootzJs.Mvc.Mvc.Views.TextBox.prototype.remove_Changed, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Action, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Attribute))], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {};
    $p.$ctor = function() {
        WootzJs.Mvc.Mvc.Views.Control.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.$Changed$k__BackingField = null;
    $p.add_Changed = function(value) {
        this.$Changed$k__BackingField = System.Delegate.Combine(this.$Changed$k__BackingField, value);
    };
    $p.remove_Changed = function(value) {
        this.$Changed$k__BackingField = System.Delegate.Remove(this.$Changed$k__BackingField, value);
    };
    $p.get_Node$1 = function() {
        return WootzJs.Mvc.Mvc.Views.Control.prototype.get_Node.call(this);
    };
    $p.CreateNode = function() {
        var textBox = WootzJs.Web.Browser().get_Document().createElement("input");
        textBox.setAttribute("type", "text");
        textBox.addEventListener("change", $delegate(
            this, 
            System.Action$1$(Event), 
            this.OnJsChanged, 
            "OnJsChanged$delegate"
        ));
        return textBox;
    };
    $p.OnJsChanged = function(evt) {
        var changed = this.$Changed$k__BackingField;
        if (changed != null)
            changed();
    };
    $p.get_Text = function() {
        this.EnsureNodeExists();
        return this.get_Node$1().value;
    };
    $p.set_Text = function(value) {
        this.EnsureNodeExists();
        this.get_Node$1().value = value;
    };
}).call(null, WootzJs.Mvc.Mvc.Views.TextBox, WootzJs.Mvc.Mvc.Views.TextBox.prototype);
$WootzJs$Mvc$AssemblyTypes.push(WootzJs.Mvc.Mvc.Views.TextBox);
WootzJs.Mvc.Mvc.Views.UrlGenerator = $define("WootzJs.Mvc.Mvc.Views.UrlGenerator", System.Object);
(WootzJs.Mvc.Mvc.Views.UrlGenerator.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Mvc$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Mvc.Mvc.Views.UrlGenerator";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("UrlGenerator", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Mvc.Mvc.Views.UrlGenerator", WootzJs.Mvc.Mvc.Views.UrlGenerator, System.Object, $arrayinit([], System.Type), $arrayinit([], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("GenerateUrl", WootzJs.Mvc.Mvc.Views.UrlGenerator.prototype.GenerateUrl, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("action", System.Linq.Expressions.LambdaExpression, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("GenerateUrlFromTemplate", WootzJs.Mvc.Mvc.Views.UrlGenerator.prototype.GenerateUrlFromTemplate, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("template", String, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Private | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("GenerateUrlFromMethod", WootzJs.Mvc.Mvc.Views.UrlGenerator.prototype.GenerateUrlFromMethod, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("method", System.Reflection.MethodInfo, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Private | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("GetControllerNameFromType", WootzJs.Mvc.Mvc.Views.UrlGenerator.prototype.GetControllerNameFromType, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("type", System.Type, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Private | System.Reflection.MethodAttributes().Static, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Mvc.Mvc.Views.UrlGenerator.prototype.$ctor, $arrayinit([], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {};
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $t.GenerateUrl = function(action) {
        var result = System.Text.StringBuilder.prototype.$ctor.$new();
        var methodCallExpression = $cast(System.Linq.Expressions.MethodCallExpression, action.get_Body());
        var method = methodCallExpression.get_Method();
        var routeAttribute = $cast(WootzJs.Mvc.Mvc.RouteAttribute, System.Linq.Enumerable.SingleOrDefault(System.Object, method.GetCustomAttributes$1(WootzJs.Mvc.Mvc.RouteAttribute.$GetType(), false)));
        if (routeAttribute != null && routeAttribute.get_Value() != null)
            result.Append$2(WootzJs.Mvc.Mvc.Views.UrlGenerator.GenerateUrlFromTemplate(routeAttribute.get_Value()));
        else
            result.Append$2(WootzJs.Mvc.Mvc.Views.UrlGenerator.GenerateUrlFromMethod(method));
        var hasAddedArgument = false;
        var args = WootzJs.Mvc.ExpressionTrees.EvaluatorExtensions.ExtractArguments$1(methodCallExpression);
        {
            var $anon$1iterator = args;
            var $anon$2enumerator = $anon$1iterator.System$Collections$IEnumerable$GetEnumerator();
            while ($anon$2enumerator.System$Collections$IEnumerator$MoveNext()) {
                var argument = $anon$2enumerator.System$Collections$IEnumerator$get_Current();
                if (!hasAddedArgument)
                    result.Append$2("?");
                else
                    result.Append$2("&");
                hasAddedArgument = true;
                result.Append$2(argument.get_Key());
                result.Append$2("=");
                result.Append$1(argument.get_Value());
            }
        }
        return result.ToString();
    };
    $t.GenerateUrlFromTemplate = function(template) {
        return template;
    };
    $t.GenerateUrlFromMethod = function(method) {
        var controller = WootzJs.Mvc.Mvc.Views.UrlGenerator.GetControllerNameFromType(method.get_DeclaringType());
        var action = method.get_Name().toLowerCase();
        return "/" + controller + "/" + action;
    };
    $t.GetControllerNameFromType = function(type) {
        return String.prototype.Substring.call(type.get_Name(), 0, type.get_Name().length - "Controller".length).toLowerCase();
    };
}).call(null, WootzJs.Mvc.Mvc.Views.UrlGenerator, WootzJs.Mvc.Mvc.Views.UrlGenerator.prototype);
$WootzJs$Mvc$AssemblyTypes.push(WootzJs.Mvc.Mvc.Views.UrlGenerator);
WootzJs.Mvc.Mvc.Views.VerticalAlignment = $define("WootzJs.Mvc.Mvc.Views.VerticalAlignment", System.Enum);
(WootzJs.Mvc.Mvc.Views.VerticalAlignment.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Mvc$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Enum;
    $p.$typeName = "WootzJs.Mvc.Mvc.Views.VerticalAlignment";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("VerticalAlignment", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Mvc.Mvc.Views.VerticalAlignment", WootzJs.Mvc.Mvc.Views.VerticalAlignment, System.Enum, $arrayinit([], System.Type), $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("Top", WootzJs.Mvc.Mvc.Views.VerticalAlignment, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().Literal, 0, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("Middle", WootzJs.Mvc.Mvc.Views.VerticalAlignment, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().Literal, 1, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("Bottom", WootzJs.Mvc.Mvc.Views.VerticalAlignment, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().Literal, 2, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("Fill", WootzJs.Mvc.Mvc.Views.VerticalAlignment, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().Literal, 3, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Mvc.Mvc.Views.VerticalAlignment.prototype.$ctor, $arrayinit([], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), true);return this.$type;};
    $t.$StaticInitializer = function() {
        $t.Top = 0;
        $t.Top$ = $p.$ctor.$new("Top", WootzJs.Mvc.Mvc.Views.VerticalAlignment().Top);
        $t.Middle = WootzJs.Mvc.Mvc.Views.VerticalAlignment().Top + 1;
        $t.Middle$ = $p.$ctor.$new("Middle", WootzJs.Mvc.Mvc.Views.VerticalAlignment().Middle);
        $t.Bottom = WootzJs.Mvc.Mvc.Views.VerticalAlignment().Middle + 1;
        $t.Bottom$ = $p.$ctor.$new("Bottom", WootzJs.Mvc.Mvc.Views.VerticalAlignment().Bottom);
        $t.Fill = WootzJs.Mvc.Mvc.Views.VerticalAlignment().Bottom + 1;
        $t.Fill$ = $p.$ctor.$new("Fill", WootzJs.Mvc.Mvc.Views.VerticalAlignment().Fill);
    };
    $p.$ctor = function(name, value) {
        System.Enum.prototype.$ctor.call(this, name, value);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function(name, value) {
        return new $p.$ctor.$type(this, name, value);
    };
}).call(null, WootzJs.Mvc.Mvc.Views.VerticalAlignment, WootzJs.Mvc.Mvc.Views.VerticalAlignment.prototype);
$WootzJs$Mvc$AssemblyTypes.push(WootzJs.Mvc.Mvc.Views.VerticalAlignment);
WootzJs.Mvc.Mvc.Views.VerticalPanel = $define("WootzJs.Mvc.Mvc.Views.VerticalPanel", WootzJs.Mvc.Mvc.Views.Control);
(WootzJs.Mvc.Mvc.Views.VerticalPanel.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Mvc$GetAssembly;
    $p.$type = $t;
    $t.$baseType = WootzJs.Mvc.Mvc.Views.Control;
    $p.$typeName = "WootzJs.Mvc.Mvc.Views.VerticalPanel";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("VerticalPanel", $arrayinit([], System.Attribute));this.$type.Init("WootzJs.Mvc.Mvc.Views.VerticalPanel", WootzJs.Mvc.Mvc.Views.VerticalPanel, WootzJs.Mvc.Mvc.Views.Control, $arrayinit([], System.Type), $arrayinit([], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("CreateNode", WootzJs.Mvc.Mvc.Views.VerticalPanel.prototype.CreateNode, $arrayinit([], System.Reflection.ParameterInfo), Element, System.Reflection.MethodAttributes().Family, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Add$1", WootzJs.Mvc.Mvc.Views.VerticalPanel.prototype.Add$1, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("child", WootzJs.Mvc.Mvc.Views.Control, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Add$2", WootzJs.Mvc.Mvc.Views.VerticalPanel.prototype.Add$2, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("child", WootzJs.Mvc.Mvc.Views.Control, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("alignment", WootzJs.Mvc.Mvc.Views.HorizontalAlignment, 1, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Add$3", WootzJs.Mvc.Mvc.Views.VerticalPanel.prototype.Add$3, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("child", WootzJs.Mvc.Mvc.Views.Control, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("spaceAbove", System.Int32, 1, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Add$4", WootzJs.Mvc.Mvc.Views.VerticalPanel.prototype.Add$4, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("child", WootzJs.Mvc.Mvc.Views.Control, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("alignment", WootzJs.Mvc.Mvc.Views.HorizontalAlignment, 1, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("spaceAbove", System.Int32, 2, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Mvc.Mvc.Views.VerticalPanel.prototype.$ctor, $arrayinit([], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false);return this.$type;};
    $t.$StaticInitializer = function() {};
    $p.$ctor = function() {
        WootzJs.Mvc.Mvc.Views.Control.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.table = null;
    $p.CreateNode = function() {
        this.table = WootzJs.Web.Browser().get_Document().createElement("table");
        this.table.style.width = "100%";
        var div = WootzJs.Web.Browser().get_Document().createElement("div");
        div.appendChild(this.table);
        return div;
    };
    $p.Add$1 = function(child) {
        this.Add$4(child, WootzJs.Mvc.Mvc.Views.HorizontalAlignment().Fill, 0);
    };
    $p.Add$2 = function(child, alignment) {
        this.Add$4(child, alignment, 0);
    };
    $p.Add$3 = function(child, spaceAbove) {
        this.Add$4(child, WootzJs.Mvc.Mvc.Views.HorizontalAlignment().Fill, spaceAbove);
    };
    $p.Add$4 = function(child, alignment, spaceAbove) {
        WootzJs.Mvc.Mvc.Views.Control.prototype.Add.call(this, child);
        var row = WootzJs.Web.Browser().get_Document().createElement("tr");
        var cell = WootzJs.Web.Browser().get_Document().createElement("td");
        var div = WootzJs.Web.Browser().get_Document().createElement("div");
        cell.appendChild(div);
        switch (alignment) {
            case WootzJs.Mvc.Mvc.Views.HorizontalAlignment().Fill:
                child.get_Node().style.width = "100%";
                div.style.width = "100%";
                break;
            case WootzJs.Mvc.Mvc.Views.HorizontalAlignment().Left:
                cell.setAttribute("align", "left");
                break;
            case WootzJs.Mvc.Mvc.Views.HorizontalAlignment().Center:
                cell.setAttribute("align", "center");
                break;
            case WootzJs.Mvc.Mvc.Views.HorizontalAlignment().Right:
                cell.setAttribute("align", "right");
                break;
        }
        if (spaceAbove != 0) {
            div.style.marginTop = $safeToString(spaceAbove) + "px";
        }
        div.appendChild(child.get_Node());
        row.appendChild(cell);
        this.table.appendChild(row);
    };
}).call(null, WootzJs.Mvc.Mvc.Views.VerticalPanel, WootzJs.Mvc.Mvc.Views.VerticalPanel.prototype);
$WootzJs$Mvc$AssemblyTypes.push(WootzJs.Mvc.Mvc.Views.VerticalPanel);
