"use strict";
var $System$ComponentModel$DataAnnotations$Assembly = null;
var $System$ComponentModel$DataAnnotations$AssemblyTypes = [];
window.$System$ComponentModel$DataAnnotations$GetAssembly = function() {
    if ($System$ComponentModel$DataAnnotations$Assembly == null)
        $System$ComponentModel$DataAnnotations$Assembly = System.Reflection.Assembly.prototype.$ctor.$new("System.ComponentModel.DataAnnotations", $System$ComponentModel$DataAnnotations$AssemblyTypes, $arrayinit([
            System.Reflection.AssemblyTitleAttribute.prototype.$ctor.$new("System.ComponentModel.DataAnnotations"), 
            System.Reflection.AssemblyDescriptionAttribute.prototype.$ctor.$new(""), 
            System.Reflection.AssemblyConfigurationAttribute.prototype.$ctor.$new(""), 
            System.Reflection.AssemblyCompanyAttribute.prototype.$ctor.$new(""), 
            System.Reflection.AssemblyProductAttribute.prototype.$ctor.$new("System.ComponentModel.DataAnnotations"), 
            System.Reflection.AssemblyCopyrightAttribute.prototype.$ctor.$new("Copyright ©  2014"), 
            System.Reflection.AssemblyTrademarkAttribute.prototype.$ctor.$new(""), 
            System.Reflection.AssemblyCultureAttribute.prototype.$ctor.$new(""), 
            System.Runtime.InteropServices.ComVisibleAttribute.prototype.$ctor.$new(false), 
            System.Runtime.InteropServices.GuidAttribute.prototype.$ctor.$new("98db0282-b5d2-4ec5-b8f6-289cec54e128"), 
            System.Reflection.AssemblyVersionAttribute.prototype.$ctor.$new("4.0.0.0"), 
            System.Reflection.AssemblyFileVersionAttribute.prototype.$ctor.$new("1.0.0.0")
        ], System.Attribute));
    return $System$ComponentModel$DataAnnotations$Assembly;
};
$assemblies.push(window.$System$ComponentModel$DataAnnotations$GetAssembly);
window.System = window.System || {};
System.ComponentModel = System.ComponentModel || {};
System.ComponentModel.DataAnnotations = System.ComponentModel.DataAnnotations || {};
System.ComponentModel.DataAnnotations.ValidationAttribute = $define("System.ComponentModel.DataAnnotations.ValidationAttribute", System.Attribute);
(System.ComponentModel.DataAnnotations.ValidationAttribute.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$System$ComponentModel$DataAnnotations$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Attribute;
    $p.$typeName = "System.ComponentModel.DataAnnotations.ValidationAttribute";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("ValidationAttribute", $arrayinit([], System.Attribute));this.$type.Init("System.ComponentModel.DataAnnotations.ValidationAttribute", System.Enum.InternalToObject(System.Reflection.TypeAttributes, System.Enum.InternalToObject(System.Reflection.TypeAttributes, System.Reflection.TypeAttributes().Public.GetValue() | System.Reflection.TypeAttributes().Class.GetValue()).GetValue() | System.Reflection.TypeAttributes().Abstract.GetValue()), System.ComponentModel.DataAnnotations.ValidationAttribute, System.Attribute, $arrayinit([], System.Type), null, $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("_errorMessage", String, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("_errorMessageResourceAccessor", System.Func$1, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("_errorMessageResourceName", String, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("_errorMessageResourceType", System.Type, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("isCallingOverload", System.Boolean, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("$CustomErrorMessageSet$k__BackingField", System.Boolean, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("get_ErrorMessageString", System.ComponentModel.DataAnnotations.ValidationAttribute.prototype.get_ErrorMessageString, $arrayinit([], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Family, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_CustomErrorMessageSet", System.ComponentModel.DataAnnotations.ValidationAttribute.prototype.get_CustomErrorMessageSet, $arrayinit([], System.Reflection.ParameterInfo), System.Boolean, System.Reflection.MethodAttributes().Assembly, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_CustomErrorMessageSet", System.ComponentModel.DataAnnotations.ValidationAttribute.prototype.set_CustomErrorMessageSet, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Boolean, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Private, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_RequiresValidationContext", System.ComponentModel.DataAnnotations.ValidationAttribute.prototype.get_RequiresValidationContext, $arrayinit([], System.Reflection.ParameterInfo), System.Boolean, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_ErrorMessage", System.ComponentModel.DataAnnotations.ValidationAttribute.prototype.get_ErrorMessage, $arrayinit([], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_ErrorMessage", System.ComponentModel.DataAnnotations.ValidationAttribute.prototype.set_ErrorMessage, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", String, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_ErrorMessageResourceName", System.ComponentModel.DataAnnotations.ValidationAttribute.prototype.get_ErrorMessageResourceName, $arrayinit([], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_ErrorMessageResourceName", System.ComponentModel.DataAnnotations.ValidationAttribute.prototype.set_ErrorMessageResourceName, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", String, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_ErrorMessageResourceType", System.ComponentModel.DataAnnotations.ValidationAttribute.prototype.get_ErrorMessageResourceType, $arrayinit([], System.Reflection.ParameterInfo), System.Type, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_ErrorMessageResourceType", System.ComponentModel.DataAnnotations.ValidationAttribute.prototype.set_ErrorMessageResourceType, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Type, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("FormatErrorMessage", System.ComponentModel.DataAnnotations.ValidationAttribute.prototype.FormatErrorMessage, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("name", String, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("IsValid", System.ComponentModel.DataAnnotations.ValidationAttribute.prototype.IsValid, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Object, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Boolean, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("IsValid", System.ComponentModel.DataAnnotations.ValidationAttribute.prototype.IsValid$1, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Object, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("validationContext", System.ComponentModel.DataAnnotations.ValidationContext, 1, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.ComponentModel.DataAnnotations.ValidationResult, System.Reflection.MethodAttributes().Family, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("GetValidationResult", System.ComponentModel.DataAnnotations.ValidationAttribute.prototype.GetValidationResult, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Object, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("validationContext", System.ComponentModel.DataAnnotations.ValidationContext, 1, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.ComponentModel.DataAnnotations.ValidationResult, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Validate", System.ComponentModel.DataAnnotations.ValidationAttribute.prototype.Validate$1, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Object, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("name", String, 1, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("Validate", System.ComponentModel.DataAnnotations.ValidationAttribute.prototype.Validate, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Object, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("validationContext", System.ComponentModel.DataAnnotations.ValidationContext, 1, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("SetupResourceAccessor", System.ComponentModel.DataAnnotations.ValidationAttribute.prototype.SetupResourceAccessor, $arrayinit([], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Private, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("SetResourceAccessorByPropertyLookup", System.ComponentModel.DataAnnotations.ValidationAttribute.prototype.SetResourceAccessorByPropertyLookup, $arrayinit([], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Private, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", System.ComponentModel.DataAnnotations.ValidationAttribute.prototype.$ctor, $arrayinit([], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Family, $arrayinit([], System.Attribute)), System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor$2", System.ComponentModel.DataAnnotations.ValidationAttribute.prototype.$ctor$2, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("errorMessage", String, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Family, $arrayinit([], System.Attribute)), System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor$1", System.ComponentModel.DataAnnotations.ValidationAttribute.prototype.$ctor$1, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("errorMessageAccessor", System.Func$1$(String), 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Family, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.PropertyInfo.prototype.$ctor.$new("ErrorMessageString", String, System.Reflection.MethodInfo.prototype.$ctor.$new("get_ErrorMessageString", System.ComponentModel.DataAnnotations.ValidationAttribute.prototype.get_ErrorMessageString, $arrayinit([], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Family, $arrayinit([], System.Attribute)), null, $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("CustomErrorMessageSet", System.Boolean, System.Reflection.MethodInfo.prototype.$ctor.$new("get_CustomErrorMessageSet", System.ComponentModel.DataAnnotations.ValidationAttribute.prototype.get_CustomErrorMessageSet, $arrayinit([], System.Reflection.ParameterInfo), System.Boolean, System.Reflection.MethodAttributes().Assembly, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_CustomErrorMessageSet", System.ComponentModel.DataAnnotations.ValidationAttribute.prototype.set_CustomErrorMessageSet, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Boolean, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Private, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("RequiresValidationContext", System.Boolean, System.Reflection.MethodInfo.prototype.$ctor.$new("get_RequiresValidationContext", System.ComponentModel.DataAnnotations.ValidationAttribute.prototype.get_RequiresValidationContext, $arrayinit([], System.Reflection.ParameterInfo), System.Boolean, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), null, $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("ErrorMessage", String, System.Reflection.MethodInfo.prototype.$ctor.$new("get_ErrorMessage", System.ComponentModel.DataAnnotations.ValidationAttribute.prototype.get_ErrorMessage, $arrayinit([], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_ErrorMessage", System.ComponentModel.DataAnnotations.ValidationAttribute.prototype.set_ErrorMessage, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", String, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("ErrorMessageResourceName", String, System.Reflection.MethodInfo.prototype.$ctor.$new("get_ErrorMessageResourceName", System.ComponentModel.DataAnnotations.ValidationAttribute.prototype.get_ErrorMessageResourceName, $arrayinit([], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_ErrorMessageResourceName", System.ComponentModel.DataAnnotations.ValidationAttribute.prototype.set_ErrorMessageResourceName, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", String, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("ErrorMessageResourceType", System.Type, System.Reflection.MethodInfo.prototype.$ctor.$new("get_ErrorMessageResourceType", System.ComponentModel.DataAnnotations.ValidationAttribute.prototype.get_ErrorMessageResourceType, $arrayinit([], System.Reflection.ParameterInfo), System.Type, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_ErrorMessageResourceType", System.ComponentModel.DataAnnotations.ValidationAttribute.prototype.set_ErrorMessageResourceType, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Type, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute))], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false, false, false, false);return this.$type;};
    $t.$StaticInitializer = function() {
        if ($t.$isStaticInitialized)
            return;
        $t.$isStaticInitialized = true;
        System.Attribute.$StaticInitializer();
    };
    $p.get_ErrorMessageString = function() {
        this.SetupResourceAccessor();
        return this._errorMessageResourceAccessor();
    };
    $p.get_CustomErrorMessageSet = function() {return this.$CustomErrorMessageSet$k__BackingField;};
    $p.set_CustomErrorMessageSet = function(value) {this.$CustomErrorMessageSet$k__BackingField = value;return value;};
    $p.get_RequiresValidationContext = function() {
        return false;
    };
    $p.get_ErrorMessage = function() {
        return this._errorMessage;
    };
    $p.set_ErrorMessage = function(value) {
        this._errorMessage = value;
        this._errorMessageResourceAccessor = null;
        this.set_CustomErrorMessageSet(true);
        return value;
    };
    $p.get_ErrorMessageResourceName = function() {
        return this._errorMessageResourceName;
    };
    $p.set_ErrorMessageResourceName = function(value) {
        this._errorMessageResourceName = value;
        this._errorMessageResourceAccessor = null;
        this.set_CustomErrorMessageSet(true);
        return value;
    };
    $p.get_ErrorMessageResourceType = function() {
        return this._errorMessageResourceType;
    };
    $p.set_ErrorMessageResourceType = function(value) {
        this._errorMessageResourceType = value;
        this._errorMessageResourceAccessor = null;
        this.set_CustomErrorMessageSet(true);
        return value;
    };
    $p.$ctor = function() {
        this._errorMessage = null;
        this._errorMessageResourceAccessor = null;
        this._errorMessageResourceName = null;
        this._errorMessageResourceType = null;
        this.isCallingOverload = false;
        this.$CustomErrorMessageSet$k__BackingField = false;
        System.ComponentModel.DataAnnotations.ValidationAttribute.prototype.$ctor$1.call(this, $delegate(this, System.Func$1$(String), function() {
            return "Validation Error";
        }));
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.$ctor$2 = function(errorMessage) {
        this._errorMessage = null;
        this._errorMessageResourceAccessor = null;
        this._errorMessageResourceName = null;
        this._errorMessageResourceType = null;
        this.isCallingOverload = false;
        this.$CustomErrorMessageSet$k__BackingField = false;
        System.ComponentModel.DataAnnotations.ValidationAttribute.prototype.$ctor$1.call(this, $delegate(this, System.Func$1$(String), function() {
            return errorMessage;
        }));
    };
    $p.$ctor$2.$type = $t;
    $p.$ctor$2.$new = function(errorMessage) {
        return new $p.$ctor$2.$type(this, errorMessage);
    };
    $p.$ctor$1 = function(errorMessageAccessor) {
        this._errorMessage = null;
        this._errorMessageResourceAccessor = null;
        this._errorMessageResourceName = null;
        this._errorMessageResourceType = null;
        this.isCallingOverload = false;
        this.$CustomErrorMessageSet$k__BackingField = false;
        System.Attribute.prototype.$ctor.call(this);
        this._errorMessageResourceAccessor = errorMessageAccessor;
    };
    $p.$ctor$1.$type = $t;
    $p.$ctor$1.$new = function(errorMessageAccessor) {
        return new $p.$ctor$1.$type(this, errorMessageAccessor);
    };
    $p.FormatErrorMessage = function(name) {
        return String.Format$1(System.Globalization.CultureInfo().CurrentCulture, this.get_ErrorMessageString(), $arrayinit([name], System.Object));
    };
    $p.IsValid = function(value) {
        if (this.isCallingOverload)
            throw System.NotImplementedException.prototype.$ctor$1.$new("Not Implemented").InternalInit(new Error());
        this.isCallingOverload = true;
        try {
            return this.IsValid$1(value, null) == null;
        }
        finally {
            this.isCallingOverload = false;
        }
    };
    $p.IsValid$1 = function(value, validationContext) {
        if (this.isCallingOverload)
            throw System.NotImplementedException.prototype.$ctor.$new().InternalInit(new Error());
        this.isCallingOverload = true;
        try {
            var result = System.ComponentModel.DataAnnotations.ValidationResult().Success;
            if (!this.IsValid(value)) {
                var memberNames;
                if (validationContext.get_MemberName() == null)
                    memberNames = null;
                else
                    memberNames = $arrayinit([validationContext.get_MemberName()], String);
                result = System.ComponentModel.DataAnnotations.ValidationResult.prototype.$ctor$2.$new(this.FormatErrorMessage(validationContext.get_DisplayName()), memberNames);
            }
            return result;
        }
        finally {
            this.isCallingOverload = false;
        }
    };
    $p.GetValidationResult = function(value, validationContext) {
        if (validationContext == null)
            throw System.ArgumentNullException.prototype.$ctor.$new("validationContext").InternalInit(new Error());
        var validationResult = this.IsValid$1(value, validationContext);
        if (validationResult != null && String.IsNullOrEmpty(validationResult.get_ErrorMessage()))
            validationResult = System.ComponentModel.DataAnnotations.ValidationResult.prototype.$ctor$2.$new(this.FormatErrorMessage(validationContext.get_DisplayName()), validationResult.get_MemberNames());
        return validationResult;
    };
    $p.Validate$1 = function(value, name) {
        if (!this.IsValid(value))
            throw System.ComponentModel.DataAnnotations.ValidationException.prototype.$ctor$4.$new(this.FormatErrorMessage(name), this, value).InternalInit(new Error());
    };
    $p.Validate = function(value, validationContext) {
        if (validationContext == null)
            throw System.ArgumentNullException.prototype.$ctor.$new("validationContext").InternalInit(new Error());
        var validationResult = this.GetValidationResult(value, validationContext);
        if (validationResult != null)
            throw System.ComponentModel.DataAnnotations.ValidationException.prototype.$ctor$3.$new(validationResult, this, value).InternalInit(new Error());
    };
    $p.SetupResourceAccessor = function() {
        if (this._errorMessageResourceAccessor != null)
            return;
        var localErrorMessage = this._errorMessage;
        var flag1 = !String.IsNullOrEmpty(this._errorMessageResourceName);
        var flag2 = !String.IsNullOrEmpty(localErrorMessage);
        var flag3 = this._errorMessageResourceType != null;
        if (flag1 == flag2)
            throw System.InvalidOperationException.prototype.$ctor.$new().InternalInit(new Error());
        if (flag3 != flag1)
            throw System.InvalidOperationException.prototype.$ctor.$new().InternalInit(new Error());
        if (flag1)
            this.SetResourceAccessorByPropertyLookup();
        else
            this._errorMessageResourceAccessor = ($delegate(this, System.Func$1$(String), function() {
                return localErrorMessage;
            }));
    };
    $p.SetResourceAccessorByPropertyLookup = function() {
        if (this._errorMessageResourceType == null || String.IsNullOrEmpty(this._errorMessageResourceName))
            throw System.InvalidOperationException.prototype.$ctor.$new().InternalInit(new Error());
        var property = this._errorMessageResourceType.GetProperty$1(this._errorMessageResourceName, System.Enum.InternalToObject(System.Reflection.BindingFlags, System.Enum.InternalToObject(System.Reflection.BindingFlags, System.Reflection.BindingFlags().Static.GetValue() | System.Reflection.BindingFlags().Public.GetValue()).GetValue() | System.Reflection.BindingFlags().NonPublic.GetValue()));
        if (property != null) {
            var getMethod = property.GetGetMethod$1(true);
            if (getMethod == null || !getMethod.get_IsAssembly() && !getMethod.get_IsPublic())
                property = null;
        }
        if (property == null)
            throw System.InvalidOperationException.prototype.$ctor.$new().InternalInit(new Error());
        else
            if (property.get_PropertyType() != String.$GetType())
                throw System.InvalidOperationException.prototype.$ctor.$new().InternalInit(new Error());
            else
                this._errorMessageResourceAccessor = $delegate(this, System.Func$1$(String), function() {
                    return $cast(System.Object, property.GetValue$1(null, null));
                });
    };
}).call(null, System.ComponentModel.DataAnnotations.ValidationAttribute, System.ComponentModel.DataAnnotations.ValidationAttribute.prototype);
$System$ComponentModel$DataAnnotations$AssemblyTypes.push(System.ComponentModel.DataAnnotations.ValidationAttribute);
System.ComponentModel.DataAnnotations.DataType = $define("System.ComponentModel.DataAnnotations.DataType", System.Enum);
(System.ComponentModel.DataAnnotations.DataType.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$System$ComponentModel$DataAnnotations$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Enum;
    $p.$typeName = "System.ComponentModel.DataAnnotations.DataType";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("DataType", $arrayinit([], System.Attribute));this.$type.Init("System.ComponentModel.DataAnnotations.DataType", System.Enum.InternalToObject(System.Reflection.TypeAttributes, System.Reflection.TypeAttributes().Public.GetValue() | System.Reflection.TypeAttributes().Sealed.GetValue()), System.ComponentModel.DataAnnotations.DataType, System.Enum, $arrayinit([], System.Type), null, $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("Custom", System.ComponentModel.DataAnnotations.DataType, System.Enum.InternalToObject(System.Reflection.FieldAttributes, System.Enum.InternalToObject(System.Reflection.FieldAttributes, System.Reflection.FieldAttributes().Public.GetValue() | System.Reflection.FieldAttributes().Static.GetValue()).GetValue() | System.Reflection.FieldAttributes().Literal.GetValue()), 0, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("DateTime", System.ComponentModel.DataAnnotations.DataType, System.Enum.InternalToObject(System.Reflection.FieldAttributes, System.Enum.InternalToObject(System.Reflection.FieldAttributes, System.Reflection.FieldAttributes().Public.GetValue() | System.Reflection.FieldAttributes().Static.GetValue()).GetValue() | System.Reflection.FieldAttributes().Literal.GetValue()), 1, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("Date", System.ComponentModel.DataAnnotations.DataType, System.Enum.InternalToObject(System.Reflection.FieldAttributes, System.Enum.InternalToObject(System.Reflection.FieldAttributes, System.Reflection.FieldAttributes().Public.GetValue() | System.Reflection.FieldAttributes().Static.GetValue()).GetValue() | System.Reflection.FieldAttributes().Literal.GetValue()), 2, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("Time", System.ComponentModel.DataAnnotations.DataType, System.Enum.InternalToObject(System.Reflection.FieldAttributes, System.Enum.InternalToObject(System.Reflection.FieldAttributes, System.Reflection.FieldAttributes().Public.GetValue() | System.Reflection.FieldAttributes().Static.GetValue()).GetValue() | System.Reflection.FieldAttributes().Literal.GetValue()), 3, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("Duration", System.ComponentModel.DataAnnotations.DataType, System.Enum.InternalToObject(System.Reflection.FieldAttributes, System.Enum.InternalToObject(System.Reflection.FieldAttributes, System.Reflection.FieldAttributes().Public.GetValue() | System.Reflection.FieldAttributes().Static.GetValue()).GetValue() | System.Reflection.FieldAttributes().Literal.GetValue()), 4, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("PhoneNumber", System.ComponentModel.DataAnnotations.DataType, System.Enum.InternalToObject(System.Reflection.FieldAttributes, System.Enum.InternalToObject(System.Reflection.FieldAttributes, System.Reflection.FieldAttributes().Public.GetValue() | System.Reflection.FieldAttributes().Static.GetValue()).GetValue() | System.Reflection.FieldAttributes().Literal.GetValue()), 5, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("Currency", System.ComponentModel.DataAnnotations.DataType, System.Enum.InternalToObject(System.Reflection.FieldAttributes, System.Enum.InternalToObject(System.Reflection.FieldAttributes, System.Reflection.FieldAttributes().Public.GetValue() | System.Reflection.FieldAttributes().Static.GetValue()).GetValue() | System.Reflection.FieldAttributes().Literal.GetValue()), 6, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("Text", System.ComponentModel.DataAnnotations.DataType, System.Enum.InternalToObject(System.Reflection.FieldAttributes, System.Enum.InternalToObject(System.Reflection.FieldAttributes, System.Reflection.FieldAttributes().Public.GetValue() | System.Reflection.FieldAttributes().Static.GetValue()).GetValue() | System.Reflection.FieldAttributes().Literal.GetValue()), 7, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("Html", System.ComponentModel.DataAnnotations.DataType, System.Enum.InternalToObject(System.Reflection.FieldAttributes, System.Enum.InternalToObject(System.Reflection.FieldAttributes, System.Reflection.FieldAttributes().Public.GetValue() | System.Reflection.FieldAttributes().Static.GetValue()).GetValue() | System.Reflection.FieldAttributes().Literal.GetValue()), 8, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("MultilineText", System.ComponentModel.DataAnnotations.DataType, System.Enum.InternalToObject(System.Reflection.FieldAttributes, System.Enum.InternalToObject(System.Reflection.FieldAttributes, System.Reflection.FieldAttributes().Public.GetValue() | System.Reflection.FieldAttributes().Static.GetValue()).GetValue() | System.Reflection.FieldAttributes().Literal.GetValue()), 9, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("EmailAddress", System.ComponentModel.DataAnnotations.DataType, System.Enum.InternalToObject(System.Reflection.FieldAttributes, System.Enum.InternalToObject(System.Reflection.FieldAttributes, System.Reflection.FieldAttributes().Public.GetValue() | System.Reflection.FieldAttributes().Static.GetValue()).GetValue() | System.Reflection.FieldAttributes().Literal.GetValue()), 10, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("Password", System.ComponentModel.DataAnnotations.DataType, System.Enum.InternalToObject(System.Reflection.FieldAttributes, System.Enum.InternalToObject(System.Reflection.FieldAttributes, System.Reflection.FieldAttributes().Public.GetValue() | System.Reflection.FieldAttributes().Static.GetValue()).GetValue() | System.Reflection.FieldAttributes().Literal.GetValue()), 11, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("Url", System.ComponentModel.DataAnnotations.DataType, System.Enum.InternalToObject(System.Reflection.FieldAttributes, System.Enum.InternalToObject(System.Reflection.FieldAttributes, System.Reflection.FieldAttributes().Public.GetValue() | System.Reflection.FieldAttributes().Static.GetValue()).GetValue() | System.Reflection.FieldAttributes().Literal.GetValue()), 12, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("ImageUrl", System.ComponentModel.DataAnnotations.DataType, System.Enum.InternalToObject(System.Reflection.FieldAttributes, System.Enum.InternalToObject(System.Reflection.FieldAttributes, System.Reflection.FieldAttributes().Public.GetValue() | System.Reflection.FieldAttributes().Static.GetValue()).GetValue() | System.Reflection.FieldAttributes().Literal.GetValue()), 13, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("CreditCard", System.ComponentModel.DataAnnotations.DataType, System.Enum.InternalToObject(System.Reflection.FieldAttributes, System.Enum.InternalToObject(System.Reflection.FieldAttributes, System.Reflection.FieldAttributes().Public.GetValue() | System.Reflection.FieldAttributes().Static.GetValue()).GetValue() | System.Reflection.FieldAttributes().Literal.GetValue()), 14, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("PostalCode", System.ComponentModel.DataAnnotations.DataType, System.Enum.InternalToObject(System.Reflection.FieldAttributes, System.Enum.InternalToObject(System.Reflection.FieldAttributes, System.Reflection.FieldAttributes().Public.GetValue() | System.Reflection.FieldAttributes().Static.GetValue()).GetValue() | System.Reflection.FieldAttributes().Literal.GetValue()), 15, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("Upload", System.ComponentModel.DataAnnotations.DataType, System.Enum.InternalToObject(System.Reflection.FieldAttributes, System.Enum.InternalToObject(System.Reflection.FieldAttributes, System.Reflection.FieldAttributes().Public.GetValue() | System.Reflection.FieldAttributes().Static.GetValue()).GetValue() | System.Reflection.FieldAttributes().Literal.GetValue()), 16, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", System.ComponentModel.DataAnnotations.DataType.prototype.$ctor, $arrayinit([], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), true, false, false, false);return this.$type;};
    $t.$StaticInitializer = function() {
        if ($t.$isStaticInitialized)
            return;
        $t.$isStaticInitialized = true;
        System.Enum.$StaticInitializer();
        $t.Custom = $p.$ctor.$new("Custom", 0);
        $t.DateTime = $p.$ctor.$new("DateTime", System.ComponentModel.DataAnnotations.DataType().Custom + 1);
        $t.Date = $p.$ctor.$new("Date", System.ComponentModel.DataAnnotations.DataType().DateTime + 1);
        $t.Time = $p.$ctor.$new("Time", System.ComponentModel.DataAnnotations.DataType().Date + 1);
        $t.Duration = $p.$ctor.$new("Duration", System.ComponentModel.DataAnnotations.DataType().Time + 1);
        $t.PhoneNumber = $p.$ctor.$new("PhoneNumber", System.ComponentModel.DataAnnotations.DataType().Duration + 1);
        $t.Currency = $p.$ctor.$new("Currency", System.ComponentModel.DataAnnotations.DataType().PhoneNumber + 1);
        $t.Text = $p.$ctor.$new("Text", System.ComponentModel.DataAnnotations.DataType().Currency + 1);
        $t.Html = $p.$ctor.$new("Html", System.ComponentModel.DataAnnotations.DataType().Text + 1);
        $t.MultilineText = $p.$ctor.$new("MultilineText", System.ComponentModel.DataAnnotations.DataType().Html + 1);
        $t.EmailAddress = $p.$ctor.$new("EmailAddress", System.ComponentModel.DataAnnotations.DataType().MultilineText + 1);
        $t.Password = $p.$ctor.$new("Password", System.ComponentModel.DataAnnotations.DataType().EmailAddress + 1);
        $t.Url = $p.$ctor.$new("Url", System.ComponentModel.DataAnnotations.DataType().Password + 1);
        $t.ImageUrl = $p.$ctor.$new("ImageUrl", System.ComponentModel.DataAnnotations.DataType().Url + 1);
        $t.CreditCard = $p.$ctor.$new("CreditCard", System.ComponentModel.DataAnnotations.DataType().ImageUrl + 1);
        $t.PostalCode = $p.$ctor.$new("PostalCode", System.ComponentModel.DataAnnotations.DataType().CreditCard + 1);
        $t.Upload = $p.$ctor.$new("Upload", System.ComponentModel.DataAnnotations.DataType().PostalCode + 1);
    };
    $p.$ctor = function(name, value) {
        System.Enum.prototype.$ctor.call(this, name, value);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function(name, value) {
        return new $p.$ctor.$type(this, name, value);
    };
}).call(null, System.ComponentModel.DataAnnotations.DataType, System.ComponentModel.DataAnnotations.DataType.prototype);
$System$ComponentModel$DataAnnotations$AssemblyTypes.push(System.ComponentModel.DataAnnotations.DataType);
System.ComponentModel.DataAnnotations.DataTypeAttribute = $define("System.ComponentModel.DataAnnotations.DataTypeAttribute", System.ComponentModel.DataAnnotations.ValidationAttribute);
(System.ComponentModel.DataAnnotations.DataTypeAttribute.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$System$ComponentModel$DataAnnotations$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.ComponentModel.DataAnnotations.ValidationAttribute;
    $p.$typeName = "System.ComponentModel.DataAnnotations.DataTypeAttribute";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("DataTypeAttribute", $arrayinit([(function() {var $obj$ = System.AttributeUsageAttribute.prototype.$ctor.$new(2496);$obj$.set_AllowMultiple(false);return $obj$;}).call(this)], System.Attribute));this.$type.Init("System.ComponentModel.DataAnnotations.DataTypeAttribute", System.Enum.InternalToObject(System.Reflection.TypeAttributes, System.Reflection.TypeAttributes().Public.GetValue() | System.Reflection.TypeAttributes().Class.GetValue()), System.ComponentModel.DataAnnotations.DataTypeAttribute, System.ComponentModel.DataAnnotations.ValidationAttribute, $arrayinit([], System.Type), null, $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("_dataTypeStrings", $array(String), System.Enum.InternalToObject(System.Reflection.FieldAttributes, System.Reflection.FieldAttributes().Private.GetValue() | System.Reflection.FieldAttributes().Static.GetValue()), null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("$DataType$k__BackingField", System.ComponentModel.DataAnnotations.DataType, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("$CustomDataType$k__BackingField", String, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("$DisplayFormat$k__BackingField", System.ComponentModel.DataAnnotations.DisplayFormatAttribute, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("get_DataType", System.ComponentModel.DataAnnotations.DataTypeAttribute.prototype.get_DataType, $arrayinit([], System.Reflection.ParameterInfo), System.ComponentModel.DataAnnotations.DataType, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_DataType", System.ComponentModel.DataAnnotations.DataTypeAttribute.prototype.set_DataType, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.ComponentModel.DataAnnotations.DataType, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Private, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_CustomDataType", System.ComponentModel.DataAnnotations.DataTypeAttribute.prototype.get_CustomDataType, $arrayinit([], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_CustomDataType", System.ComponentModel.DataAnnotations.DataTypeAttribute.prototype.set_CustomDataType, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", String, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Private, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_DisplayFormat", System.ComponentModel.DataAnnotations.DataTypeAttribute.prototype.get_DisplayFormat, $arrayinit([], System.Reflection.ParameterInfo), System.ComponentModel.DataAnnotations.DisplayFormatAttribute, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_DisplayFormat", System.ComponentModel.DataAnnotations.DataTypeAttribute.prototype.set_DisplayFormat, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.ComponentModel.DataAnnotations.DisplayFormatAttribute, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Family, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new(".cctor", System.ComponentModel.DataAnnotations.DataTypeAttribute.prototype.$cctor, $arrayinit([], System.Reflection.ParameterInfo), System.Void, System.Enum.InternalToObject(System.Reflection.MethodAttributes, System.Reflection.MethodAttributes().Private.GetValue() | System.Reflection.MethodAttributes().Static.GetValue()), $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("GetDataTypeName", System.ComponentModel.DataAnnotations.DataTypeAttribute.prototype.GetDataTypeName, $arrayinit([], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("IsValid", System.ComponentModel.DataAnnotations.DataTypeAttribute.prototype.IsValid, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Object, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Boolean, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("EnsureValidDataType", System.ComponentModel.DataAnnotations.DataTypeAttribute.prototype.EnsureValidDataType, $arrayinit([], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Private, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", System.ComponentModel.DataAnnotations.DataTypeAttribute.prototype.$ctor, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("dataType", System.ComponentModel.DataAnnotations.DataType, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor$1", System.ComponentModel.DataAnnotations.DataTypeAttribute.prototype.$ctor$1, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("customDataType", String, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.PropertyInfo.prototype.$ctor.$new("DataType", System.ComponentModel.DataAnnotations.DataType, System.Reflection.MethodInfo.prototype.$ctor.$new("get_DataType", System.ComponentModel.DataAnnotations.DataTypeAttribute.prototype.get_DataType, $arrayinit([], System.Reflection.ParameterInfo), System.ComponentModel.DataAnnotations.DataType, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_DataType", System.ComponentModel.DataAnnotations.DataTypeAttribute.prototype.set_DataType, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.ComponentModel.DataAnnotations.DataType, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Private, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("CustomDataType", String, System.Reflection.MethodInfo.prototype.$ctor.$new("get_CustomDataType", System.ComponentModel.DataAnnotations.DataTypeAttribute.prototype.get_CustomDataType, $arrayinit([], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_CustomDataType", System.ComponentModel.DataAnnotations.DataTypeAttribute.prototype.set_CustomDataType, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", String, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Private, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("DisplayFormat", System.ComponentModel.DataAnnotations.DisplayFormatAttribute, System.Reflection.MethodInfo.prototype.$ctor.$new("get_DisplayFormat", System.ComponentModel.DataAnnotations.DataTypeAttribute.prototype.get_DisplayFormat, $arrayinit([], System.Reflection.ParameterInfo), System.ComponentModel.DataAnnotations.DisplayFormatAttribute, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_DisplayFormat", System.ComponentModel.DataAnnotations.DataTypeAttribute.prototype.set_DisplayFormat, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.ComponentModel.DataAnnotations.DisplayFormatAttribute, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Family, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute))], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false, false, false, false);return this.$type;};
    $t.$StaticInitializer = function() {
        if ($t.$isStaticInitialized)
            return;
        $t.$isStaticInitialized = true;
        System.ComponentModel.DataAnnotations.ValidationAttribute.$StaticInitializer();
        $t._dataTypeStrings = System.Enum.GetNames(System.ComponentModel.DataAnnotations.DataType.$GetType());
    };
    $p.get_DataType = function() {return this.$DataType$k__BackingField;};
    $p.set_DataType = function(value) {this.$DataType$k__BackingField = value;return value;};
    $p.get_CustomDataType = function() {return this.$CustomDataType$k__BackingField;};
    $p.set_CustomDataType = function(value) {this.$CustomDataType$k__BackingField = value;return value;};
    $p.get_DisplayFormat = function() {return this.$DisplayFormat$k__BackingField;};
    $p.set_DisplayFormat = function(value) {this.$DisplayFormat$k__BackingField = value;return value;};
    $p.$ctor = function(dataType) {
        this.$DataType$k__BackingField = 0;
        this.$CustomDataType$k__BackingField = null;
        this.$DisplayFormat$k__BackingField = null;
        System.ComponentModel.DataAnnotations.ValidationAttribute.prototype.$ctor.call(this);
        this.set_DataType(dataType);
        switch (dataType) {
            case System.ComponentModel.DataAnnotations.DataType().Date:
                this.set_DisplayFormat(System.ComponentModel.DataAnnotations.DisplayFormatAttribute.prototype.$ctor.$new());
                this.get_DisplayFormat().set_DataFormatString("{0:d}");
                this.get_DisplayFormat().set_ApplyFormatInEditMode(true);
                break;
            case System.ComponentModel.DataAnnotations.DataType().Time:
                this.set_DisplayFormat(System.ComponentModel.DataAnnotations.DisplayFormatAttribute.prototype.$ctor.$new());
                this.get_DisplayFormat().set_DataFormatString("{0:t}");
                this.get_DisplayFormat().set_ApplyFormatInEditMode(true);
                break;
            case System.ComponentModel.DataAnnotations.DataType().Currency:
                this.set_DisplayFormat(System.ComponentModel.DataAnnotations.DisplayFormatAttribute.prototype.$ctor.$new());
                this.get_DisplayFormat().set_DataFormatString("{0:C}");
                break;
        }
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function(dataType) {
        return new $p.$ctor.$type(this, dataType);
    };
    $p.$ctor$1 = function(customDataType) {
        this.$DataType$k__BackingField = 0;
        this.$CustomDataType$k__BackingField = null;
        this.$DisplayFormat$k__BackingField = null;
        System.ComponentModel.DataAnnotations.DataTypeAttribute.prototype.$ctor.call(this, System.ComponentModel.DataAnnotations.DataType().Custom);
        this.set_CustomDataType(customDataType);
    };
    $p.$ctor$1.$type = $t;
    $p.$ctor$1.$new = function(customDataType) {
        return new $p.$ctor$1.$type(this, customDataType);
    };
    $p.GetDataTypeName = function() {
        this.EnsureValidDataType();
        if (this.get_DataType().GetValue() == System.ComponentModel.DataAnnotations.DataType().Custom.GetValue())
            return this.get_CustomDataType();
        else
            return System.ComponentModel.DataAnnotations.DataTypeAttribute()._dataTypeStrings[this.get_DataType().GetValue()];
    };
    $p.IsValid = function(value) {
        this.EnsureValidDataType();
        return true;
    };
    $p.EnsureValidDataType = function() {
        if (this.get_DataType().GetValue() == System.ComponentModel.DataAnnotations.DataType().Custom.GetValue() && String.IsNullOrEmpty(this.get_CustomDataType()))
            throw System.InvalidOperationException.prototype.$ctor.$new().InternalInit(new Error());
    };
}).call(null, System.ComponentModel.DataAnnotations.DataTypeAttribute, System.ComponentModel.DataAnnotations.DataTypeAttribute.prototype);
$System$ComponentModel$DataAnnotations$AssemblyTypes.push(System.ComponentModel.DataAnnotations.DataTypeAttribute);
System.ComponentModel.DataAnnotations.DisplayAttribute = $define("System.ComponentModel.DataAnnotations.DisplayAttribute", System.Attribute);
(System.ComponentModel.DataAnnotations.DisplayAttribute.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$System$ComponentModel$DataAnnotations$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Attribute;
    $p.$typeName = "System.ComponentModel.DataAnnotations.DisplayAttribute";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("DisplayAttribute", $arrayinit([(function() {var $obj$ = System.AttributeUsageAttribute.prototype.$ctor.$new(2496);$obj$.set_AllowMultiple(false);return $obj$;}).call(this)], System.Attribute));this.$type.Init("System.ComponentModel.DataAnnotations.DisplayAttribute", System.Enum.InternalToObject(System.Reflection.TypeAttributes, System.Enum.InternalToObject(System.Reflection.TypeAttributes, System.Reflection.TypeAttributes().Public.GetValue() | System.Reflection.TypeAttributes().Class.GetValue()).GetValue() | System.Reflection.TypeAttributes().Sealed.GetValue()), System.ComponentModel.DataAnnotations.DisplayAttribute, System.Attribute, $arrayinit([], System.Type), null, $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("_resourceType", System.Type, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("_shortName", System.ComponentModel.DataAnnotations.LocalizableString, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("_name", System.ComponentModel.DataAnnotations.LocalizableString, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("_description", System.ComponentModel.DataAnnotations.LocalizableString, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("_prompt", System.ComponentModel.DataAnnotations.LocalizableString, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("_groupName", System.ComponentModel.DataAnnotations.LocalizableString, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("_autoGenerateField", System.Nullable$1, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("_autoGenerateFilter", System.Nullable$1, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("_order", System.Nullable$1, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("get_ShortName", System.ComponentModel.DataAnnotations.DisplayAttribute.prototype.get_ShortName, $arrayinit([], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_ShortName", System.ComponentModel.DataAnnotations.DisplayAttribute.prototype.set_ShortName, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", String, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_Name", System.ComponentModel.DataAnnotations.DisplayAttribute.prototype.get_Name, $arrayinit([], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Name", System.ComponentModel.DataAnnotations.DisplayAttribute.prototype.set_Name, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", String, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_Description", System.ComponentModel.DataAnnotations.DisplayAttribute.prototype.get_Description, $arrayinit([], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Description", System.ComponentModel.DataAnnotations.DisplayAttribute.prototype.set_Description, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", String, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_Prompt", System.ComponentModel.DataAnnotations.DisplayAttribute.prototype.get_Prompt, $arrayinit([], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Prompt", System.ComponentModel.DataAnnotations.DisplayAttribute.prototype.set_Prompt, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", String, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_GroupName", System.ComponentModel.DataAnnotations.DisplayAttribute.prototype.get_GroupName, $arrayinit([], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_GroupName", System.ComponentModel.DataAnnotations.DisplayAttribute.prototype.set_GroupName, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", String, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_ResourceType", System.ComponentModel.DataAnnotations.DisplayAttribute.prototype.get_ResourceType, $arrayinit([], System.Reflection.ParameterInfo), System.Type, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_ResourceType", System.ComponentModel.DataAnnotations.DisplayAttribute.prototype.set_ResourceType, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Type, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_AutoGenerateField", System.ComponentModel.DataAnnotations.DisplayAttribute.prototype.get_AutoGenerateField, $arrayinit([], System.Reflection.ParameterInfo), System.Boolean, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_AutoGenerateField", System.ComponentModel.DataAnnotations.DisplayAttribute.prototype.set_AutoGenerateField, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Boolean, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_AutoGenerateFilter", System.ComponentModel.DataAnnotations.DisplayAttribute.prototype.get_AutoGenerateFilter, $arrayinit([], System.Reflection.ParameterInfo), System.Boolean, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_AutoGenerateFilter", System.ComponentModel.DataAnnotations.DisplayAttribute.prototype.set_AutoGenerateFilter, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Boolean, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_Order", System.ComponentModel.DataAnnotations.DisplayAttribute.prototype.get_Order, $arrayinit([], System.Reflection.ParameterInfo), System.Int32, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Order", System.ComponentModel.DataAnnotations.DisplayAttribute.prototype.set_Order, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Int32, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("GetShortName", System.ComponentModel.DataAnnotations.DisplayAttribute.prototype.GetShortName, $arrayinit([], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("GetName", System.ComponentModel.DataAnnotations.DisplayAttribute.prototype.GetName, $arrayinit([], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("GetDescription", System.ComponentModel.DataAnnotations.DisplayAttribute.prototype.GetDescription, $arrayinit([], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("GetPrompt", System.ComponentModel.DataAnnotations.DisplayAttribute.prototype.GetPrompt, $arrayinit([], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("GetGroupName", System.ComponentModel.DataAnnotations.DisplayAttribute.prototype.GetGroupName, $arrayinit([], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("GetAutoGenerateField", System.ComponentModel.DataAnnotations.DisplayAttribute.prototype.GetAutoGenerateField, $arrayinit([], System.Reflection.ParameterInfo), System.Nullable$1, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("GetAutoGenerateFilter", System.ComponentModel.DataAnnotations.DisplayAttribute.prototype.GetAutoGenerateFilter, $arrayinit([], System.Reflection.ParameterInfo), System.Nullable$1, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("GetOrder", System.ComponentModel.DataAnnotations.DisplayAttribute.prototype.GetOrder, $arrayinit([], System.Reflection.ParameterInfo), System.Nullable$1, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", System.ComponentModel.DataAnnotations.DisplayAttribute.prototype.$ctor, $arrayinit([], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.PropertyInfo.prototype.$ctor.$new("ShortName", String, System.Reflection.MethodInfo.prototype.$ctor.$new("get_ShortName", System.ComponentModel.DataAnnotations.DisplayAttribute.prototype.get_ShortName, $arrayinit([], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_ShortName", System.ComponentModel.DataAnnotations.DisplayAttribute.prototype.set_ShortName, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", String, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("Name", String, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Name", System.ComponentModel.DataAnnotations.DisplayAttribute.prototype.get_Name, $arrayinit([], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Name", System.ComponentModel.DataAnnotations.DisplayAttribute.prototype.set_Name, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", String, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("Description", String, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Description", System.ComponentModel.DataAnnotations.DisplayAttribute.prototype.get_Description, $arrayinit([], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Description", System.ComponentModel.DataAnnotations.DisplayAttribute.prototype.set_Description, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", String, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("Prompt", String, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Prompt", System.ComponentModel.DataAnnotations.DisplayAttribute.prototype.get_Prompt, $arrayinit([], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Prompt", System.ComponentModel.DataAnnotations.DisplayAttribute.prototype.set_Prompt, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", String, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("GroupName", String, System.Reflection.MethodInfo.prototype.$ctor.$new("get_GroupName", System.ComponentModel.DataAnnotations.DisplayAttribute.prototype.get_GroupName, $arrayinit([], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_GroupName", System.ComponentModel.DataAnnotations.DisplayAttribute.prototype.set_GroupName, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", String, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("ResourceType", System.Type, System.Reflection.MethodInfo.prototype.$ctor.$new("get_ResourceType", System.ComponentModel.DataAnnotations.DisplayAttribute.prototype.get_ResourceType, $arrayinit([], System.Reflection.ParameterInfo), System.Type, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_ResourceType", System.ComponentModel.DataAnnotations.DisplayAttribute.prototype.set_ResourceType, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Type, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("AutoGenerateField", System.Boolean, System.Reflection.MethodInfo.prototype.$ctor.$new("get_AutoGenerateField", System.ComponentModel.DataAnnotations.DisplayAttribute.prototype.get_AutoGenerateField, $arrayinit([], System.Reflection.ParameterInfo), System.Boolean, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_AutoGenerateField", System.ComponentModel.DataAnnotations.DisplayAttribute.prototype.set_AutoGenerateField, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Boolean, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("AutoGenerateFilter", System.Boolean, System.Reflection.MethodInfo.prototype.$ctor.$new("get_AutoGenerateFilter", System.ComponentModel.DataAnnotations.DisplayAttribute.prototype.get_AutoGenerateFilter, $arrayinit([], System.Reflection.ParameterInfo), System.Boolean, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_AutoGenerateFilter", System.ComponentModel.DataAnnotations.DisplayAttribute.prototype.set_AutoGenerateFilter, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Boolean, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("Order", System.Int32, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Order", System.ComponentModel.DataAnnotations.DisplayAttribute.prototype.get_Order, $arrayinit([], System.Reflection.ParameterInfo), System.Int32, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Order", System.ComponentModel.DataAnnotations.DisplayAttribute.prototype.set_Order, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Int32, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute))], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false, false, false, false);return this.$type;};
    $t.$StaticInitializer = function() {
        if ($t.$isStaticInitialized)
            return;
        $t.$isStaticInitialized = true;
        System.Attribute.$StaticInitializer();
    };
    $p.$ctor = function() {
        this._resourceType = null;
        this._shortName = System.ComponentModel.DataAnnotations.LocalizableString.prototype.$ctor.$new("ShortName");
        this._name = System.ComponentModel.DataAnnotations.LocalizableString.prototype.$ctor.$new("Name");
        this._description = System.ComponentModel.DataAnnotations.LocalizableString.prototype.$ctor.$new("Description");
        this._prompt = System.ComponentModel.DataAnnotations.LocalizableString.prototype.$ctor.$new("Prompt");
        this._groupName = System.ComponentModel.DataAnnotations.LocalizableString.prototype.$ctor.$new("GroupName");
        this._autoGenerateField = null;
        this._autoGenerateFilter = null;
        this._order = null;
        System.Attribute.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.get_ShortName = function() {
        return this._shortName.get_Value();
    };
    $p.set_ShortName = function(value) {
        if (this._shortName.get_Value() != value) {
            this._shortName.set_Value(value);
        }
        return value;
    };
    $p.get_Name = function() {
        return this._name.get_Value();
    };
    $p.set_Name = function(value) {
        if (this._name.get_Value() != value) {
            this._name.set_Value(value);
        }
        return value;
    };
    $p.get_Description = function() {
        return this._description.get_Value();
    };
    $p.set_Description = function(value) {
        if (this._description.get_Value() != value) {
            this._description.set_Value(value);
        }
        return value;
    };
    $p.get_Prompt = function() {
        return this._prompt.get_Value();
    };
    $p.set_Prompt = function(value) {
        if (this._prompt.get_Value() != value) {
            this._prompt.set_Value(value);
        }
        return value;
    };
    $p.get_GroupName = function() {
        return this._groupName.get_Value();
    };
    $p.set_GroupName = function(value) {
        if (this._groupName.get_Value() != value) {
            this._groupName.set_Value(value);
        }
        return value;
    };
    $p.get_ResourceType = function() {
        return this._resourceType;
    };
    $p.set_ResourceType = function(value) {
        if (this._resourceType != value) {
            this._resourceType = value;
            this._shortName.set_ResourceType(value);
            this._name.set_ResourceType(value);
            this._description.set_ResourceType(value);
            this._prompt.set_ResourceType(value);
            this._groupName.set_ResourceType(value);
        }
        return value;
    };
    $p.get_AutoGenerateField = function() {
        if (!(this._autoGenerateField != null)) {
            throw System.InvalidOperationException.prototype.$ctor.$new().InternalInit(new Error());
        }
        return this._autoGenerateField;
    };
    $p.set_AutoGenerateField = function(value) {
        this._autoGenerateField = value;
        return value;
    };
    $p.get_AutoGenerateFilter = function() {
        if (!(this._autoGenerateFilter != null)) {
            throw System.InvalidOperationException.prototype.$ctor.$new().InternalInit(new Error());
        }
        return this._autoGenerateFilter;
    };
    $p.set_AutoGenerateFilter = function(value) {
        this._autoGenerateFilter = value;
        return value;
    };
    $p.get_Order = function() {
        if (!(this._order != null)) {
            throw System.InvalidOperationException.prototype.$ctor.$new().InternalInit(new Error());
        }
        return this._order;
    };
    $p.set_Order = function(value) {
        this._order = value;
        return value;
    };
    $p.GetShortName = function() {
        return this.GetName();
    };
    $p.GetName = function() {
        return this._name.GetLocalizableValue();
    };
    $p.GetDescription = function() {
        return this._description.GetLocalizableValue();
    };
    $p.GetPrompt = function() {
        return this._prompt.GetLocalizableValue();
    };
    $p.GetGroupName = function() {
        return this._groupName.GetLocalizableValue();
    };
    $p.GetAutoGenerateField = function() {
        return this._autoGenerateField;
    };
    $p.GetAutoGenerateFilter = function() {
        return this._autoGenerateFilter;
    };
    $p.GetOrder = function() {
        return this._order;
    };
}).call(null, System.ComponentModel.DataAnnotations.DisplayAttribute, System.ComponentModel.DataAnnotations.DisplayAttribute.prototype);
$System$ComponentModel$DataAnnotations$AssemblyTypes.push(System.ComponentModel.DataAnnotations.DisplayAttribute);
System.ComponentModel.DataAnnotations.DisplayFormatAttribute = $define("System.ComponentModel.DataAnnotations.DisplayFormatAttribute", System.Attribute);
(System.ComponentModel.DataAnnotations.DisplayFormatAttribute.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$System$ComponentModel$DataAnnotations$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Attribute;
    $p.$typeName = "System.ComponentModel.DataAnnotations.DisplayFormatAttribute";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("DisplayFormatAttribute", $arrayinit([(function() {var $obj$ = System.AttributeUsageAttribute.prototype.$ctor.$new(384);$obj$.set_AllowMultiple(false);return $obj$;}).call(this)], System.Attribute));this.$type.Init("System.ComponentModel.DataAnnotations.DisplayFormatAttribute", System.Enum.InternalToObject(System.Reflection.TypeAttributes, System.Reflection.TypeAttributes().Public.GetValue() | System.Reflection.TypeAttributes().Class.GetValue()), System.ComponentModel.DataAnnotations.DisplayFormatAttribute, System.Attribute, $arrayinit([], System.Type), null, $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("$DataFormatString$k__BackingField", String, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("$NullDisplayText$k__BackingField", String, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("$ConvertEmptyStringToNull$k__BackingField", System.Boolean, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("$ApplyFormatInEditMode$k__BackingField", System.Boolean, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("$HtmlEncode$k__BackingField", System.Boolean, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("get_DataFormatString", System.ComponentModel.DataAnnotations.DisplayFormatAttribute.prototype.get_DataFormatString, $arrayinit([], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_DataFormatString", System.ComponentModel.DataAnnotations.DisplayFormatAttribute.prototype.set_DataFormatString, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", String, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_NullDisplayText", System.ComponentModel.DataAnnotations.DisplayFormatAttribute.prototype.get_NullDisplayText, $arrayinit([], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_NullDisplayText", System.ComponentModel.DataAnnotations.DisplayFormatAttribute.prototype.set_NullDisplayText, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", String, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_ConvertEmptyStringToNull", System.ComponentModel.DataAnnotations.DisplayFormatAttribute.prototype.get_ConvertEmptyStringToNull, $arrayinit([], System.Reflection.ParameterInfo), System.Boolean, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_ConvertEmptyStringToNull", System.ComponentModel.DataAnnotations.DisplayFormatAttribute.prototype.set_ConvertEmptyStringToNull, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Boolean, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_ApplyFormatInEditMode", System.ComponentModel.DataAnnotations.DisplayFormatAttribute.prototype.get_ApplyFormatInEditMode, $arrayinit([], System.Reflection.ParameterInfo), System.Boolean, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_ApplyFormatInEditMode", System.ComponentModel.DataAnnotations.DisplayFormatAttribute.prototype.set_ApplyFormatInEditMode, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Boolean, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_HtmlEncode", System.ComponentModel.DataAnnotations.DisplayFormatAttribute.prototype.get_HtmlEncode, $arrayinit([], System.Reflection.ParameterInfo), System.Boolean, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_HtmlEncode", System.ComponentModel.DataAnnotations.DisplayFormatAttribute.prototype.set_HtmlEncode, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Boolean, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", System.ComponentModel.DataAnnotations.DisplayFormatAttribute.prototype.$ctor, $arrayinit([], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.PropertyInfo.prototype.$ctor.$new("DataFormatString", String, System.Reflection.MethodInfo.prototype.$ctor.$new("get_DataFormatString", System.ComponentModel.DataAnnotations.DisplayFormatAttribute.prototype.get_DataFormatString, $arrayinit([], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_DataFormatString", System.ComponentModel.DataAnnotations.DisplayFormatAttribute.prototype.set_DataFormatString, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", String, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("NullDisplayText", String, System.Reflection.MethodInfo.prototype.$ctor.$new("get_NullDisplayText", System.ComponentModel.DataAnnotations.DisplayFormatAttribute.prototype.get_NullDisplayText, $arrayinit([], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_NullDisplayText", System.ComponentModel.DataAnnotations.DisplayFormatAttribute.prototype.set_NullDisplayText, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", String, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("ConvertEmptyStringToNull", System.Boolean, System.Reflection.MethodInfo.prototype.$ctor.$new("get_ConvertEmptyStringToNull", System.ComponentModel.DataAnnotations.DisplayFormatAttribute.prototype.get_ConvertEmptyStringToNull, $arrayinit([], System.Reflection.ParameterInfo), System.Boolean, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_ConvertEmptyStringToNull", System.ComponentModel.DataAnnotations.DisplayFormatAttribute.prototype.set_ConvertEmptyStringToNull, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Boolean, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("ApplyFormatInEditMode", System.Boolean, System.Reflection.MethodInfo.prototype.$ctor.$new("get_ApplyFormatInEditMode", System.ComponentModel.DataAnnotations.DisplayFormatAttribute.prototype.get_ApplyFormatInEditMode, $arrayinit([], System.Reflection.ParameterInfo), System.Boolean, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_ApplyFormatInEditMode", System.ComponentModel.DataAnnotations.DisplayFormatAttribute.prototype.set_ApplyFormatInEditMode, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Boolean, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("HtmlEncode", System.Boolean, System.Reflection.MethodInfo.prototype.$ctor.$new("get_HtmlEncode", System.ComponentModel.DataAnnotations.DisplayFormatAttribute.prototype.get_HtmlEncode, $arrayinit([], System.Reflection.ParameterInfo), System.Boolean, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_HtmlEncode", System.ComponentModel.DataAnnotations.DisplayFormatAttribute.prototype.set_HtmlEncode, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Boolean, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute))], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false, false, false, false);return this.$type;};
    $t.$StaticInitializer = function() {
        if ($t.$isStaticInitialized)
            return;
        $t.$isStaticInitialized = true;
        System.Attribute.$StaticInitializer();
    };
    $p.get_DataFormatString = function() {return this.$DataFormatString$k__BackingField;};
    $p.set_DataFormatString = function(value) {this.$DataFormatString$k__BackingField = value;return value;};
    $p.get_NullDisplayText = function() {return this.$NullDisplayText$k__BackingField;};
    $p.set_NullDisplayText = function(value) {this.$NullDisplayText$k__BackingField = value;return value;};
    $p.get_ConvertEmptyStringToNull = function() {return this.$ConvertEmptyStringToNull$k__BackingField;};
    $p.set_ConvertEmptyStringToNull = function(value) {this.$ConvertEmptyStringToNull$k__BackingField = value;return value;};
    $p.get_ApplyFormatInEditMode = function() {return this.$ApplyFormatInEditMode$k__BackingField;};
    $p.set_ApplyFormatInEditMode = function(value) {this.$ApplyFormatInEditMode$k__BackingField = value;return value;};
    $p.get_HtmlEncode = function() {return this.$HtmlEncode$k__BackingField;};
    $p.set_HtmlEncode = function(value) {this.$HtmlEncode$k__BackingField = value;return value;};
    $p.$ctor = function() {
        this.$DataFormatString$k__BackingField = null;
        this.$NullDisplayText$k__BackingField = null;
        this.$ConvertEmptyStringToNull$k__BackingField = false;
        this.$ApplyFormatInEditMode$k__BackingField = false;
        this.$HtmlEncode$k__BackingField = false;
        System.Attribute.prototype.$ctor.call(this);
        this.set_ConvertEmptyStringToNull(true);
        this.set_HtmlEncode(true);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
}).call(null, System.ComponentModel.DataAnnotations.DisplayFormatAttribute, System.ComponentModel.DataAnnotations.DisplayFormatAttribute.prototype);
$System$ComponentModel$DataAnnotations$AssemblyTypes.push(System.ComponentModel.DataAnnotations.DisplayFormatAttribute);
System.ComponentModel.DataAnnotations.EmailAddressAttribute = $define("System.ComponentModel.DataAnnotations.EmailAddressAttribute", System.ComponentModel.DataAnnotations.DataTypeAttribute);
(System.ComponentModel.DataAnnotations.EmailAddressAttribute.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$System$ComponentModel$DataAnnotations$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.ComponentModel.DataAnnotations.DataTypeAttribute;
    $p.$typeName = "System.ComponentModel.DataAnnotations.EmailAddressAttribute";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("EmailAddressAttribute", $arrayinit([(function() {var $obj$ = System.AttributeUsageAttribute.prototype.$ctor.$new(2432);$obj$.set_AllowMultiple(false);return $obj$;}).call(this)], System.Attribute));this.$type.Init("System.ComponentModel.DataAnnotations.EmailAddressAttribute", System.Enum.InternalToObject(System.Reflection.TypeAttributes, System.Enum.InternalToObject(System.Reflection.TypeAttributes, System.Reflection.TypeAttributes().Public.GetValue() | System.Reflection.TypeAttributes().Class.GetValue()).GetValue() | System.Reflection.TypeAttributes().Sealed.GetValue()), System.ComponentModel.DataAnnotations.EmailAddressAttribute, System.ComponentModel.DataAnnotations.DataTypeAttribute, $arrayinit([], System.Type), null, $arrayinit([], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new(".cctor", System.ComponentModel.DataAnnotations.EmailAddressAttribute.prototype.$cctor$1, $arrayinit([], System.Reflection.ParameterInfo), System.Void, System.Enum.InternalToObject(System.Reflection.MethodAttributes, System.Reflection.MethodAttributes().Private.GetValue() | System.Reflection.MethodAttributes().Static.GetValue()), $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("IsValid", System.ComponentModel.DataAnnotations.EmailAddressAttribute.prototype.IsValid, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Object, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Boolean, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", System.ComponentModel.DataAnnotations.EmailAddressAttribute.prototype.$ctor, $arrayinit([], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false, false, false, false);return this.$type;};
    $t.$StaticInitializer = function() {
        if ($t.$isStaticInitialized)
            return;
        $t.$isStaticInitialized = true;
        System.ComponentModel.DataAnnotations.DataTypeAttribute.$StaticInitializer();
        $t._regex = new RegExp("^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$");
    };
    $p.$ctor = function() {
        System.ComponentModel.DataAnnotations.DataTypeAttribute.prototype.$ctor.call(this, System.ComponentModel.DataAnnotations.DataType().EmailAddress);
        this.set_ErrorMessage("Invalid email address");
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.IsValid = function(value) {
        if (value == null)
            return true;
        var input = (function() {
            var $as$ = value;
            if (!System.Type.prototype.IsInstanceOfType.call(String.$GetType(), $as$))
                $as$ = null;
            return $as$;
        }).call(this);
        if (input != null)
            return System.ComponentModel.DataAnnotations.EmailAddressAttribute()._regex.exec(input) != null;
        else
            return false;
    };
}).call(null, System.ComponentModel.DataAnnotations.EmailAddressAttribute, System.ComponentModel.DataAnnotations.EmailAddressAttribute.prototype);
$System$ComponentModel$DataAnnotations$AssemblyTypes.push(System.ComponentModel.DataAnnotations.EmailAddressAttribute);
System.ComponentModel.DataAnnotations.LocalizableString = $define("System.ComponentModel.DataAnnotations.LocalizableString", System.Object);
(System.ComponentModel.DataAnnotations.LocalizableString.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$System$ComponentModel$DataAnnotations$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Object;
    $p.$typeName = "System.ComponentModel.DataAnnotations.LocalizableString";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("LocalizableString", $arrayinit([], System.Attribute));this.$type.Init("System.ComponentModel.DataAnnotations.LocalizableString", System.Enum.InternalToObject(System.Reflection.TypeAttributes, System.Reflection.TypeAttributes().NotPublic.GetValue() | System.Reflection.TypeAttributes().Class.GetValue()), System.ComponentModel.DataAnnotations.LocalizableString, System.Object, $arrayinit([], System.Type), null, $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("_propertyName", String, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("_propertyValue", String, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("_resourceType", System.Type, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("_cachedResult", System.Func$1, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("get_Value", System.ComponentModel.DataAnnotations.LocalizableString.prototype.get_Value, $arrayinit([], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Value", System.ComponentModel.DataAnnotations.LocalizableString.prototype.set_Value, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", String, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_ResourceType", System.ComponentModel.DataAnnotations.LocalizableString.prototype.set_ResourceType, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Type, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("GetLocalizableValue", System.ComponentModel.DataAnnotations.LocalizableString.prototype.GetLocalizableValue, $arrayinit([], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("ClearCache", System.ComponentModel.DataAnnotations.LocalizableString.prototype.ClearCache, $arrayinit([], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Private, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", System.ComponentModel.DataAnnotations.LocalizableString.prototype.$ctor, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("propertyName", String, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.PropertyInfo.prototype.$ctor.$new("Value", String, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Value", System.ComponentModel.DataAnnotations.LocalizableString.prototype.get_Value, $arrayinit([], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Value", System.ComponentModel.DataAnnotations.LocalizableString.prototype.set_Value, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", String, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("ResourceType", System.Type, null, System.Reflection.MethodInfo.prototype.$ctor.$new("set_ResourceType", System.ComponentModel.DataAnnotations.LocalizableString.prototype.set_ResourceType, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Type, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute))], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false, false, false, false);return this.$type;};
    $t.$StaticInitializer = function() {
        if ($t.$isStaticInitialized)
            return;
        $t.$isStaticInitialized = true;
        System.Object.$StaticInitializer();
    };
    $p.get_Value = function() {
        return this._propertyValue;
    };
    $p.set_Value = function(value) {
        if (!(this._propertyValue != value))
            return;
        this.ClearCache();
        this._propertyValue = value;
        return value;
    };
    $p.set_ResourceType = function(value) {
        if (!(this._resourceType != value))
            return;
        this.ClearCache();
        this._resourceType = value;
        return value;
    };
    $p.$ctor = function(propertyName) {
        this._propertyName = null;
        this._propertyValue = null;
        this._resourceType = null;
        this._cachedResult = null;
        System.Object.prototype.$ctor.call(this);
        this._propertyName = propertyName;
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function(propertyName) {
        return new $p.$ctor.$type(this, propertyName);
    };
    $p.GetLocalizableValue = function() {
        if (this._cachedResult == null) {
            if (this._propertyValue == null || this._resourceType == null) {
                this._cachedResult = $cast(System.Func$1$(String), ($delegate(this, System.Func$1$(String), function() {
                    return this._propertyValue;
                })));
            }
            else {
                var property = this._resourceType.GetProperty(this._propertyValue);
                var flag = false;
                if (!this._resourceType.get_IsVisible() || property == null || property.get_PropertyType() != String.$GetType()) {
                    flag = true;
                }
                else {
                    var getMethod = property.GetGetMethod();
                    if (getMethod == null || !getMethod.get_IsPublic() || !getMethod.get_IsStatic())
                        flag = true;
                }
                if (flag) {
                    this._cachedResult = $cast(System.Func$1$(String), ($delegate(this, System.Func$1$(String), function() {
                        throw System.InvalidOperationException.prototype.$ctor$1.$new("Localization Failed").InternalInit(new Error());
                    })));
                }
                else
                    this._cachedResult = $cast(System.Func$1$(String), ($delegate(this, System.Func$1$(String), function() {
                        return $cast(System.Object, property.GetValue$1(null, null));
                    })));
            }
        }
        return this._cachedResult();
    };
    $p.ClearCache = function() {
        this._cachedResult = null;
    };
}).call(null, System.ComponentModel.DataAnnotations.LocalizableString, System.ComponentModel.DataAnnotations.LocalizableString.prototype);
$System$ComponentModel$DataAnnotations$AssemblyTypes.push(System.ComponentModel.DataAnnotations.LocalizableString);
System.ComponentModel.DataAnnotations.RequiredAttribute = $define("System.ComponentModel.DataAnnotations.RequiredAttribute", System.ComponentModel.DataAnnotations.ValidationAttribute);
(System.ComponentModel.DataAnnotations.RequiredAttribute.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$System$ComponentModel$DataAnnotations$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.ComponentModel.DataAnnotations.ValidationAttribute;
    $p.$typeName = "System.ComponentModel.DataAnnotations.RequiredAttribute";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("RequiredAttribute", $arrayinit([(function() {var $obj$ = System.AttributeUsageAttribute.prototype.$ctor.$new(2432);$obj$.set_AllowMultiple(false);return $obj$;}).call(this)], System.Attribute));this.$type.Init("System.ComponentModel.DataAnnotations.RequiredAttribute", System.Enum.InternalToObject(System.Reflection.TypeAttributes, System.Reflection.TypeAttributes().Public.GetValue() | System.Reflection.TypeAttributes().Class.GetValue()), System.ComponentModel.DataAnnotations.RequiredAttribute, System.ComponentModel.DataAnnotations.ValidationAttribute, $arrayinit([], System.Type), null, $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("$AllowEmptyStrings$k__BackingField", System.Boolean, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("get_AllowEmptyStrings", System.ComponentModel.DataAnnotations.RequiredAttribute.prototype.get_AllowEmptyStrings, $arrayinit([], System.Reflection.ParameterInfo), System.Boolean, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_AllowEmptyStrings", System.ComponentModel.DataAnnotations.RequiredAttribute.prototype.set_AllowEmptyStrings, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Boolean, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("IsValid", System.ComponentModel.DataAnnotations.RequiredAttribute.prototype.IsValid, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Object, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Boolean, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", System.ComponentModel.DataAnnotations.RequiredAttribute.prototype.$ctor, $arrayinit([], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.PropertyInfo.prototype.$ctor.$new("AllowEmptyStrings", System.Boolean, System.Reflection.MethodInfo.prototype.$ctor.$new("get_AllowEmptyStrings", System.ComponentModel.DataAnnotations.RequiredAttribute.prototype.get_AllowEmptyStrings, $arrayinit([], System.Reflection.ParameterInfo), System.Boolean, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_AllowEmptyStrings", System.ComponentModel.DataAnnotations.RequiredAttribute.prototype.set_AllowEmptyStrings, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Boolean, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute))], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false, false, false, false);return this.$type;};
    $t.$StaticInitializer = function() {
        if ($t.$isStaticInitialized)
            return;
        $t.$isStaticInitialized = true;
        System.ComponentModel.DataAnnotations.ValidationAttribute.$StaticInitializer();
    };
    $p.get_AllowEmptyStrings = function() {return this.$AllowEmptyStrings$k__BackingField;};
    $p.set_AllowEmptyStrings = function(value) {this.$AllowEmptyStrings$k__BackingField = value;return value;};
    $p.$ctor = function() {
        this.$AllowEmptyStrings$k__BackingField = false;
        System.ComponentModel.DataAnnotations.ValidationAttribute.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.IsValid = function(value) {
        if (value == null)
            return false;
        var str = (function() {
            var $as$ = value;
            if (!System.Type.prototype.IsInstanceOfType.call(String.$GetType(), $as$))
                $as$ = null;
            return $as$;
        }).call(this);
        if (str != null && !this.get_AllowEmptyStrings())
            return str.Trim().length != 0;
        else
            return true;
    };
}).call(null, System.ComponentModel.DataAnnotations.RequiredAttribute, System.ComponentModel.DataAnnotations.RequiredAttribute.prototype);
$System$ComponentModel$DataAnnotations$AssemblyTypes.push(System.ComponentModel.DataAnnotations.RequiredAttribute);
System.ComponentModel.DataAnnotations.ValidationAttributeStore = $define("System.ComponentModel.DataAnnotations.ValidationAttributeStore", System.Object);
(System.ComponentModel.DataAnnotations.ValidationAttributeStore.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$System$ComponentModel$DataAnnotations$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Object;
    $p.$typeName = "System.ComponentModel.DataAnnotations.ValidationAttributeStore";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("ValidationAttributeStore", $arrayinit([], System.Attribute));this.$type.Init("System.ComponentModel.DataAnnotations.ValidationAttributeStore", System.Enum.InternalToObject(System.Reflection.TypeAttributes, System.Reflection.TypeAttributes().NotPublic.GetValue() | System.Reflection.TypeAttributes().Class.GetValue()), System.ComponentModel.DataAnnotations.ValidationAttributeStore, System.Object, $arrayinit([], System.Type), null, $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("_singleton", System.ComponentModel.DataAnnotations.ValidationAttributeStore, System.Enum.InternalToObject(System.Reflection.FieldAttributes, System.Reflection.FieldAttributes().Private.GetValue() | System.Reflection.FieldAttributes().Static.GetValue()), null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("_typeStoreItems", System.Collections.Generic.Dictionary$2, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new(".cctor", System.ComponentModel.DataAnnotations.ValidationAttributeStore.prototype.$cctor, $arrayinit([], System.Reflection.ParameterInfo), System.Void, System.Enum.InternalToObject(System.Reflection.MethodAttributes, System.Reflection.MethodAttributes().Private.GetValue() | System.Reflection.MethodAttributes().Static.GetValue()), $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_Instance", System.ComponentModel.DataAnnotations.ValidationAttributeStore.prototype.get_Instance, $arrayinit([], System.Reflection.ParameterInfo), System.ComponentModel.DataAnnotations.ValidationAttributeStore, System.Enum.InternalToObject(System.Reflection.MethodAttributes, System.Reflection.MethodAttributes().Assembly.GetValue() | System.Reflection.MethodAttributes().Static.GetValue()), $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("GetTypeValidationAttributes", System.ComponentModel.DataAnnotations.ValidationAttributeStore.prototype.GetTypeValidationAttributes, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("validationContext", System.ComponentModel.DataAnnotations.ValidationContext, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Collections.Generic.IEnumerable$1, System.Reflection.MethodAttributes().Assembly, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("GetTypeDisplayAttribute", System.ComponentModel.DataAnnotations.ValidationAttributeStore.prototype.GetTypeDisplayAttribute, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("validationContext", System.ComponentModel.DataAnnotations.ValidationContext, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.ComponentModel.DataAnnotations.DisplayAttribute, System.Reflection.MethodAttributes().Assembly, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("GetPropertyValidationAttributes", System.ComponentModel.DataAnnotations.ValidationAttributeStore.prototype.GetPropertyValidationAttributes, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("validationContext", System.ComponentModel.DataAnnotations.ValidationContext, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Collections.Generic.IEnumerable$1, System.Reflection.MethodAttributes().Assembly, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("GetPropertyDisplayAttribute", System.ComponentModel.DataAnnotations.ValidationAttributeStore.prototype.GetPropertyDisplayAttribute, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("validationContext", System.ComponentModel.DataAnnotations.ValidationContext, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.ComponentModel.DataAnnotations.DisplayAttribute, System.Reflection.MethodAttributes().Assembly, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("GetPropertyType", System.ComponentModel.DataAnnotations.ValidationAttributeStore.prototype.GetPropertyType, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("validationContext", System.ComponentModel.DataAnnotations.ValidationContext, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Type, System.Reflection.MethodAttributes().Assembly, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("IsPropertyContext", System.ComponentModel.DataAnnotations.ValidationAttributeStore.prototype.IsPropertyContext, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("validationContext", System.ComponentModel.DataAnnotations.ValidationContext, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Boolean, System.Reflection.MethodAttributes().Assembly, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("GetTypeStoreItem", System.ComponentModel.DataAnnotations.ValidationAttributeStore.prototype.GetTypeStoreItem, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("type", System.Type, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.ComponentModel.DataAnnotations.ValidationAttributeStore.TypeStoreItem, System.Reflection.MethodAttributes().Private, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("EnsureValidationContext", System.ComponentModel.DataAnnotations.ValidationAttributeStore.prototype.EnsureValidationContext, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("validationContext", System.ComponentModel.DataAnnotations.ValidationContext, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Enum.InternalToObject(System.Reflection.MethodAttributes, System.Reflection.MethodAttributes().Private.GetValue() | System.Reflection.MethodAttributes().Static.GetValue()), $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", System.ComponentModel.DataAnnotations.ValidationAttributeStore.prototype.$ctor, $arrayinit([], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.PropertyInfo.prototype.$ctor.$new("Instance", System.ComponentModel.DataAnnotations.ValidationAttributeStore, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Instance", System.ComponentModel.DataAnnotations.ValidationAttributeStore.prototype.get_Instance, $arrayinit([], System.Reflection.ParameterInfo), System.ComponentModel.DataAnnotations.ValidationAttributeStore, System.Enum.InternalToObject(System.Reflection.MethodAttributes, System.Reflection.MethodAttributes().Assembly.GetValue() | System.Reflection.MethodAttributes().Static.GetValue()), $arrayinit([], System.Attribute)), null, $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute))], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false, false, false, false);return this.$type;};
    $t.$StaticInitializer = function() {
        if ($t.$isStaticInitialized)
            return;
        $t.$isStaticInitialized = true;
        System.Object.$StaticInitializer();
        $t._singleton = System.ComponentModel.DataAnnotations.ValidationAttributeStore.prototype.$ctor.$new();
    };
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
        this._typeStoreItems = System.Collections.Generic.Dictionary$2$(System.Type, System.ComponentModel.DataAnnotations.ValidationAttributeStore.TypeStoreItem).prototype.$ctor.$new();
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $t.get_Instance = function() {
        return System.ComponentModel.DataAnnotations.ValidationAttributeStore()._singleton;
    };
    $p.GetTypeValidationAttributes = function(validationContext) {
        System.ComponentModel.DataAnnotations.ValidationAttributeStore.EnsureValidationContext(validationContext);
        var item = this.GetTypeStoreItem(validationContext.get_ObjectType());
        return item.get_ValidationAttributes();
    };
    $p.GetTypeDisplayAttribute = function(validationContext) {
        System.ComponentModel.DataAnnotations.ValidationAttributeStore.EnsureValidationContext(validationContext);
        var item = this.GetTypeStoreItem(validationContext.get_ObjectType());
        return item.get_DisplayAttribute();
    };
    $p.GetPropertyValidationAttributes = function(validationContext) {
        System.ComponentModel.DataAnnotations.ValidationAttributeStore.EnsureValidationContext(validationContext);
        var typeItem = this.GetTypeStoreItem(validationContext.get_ObjectType());
        var item = typeItem.GetPropertyStoreItem(validationContext.get_MemberName());
        return item.get_ValidationAttributes();
    };
    $p.GetPropertyDisplayAttribute = function(validationContext) {
        System.ComponentModel.DataAnnotations.ValidationAttributeStore.EnsureValidationContext(validationContext);
        var typeItem = this.GetTypeStoreItem(validationContext.get_ObjectType());
        var item = typeItem.GetPropertyStoreItem(validationContext.get_MemberName());
        return item.get_DisplayAttribute();
    };
    $p.GetPropertyType = function(validationContext) {
        System.ComponentModel.DataAnnotations.ValidationAttributeStore.EnsureValidationContext(validationContext);
        var typeItem = this.GetTypeStoreItem(validationContext.get_ObjectType());
        var item = typeItem.GetPropertyStoreItem(validationContext.get_MemberName());
        return item.get_PropertyType();
    };
    $p.IsPropertyContext = function(validationContext) {
        System.ComponentModel.DataAnnotations.ValidationAttributeStore.EnsureValidationContext(validationContext);
        var typeItem = this.GetTypeStoreItem(validationContext.get_ObjectType());
        var item = null;
        return (function() {
            var $anon$1 = {
                value: null
            };
            var $result$ = typeItem.TryGetPropertyStoreItem(validationContext.get_MemberName(), $anon$1);
            item = $anon$1.value;
            return $result$;
        }).call(this);
    };
    $p.GetTypeStoreItem = function(type) {
        if (type == null) {
            throw System.ArgumentNullException.prototype.$ctor.$new("type").InternalInit(new Error());
        }
        var item = null;
        if (!(function() {
            var $anon$1 = {
                value: null
            };
            var $result$ = this._typeStoreItems.TryGetValue(type, $anon$1);
            item = $anon$1.value;
            return $result$;
        }).call(this)) {
            var attributes = System.Linq.Enumerable.Cast(System.Attribute, type.GetCustomAttributes(true));
            item = System.ComponentModel.DataAnnotations.ValidationAttributeStore.TypeStoreItem.prototype.$ctor.$new(type, attributes);
            this._typeStoreItems.set_Item(type, item);
        }
        return item;
    };
    $t.EnsureValidationContext = function(validationContext) {
        if (validationContext == null) {
            throw System.ArgumentNullException.prototype.$ctor.$new("validationContext").InternalInit(new Error());
        }
    };
    $t.StoreItem = $define("System.ComponentModel.DataAnnotations.ValidationAttributeStore.StoreItem", System.Object);
    ($t.StoreItem.$TypeInitializer = function($t, $p) {
        $t.$GetAssembly = window.$System$ComponentModel$DataAnnotations$GetAssembly;
        $p.$type = $t;
        $t.$baseType = System.Object;
        $p.$typeName = "System.ComponentModel.DataAnnotations.ValidationAttributeStore.StoreItem";
        $t.$typeName = $p.$typeName;
        $t.$GetType = function() {
            return System.Type._GetTypeFromTypeFunc(this);
        };
        $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("StoreItem", $arrayinit([], System.Attribute));this.$type.Init("System.ComponentModel.DataAnnotations.ValidationAttributeStore.StoreItem", System.Enum.InternalToObject(System.Reflection.TypeAttributes, System.Enum.InternalToObject(System.Reflection.TypeAttributes, System.Reflection.TypeAttributes().NestedPrivate.GetValue() | System.Reflection.TypeAttributes().Class.GetValue()).GetValue() | System.Reflection.TypeAttributes().Abstract.GetValue()), System.ComponentModel.DataAnnotations.ValidationAttributeStore.StoreItem, System.Object, $arrayinit([], System.Type), null, $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("_emptyValidationAttributeEnumerable", System.Collections.Generic.IEnumerable$1, System.Enum.InternalToObject(System.Reflection.FieldAttributes, System.Reflection.FieldAttributes().Private.GetValue() | System.Reflection.FieldAttributes().Static.GetValue()), null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("_validationAttributes", System.Collections.Generic.IEnumerable$1, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("$DisplayAttribute$k__BackingField", System.ComponentModel.DataAnnotations.DisplayAttribute, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new(".cctor", System.ComponentModel.DataAnnotations.ValidationAttributeStore.StoreItem.prototype.$cctor, $arrayinit([], System.Reflection.ParameterInfo), System.Void, System.Enum.InternalToObject(System.Reflection.MethodAttributes, System.Reflection.MethodAttributes().Private.GetValue() | System.Reflection.MethodAttributes().Static.GetValue()), $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_ValidationAttributes", System.ComponentModel.DataAnnotations.ValidationAttributeStore.StoreItem.prototype.get_ValidationAttributes, $arrayinit([], System.Reflection.ParameterInfo), System.Collections.Generic.IEnumerable$1, System.Reflection.MethodAttributes().Assembly, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_DisplayAttribute", System.ComponentModel.DataAnnotations.ValidationAttributeStore.StoreItem.prototype.get_DisplayAttribute, $arrayinit([], System.Reflection.ParameterInfo), System.ComponentModel.DataAnnotations.DisplayAttribute, System.Reflection.MethodAttributes().Assembly, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_DisplayAttribute", System.ComponentModel.DataAnnotations.ValidationAttributeStore.StoreItem.prototype.set_DisplayAttribute, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.ComponentModel.DataAnnotations.DisplayAttribute, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Assembly, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", System.ComponentModel.DataAnnotations.ValidationAttributeStore.StoreItem.prototype.$ctor, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("attributes", System.Collections.Generic.IEnumerable$1$(System.Attribute), 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Assembly, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.PropertyInfo.prototype.$ctor.$new("ValidationAttributes", System.Collections.Generic.IEnumerable$1, System.Reflection.MethodInfo.prototype.$ctor.$new("get_ValidationAttributes", System.ComponentModel.DataAnnotations.ValidationAttributeStore.StoreItem.prototype.get_ValidationAttributes, $arrayinit([], System.Reflection.ParameterInfo), System.Collections.Generic.IEnumerable$1, System.Reflection.MethodAttributes().Assembly, $arrayinit([], System.Attribute)), null, $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("DisplayAttribute", System.ComponentModel.DataAnnotations.DisplayAttribute, System.Reflection.MethodInfo.prototype.$ctor.$new("get_DisplayAttribute", System.ComponentModel.DataAnnotations.ValidationAttributeStore.StoreItem.prototype.get_DisplayAttribute, $arrayinit([], System.Reflection.ParameterInfo), System.ComponentModel.DataAnnotations.DisplayAttribute, System.Reflection.MethodAttributes().Assembly, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_DisplayAttribute", System.ComponentModel.DataAnnotations.ValidationAttributeStore.StoreItem.prototype.set_DisplayAttribute, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.ComponentModel.DataAnnotations.DisplayAttribute, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Assembly, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute))], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false, false, false, false);return this.$type;};
        $t.$StaticInitializer = function() {
            if ($t.$isStaticInitialized)
                return;
            $t.$isStaticInitialized = true;
            System.Object.$StaticInitializer();
            $t._emptyValidationAttributeEnumerable = $arrayinit(new Array(0), System.ComponentModel.DataAnnotations.ValidationAttribute);
        };
        $p.$ctor = function(attributes) {
            this._validationAttributes = null;
            this.$DisplayAttribute$k__BackingField = null;
            System.Object.prototype.$ctor.call(this);
            this._validationAttributes = System.Linq.Enumerable.OfType(System.ComponentModel.DataAnnotations.ValidationAttribute, attributes);
            this.set_DisplayAttribute(System.Linq.Enumerable.SingleOrDefault(System.ComponentModel.DataAnnotations.DisplayAttribute, System.Linq.Enumerable.OfType(System.ComponentModel.DataAnnotations.DisplayAttribute, attributes)));
        };
        $p.$ctor.$type = $t;
        $p.$ctor.$new = function(attributes) {
            return new $p.$ctor.$type(this, attributes);
        };
        $p.get_ValidationAttributes = function() {
            return this._validationAttributes;
        };
        $p.get_DisplayAttribute = function() {return this.$DisplayAttribute$k__BackingField;};
        $p.set_DisplayAttribute = function(value) {this.$DisplayAttribute$k__BackingField = value;return value;};
    }).call($t, $t.StoreItem, $t.StoreItem.prototype);
    $System$ComponentModel$DataAnnotations$AssemblyTypes.push($t.StoreItem);
    $t.TypeStoreItem = $define("System.ComponentModel.DataAnnotations.ValidationAttributeStore.TypeStoreItem", System.ComponentModel.DataAnnotations.ValidationAttributeStore.StoreItem);
    ($t.TypeStoreItem.$TypeInitializer = function($t, $p) {
        $t.$GetAssembly = window.$System$ComponentModel$DataAnnotations$GetAssembly;
        $p.$type = $t;
        $t.$baseType = System.ComponentModel.DataAnnotations.ValidationAttributeStore.StoreItem;
        $p.$typeName = "System.ComponentModel.DataAnnotations.ValidationAttributeStore.TypeStoreItem";
        $t.$typeName = $p.$typeName;
        $t.$GetType = function() {
            return System.Type._GetTypeFromTypeFunc(this);
        };
        $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("TypeStoreItem", $arrayinit([], System.Attribute));this.$type.Init("System.ComponentModel.DataAnnotations.ValidationAttributeStore.TypeStoreItem", System.Enum.InternalToObject(System.Reflection.TypeAttributes, System.Reflection.TypeAttributes().NestedPrivate.GetValue() | System.Reflection.TypeAttributes().Class.GetValue()), System.ComponentModel.DataAnnotations.ValidationAttributeStore.TypeStoreItem, System.ComponentModel.DataAnnotations.ValidationAttributeStore.StoreItem, $arrayinit([], System.Type), null, $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("_type", System.Type, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("_propertyStoreItems", System.Collections.Generic.Dictionary$2, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("GetPropertyStoreItem", System.ComponentModel.DataAnnotations.ValidationAttributeStore.TypeStoreItem.prototype.GetPropertyStoreItem, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("propertyName", String, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.ComponentModel.DataAnnotations.ValidationAttributeStore.PropertyStoreItem, System.Reflection.MethodAttributes().Assembly, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("TryGetPropertyStoreItem", System.ComponentModel.DataAnnotations.ValidationAttributeStore.TypeStoreItem.prototype.TryGetPropertyStoreItem, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("propertyName", String, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("item", System.ComponentModel.DataAnnotations.ValidationAttributeStore.PropertyStoreItem, 1, System.Reflection.ParameterAttributes().Out, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Boolean, System.Reflection.MethodAttributes().Assembly, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("CreatePropertyStoreItems", System.ComponentModel.DataAnnotations.ValidationAttributeStore.TypeStoreItem.prototype.CreatePropertyStoreItems, $arrayinit([], System.Reflection.ParameterInfo), System.Collections.Generic.Dictionary$2, System.Reflection.MethodAttributes().Private, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", System.ComponentModel.DataAnnotations.ValidationAttributeStore.TypeStoreItem.prototype.$ctor, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("type", System.Type, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("attributes", System.Collections.Generic.IEnumerable$1$(System.Attribute), 1, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Assembly, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false, false, false, false);return this.$type;};
        $t.$StaticInitializer = function() {
            if ($t.$isStaticInitialized)
                return;
            $t.$isStaticInitialized = true;
            System.ComponentModel.DataAnnotations.ValidationAttributeStore.StoreItem.$StaticInitializer();
        };
        $p.$ctor = function(type, attributes) {
            this._type = null;
            this._propertyStoreItems = null;
            System.ComponentModel.DataAnnotations.ValidationAttributeStore.StoreItem.prototype.$ctor.call(this, attributes);
            this._type = type;
        };
        $p.$ctor.$type = $t;
        $p.$ctor.$new = function(type, attributes) {
            return new $p.$ctor.$type(this, type, attributes);
        };
        $p.GetPropertyStoreItem = function(propertyName) {
            var item = null;
            if (!(function() {
                var $anon$1 = {
                    value: null
                };
                var $result$ = this.TryGetPropertyStoreItem(propertyName, $anon$1);
                item = $anon$1.value;
                return $result$;
            }).call(this)) {
                throw System.ArgumentException.prototype.$ctor$1.$new("propertyName").InternalInit(new Error());
            }
            return item;
        };
        $p.TryGetPropertyStoreItem = function(propertyName, item) {
            if (String.IsNullOrEmpty(propertyName)) {
                throw System.ArgumentNullException.prototype.$ctor.$new("propertyName").InternalInit(new Error());
            }
            if (this._propertyStoreItems == null) {
                if (this._propertyStoreItems == null) {
                    this._propertyStoreItems = this.CreatePropertyStoreItems();
                }
            }
            if (!(function() {
                var $anon$1 = {
                    value: null
                };
                var $result$ = this._propertyStoreItems.TryGetValue(propertyName, $anon$1);
                item.value = $anon$1.value;
                return $result$;
            }).call(this)) {
                return false;
            }
            return true;
        };
        $p.CreatePropertyStoreItems = function() {
            var propertyStoreItems = System.Collections.Generic.Dictionary$2$(String, System.ComponentModel.DataAnnotations.ValidationAttributeStore.PropertyStoreItem).prototype.$ctor.$new();
            var properties = this._type.GetProperties();
            {
                var $anon$1iterator = properties;
                var $anon$2enumerator = $anon$1iterator.System$Collections$IEnumerable$GetEnumerator();
                while ($anon$2enumerator.System$Collections$IEnumerator$MoveNext()) {
                    var property = $anon$2enumerator.System$Collections$IEnumerator$get_Current();
                    var item = System.ComponentModel.DataAnnotations.ValidationAttributeStore.PropertyStoreItem.prototype.$ctor.$new(property.get_PropertyType(), System.Linq.Enumerable.Cast(System.Attribute, property.GetCustomAttributes(true)));
                    propertyStoreItems.set_Item(property.get_Name(), item);
                }
            }
            return propertyStoreItems;
        };
    }).call($t, $t.TypeStoreItem, $t.TypeStoreItem.prototype);
    $System$ComponentModel$DataAnnotations$AssemblyTypes.push($t.TypeStoreItem);
    $t.PropertyStoreItem = $define("System.ComponentModel.DataAnnotations.ValidationAttributeStore.PropertyStoreItem", System.ComponentModel.DataAnnotations.ValidationAttributeStore.StoreItem);
    ($t.PropertyStoreItem.$TypeInitializer = function($t, $p) {
        $t.$GetAssembly = window.$System$ComponentModel$DataAnnotations$GetAssembly;
        $p.$type = $t;
        $t.$baseType = System.ComponentModel.DataAnnotations.ValidationAttributeStore.StoreItem;
        $p.$typeName = "System.ComponentModel.DataAnnotations.ValidationAttributeStore.PropertyStoreItem";
        $t.$typeName = $p.$typeName;
        $t.$GetType = function() {
            return System.Type._GetTypeFromTypeFunc(this);
        };
        $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("PropertyStoreItem", $arrayinit([], System.Attribute));this.$type.Init("System.ComponentModel.DataAnnotations.ValidationAttributeStore.PropertyStoreItem", System.Enum.InternalToObject(System.Reflection.TypeAttributes, System.Reflection.TypeAttributes().NestedPrivate.GetValue() | System.Reflection.TypeAttributes().Class.GetValue()), System.ComponentModel.DataAnnotations.ValidationAttributeStore.PropertyStoreItem, System.ComponentModel.DataAnnotations.ValidationAttributeStore.StoreItem, $arrayinit([], System.Type), null, $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("_propertyType", System.Type, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("get_PropertyType", System.ComponentModel.DataAnnotations.ValidationAttributeStore.PropertyStoreItem.prototype.get_PropertyType, $arrayinit([], System.Reflection.ParameterInfo), System.Type, System.Reflection.MethodAttributes().Assembly, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", System.ComponentModel.DataAnnotations.ValidationAttributeStore.PropertyStoreItem.prototype.$ctor, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("propertyType", System.Type, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("attributes", System.Collections.Generic.IEnumerable$1$(System.Attribute), 1, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Assembly, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.PropertyInfo.prototype.$ctor.$new("PropertyType", System.Type, System.Reflection.MethodInfo.prototype.$ctor.$new("get_PropertyType", System.ComponentModel.DataAnnotations.ValidationAttributeStore.PropertyStoreItem.prototype.get_PropertyType, $arrayinit([], System.Reflection.ParameterInfo), System.Type, System.Reflection.MethodAttributes().Assembly, $arrayinit([], System.Attribute)), null, $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute))], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false, false, false, false);return this.$type;};
        $t.$StaticInitializer = function() {
            if ($t.$isStaticInitialized)
                return;
            $t.$isStaticInitialized = true;
            System.ComponentModel.DataAnnotations.ValidationAttributeStore.StoreItem.$StaticInitializer();
        };
        $p.$ctor = function(propertyType, attributes) {
            this._propertyType = null;
            System.ComponentModel.DataAnnotations.ValidationAttributeStore.StoreItem.prototype.$ctor.call(this, attributes);
            this._propertyType = propertyType;
        };
        $p.$ctor.$type = $t;
        $p.$ctor.$new = function(propertyType, attributes) {
            return new $p.$ctor.$type(this, propertyType, attributes);
        };
        $p.get_PropertyType = function() {
            return this._propertyType;
        };
    }).call($t, $t.PropertyStoreItem, $t.PropertyStoreItem.prototype);
    $System$ComponentModel$DataAnnotations$AssemblyTypes.push($t.PropertyStoreItem);
}).call(null, System.ComponentModel.DataAnnotations.ValidationAttributeStore, System.ComponentModel.DataAnnotations.ValidationAttributeStore.prototype);
$System$ComponentModel$DataAnnotations$AssemblyTypes.push(System.ComponentModel.DataAnnotations.ValidationAttributeStore);
System.ComponentModel.DataAnnotations.ValidationContext = $define("System.ComponentModel.DataAnnotations.ValidationContext", System.Object);
(System.ComponentModel.DataAnnotations.ValidationContext.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$System$ComponentModel$DataAnnotations$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Object;
    $p.$typeName = "System.ComponentModel.DataAnnotations.ValidationContext";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("ValidationContext", $arrayinit([], System.Attribute));this.$type.Init("System.ComponentModel.DataAnnotations.ValidationContext", System.Enum.InternalToObject(System.Reflection.TypeAttributes, System.Enum.InternalToObject(System.Reflection.TypeAttributes, System.Reflection.TypeAttributes().Public.GetValue() | System.Reflection.TypeAttributes().Class.GetValue()).GetValue() | System.Reflection.TypeAttributes().Sealed.GetValue()), System.ComponentModel.DataAnnotations.ValidationContext, System.Object, $arrayinit([System.IServiceProvider], System.Type), null, $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("_serviceProvider", System.Func$2, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("_objectInstance", System.Object, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("_memberName", String, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("_displayName", String, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("_items", System.Collections.Generic.Dictionary$2, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("get_ObjectInstance", System.ComponentModel.DataAnnotations.ValidationContext.prototype.get_ObjectInstance, $arrayinit([], System.Reflection.ParameterInfo), System.Object, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_ObjectType", System.ComponentModel.DataAnnotations.ValidationContext.prototype.get_ObjectType, $arrayinit([], System.Reflection.ParameterInfo), System.Type, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_DisplayName", System.ComponentModel.DataAnnotations.ValidationContext.prototype.get_DisplayName, $arrayinit([], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_DisplayName", System.ComponentModel.DataAnnotations.ValidationContext.prototype.set_DisplayName, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", String, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_MemberName", System.ComponentModel.DataAnnotations.ValidationContext.prototype.get_MemberName, $arrayinit([], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_MemberName", System.ComponentModel.DataAnnotations.ValidationContext.prototype.set_MemberName, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", String, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_Items", System.ComponentModel.DataAnnotations.ValidationContext.prototype.get_Items, $arrayinit([], System.Reflection.ParameterInfo), System.Collections.Generic.IDictionary$2, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("GetDisplayName", System.ComponentModel.DataAnnotations.ValidationContext.prototype.GetDisplayName, $arrayinit([], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Private, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("InitializeServiceProvider", System.ComponentModel.DataAnnotations.ValidationContext.prototype.InitializeServiceProvider, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("serviceProvider", System.Func$2$(System.Type, System.Object), 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("GetService", System.ComponentModel.DataAnnotations.ValidationContext.prototype.GetService, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("serviceType", System.Type, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Object, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", System.ComponentModel.DataAnnotations.ValidationContext.prototype.$ctor, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("instance", System.Object, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor$1", System.ComponentModel.DataAnnotations.ValidationContext.prototype.$ctor$1, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("instance", System.Object, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("items", System.Collections.Generic.IDictionary$2$(System.Object, System.Object), 1, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor$2", System.ComponentModel.DataAnnotations.ValidationContext.prototype.$ctor$2, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("instance", System.Object, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("serviceProvider", System.IServiceProvider, 1, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("items", System.Collections.Generic.IDictionary$2$(System.Object, System.Object), 2, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.PropertyInfo.prototype.$ctor.$new("ObjectInstance", System.Object, System.Reflection.MethodInfo.prototype.$ctor.$new("get_ObjectInstance", System.ComponentModel.DataAnnotations.ValidationContext.prototype.get_ObjectInstance, $arrayinit([], System.Reflection.ParameterInfo), System.Object, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), null, $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("ObjectType", System.Type, System.Reflection.MethodInfo.prototype.$ctor.$new("get_ObjectType", System.ComponentModel.DataAnnotations.ValidationContext.prototype.get_ObjectType, $arrayinit([], System.Reflection.ParameterInfo), System.Type, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), null, $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("DisplayName", String, System.Reflection.MethodInfo.prototype.$ctor.$new("get_DisplayName", System.ComponentModel.DataAnnotations.ValidationContext.prototype.get_DisplayName, $arrayinit([], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_DisplayName", System.ComponentModel.DataAnnotations.ValidationContext.prototype.set_DisplayName, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", String, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("MemberName", String, System.Reflection.MethodInfo.prototype.$ctor.$new("get_MemberName", System.ComponentModel.DataAnnotations.ValidationContext.prototype.get_MemberName, $arrayinit([], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_MemberName", System.ComponentModel.DataAnnotations.ValidationContext.prototype.set_MemberName, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", String, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("Items", System.Collections.Generic.IDictionary$2, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Items", System.ComponentModel.DataAnnotations.ValidationContext.prototype.get_Items, $arrayinit([], System.Reflection.ParameterInfo), System.Collections.Generic.IDictionary$2, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), null, $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute))], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false, false, false, false);return this.$type;};
    $t.$StaticInitializer = function() {
        if ($t.$isStaticInitialized)
            return;
        $t.$isStaticInitialized = true;
        System.Object.$StaticInitializer();
    };
    $p.$ctor = function(instance) {
        this._serviceProvider = null;
        this._objectInstance = null;
        this._memberName = null;
        this._displayName = null;
        this._items = null;
        System.ComponentModel.DataAnnotations.ValidationContext.prototype.$ctor$2.call(
            this, 
            instance, 
            null, 
            null
        );
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function(instance) {
        return new $p.$ctor.$type(this, instance);
    };
    $p.$ctor$1 = function(instance, items) {
        this._serviceProvider = null;
        this._objectInstance = null;
        this._memberName = null;
        this._displayName = null;
        this._items = null;
        System.ComponentModel.DataAnnotations.ValidationContext.prototype.$ctor$2.call(
            this, 
            instance, 
            null, 
            items
        );
    };
    $p.$ctor$1.$type = $t;
    $p.$ctor$1.$new = function(instance, items) {
        return new $p.$ctor$1.$type(this, instance, items);
    };
    $p.$ctor$2 = function(instance, serviceProvider, items) {
        this._serviceProvider = null;
        this._objectInstance = null;
        this._memberName = null;
        this._displayName = null;
        this._items = null;
        System.Object.prototype.$ctor.call(this);
        if (instance == null) {
            throw System.ArgumentNullException.prototype.$ctor.$new("instance").InternalInit(new Error());
        }
        if (serviceProvider != null) {
            this.InitializeServiceProvider($delegate(this, System.Func$2$(System.Type, System.Object), function(serviceType) {
                return serviceProvider.System$IServiceProvider$GetService(serviceType);
            }));
        }
        if (items != null) {
            this._items = System.Collections.Generic.Dictionary$2$(System.Object, System.Object).prototype.$ctor$1.$new(items);
        }
        else {
            this._items = System.Collections.Generic.Dictionary$2$(System.Object, System.Object).prototype.$ctor.$new();
        }
        this._objectInstance = instance;
    };
    $p.$ctor$2.$type = $t;
    $p.$ctor$2.$new = function(instance, serviceProvider, items) {
        return new $p.$ctor$2.$type(
            this, 
            instance, 
            serviceProvider, 
            items
        );
    };
    $p.get_ObjectInstance = function() {
        return this._objectInstance;
    };
    $p.get_ObjectType = function() {
        return this.get_ObjectInstance().GetType();
    };
    $p.get_DisplayName = function() {
        if (String.IsNullOrEmpty(this._displayName)) {
            this._displayName = this.GetDisplayName();
            if (String.IsNullOrEmpty(this._displayName)) {
                this._displayName = this.get_MemberName();
                if (String.IsNullOrEmpty(this._displayName)) {
                    this._displayName = this.get_ObjectType().get_Name();
                }
            }
        }
        return this._displayName;
    };
    $p.set_DisplayName = function(value) {
        if (String.IsNullOrEmpty(value)) {
            throw System.ArgumentNullException.prototype.$ctor.$new("value").InternalInit(new Error());
        }
        this._displayName = value;
        return value;
    };
    $p.get_MemberName = function() {
        return this._memberName;
    };
    $p.set_MemberName = function(value) {
        this._memberName = value;
        return value;
    };
    $p.get_Items = function() {
        return this._items;
    };
    $p.GetDisplayName = function() {
        var displayName = null;
        var store = System.ComponentModel.DataAnnotations.ValidationAttributeStore().get_Instance();
        var displayAttribute = null;
        if (String.IsNullOrEmpty(this._memberName)) {
            displayAttribute = store.GetTypeDisplayAttribute(this);
        }
        else
            if (store.IsPropertyContext(this)) {
                displayAttribute = store.GetPropertyDisplayAttribute(this);
            }
        if (displayAttribute != null) {
            displayName = displayAttribute.GetName();
        }
        return displayName || this.get_MemberName();
    };
    $p.InitializeServiceProvider = function(serviceProvider) {
        this._serviceProvider = serviceProvider;
    };
    $p.GetService = function(serviceType) {
        var service = null;
        if (service == null && this._serviceProvider != null) {
            service = this._serviceProvider(serviceType);
        }
        return service;
    };
    $p.System$IServiceProvider$GetService = $p.GetService;
}).call(null, System.ComponentModel.DataAnnotations.ValidationContext, System.ComponentModel.DataAnnotations.ValidationContext.prototype);
$System$ComponentModel$DataAnnotations$AssemblyTypes.push(System.ComponentModel.DataAnnotations.ValidationContext);
System.ComponentModel.DataAnnotations.ValidationException = $define("System.ComponentModel.DataAnnotations.ValidationException", System.Exception);
(System.ComponentModel.DataAnnotations.ValidationException.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$System$ComponentModel$DataAnnotations$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Exception;
    $p.$typeName = "System.ComponentModel.DataAnnotations.ValidationException";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("ValidationException", $arrayinit([], System.Attribute));this.$type.Init("System.ComponentModel.DataAnnotations.ValidationException", System.Enum.InternalToObject(System.Reflection.TypeAttributes, System.Reflection.TypeAttributes().Public.GetValue() | System.Reflection.TypeAttributes().Class.GetValue()), System.ComponentModel.DataAnnotations.ValidationException, System.Exception, $arrayinit([], System.Type), null, $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("_validationResult", System.ComponentModel.DataAnnotations.ValidationResult, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("$ValidationAttribute$k__BackingField", System.ComponentModel.DataAnnotations.ValidationAttribute, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("$Value$k__BackingField", System.Object, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("get_ValidationAttribute", System.ComponentModel.DataAnnotations.ValidationException.prototype.get_ValidationAttribute, $arrayinit([], System.Reflection.ParameterInfo), System.ComponentModel.DataAnnotations.ValidationAttribute, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_ValidationAttribute", System.ComponentModel.DataAnnotations.ValidationException.prototype.set_ValidationAttribute, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.ComponentModel.DataAnnotations.ValidationAttribute, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Private, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_ValidationResult", System.ComponentModel.DataAnnotations.ValidationException.prototype.get_ValidationResult, $arrayinit([], System.Reflection.ParameterInfo), System.ComponentModel.DataAnnotations.ValidationResult, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_Value", System.ComponentModel.DataAnnotations.ValidationException.prototype.get_Value, $arrayinit([], System.Reflection.ParameterInfo), System.Object, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Value", System.ComponentModel.DataAnnotations.ValidationException.prototype.set_Value, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Object, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Private, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor$3", System.ComponentModel.DataAnnotations.ValidationException.prototype.$ctor$3, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("validationResult", System.ComponentModel.DataAnnotations.ValidationResult, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("validatingAttribute", System.ComponentModel.DataAnnotations.ValidationAttribute, 1, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Object, 2, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor$4", System.ComponentModel.DataAnnotations.ValidationException.prototype.$ctor$4, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("errorMessage", String, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("validatingAttribute", System.ComponentModel.DataAnnotations.ValidationAttribute, 1, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Object, 2, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", System.ComponentModel.DataAnnotations.ValidationException.prototype.$ctor, $arrayinit([], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor$1", System.ComponentModel.DataAnnotations.ValidationException.prototype.$ctor$1, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("message", String, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor$2", System.ComponentModel.DataAnnotations.ValidationException.prototype.$ctor$2, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("message", String, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("innerException", System.Exception, 1, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.PropertyInfo.prototype.$ctor.$new("ValidationAttribute", System.ComponentModel.DataAnnotations.ValidationAttribute, System.Reflection.MethodInfo.prototype.$ctor.$new("get_ValidationAttribute", System.ComponentModel.DataAnnotations.ValidationException.prototype.get_ValidationAttribute, $arrayinit([], System.Reflection.ParameterInfo), System.ComponentModel.DataAnnotations.ValidationAttribute, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_ValidationAttribute", System.ComponentModel.DataAnnotations.ValidationException.prototype.set_ValidationAttribute, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.ComponentModel.DataAnnotations.ValidationAttribute, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Private, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("ValidationResult", System.ComponentModel.DataAnnotations.ValidationResult, System.Reflection.MethodInfo.prototype.$ctor.$new("get_ValidationResult", System.ComponentModel.DataAnnotations.ValidationException.prototype.get_ValidationResult, $arrayinit([], System.Reflection.ParameterInfo), System.ComponentModel.DataAnnotations.ValidationResult, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), null, $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("Value", System.Object, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Value", System.ComponentModel.DataAnnotations.ValidationException.prototype.get_Value, $arrayinit([], System.Reflection.ParameterInfo), System.Object, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Value", System.ComponentModel.DataAnnotations.ValidationException.prototype.set_Value, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Object, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Private, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute))], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false, false, false, false);return this.$type;};
    $t.$StaticInitializer = function() {
        if ($t.$isStaticInitialized)
            return;
        $t.$isStaticInitialized = true;
        System.Exception.$StaticInitializer();
    };
    $p.get_ValidationAttribute = function() {return this.$ValidationAttribute$k__BackingField;};
    $p.set_ValidationAttribute = function(value) {this.$ValidationAttribute$k__BackingField = value;return value;};
    $p.get_ValidationResult = function() {
        if (this._validationResult == null)
            this._validationResult = System.ComponentModel.DataAnnotations.ValidationResult.prototype.$ctor$1.$new(this.get_Message());
        return this._validationResult;
    };
    $p.get_Value = function() {return this.$Value$k__BackingField;};
    $p.set_Value = function(value) {this.$Value$k__BackingField = value;return value;};
    $p.$ctor$3 = function(validationResult, validatingAttribute, value) {
        this._validationResult = null;
        this.$ValidationAttribute$k__BackingField = null;
        this.$Value$k__BackingField = null;
        System.ComponentModel.DataAnnotations.ValidationException.prototype.$ctor$4.call(
            this, 
            validationResult.get_ErrorMessage(), 
            validatingAttribute, 
            value
        );
        this._validationResult = validationResult;
    };
    $p.$ctor$3.$type = $t;
    $p.$ctor$3.$new = function(validationResult, validatingAttribute, value) {
        return new $p.$ctor$3.$type(
            this, 
            validationResult, 
            validatingAttribute, 
            value
        );
    };
    $p.$ctor$4 = function(errorMessage, validatingAttribute, value) {
        this._validationResult = null;
        this.$ValidationAttribute$k__BackingField = null;
        this.$Value$k__BackingField = null;
        System.Exception.prototype.$ctor$1.call(this, errorMessage);
        this.set_Value(value);
        this.set_ValidationAttribute(validatingAttribute);
    };
    $p.$ctor$4.$type = $t;
    $p.$ctor$4.$new = function(errorMessage, validatingAttribute, value) {
        return new $p.$ctor$4.$type(
            this, 
            errorMessage, 
            validatingAttribute, 
            value
        );
    };
    $p.$ctor = function() {
        this._validationResult = null;
        this.$ValidationAttribute$k__BackingField = null;
        this.$Value$k__BackingField = null;
        System.Exception.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.$ctor$1 = function(message) {
        this._validationResult = null;
        this.$ValidationAttribute$k__BackingField = null;
        this.$Value$k__BackingField = null;
        System.Exception.prototype.$ctor$1.call(this, message);
    };
    $p.$ctor$1.$type = $t;
    $p.$ctor$1.$new = function(message) {
        return new $p.$ctor$1.$type(this, message);
    };
    $p.$ctor$2 = function(message, innerException) {
        this._validationResult = null;
        this.$ValidationAttribute$k__BackingField = null;
        this.$Value$k__BackingField = null;
        System.Exception.prototype.$ctor$2.call(this, message, innerException);
    };
    $p.$ctor$2.$type = $t;
    $p.$ctor$2.$new = function(message, innerException) {
        return new $p.$ctor$2.$type(this, message, innerException);
    };
}).call(null, System.ComponentModel.DataAnnotations.ValidationException, System.ComponentModel.DataAnnotations.ValidationException.prototype);
$System$ComponentModel$DataAnnotations$AssemblyTypes.push(System.ComponentModel.DataAnnotations.ValidationException);
System.ComponentModel.DataAnnotations.ValidationResult = $define("System.ComponentModel.DataAnnotations.ValidationResult", System.Object);
(System.ComponentModel.DataAnnotations.ValidationResult.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$System$ComponentModel$DataAnnotations$GetAssembly;
    $p.$type = $t;
    $t.$baseType = System.Object;
    $p.$typeName = "System.ComponentModel.DataAnnotations.ValidationResult";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("ValidationResult", $arrayinit([], System.Attribute));this.$type.Init("System.ComponentModel.DataAnnotations.ValidationResult", System.Enum.InternalToObject(System.Reflection.TypeAttributes, System.Reflection.TypeAttributes().Public.GetValue() | System.Reflection.TypeAttributes().Class.GetValue()), System.ComponentModel.DataAnnotations.ValidationResult, System.Object, $arrayinit([], System.Type), null, $arrayinit([System.Reflection.FieldInfo.prototype.$ctor.$new("_memberNames", System.Collections.Generic.IEnumerable$1, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("_errorMessage", String, System.Reflection.FieldAttributes().Private, null, $arrayinit([], System.Attribute)), System.Reflection.FieldInfo.prototype.$ctor.$new("Success", System.ComponentModel.DataAnnotations.ValidationResult, System.Enum.InternalToObject(System.Reflection.FieldAttributes, System.Enum.InternalToObject(System.Reflection.FieldAttributes, System.Reflection.FieldAttributes().Public.GetValue() | System.Reflection.FieldAttributes().Static.GetValue()).GetValue() | System.Reflection.FieldAttributes().InitOnly.GetValue()), null, $arrayinit([], System.Attribute))], System.Reflection.FieldInfo), $arrayinit([System.Reflection.MethodInfo.prototype.$ctor.$new("get_MemberNames", System.ComponentModel.DataAnnotations.ValidationResult.prototype.get_MemberNames, $arrayinit([], System.Reflection.ParameterInfo), System.Collections.Generic.IEnumerable$1, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("get_ErrorMessage", System.ComponentModel.DataAnnotations.ValidationResult.prototype.get_ErrorMessage, $arrayinit([], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_ErrorMessage", System.ComponentModel.DataAnnotations.ValidationResult.prototype.set_ErrorMessage, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", String, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("ToString", System.ComponentModel.DataAnnotations.ValidationResult.prototype.ToString, $arrayinit([], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor$1", System.ComponentModel.DataAnnotations.ValidationResult.prototype.$ctor$1, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("errorMessage", String, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor$2", System.ComponentModel.DataAnnotations.ValidationResult.prototype.$ctor$2, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("errorMessage", String, 0, 0, null, $arrayinit([], System.Attribute)), System.Reflection.ParameterInfo.prototype.$ctor.$new("memberNames", System.Collections.Generic.IEnumerable$1$(String), 1, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", System.ComponentModel.DataAnnotations.ValidationResult.prototype.$ctor, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("validationResult", System.ComponentModel.DataAnnotations.ValidationResult, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Reflection.MethodAttributes().Family, $arrayinit([], System.Attribute))], System.Reflection.MethodInfo), $arrayinit([System.Reflection.PropertyInfo.prototype.$ctor.$new("MemberNames", System.Collections.Generic.IEnumerable$1, System.Reflection.MethodInfo.prototype.$ctor.$new("get_MemberNames", System.ComponentModel.DataAnnotations.ValidationResult.prototype.get_MemberNames, $arrayinit([], System.Reflection.ParameterInfo), System.Collections.Generic.IEnumerable$1, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), null, $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute)), System.Reflection.PropertyInfo.prototype.$ctor.$new("ErrorMessage", String, System.Reflection.MethodInfo.prototype.$ctor.$new("get_ErrorMessage", System.ComponentModel.DataAnnotations.ValidationResult.prototype.get_ErrorMessage, $arrayinit([], System.Reflection.ParameterInfo), String, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), System.Reflection.MethodInfo.prototype.$ctor.$new("set_ErrorMessage", System.ComponentModel.DataAnnotations.ValidationResult.prototype.set_ErrorMessage, $arrayinit([System.Reflection.ParameterInfo.prototype.$ctor.$new("value", String, 0, 0, null, $arrayinit([], System.Attribute))], System.Reflection.ParameterInfo), System.Void, System.Reflection.MethodAttributes().Public, $arrayinit([], System.Attribute)), $arrayinit([], System.Reflection.ParameterInfo), $arrayinit([], System.Attribute))], System.Reflection.PropertyInfo), $arrayinit([], System.Reflection.EventInfo), false, false, false, false);return this.$type;};
    $t.$StaticInitializer = function() {
        if ($t.$isStaticInitialized)
            return;
        $t.$isStaticInitialized = true;
        System.Object.$StaticInitializer();
    };
    $p.get_MemberNames = function() {
        return this._memberNames;
    };
    $p.get_ErrorMessage = function() {
        return this._errorMessage;
    };
    $p.set_ErrorMessage = function(value) {
        this._errorMessage = value;
        return value;
    };
    $p.$ctor$1 = function(errorMessage) {
        this._memberNames = null;
        this._errorMessage = null;
        System.ComponentModel.DataAnnotations.ValidationResult.prototype.$ctor$2.call(this, errorMessage, null);
    };
    $p.$ctor$1.$type = $t;
    $p.$ctor$1.$new = function(errorMessage) {
        return new $p.$ctor$1.$type(this, errorMessage);
    };
    $p.$ctor$2 = function(errorMessage, memberNames) {
        this._memberNames = null;
        this._errorMessage = null;
        System.Object.prototype.$ctor.call(this);
        this._errorMessage = errorMessage;
        this._memberNames = memberNames || $cast($array(String), $arrayinit(new Array(0), String));
    };
    $p.$ctor$2.$type = $t;
    $p.$ctor$2.$new = function(errorMessage, memberNames) {
        return new $p.$ctor$2.$type(this, errorMessage, memberNames);
    };
    $p.$ctor = function(validationResult) {
        this._memberNames = null;
        this._errorMessage = null;
        System.Object.prototype.$ctor.call(this);
        if (validationResult == null)
            throw System.ArgumentNullException.prototype.$ctor.$new("validationResult").InternalInit(new Error());
        this._errorMessage = validationResult._errorMessage;
        this._memberNames = validationResult._memberNames;
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function(validationResult) {
        return new $p.$ctor.$type(this, validationResult);
    };
    $p.ToString = function() {
        return this.get_ErrorMessage() || System.Object.prototype.ToString.call(this);
    };
}).call(null, System.ComponentModel.DataAnnotations.ValidationResult, System.ComponentModel.DataAnnotations.ValidationResult.prototype);
$System$ComponentModel$DataAnnotations$AssemblyTypes.push(System.ComponentModel.DataAnnotations.ValidationResult);
