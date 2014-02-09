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
