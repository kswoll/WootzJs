"use strict";
var $WootzJs$Compiler$Tests$Assembly = null;
var $WootzJs$Compiler$Tests$AssemblyTypes = [];
window.$WootzJs$Compiler$Tests$GetAssembly = function() {
    if ($WootzJs$Compiler$Tests$Assembly == null)
        $WootzJs$Compiler$Tests$Assembly = System.Reflection.Assembly.prototype.$ctor.$new("WootzJs.Compiler.Tests", $WootzJs$Compiler$Tests$AssemblyTypes);
    return $WootzJs$Compiler$Tests$Assembly;
};
$assemblies.push(window.$WootzJs$Compiler$Tests$GetAssembly);
window.WootzJs = {};
WootzJs.Compiler = {};
WootzJs.Compiler.Tests = {};
WootzJs.Compiler.Tests.Collections = {};
WootzJs.Compiler.Tests.Collections.Generic = {};
WootzJs.Compiler.Tests.Linq = {};
WootzJs.Compiler.Tests.Linq.Expressions = {};
WootzJs.Compiler.Tests.Reflection = {};
WootzJs.Compiler.Tests.Text = {};
window.$AnonymousType$1 = function $AnonymousType$1($constructor) {
    if (!$AnonymousType$1.$isStaticInitialized && ($constructor != null || !(this instanceof $AnonymousType$1))) {
        $AnonymousType$1.$isStaticInitialized = true;
        $AnonymousType$1.$StaticInitializer();
    }
    if ($constructor != null)
        $constructor.apply(this, Array.prototype.slice.call(arguments, 1));
    if (!(this instanceof $AnonymousType$1))
        return $AnonymousType$1;
};
$AnonymousType$1.prototype = new System.Object();
($AnonymousType$1.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
    $p.$type = $AnonymousType$1;
    $t.$baseType = System.Object;
    $p.$typeName = "$AnonymousType$1";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("", []);this.$type.Init("$AnonymousType$1", $AnonymousType$1, System.Object, [], [], [System.Reflection.MethodInfo.prototype.$ctor.$new("get_MyProperty", $AnonymousType$1.prototype.get_MyProperty, [], String, System.Reflection.MethodAttributes().Public, [])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", $AnonymousType$1.prototype.$ctor, [System.Reflection.ParameterInfo.prototype.$ctor.$new("MyProperty", String, 0, 0, null, [])], System.Reflection.MethodAttributes().Public, [])], [System.Reflection.PropertyInfo.prototype.$ctor.$new("MyProperty", String, System.Reflection.MethodInfo.prototype.$ctor.$new("get_MyProperty", $AnonymousType$1.prototype.get_MyProperty, [], String, System.Reflection.MethodAttributes().Public, []), null, [], [])], [], false);return this.$type;};
    $t.$StaticInitializer = function() {
    };
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.$MyProperty$k__BackingField = null;
    $p.get_MyProperty = function() {
        return this.$MyProperty$k__BackingField;
    };
    $p.set_MyProperty = function(value) {
        this.$MyProperty$k__BackingField = value;
    };
}).call(null, $AnonymousType$1, $AnonymousType$1.prototype);
$WootzJs$Compiler$Tests$AssemblyTypes.push($AnonymousType$1);
WootzJs.Compiler.Tests.AnonymousTypeTests = $define("WootzJs.Compiler.Tests.AnonymousTypeTests");
WootzJs.Compiler.Tests.AnonymousTypeTests.prototype = new System.Object();
(WootzJs.Compiler.Tests.AnonymousTypeTests.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
    $p.$type = WootzJs.Compiler.Tests.AnonymousTypeTests;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Compiler.Tests.AnonymousTypeTests";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("AnonymousTypeTests", [WootzJs.Compiler.Tests.TestFixtureAttribute.prototype.$ctor.$new()]);this.$type.Init("WootzJs.Compiler.Tests.AnonymousTypeTests", WootzJs.Compiler.Tests.AnonymousTypeTests, System.Object, [], [], [System.Reflection.MethodInfo.prototype.$ctor.$new("OneProperty", WootzJs.Compiler.Tests.AnonymousTypeTests.prototype.OneProperty, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.AnonymousTypeTests.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
    $t.$StaticInitializer = function() {
    };
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.OneProperty = function() {
        var o = (function() {
            var $obj$ = $AnonymousType$1.prototype.$ctor.$new();
            $obj$.$MyProperty$k__BackingField = "foo";
            return $obj$;
        }).call(this);
        QUnit.equal(o.get_MyProperty(), "foo");
    };
}).call(null, WootzJs.Compiler.Tests.AnonymousTypeTests, WootzJs.Compiler.Tests.AnonymousTypeTests.prototype);
$WootzJs$Compiler$Tests$AssemblyTypes.push(WootzJs.Compiler.Tests.AnonymousTypeTests);
WootzJs.Compiler.Tests.ArrayTests = $define("WootzJs.Compiler.Tests.ArrayTests");
WootzJs.Compiler.Tests.ArrayTests.prototype = new System.Object();
(WootzJs.Compiler.Tests.ArrayTests.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
    $p.$type = WootzJs.Compiler.Tests.ArrayTests;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Compiler.Tests.ArrayTests";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("ArrayTests", [WootzJs.Compiler.Tests.TestFixtureAttribute.prototype.$ctor.$new()]);this.$type.Init("WootzJs.Compiler.Tests.ArrayTests", WootzJs.Compiler.Tests.ArrayTests, System.Object, [], [], [System.Reflection.MethodInfo.prototype.$ctor.$new("LengthProperty", WootzJs.Compiler.Tests.ArrayTests.prototype.LengthProperty, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("ArrayIndex", WootzJs.Compiler.Tests.ArrayTests.prototype.ArrayIndex, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("ArrayIndexSet", WootzJs.Compiler.Tests.ArrayTests.prototype.ArrayIndexSet, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("ArrayCopy", WootzJs.Compiler.Tests.ArrayTests.prototype.ArrayCopy, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("StringArrayType", WootzJs.Compiler.Tests.ArrayTests.prototype.StringArrayType, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.ArrayTests.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
    $t.$StaticInitializer = function() {
    };
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.LengthProperty = function() {
        var array = System.Object.$$InitializeArray(["1", "2", "3"], String);
        QUnit.equal(array.length, 3);
    };
    $p.ArrayIndex = function() {
        var array = System.Object.$$InitializeArray(["1", "2", "3"], String);
        QUnit.equal(array[2], "3");
    };
    $p.ArrayIndexSet = function() {
        var array = System.Object.$$InitializeArray(["1", "2", "3"], String);
        array[2] = "10";
        QUnit.equal(array[2], "10");
    };
    $p.ArrayCopy = function() {
        var array = System.Object.$$InitializeArray(["1", "2", "3"], String);
        var newArray = new Array(2);
        array.CopyTo(newArray, 1);
        QUnit.equal(newArray[0], "2");
        QUnit.equal(newArray[1], "3");
    };
    $p.StringArrayType = function() {
        var array = System.Object.$$InitializeArray(["1", "2", "3"], String);
        QUnit.equal(array.GetType().get_Name(), "String[]");
    };
}).call(null, WootzJs.Compiler.Tests.ArrayTests, WootzJs.Compiler.Tests.ArrayTests.prototype);
$WootzJs$Compiler$Tests$AssemblyTypes.push(WootzJs.Compiler.Tests.ArrayTests);
WootzJs.Compiler.Tests.AsExpressionTests = $define("WootzJs.Compiler.Tests.AsExpressionTests");
WootzJs.Compiler.Tests.AsExpressionTests.prototype = new System.Object();
(WootzJs.Compiler.Tests.AsExpressionTests.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
    $p.$type = WootzJs.Compiler.Tests.AsExpressionTests;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Compiler.Tests.AsExpressionTests";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("AsExpressionTests", [WootzJs.Compiler.Tests.TestFixtureAttribute.prototype.$ctor.$new()]);this.$type.Init("WootzJs.Compiler.Tests.AsExpressionTests", WootzJs.Compiler.Tests.AsExpressionTests, System.Object, [], [], [System.Reflection.MethodInfo.prototype.$ctor.$new("String", WootzJs.Compiler.Tests.AsExpressionTests.prototype.String, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("TestClass", WootzJs.Compiler.Tests.AsExpressionTests.prototype.TestClass, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.AsExpressionTests.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
    $t.$StaticInitializer = function() {
    };
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.String = function() {
        var o = "foo";
        var s = (function() {
            var $as$ = o;
            if (!System.Type.prototype.IsInstanceOfType.call(String.$GetType(), $as$))
                $as$ = null;
            return $as$;
        }).call(this);
        QUnit.ok(String.$GetType().IsInstanceOfType(s));
        QUnit.ok(!(System.Int32.$GetType().IsInstanceOfType(s)));
    };
    $p.TestClass = function() {
        var o = WootzJs.Compiler.Tests.AsExpressionTests.MyClass.prototype.$ctor.$new();
        var myClass = (function() {
            var $as$ = o;
            if (!System.Type.prototype.IsInstanceOfType.call(WootzJs.Compiler.Tests.AsExpressionTests.MyClass.$GetType(), $as$))
                $as$ = null;
            return $as$;
        }).call(this);
        QUnit.ok(WootzJs.Compiler.Tests.AsExpressionTests.MyClass.$GetType().IsInstanceOfType(myClass));
        QUnit.ok(System.Object.$GetType().IsInstanceOfType(myClass));
        QUnit.ok(!(String.$GetType().IsInstanceOfType(myClass)));
    };
    function MyClass($constructor) {
        if (!$t.MyClass.$isStaticInitialized && ($constructor != null || !(this instanceof WootzJs.Compiler.Tests.AsExpressionTests.MyClass))) {
            $t.MyClass.$isStaticInitialized = true;
            $t.MyClass.$StaticInitializer();
        }
        if ($constructor != null)
            $constructor.apply(this, Array.prototype.slice.call(arguments, 1));
        if (!(this instanceof WootzJs.Compiler.Tests.AsExpressionTests.MyClass))
            return $t.MyClass;
    }
    $t.MyClass = MyClass;
    $t.MyClass.prototype = new System.Object();
    ($t.MyClass.$TypeInitializer = function($t, $p) {
        $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
        $p.$type = WootzJs.Compiler.Tests.AsExpressionTests.MyClass;
        $t.$baseType = System.Object;
        $p.$typeName = "WootzJs.Compiler.Tests.AsExpressionTests.MyClass";
        $t.$typeName = $p.$typeName;
        $t.$GetType = function() {
            return System.Type._GetTypeFromTypeFunc(this);
        };
        $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("MyClass", []);this.$type.Init("WootzJs.Compiler.Tests.AsExpressionTests.MyClass", WootzJs.Compiler.Tests.AsExpressionTests.MyClass, System.Object, [], [], [], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.AsExpressionTests.MyClass.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
        $t.$StaticInitializer = function() {
        };
        $p.$ctor = function() {
            System.Object.prototype.$ctor.call(this);
        };
        $p.$ctor.$type = $t;
        $p.$ctor.$new = function() {
            return new $p.$ctor.$type(this);
        };
    }).call($t, $t.MyClass, $t.MyClass.prototype);
    $WootzJs$Compiler$Tests$AssemblyTypes.push($t.MyClass);
}).call(null, WootzJs.Compiler.Tests.AsExpressionTests, WootzJs.Compiler.Tests.AsExpressionTests.prototype);
$WootzJs$Compiler$Tests$AssemblyTypes.push(WootzJs.Compiler.Tests.AsExpressionTests);
WootzJs.Compiler.Tests.Collections.Generic.DictionaryTests = $define("WootzJs.Compiler.Tests.Collections.Generic.DictionaryTests");
WootzJs.Compiler.Tests.Collections.Generic.DictionaryTests.prototype = new System.Object();
(WootzJs.Compiler.Tests.Collections.Generic.DictionaryTests.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
    $p.$type = WootzJs.Compiler.Tests.Collections.Generic.DictionaryTests;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Compiler.Tests.Collections.Generic.DictionaryTests";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("DictionaryTests", [WootzJs.Compiler.Tests.TestFixtureAttribute.prototype.$ctor.$new()]);this.$type.Init("WootzJs.Compiler.Tests.Collections.Generic.DictionaryTests", WootzJs.Compiler.Tests.Collections.Generic.DictionaryTests, System.Object, [], [], [System.Reflection.MethodInfo.prototype.$ctor.$new("Count", WootzJs.Compiler.Tests.Collections.Generic.DictionaryTests.prototype.Count, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("ContainsKey", WootzJs.Compiler.Tests.Collections.Generic.DictionaryTests.prototype.ContainsKey, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("Keys", WootzJs.Compiler.Tests.Collections.Generic.DictionaryTests.prototype.Keys, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("Add", WootzJs.Compiler.Tests.Collections.Generic.DictionaryTests.prototype.Add, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("Set", WootzJs.Compiler.Tests.Collections.Generic.DictionaryTests.prototype.Set, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("DupsDontChangeCount", WootzJs.Compiler.Tests.Collections.Generic.DictionaryTests.prototype.DupsDontChangeCount, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("Remove", WootzJs.Compiler.Tests.Collections.Generic.DictionaryTests.prototype.Remove, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("Clear", WootzJs.Compiler.Tests.Collections.Generic.DictionaryTests.prototype.Clear, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("TryGetValue", WootzJs.Compiler.Tests.Collections.Generic.DictionaryTests.prototype.TryGetValue, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.Collections.Generic.DictionaryTests.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
    $t.$StaticInitializer = function() {
    };
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.Count = function() {
        var dictionary = (System.Collections.Generic.Dictionary$2$(String, System.Int32)).prototype.$ctor.$new();
        dictionary.Add$1("one", 1);
        QUnit.equal(dictionary.get_Count(), 1);
    };
    $p.ContainsKey = function() {
        var dictionary = (System.Collections.Generic.Dictionary$2$(String, System.Int32)).prototype.$ctor.$new();
        dictionary.Add$1("one", 1);
        QUnit.ok(dictionary.ContainsKey("one"));
        QUnit.ok(!dictionary.ContainsKey("two"));
    };
    $p.Keys = function() {
        var dictionary = (System.Collections.Generic.Dictionary$2$(String, System.Int32)).prototype.$ctor.$new();
        dictionary.Add$1("one", 1);
        dictionary.Add$1("two", 2);
        var keys = System.Linq.Enumerable.ToArray(String, dictionary.get_Keys());
        QUnit.ok(keys[0] == "one" || keys[1] == "one");
        QUnit.ok(keys[0] == "two" || keys[1] == "two");
    };
    $p.Add = function() {
        var dictionary = (System.Collections.Generic.Dictionary$2$(String, System.Int32)).prototype.$ctor.$new();
        dictionary.Add$1("one", 1);
        dictionary.Add$1("two", 2);
        QUnit.equal(dictionary.get_Item("one"), 1);
    };
    $p.Set = function() {
        var dictionary = (System.Collections.Generic.Dictionary$2$(String, System.Int32)).prototype.$ctor.$new();
        dictionary.set_Item("one", 1);
        dictionary.set_Item("two", 2);
        QUnit.equal(dictionary.get_Item("one"), 1);
        QUnit.equal(dictionary.get_Item("two"), 2);
    };
    $p.DupsDontChangeCount = function() {
        var dictionary = (System.Collections.Generic.Dictionary$2$(String, System.Int32)).prototype.$ctor.$new();
        dictionary.set_Item("one", 1);
        dictionary.set_Item("one", 2);
        QUnit.equal(dictionary.get_Item("one"), 2);
        QUnit.equal(dictionary.get_Count(), 1);
    };
    $p.Remove = function() {
        var dictionary = (System.Collections.Generic.Dictionary$2$(String, System.Int32)).prototype.$ctor.$new();
        dictionary.set_Item("one", 1);
        dictionary.Remove("one");
        QUnit.equal(dictionary.get_Count(), 0);
    };
    $p.Clear = function() {
        var dictionary = (System.Collections.Generic.Dictionary$2$(String, System.Int32)).prototype.$ctor.$new();
        dictionary.set_Item("one", 1);
        dictionary.Clear();
        QUnit.equal(dictionary.get_Count(), 0);
    };
    $p.TryGetValue = function() {
        var dictionary = (System.Collections.Generic.Dictionary$2$(String, System.Int32)).prototype.$ctor.$new();
        dictionary.set_Item("one", 1);
        dictionary.set_Item("two", 2);
        var i;
        (function() {
            var $anon$1 = {
                value: null
            };
            var $result$ = dictionary.TryGetValue("two", $anon$1);
            i = $anon$1.value;
            return $result$;
        }).call(this);
        QUnit.equal(i, 2);
    };
}).call(null, WootzJs.Compiler.Tests.Collections.Generic.DictionaryTests, WootzJs.Compiler.Tests.Collections.Generic.DictionaryTests.prototype);
$WootzJs$Compiler$Tests$AssemblyTypes.push(WootzJs.Compiler.Tests.Collections.Generic.DictionaryTests);
WootzJs.Compiler.Tests.Collections.Generic.ListTests = $define("WootzJs.Compiler.Tests.Collections.Generic.ListTests");
WootzJs.Compiler.Tests.Collections.Generic.ListTests.prototype = new System.Object();
(WootzJs.Compiler.Tests.Collections.Generic.ListTests.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
    $p.$type = WootzJs.Compiler.Tests.Collections.Generic.ListTests;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Compiler.Tests.Collections.Generic.ListTests";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("ListTests", [WootzJs.Compiler.Tests.TestFixtureAttribute.prototype.$ctor.$new()]);this.$type.Init("WootzJs.Compiler.Tests.Collections.Generic.ListTests", WootzJs.Compiler.Tests.Collections.Generic.ListTests, System.Object, [], [], [System.Reflection.MethodInfo.prototype.$ctor.$new("Add", WootzJs.Compiler.Tests.Collections.Generic.ListTests.prototype.Add, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("Remove", WootzJs.Compiler.Tests.Collections.Generic.ListTests.prototype.Remove, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("IndexOf", WootzJs.Compiler.Tests.Collections.Generic.ListTests.prototype.IndexOf, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("Contains", WootzJs.Compiler.Tests.Collections.Generic.ListTests.prototype.Contains, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("ElementGet", WootzJs.Compiler.Tests.Collections.Generic.ListTests.prototype.ElementGet, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("ElementSet", WootzJs.Compiler.Tests.Collections.Generic.ListTests.prototype.ElementSet, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.Collections.Generic.ListTests.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
    $t.$StaticInitializer = function() {
    };
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.Add = function() {
        var list = (System.Collections.Generic.List$1$(String)).prototype.$ctor.$new();
        list.Add$1("one");
        QUnit.equal(list.get_Item(0), "one");
    };
    $p.Remove = function() {
        var list = (System.Collections.Generic.List$1$(String)).prototype.$ctor.$new();
        list.Add$1("one");
        list.Add$1("two");
        list.Add$1("three");
        QUnit.equal(list.get_Count(), 3);
        list.Remove$1("two");
        QUnit.equal(list.get_Count(), 2);
        QUnit.equal(list.get_Item(0), "one");
        QUnit.equal(list.get_Item(1), "three");
    };
    $p.IndexOf = function() {
        var list = (System.Collections.Generic.List$1$(String)).prototype.$ctor.$new();
        list.Add$1("one");
        list.Add$1("two");
        list.Add$1("three");
        QUnit.equal(0, list.IndexOf$1("one"));
        QUnit.equal(1, list.IndexOf$1("two"));
        QUnit.equal(2, list.IndexOf$1("three"));
        QUnit.equal(-1, list.IndexOf$1("four"));
    };
    $p.Contains = function() {
        var list = (System.Collections.Generic.List$1$(String)).prototype.$ctor.$new();
        list.Add$1("one");
        list.Add$1("two");
        list.Add$1("three");
        QUnit.ok(list.Contains$1("one"));
        QUnit.ok(list.Contains$1("two"));
        QUnit.ok(list.Contains$1("three"));
        QUnit.ok(!list.Contains$1("four"));
    };
    $p.ElementGet = function() {
        var list = (System.Collections.Generic.List$1$(String)).prototype.$ctor.$new();
        list.Add$1("one");
        QUnit.equal(list.get_Item(0), "one");
    };
    $p.ElementSet = function() {
        var list = (System.Collections.Generic.List$1$(String)).prototype.$ctor.$new();
        list.Add$1("one");
        list.set_Item(0, "two");
        QUnit.equal(list.get_Item(0), "two");
    };
}).call(null, WootzJs.Compiler.Tests.Collections.Generic.ListTests, WootzJs.Compiler.Tests.Collections.Generic.ListTests.prototype);
$WootzJs$Compiler$Tests$AssemblyTypes.push(WootzJs.Compiler.Tests.Collections.Generic.ListTests);
WootzJs.Compiler.Tests.ConstructorTests = $define("WootzJs.Compiler.Tests.ConstructorTests");
WootzJs.Compiler.Tests.ConstructorTests.prototype = new System.Object();
(WootzJs.Compiler.Tests.ConstructorTests.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
    $p.$type = WootzJs.Compiler.Tests.ConstructorTests;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Compiler.Tests.ConstructorTests";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("ConstructorTests", [WootzJs.Compiler.Tests.TestFixtureAttribute.prototype.$ctor.$new()]);this.$type.Init("WootzJs.Compiler.Tests.ConstructorTests", WootzJs.Compiler.Tests.ConstructorTests, System.Object, [], [], [System.Reflection.MethodInfo.prototype.$ctor.$new("ConstructorsWithOverloads", WootzJs.Compiler.Tests.ConstructorTests.prototype.ConstructorsWithOverloads, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("InitializedStaticField", WootzJs.Compiler.Tests.ConstructorTests.prototype.InitializedStaticField, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("StaticConstructor", WootzJs.Compiler.Tests.ConstructorTests.prototype.StaticConstructor, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.ConstructorTests.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
    $t.$StaticInitializer = function() {
    };
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.ConstructorsWithOverloads = function() {
        var test1 = WootzJs.Compiler.Tests.ConstructorTests.TestClass.prototype.$ctor.$new();
        var test2 = WootzJs.Compiler.Tests.ConstructorTests.TestClass.prototype.$ctor$2.$new("foo");
        var test3 = WootzJs.Compiler.Tests.ConstructorTests.TestClass.prototype.$ctor$1.$new(5);
        QUnit.equal(test1.get_Arg1(), "none");
        QUnit.equal(test2.get_Arg1(), "string");
        QUnit.equal(test3.get_Arg1(), "int");
    };
    $p.InitializedStaticField = function() {
        QUnit.equal(WootzJs.Compiler.Tests.ConstructorTests.ClassWithStaticInitializedField().InitializedValue, "foo");
    };
    $p.StaticConstructor = function() {
        QUnit.equal(WootzJs.Compiler.Tests.ConstructorTests.ClassWithStaticConstructor().InitializedValue, "foo");
    };
    function TestClass($constructor) {
        if (!$t.TestClass.$isStaticInitialized && ($constructor != null || !(this instanceof WootzJs.Compiler.Tests.ConstructorTests.TestClass))) {
            $t.TestClass.$isStaticInitialized = true;
            $t.TestClass.$StaticInitializer();
        }
        if ($constructor != null)
            $constructor.apply(this, Array.prototype.slice.call(arguments, 1));
        if (!(this instanceof WootzJs.Compiler.Tests.ConstructorTests.TestClass))
            return $t.TestClass;
    }
    $t.TestClass = TestClass;
    $t.TestClass.prototype = new System.Object();
    ($t.TestClass.$TypeInitializer = function($t, $p) {
        $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
        $p.$type = WootzJs.Compiler.Tests.ConstructorTests.TestClass;
        $t.$baseType = System.Object;
        $p.$typeName = "WootzJs.Compiler.Tests.ConstructorTests.TestClass";
        $t.$typeName = $p.$typeName;
        $t.$GetType = function() {
            return System.Type._GetTypeFromTypeFunc(this);
        };
        $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("TestClass", []);this.$type.Init("WootzJs.Compiler.Tests.ConstructorTests.TestClass", WootzJs.Compiler.Tests.ConstructorTests.TestClass, System.Object, [], [System.Reflection.FieldInfo.prototype.$ctor.$new("arg1", String, System.Reflection.FieldAttributes().Private, null, [])], [System.Reflection.MethodInfo.prototype.$ctor.$new("get_Arg1", WootzJs.Compiler.Tests.ConstructorTests.TestClass.prototype.get_Arg1, [], String, System.Reflection.MethodAttributes().Public, [])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.ConstructorTests.TestClass.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, []), System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor$2", WootzJs.Compiler.Tests.ConstructorTests.TestClass.prototype.$ctor$2, [System.Reflection.ParameterInfo.prototype.$ctor.$new("arg1", String, 0, 0, null, [])], System.Reflection.MethodAttributes().Public, []), System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor$1", WootzJs.Compiler.Tests.ConstructorTests.TestClass.prototype.$ctor$1, [System.Reflection.ParameterInfo.prototype.$ctor.$new("arg1", System.Int32, 0, 0, null, [])], System.Reflection.MethodAttributes().Public, [])], [System.Reflection.PropertyInfo.prototype.$ctor.$new("Arg1", String, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Arg1", WootzJs.Compiler.Tests.ConstructorTests.TestClass.prototype.get_Arg1, [], String, System.Reflection.MethodAttributes().Public, []), null, [], [])], [], false);return this.$type;};
        $t.$StaticInitializer = function() {
        };
        $p.arg1 = null;
        $p.$ctor = function() {
            System.Object.prototype.$ctor.call(this);
            this.arg1 = "none";
        };
        $p.$ctor.$type = $t;
        $p.$ctor.$new = function() {
            return new $p.$ctor.$type(this);
        };
        $p.$ctor$2 = function(arg1) {
            System.Object.prototype.$ctor.call(this);
            this.arg1 = "string";
        };
        $p.$ctor$2.$type = $t;
        $p.$ctor$2.$new = function(arg1) {
            return new $p.$ctor$2.$type(this, arg1);
        };
        $p.$ctor$1 = function(arg1) {
            System.Object.prototype.$ctor.call(this);
            this.arg1 = "int";
        };
        $p.$ctor$1.$type = $t;
        $p.$ctor$1.$new = function(arg1) {
            return new $p.$ctor$1.$type(this, arg1);
        };
        $p.get_Arg1 = function() {
            return this.arg1;
        };
    }).call($t, $t.TestClass, $t.TestClass.prototype);
    $WootzJs$Compiler$Tests$AssemblyTypes.push($t.TestClass);
    function ClassWithStaticInitializedField($constructor) {
        if (!$t.ClassWithStaticInitializedField.$isStaticInitialized && ($constructor != null || !(this instanceof WootzJs.Compiler.Tests.ConstructorTests.ClassWithStaticInitializedField))) {
            $t.ClassWithStaticInitializedField.$isStaticInitialized = true;
            $t.ClassWithStaticInitializedField.$StaticInitializer();
        }
        if ($constructor != null)
            $constructor.apply(this, Array.prototype.slice.call(arguments, 1));
        if (!(this instanceof WootzJs.Compiler.Tests.ConstructorTests.ClassWithStaticInitializedField))
            return $t.ClassWithStaticInitializedField;
    }
    $t.ClassWithStaticInitializedField = ClassWithStaticInitializedField;
    $t.ClassWithStaticInitializedField.prototype = new System.Object();
    ($t.ClassWithStaticInitializedField.$TypeInitializer = function($t, $p) {
        $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
        $p.$type = WootzJs.Compiler.Tests.ConstructorTests.ClassWithStaticInitializedField;
        $t.$baseType = System.Object;
        $p.$typeName = "WootzJs.Compiler.Tests.ConstructorTests.ClassWithStaticInitializedField";
        $t.$typeName = $p.$typeName;
        $t.$GetType = function() {
            return System.Type._GetTypeFromTypeFunc(this);
        };
        $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("ClassWithStaticInitializedField", []);this.$type.Init("WootzJs.Compiler.Tests.ConstructorTests.ClassWithStaticInitializedField", WootzJs.Compiler.Tests.ConstructorTests.ClassWithStaticInitializedField, System.Object, [], [System.Reflection.FieldInfo.prototype.$ctor.$new("InitializedValue", String, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static, null, [])], [System.Reflection.MethodInfo.prototype.$ctor.$new("$cctor", WootzJs.Compiler.Tests.ConstructorTests.ClassWithStaticInitializedField.prototype.$cctor, [], System.Void, System.Reflection.MethodAttributes().Private | System.Reflection.MethodAttributes().Static, [])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.ConstructorTests.ClassWithStaticInitializedField.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
        $t.$StaticInitializer = function() {
            WootzJs.Compiler.Tests.ConstructorTests.ClassWithStaticInitializedField.InitializedValue = "foo";
        };
        $p.$ctor = function() {
            System.Object.prototype.$ctor.call(this);
        };
        $p.$ctor.$type = $t;
        $p.$ctor.$new = function() {
            return new $p.$ctor.$type(this);
        };
        $p.InitializedValue = null;
    }).call($t, $t.ClassWithStaticInitializedField, $t.ClassWithStaticInitializedField.prototype);
    $WootzJs$Compiler$Tests$AssemblyTypes.push($t.ClassWithStaticInitializedField);
    function ClassWithStaticConstructor($constructor) {
        if (!$t.ClassWithStaticConstructor.$isStaticInitialized && ($constructor != null || !(this instanceof WootzJs.Compiler.Tests.ConstructorTests.ClassWithStaticConstructor))) {
            $t.ClassWithStaticConstructor.$isStaticInitialized = true;
            $t.ClassWithStaticConstructor.$StaticInitializer();
        }
        if ($constructor != null)
            $constructor.apply(this, Array.prototype.slice.call(arguments, 1));
        if (!(this instanceof WootzJs.Compiler.Tests.ConstructorTests.ClassWithStaticConstructor))
            return $t.ClassWithStaticConstructor;
    }
    $t.ClassWithStaticConstructor = ClassWithStaticConstructor;
    $t.ClassWithStaticConstructor.prototype = new System.Object();
    ($t.ClassWithStaticConstructor.$TypeInitializer = function($t, $p) {
        $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
        $p.$type = WootzJs.Compiler.Tests.ConstructorTests.ClassWithStaticConstructor;
        $t.$baseType = System.Object;
        $p.$typeName = "WootzJs.Compiler.Tests.ConstructorTests.ClassWithStaticConstructor";
        $t.$typeName = $p.$typeName;
        $t.$GetType = function() {
            return System.Type._GetTypeFromTypeFunc(this);
        };
        $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("ClassWithStaticConstructor", []);this.$type.Init("WootzJs.Compiler.Tests.ConstructorTests.ClassWithStaticConstructor", WootzJs.Compiler.Tests.ConstructorTests.ClassWithStaticConstructor, System.Object, [], [System.Reflection.FieldInfo.prototype.$ctor.$new("InitializedValue", String, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static, null, [])], [System.Reflection.MethodInfo.prototype.$ctor.$new("$cctor", WootzJs.Compiler.Tests.ConstructorTests.ClassWithStaticConstructor.prototype.$cctor, [], System.Void, System.Reflection.MethodAttributes().Private | System.Reflection.MethodAttributes().Static, [])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.ConstructorTests.ClassWithStaticConstructor.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
        $t.$StaticInitializer = function() {
            WootzJs.Compiler.Tests.ConstructorTests.ClassWithStaticConstructor().InitializedValue = "foo";
        };
        $p.InitializedValue = null;
        $p.$cctor = function() {
            System.Object.prototype.$ctor.call(this);
            WootzJs.Compiler.Tests.ConstructorTests.ClassWithStaticConstructor().InitializedValue = "foo";
        };
        $p.$cctor.$type = $t;
        $p.$cctor.$new = function() {
            return new $p.$cctor.$type(this);
        };
    }).call($t, $t.ClassWithStaticConstructor, $t.ClassWithStaticConstructor.prototype);
    $WootzJs$Compiler$Tests$AssemblyTypes.push($t.ClassWithStaticConstructor);
}).call(null, WootzJs.Compiler.Tests.ConstructorTests, WootzJs.Compiler.Tests.ConstructorTests.prototype);
$WootzJs$Compiler$Tests$AssemblyTypes.push(WootzJs.Compiler.Tests.ConstructorTests);
WootzJs.Compiler.Tests.DefaultTests = $define("WootzJs.Compiler.Tests.DefaultTests");
WootzJs.Compiler.Tests.DefaultTests.prototype = new System.Object();
(WootzJs.Compiler.Tests.DefaultTests.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
    $p.$type = WootzJs.Compiler.Tests.DefaultTests;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Compiler.Tests.DefaultTests";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("DefaultTests", [WootzJs.Compiler.Tests.TestFixtureAttribute.prototype.$ctor.$new()]);this.$type.Init("WootzJs.Compiler.Tests.DefaultTests", WootzJs.Compiler.Tests.DefaultTests, System.Object, [], [], [System.Reflection.MethodInfo.prototype.$ctor.$new("DefaultInt", WootzJs.Compiler.Tests.DefaultTests.prototype.DefaultInt, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("DefaultChar", WootzJs.Compiler.Tests.DefaultTests.prototype.DefaultChar, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("DefaultBool", WootzJs.Compiler.Tests.DefaultTests.prototype.DefaultBool, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("DefaultObject", WootzJs.Compiler.Tests.DefaultTests.prototype.DefaultObject, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.DefaultTests.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
    $t.$StaticInitializer = function() {
    };
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.DefaultInt = function() {
        var value = 0;
        QUnit.equal(value, 0);
    };
    $p.DefaultChar = function() {
        var value = 0;
        QUnit.equal(value, "");
    };
    $p.DefaultBool = function() {
        var value = false;
        QUnit.equal(value, false);
    };
    $p.DefaultObject = function() {
        var value = null;
        QUnit.equal(value, null);
    };
}).call(null, WootzJs.Compiler.Tests.DefaultTests, WootzJs.Compiler.Tests.DefaultTests.prototype);
$WootzJs$Compiler$Tests$AssemblyTypes.push(WootzJs.Compiler.Tests.DefaultTests);
WootzJs.Compiler.Tests.DelegateTests = $define("WootzJs.Compiler.Tests.DelegateTests");
WootzJs.Compiler.Tests.DelegateTests.prototype = new System.Object();
(WootzJs.Compiler.Tests.DelegateTests.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
    $p.$type = WootzJs.Compiler.Tests.DelegateTests;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Compiler.Tests.DelegateTests";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("DelegateTests", [WootzJs.Compiler.Tests.TestFixtureAttribute.prototype.$ctor.$new()]);this.$type.Init("WootzJs.Compiler.Tests.DelegateTests", WootzJs.Compiler.Tests.DelegateTests, System.Object, [], [], [System.Reflection.MethodInfo.prototype.$ctor.$new("SimpleLambda", WootzJs.Compiler.Tests.DelegateTests.prototype.SimpleLambda, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("AnonymousMethod", WootzJs.Compiler.Tests.DelegateTests.prototype.AnonymousMethod, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("ModifyClosedVariable", WootzJs.Compiler.Tests.DelegateTests.prototype.ModifyClosedVariable, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("CastDelegate", WootzJs.Compiler.Tests.DelegateTests.prototype.CastDelegate, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.DelegateTests.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
    $t.$StaticInitializer = function() {
    };
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.SimpleLambda = function() {
        var myClass = (function() {
            var $obj$ = WootzJs.Compiler.Tests.DelegateTests.MyClass.prototype.$ctor.$new();
            $obj$.set_Name("foo");
            return $obj$;
        }).call(this);
        var lambda = myClass.CreateLambda();
        var name = lambda();
        QUnit.equal(name, "foo");
    };
    $p.AnonymousMethod = function() {
        var lambda = $delegate(this, (System.Func$1$(String)), function() {
            return "foo";
        });
        var name = lambda();
        QUnit.equal(name, "foo");
    };
    $p.ModifyClosedVariable = function() {
        var i = 0;
        var j = 0;
        var action = $delegate(this, System.Action, function() {
            i = 5;
            j = i;
        });
        action();
        QUnit.equal(j, 5);
    };
    $p.CastDelegate = function() {
        var i = 0;
        var action = $delegate(this, System.Action, function() {
            i = 5;
        });
        var delgt = action;
        var action2 = $cast(System.Action, delgt);
        action2();
        QUnit.equal(i, 5);
    };
    function MyClass($constructor) {
        if (!$t.MyClass.$isStaticInitialized && ($constructor != null || !(this instanceof WootzJs.Compiler.Tests.DelegateTests.MyClass))) {
            $t.MyClass.$isStaticInitialized = true;
            $t.MyClass.$StaticInitializer();
        }
        if ($constructor != null)
            $constructor.apply(this, Array.prototype.slice.call(arguments, 1));
        if (!(this instanceof WootzJs.Compiler.Tests.DelegateTests.MyClass))
            return $t.MyClass;
    }
    $t.MyClass = MyClass;
    $t.MyClass.prototype = new System.Object();
    ($t.MyClass.$TypeInitializer = function($t, $p) {
        $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
        $p.$type = WootzJs.Compiler.Tests.DelegateTests.MyClass;
        $t.$baseType = System.Object;
        $p.$typeName = "WootzJs.Compiler.Tests.DelegateTests.MyClass";
        $t.$typeName = $p.$typeName;
        $t.$GetType = function() {
            return System.Type._GetTypeFromTypeFunc(this);
        };
        $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("MyClass", []);this.$type.Init("WootzJs.Compiler.Tests.DelegateTests.MyClass", WootzJs.Compiler.Tests.DelegateTests.MyClass, System.Object, [], [System.Reflection.FieldInfo.prototype.$ctor.$new("$Name$k__BackingField", String, System.Reflection.FieldAttributes().Private, null, [])], [System.Reflection.MethodInfo.prototype.$ctor.$new("get_Name", WootzJs.Compiler.Tests.DelegateTests.MyClass.prototype.get_Name, [], String, System.Reflection.MethodAttributes().Public, []), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Name", WootzJs.Compiler.Tests.DelegateTests.MyClass.prototype.set_Name, [System.Reflection.ParameterInfo.prototype.$ctor.$new("value", String, 0, 0, null, [])], System.Void, System.Reflection.MethodAttributes().Public, []), System.Reflection.MethodInfo.prototype.$ctor.$new("CreateLambda", WootzJs.Compiler.Tests.DelegateTests.MyClass.prototype.CreateLambda, [], System.Func$1, System.Reflection.MethodAttributes().Public, [])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.DelegateTests.MyClass.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, [])], [System.Reflection.PropertyInfo.prototype.$ctor.$new("Name", String, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Name", WootzJs.Compiler.Tests.DelegateTests.MyClass.prototype.get_Name, [], String, System.Reflection.MethodAttributes().Public, []), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Name", WootzJs.Compiler.Tests.DelegateTests.MyClass.prototype.set_Name, [System.Reflection.ParameterInfo.prototype.$ctor.$new("value", String, 0, 0, null, [])], System.Void, System.Reflection.MethodAttributes().Public, []), [], [])], [], false);return this.$type;};
        $t.$StaticInitializer = function() {
        };
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
        $p.set_Name = function(value) {
            this.$Name$k__BackingField = value;
        };
        $p.CreateLambda = function() {
            return $delegate(this, (System.Func$1$(String)), function() {
                return this.get_Name();
            });
        };
    }).call($t, $t.MyClass, $t.MyClass.prototype);
    $WootzJs$Compiler$Tests$AssemblyTypes.push($t.MyClass);
}).call(null, WootzJs.Compiler.Tests.DelegateTests, WootzJs.Compiler.Tests.DelegateTests.prototype);
$WootzJs$Compiler$Tests$AssemblyTypes.push(WootzJs.Compiler.Tests.DelegateTests);
WootzJs.Compiler.Tests.DoWhileTests = $define("WootzJs.Compiler.Tests.DoWhileTests");
WootzJs.Compiler.Tests.DoWhileTests.prototype = new System.Object();
(WootzJs.Compiler.Tests.DoWhileTests.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
    $p.$type = WootzJs.Compiler.Tests.DoWhileTests;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Compiler.Tests.DoWhileTests";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("DoWhileTests", [WootzJs.Compiler.Tests.TestFixtureAttribute.prototype.$ctor.$new()]);this.$type.Init("WootzJs.Compiler.Tests.DoWhileTests", WootzJs.Compiler.Tests.DoWhileTests, System.Object, [], [], [System.Reflection.MethodInfo.prototype.$ctor.$new("DoWhile", WootzJs.Compiler.Tests.DoWhileTests.prototype.DoWhile, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.DoWhileTests.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
    $t.$StaticInitializer = function() {
    };
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.DoWhile = function() {
        var i = 0;
        do {
            i++;
        }
        while (i < 5);
        QUnit.equal(i, 5);
    };
}).call(null, WootzJs.Compiler.Tests.DoWhileTests, WootzJs.Compiler.Tests.DoWhileTests.prototype);
$WootzJs$Compiler$Tests$AssemblyTypes.push(WootzJs.Compiler.Tests.DoWhileTests);
WootzJs.Compiler.Tests.EnumTests = $define("WootzJs.Compiler.Tests.EnumTests");
WootzJs.Compiler.Tests.EnumTests.prototype = new System.Object();
(WootzJs.Compiler.Tests.EnumTests.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
    $p.$type = WootzJs.Compiler.Tests.EnumTests;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Compiler.Tests.EnumTests";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("EnumTests", [WootzJs.Compiler.Tests.TestFixtureAttribute.prototype.$ctor.$new()]);this.$type.Init("WootzJs.Compiler.Tests.EnumTests", WootzJs.Compiler.Tests.EnumTests, System.Object, [], [], [System.Reflection.MethodInfo.prototype.$ctor.$new("Name", WootzJs.Compiler.Tests.EnumTests.prototype.Name, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("Value", WootzJs.Compiler.Tests.EnumTests.prototype.Value, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("Flags", WootzJs.Compiler.Tests.EnumTests.prototype.Flags, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("ThreeFlags", WootzJs.Compiler.Tests.EnumTests.prototype.ThreeFlags, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.EnumTests.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
    $t.$StaticInitializer = function() {
    };
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.Name = function() {
        var s = System.Enum.InternalToObject(WootzJs.Compiler.Tests.EnumTests.TestEnum, WootzJs.Compiler.Tests.EnumTests.TestEnum().One).ToString();
        QUnit.equal(s, "One");
    };
    $p.Value = function() {
        QUnit.equal($cast(System.Int32, WootzJs.Compiler.Tests.EnumTests.TestEnum().One), 0);
        QUnit.equal($cast(System.Int32, WootzJs.Compiler.Tests.EnumTests.TestEnum().Two), 1);
        QUnit.equal($cast(System.Int32, WootzJs.Compiler.Tests.EnumTests.TestEnum().Three), 2);
    };
    $p.Flags = function() {
        var oneAndTwo = WootzJs.Compiler.Tests.EnumTests.FlagsEnum().One | WootzJs.Compiler.Tests.EnumTests.FlagsEnum().Two;
        QUnit.ok((oneAndTwo & WootzJs.Compiler.Tests.EnumTests.FlagsEnum().One) == WootzJs.Compiler.Tests.EnumTests.FlagsEnum().One);
    };
    $p.ThreeFlags = function() {
        var oneAndTwo = WootzJs.Compiler.Tests.EnumTests.FlagsEnum().One | WootzJs.Compiler.Tests.EnumTests.FlagsEnum().Two | WootzJs.Compiler.Tests.EnumTests.FlagsEnum().Three;
        QUnit.ok((oneAndTwo & WootzJs.Compiler.Tests.EnumTests.FlagsEnum().One) == WootzJs.Compiler.Tests.EnumTests.FlagsEnum().One);
    };
    function TestEnum($constructor) {
        if (!$t.TestEnum.$isStaticInitialized && ($constructor != null || !(this instanceof WootzJs.Compiler.Tests.EnumTests.TestEnum))) {
            $t.TestEnum.$isStaticInitialized = true;
            $t.TestEnum.$StaticInitializer();
        }
        if ($constructor != null)
            $constructor.apply(this, Array.prototype.slice.call(arguments, 1));
        if (!(this instanceof WootzJs.Compiler.Tests.EnumTests.TestEnum))
            return $t.TestEnum;
    }
    $t.TestEnum = TestEnum;
    $t.TestEnum.prototype = new System.Enum();
    ($t.TestEnum.$TypeInitializer = function($t, $p) {
        $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
        $p.$type = WootzJs.Compiler.Tests.EnumTests.TestEnum;
        $t.$baseType = System.Enum;
        $p.$typeName = "WootzJs.Compiler.Tests.EnumTests.TestEnum";
        $t.$typeName = $p.$typeName;
        $t.$GetType = function() {
            return System.Type._GetTypeFromTypeFunc(this);
        };
        $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("TestEnum", []);this.$type.Init("WootzJs.Compiler.Tests.EnumTests.TestEnum", WootzJs.Compiler.Tests.EnumTests.TestEnum, System.Enum, [], [System.Reflection.FieldInfo.prototype.$ctor.$new("One", WootzJs.Compiler.Tests.EnumTests.TestEnum, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().Literal, 0, []), System.Reflection.FieldInfo.prototype.$ctor.$new("Two", WootzJs.Compiler.Tests.EnumTests.TestEnum, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().Literal, 1, []), System.Reflection.FieldInfo.prototype.$ctor.$new("Three", WootzJs.Compiler.Tests.EnumTests.TestEnum, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().Literal, 2, [])], [], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.EnumTests.TestEnum.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, [])], [], [], true);return this.$type;};
        $t.$StaticInitializer = function() {
            $t.One = 0;
            $t.One$ = $p.$ctor.$new("One", WootzJs.Compiler.Tests.EnumTests.TestEnum().One);
            $t.Two = WootzJs.Compiler.Tests.EnumTests.TestEnum().One + 1;
            $t.Two$ = $p.$ctor.$new("Two", WootzJs.Compiler.Tests.EnumTests.TestEnum().Two);
            $t.Three = WootzJs.Compiler.Tests.EnumTests.TestEnum().Two + 1;
            $t.Three$ = $p.$ctor.$new("Three", WootzJs.Compiler.Tests.EnumTests.TestEnum().Three);
        };
        $p.$ctor = function(name, value) {
            System.Enum.prototype.$ctor.call(this, name, value);
        };
        $p.$ctor.$type = $t;
        $p.$ctor.$new = function(name, value) {
            return new $p.$ctor.$type(this, name, value);
        };
    }).call($t, $t.TestEnum, $t.TestEnum.prototype);
    $WootzJs$Compiler$Tests$AssemblyTypes.push($t.TestEnum);
    function FlagsEnum($constructor) {
        if (!$t.FlagsEnum.$isStaticInitialized && ($constructor != null || !(this instanceof WootzJs.Compiler.Tests.EnumTests.FlagsEnum))) {
            $t.FlagsEnum.$isStaticInitialized = true;
            $t.FlagsEnum.$StaticInitializer();
        }
        if ($constructor != null)
            $constructor.apply(this, Array.prototype.slice.call(arguments, 1));
        if (!(this instanceof WootzJs.Compiler.Tests.EnumTests.FlagsEnum))
            return $t.FlagsEnum;
    }
    $t.FlagsEnum = FlagsEnum;
    $t.FlagsEnum.prototype = new System.Enum();
    ($t.FlagsEnum.$TypeInitializer = function($t, $p) {
        $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
        $p.$type = WootzJs.Compiler.Tests.EnumTests.FlagsEnum;
        $t.$baseType = System.Enum;
        $p.$typeName = "WootzJs.Compiler.Tests.EnumTests.FlagsEnum";
        $t.$typeName = $p.$typeName;
        $t.$GetType = function() {
            return System.Type._GetTypeFromTypeFunc(this);
        };
        $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("FlagsEnum", [System.FlagsAttribute.prototype.$ctor.$new()]);this.$type.Init("WootzJs.Compiler.Tests.EnumTests.FlagsEnum", WootzJs.Compiler.Tests.EnumTests.FlagsEnum, System.Enum, [], [System.Reflection.FieldInfo.prototype.$ctor.$new("None", WootzJs.Compiler.Tests.EnumTests.FlagsEnum, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().Literal, 0, []), System.Reflection.FieldInfo.prototype.$ctor.$new("One", WootzJs.Compiler.Tests.EnumTests.FlagsEnum, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().Literal, 1, []), System.Reflection.FieldInfo.prototype.$ctor.$new("Two", WootzJs.Compiler.Tests.EnumTests.FlagsEnum, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().Literal, 2, []), System.Reflection.FieldInfo.prototype.$ctor.$new("Three", WootzJs.Compiler.Tests.EnumTests.FlagsEnum, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().Literal, 4, [])], [], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.EnumTests.FlagsEnum.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, [])], [], [], true);return this.$type;};
        $t.$StaticInitializer = function() {
            $t.None = 0;
            $t.None$ = $p.$ctor.$new("None", WootzJs.Compiler.Tests.EnumTests.FlagsEnum().None);
            $t.One = 1 << 0;
            $t.One$ = $p.$ctor.$new("One", WootzJs.Compiler.Tests.EnumTests.FlagsEnum().One);
            $t.Two = 1 << 1;
            $t.Two$ = $p.$ctor.$new("Two", WootzJs.Compiler.Tests.EnumTests.FlagsEnum().Two);
            $t.Three = 1 << 2;
            $t.Three$ = $p.$ctor.$new("Three", WootzJs.Compiler.Tests.EnumTests.FlagsEnum().Three);
        };
        $p.$ctor = function(name, value) {
            System.Enum.prototype.$ctor.call(this, name, value);
        };
        $p.$ctor.$type = $t;
        $p.$ctor.$new = function(name, value) {
            return new $p.$ctor.$type(this, name, value);
        };
    }).call($t, $t.FlagsEnum, $t.FlagsEnum.prototype);
    $WootzJs$Compiler$Tests$AssemblyTypes.push($t.FlagsEnum);
}).call(null, WootzJs.Compiler.Tests.EnumTests, WootzJs.Compiler.Tests.EnumTests.prototype);
$WootzJs$Compiler$Tests$AssemblyTypes.push(WootzJs.Compiler.Tests.EnumTests);
WootzJs.Compiler.Tests.EventTests = $define("WootzJs.Compiler.Tests.EventTests");
WootzJs.Compiler.Tests.EventTests.prototype = new System.Object();
(WootzJs.Compiler.Tests.EventTests.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
    $p.$type = WootzJs.Compiler.Tests.EventTests;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Compiler.Tests.EventTests";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("EventTests", [WootzJs.Compiler.Tests.TestFixtureAttribute.prototype.$ctor.$new()]);this.$type.Init("WootzJs.Compiler.Tests.EventTests", WootzJs.Compiler.Tests.EventTests, System.Object, [], [], [System.Reflection.MethodInfo.prototype.$ctor.$new("BasicEvent", WootzJs.Compiler.Tests.EventTests.prototype.BasicEvent, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("BasicEventExplicitThis", WootzJs.Compiler.Tests.EventTests.prototype.BasicEventExplicitThis, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("MulticastEvent", WootzJs.Compiler.Tests.EventTests.prototype.MulticastEvent, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("MulticastEventRemove", WootzJs.Compiler.Tests.EventTests.prototype.MulticastEventRemove, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("EventAccessor", WootzJs.Compiler.Tests.EventTests.prototype.EventAccessor, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("MulticastEventKeepsDelegateType", WootzJs.Compiler.Tests.EventTests.prototype.MulticastEventKeepsDelegateType, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.EventTests.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
    $t.$StaticInitializer = function() {
    };
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.BasicEvent = function() {
        var o = WootzJs.Compiler.Tests.EventTests.EventClass.prototype.$ctor.$new();
        var success = false;
        o.add_Foo($delegate(this, System.Action, function() {
            return success = true;
        }));
        o.OnFoo();
        QUnit.ok(success);
    };
    $p.BasicEventExplicitThis = function() {
        var o = WootzJs.Compiler.Tests.EventTests.EventClass.prototype.$ctor.$new();
        var success = false;
        o.add_FooThis($delegate(this, System.Action, function() {
            return success = true;
        }));
        o.OnFooThis();
        QUnit.ok(success);
    };
    $p.MulticastEvent = function() {
        var o = WootzJs.Compiler.Tests.EventTests.EventClass.prototype.$ctor.$new();
        var success1 = false;
        var success2 = false;
        o.add_Foo($delegate(this, System.Action, function() {
            return success1 = true;
        }));
        o.add_Foo($delegate(this, System.Action, function() {
            return success2 = true;
        }));
        o.OnFoo();
        QUnit.ok(success1);
        QUnit.ok(success2);
    };
    $p.MulticastEventRemove = function() {
        var o = WootzJs.Compiler.Tests.EventTests.EventClass.prototype.$ctor.$new();
        var success1 = false;
        var success2 = false;
        var foo1 = $delegate(this, System.Action, function() {
            return success1 = true;
        });
        o.add_Foo(foo1);
        o.add_Foo($delegate(this, System.Action, function() {
            return success2 = true;
        }));
        o.remove_Foo(foo1);
        o.OnFoo();
        QUnit.ok(!success1);
        QUnit.ok(success2);
    };
    $p.EventAccessor = function() {
        var eventClass = WootzJs.Compiler.Tests.EventTests.EventClass.prototype.$ctor.$new();
        var ran = false;
        var evt = $delegate(this, System.Action, function() {
            return ran = true;
        });
        eventClass.add_Bar(evt);
        eventClass.OnBar();
        QUnit.ok(ran);
        ran = false;
        eventClass.remove_Bar(evt);
        eventClass.OnBar();
        QUnit.ok(!ran);
    };
    $p.MulticastEventKeepsDelegateType = function() {
        var i = 0;
        var eventClass = WootzJs.Compiler.Tests.EventTests.EventClass.prototype.$ctor.$new();
        eventClass.add_Foo($delegate(this, System.Action, function() {
            return i++;
        }));
        eventClass.add_Foo($delegate(this, System.Action, function() {
            return i++;
        }));
        var action = eventClass.GetFoo();
        QUnit.ok(System.Action.$GetType().IsInstanceOfType(action));
    };
    function EventClass($constructor) {
        if (!$t.EventClass.$isStaticInitialized && ($constructor != null || !(this instanceof WootzJs.Compiler.Tests.EventTests.EventClass))) {
            $t.EventClass.$isStaticInitialized = true;
            $t.EventClass.$StaticInitializer();
        }
        if ($constructor != null)
            $constructor.apply(this, Array.prototype.slice.call(arguments, 1));
        if (!(this instanceof WootzJs.Compiler.Tests.EventTests.EventClass))
            return $t.EventClass;
    }
    $t.EventClass = EventClass;
    $t.EventClass.prototype = new System.Object();
    ($t.EventClass.$TypeInitializer = function($t, $p) {
        $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
        $p.$type = WootzJs.Compiler.Tests.EventTests.EventClass;
        $t.$baseType = System.Object;
        $p.$typeName = "WootzJs.Compiler.Tests.EventTests.EventClass";
        $t.$typeName = $p.$typeName;
        $t.$GetType = function() {
            return System.Type._GetTypeFromTypeFunc(this);
        };
        $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("EventClass", []);this.$type.Init("WootzJs.Compiler.Tests.EventTests.EventClass", WootzJs.Compiler.Tests.EventTests.EventClass, System.Object, [], [System.Reflection.FieldInfo.prototype.$ctor.$new("bar", System.Action, System.Reflection.FieldAttributes().Private, null, [])], [System.Reflection.MethodInfo.prototype.$ctor.$new("add_Foo", WootzJs.Compiler.Tests.EventTests.EventClass.prototype.add_Foo, [System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Action, 0, 0, null, [])], System.Void, System.Reflection.MethodAttributes().Public, []), System.Reflection.MethodInfo.prototype.$ctor.$new("remove_Foo", WootzJs.Compiler.Tests.EventTests.EventClass.prototype.remove_Foo, [System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Action, 0, 0, null, [])], System.Void, System.Reflection.MethodAttributes().Public, []), System.Reflection.MethodInfo.prototype.$ctor.$new("OnFoo", WootzJs.Compiler.Tests.EventTests.EventClass.prototype.OnFoo, [], System.Void, System.Reflection.MethodAttributes().Public, []), System.Reflection.MethodInfo.prototype.$ctor.$new("GetFoo", WootzJs.Compiler.Tests.EventTests.EventClass.prototype.GetFoo, [], System.Action, System.Reflection.MethodAttributes().Public, []), System.Reflection.MethodInfo.prototype.$ctor.$new("add_FooThis", WootzJs.Compiler.Tests.EventTests.EventClass.prototype.add_FooThis, [System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Action, 0, 0, null, [])], System.Void, System.Reflection.MethodAttributes().Public, []), System.Reflection.MethodInfo.prototype.$ctor.$new("remove_FooThis", WootzJs.Compiler.Tests.EventTests.EventClass.prototype.remove_FooThis, [System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Action, 0, 0, null, [])], System.Void, System.Reflection.MethodAttributes().Public, []), System.Reflection.MethodInfo.prototype.$ctor.$new("OnFooThis", WootzJs.Compiler.Tests.EventTests.EventClass.prototype.OnFooThis, [], System.Void, System.Reflection.MethodAttributes().Public, []), System.Reflection.MethodInfo.prototype.$ctor.$new("add_Bar", WootzJs.Compiler.Tests.EventTests.EventClass.prototype.add_Bar, [System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Action, 0, 0, null, [])], System.Void, System.Reflection.MethodAttributes().Public, []), System.Reflection.MethodInfo.prototype.$ctor.$new("remove_Bar", WootzJs.Compiler.Tests.EventTests.EventClass.prototype.remove_Bar, [System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Action, 0, 0, null, [])], System.Void, System.Reflection.MethodAttributes().Public, []), System.Reflection.MethodInfo.prototype.$ctor.$new("OnBar", WootzJs.Compiler.Tests.EventTests.EventClass.prototype.OnBar, [], System.Void, System.Reflection.MethodAttributes().Public, [])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.EventTests.EventClass.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, [])], [], [System.Reflection.EventInfo.prototype.$ctor.$new("Foo", System.Action, System.Reflection.MethodInfo.prototype.$ctor.$new("add_Foo", WootzJs.Compiler.Tests.EventTests.EventClass.prototype.add_Foo, [System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Action, 0, 0, null, [])], System.Void, System.Reflection.MethodAttributes().Public, []), System.Reflection.MethodInfo.prototype.$ctor.$new("remove_Foo", WootzJs.Compiler.Tests.EventTests.EventClass.prototype.remove_Foo, [System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Action, 0, 0, null, [])], System.Void, System.Reflection.MethodAttributes().Public, []), []), System.Reflection.EventInfo.prototype.$ctor.$new("FooThis", System.Action, System.Reflection.MethodInfo.prototype.$ctor.$new("add_FooThis", WootzJs.Compiler.Tests.EventTests.EventClass.prototype.add_FooThis, [System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Action, 0, 0, null, [])], System.Void, System.Reflection.MethodAttributes().Public, []), System.Reflection.MethodInfo.prototype.$ctor.$new("remove_FooThis", WootzJs.Compiler.Tests.EventTests.EventClass.prototype.remove_FooThis, [System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Action, 0, 0, null, [])], System.Void, System.Reflection.MethodAttributes().Public, []), []), System.Reflection.EventInfo.prototype.$ctor.$new("Bar", System.Action, System.Reflection.MethodInfo.prototype.$ctor.$new("add_Bar", WootzJs.Compiler.Tests.EventTests.EventClass.prototype.add_Bar, [System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Action, 0, 0, null, [])], System.Void, System.Reflection.MethodAttributes().Public, []), System.Reflection.MethodInfo.prototype.$ctor.$new("remove_Bar", WootzJs.Compiler.Tests.EventTests.EventClass.prototype.remove_Bar, [System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Action, 0, 0, null, [])], System.Void, System.Reflection.MethodAttributes().Public, []), [])], false);return this.$type;};
        $t.$StaticInitializer = function() {
        };
        $p.$ctor = function() {
            System.Object.prototype.$ctor.call(this);
        };
        $p.$ctor.$type = $t;
        $p.$ctor.$new = function() {
            return new $p.$ctor.$type(this);
        };
        $p.$Foo$k__BackingField = null;
        $p.add_Foo = function(value) {
            this.$Foo$k__BackingField = System.Delegate.Combine(this.$Foo$k__BackingField, value);
        };
        $p.remove_Foo = function(value) {
            this.$Foo$k__BackingField = System.Delegate.Remove(this.$Foo$k__BackingField, value);
        };
        $p.bar = null;
        $p.OnFoo = function() {
            if (this.$Foo$k__BackingField != null)
                this.$Foo$k__BackingField();
        };
        $p.GetFoo = function() {
            return this.$Foo$k__BackingField;
        };
        $p.$FooThis$k__BackingField = null;
        $p.add_FooThis = function(value) {
            this.$FooThis$k__BackingField = System.Delegate.Combine(this.$FooThis$k__BackingField, value);
        };
        $p.remove_FooThis = function(value) {
            this.$FooThis$k__BackingField = System.Delegate.Remove(this.$FooThis$k__BackingField, value);
        };
        $p.OnFooThis = function() {
            if (this.$FooThis$k__BackingField != null)
                this.$FooThis$k__BackingField();
        };
        $p.add_Bar = function(value) {
            this.bar = $cast(System.Action, System.Delegate.Combine(this.bar, value));
        };
        $p.remove_Bar = function(value) {
            this.bar = null;
        };
        $p.OnBar = function() {
            if (this.bar != null)
                this.bar();
        };
    }).call($t, $t.EventClass, $t.EventClass.prototype);
    $WootzJs$Compiler$Tests$AssemblyTypes.push($t.EventClass);
}).call(null, WootzJs.Compiler.Tests.EventTests, WootzJs.Compiler.Tests.EventTests.prototype);
$WootzJs$Compiler$Tests$AssemblyTypes.push(WootzJs.Compiler.Tests.EventTests);
WootzJs.Compiler.Tests.FieldTests = $define("WootzJs.Compiler.Tests.FieldTests");
WootzJs.Compiler.Tests.FieldTests.prototype = new System.Object();
(WootzJs.Compiler.Tests.FieldTests.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
    $p.$type = WootzJs.Compiler.Tests.FieldTests;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Compiler.Tests.FieldTests";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("FieldTests", [WootzJs.Compiler.Tests.TestFixtureAttribute.prototype.$ctor.$new()]);this.$type.Init("WootzJs.Compiler.Tests.FieldTests", WootzJs.Compiler.Tests.FieldTests, System.Object, [], [], [System.Reflection.MethodInfo.prototype.$ctor.$new("FieldsDoNotCollide", WootzJs.Compiler.Tests.FieldTests.prototype.FieldsDoNotCollide, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("StaticFieldsAreStatic", WootzJs.Compiler.Tests.FieldTests.prototype.StaticFieldsAreStatic, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("ReferencedField", WootzJs.Compiler.Tests.FieldTests.prototype.ReferencedField, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.FieldTests.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
    $t.$StaticInitializer = function() {
    };
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.FieldsDoNotCollide = function() {
        var subClass = WootzJs.Compiler.Tests.FieldTests.SubClass.prototype.$ctor.$new();
        QUnit.equal(subClass.GetFoo1(), "base");
        QUnit.equal(subClass.GetFoo2(), "sub");
    };
    $p.StaticFieldsAreStatic = function() {
        WootzJs.Compiler.Tests.FieldTests.StaticFieldClass().MyField = "foo";
        QUnit.equal(WootzJs.Compiler.Tests.FieldTests.StaticFieldClass().MyField, "foo");
    };
    $p.ReferencedField = function() {
        var reference = WootzJs.Compiler.Tests.FieldTests.ReferenceClass.prototype.$ctor.$new();
        reference.set_Target(WootzJs.Compiler.Tests.FieldTests.TargetClass.prototype.$ctor.$new());
        reference.get_Target().set_Foo("foo");
        QUnit.equal(reference.get_Target().get_Foo(), "foo");
    };
    function StaticFieldClass($constructor) {
        if (!$t.StaticFieldClass.$isStaticInitialized && ($constructor != null || !(this instanceof WootzJs.Compiler.Tests.FieldTests.StaticFieldClass))) {
            $t.StaticFieldClass.$isStaticInitialized = true;
            $t.StaticFieldClass.$StaticInitializer();
        }
        if ($constructor != null)
            $constructor.apply(this, Array.prototype.slice.call(arguments, 1));
        if (!(this instanceof WootzJs.Compiler.Tests.FieldTests.StaticFieldClass))
            return $t.StaticFieldClass;
    }
    $t.StaticFieldClass = StaticFieldClass;
    $t.StaticFieldClass.prototype = new System.Object();
    ($t.StaticFieldClass.$TypeInitializer = function($t, $p) {
        $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
        $p.$type = WootzJs.Compiler.Tests.FieldTests.StaticFieldClass;
        $t.$baseType = System.Object;
        $p.$typeName = "WootzJs.Compiler.Tests.FieldTests.StaticFieldClass";
        $t.$typeName = $p.$typeName;
        $t.$GetType = function() {
            return System.Type._GetTypeFromTypeFunc(this);
        };
        $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("StaticFieldClass", []);this.$type.Init("WootzJs.Compiler.Tests.FieldTests.StaticFieldClass", WootzJs.Compiler.Tests.FieldTests.StaticFieldClass, System.Object, [], [System.Reflection.FieldInfo.prototype.$ctor.$new("MyField", String, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static, null, [])], [], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.FieldTests.StaticFieldClass.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
        $t.$StaticInitializer = function() {
        };
        $p.$ctor = function() {
            System.Object.prototype.$ctor.call(this);
        };
        $p.$ctor.$type = $t;
        $p.$ctor.$new = function() {
            return new $p.$ctor.$type(this);
        };
        $p.MyField = null;
    }).call($t, $t.StaticFieldClass, $t.StaticFieldClass.prototype);
    $WootzJs$Compiler$Tests$AssemblyTypes.push($t.StaticFieldClass);
    function BaseClass($constructor) {
        if (!$t.BaseClass.$isStaticInitialized && ($constructor != null || !(this instanceof WootzJs.Compiler.Tests.FieldTests.BaseClass))) {
            $t.BaseClass.$isStaticInitialized = true;
            $t.BaseClass.$StaticInitializer();
        }
        if ($constructor != null)
            $constructor.apply(this, Array.prototype.slice.call(arguments, 1));
        if (!(this instanceof WootzJs.Compiler.Tests.FieldTests.BaseClass))
            return $t.BaseClass;
    }
    $t.BaseClass = BaseClass;
    $t.BaseClass.prototype = new System.Object();
    ($t.BaseClass.$TypeInitializer = function($t, $p) {
        $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
        $p.$type = WootzJs.Compiler.Tests.FieldTests.BaseClass;
        $t.$baseType = System.Object;
        $p.$typeName = "WootzJs.Compiler.Tests.FieldTests.BaseClass";
        $t.$typeName = $p.$typeName;
        $t.$GetType = function() {
            return System.Type._GetTypeFromTypeFunc(this);
        };
        $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("BaseClass", []);this.$type.Init("WootzJs.Compiler.Tests.FieldTests.BaseClass", WootzJs.Compiler.Tests.FieldTests.BaseClass, System.Object, [], [System.Reflection.FieldInfo.prototype.$ctor.$new("foo", String, System.Reflection.FieldAttributes().Private, null, [])], [System.Reflection.MethodInfo.prototype.$ctor.$new("GetFoo1", WootzJs.Compiler.Tests.FieldTests.BaseClass.prototype.GetFoo1, [], String, System.Reflection.MethodAttributes().Public, [])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.FieldTests.BaseClass.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
        $t.$StaticInitializer = function() {
        };
        $p.foo = null;
        $p.$ctor = function() {
            System.Object.prototype.$ctor.call(this);
            this.foo = "base";
        };
        $p.$ctor.$type = $t;
        $p.$ctor.$new = function() {
            return new $p.$ctor.$type(this);
        };
        $p.GetFoo1 = function() {
            return this.foo;
        };
    }).call($t, $t.BaseClass, $t.BaseClass.prototype);
    $WootzJs$Compiler$Tests$AssemblyTypes.push($t.BaseClass);
    function SubClass($constructor) {
        if (!$t.SubClass.$isStaticInitialized && ($constructor != null || !(this instanceof WootzJs.Compiler.Tests.FieldTests.SubClass))) {
            $t.SubClass.$isStaticInitialized = true;
            $t.SubClass.$StaticInitializer();
        }
        if ($constructor != null)
            $constructor.apply(this, Array.prototype.slice.call(arguments, 1));
        if (!(this instanceof WootzJs.Compiler.Tests.FieldTests.SubClass))
            return $t.SubClass;
    }
    $t.SubClass = SubClass;
    $t.SubClass.prototype = new WootzJs.Compiler.Tests.FieldTests.BaseClass();
    ($t.SubClass.$TypeInitializer = function($t, $p) {
        $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
        $p.$type = WootzJs.Compiler.Tests.FieldTests.SubClass;
        $t.$baseType = WootzJs.Compiler.Tests.FieldTests.BaseClass;
        $p.$typeName = "WootzJs.Compiler.Tests.FieldTests.SubClass";
        $t.$typeName = $p.$typeName;
        $t.$GetType = function() {
            return System.Type._GetTypeFromTypeFunc(this);
        };
        $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("SubClass", []);this.$type.Init("WootzJs.Compiler.Tests.FieldTests.SubClass", WootzJs.Compiler.Tests.FieldTests.SubClass, WootzJs.Compiler.Tests.FieldTests.BaseClass, [], [System.Reflection.FieldInfo.prototype.$ctor.$new("foo$1", String, System.Reflection.FieldAttributes().Private, null, [])], [System.Reflection.MethodInfo.prototype.$ctor.$new("GetFoo2", WootzJs.Compiler.Tests.FieldTests.SubClass.prototype.GetFoo2, [], String, System.Reflection.MethodAttributes().Public, [])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.FieldTests.SubClass.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
        $t.$StaticInitializer = function() {
        };
        $p.foo$1 = null;
        $p.$ctor = function() {
            WootzJs.Compiler.Tests.FieldTests.BaseClass.prototype.$ctor.call(this);
            var x = null;
            this.foo$1 = "sub";
        };
        $p.$ctor.$type = $t;
        $p.$ctor.$new = function() {
            return new $p.$ctor.$type(this);
        };
        $p.GetFoo2 = function() {
            this.GetFoo1();
            return this.foo$1;
        };
    }).call($t, $t.SubClass, $t.SubClass.prototype);
    $WootzJs$Compiler$Tests$AssemblyTypes.push($t.SubClass);
    function ReferenceClass($constructor) {
        if (!$t.ReferenceClass.$isStaticInitialized && ($constructor != null || !(this instanceof WootzJs.Compiler.Tests.FieldTests.ReferenceClass))) {
            $t.ReferenceClass.$isStaticInitialized = true;
            $t.ReferenceClass.$StaticInitializer();
        }
        if ($constructor != null)
            $constructor.apply(this, Array.prototype.slice.call(arguments, 1));
        if (!(this instanceof WootzJs.Compiler.Tests.FieldTests.ReferenceClass))
            return $t.ReferenceClass;
    }
    $t.ReferenceClass = ReferenceClass;
    $t.ReferenceClass.prototype = new System.Object();
    ($t.ReferenceClass.$TypeInitializer = function($t, $p) {
        $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
        $p.$type = WootzJs.Compiler.Tests.FieldTests.ReferenceClass;
        $t.$baseType = System.Object;
        $p.$typeName = "WootzJs.Compiler.Tests.FieldTests.ReferenceClass";
        $t.$typeName = $p.$typeName;
        $t.$GetType = function() {
            return System.Type._GetTypeFromTypeFunc(this);
        };
        $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("ReferenceClass", []);this.$type.Init("WootzJs.Compiler.Tests.FieldTests.ReferenceClass", WootzJs.Compiler.Tests.FieldTests.ReferenceClass, System.Object, [], [System.Reflection.FieldInfo.prototype.$ctor.$new("$Target$k__BackingField", WootzJs.Compiler.Tests.FieldTests.TargetClass, System.Reflection.FieldAttributes().Private, null, [])], [System.Reflection.MethodInfo.prototype.$ctor.$new("get_Target", WootzJs.Compiler.Tests.FieldTests.ReferenceClass.prototype.get_Target, [], WootzJs.Compiler.Tests.FieldTests.TargetClass, System.Reflection.MethodAttributes().Public, []), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Target", WootzJs.Compiler.Tests.FieldTests.ReferenceClass.prototype.set_Target, [System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Compiler.Tests.FieldTests.TargetClass, 0, 0, null, [])], System.Void, System.Reflection.MethodAttributes().Public, [])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.FieldTests.ReferenceClass.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, [])], [System.Reflection.PropertyInfo.prototype.$ctor.$new("Target", WootzJs.Compiler.Tests.FieldTests.TargetClass, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Target", WootzJs.Compiler.Tests.FieldTests.ReferenceClass.prototype.get_Target, [], WootzJs.Compiler.Tests.FieldTests.TargetClass, System.Reflection.MethodAttributes().Public, []), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Target", WootzJs.Compiler.Tests.FieldTests.ReferenceClass.prototype.set_Target, [System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Compiler.Tests.FieldTests.TargetClass, 0, 0, null, [])], System.Void, System.Reflection.MethodAttributes().Public, []), [], [])], [], false);return this.$type;};
        $t.$StaticInitializer = function() {
        };
        $p.$ctor = function() {
            System.Object.prototype.$ctor.call(this);
        };
        $p.$ctor.$type = $t;
        $p.$ctor.$new = function() {
            return new $p.$ctor.$type(this);
        };
        $p.$Target$k__BackingField = null;
        $p.get_Target = function() {
            return this.$Target$k__BackingField;
        };
        $p.set_Target = function(value) {
            this.$Target$k__BackingField = value;
        };
    }).call($t, $t.ReferenceClass, $t.ReferenceClass.prototype);
    $WootzJs$Compiler$Tests$AssemblyTypes.push($t.ReferenceClass);
    function TargetClass($constructor) {
        if (!$t.TargetClass.$isStaticInitialized && ($constructor != null || !(this instanceof WootzJs.Compiler.Tests.FieldTests.TargetClass))) {
            $t.TargetClass.$isStaticInitialized = true;
            $t.TargetClass.$StaticInitializer();
        }
        if ($constructor != null)
            $constructor.apply(this, Array.prototype.slice.call(arguments, 1));
        if (!(this instanceof WootzJs.Compiler.Tests.FieldTests.TargetClass))
            return $t.TargetClass;
    }
    $t.TargetClass = TargetClass;
    $t.TargetClass.prototype = new System.Object();
    ($t.TargetClass.$TypeInitializer = function($t, $p) {
        $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
        $p.$type = WootzJs.Compiler.Tests.FieldTests.TargetClass;
        $t.$baseType = System.Object;
        $p.$typeName = "WootzJs.Compiler.Tests.FieldTests.TargetClass";
        $t.$typeName = $p.$typeName;
        $t.$GetType = function() {
            return System.Type._GetTypeFromTypeFunc(this);
        };
        $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("TargetClass", []);this.$type.Init("WootzJs.Compiler.Tests.FieldTests.TargetClass", WootzJs.Compiler.Tests.FieldTests.TargetClass, System.Object, [], [System.Reflection.FieldInfo.prototype.$ctor.$new("$Foo$k__BackingField", String, System.Reflection.FieldAttributes().Private, null, [])], [System.Reflection.MethodInfo.prototype.$ctor.$new("get_Foo", WootzJs.Compiler.Tests.FieldTests.TargetClass.prototype.get_Foo, [], String, System.Reflection.MethodAttributes().Public, []), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Foo", WootzJs.Compiler.Tests.FieldTests.TargetClass.prototype.set_Foo, [System.Reflection.ParameterInfo.prototype.$ctor.$new("value", String, 0, 0, null, [])], System.Void, System.Reflection.MethodAttributes().Public, [])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.FieldTests.TargetClass.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, [])], [System.Reflection.PropertyInfo.prototype.$ctor.$new("Foo", String, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Foo", WootzJs.Compiler.Tests.FieldTests.TargetClass.prototype.get_Foo, [], String, System.Reflection.MethodAttributes().Public, []), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Foo", WootzJs.Compiler.Tests.FieldTests.TargetClass.prototype.set_Foo, [System.Reflection.ParameterInfo.prototype.$ctor.$new("value", String, 0, 0, null, [])], System.Void, System.Reflection.MethodAttributes().Public, []), [], [])], [], false);return this.$type;};
        $t.$StaticInitializer = function() {
        };
        $p.$ctor = function() {
            System.Object.prototype.$ctor.call(this);
        };
        $p.$ctor.$type = $t;
        $p.$ctor.$new = function() {
            return new $p.$ctor.$type(this);
        };
        $p.$Foo$k__BackingField = null;
        $p.get_Foo = function() {
            return this.$Foo$k__BackingField;
        };
        $p.set_Foo = function(value) {
            this.$Foo$k__BackingField = value;
        };
    }).call($t, $t.TargetClass, $t.TargetClass.prototype);
    $WootzJs$Compiler$Tests$AssemblyTypes.push($t.TargetClass);
}).call(null, WootzJs.Compiler.Tests.FieldTests, WootzJs.Compiler.Tests.FieldTests.prototype);
$WootzJs$Compiler$Tests$AssemblyTypes.push(WootzJs.Compiler.Tests.FieldTests);
WootzJs.Compiler.Tests.GenericTests = $define("WootzJs.Compiler.Tests.GenericTests");
WootzJs.Compiler.Tests.GenericTests.prototype = new System.Object();
(WootzJs.Compiler.Tests.GenericTests.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
    $p.$type = WootzJs.Compiler.Tests.GenericTests;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Compiler.Tests.GenericTests";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("GenericTests", [WootzJs.Compiler.Tests.TestFixtureAttribute.prototype.$ctor.$new()]);this.$type.Init("WootzJs.Compiler.Tests.GenericTests", WootzJs.Compiler.Tests.GenericTests, System.Object, [], [], [System.Reflection.MethodInfo.prototype.$ctor.$new("TypeEqualsString", WootzJs.Compiler.Tests.GenericTests.prototype.TypeEqualsString, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("GenericClasses", WootzJs.Compiler.Tests.GenericTests.prototype.GenericClasses, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("GenericClassStaticMethod", WootzJs.Compiler.Tests.GenericTests.prototype.GenericClassStaticMethod, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("GenericOuterClassStaticMethod", WootzJs.Compiler.Tests.GenericTests.prototype.GenericOuterClassStaticMethod, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("TypeFunctionsAreCached", WootzJs.Compiler.Tests.GenericTests.prototype.TypeFunctionsAreCached, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("TopLevelGenericClasses", WootzJs.Compiler.Tests.GenericTests.prototype.TopLevelGenericClasses, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("TopLevelGenericClassStaticMethod", WootzJs.Compiler.Tests.GenericTests.prototype.TopLevelGenericClassStaticMethod, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("TopLevelGenericOuterClassStaticMethod", WootzJs.Compiler.Tests.GenericTests.prototype.TopLevelGenericOuterClassStaticMethod, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("TopLevelTypeFunctionsAreCached", WootzJs.Compiler.Tests.GenericTests.prototype.TopLevelTypeFunctionsAreCached, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("MethodTypeEqualsString", WootzJs.Compiler.Tests.GenericTests.prototype.MethodTypeEqualsString, [], System.Boolean, System.Reflection.MethodAttributes().Private, [])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.GenericTests.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
    $t.$StaticInitializer = function() {
    };
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.TypeEqualsString = function() {
        QUnit.ok(this.MethodTypeEqualsString(String));
        QUnit.ok(!this.MethodTypeEqualsString(System.Int32));
    };
    $p.GenericClasses = function() {
        var stringClass = (WootzJs.Compiler.Tests.GenericTests.GenericClass$1$(String)).prototype.$ctor.$new();
        var intClass = (WootzJs.Compiler.Tests.GenericTests.GenericClass$1$(System.Int32)).prototype.$ctor.$new();
        var simpleClass = (WootzJs.Compiler.Tests.GenericTests.GenericClass$1$(WootzJs.Compiler.Tests.GenericTests.SimpleClass)).prototype.$ctor.$new();
        QUnit.equal(stringClass.GetName(), "String");
        QUnit.equal(intClass.GetName(), "Int32");
        QUnit.equal(simpleClass.GetName(), "SimpleClass");
    };
    $p.GenericClassStaticMethod = function() {
        QUnit.equal((WootzJs.Compiler.Tests.GenericTests.GenericClass$1$(String)).GetUpperName(), "STRING");
        QUnit.equal((WootzJs.Compiler.Tests.GenericTests.GenericClass$1$(System.Int32)).GetUpperName(), "INT32");
        QUnit.equal((WootzJs.Compiler.Tests.GenericTests.GenericClass$1$(WootzJs.Compiler.Tests.GenericTests.SimpleClass)).GetUpperName(), "SIMPLECLASS");
    };
    $p.GenericOuterClassStaticMethod = function() {
        QUnit.equal(((WootzJs.Compiler.Tests.GenericTests.GenericClass$1$(String)).NestedClass$()).GetUpperName(), "STRING");
        QUnit.equal(((WootzJs.Compiler.Tests.GenericTests.GenericClass$1$(System.Int32)).NestedClass$()).GetUpperName(), "INT32");
        QUnit.equal(((WootzJs.Compiler.Tests.GenericTests.GenericClass$1$(WootzJs.Compiler.Tests.GenericTests.SimpleClass)).NestedClass$()).GetUpperName(), "SIMPLECLASS");
    };
    $p.TypeFunctionsAreCached = function() {
        QUnit.ok((WootzJs.Compiler.Tests.GenericTests.GenericClass$1$(String)).$GetType() == (WootzJs.Compiler.Tests.GenericTests.GenericClass$1$(String)).$GetType());
        QUnit.ok(((WootzJs.Compiler.Tests.GenericTests.GenericClass$1$(String)).NestedClass$()).$GetType() == ((WootzJs.Compiler.Tests.GenericTests.GenericClass$1$(String)).NestedClass$()).$GetType());
    };
    $p.TopLevelGenericClasses = function() {
        var stringClass = (WootzJs.Compiler.Tests.TopLevelGenericClass$1$(String)).prototype.$ctor.$new();
        var intClass = (WootzJs.Compiler.Tests.TopLevelGenericClass$1$(System.Int32)).prototype.$ctor.$new();
        var simpleClass = (WootzJs.Compiler.Tests.TopLevelGenericClass$1$(WootzJs.Compiler.Tests.GenericTests.SimpleClass)).prototype.$ctor.$new();
        QUnit.equal(stringClass.GetName(), "String");
        QUnit.equal(intClass.GetName(), "Int32");
        QUnit.equal(simpleClass.GetName(), "SimpleClass");
    };
    $p.TopLevelGenericClassStaticMethod = function() {
        QUnit.equal((WootzJs.Compiler.Tests.TopLevelGenericClass$1$(String)).GetUpperName(), "STRING");
        QUnit.equal((WootzJs.Compiler.Tests.TopLevelGenericClass$1$(System.Int32)).GetUpperName(), "INT32");
        QUnit.equal((WootzJs.Compiler.Tests.TopLevelGenericClass$1$(WootzJs.Compiler.Tests.GenericTests.SimpleClass)).GetUpperName(), "SIMPLECLASS");
    };
    $p.TopLevelGenericOuterClassStaticMethod = function() {
        QUnit.equal(((WootzJs.Compiler.Tests.TopLevelGenericClass$1$(String)).NestedClass$()).GetUpperName(), "STRING");
        QUnit.equal(((WootzJs.Compiler.Tests.TopLevelGenericClass$1$(System.Int32)).NestedClass$()).GetUpperName(), "INT32");
        QUnit.equal(((WootzJs.Compiler.Tests.TopLevelGenericClass$1$(WootzJs.Compiler.Tests.GenericTests.SimpleClass)).NestedClass$()).GetUpperName(), "SIMPLECLASS");
    };
    $p.TopLevelTypeFunctionsAreCached = function() {
        QUnit.ok((WootzJs.Compiler.Tests.TopLevelGenericClass$1$(String)).$GetType() == (WootzJs.Compiler.Tests.TopLevelGenericClass$1$(String)).$GetType());
        QUnit.ok(((WootzJs.Compiler.Tests.TopLevelGenericClass$1$(String)).NestedClass$()).$GetType() == ((WootzJs.Compiler.Tests.TopLevelGenericClass$1$(String)).NestedClass$()).$GetType());
    };
    $p.MethodTypeEqualsString = function(T) {
        return T.$GetType() == String.$GetType();
    };
    function GenericClass$1($constructor) {
        if (!$t.GenericClass$1.$isStaticInitialized && ($constructor != null || !(this instanceof WootzJs.Compiler.Tests.GenericTests.GenericClass$1))) {
            $t.GenericClass$1.$isStaticInitialized = true;
            $t.GenericClass$1.$StaticInitializer();
        }
        if ($constructor != null)
            $constructor.apply(this, Array.prototype.slice.call(arguments, 1));
        if (!(this instanceof WootzJs.Compiler.Tests.GenericTests.GenericClass$1))
            return $t.GenericClass$1;
    }
    $t.GenericClass$1 = GenericClass$1;
    $t.GenericClass$1.prototype = new System.Object();
    ($t.GenericClass$1.$TypeInitializer = function($t, $p, T) {
        $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
        $p.$type = WootzJs.Compiler.Tests.GenericTests.GenericClass$1;
        $t.$baseType = System.Object;
        $p.$typeName = "WootzJs.Compiler.Tests.GenericTests.GenericClass`1";
        $t.$typeName = $p.$typeName;
        $t.$GetType = function() {
            return System.Type._GetTypeFromTypeFunc(this);
        };
        $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("GenericClass", []);this.$type.Init("WootzJs.Compiler.Tests.GenericTests.GenericClass`1", WootzJs.Compiler.Tests.GenericTests.GenericClass$1, System.Object, [], [], [System.Reflection.MethodInfo.prototype.$ctor.$new("GetName", WootzJs.Compiler.Tests.GenericTests.GenericClass$1.prototype.GetName, [], String, System.Reflection.MethodAttributes().Public, []), System.Reflection.MethodInfo.prototype.$ctor.$new("GetUpperName", WootzJs.Compiler.Tests.GenericTests.GenericClass$1.prototype.GetUpperName, [], String, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, [])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.GenericTests.GenericClass$1.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
        $t.$StaticInitializer = function() {
        };
        this.GenericClass$1$ = function() {
            return System.Object.$$MakeGenericType.call(this, this.GenericClass$1, arguments);
        };
        $p.$ctor = function() {
            System.Object.prototype.$ctor.call(this);
        };
        $p.$ctor.$type = $t;
        $p.$ctor.$new = function() {
            return new $p.$ctor.$type(this);
        };
        $p.GetName = function() {
            return T.$GetType().get_Name();
        };
        $t.GetUpperName = function() {
            return T.$GetType().get_Name().toUpperCase();
        };
        function NestedClass($constructor) {
            if (!$t.NestedClass.$isStaticInitialized && ($constructor != null || !(this instanceof WootzJs.Compiler.Tests.GenericTests.GenericClass$1.NestedClass))) {
                $t.NestedClass.$isStaticInitialized = true;
                $t.NestedClass.$StaticInitializer();
            }
            if ($constructor != null)
                $constructor.apply(this, Array.prototype.slice.call(arguments, 1));
            if (!(this instanceof WootzJs.Compiler.Tests.GenericTests.GenericClass$1.NestedClass))
                return $t.NestedClass;
        }
        $t.NestedClass = NestedClass;
        $t.NestedClass.prototype = new System.Object();
        ($t.NestedClass.$TypeInitializer = function($t, $p) {
            $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
            $p.$type = WootzJs.Compiler.Tests.GenericTests.GenericClass$1.NestedClass;
            $t.$baseType = System.Object;
            $p.$typeName = "WootzJs.Compiler.Tests.GenericTests.GenericClass`1.NestedClass";
            $t.$typeName = $p.$typeName;
            $t.$GetType = function() {
                return System.Type._GetTypeFromTypeFunc(this);
            };
            $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("NestedClass", []);this.$type.Init("WootzJs.Compiler.Tests.GenericTests.GenericClass`1.NestedClass", WootzJs.Compiler.Tests.GenericTests.GenericClass$1.NestedClass, System.Object, [], [], [System.Reflection.MethodInfo.prototype.$ctor.$new("GetUpperName", WootzJs.Compiler.Tests.GenericTests.GenericClass$1.NestedClass.prototype.GetUpperName, [], String, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, [])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.GenericTests.GenericClass$1.NestedClass.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
            $t.$StaticInitializer = function() {
            };
            this.NestedClass$ = function() {
                return System.Object.$$MakeGenericType.call(this, this.NestedClass, arguments);
            };
            $p.$ctor = function() {
                System.Object.prototype.$ctor.call(this);
            };
            $p.$ctor.$type = $t;
            $p.$ctor.$new = function() {
                return new $p.$ctor.$type(this);
            };
            $t.GetUpperName = function() {
                return T.$GetType().get_Name().toUpperCase();
            };
        }).call($t, $t.NestedClass, $t.NestedClass.prototype);
        $WootzJs$Compiler$Tests$AssemblyTypes.push($t.NestedClass);
    }).call($t, $t.GenericClass$1, $t.GenericClass$1.prototype);
    $WootzJs$Compiler$Tests$AssemblyTypes.push($t.GenericClass$1);
    function SimpleClass($constructor) {
        if (!$t.SimpleClass.$isStaticInitialized && ($constructor != null || !(this instanceof WootzJs.Compiler.Tests.GenericTests.SimpleClass))) {
            $t.SimpleClass.$isStaticInitialized = true;
            $t.SimpleClass.$StaticInitializer();
        }
        if ($constructor != null)
            $constructor.apply(this, Array.prototype.slice.call(arguments, 1));
        if (!(this instanceof WootzJs.Compiler.Tests.GenericTests.SimpleClass))
            return $t.SimpleClass;
    }
    $t.SimpleClass = SimpleClass;
    $t.SimpleClass.prototype = new System.Object();
    ($t.SimpleClass.$TypeInitializer = function($t, $p) {
        $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
        $p.$type = WootzJs.Compiler.Tests.GenericTests.SimpleClass;
        $t.$baseType = System.Object;
        $p.$typeName = "WootzJs.Compiler.Tests.GenericTests.SimpleClass";
        $t.$typeName = $p.$typeName;
        $t.$GetType = function() {
            return System.Type._GetTypeFromTypeFunc(this);
        };
        $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("SimpleClass", []);this.$type.Init("WootzJs.Compiler.Tests.GenericTests.SimpleClass", WootzJs.Compiler.Tests.GenericTests.SimpleClass, System.Object, [], [], [], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.GenericTests.SimpleClass.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
        $t.$StaticInitializer = function() {
        };
        $p.$ctor = function() {
            System.Object.prototype.$ctor.call(this);
        };
        $p.$ctor.$type = $t;
        $p.$ctor.$new = function() {
            return new $p.$ctor.$type(this);
        };
    }).call($t, $t.SimpleClass, $t.SimpleClass.prototype);
    $WootzJs$Compiler$Tests$AssemblyTypes.push($t.SimpleClass);
}).call(null, WootzJs.Compiler.Tests.GenericTests, WootzJs.Compiler.Tests.GenericTests.prototype);
$WootzJs$Compiler$Tests$AssemblyTypes.push(WootzJs.Compiler.Tests.GenericTests);
WootzJs.Compiler.Tests.TopLevelGenericClass$1 = $define("WootzJs.Compiler.Tests.TopLevelGenericClass<T>");
WootzJs.Compiler.Tests.TopLevelGenericClass$1.prototype = new System.Object();
(WootzJs.Compiler.Tests.TopLevelGenericClass$1.$TypeInitializer = function($t, $p, T) {
    $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
    $p.$type = WootzJs.Compiler.Tests.TopLevelGenericClass$1;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Compiler.Tests.TopLevelGenericClass`1";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("TopLevelGenericClass", []);this.$type.Init("WootzJs.Compiler.Tests.TopLevelGenericClass`1", WootzJs.Compiler.Tests.TopLevelGenericClass$1, System.Object, [], [], [System.Reflection.MethodInfo.prototype.$ctor.$new("GetName", WootzJs.Compiler.Tests.TopLevelGenericClass$1.prototype.GetName, [], String, System.Reflection.MethodAttributes().Public, []), System.Reflection.MethodInfo.prototype.$ctor.$new("GetUpperName", WootzJs.Compiler.Tests.TopLevelGenericClass$1.prototype.GetUpperName, [], String, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, [])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.TopLevelGenericClass$1.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
    $t.$StaticInitializer = function() {
    };
    window.WootzJs.Compiler.Tests.TopLevelGenericClass$1$ = function() {
        return System.Object.$$MakeGenericType.call(null, WootzJs.Compiler.Tests.TopLevelGenericClass$1, arguments);
    };
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.GetName = function() {
        return T.$GetType().get_Name();
    };
    $t.GetUpperName = function() {
        return T.$GetType().get_Name().toUpperCase();
    };
    function NestedClass($constructor) {
        if (!$t.NestedClass.$isStaticInitialized && ($constructor != null || !(this instanceof WootzJs.Compiler.Tests.TopLevelGenericClass$1.NestedClass))) {
            $t.NestedClass.$isStaticInitialized = true;
            $t.NestedClass.$StaticInitializer();
        }
        if ($constructor != null)
            $constructor.apply(this, Array.prototype.slice.call(arguments, 1));
        if (!(this instanceof WootzJs.Compiler.Tests.TopLevelGenericClass$1.NestedClass))
            return $t.NestedClass;
    }
    $t.NestedClass = NestedClass;
    $t.NestedClass.prototype = new System.Object();
    ($t.NestedClass.$TypeInitializer = function($t, $p) {
        $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
        $p.$type = WootzJs.Compiler.Tests.TopLevelGenericClass$1.NestedClass;
        $t.$baseType = System.Object;
        $p.$typeName = "WootzJs.Compiler.Tests.TopLevelGenericClass`1.NestedClass";
        $t.$typeName = $p.$typeName;
        $t.$GetType = function() {
            return System.Type._GetTypeFromTypeFunc(this);
        };
        $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("NestedClass", []);this.$type.Init("WootzJs.Compiler.Tests.TopLevelGenericClass`1.NestedClass", WootzJs.Compiler.Tests.TopLevelGenericClass$1.NestedClass, System.Object, [], [], [System.Reflection.MethodInfo.prototype.$ctor.$new("GetUpperName", WootzJs.Compiler.Tests.TopLevelGenericClass$1.NestedClass.prototype.GetUpperName, [], String, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, [])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.TopLevelGenericClass$1.NestedClass.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
        $t.$StaticInitializer = function() {
        };
        this.NestedClass$ = function() {
            return System.Object.$$MakeGenericType.call(this, this.NestedClass, arguments);
        };
        $p.$ctor = function() {
            System.Object.prototype.$ctor.call(this);
        };
        $p.$ctor.$type = $t;
        $p.$ctor.$new = function() {
            return new $p.$ctor.$type(this);
        };
        $t.GetUpperName = function() {
            return T.$GetType().get_Name().toUpperCase();
        };
    }).call($t, $t.NestedClass, $t.NestedClass.prototype);
    $WootzJs$Compiler$Tests$AssemblyTypes.push($t.NestedClass);
}).call(null, WootzJs.Compiler.Tests.TopLevelGenericClass$1, WootzJs.Compiler.Tests.TopLevelGenericClass$1.prototype);
$WootzJs$Compiler$Tests$AssemblyTypes.push(WootzJs.Compiler.Tests.TopLevelGenericClass$1);
WootzJs.Compiler.Tests.GotoTests = $define("WootzJs.Compiler.Tests.GotoTests");
WootzJs.Compiler.Tests.GotoTests.prototype = new System.Object();
(WootzJs.Compiler.Tests.GotoTests.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
    $p.$type = WootzJs.Compiler.Tests.GotoTests;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Compiler.Tests.GotoTests";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("GotoTests", [WootzJs.Compiler.Tests.TestFixtureAttribute.prototype.$ctor.$new()]);this.$type.Init("WootzJs.Compiler.Tests.GotoTests", WootzJs.Compiler.Tests.GotoTests, System.Object, [], [], [System.Reflection.MethodInfo.prototype.$ctor.$new("LabeledBreak", WootzJs.Compiler.Tests.GotoTests.prototype.LabeledBreak, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.GotoTests.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
    $t.$StaticInitializer = function() {
    };
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.LabeledBreak = function() {
        var counter = 0;
        top:
        for (var i = 0; i < 3; i++) {
            for (var j = 0; j < 3; j++) {
                if (i == 1)
                    return {type: 2,label: "top",depth: 1};
                counter++;
            }
        }
        QUnit.equal(counter, 6);
    };
}).call(null, WootzJs.Compiler.Tests.GotoTests, WootzJs.Compiler.Tests.GotoTests.prototype);
$WootzJs$Compiler$Tests$AssemblyTypes.push(WootzJs.Compiler.Tests.GotoTests);
WootzJs.Compiler.Tests.IsExpressionTests = $define("WootzJs.Compiler.Tests.IsExpressionTests");
WootzJs.Compiler.Tests.IsExpressionTests.prototype = new System.Object();
(WootzJs.Compiler.Tests.IsExpressionTests.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
    $p.$type = WootzJs.Compiler.Tests.IsExpressionTests;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Compiler.Tests.IsExpressionTests";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("IsExpressionTests", [WootzJs.Compiler.Tests.TestFixtureAttribute.prototype.$ctor.$new()]);this.$type.Init("WootzJs.Compiler.Tests.IsExpressionTests", WootzJs.Compiler.Tests.IsExpressionTests, System.Object, [], [], [System.Reflection.MethodInfo.prototype.$ctor.$new("String", WootzJs.Compiler.Tests.IsExpressionTests.prototype.String, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("TestClass", WootzJs.Compiler.Tests.IsExpressionTests.prototype.TestClass, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.IsExpressionTests.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
    $t.$StaticInitializer = function() {
    };
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.String = function() {
        var s = "foo";
        QUnit.ok(String.$GetType().IsInstanceOfType(s));
        QUnit.ok(!(System.Int32.$GetType().IsInstanceOfType(s)));
    };
    $p.TestClass = function() {
        var o = WootzJs.Compiler.Tests.IsExpressionTests.MyClass.prototype.$ctor.$new();
        QUnit.ok(WootzJs.Compiler.Tests.IsExpressionTests.MyClass.$GetType().IsInstanceOfType(o));
        QUnit.ok(System.Object.$GetType().IsInstanceOfType(o));
        QUnit.ok(!(String.$GetType().IsInstanceOfType(o)));
    };
    function MyClass($constructor) {
        if (!$t.MyClass.$isStaticInitialized && ($constructor != null || !(this instanceof WootzJs.Compiler.Tests.IsExpressionTests.MyClass))) {
            $t.MyClass.$isStaticInitialized = true;
            $t.MyClass.$StaticInitializer();
        }
        if ($constructor != null)
            $constructor.apply(this, Array.prototype.slice.call(arguments, 1));
        if (!(this instanceof WootzJs.Compiler.Tests.IsExpressionTests.MyClass))
            return $t.MyClass;
    }
    $t.MyClass = MyClass;
    $t.MyClass.prototype = new System.Object();
    ($t.MyClass.$TypeInitializer = function($t, $p) {
        $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
        $p.$type = WootzJs.Compiler.Tests.IsExpressionTests.MyClass;
        $t.$baseType = System.Object;
        $p.$typeName = "WootzJs.Compiler.Tests.IsExpressionTests.MyClass";
        $t.$typeName = $p.$typeName;
        $t.$GetType = function() {
            return System.Type._GetTypeFromTypeFunc(this);
        };
        $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("MyClass", []);this.$type.Init("WootzJs.Compiler.Tests.IsExpressionTests.MyClass", WootzJs.Compiler.Tests.IsExpressionTests.MyClass, System.Object, [], [], [], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.IsExpressionTests.MyClass.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
        $t.$StaticInitializer = function() {
        };
        $p.$ctor = function() {
            System.Object.prototype.$ctor.call(this);
        };
        $p.$ctor.$type = $t;
        $p.$ctor.$new = function() {
            return new $p.$ctor.$type(this);
        };
    }).call($t, $t.MyClass, $t.MyClass.prototype);
    $WootzJs$Compiler$Tests$AssemblyTypes.push($t.MyClass);
}).call(null, WootzJs.Compiler.Tests.IsExpressionTests, WootzJs.Compiler.Tests.IsExpressionTests.prototype);
$WootzJs$Compiler$Tests$AssemblyTypes.push(WootzJs.Compiler.Tests.IsExpressionTests);
WootzJs.Compiler.Tests.Linq.EnumerableTests = $define("WootzJs.Compiler.Tests.Linq.EnumerableTests");
WootzJs.Compiler.Tests.Linq.EnumerableTests.prototype = new System.Object();
(WootzJs.Compiler.Tests.Linq.EnumerableTests.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
    $p.$type = WootzJs.Compiler.Tests.Linq.EnumerableTests;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Compiler.Tests.Linq.EnumerableTests";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("EnumerableTests", [WootzJs.Compiler.Tests.TestFixtureAttribute.prototype.$ctor.$new()]);this.$type.Init("WootzJs.Compiler.Tests.Linq.EnumerableTests", WootzJs.Compiler.Tests.Linq.EnumerableTests, System.Object, [], [], [System.Reflection.MethodInfo.prototype.$ctor.$new("Aggregate", WootzJs.Compiler.Tests.Linq.EnumerableTests.prototype.Aggregate, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("AggregateWithSeed", WootzJs.Compiler.Tests.Linq.EnumerableTests.prototype.AggregateWithSeed, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("AggregateWithSeedAndResult", WootzJs.Compiler.Tests.Linq.EnumerableTests.prototype.AggregateWithSeedAndResult, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("All", WootzJs.Compiler.Tests.Linq.EnumerableTests.prototype.All, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("Where", WootzJs.Compiler.Tests.Linq.EnumerableTests.prototype.Where, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("WhereWithIndex", WootzJs.Compiler.Tests.Linq.EnumerableTests.prototype.WhereWithIndex, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("Select", WootzJs.Compiler.Tests.Linq.EnumerableTests.prototype.Select, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("SelectWithIndex", WootzJs.Compiler.Tests.Linq.EnumerableTests.prototype.SelectWithIndex, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("SelectMany", WootzJs.Compiler.Tests.Linq.EnumerableTests.prototype.SelectMany, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("SelectManyWithIndex", WootzJs.Compiler.Tests.Linq.EnumerableTests.prototype.SelectManyWithIndex, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("SelectManyWithIndexAndResultSelector", WootzJs.Compiler.Tests.Linq.EnumerableTests.prototype.SelectManyWithIndexAndResultSelector, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("SelectManyWithResultSelector", WootzJs.Compiler.Tests.Linq.EnumerableTests.prototype.SelectManyWithResultSelector, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("Max", WootzJs.Compiler.Tests.Linq.EnumerableTests.prototype.Max, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("Min", WootzJs.Compiler.Tests.Linq.EnumerableTests.prototype.Min, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("Take", WootzJs.Compiler.Tests.Linq.EnumerableTests.prototype.Take, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("TakeWhile", WootzJs.Compiler.Tests.Linq.EnumerableTests.prototype.TakeWhile, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("TakeWhileWithIndex", WootzJs.Compiler.Tests.Linq.EnumerableTests.prototype.TakeWhileWithIndex, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("Skip", WootzJs.Compiler.Tests.Linq.EnumerableTests.prototype.Skip, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("SkipWhile", WootzJs.Compiler.Tests.Linq.EnumerableTests.prototype.SkipWhile, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("SkipWhileWithIndex", WootzJs.Compiler.Tests.Linq.EnumerableTests.prototype.SkipWhileWithIndex, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("Join", WootzJs.Compiler.Tests.Linq.EnumerableTests.prototype.Join, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("Except", WootzJs.Compiler.Tests.Linq.EnumerableTests.prototype.Except, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.Linq.EnumerableTests.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
    $t.$StaticInitializer = function() {
    };
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.Aggregate = function() {
        var array = System.Object.$$InitializeArray([1, 2, 3], System.Int32);
        var result = System.Linq.Enumerable.Aggregate(System.Int32, array, $delegate(this, (System.Func$3$(System.Int32, System.Int32, System.Int32)), function(x, y) {
            return x + y;
        }));
        QUnit.equal(result, 6);
    };
    $p.AggregateWithSeed = function() {
        var array = System.Object.$$InitializeArray([1, 2, 3], System.Int32);
        var result = System.Linq.Enumerable.Aggregate$1(
            System.Int32, 
            System.Int32, 
            array, 
            10, 
            $delegate(this, (System.Func$3$(System.Int32, System.Int32, System.Int32)), function(x, y) {
                return x + y;
            })
        );
        QUnit.equal(result, 16);
    };
    $p.AggregateWithSeedAndResult = function() {
        var array = System.Object.$$InitializeArray([1, 2, 3], System.Int32);
        var result = System.Linq.Enumerable.Aggregate$2(
            System.Int32, 
            System.Int32, 
            String, 
            array, 
            10, 
            $delegate(this, (System.Func$3$(System.Int32, System.Int32, System.Int32)), function(x, y) {
                return x + y;
            }), 
            $delegate(this, (System.Func$2$(System.Int32, String)), function(x) {
                return x.ToString();
            })
        );
        QUnit.equal(result, "16");
    };
    $p.All = function() {
        var array = System.Object.$$InitializeArray([1, 2, 3], System.Int32);
        QUnit.equal(System.Linq.Enumerable.All(System.Int32, array, $delegate(this, (System.Func$2$(System.Int32, System.Boolean)), function(x) {
            return x > 0;
        })), true);
        QUnit.equal(System.Linq.Enumerable.All(System.Int32, array, $delegate(this, (System.Func$2$(System.Int32, System.Boolean)), function(x) {
            return x > 1;
        })), false);
    };
    $p.Where = function() {
        var array = System.Object.$$InitializeArray(["1", "2", "3"], String);
        var two = System.Linq.Enumerable.Single(String, System.Linq.Enumerable.Where(String, array, $delegate(this, (System.Func$2$(String, System.Boolean)), function(x) {
            return x == "2";
        })));
        QUnit.equal(two, "2");
    };
    $p.WhereWithIndex = function() {
        var array = System.Object.$$InitializeArray(["1", "2", "3"], String);
        var result = System.Linq.Enumerable.ToArray(String, System.Linq.Enumerable.Where$1(String, array, $delegate(this, (System.Func$3$(String, System.Int32, System.Boolean)), function(x, i) {
            return x == "2" || i == 2;
        })));
        QUnit.equal(result.length, 2);
        QUnit.equal(result[0], "2");
        QUnit.equal(result[1], "3");
    };
    $p.Select = function() {
        var array = System.Object.$$InitializeArray(["1", "2", "3"], String);
        var two = System.Linq.Enumerable.ToArray(String, System.Linq.Enumerable.Select(
            String, 
            String, 
            array, 
            $delegate(this, (System.Func$2$(String, String)), function(x) {
                return x + "a";
            })
        ));
        QUnit.equal(two[0], "1a");
        QUnit.equal(two[1], "2a");
        QUnit.equal(two[2], "3a");
    };
    $p.SelectWithIndex = function() {
        var array = System.Object.$$InitializeArray(["1", "2", "3"], String);
        var two = System.Linq.Enumerable.ToArray(String, System.Linq.Enumerable.Select$1(
            String, 
            String, 
            array, 
            $delegate(this, (System.Func$3$(String, System.Int32, String)), function(x, i) {
                return x + "a" + i;
            })
        ));
        QUnit.equal(two[0], "1a0");
        QUnit.equal(two[1], "2a1");
        QUnit.equal(two[2], "3a2");
    };
    $p.SelectMany = function() {
        var arrays = System.Object.$$InitializeArray([System.Object.$$InitializeArray(["1", "2", "3"], String), System.Object.$$InitializeArray(["4", "5", "6"], String)], System.Object.$$MakeArrayType(String));
        var elements = System.Linq.Enumerable.ToArray(String, System.Linq.Enumerable.SelectMany(
            System.Object.$$MakeArrayType(String), 
            String, 
            arrays, 
            $delegate(this, (System.Func$2$(System.Object.$$MakeArrayType(String), (System.Collections.Generic.IEnumerable$1$(String)))), function(x) {
                return x;
            })
        ));
        QUnit.equal(elements.length, 6);
        QUnit.equal(elements[0], "1");
        QUnit.equal(elements[1], "2");
        QUnit.equal(elements[2], "3");
        QUnit.equal(elements[3], "4");
        QUnit.equal(elements[4], "5");
        QUnit.equal(elements[5], "6");
    };
    $p.SelectManyWithIndex = function() {
        var arrays = System.Object.$$InitializeArray([System.Object.$$InitializeArray(["1", "2", "3"], String), System.Object.$$InitializeArray(["4", "5", "6"], String)], System.Object.$$MakeArrayType(String));
        var elements = System.Linq.Enumerable.ToArray(String, System.Linq.Enumerable.SelectMany$1(
            System.Object.$$MakeArrayType(String), 
            String, 
            arrays, 
            $delegate(this, (System.Func$3$(System.Object.$$MakeArrayType(String), System.Int32, (System.Collections.Generic.IEnumerable$1$(String)))), function(x, i) {
                return System.Linq.Enumerable.Select(
                    String, 
                    String, 
                    x, 
                    $delegate(this, (System.Func$2$(String, String)), function(y) {
                        return y + i;
                    })
                );
            })
        ));
        QUnit.equal(elements.length, 6);
        QUnit.equal(elements[0], "10");
        QUnit.equal(elements[1], "20");
        QUnit.equal(elements[2], "30");
        QUnit.equal(elements[3], "41");
        QUnit.equal(elements[4], "51");
        QUnit.equal(elements[5], "61");
    };
    $p.SelectManyWithIndexAndResultSelector = function() {
        var arrays = System.Object.$$InitializeArray([System.Object.$$InitializeArray(["1", "2", "3"], String), System.Object.$$InitializeArray(["4", "5", "6"], String)], System.Object.$$MakeArrayType(String));
        var elements = System.Linq.Enumerable.ToArray(System.Int32, System.Linq.Enumerable.SelectMany$3(
            System.Object.$$MakeArrayType(String), 
            String, 
            System.Int32, 
            arrays, 
            $delegate(this, (System.Func$3$(System.Object.$$MakeArrayType(String), System.Int32, (System.Collections.Generic.IEnumerable$1$(String)))), function(x, i) {
                return System.Linq.Enumerable.Select(
                    String, 
                    String, 
                    x, 
                    $delegate(this, (System.Func$2$(String, String)), function(y) {
                        return y + i;
                    })
                );
            }), 
            $delegate(this, (System.Func$3$(System.Object.$$MakeArrayType(String), String, System.Int32)), function(row, item) {
                return row.length * System.Int32.Parse(item);
            })
        ));
        QUnit.equal(elements.length, 6);
        QUnit.equal(elements[0], 30);
        QUnit.equal(elements[1], 60);
        QUnit.equal(elements[2], 90);
        QUnit.equal(elements[3], 123);
        QUnit.equal(elements[4], 153);
        QUnit.equal(elements[5], 183);
    };
    $p.SelectManyWithResultSelector = function() {
        var arrays = System.Object.$$InitializeArray([System.Object.$$InitializeArray(["1", "2", "3"], String), System.Object.$$InitializeArray(["4", "5", "6"], String)], System.Object.$$MakeArrayType(String));
        var elements = System.Linq.Enumerable.ToArray(System.Int32, System.Linq.Enumerable.SelectMany$2(
            System.Object.$$MakeArrayType(String), 
            String, 
            System.Int32, 
            arrays, 
            $delegate(this, (System.Func$2$(System.Object.$$MakeArrayType(String), (System.Collections.Generic.IEnumerable$1$(String)))), function(x) {
                return x;
            }), 
            $delegate(this, (System.Func$3$(System.Object.$$MakeArrayType(String), String, System.Int32)), function(row, item) {
                return row.length * System.Int32.Parse(item);
            })
        ));
        QUnit.equal(elements.length, 6);
        QUnit.equal(elements[0], 3);
        QUnit.equal(elements[1], 6);
        QUnit.equal(elements[2], 9);
        QUnit.equal(elements[3], 12);
        QUnit.equal(elements[4], 15);
        QUnit.equal(elements[5], 18);
    };
    $p.Max = function() {
        QUnit.equal(System.Linq.Enumerable.Max(System.Int32, System.Object.$$InitializeArray([1, 2, 3], System.Int32)), 3);
        QUnit.equal(System.Linq.Enumerable.Max(System.Double, System.Object.$$InitializeArray([1.3, 2.4, 3.5], System.Double)), 3.5);
    };
    $p.Min = function() {
        QUnit.equal(System.Linq.Enumerable.Min(System.Int32, System.Object.$$InitializeArray([-1, 2, 3], System.Int32)), -1);
        QUnit.equal(System.Linq.Enumerable.Min(System.Double, System.Object.$$InitializeArray([1.3, -2.4, 3.5], System.Double)), -2.4);
    };
    $p.Take = function() {
        var ints = System.Linq.Enumerable.ToArray(System.Int32, System.Linq.Enumerable.Take(System.Int32, System.Object.$$InitializeArray([
            8, 
            3, 
            5, 
            1
        ], System.Int32), 3));
        QUnit.equal(ints.length, 3);
        QUnit.equal(ints[0], 8);
        QUnit.equal(ints[1], 3);
        QUnit.equal(ints[2], 5);
    };
    $p.TakeWhile = function() {
        var ints = System.Linq.Enumerable.ToArray(System.Int32, System.Linq.Enumerable.TakeWhile(System.Int32, System.Object.$$InitializeArray([
            1, 
            2, 
            3, 
            4, 
            5
        ], System.Int32), $delegate(this, (System.Func$2$(System.Int32, System.Boolean)), function(x) {
            return x < 3;
        })));
        QUnit.equal(ints.length, 2);
        QUnit.equal(ints[0], 1);
        QUnit.equal(ints[1], 2);
    };
    $p.TakeWhileWithIndex = function() {
        var ints = System.Linq.Enumerable.ToArray(System.Int32, System.Linq.Enumerable.TakeWhile$1(System.Int32, System.Object.$$InitializeArray([
            1, 
            2, 
            3, 
            4, 
            5
        ], System.Int32), $delegate(this, (System.Func$3$(System.Int32, System.Int32, System.Boolean)), function(x, i) {
            return i < 3;
        })));
        QUnit.equal(ints.length, 3);
        QUnit.equal(ints[0], 1);
        QUnit.equal(ints[1], 2);
        QUnit.equal(ints[2], 3);
    };
    $p.Skip = function() {
        var ints = System.Linq.Enumerable.ToArray(System.Int32, System.Linq.Enumerable.Skip(System.Int32, System.Object.$$InitializeArray([
            8, 
            3, 
            5, 
            1
        ], System.Int32), 2));
        QUnit.equal(ints.length, 2);
        QUnit.equal(ints[0], 5);
        QUnit.equal(ints[1], 1);
    };
    $p.SkipWhile = function() {
        var ints = System.Linq.Enumerable.ToArray(System.Int32, System.Linq.Enumerable.SkipWhile(System.Int32, System.Object.$$InitializeArray([
            1, 
            2, 
            3, 
            4, 
            5
        ], System.Int32), $delegate(this, (System.Func$2$(System.Int32, System.Boolean)), function(x) {
            return x < 3;
        })));
        QUnit.equal(ints.length, 3);
        QUnit.equal(ints[0], 3);
        QUnit.equal(ints[1], 4);
        QUnit.equal(ints[2], 5);
    };
    $p.SkipWhileWithIndex = function() {
        var ints = System.Linq.Enumerable.ToArray(System.Int32, System.Linq.Enumerable.SkipWhile$1(System.Int32, System.Object.$$InitializeArray([
            1, 
            2, 
            3, 
            4, 
            5
        ], System.Int32), $delegate(this, (System.Func$3$(System.Int32, System.Int32, System.Boolean)), function(x, i) {
            return i < 3;
        })));
        QUnit.equal(ints.length, 2);
        QUnit.equal(ints[0], 4);
        QUnit.equal(ints[1], 5);
    };
    $p.Join = function() {
        var ints1 = System.Object.$$InitializeArray([
            1, 
            2, 
            3, 
            4
        ], System.Int32);
        var ints2 = System.Object.$$InitializeArray([
            3, 
            4, 
            5, 
            6
        ], System.Int32);
        var join = System.Linq.Enumerable.ToArray(System.Int32, System.Linq.Enumerable.Join(
            System.Int32, 
            System.Int32, 
            System.Int32, 
            System.Int32, 
            ints1, 
            ints2, 
            $delegate(this, (System.Func$2$(System.Int32, System.Int32)), function(x) {
                return x;
            }), 
            $delegate(this, (System.Func$2$(System.Int32, System.Int32)), function(x) {
                return x;
            }), 
            $delegate(this, (System.Func$3$(System.Int32, System.Int32, System.Int32)), function(x, y) {
                return x + y;
            })
        ));
        QUnit.equal(join.length, 2);
        QUnit.equal(join[0], 6);
        QUnit.equal(join[1], 8);
    };
    $p.Except = function() {
        var ints1 = System.Object.$$InitializeArray([
            1, 
            2, 
            3, 
            4
        ], System.Int32);
        var ints2 = System.Object.$$InitializeArray([
            3, 
            4, 
            5, 
            6
        ], System.Int32);
        var join = System.Linq.Enumerable.ToArray(System.Int32, System.Linq.Enumerable.Except(System.Int32, ints1, ints2));
        QUnit.equal(join.length, 2);
        QUnit.equal(join[0], 1);
        QUnit.equal(join[1], 2);
    };
}).call(null, WootzJs.Compiler.Tests.Linq.EnumerableTests, WootzJs.Compiler.Tests.Linq.EnumerableTests.prototype);
$WootzJs$Compiler$Tests$AssemblyTypes.push(WootzJs.Compiler.Tests.Linq.EnumerableTests);
WootzJs.Compiler.Tests.CollectionInitializerTests = $define("WootzJs.Compiler.Tests.CollectionInitializerTests");
WootzJs.Compiler.Tests.CollectionInitializerTests.prototype = new System.Object();
(WootzJs.Compiler.Tests.CollectionInitializerTests.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
    $p.$type = WootzJs.Compiler.Tests.CollectionInitializerTests;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Compiler.Tests.CollectionInitializerTests";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("CollectionInitializerTests", [WootzJs.Compiler.Tests.TestFixtureAttribute.prototype.$ctor.$new()]);this.$type.Init("WootzJs.Compiler.Tests.CollectionInitializerTests", WootzJs.Compiler.Tests.CollectionInitializerTests, System.Object, [], [], [System.Reflection.MethodInfo.prototype.$ctor.$new("OneString", WootzJs.Compiler.Tests.CollectionInitializerTests.prototype.OneString, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("TwoItemDictionary", WootzJs.Compiler.Tests.CollectionInitializerTests.prototype.TwoItemDictionary, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.CollectionInitializerTests.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
    $t.$StaticInitializer = function() {
    };
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.OneString = function() {
        var list = (function() {
            var $obj$ = (System.Collections.Generic.List$1$(String)).prototype.$ctor.$new();
            $obj$.Add("one");
            return $obj$;
        }).call(this);
        QUnit.equal(list.get_Item(0), "one");
    };
    $p.TwoItemDictionary = function() {
        var dictionary = (function() {
            var $obj$ = (System.Collections.Generic.Dictionary$2$(String, System.Int32)).prototype.$ctor.$new();
            $obj$.Add$1("one", 1);
            $obj$.Add$1("two", 2);
            return $obj$;
        }).call(this);
        var one = dictionary.get_Item("one");
        var two = dictionary.get_Item("two");
        QUnit.equal(one, 1);
        QUnit.equal(two, 2);
    };
}).call(null, WootzJs.Compiler.Tests.CollectionInitializerTests, WootzJs.Compiler.Tests.CollectionInitializerTests.prototype);
$WootzJs$Compiler$Tests$AssemblyTypes.push(WootzJs.Compiler.Tests.CollectionInitializerTests);
WootzJs.Compiler.Tests.Linq.Expressions.BinaryExpressionTests = $define("WootzJs.Compiler.Tests.Linq.Expressions.BinaryExpressionTests");
WootzJs.Compiler.Tests.Linq.Expressions.BinaryExpressionTests.prototype = new System.Object();
(WootzJs.Compiler.Tests.Linq.Expressions.BinaryExpressionTests.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
    $p.$type = WootzJs.Compiler.Tests.Linq.Expressions.BinaryExpressionTests;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Compiler.Tests.Linq.Expressions.BinaryExpressionTests";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("BinaryExpressionTests", []);this.$type.Init("WootzJs.Compiler.Tests.Linq.Expressions.BinaryExpressionTests", WootzJs.Compiler.Tests.Linq.Expressions.BinaryExpressionTests, System.Object, [], [], [System.Reflection.MethodInfo.prototype.$ctor.$new("AddTwoInts", WootzJs.Compiler.Tests.Linq.Expressions.BinaryExpressionTests.prototype.AddTwoInts, [], System.Void, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("AddTwoStrings", WootzJs.Compiler.Tests.Linq.Expressions.BinaryExpressionTests.prototype.AddTwoStrings, [], System.Void, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("AddStringAndInt", WootzJs.Compiler.Tests.Linq.Expressions.BinaryExpressionTests.prototype.AddStringAndInt, [], System.Void, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("SubtractTwoInts", WootzJs.Compiler.Tests.Linq.Expressions.BinaryExpressionTests.prototype.SubtractTwoInts, [], System.Void, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("MultiplyTwoInts", WootzJs.Compiler.Tests.Linq.Expressions.BinaryExpressionTests.prototype.MultiplyTwoInts, [], System.Void, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("DivideTwoInts", WootzJs.Compiler.Tests.Linq.Expressions.BinaryExpressionTests.prototype.DivideTwoInts, [], System.Void, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("ModuloTwoInts", WootzJs.Compiler.Tests.Linq.Expressions.BinaryExpressionTests.prototype.ModuloTwoInts, [], System.Void, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("ArrayIndex", WootzJs.Compiler.Tests.Linq.Expressions.BinaryExpressionTests.prototype.ArrayIndex, [], System.Void, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.Linq.Expressions.BinaryExpressionTests.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
    $t.$StaticInitializer = function() {
    };
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $t.AddTwoInts = function() {
        var lambda = (function() {
            return System.Linq.Expressions.Expression.Lambda((System.Func$1$(System.Int32)), System.Linq.Expressions.Expression.MakeBinary(System.Linq.Expressions.ExpressionType().Add, System.Linq.Expressions.Expression.Constant$1(5, System.Int32.$GetType()), System.Linq.Expressions.Expression.Constant$1(4, System.Int32.$GetType())), []);
        }).call(this);
        var binaryExpression = $cast(System.Linq.Expressions.BinaryExpression, lambda.get_Body());
        var left = $cast(System.Linq.Expressions.ConstantExpression, binaryExpression.get_Left());
        var right = $cast(System.Linq.Expressions.ConstantExpression, binaryExpression.get_Right());
        QUnit.equal(binaryExpression.get_NodeType(), System.Linq.Expressions.ExpressionType().Add);
        QUnit.equal(left.get_Value(), 5);
        QUnit.equal(right.get_Value(), 4);
    };
    $t.AddTwoStrings = function() {
        var lambda = (function() {
            return System.Linq.Expressions.Expression.Lambda((System.Func$1$(String)), System.Linq.Expressions.Expression.MakeBinary(System.Linq.Expressions.ExpressionType().Add, System.Linq.Expressions.Expression.Constant$1("foo", String.$GetType()), System.Linq.Expressions.Expression.Constant$1("bar", String.$GetType())), []);
        }).call(this);
        var binaryExpression = $cast(System.Linq.Expressions.BinaryExpression, lambda.get_Body());
        var left = $cast(System.Linq.Expressions.ConstantExpression, binaryExpression.get_Left());
        var right = $cast(System.Linq.Expressions.ConstantExpression, binaryExpression.get_Right());
        QUnit.equal(binaryExpression.get_NodeType(), System.Linq.Expressions.ExpressionType().Add);
        QUnit.equal(left.get_Value(), "foo");
        QUnit.equal(right.get_Value(), "bar");
    };
    $t.AddStringAndInt = function() {
        var lambda = (function() {
            return System.Linq.Expressions.Expression.Lambda((System.Func$1$(String)), System.Linq.Expressions.Expression.MakeBinary(System.Linq.Expressions.ExpressionType().Add, System.Linq.Expressions.Expression.Constant$1("foo", String.$GetType()), System.Linq.Expressions.Expression.Constant$1(5, System.Object.$GetType())), []);
        }).call(this);
        var binaryExpression = $cast(System.Linq.Expressions.BinaryExpression, lambda.get_Body());
        var left = $cast(System.Linq.Expressions.ConstantExpression, binaryExpression.get_Left());
        var right = $cast(System.Linq.Expressions.ConstantExpression, binaryExpression.get_Right());
        QUnit.equal(binaryExpression.get_NodeType(), System.Linq.Expressions.ExpressionType().Add);
        QUnit.equal(left.get_Value(), "foo");
        QUnit.equal(right.get_Value(), 5);
    };
    $t.SubtractTwoInts = function() {
        var lambda = (function() {
            return System.Linq.Expressions.Expression.Lambda((System.Func$1$(System.Int32)), System.Linq.Expressions.Expression.MakeBinary(System.Linq.Expressions.ExpressionType().Subtract, System.Linq.Expressions.Expression.Constant$1(5, System.Int32.$GetType()), System.Linq.Expressions.Expression.Constant$1(4, System.Int32.$GetType())), []);
        }).call(this);
        var binaryExpression = $cast(System.Linq.Expressions.BinaryExpression, lambda.get_Body());
        var left = $cast(System.Linq.Expressions.ConstantExpression, binaryExpression.get_Left());
        var right = $cast(System.Linq.Expressions.ConstantExpression, binaryExpression.get_Right());
        QUnit.equal(binaryExpression.get_NodeType(), System.Linq.Expressions.ExpressionType().Subtract);
        QUnit.equal(left.get_Value(), 5);
        QUnit.equal(right.get_Value(), 4);
    };
    $t.MultiplyTwoInts = function() {
        var lambda = (function() {
            return System.Linq.Expressions.Expression.Lambda((System.Func$1$(System.Int32)), System.Linq.Expressions.Expression.MakeBinary(System.Linq.Expressions.ExpressionType().Multiply, System.Linq.Expressions.Expression.Constant$1(5, System.Int32.$GetType()), System.Linq.Expressions.Expression.Constant$1(4, System.Int32.$GetType())), []);
        }).call(this);
        var binaryExpression = $cast(System.Linq.Expressions.BinaryExpression, lambda.get_Body());
        var left = $cast(System.Linq.Expressions.ConstantExpression, binaryExpression.get_Left());
        var right = $cast(System.Linq.Expressions.ConstantExpression, binaryExpression.get_Right());
        QUnit.equal(binaryExpression.get_NodeType(), System.Linq.Expressions.ExpressionType().Multiply);
        QUnit.equal(left.get_Value(), 5);
        QUnit.equal(right.get_Value(), 4);
    };
    $t.DivideTwoInts = function() {
        var lambda = (function() {
            return System.Linq.Expressions.Expression.Lambda((System.Func$1$(System.Int32)), System.Linq.Expressions.Expression.MakeBinary(System.Linq.Expressions.ExpressionType().Divide, System.Linq.Expressions.Expression.Constant$1(5, System.Int32.$GetType()), System.Linq.Expressions.Expression.Constant$1(4, System.Int32.$GetType())), []);
        }).call(this);
        var binaryExpression = $cast(System.Linq.Expressions.BinaryExpression, lambda.get_Body());
        var left = $cast(System.Linq.Expressions.ConstantExpression, binaryExpression.get_Left());
        var right = $cast(System.Linq.Expressions.ConstantExpression, binaryExpression.get_Right());
        QUnit.equal(binaryExpression.get_NodeType(), System.Linq.Expressions.ExpressionType().Divide);
        QUnit.equal(left.get_Value(), 5);
        QUnit.equal(right.get_Value(), 4);
    };
    $t.ModuloTwoInts = function() {
        var lambda = (function() {
            return System.Linq.Expressions.Expression.Lambda((System.Func$1$(System.Int32)), System.Linq.Expressions.Expression.MakeBinary(System.Linq.Expressions.ExpressionType().Modulo, System.Linq.Expressions.Expression.Constant$1(5, System.Int32.$GetType()), System.Linq.Expressions.Expression.Constant$1(4, System.Int32.$GetType())), []);
        }).call(this);
        var binaryExpression = $cast(System.Linq.Expressions.BinaryExpression, lambda.get_Body());
        var left = $cast(System.Linq.Expressions.ConstantExpression, binaryExpression.get_Left());
        var right = $cast(System.Linq.Expressions.ConstantExpression, binaryExpression.get_Right());
        QUnit.equal(binaryExpression.get_NodeType(), System.Linq.Expressions.ExpressionType().Modulo);
        QUnit.equal(left.get_Value(), 5);
        QUnit.equal(right.get_Value(), 4);
    };
    $t.ArrayIndex = function() {
        var array = System.Object.$$InitializeArray([5], System.Int32);
        var lambda = (function() {
            return System.Linq.Expressions.Expression.Lambda((System.Func$1$(System.Int32)), System.Linq.Expressions.Expression.ArrayIndex$1(System.Linq.Expressions.Expression.Constant$1(array, System.Object.$$MakeArrayType(System.Int32).$GetType()), System.Linq.Expressions.Expression.Constant$1(4, System.Int32.$GetType())), []);
        }).call(this);
        var binaryExpression = $cast(System.Linq.Expressions.BinaryExpression, lambda.get_Body());
        var target = $cast(System.Linq.Expressions.ConstantExpression, binaryExpression.get_Left());
        QUnit.equal(target.get_Value(), array);
        var index = $cast(System.Linq.Expressions.ConstantExpression, binaryExpression.get_Right());
        QUnit.equal(index.get_Value(), 4);
    };
}).call(null, WootzJs.Compiler.Tests.Linq.Expressions.BinaryExpressionTests, WootzJs.Compiler.Tests.Linq.Expressions.BinaryExpressionTests.prototype);
$WootzJs$Compiler$Tests$AssemblyTypes.push(WootzJs.Compiler.Tests.Linq.Expressions.BinaryExpressionTests);
WootzJs.Compiler.Tests.Linq.Expressions.ConditionalExpressionTests = $define("WootzJs.Compiler.Tests.Linq.Expressions.ConditionalExpressionTests");
WootzJs.Compiler.Tests.Linq.Expressions.ConditionalExpressionTests.prototype = new System.Object();
(WootzJs.Compiler.Tests.Linq.Expressions.ConditionalExpressionTests.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
    $p.$type = WootzJs.Compiler.Tests.Linq.Expressions.ConditionalExpressionTests;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Compiler.Tests.Linq.Expressions.ConditionalExpressionTests";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("ConditionalExpressionTests", []);this.$type.Init("WootzJs.Compiler.Tests.Linq.Expressions.ConditionalExpressionTests", WootzJs.Compiler.Tests.Linq.Expressions.ConditionalExpressionTests, System.Object, [], [], [System.Reflection.MethodInfo.prototype.$ctor.$new("Conditional", WootzJs.Compiler.Tests.Linq.Expressions.ConditionalExpressionTests.prototype.Conditional, [], System.Void, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.Linq.Expressions.ConditionalExpressionTests.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
    $t.$StaticInitializer = function() {
    };
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $t.Conditional = function() {
        var lambda = (function() {
            var $lambdaparam$x = System.Linq.Expressions.Expression.Parameter$1(System.Boolean.$GetType(), "x");
            return System.Linq.Expressions.Expression.Lambda((System.Func$2$(System.Boolean, String)), System.Linq.Expressions.Expression.Condition$1(
                $lambdaparam$x, 
                System.Linq.Expressions.Expression.Constant$1("yes", String.$GetType()), 
                System.Linq.Expressions.Expression.Constant$1("no", String.$GetType()), 
                String.$GetType()
            ), [$lambdaparam$x]);
        }).call(this);
        var conditional = $cast(System.Linq.Expressions.ConditionalExpression, lambda.get_Body());
        QUnit.equal(conditional.get_Test(), lambda.get_Parameters().get_Item(0));
        var ifTrue = $cast(System.Linq.Expressions.ConstantExpression, conditional.get_IfTrue());
        var ifFalse = $cast(System.Linq.Expressions.ConstantExpression, conditional.get_IfFalse());
        QUnit.equal(ifTrue.get_Value(), "yes");
        QUnit.equal(ifFalse.get_Value(), "no");
    };
}).call(null, WootzJs.Compiler.Tests.Linq.Expressions.ConditionalExpressionTests, WootzJs.Compiler.Tests.Linq.Expressions.ConditionalExpressionTests.prototype);
$WootzJs$Compiler$Tests$AssemblyTypes.push(WootzJs.Compiler.Tests.Linq.Expressions.ConditionalExpressionTests);
WootzJs.Compiler.Tests.Linq.Expressions.ConstantExpressionTests = $define("WootzJs.Compiler.Tests.Linq.Expressions.ConstantExpressionTests");
WootzJs.Compiler.Tests.Linq.Expressions.ConstantExpressionTests.prototype = new System.Object();
(WootzJs.Compiler.Tests.Linq.Expressions.ConstantExpressionTests.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
    $p.$type = WootzJs.Compiler.Tests.Linq.Expressions.ConstantExpressionTests;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Compiler.Tests.Linq.Expressions.ConstantExpressionTests";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("ConstantExpressionTests", [WootzJs.Compiler.Tests.TestFixtureAttribute.prototype.$ctor.$new()]);this.$type.Init("WootzJs.Compiler.Tests.Linq.Expressions.ConstantExpressionTests", WootzJs.Compiler.Tests.Linq.Expressions.ConstantExpressionTests, System.Object, [], [], [System.Reflection.MethodInfo.prototype.$ctor.$new("LocalClosedVariable", WootzJs.Compiler.Tests.Linq.Expressions.ConstantExpressionTests.prototype.LocalClosedVariable, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("Integer", WootzJs.Compiler.Tests.Linq.Expressions.ConstantExpressionTests.prototype.Integer, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("Float", WootzJs.Compiler.Tests.Linq.Expressions.ConstantExpressionTests.prototype.Float, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("Double", WootzJs.Compiler.Tests.Linq.Expressions.ConstantExpressionTests.prototype.Double, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("String", WootzJs.Compiler.Tests.Linq.Expressions.ConstantExpressionTests.prototype.String, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("Boolean", WootzJs.Compiler.Tests.Linq.Expressions.ConstantExpressionTests.prototype.Boolean, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.Linq.Expressions.ConstantExpressionTests.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
    $t.$StaticInitializer = function() {
    };
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.LocalClosedVariable = function() {
        var s = "foo";
        var lambda = (function() {
            var $lambdaparam$x = System.Linq.Expressions.Expression.Parameter$1(String.$GetType(), "x");
            return System.Linq.Expressions.Expression.Lambda((System.Func$2$(String, String)), System.Linq.Expressions.Expression.Constant$1(s, String.$GetType()), [$lambdaparam$x]);
        }).call(this);
        var constantExpression = $cast(System.Linq.Expressions.ConstantExpression, lambda.get_Body());
        QUnit.equal(constantExpression.get_Value(), "foo");
    };
    $p.Integer = function() {
        var lambda = (function() {
            var $lambdaparam$x = System.Linq.Expressions.Expression.Parameter$1(String.$GetType(), "x");
            return System.Linq.Expressions.Expression.Lambda((System.Func$2$(String, System.Int32)), System.Linq.Expressions.Expression.Constant$1(5, System.Int32.$GetType()), [$lambdaparam$x]);
        }).call(this);
        var constantExpression = $cast(System.Linq.Expressions.ConstantExpression, lambda.get_Body());
        QUnit.equal(constantExpression.get_Value(), 5);
    };
    $p.Float = function() {
        var lambda = (function() {
            var $lambdaparam$x = System.Linq.Expressions.Expression.Parameter$1(String.$GetType(), "x");
            return System.Linq.Expressions.Expression.Lambda((System.Func$2$(String, System.Single)), System.Linq.Expressions.Expression.Constant$1(5.4, System.Single.$GetType()), [$lambdaparam$x]);
        }).call(this);
        var constantExpression = $cast(System.Linq.Expressions.ConstantExpression, lambda.get_Body());
        QUnit.equal(constantExpression.get_Value(), 5.4);
    };
    $p.Double = function() {
        var lambda = (function() {
            var $lambdaparam$x = System.Linq.Expressions.Expression.Parameter$1(String.$GetType(), "x");
            return System.Linq.Expressions.Expression.Lambda((System.Func$2$(String, System.Double)), System.Linq.Expressions.Expression.Constant$1(3.40282347E+40, System.Double.$GetType()), [$lambdaparam$x]);
        }).call(this);
        var constantExpression = $cast(System.Linq.Expressions.ConstantExpression, lambda.get_Body());
        QUnit.equal(constantExpression.get_Value(), 3.40282347E+40);
    };
    $p.String = function() {
        var lambda = (function() {
            var $lambdaparam$x = System.Linq.Expressions.Expression.Parameter$1(String.$GetType(), "x");
            return System.Linq.Expressions.Expression.Lambda((System.Func$2$(String, String)), System.Linq.Expressions.Expression.Constant$1("foo", String.$GetType()), [$lambdaparam$x]);
        }).call(this);
        var constantExpression = $cast(System.Linq.Expressions.ConstantExpression, lambda.get_Body());
        QUnit.equal(constantExpression.get_Value(), "foo");
    };
    $p.Boolean = function() {
        var lambda = (function() {
            var $lambdaparam$x = System.Linq.Expressions.Expression.Parameter$1(String.$GetType(), "x");
            return System.Linq.Expressions.Expression.Lambda((System.Func$2$(String, System.Boolean)), System.Linq.Expressions.Expression.Constant$1(true, System.Boolean.$GetType()), [$lambdaparam$x]);
        }).call(this);
        var constantExpression = $cast(System.Linq.Expressions.ConstantExpression, lambda.get_Body());
        QUnit.equal(constantExpression.get_Value(), true);
    };
}).call(null, WootzJs.Compiler.Tests.Linq.Expressions.ConstantExpressionTests, WootzJs.Compiler.Tests.Linq.Expressions.ConstantExpressionTests.prototype);
$WootzJs$Compiler$Tests$AssemblyTypes.push(WootzJs.Compiler.Tests.Linq.Expressions.ConstantExpressionTests);
WootzJs.Compiler.Tests.Linq.Expressions.DefaultExpressionTests = $define("WootzJs.Compiler.Tests.Linq.Expressions.DefaultExpressionTests");
WootzJs.Compiler.Tests.Linq.Expressions.DefaultExpressionTests.prototype = new System.Object();
(WootzJs.Compiler.Tests.Linq.Expressions.DefaultExpressionTests.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
    $p.$type = WootzJs.Compiler.Tests.Linq.Expressions.DefaultExpressionTests;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Compiler.Tests.Linq.Expressions.DefaultExpressionTests";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("DefaultExpressionTests", [WootzJs.Compiler.Tests.TestFixtureAttribute.prototype.$ctor.$new()]);this.$type.Init("WootzJs.Compiler.Tests.Linq.Expressions.DefaultExpressionTests", WootzJs.Compiler.Tests.Linq.Expressions.DefaultExpressionTests, System.Object, [], [], [System.Reflection.MethodInfo.prototype.$ctor.$new("DefaultInt", WootzJs.Compiler.Tests.Linq.Expressions.DefaultExpressionTests.prototype.DefaultInt, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.Linq.Expressions.DefaultExpressionTests.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
    $t.$StaticInitializer = function() {
    };
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.DefaultInt = function() {
        var lambda = (function() {
            return System.Linq.Expressions.Expression.Lambda((System.Func$1$(System.Int32)), System.Linq.Expressions.Expression.Default(System.Int32.$GetType()), []);
        }).call(this);
        var defaultExpression = $cast(System.Linq.Expressions.DefaultExpression, lambda.get_Body());
        QUnit.equal(defaultExpression.get_Type().get_FullName(), System.Int32.$GetType().get_FullName());
    };
}).call(null, WootzJs.Compiler.Tests.Linq.Expressions.DefaultExpressionTests, WootzJs.Compiler.Tests.Linq.Expressions.DefaultExpressionTests.prototype);
$WootzJs$Compiler$Tests$AssemblyTypes.push(WootzJs.Compiler.Tests.Linq.Expressions.DefaultExpressionTests);
WootzJs.Compiler.Tests.Linq.Expressions.IndexExpressionTests = $define("WootzJs.Compiler.Tests.Linq.Expressions.IndexExpressionTests");
WootzJs.Compiler.Tests.Linq.Expressions.IndexExpressionTests.prototype = new System.Object();
(WootzJs.Compiler.Tests.Linq.Expressions.IndexExpressionTests.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
    $p.$type = WootzJs.Compiler.Tests.Linq.Expressions.IndexExpressionTests;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Compiler.Tests.Linq.Expressions.IndexExpressionTests";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("IndexExpressionTests", [WootzJs.Compiler.Tests.TestFixtureAttribute.prototype.$ctor.$new()]);this.$type.Init("WootzJs.Compiler.Tests.Linq.Expressions.IndexExpressionTests", WootzJs.Compiler.Tests.Linq.Expressions.IndexExpressionTests, System.Object, [], [], [System.Reflection.MethodInfo.prototype.$ctor.$new("IndexIntoList", WootzJs.Compiler.Tests.Linq.Expressions.IndexExpressionTests.prototype.IndexIntoList, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("IndexIntoDictionary", WootzJs.Compiler.Tests.Linq.Expressions.IndexExpressionTests.prototype.IndexIntoDictionary, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.Linq.Expressions.IndexExpressionTests.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
    $t.$StaticInitializer = function() {
    };
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.IndexIntoList = function() {
        var list = (function() {
            var $obj$ = (System.Collections.Generic.List$1$(System.Int32)).prototype.$ctor.$new();
            $obj$.Add$1(1);
            $obj$.Add$1(2);
            return $obj$;
        }).call(this);
        var lambda = (function() {
            return System.Linq.Expressions.Expression.Lambda((System.Func$1$(System.Int32)), System.Linq.Expressions.Expression.MakeIndex(System.Linq.Expressions.Expression.Constant$1(list, (System.Collections.Generic.List$1$(System.Int32)).$GetType()), (System.Collections.Generic.List$1$(System.Int32)).$GetType().GetProperty("this[]"), [System.Linq.Expressions.Expression.Constant$1(1, System.Int32.$GetType())]), []);
        }).call(this);
        var callExpression = $cast(System.Linq.Expressions.IndexExpression, lambda.get_Body());
        var target = $cast(System.Linq.Expressions.ConstantExpression, callExpression.get_Object());
        QUnit.equal(target.get_Value(), list);
        var index = $cast(System.Linq.Expressions.ConstantExpression, callExpression.get_Arguments().get_Item(0));
        QUnit.equal(index.get_Value(), 1);
    };
    $p.IndexIntoDictionary = function() {
        var dictionary = (function() {
            var $obj$ = (System.Collections.Generic.Dictionary$2$(System.Int32, String)).prototype.$ctor.$new();
            $obj$.Add$1(1, "foo");
            $obj$.Add$1(2, "bar");
            return $obj$;
        }).call(this);
        var lambda = (function() {
            return System.Linq.Expressions.Expression.Lambda((System.Func$1$(String)), System.Linq.Expressions.Expression.MakeIndex(System.Linq.Expressions.Expression.Constant$1(dictionary, (System.Collections.Generic.Dictionary$2$(System.Int32, String)).$GetType()), (System.Collections.Generic.Dictionary$2$(System.Int32, String)).$GetType().GetProperty("this[]"), [System.Linq.Expressions.Expression.Constant$1(1, System.Int32.$GetType())]), []);
        }).call(this);
        var callExpression = $cast(System.Linq.Expressions.IndexExpression, lambda.get_Body());
        var target = $cast(System.Linq.Expressions.ConstantExpression, callExpression.get_Object());
        QUnit.equal(target.get_Value(), dictionary);
        var index = $cast(System.Linq.Expressions.ConstantExpression, callExpression.get_Arguments().get_Item(0));
        QUnit.equal(index.get_Value(), 1);
    };
}).call(null, WootzJs.Compiler.Tests.Linq.Expressions.IndexExpressionTests, WootzJs.Compiler.Tests.Linq.Expressions.IndexExpressionTests.prototype);
$WootzJs$Compiler$Tests$AssemblyTypes.push(WootzJs.Compiler.Tests.Linq.Expressions.IndexExpressionTests);
WootzJs.Compiler.Tests.Linq.Expressions.InvocationExpressionTests = $define("WootzJs.Compiler.Tests.Linq.Expressions.InvocationExpressionTests");
WootzJs.Compiler.Tests.Linq.Expressions.InvocationExpressionTests.prototype = new System.Object();
(WootzJs.Compiler.Tests.Linq.Expressions.InvocationExpressionTests.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
    $p.$type = WootzJs.Compiler.Tests.Linq.Expressions.InvocationExpressionTests;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Compiler.Tests.Linq.Expressions.InvocationExpressionTests";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("InvocationExpressionTests", [WootzJs.Compiler.Tests.TestFixtureAttribute.prototype.$ctor.$new()]);this.$type.Init("WootzJs.Compiler.Tests.Linq.Expressions.InvocationExpressionTests", WootzJs.Compiler.Tests.Linq.Expressions.InvocationExpressionTests, System.Object, [], [], [System.Reflection.MethodInfo.prototype.$ctor.$new("CallDelegate", WootzJs.Compiler.Tests.Linq.Expressions.InvocationExpressionTests.prototype.CallDelegate, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.Linq.Expressions.InvocationExpressionTests.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
    $t.$StaticInitializer = function() {
    };
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.CallDelegate = function() {
        var func = $delegate(this, (System.Func$2$(System.Int32, System.Int32)), function(x) {
            return x + 1;
        });
        var lambda = (function() {
            return System.Linq.Expressions.Expression.Lambda((System.Func$1$(System.Int32)), System.Linq.Expressions.Expression.Invoke$1(System.Linq.Expressions.Expression.Constant$1(func, (System.Func$2$(System.Int32, System.Int32)).$GetType()), System.Object.$$InitializeArray([System.Linq.Expressions.Expression.Constant$1(5, System.Int32.$GetType())], System.Linq.Expressions.Expression)), []);
        }).call(this);
        var invocation = $cast(System.Linq.Expressions.InvocationExpression, lambda.get_Body());
        var target = $cast(System.Linq.Expressions.ConstantExpression, invocation.get_Expression());
        QUnit.equal(target.get_Value(), func);
        var arg = $cast(System.Linq.Expressions.ConstantExpression, invocation.get_Arguments().get_Item(0));
        QUnit.equal(arg.get_Value(), 5);
    };
}).call(null, WootzJs.Compiler.Tests.Linq.Expressions.InvocationExpressionTests, WootzJs.Compiler.Tests.Linq.Expressions.InvocationExpressionTests.prototype);
$WootzJs$Compiler$Tests$AssemblyTypes.push(WootzJs.Compiler.Tests.Linq.Expressions.InvocationExpressionTests);
WootzJs.Compiler.Tests.Linq.Expressions.LambdaExpressionTests = $define("WootzJs.Compiler.Tests.Linq.Expressions.LambdaExpressionTests");
WootzJs.Compiler.Tests.Linq.Expressions.LambdaExpressionTests.prototype = new System.Object();
(WootzJs.Compiler.Tests.Linq.Expressions.LambdaExpressionTests.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
    $p.$type = WootzJs.Compiler.Tests.Linq.Expressions.LambdaExpressionTests;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Compiler.Tests.Linq.Expressions.LambdaExpressionTests";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("LambdaExpressionTests", [WootzJs.Compiler.Tests.TestFixtureAttribute.prototype.$ctor.$new()]);this.$type.Init("WootzJs.Compiler.Tests.Linq.Expressions.LambdaExpressionTests", WootzJs.Compiler.Tests.Linq.Expressions.LambdaExpressionTests, System.Object, [], [], [System.Reflection.MethodInfo.prototype.$ctor.$new("Func", WootzJs.Compiler.Tests.Linq.Expressions.LambdaExpressionTests.prototype.Func, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.Linq.Expressions.LambdaExpressionTests.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
    $t.$StaticInitializer = function() {
    };
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.Func = function() {
        var lambda = (function() {
            return System.Linq.Expressions.Expression.Lambda((System.Func$1$((System.Func$2$(System.Int32, System.Int32)))), (function() {
                var $lambdaparam$x = System.Linq.Expressions.Expression.Parameter$1(System.Int32.$GetType(), "x");
                return System.Linq.Expressions.Expression.Lambda((System.Func$2$(System.Int32, System.Int32)), $lambdaparam$x, [$lambdaparam$x]);
            }).call(this), []);
        }).call(this);
        var expression = $cast(System.Linq.Expressions.LambdaExpression, lambda.get_Body());
        QUnit.equal(expression.get_Parameters().get_Count(), 1);
        QUnit.equal(expression.get_Body(), expression.get_Parameters().get_Item(0));
    };
}).call(null, WootzJs.Compiler.Tests.Linq.Expressions.LambdaExpressionTests, WootzJs.Compiler.Tests.Linq.Expressions.LambdaExpressionTests.prototype);
$WootzJs$Compiler$Tests$AssemblyTypes.push(WootzJs.Compiler.Tests.Linq.Expressions.LambdaExpressionTests);
WootzJs.Compiler.Tests.Linq.Expressions.ListInitExpressionTests = $define("WootzJs.Compiler.Tests.Linq.Expressions.ListInitExpressionTests");
WootzJs.Compiler.Tests.Linq.Expressions.ListInitExpressionTests.prototype = new System.Object();
(WootzJs.Compiler.Tests.Linq.Expressions.ListInitExpressionTests.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
    $p.$type = WootzJs.Compiler.Tests.Linq.Expressions.ListInitExpressionTests;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Compiler.Tests.Linq.Expressions.ListInitExpressionTests";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("ListInitExpressionTests", [WootzJs.Compiler.Tests.TestFixtureAttribute.prototype.$ctor.$new()]);this.$type.Init("WootzJs.Compiler.Tests.Linq.Expressions.ListInitExpressionTests", WootzJs.Compiler.Tests.Linq.Expressions.ListInitExpressionTests, System.Object, [], [], [System.Reflection.MethodInfo.prototype.$ctor.$new("ListWithInitializer", WootzJs.Compiler.Tests.Linq.Expressions.ListInitExpressionTests.prototype.ListWithInitializer, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("ListWithInitializerTwoElements", WootzJs.Compiler.Tests.Linq.Expressions.ListInitExpressionTests.prototype.ListWithInitializerTwoElements, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("DictionaryWithInitializer", WootzJs.Compiler.Tests.Linq.Expressions.ListInitExpressionTests.prototype.DictionaryWithInitializer, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.Linq.Expressions.ListInitExpressionTests.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
    $t.$StaticInitializer = function() {
    };
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.ListWithInitializer = function() {
        var lambda = (function() {
            return System.Linq.Expressions.Expression.Lambda((System.Func$1$((System.Collections.Generic.List$1$(String)))), System.Linq.Expressions.Expression.ListInit$2(System.Linq.Expressions.Expression.New$3((System.Collections.Generic.List$1$(String)).$GetType().GetConstructor([]), []), System.Object.$$InitializeArray([System.Linq.Expressions.Expression.ElementInit$1((System.Collections.Generic.List$1$(String)).$GetType().GetMethod$2("Add", [System.Object.$GetType()]), System.Object.$$InitializeArray([System.Linq.Expressions.Expression.Constant$1("foo", String.$GetType())], System.Linq.Expressions.Expression))], System.Linq.Expressions.ElementInit)), []);
        }).call(this);
        var listInitExpression = $cast(System.Linq.Expressions.ListInitExpression, lambda.get_Body());
        var newExpression = listInitExpression.get_NewExpression();
        QUnit.equal(newExpression.get_Type().get_FullName(), (System.Collections.Generic.List$1$(String)).$GetType().get_FullName());
        var binding = listInitExpression.get_Initializers().get_Item(0);
        var value = $cast(System.Linq.Expressions.ConstantExpression, binding.get_Arguments().get_Item(0));
        QUnit.equal(value.get_Value(), "foo");
    };
    $p.ListWithInitializerTwoElements = function() {
        var lambda = (function() {
            return System.Linq.Expressions.Expression.Lambda((System.Func$1$((System.Collections.Generic.List$1$(String)))), System.Linq.Expressions.Expression.ListInit$2(System.Linq.Expressions.Expression.New$3((System.Collections.Generic.List$1$(String)).$GetType().GetConstructor([]), []), System.Object.$$InitializeArray([System.Linq.Expressions.Expression.ElementInit$1((System.Collections.Generic.List$1$(String)).$GetType().GetMethod$2("Add", [System.Object.$GetType()]), System.Object.$$InitializeArray([System.Linq.Expressions.Expression.Constant$1("foo", String.$GetType())], System.Linq.Expressions.Expression)), System.Linq.Expressions.Expression.ElementInit$1((System.Collections.Generic.List$1$(String)).$GetType().GetMethod$2("Add", [System.Object.$GetType()]), System.Object.$$InitializeArray([System.Linq.Expressions.Expression.Constant$1("bar", String.$GetType())], System.Linq.Expressions.Expression))], System.Linq.Expressions.ElementInit)), []);
        }).call(this);
        var listInitExpression = $cast(System.Linq.Expressions.ListInitExpression, lambda.get_Body());
        var newExpression = listInitExpression.get_NewExpression();
        QUnit.equal(newExpression.get_Type().get_FullName(), (System.Collections.Generic.List$1$(String)).$GetType().get_FullName());
        var binding1 = listInitExpression.get_Initializers().get_Item(0);
        var binding2 = listInitExpression.get_Initializers().get_Item(1);
        var value1 = $cast(System.Linq.Expressions.ConstantExpression, binding1.get_Arguments().get_Item(0));
        var value2 = $cast(System.Linq.Expressions.ConstantExpression, binding2.get_Arguments().get_Item(0));
        QUnit.equal(value1.get_Value(), "foo");
        QUnit.equal(value2.get_Value(), "bar");
    };
    $p.DictionaryWithInitializer = function() {
        var lambda = (function() {
            return System.Linq.Expressions.Expression.Lambda((System.Func$1$((System.Collections.Generic.Dictionary$2$(String, System.Int32)))), System.Linq.Expressions.Expression.ListInit$2(System.Linq.Expressions.Expression.New$3((System.Collections.Generic.Dictionary$2$(String, System.Int32)).$GetType().GetConstructor([]), []), System.Object.$$InitializeArray([System.Linq.Expressions.Expression.ElementInit$1((System.Collections.Generic.Dictionary$2$(String, System.Int32)).$GetType().GetMethod$2("Add", [String.$GetType(), System.Int32.$GetType()]), System.Object.$$InitializeArray([System.Linq.Expressions.Expression.Constant$1("foo", String.$GetType()), System.Linq.Expressions.Expression.Constant$1(5, System.Int32.$GetType())], System.Linq.Expressions.Expression))], System.Linq.Expressions.ElementInit)), []);
        }).call(this);
        var listInitExpression = $cast(System.Linq.Expressions.ListInitExpression, lambda.get_Body());
        var newExpression = listInitExpression.get_NewExpression();
        QUnit.equal(newExpression.get_Type().get_FullName(), (System.Collections.Generic.Dictionary$2$(String, System.Int32)).$GetType().get_FullName());
        var binding = listInitExpression.get_Initializers().get_Item(0);
        var key = $cast(System.Linq.Expressions.ConstantExpression, binding.get_Arguments().get_Item(0));
        var value = $cast(System.Linq.Expressions.ConstantExpression, binding.get_Arguments().get_Item(1));
        QUnit.equal(key.get_Value(), "foo");
        QUnit.equal(value.get_Value(), 5);
    };
}).call(null, WootzJs.Compiler.Tests.Linq.Expressions.ListInitExpressionTests, WootzJs.Compiler.Tests.Linq.Expressions.ListInitExpressionTests.prototype);
$WootzJs$Compiler$Tests$AssemblyTypes.push(WootzJs.Compiler.Tests.Linq.Expressions.ListInitExpressionTests);
WootzJs.Compiler.Tests.Linq.Expressions.MemberExpressionTests = $define("WootzJs.Compiler.Tests.Linq.Expressions.MemberExpressionTests");
WootzJs.Compiler.Tests.Linq.Expressions.MemberExpressionTests.prototype = new System.Object();
(WootzJs.Compiler.Tests.Linq.Expressions.MemberExpressionTests.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
    $p.$type = WootzJs.Compiler.Tests.Linq.Expressions.MemberExpressionTests;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Compiler.Tests.Linq.Expressions.MemberExpressionTests";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("MemberExpressionTests", [WootzJs.Compiler.Tests.TestFixtureAttribute.prototype.$ctor.$new()]);this.$type.Init("WootzJs.Compiler.Tests.Linq.Expressions.MemberExpressionTests", WootzJs.Compiler.Tests.Linq.Expressions.MemberExpressionTests, System.Object, [], [], [System.Reflection.MethodInfo.prototype.$ctor.$new("Property", WootzJs.Compiler.Tests.Linq.Expressions.MemberExpressionTests.prototype.Property, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.Linq.Expressions.MemberExpressionTests.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
    $t.$StaticInitializer = function() {
    };
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.Property = function() {
        var lambda = (function() {
            var $lambdaparam$x = System.Linq.Expressions.Expression.Parameter$1(WootzJs.Compiler.Tests.Linq.Expressions.MemberExpressionTests.ClassWithMembers.$GetType(), "x");
            return System.Linq.Expressions.Expression.Lambda((System.Func$2$(WootzJs.Compiler.Tests.Linq.Expressions.MemberExpressionTests.ClassWithMembers, String)), System.Linq.Expressions.Expression.MakeMemberAccess($lambdaparam$x, WootzJs.Compiler.Tests.Linq.Expressions.MemberExpressionTests.ClassWithMembers.$GetType().GetProperty("StringProperty")), [$lambdaparam$x]);
        }).call(this);
        var memberExpression = $cast(System.Linq.Expressions.MemberExpression, lambda.get_Body());
        QUnit.equal(memberExpression.get_Expression(), lambda.get_Parameters().get_Item(0));
        QUnit.ok(System.Reflection.PropertyInfo.$GetType().IsInstanceOfType(memberExpression.get_Member()));
        QUnit.equal(memberExpression.get_Member().get_Name(), "StringProperty");
    };
    function ClassWithMembers($constructor) {
        if (!$t.ClassWithMembers.$isStaticInitialized && ($constructor != null || !(this instanceof WootzJs.Compiler.Tests.Linq.Expressions.MemberExpressionTests.ClassWithMembers))) {
            $t.ClassWithMembers.$isStaticInitialized = true;
            $t.ClassWithMembers.$StaticInitializer();
        }
        if ($constructor != null)
            $constructor.apply(this, Array.prototype.slice.call(arguments, 1));
        if (!(this instanceof WootzJs.Compiler.Tests.Linq.Expressions.MemberExpressionTests.ClassWithMembers))
            return $t.ClassWithMembers;
    }
    $t.ClassWithMembers = ClassWithMembers;
    $t.ClassWithMembers.prototype = new System.Object();
    ($t.ClassWithMembers.$TypeInitializer = function($t, $p) {
        $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
        $p.$type = WootzJs.Compiler.Tests.Linq.Expressions.MemberExpressionTests.ClassWithMembers;
        $t.$baseType = System.Object;
        $p.$typeName = "WootzJs.Compiler.Tests.Linq.Expressions.MemberExpressionTests.ClassWithMembers";
        $t.$typeName = $p.$typeName;
        $t.$GetType = function() {
            return System.Type._GetTypeFromTypeFunc(this);
        };
        $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("ClassWithMembers", []);this.$type.Init("WootzJs.Compiler.Tests.Linq.Expressions.MemberExpressionTests.ClassWithMembers", WootzJs.Compiler.Tests.Linq.Expressions.MemberExpressionTests.ClassWithMembers, System.Object, [], [System.Reflection.FieldInfo.prototype.$ctor.$new("$StringProperty$k__BackingField", String, System.Reflection.FieldAttributes().Private, null, []), System.Reflection.FieldInfo.prototype.$ctor.$new("IntField", System.Int32, System.Reflection.FieldAttributes().Public, null, [])], [System.Reflection.MethodInfo.prototype.$ctor.$new("get_StringProperty", WootzJs.Compiler.Tests.Linq.Expressions.MemberExpressionTests.ClassWithMembers.prototype.get_StringProperty, [], String, System.Reflection.MethodAttributes().Public, []), System.Reflection.MethodInfo.prototype.$ctor.$new("set_StringProperty", WootzJs.Compiler.Tests.Linq.Expressions.MemberExpressionTests.ClassWithMembers.prototype.set_StringProperty, [System.Reflection.ParameterInfo.prototype.$ctor.$new("value", String, 0, 0, null, [])], System.Void, System.Reflection.MethodAttributes().Public, [])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.Linq.Expressions.MemberExpressionTests.ClassWithMembers.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, [])], [System.Reflection.PropertyInfo.prototype.$ctor.$new("StringProperty", String, System.Reflection.MethodInfo.prototype.$ctor.$new("get_StringProperty", WootzJs.Compiler.Tests.Linq.Expressions.MemberExpressionTests.ClassWithMembers.prototype.get_StringProperty, [], String, System.Reflection.MethodAttributes().Public, []), System.Reflection.MethodInfo.prototype.$ctor.$new("set_StringProperty", WootzJs.Compiler.Tests.Linq.Expressions.MemberExpressionTests.ClassWithMembers.prototype.set_StringProperty, [System.Reflection.ParameterInfo.prototype.$ctor.$new("value", String, 0, 0, null, [])], System.Void, System.Reflection.MethodAttributes().Public, []), [], [])], [], false);return this.$type;};
        $t.$StaticInitializer = function() {
        };
        $p.$ctor = function() {
            System.Object.prototype.$ctor.call(this);
        };
        $p.$ctor.$type = $t;
        $p.$ctor.$new = function() {
            return new $p.$ctor.$type(this);
        };
        $p.$StringProperty$k__BackingField = null;
        $p.get_StringProperty = function() {
            return this.$StringProperty$k__BackingField;
        };
        $p.set_StringProperty = function(value) {
            this.$StringProperty$k__BackingField = value;
        };
        $p.IntField = null;
    }).call($t, $t.ClassWithMembers, $t.ClassWithMembers.prototype);
    $WootzJs$Compiler$Tests$AssemblyTypes.push($t.ClassWithMembers);
}).call(null, WootzJs.Compiler.Tests.Linq.Expressions.MemberExpressionTests, WootzJs.Compiler.Tests.Linq.Expressions.MemberExpressionTests.prototype);
$WootzJs$Compiler$Tests$AssemblyTypes.push(WootzJs.Compiler.Tests.Linq.Expressions.MemberExpressionTests);
WootzJs.Compiler.Tests.Linq.Expressions.MemberInitExpressionTests = $define("WootzJs.Compiler.Tests.Linq.Expressions.MemberInitExpressionTests");
WootzJs.Compiler.Tests.Linq.Expressions.MemberInitExpressionTests.prototype = new System.Object();
(WootzJs.Compiler.Tests.Linq.Expressions.MemberInitExpressionTests.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
    $p.$type = WootzJs.Compiler.Tests.Linq.Expressions.MemberInitExpressionTests;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Compiler.Tests.Linq.Expressions.MemberInitExpressionTests";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("MemberInitExpressionTests", [WootzJs.Compiler.Tests.TestFixtureAttribute.prototype.$ctor.$new()]);this.$type.Init("WootzJs.Compiler.Tests.Linq.Expressions.MemberInitExpressionTests", WootzJs.Compiler.Tests.Linq.Expressions.MemberInitExpressionTests, System.Object, [], [], [System.Reflection.MethodInfo.prototype.$ctor.$new("ConstructorNoArgOneInitializer", WootzJs.Compiler.Tests.Linq.Expressions.MemberInitExpressionTests.prototype.ConstructorNoArgOneInitializer, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.Linq.Expressions.MemberInitExpressionTests.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
    $t.$StaticInitializer = function() {
    };
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.ConstructorNoArgOneInitializer = function() {
        var lambda = (function() {
            return System.Linq.Expressions.Expression.Lambda((System.Func$1$(WootzJs.Compiler.Tests.Linq.Expressions.MemberInitExpressionTests.CreateClass)), System.Linq.Expressions.Expression.MemberInit$1(System.Linq.Expressions.Expression.New$3(WootzJs.Compiler.Tests.Linq.Expressions.MemberInitExpressionTests.CreateClass.$GetType().GetConstructor([]), []), System.Object.$$InitializeArray([System.Linq.Expressions.Expression.Bind(WootzJs.Compiler.Tests.Linq.Expressions.MemberInitExpressionTests.CreateClass.$GetType().GetProperty("StringProperty"), System.Linq.Expressions.Expression.Constant$1("foo", String.$GetType()))], System.Linq.Expressions.MemberBinding)), []);
        }).call(this);
        var memberInitExpression = $cast(System.Linq.Expressions.MemberInitExpression, lambda.get_Body());
        var newExpression = memberInitExpression.get_NewExpression();
        QUnit.equal(newExpression.get_Type().get_FullName(), WootzJs.Compiler.Tests.Linq.Expressions.MemberInitExpressionTests.CreateClass.$GetType().get_FullName());
        var binding = $cast(System.Linq.Expressions.MemberAssignment, memberInitExpression.get_Bindings().get_Item(0));
        var value = $cast(System.Linq.Expressions.ConstantExpression, binding.get_Expression());
        QUnit.equal(value.get_Value(), "foo");
    };
    function CreateClass($constructor) {
        if (!$t.CreateClass.$isStaticInitialized && ($constructor != null || !(this instanceof WootzJs.Compiler.Tests.Linq.Expressions.MemberInitExpressionTests.CreateClass))) {
            $t.CreateClass.$isStaticInitialized = true;
            $t.CreateClass.$StaticInitializer();
        }
        if ($constructor != null)
            $constructor.apply(this, Array.prototype.slice.call(arguments, 1));
        if (!(this instanceof WootzJs.Compiler.Tests.Linq.Expressions.MemberInitExpressionTests.CreateClass))
            return $t.CreateClass;
    }
    $t.CreateClass = CreateClass;
    $t.CreateClass.prototype = new System.Object();
    ($t.CreateClass.$TypeInitializer = function($t, $p) {
        $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
        $p.$type = WootzJs.Compiler.Tests.Linq.Expressions.MemberInitExpressionTests.CreateClass;
        $t.$baseType = System.Object;
        $p.$typeName = "WootzJs.Compiler.Tests.Linq.Expressions.MemberInitExpressionTests.CreateClass";
        $t.$typeName = $p.$typeName;
        $t.$GetType = function() {
            return System.Type._GetTypeFromTypeFunc(this);
        };
        $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("CreateClass", []);this.$type.Init("WootzJs.Compiler.Tests.Linq.Expressions.MemberInitExpressionTests.CreateClass", WootzJs.Compiler.Tests.Linq.Expressions.MemberInitExpressionTests.CreateClass, System.Object, [], [System.Reflection.FieldInfo.prototype.$ctor.$new("$StringProperty$k__BackingField", String, System.Reflection.FieldAttributes().Private, null, [])], [System.Reflection.MethodInfo.prototype.$ctor.$new("get_StringProperty", WootzJs.Compiler.Tests.Linq.Expressions.MemberInitExpressionTests.CreateClass.prototype.get_StringProperty, [], String, System.Reflection.MethodAttributes().Public, []), System.Reflection.MethodInfo.prototype.$ctor.$new("set_StringProperty", WootzJs.Compiler.Tests.Linq.Expressions.MemberInitExpressionTests.CreateClass.prototype.set_StringProperty, [System.Reflection.ParameterInfo.prototype.$ctor.$new("value", String, 0, 0, null, [])], System.Void, System.Reflection.MethodAttributes().Public, [])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.Linq.Expressions.MemberInitExpressionTests.CreateClass.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, []), System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor$1", WootzJs.Compiler.Tests.Linq.Expressions.MemberInitExpressionTests.CreateClass.prototype.$ctor$1, [System.Reflection.ParameterInfo.prototype.$ctor.$new("stringProperty", String, 0, 0, null, [])], System.Reflection.MethodAttributes().Public, [])], [System.Reflection.PropertyInfo.prototype.$ctor.$new("StringProperty", String, System.Reflection.MethodInfo.prototype.$ctor.$new("get_StringProperty", WootzJs.Compiler.Tests.Linq.Expressions.MemberInitExpressionTests.CreateClass.prototype.get_StringProperty, [], String, System.Reflection.MethodAttributes().Public, []), System.Reflection.MethodInfo.prototype.$ctor.$new("set_StringProperty", WootzJs.Compiler.Tests.Linq.Expressions.MemberInitExpressionTests.CreateClass.prototype.set_StringProperty, [System.Reflection.ParameterInfo.prototype.$ctor.$new("value", String, 0, 0, null, [])], System.Void, System.Reflection.MethodAttributes().Public, []), [], [])], [], false);return this.$type;};
        $t.$StaticInitializer = function() {
        };
        $p.$StringProperty$k__BackingField = null;
        $p.get_StringProperty = function() {
            return this.$StringProperty$k__BackingField;
        };
        $p.set_StringProperty = function(value) {
            this.$StringProperty$k__BackingField = value;
        };
        $p.$ctor = function() {
            System.Object.prototype.$ctor.call(this);
        };
        $p.$ctor.$type = $t;
        $p.$ctor.$new = function() {
            return new $p.$ctor.$type(this);
        };
        $p.$ctor$1 = function(stringProperty) {
            System.Object.prototype.$ctor.call(this);
            this.set_StringProperty(stringProperty);
        };
        $p.$ctor$1.$type = $t;
        $p.$ctor$1.$new = function(stringProperty) {
            return new $p.$ctor$1.$type(this, stringProperty);
        };
    }).call($t, $t.CreateClass, $t.CreateClass.prototype);
    $WootzJs$Compiler$Tests$AssemblyTypes.push($t.CreateClass);
}).call(null, WootzJs.Compiler.Tests.Linq.Expressions.MemberInitExpressionTests, WootzJs.Compiler.Tests.Linq.Expressions.MemberInitExpressionTests.prototype);
$WootzJs$Compiler$Tests$AssemblyTypes.push(WootzJs.Compiler.Tests.Linq.Expressions.MemberInitExpressionTests);
WootzJs.Compiler.Tests.Linq.Expressions.MethodCallExpressionTests = $define("WootzJs.Compiler.Tests.Linq.Expressions.MethodCallExpressionTests");
WootzJs.Compiler.Tests.Linq.Expressions.MethodCallExpressionTests.prototype = new System.Object();
(WootzJs.Compiler.Tests.Linq.Expressions.MethodCallExpressionTests.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
    $p.$type = WootzJs.Compiler.Tests.Linq.Expressions.MethodCallExpressionTests;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Compiler.Tests.Linq.Expressions.MethodCallExpressionTests";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("MethodCallExpressionTests", [WootzJs.Compiler.Tests.TestFixtureAttribute.prototype.$ctor.$new()]);this.$type.Init("WootzJs.Compiler.Tests.Linq.Expressions.MethodCallExpressionTests", WootzJs.Compiler.Tests.Linq.Expressions.MethodCallExpressionTests, System.Object, [], [], [System.Reflection.MethodInfo.prototype.$ctor.$new("CallZeroParameterStaticMethod", WootzJs.Compiler.Tests.Linq.Expressions.MethodCallExpressionTests.prototype.CallZeroParameterStaticMethod, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("CallOneParameterStaticMethod", WootzJs.Compiler.Tests.Linq.Expressions.MethodCallExpressionTests.prototype.CallOneParameterStaticMethod, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("CallZeroParameterInstanceMethod", WootzJs.Compiler.Tests.Linq.Expressions.MethodCallExpressionTests.prototype.CallZeroParameterInstanceMethod, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.Linq.Expressions.MethodCallExpressionTests.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
    $t.$StaticInitializer = function() {
    };
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.CallZeroParameterStaticMethod = function() {
        var lambda = (function() {
            return System.Linq.Expressions.Expression.Lambda(System.Action, System.Linq.Expressions.Expression.Call(WootzJs.Compiler.Tests.Linq.Expressions.MethodCallExpressionTests.ClassWithMethods.$GetType().GetMethod$2("ZeroParameterStaticMethod", []), []), []);
        }).call(this);
        var methodCallExpression = $cast(System.Linq.Expressions.MethodCallExpression, lambda.get_Body());
        QUnit.equal(methodCallExpression.get_Method().get_Name(), "ZeroParameterStaticMethod");
    };
    $p.CallOneParameterStaticMethod = function() {
        var lambda = (function() {
            return System.Linq.Expressions.Expression.Lambda(System.Action, System.Linq.Expressions.Expression.Call(WootzJs.Compiler.Tests.Linq.Expressions.MethodCallExpressionTests.ClassWithMethods.$GetType().GetMethod$2("OneParameterStaticMethod", [String.$GetType()]), [System.Linq.Expressions.Expression.Constant$1("foo", String.$GetType())]), []);
        }).call(this);
        var methodCallExpression = $cast(System.Linq.Expressions.MethodCallExpression, lambda.get_Body());
        QUnit.equal(methodCallExpression.get_Method().get_Name(), "OneParameterStaticMethod");
        var argument = $cast(System.Linq.Expressions.ConstantExpression, methodCallExpression.get_Arguments().get_Item(0));
        QUnit.equal(argument.get_Value(), "foo");
    };
    $p.CallZeroParameterInstanceMethod = function() {
        var instance = WootzJs.Compiler.Tests.Linq.Expressions.MethodCallExpressionTests.ClassWithMethods.prototype.$ctor.$new();
        var lambda = (function() {
            return System.Linq.Expressions.Expression.Lambda(System.Action, System.Linq.Expressions.Expression.Call$1(System.Linq.Expressions.Expression.Constant$1(instance, WootzJs.Compiler.Tests.Linq.Expressions.MethodCallExpressionTests.ClassWithMethods.$GetType()), WootzJs.Compiler.Tests.Linq.Expressions.MethodCallExpressionTests.ClassWithMethods.$GetType().GetMethod$2("ZeroParameterInstanceMethod", []), System.Object.$$InitializeArray([], System.Linq.Expressions.Expression)), []);
        }).call(this);
        var methodCallExpression = $cast(System.Linq.Expressions.MethodCallExpression, lambda.get_Body());
        QUnit.equal(methodCallExpression.get_Method().get_Name(), "ZeroParameterInstanceMethod");
        var target = $cast(System.Linq.Expressions.ConstantExpression, methodCallExpression.get_Object());
        QUnit.equal(target.get_Value(), instance);
    };
    function ClassWithMethods($constructor) {
        if (!$t.ClassWithMethods.$isStaticInitialized && ($constructor != null || !(this instanceof WootzJs.Compiler.Tests.Linq.Expressions.MethodCallExpressionTests.ClassWithMethods))) {
            $t.ClassWithMethods.$isStaticInitialized = true;
            $t.ClassWithMethods.$StaticInitializer();
        }
        if ($constructor != null)
            $constructor.apply(this, Array.prototype.slice.call(arguments, 1));
        if (!(this instanceof WootzJs.Compiler.Tests.Linq.Expressions.MethodCallExpressionTests.ClassWithMethods))
            return $t.ClassWithMethods;
    }
    $t.ClassWithMethods = ClassWithMethods;
    $t.ClassWithMethods.prototype = new System.Object();
    ($t.ClassWithMethods.$TypeInitializer = function($t, $p) {
        $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
        $p.$type = WootzJs.Compiler.Tests.Linq.Expressions.MethodCallExpressionTests.ClassWithMethods;
        $t.$baseType = System.Object;
        $p.$typeName = "WootzJs.Compiler.Tests.Linq.Expressions.MethodCallExpressionTests.ClassWithMethods";
        $t.$typeName = $p.$typeName;
        $t.$GetType = function() {
            return System.Type._GetTypeFromTypeFunc(this);
        };
        $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("ClassWithMethods", []);this.$type.Init("WootzJs.Compiler.Tests.Linq.Expressions.MethodCallExpressionTests.ClassWithMethods", WootzJs.Compiler.Tests.Linq.Expressions.MethodCallExpressionTests.ClassWithMethods, System.Object, [], [], [System.Reflection.MethodInfo.prototype.$ctor.$new("ZeroParameterStaticMethod", WootzJs.Compiler.Tests.Linq.Expressions.MethodCallExpressionTests.ClassWithMethods.prototype.ZeroParameterStaticMethod, [], System.Void, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, []), System.Reflection.MethodInfo.prototype.$ctor.$new("OneParameterStaticMethod", WootzJs.Compiler.Tests.Linq.Expressions.MethodCallExpressionTests.ClassWithMethods.prototype.OneParameterStaticMethod, [System.Reflection.ParameterInfo.prototype.$ctor.$new("parameter", String, 0, 0, null, [])], System.Void, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, []), System.Reflection.MethodInfo.prototype.$ctor.$new("ZeroParameterInstanceMethod", WootzJs.Compiler.Tests.Linq.Expressions.MethodCallExpressionTests.ClassWithMethods.prototype.ZeroParameterInstanceMethod, [], System.Void, System.Reflection.MethodAttributes().Public, [])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.Linq.Expressions.MethodCallExpressionTests.ClassWithMethods.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
        $t.$StaticInitializer = function() {
        };
        $p.$ctor = function() {
            System.Object.prototype.$ctor.call(this);
        };
        $p.$ctor.$type = $t;
        $p.$ctor.$new = function() {
            return new $p.$ctor.$type(this);
        };
        $t.ZeroParameterStaticMethod = function() {
        };
        $t.OneParameterStaticMethod = function(parameter) {
        };
        $p.ZeroParameterInstanceMethod = function() {
        };
    }).call($t, $t.ClassWithMethods, $t.ClassWithMethods.prototype);
    $WootzJs$Compiler$Tests$AssemblyTypes.push($t.ClassWithMethods);
}).call(null, WootzJs.Compiler.Tests.Linq.Expressions.MethodCallExpressionTests, WootzJs.Compiler.Tests.Linq.Expressions.MethodCallExpressionTests.prototype);
$WootzJs$Compiler$Tests$AssemblyTypes.push(WootzJs.Compiler.Tests.Linq.Expressions.MethodCallExpressionTests);
WootzJs.Compiler.Tests.Linq.Expressions.NewArrayExpressionTests = $define("WootzJs.Compiler.Tests.Linq.Expressions.NewArrayExpressionTests");
WootzJs.Compiler.Tests.Linq.Expressions.NewArrayExpressionTests.prototype = new System.Object();
(WootzJs.Compiler.Tests.Linq.Expressions.NewArrayExpressionTests.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
    $p.$type = WootzJs.Compiler.Tests.Linq.Expressions.NewArrayExpressionTests;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Compiler.Tests.Linq.Expressions.NewArrayExpressionTests";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("NewArrayExpressionTests", [WootzJs.Compiler.Tests.TestFixtureAttribute.prototype.$ctor.$new()]);this.$type.Init("WootzJs.Compiler.Tests.Linq.Expressions.NewArrayExpressionTests", WootzJs.Compiler.Tests.Linq.Expressions.NewArrayExpressionTests, System.Object, [], [], [System.Reflection.MethodInfo.prototype.$ctor.$new("NewArrayOneDimensionNoInitializer", WootzJs.Compiler.Tests.Linq.Expressions.NewArrayExpressionTests.prototype.NewArrayOneDimensionNoInitializer, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("NewArrayWithInitializer", WootzJs.Compiler.Tests.Linq.Expressions.NewArrayExpressionTests.prototype.NewArrayWithInitializer, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("NewJaggedArrayWithInitializer", WootzJs.Compiler.Tests.Linq.Expressions.NewArrayExpressionTests.prototype.NewJaggedArrayWithInitializer, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.Linq.Expressions.NewArrayExpressionTests.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
    $t.$StaticInitializer = function() {
    };
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.NewArrayOneDimensionNoInitializer = function() {
        var lambda = (function() {
            return System.Linq.Expressions.Expression.Lambda((System.Func$1$(System.Object.$$MakeArrayType(System.Int32))), System.Linq.Expressions.Expression.NewArrayBounds$1(System.Int32.$GetType(), System.Object.$$InitializeArray([System.Linq.Expressions.Expression.Constant$1(5, System.Int32.$GetType())], System.Linq.Expressions.Expression)), []);
        }).call(this);
        var newArrayExpression = $cast(System.Linq.Expressions.NewArrayExpression, lambda.get_Body());
        QUnit.equal(newArrayExpression.get_NodeType(), System.Linq.Expressions.ExpressionType().NewArrayBounds);
        var value = $cast(System.Linq.Expressions.ConstantExpression, newArrayExpression.get_Expressions().get_Item(0));
        QUnit.equal(value.get_Value(), 5);
    };
    $p.NewArrayWithInitializer = function() {
        var lambda = (function() {
            return System.Linq.Expressions.Expression.Lambda((System.Func$1$(System.Object.$$MakeArrayType(System.Int32))), System.Linq.Expressions.Expression.NewArrayInit$1(System.Int32.$GetType(), System.Object.$$InitializeArray([System.Linq.Expressions.Expression.Constant$1(1, System.Int32.$GetType()), System.Linq.Expressions.Expression.Constant$1(2, System.Int32.$GetType())], System.Linq.Expressions.Expression)), []);
        }).call(this);
        var newArrayExpression = $cast(System.Linq.Expressions.NewArrayExpression, lambda.get_Body());
        QUnit.equal(newArrayExpression.get_NodeType(), System.Linq.Expressions.ExpressionType().NewArrayInit);
        var value1 = $cast(System.Linq.Expressions.ConstantExpression, newArrayExpression.get_Expressions().get_Item(0));
        var value2 = $cast(System.Linq.Expressions.ConstantExpression, newArrayExpression.get_Expressions().get_Item(1));
        QUnit.equal(value1.get_Value(), 1);
        QUnit.equal(value2.get_Value(), 2);
    };
    $p.NewJaggedArrayWithInitializer = function() {
        var lambda = (function() {
            return System.Linq.Expressions.Expression.Lambda((System.Func$1$(System.Object.$$MakeArrayType(System.Object.$$MakeArrayType(System.Int32)))), System.Linq.Expressions.Expression.NewArrayInit$1(System.Object.$$MakeArrayType(System.Int32).$GetType(), System.Object.$$InitializeArray([System.Linq.Expressions.Expression.NewArrayInit$1(System.Int32.$GetType(), System.Object.$$InitializeArray([System.Linq.Expressions.Expression.Constant$1(1, System.Int32.$GetType()), System.Linq.Expressions.Expression.Constant$1(2, System.Int32.$GetType())], System.Linq.Expressions.Expression)), System.Linq.Expressions.Expression.NewArrayInit$1(System.Int32.$GetType(), System.Object.$$InitializeArray([System.Linq.Expressions.Expression.Constant$1(3, System.Int32.$GetType()), System.Linq.Expressions.Expression.Constant$1(4, System.Int32.$GetType())], System.Linq.Expressions.Expression))], System.Linq.Expressions.Expression)), []);
        }).call(this);
        var newArrayExpression = $cast(System.Linq.Expressions.NewArrayExpression, lambda.get_Body());
        QUnit.equal(newArrayExpression.get_NodeType(), System.Linq.Expressions.ExpressionType().NewArrayInit);
        var array1 = $cast(System.Linq.Expressions.NewArrayExpression, newArrayExpression.get_Expressions().get_Item(0));
        var array2 = $cast(System.Linq.Expressions.NewArrayExpression, newArrayExpression.get_Expressions().get_Item(1));
        var value1 = $cast(System.Linq.Expressions.ConstantExpression, array1.get_Expressions().get_Item(0));
        var value2 = $cast(System.Linq.Expressions.ConstantExpression, array1.get_Expressions().get_Item(1));
        var value3 = $cast(System.Linq.Expressions.ConstantExpression, array2.get_Expressions().get_Item(0));
        var value4 = $cast(System.Linq.Expressions.ConstantExpression, array2.get_Expressions().get_Item(1));
        QUnit.equal(value1.get_Value(), 1);
        QUnit.equal(value2.get_Value(), 2);
        QUnit.equal(value3.get_Value(), 3);
        QUnit.equal(value4.get_Value(), 4);
    };
}).call(null, WootzJs.Compiler.Tests.Linq.Expressions.NewArrayExpressionTests, WootzJs.Compiler.Tests.Linq.Expressions.NewArrayExpressionTests.prototype);
$WootzJs$Compiler$Tests$AssemblyTypes.push(WootzJs.Compiler.Tests.Linq.Expressions.NewArrayExpressionTests);
WootzJs.Compiler.Tests.Linq.Expressions.NewExpressionTests = $define("WootzJs.Compiler.Tests.Linq.Expressions.NewExpressionTests");
WootzJs.Compiler.Tests.Linq.Expressions.NewExpressionTests.prototype = new System.Object();
(WootzJs.Compiler.Tests.Linq.Expressions.NewExpressionTests.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
    $p.$type = WootzJs.Compiler.Tests.Linq.Expressions.NewExpressionTests;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Compiler.Tests.Linq.Expressions.NewExpressionTests";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("NewExpressionTests", [WootzJs.Compiler.Tests.TestFixtureAttribute.prototype.$ctor.$new()]);this.$type.Init("WootzJs.Compiler.Tests.Linq.Expressions.NewExpressionTests", WootzJs.Compiler.Tests.Linq.Expressions.NewExpressionTests, System.Object, [], [], [System.Reflection.MethodInfo.prototype.$ctor.$new("ConstructorNoArgsOrInitializers", WootzJs.Compiler.Tests.Linq.Expressions.NewExpressionTests.prototype.ConstructorNoArgsOrInitializers, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("ConstructorOneArgNoInitializers", WootzJs.Compiler.Tests.Linq.Expressions.NewExpressionTests.prototype.ConstructorOneArgNoInitializers, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.Linq.Expressions.NewExpressionTests.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
    $t.$StaticInitializer = function() {
    };
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.ConstructorNoArgsOrInitializers = function() {
        var lambda = (function() {
            return System.Linq.Expressions.Expression.Lambda((System.Func$1$(WootzJs.Compiler.Tests.Linq.Expressions.NewExpressionTests.CreateClass)), System.Linq.Expressions.Expression.New$3(WootzJs.Compiler.Tests.Linq.Expressions.NewExpressionTests.CreateClass.$GetType().GetConstructor([]), []), []);
        }).call(this);
        var newExpression = $cast(System.Linq.Expressions.NewExpression, lambda.get_Body());
        QUnit.equal(newExpression.get_Type().get_FullName(), WootzJs.Compiler.Tests.Linq.Expressions.NewExpressionTests.CreateClass.$GetType().get_FullName());
    };
    $p.ConstructorOneArgNoInitializers = function() {
        var lambda = (function() {
            return System.Linq.Expressions.Expression.Lambda((System.Func$1$(WootzJs.Compiler.Tests.Linq.Expressions.NewExpressionTests.CreateClass)), System.Linq.Expressions.Expression.New$3(WootzJs.Compiler.Tests.Linq.Expressions.NewExpressionTests.CreateClass.$GetType().GetConstructor([String.$GetType()]), [System.Linq.Expressions.Expression.Constant$1("foo", String.$GetType())]), []);
        }).call(this);
        var newExpression = $cast(System.Linq.Expressions.NewExpression, lambda.get_Body());
        QUnit.equal(newExpression.get_Type().get_FullName(), WootzJs.Compiler.Tests.Linq.Expressions.NewExpressionTests.CreateClass.$GetType().get_FullName());
        var arg = $cast(System.Linq.Expressions.ConstantExpression, newExpression.get_Arguments().get_Item(0));
        QUnit.equal(arg.get_Value(), "foo");
    };
    function CreateClass($constructor) {
        if (!$t.CreateClass.$isStaticInitialized && ($constructor != null || !(this instanceof WootzJs.Compiler.Tests.Linq.Expressions.NewExpressionTests.CreateClass))) {
            $t.CreateClass.$isStaticInitialized = true;
            $t.CreateClass.$StaticInitializer();
        }
        if ($constructor != null)
            $constructor.apply(this, Array.prototype.slice.call(arguments, 1));
        if (!(this instanceof WootzJs.Compiler.Tests.Linq.Expressions.NewExpressionTests.CreateClass))
            return $t.CreateClass;
    }
    $t.CreateClass = CreateClass;
    $t.CreateClass.prototype = new System.Object();
    ($t.CreateClass.$TypeInitializer = function($t, $p) {
        $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
        $p.$type = WootzJs.Compiler.Tests.Linq.Expressions.NewExpressionTests.CreateClass;
        $t.$baseType = System.Object;
        $p.$typeName = "WootzJs.Compiler.Tests.Linq.Expressions.NewExpressionTests.CreateClass";
        $t.$typeName = $p.$typeName;
        $t.$GetType = function() {
            return System.Type._GetTypeFromTypeFunc(this);
        };
        $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("CreateClass", []);this.$type.Init("WootzJs.Compiler.Tests.Linq.Expressions.NewExpressionTests.CreateClass", WootzJs.Compiler.Tests.Linq.Expressions.NewExpressionTests.CreateClass, System.Object, [], [System.Reflection.FieldInfo.prototype.$ctor.$new("$StringProperty$k__BackingField", String, System.Reflection.FieldAttributes().Private, null, [])], [System.Reflection.MethodInfo.prototype.$ctor.$new("get_StringProperty", WootzJs.Compiler.Tests.Linq.Expressions.NewExpressionTests.CreateClass.prototype.get_StringProperty, [], String, System.Reflection.MethodAttributes().Public, []), System.Reflection.MethodInfo.prototype.$ctor.$new("set_StringProperty", WootzJs.Compiler.Tests.Linq.Expressions.NewExpressionTests.CreateClass.prototype.set_StringProperty, [System.Reflection.ParameterInfo.prototype.$ctor.$new("value", String, 0, 0, null, [])], System.Void, System.Reflection.MethodAttributes().Public, [])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.Linq.Expressions.NewExpressionTests.CreateClass.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, []), System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor$1", WootzJs.Compiler.Tests.Linq.Expressions.NewExpressionTests.CreateClass.prototype.$ctor$1, [System.Reflection.ParameterInfo.prototype.$ctor.$new("stringProperty", String, 0, 0, null, [])], System.Reflection.MethodAttributes().Public, [])], [System.Reflection.PropertyInfo.prototype.$ctor.$new("StringProperty", String, System.Reflection.MethodInfo.prototype.$ctor.$new("get_StringProperty", WootzJs.Compiler.Tests.Linq.Expressions.NewExpressionTests.CreateClass.prototype.get_StringProperty, [], String, System.Reflection.MethodAttributes().Public, []), System.Reflection.MethodInfo.prototype.$ctor.$new("set_StringProperty", WootzJs.Compiler.Tests.Linq.Expressions.NewExpressionTests.CreateClass.prototype.set_StringProperty, [System.Reflection.ParameterInfo.prototype.$ctor.$new("value", String, 0, 0, null, [])], System.Void, System.Reflection.MethodAttributes().Public, []), [], [])], [], false);return this.$type;};
        $t.$StaticInitializer = function() {
        };
        $p.$StringProperty$k__BackingField = null;
        $p.get_StringProperty = function() {
            return this.$StringProperty$k__BackingField;
        };
        $p.set_StringProperty = function(value) {
            this.$StringProperty$k__BackingField = value;
        };
        $p.$ctor = function() {
            System.Object.prototype.$ctor.call(this);
        };
        $p.$ctor.$type = $t;
        $p.$ctor.$new = function() {
            return new $p.$ctor.$type(this);
        };
        $p.$ctor$1 = function(stringProperty) {
            System.Object.prototype.$ctor.call(this);
            this.set_StringProperty(stringProperty);
        };
        $p.$ctor$1.$type = $t;
        $p.$ctor$1.$new = function(stringProperty) {
            return new $p.$ctor$1.$type(this, stringProperty);
        };
    }).call($t, $t.CreateClass, $t.CreateClass.prototype);
    $WootzJs$Compiler$Tests$AssemblyTypes.push($t.CreateClass);
}).call(null, WootzJs.Compiler.Tests.Linq.Expressions.NewExpressionTests, WootzJs.Compiler.Tests.Linq.Expressions.NewExpressionTests.prototype);
$WootzJs$Compiler$Tests$AssemblyTypes.push(WootzJs.Compiler.Tests.Linq.Expressions.NewExpressionTests);
WootzJs.Compiler.Tests.Linq.Expressions.ParameterExpressionTests = $define("WootzJs.Compiler.Tests.Linq.Expressions.ParameterExpressionTests");
WootzJs.Compiler.Tests.Linq.Expressions.ParameterExpressionTests.prototype = new System.Object();
(WootzJs.Compiler.Tests.Linq.Expressions.ParameterExpressionTests.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
    $p.$type = WootzJs.Compiler.Tests.Linq.Expressions.ParameterExpressionTests;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Compiler.Tests.Linq.Expressions.ParameterExpressionTests";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("ParameterExpressionTests", [WootzJs.Compiler.Tests.TestFixtureAttribute.prototype.$ctor.$new()]);this.$type.Init("WootzJs.Compiler.Tests.Linq.Expressions.ParameterExpressionTests", WootzJs.Compiler.Tests.Linq.Expressions.ParameterExpressionTests, System.Object, [], [], [System.Reflection.MethodInfo.prototype.$ctor.$new("LambdaReturnsParameter", WootzJs.Compiler.Tests.Linq.Expressions.ParameterExpressionTests.prototype.LambdaReturnsParameter, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.Linq.Expressions.ParameterExpressionTests.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
    $t.$StaticInitializer = function() {
    };
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.LambdaReturnsParameter = function() {
        var lambda = (function() {
            var $lambdaparam$x = System.Linq.Expressions.Expression.Parameter$1(String.$GetType(), "x");
            return System.Linq.Expressions.Expression.Lambda((System.Func$2$(String, String)), $lambdaparam$x, [$lambdaparam$x]);
        }).call(this);
        var parameterExpression = $cast(System.Linq.Expressions.ParameterExpression, lambda.get_Body());
        QUnit.equal(lambda.get_Parameters().get_Item(0), parameterExpression);
        QUnit.equal(parameterExpression.get_Name(), "x");
    };
}).call(null, WootzJs.Compiler.Tests.Linq.Expressions.ParameterExpressionTests, WootzJs.Compiler.Tests.Linq.Expressions.ParameterExpressionTests.prototype);
$WootzJs$Compiler$Tests$AssemblyTypes.push(WootzJs.Compiler.Tests.Linq.Expressions.ParameterExpressionTests);
WootzJs.Compiler.Tests.Linq.Expressions.TypeBinaryExpressionTests = $define("WootzJs.Compiler.Tests.Linq.Expressions.TypeBinaryExpressionTests");
WootzJs.Compiler.Tests.Linq.Expressions.TypeBinaryExpressionTests.prototype = new System.Object();
(WootzJs.Compiler.Tests.Linq.Expressions.TypeBinaryExpressionTests.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
    $p.$type = WootzJs.Compiler.Tests.Linq.Expressions.TypeBinaryExpressionTests;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Compiler.Tests.Linq.Expressions.TypeBinaryExpressionTests";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("TypeBinaryExpressionTests", [WootzJs.Compiler.Tests.TestFixtureAttribute.prototype.$ctor.$new()]);this.$type.Init("WootzJs.Compiler.Tests.Linq.Expressions.TypeBinaryExpressionTests", WootzJs.Compiler.Tests.Linq.Expressions.TypeBinaryExpressionTests, System.Object, [], [], [System.Reflection.MethodInfo.prototype.$ctor.$new("IsOperator", WootzJs.Compiler.Tests.Linq.Expressions.TypeBinaryExpressionTests.prototype.IsOperator, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.Linq.Expressions.TypeBinaryExpressionTests.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
    $t.$StaticInitializer = function() {
    };
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.IsOperator = function() {
        var lambda = (function() {
            return System.Linq.Expressions.Expression.Lambda((System.Func$1$(System.Boolean)), System.Linq.Expressions.Expression.TypeIs(System.Linq.Expressions.Expression.Constant$1("foo", String.$GetType()), System.Int32.$GetType()), []);
        }).call(this);
        var unaryExpression = $cast(System.Linq.Expressions.TypeBinaryExpression, lambda.get_Body());
        var operand = $cast(System.Linq.Expressions.ConstantExpression, unaryExpression.get_Expression());
        QUnit.equal(unaryExpression.get_NodeType(), System.Linq.Expressions.ExpressionType().TypeIs);
        QUnit.equal(operand.get_Value(), "foo");
        QUnit.equal(unaryExpression.get_TypeOperand().get_FullName(), System.Int32.$GetType().get_FullName());
    };
}).call(null, WootzJs.Compiler.Tests.Linq.Expressions.TypeBinaryExpressionTests, WootzJs.Compiler.Tests.Linq.Expressions.TypeBinaryExpressionTests.prototype);
$WootzJs$Compiler$Tests$AssemblyTypes.push(WootzJs.Compiler.Tests.Linq.Expressions.TypeBinaryExpressionTests);
WootzJs.Compiler.Tests.Linq.Expressions.UnaryExpressionTests = $define("WootzJs.Compiler.Tests.Linq.Expressions.UnaryExpressionTests");
WootzJs.Compiler.Tests.Linq.Expressions.UnaryExpressionTests.prototype = new System.Object();
(WootzJs.Compiler.Tests.Linq.Expressions.UnaryExpressionTests.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
    $p.$type = WootzJs.Compiler.Tests.Linq.Expressions.UnaryExpressionTests;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Compiler.Tests.Linq.Expressions.UnaryExpressionTests";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("UnaryExpressionTests", [WootzJs.Compiler.Tests.TestFixtureAttribute.prototype.$ctor.$new()]);this.$type.Init("WootzJs.Compiler.Tests.Linq.Expressions.UnaryExpressionTests", WootzJs.Compiler.Tests.Linq.Expressions.UnaryExpressionTests, System.Object, [], [], [System.Reflection.MethodInfo.prototype.$ctor.$new("NotBoolean", WootzJs.Compiler.Tests.Linq.Expressions.UnaryExpressionTests.prototype.NotBoolean, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("NegateInteger", WootzJs.Compiler.Tests.Linq.Expressions.UnaryExpressionTests.prototype.NegateInteger, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("AsOperator", WootzJs.Compiler.Tests.Linq.Expressions.UnaryExpressionTests.prototype.AsOperator, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.Linq.Expressions.UnaryExpressionTests.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
    $t.$StaticInitializer = function() {
    };
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.NotBoolean = function() {
        var lambda = (function() {
            return System.Linq.Expressions.Expression.Lambda((System.Func$1$(System.Boolean)), System.Linq.Expressions.Expression.MakeUnary(System.Linq.Expressions.ExpressionType().Not, System.Linq.Expressions.Expression.Constant$1(true, System.Boolean.$GetType()), System.Boolean.$GetType()), []);
        }).call(this);
        var unaryExpression = $cast(System.Linq.Expressions.UnaryExpression, lambda.get_Body());
        var operand = $cast(System.Linq.Expressions.ConstantExpression, unaryExpression.get_Operand());
        QUnit.equal(unaryExpression.get_NodeType(), System.Linq.Expressions.ExpressionType().Not);
        QUnit.equal(unaryExpression.get_Type(), System.Boolean.$GetType());
        QUnit.equal(operand.get_Value(), true);
    };
    $p.NegateInteger = function() {
        var lambda = (function() {
            return System.Linq.Expressions.Expression.Lambda((System.Func$1$(System.Int32)), System.Linq.Expressions.Expression.MakeUnary(System.Linq.Expressions.ExpressionType().Negate, System.Linq.Expressions.Expression.Constant$1(5, System.Int32.$GetType()), System.Int32.$GetType()), []);
        }).call(this);
        var unaryExpression = $cast(System.Linq.Expressions.UnaryExpression, lambda.get_Body());
        var operand = $cast(System.Linq.Expressions.ConstantExpression, unaryExpression.get_Operand());
        QUnit.equal(unaryExpression.get_NodeType(), System.Linq.Expressions.ExpressionType().Negate);
        QUnit.equal(operand.get_Value(), 5);
    };
    $p.AsOperator = function() {
        var lambda = (function() {
            return System.Linq.Expressions.Expression.Lambda((System.Func$1$(System.Object)), System.Linq.Expressions.Expression.TypeAs(System.Linq.Expressions.Expression.Constant$1("foo", String.$GetType()), System.Object.$GetType()), []);
        }).call(this);
        var unaryExpression = $cast(System.Linq.Expressions.UnaryExpression, lambda.get_Body());
        var operand = $cast(System.Linq.Expressions.ConstantExpression, unaryExpression.get_Operand());
        QUnit.equal(unaryExpression.get_NodeType(), System.Linq.Expressions.ExpressionType().TypeAs);
        QUnit.equal(operand.get_Value(), "foo");
        QUnit.equal(unaryExpression.get_Type().get_FullName(), System.Object.$GetType().get_FullName());
    };
}).call(null, WootzJs.Compiler.Tests.Linq.Expressions.UnaryExpressionTests, WootzJs.Compiler.Tests.Linq.Expressions.UnaryExpressionTests.prototype);
$WootzJs$Compiler$Tests$AssemblyTypes.push(WootzJs.Compiler.Tests.Linq.Expressions.UnaryExpressionTests);
WootzJs.Compiler.Tests.MethodTests = $define("WootzJs.Compiler.Tests.MethodTests");
WootzJs.Compiler.Tests.MethodTests.prototype = new System.Object();
(WootzJs.Compiler.Tests.MethodTests.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
    $p.$type = WootzJs.Compiler.Tests.MethodTests;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Compiler.Tests.MethodTests";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("MethodTests", [WootzJs.Compiler.Tests.TestFixtureAttribute.prototype.$ctor.$new()]);this.$type.Init("WootzJs.Compiler.Tests.MethodTests", WootzJs.Compiler.Tests.MethodTests, System.Object, [], [], [System.Reflection.MethodInfo.prototype.$ctor.$new("StaticMethod", WootzJs.Compiler.Tests.MethodTests.prototype.StaticMethod, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("ExtensionMethod", WootzJs.Compiler.Tests.MethodTests.prototype.ExtensionMethod, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("OutParameter", WootzJs.Compiler.Tests.MethodTests.prototype.OutParameter, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("TwoOutParameters", WootzJs.Compiler.Tests.MethodTests.prototype.TwoOutParameters, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("RefParameter", WootzJs.Compiler.Tests.MethodTests.prototype.RefParameter, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("TwoRefParameters", WootzJs.Compiler.Tests.MethodTests.prototype.TwoRefParameters, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("RefAndOutParameter", WootzJs.Compiler.Tests.MethodTests.prototype.RefAndOutParameter, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("InterfaceMethod", WootzJs.Compiler.Tests.MethodTests.prototype.InterfaceMethod, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("CollisionImplementationBothExplicit", WootzJs.Compiler.Tests.MethodTests.prototype.CollisionImplementationBothExplicit, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("CollisionImplementationOneExplicit", WootzJs.Compiler.Tests.MethodTests.prototype.CollisionImplementationOneExplicit, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.MethodTests.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
    $t.$StaticInitializer = function() {
    };
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.StaticMethod = function() {
        var s = WootzJs.Compiler.Tests.ClassWithStaticMethods.S();
        QUnit.equal(s, "foo");
    };
    $p.ExtensionMethod = function() {
        var s = WootzJs.Compiler.Tests.ClassWithStaticMethods.MyExtension(5);
        QUnit.equal(s, "5");
    };
    $p.OutParameter = function() {
        var x;
        (function() {
            var $anon$1 = {
                value: null
            };
            var $result$ = WootzJs.Compiler.Tests.ClassWithStaticMethods.OutParameter($anon$1);
            x = $anon$1.value;
            return $result$;
        }).call(this);
        QUnit.equal(x, "foo");
    };
    $p.TwoOutParameters = function() {
        var x;
        var y;
        (function() {
            var $anon$1 = {
                value: null
            };
            var $anon$2 = {
                value: null
            };
            var $result$ = WootzJs.Compiler.Tests.ClassWithStaticMethods.TwoOutParameters($anon$1, $anon$2);
            x = $anon$1.value;
            y = $anon$2.value;
            return $result$;
        }).call(this);
        QUnit.equal(x, "foo1");
        QUnit.equal(y, "foo2");
    };
    $p.RefParameter = function() {
        var x = 5;
        (function() {
            var $anon$1 = {
                value: x
            };
            var $result$ = WootzJs.Compiler.Tests.ClassWithStaticMethods.RefParameter($anon$1);
            x = $anon$1.value;
            return $result$;
        }).call(this);
        QUnit.equal(x, 6);
    };
    $p.TwoRefParameters = function() {
        var x = 5;
        var y = 6;
        (function() {
            var $anon$1 = {
                value: x
            };
            var $anon$2 = {
                value: y
            };
            var $result$ = WootzJs.Compiler.Tests.ClassWithStaticMethods.TwoRefParameters($anon$1, $anon$2);
            x = $anon$1.value;
            y = $anon$2.value;
            return $result$;
        }).call(this);
        QUnit.equal(x, 6);
        QUnit.equal(y, 12);
    };
    $p.RefAndOutParameter = function() {
        var x = 5;
        var y;
        (function() {
            var $anon$1 = {
                value: x
            };
            var $anon$2 = {
                value: null
            };
            var $result$ = WootzJs.Compiler.Tests.ClassWithStaticMethods.RefAndOutParameter($anon$1, $anon$2);
            x = $anon$1.value;
            y = $anon$2.value;
            return $result$;
        }).call(this);
        QUnit.equal(x, 6);
        QUnit.equal(y, 10);
    };
    $p.InterfaceMethod = function() {
        var test = WootzJs.Compiler.Tests.TestImplementation.prototype.$ctor.$new();
        var s = test.WootzJs$Compiler$Tests$ITestInterface$Method();
        QUnit.equal(s, "foo");
    };
    $p.CollisionImplementationBothExplicit = function() {
        var o = WootzJs.Compiler.Tests.CollisionImplementationBothExplicit.prototype.$ctor.$new();
        var test = o;
        var test2 = o;
        var s = test.WootzJs$Compiler$Tests$ITestInterface$Method();
        var s2 = test2.WootzJs$Compiler$Tests$ITestInterface2$Method();
        QUnit.equal(s, "ITestInterface");
        QUnit.equal(s2, "ITestInterface2");
    };
    $p.CollisionImplementationOneExplicit = function() {
        var o = WootzJs.Compiler.Tests.CollisionImplementationOneExplicit.prototype.$ctor.$new();
        var test = o;
        var test2 = o;
        var s = test.WootzJs$Compiler$Tests$ITestInterface$Method();
        var s2 = test2.WootzJs$Compiler$Tests$ITestInterface2$Method();
        QUnit.equal(s, "ITestInterface");
        QUnit.equal(s2, "ITestInterface2");
    };
}).call(null, WootzJs.Compiler.Tests.MethodTests, WootzJs.Compiler.Tests.MethodTests.prototype);
$WootzJs$Compiler$Tests$AssemblyTypes.push(WootzJs.Compiler.Tests.MethodTests);
WootzJs.Compiler.Tests.ClassWithStaticMethods = $define("WootzJs.Compiler.Tests.ClassWithStaticMethods");
WootzJs.Compiler.Tests.ClassWithStaticMethods.prototype = new System.Object();
(WootzJs.Compiler.Tests.ClassWithStaticMethods.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
    $p.$type = WootzJs.Compiler.Tests.ClassWithStaticMethods;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Compiler.Tests.ClassWithStaticMethods";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("ClassWithStaticMethods", []);this.$type.Init("WootzJs.Compiler.Tests.ClassWithStaticMethods", WootzJs.Compiler.Tests.ClassWithStaticMethods, System.Object, [], [], [System.Reflection.MethodInfo.prototype.$ctor.$new("S", WootzJs.Compiler.Tests.ClassWithStaticMethods.prototype.S, [], String, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, []), System.Reflection.MethodInfo.prototype.$ctor.$new("MyExtension", WootzJs.Compiler.Tests.ClassWithStaticMethods.prototype.MyExtension, [System.Reflection.ParameterInfo.prototype.$ctor.$new("i", System.Int32, 0, 0, null, [])], String, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, []), System.Reflection.MethodInfo.prototype.$ctor.$new("OutParameter", WootzJs.Compiler.Tests.ClassWithStaticMethods.prototype.OutParameter, [System.Reflection.ParameterInfo.prototype.$ctor.$new("s", String, 0, System.Reflection.ParameterAttributes().Out, null, [])], System.Void, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, []), System.Reflection.MethodInfo.prototype.$ctor.$new("TwoOutParameters", WootzJs.Compiler.Tests.ClassWithStaticMethods.prototype.TwoOutParameters, [System.Reflection.ParameterInfo.prototype.$ctor.$new("s1", String, 0, System.Reflection.ParameterAttributes().Out, null, []), System.Reflection.ParameterInfo.prototype.$ctor.$new("s2", String, 1, System.Reflection.ParameterAttributes().Out, null, [])], System.Void, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, []), System.Reflection.MethodInfo.prototype.$ctor.$new("RefParameter", WootzJs.Compiler.Tests.ClassWithStaticMethods.prototype.RefParameter, [System.Reflection.ParameterInfo.prototype.$ctor.$new("i", System.Int32, 0, 0, null, [])], System.Void, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, []), System.Reflection.MethodInfo.prototype.$ctor.$new("TwoRefParameters", WootzJs.Compiler.Tests.ClassWithStaticMethods.prototype.TwoRefParameters, [System.Reflection.ParameterInfo.prototype.$ctor.$new("i", System.Int32, 0, 0, null, []), System.Reflection.ParameterInfo.prototype.$ctor.$new("j", System.Int32, 1, 0, null, [])], System.Void, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, []), System.Reflection.MethodInfo.prototype.$ctor.$new("RefAndOutParameter", WootzJs.Compiler.Tests.ClassWithStaticMethods.prototype.RefAndOutParameter, [System.Reflection.ParameterInfo.prototype.$ctor.$new("i", System.Int32, 0, 0, null, []), System.Reflection.ParameterInfo.prototype.$ctor.$new("j", System.Int32, 1, System.Reflection.ParameterAttributes().Out, null, [])], System.Void, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, [])], [], [], [], false);return this.$type;};
    $t.$StaticInitializer = function() {
    };
    $t.S = function() {
        return "foo";
    };
    $t.MyExtension = function(i) {
        return i.ToString();
    };
    $t.OutParameter = function(s) {
        s.value = "foo";
    };
    $t.TwoOutParameters = function(s1, s2) {
        s1.value = "foo1";
        s2.value = "foo2";
    };
    $t.RefParameter = function(i) {
        i.value = i.value + 1;
    };
    $t.TwoRefParameters = function(i, j) {
        i.value = i.value + 1;
        j.value = j.value * 2;
    };
    $t.RefAndOutParameter = function(i, j) {
        i.value = i.value + 1;
        j.value = 10;
    };
}).call(null, WootzJs.Compiler.Tests.ClassWithStaticMethods, WootzJs.Compiler.Tests.ClassWithStaticMethods.prototype);
$WootzJs$Compiler$Tests$AssemblyTypes.push(WootzJs.Compiler.Tests.ClassWithStaticMethods);
WootzJs.Compiler.Tests.ITestInterface = $define("WootzJs.Compiler.Tests.ITestInterface");
WootzJs.Compiler.Tests.ITestInterface.prototype = new System.Object();
(WootzJs.Compiler.Tests.ITestInterface.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
    $p.$type = WootzJs.Compiler.Tests.ITestInterface;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Compiler.Tests.ITestInterface";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("ITestInterface", []);this.$type.Init("WootzJs.Compiler.Tests.ITestInterface", WootzJs.Compiler.Tests.ITestInterface, null, [], [], [System.Reflection.MethodInfo.prototype.$ctor.$new("WootzJs$Compiler$Tests$ITestInterface$Method", WootzJs.Compiler.Tests.ITestInterface.prototype.WootzJs$Compiler$Tests$ITestInterface$Method, [], String, System.Reflection.MethodAttributes().Public, [])], [], [], [], false);return this.$type;};
    $t.$StaticInitializer = function() {
    };
    $p.WootzJs$Compiler$Tests$ITestInterface$Method = function() {
    };
}).call(null, WootzJs.Compiler.Tests.ITestInterface, WootzJs.Compiler.Tests.ITestInterface.prototype);
$WootzJs$Compiler$Tests$AssemblyTypes.push(WootzJs.Compiler.Tests.ITestInterface);
WootzJs.Compiler.Tests.TestImplementation = $define("WootzJs.Compiler.Tests.TestImplementation");
WootzJs.Compiler.Tests.TestImplementation.prototype = new System.Object();
(WootzJs.Compiler.Tests.TestImplementation.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
    $p.$type = WootzJs.Compiler.Tests.TestImplementation;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Compiler.Tests.TestImplementation";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("TestImplementation", []);this.$type.Init("WootzJs.Compiler.Tests.TestImplementation", WootzJs.Compiler.Tests.TestImplementation, System.Object, [WootzJs.Compiler.Tests.ITestInterface], [], [System.Reflection.MethodInfo.prototype.$ctor.$new("Method", WootzJs.Compiler.Tests.TestImplementation.prototype.Method, [], String, System.Reflection.MethodAttributes().Public, [])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.TestImplementation.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
    $t.$StaticInitializer = function() {
    };
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.Method = function() {
        return "foo";
    };
    $p.WootzJs$Compiler$Tests$ITestInterface$Method = $p.Method;
}).call(null, WootzJs.Compiler.Tests.TestImplementation, WootzJs.Compiler.Tests.TestImplementation.prototype);
$WootzJs$Compiler$Tests$AssemblyTypes.push(WootzJs.Compiler.Tests.TestImplementation);
WootzJs.Compiler.Tests.ITestInterface2 = $define("WootzJs.Compiler.Tests.ITestInterface2");
WootzJs.Compiler.Tests.ITestInterface2.prototype = new System.Object();
(WootzJs.Compiler.Tests.ITestInterface2.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
    $p.$type = WootzJs.Compiler.Tests.ITestInterface2;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Compiler.Tests.ITestInterface2";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("ITestInterface2", []);this.$type.Init("WootzJs.Compiler.Tests.ITestInterface2", WootzJs.Compiler.Tests.ITestInterface2, null, [], [], [System.Reflection.MethodInfo.prototype.$ctor.$new("WootzJs$Compiler$Tests$ITestInterface2$Method", WootzJs.Compiler.Tests.ITestInterface2.prototype.WootzJs$Compiler$Tests$ITestInterface2$Method, [], String, System.Reflection.MethodAttributes().Public, [])], [], [], [], false);return this.$type;};
    $t.$StaticInitializer = function() {
    };
    $p.WootzJs$Compiler$Tests$ITestInterface2$Method = function() {
    };
}).call(null, WootzJs.Compiler.Tests.ITestInterface2, WootzJs.Compiler.Tests.ITestInterface2.prototype);
$WootzJs$Compiler$Tests$AssemblyTypes.push(WootzJs.Compiler.Tests.ITestInterface2);
WootzJs.Compiler.Tests.CollisionImplementationBothExplicit = $define("WootzJs.Compiler.Tests.CollisionImplementationBothExplicit");
WootzJs.Compiler.Tests.CollisionImplementationBothExplicit.prototype = new System.Object();
(WootzJs.Compiler.Tests.CollisionImplementationBothExplicit.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
    $p.$type = WootzJs.Compiler.Tests.CollisionImplementationBothExplicit;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Compiler.Tests.CollisionImplementationBothExplicit";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("CollisionImplementationBothExplicit", []);this.$type.Init("WootzJs.Compiler.Tests.CollisionImplementationBothExplicit", WootzJs.Compiler.Tests.CollisionImplementationBothExplicit, System.Object, [WootzJs.Compiler.Tests.ITestInterface2, WootzJs.Compiler.Tests.ITestInterface], [], [System.Reflection.MethodInfo.prototype.$ctor.$new("WootzJs$Compiler$Tests$ITestInterface$Method", WootzJs.Compiler.Tests.CollisionImplementationBothExplicit.prototype.WootzJs$Compiler$Tests$ITestInterface$Method, [], String, System.Reflection.MethodAttributes().Private, []), System.Reflection.MethodInfo.prototype.$ctor.$new("WootzJs$Compiler$Tests$ITestInterface2$Method", WootzJs.Compiler.Tests.CollisionImplementationBothExplicit.prototype.WootzJs$Compiler$Tests$ITestInterface2$Method, [], String, System.Reflection.MethodAttributes().Private, [])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.CollisionImplementationBothExplicit.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
    $t.$StaticInitializer = function() {
    };
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.WootzJs$Compiler$Tests$ITestInterface$Method = function() {
        return "ITestInterface";
    };
    $p.WootzJs$Compiler$Tests$ITestInterface$Method = $p.WootzJs$Compiler$Tests$ITestInterface$Method;
    $p.WootzJs$Compiler$Tests$ITestInterface2$Method = function() {
        return "ITestInterface2";
    };
    $p.WootzJs$Compiler$Tests$ITestInterface2$Method = $p.WootzJs$Compiler$Tests$ITestInterface2$Method;
}).call(null, WootzJs.Compiler.Tests.CollisionImplementationBothExplicit, WootzJs.Compiler.Tests.CollisionImplementationBothExplicit.prototype);
$WootzJs$Compiler$Tests$AssemblyTypes.push(WootzJs.Compiler.Tests.CollisionImplementationBothExplicit);
WootzJs.Compiler.Tests.CollisionImplementationOneExplicit = $define("WootzJs.Compiler.Tests.CollisionImplementationOneExplicit");
WootzJs.Compiler.Tests.CollisionImplementationOneExplicit.prototype = new System.Object();
(WootzJs.Compiler.Tests.CollisionImplementationOneExplicit.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
    $p.$type = WootzJs.Compiler.Tests.CollisionImplementationOneExplicit;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Compiler.Tests.CollisionImplementationOneExplicit";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("CollisionImplementationOneExplicit", []);this.$type.Init("WootzJs.Compiler.Tests.CollisionImplementationOneExplicit", WootzJs.Compiler.Tests.CollisionImplementationOneExplicit, System.Object, [WootzJs.Compiler.Tests.ITestInterface2, WootzJs.Compiler.Tests.ITestInterface], [], [System.Reflection.MethodInfo.prototype.$ctor.$new("Method", WootzJs.Compiler.Tests.CollisionImplementationOneExplicit.prototype.Method, [], String, System.Reflection.MethodAttributes().Public, []), System.Reflection.MethodInfo.prototype.$ctor.$new("WootzJs$Compiler$Tests$ITestInterface2$Method", WootzJs.Compiler.Tests.CollisionImplementationOneExplicit.prototype.WootzJs$Compiler$Tests$ITestInterface2$Method, [], String, System.Reflection.MethodAttributes().Private, [])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.CollisionImplementationOneExplicit.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
    $t.$StaticInitializer = function() {
    };
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.Method = function() {
        return "ITestInterface";
    };
    $p.WootzJs$Compiler$Tests$ITestInterface$Method = $p.Method;
    $p.WootzJs$Compiler$Tests$ITestInterface2$Method = function() {
        return "ITestInterface2";
    };
    $p.WootzJs$Compiler$Tests$ITestInterface2$Method = $p.WootzJs$Compiler$Tests$ITestInterface2$Method;
}).call(null, WootzJs.Compiler.Tests.CollisionImplementationOneExplicit, WootzJs.Compiler.Tests.CollisionImplementationOneExplicit.prototype);
$WootzJs$Compiler$Tests$AssemblyTypes.push(WootzJs.Compiler.Tests.CollisionImplementationOneExplicit);
WootzJs.Compiler.Tests.NullableTests = $define("WootzJs.Compiler.Tests.NullableTests");
WootzJs.Compiler.Tests.NullableTests.prototype = new System.Object();
(WootzJs.Compiler.Tests.NullableTests.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
    $p.$type = WootzJs.Compiler.Tests.NullableTests;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Compiler.Tests.NullableTests";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("NullableTests", [WootzJs.Compiler.Tests.TestFixtureAttribute.prototype.$ctor.$new()]);this.$type.Init("WootzJs.Compiler.Tests.NullableTests", WootzJs.Compiler.Tests.NullableTests, System.Object, [], [], [System.Reflection.MethodInfo.prototype.$ctor.$new("HasValue", WootzJs.Compiler.Tests.NullableTests.prototype.HasValue, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("Value", WootzJs.Compiler.Tests.NullableTests.prototype.Value, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("GetValueOrDefault", WootzJs.Compiler.Tests.NullableTests.prototype.GetValueOrDefault, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.NullableTests.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
    $t.$StaticInitializer = function() {
    };
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.HasValue = function() {
        var i = 5;
        QUnit.ok((i != null));
    };
    $p.Value = function() {
        var i = 5;
        QUnit.equal(i, 5);
    };
    $p.GetValueOrDefault = function() {
        var i = 5;
        var j = null;
        QUnit.equal(i, 5);
        QUnit.equal(j, null);
    };
}).call(null, WootzJs.Compiler.Tests.NullableTests, WootzJs.Compiler.Tests.NullableTests.prototype);
$WootzJs$Compiler$Tests$AssemblyTypes.push(WootzJs.Compiler.Tests.NullableTests);
WootzJs.Compiler.Tests.NumberTests = $define("WootzJs.Compiler.Tests.NumberTests");
WootzJs.Compiler.Tests.NumberTests.prototype = new System.Object();
(WootzJs.Compiler.Tests.NumberTests.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
    $p.$type = WootzJs.Compiler.Tests.NumberTests;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Compiler.Tests.NumberTests";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("NumberTests", [WootzJs.Compiler.Tests.TestFixtureAttribute.prototype.$ctor.$new()]);this.$type.Init("WootzJs.Compiler.Tests.NumberTests", WootzJs.Compiler.Tests.NumberTests, System.Object, [], [], [System.Reflection.MethodInfo.prototype.$ctor.$new("ToHex", WootzJs.Compiler.Tests.NumberTests.prototype.ToHex, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.NumberTests.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
    $t.$StaticInitializer = function() {
    };
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.ToHex = function() {
        var number = 20;
        QUnit.equal(number.ToString$2("X4"), "0014");
    };
}).call(null, WootzJs.Compiler.Tests.NumberTests, WootzJs.Compiler.Tests.NumberTests.prototype);
$WootzJs$Compiler$Tests$AssemblyTypes.push(WootzJs.Compiler.Tests.NumberTests);
WootzJs.Compiler.Tests.ObjectInitializerTests = $define("WootzJs.Compiler.Tests.ObjectInitializerTests");
WootzJs.Compiler.Tests.ObjectInitializerTests.prototype = new System.Object();
(WootzJs.Compiler.Tests.ObjectInitializerTests.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
    $p.$type = WootzJs.Compiler.Tests.ObjectInitializerTests;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Compiler.Tests.ObjectInitializerTests";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("ObjectInitializerTests", [WootzJs.Compiler.Tests.TestFixtureAttribute.prototype.$ctor.$new()]);this.$type.Init("WootzJs.Compiler.Tests.ObjectInitializerTests", WootzJs.Compiler.Tests.ObjectInitializerTests, System.Object, [], [], [System.Reflection.MethodInfo.prototype.$ctor.$new("OneProperty", WootzJs.Compiler.Tests.ObjectInitializerTests.prototype.OneProperty, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("OneField", WootzJs.Compiler.Tests.ObjectInitializerTests.prototype.OneField, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("Nested", WootzJs.Compiler.Tests.ObjectInitializerTests.prototype.Nested, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.ObjectInitializerTests.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
    $t.$StaticInitializer = function() {
    };
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.OneProperty = function() {
        var o = (function() {
            var $obj$ = WootzJs.Compiler.Tests.ObjectInitializerTests.OnePropertyClass.prototype.$ctor.$new();
            $obj$.set_MyProperty("foo");
            return $obj$;
        }).call(this);
        QUnit.equal(o.get_MyProperty(), "foo");
    };
    $p.OneField = function() {
        var o = (function() {
            var $obj$ = WootzJs.Compiler.Tests.ObjectInitializerTests.OnePropertyClass.prototype.$ctor.$new();
            $obj$.MyField = "foo";
            return $obj$;
        }).call(this);
        QUnit.equal(o.MyField, "foo");
    };
    $p.Nested = function() {
        var o = (function() {
            var $obj$ = WootzJs.Compiler.Tests.ObjectInitializerTests.OnePropertyClass.prototype.$ctor.$new();
            $obj$.set_NestedProperty((function() {
                var $obj$ = WootzJs.Compiler.Tests.ObjectInitializerTests.OnePropertyClass.prototype.$ctor.$new();
                $obj$.set_MyProperty("foo");
                return $obj$;
            }).call(this));
            return $obj$;
        }).call(this);
        QUnit.equal(o.get_NestedProperty().get_MyProperty(), "foo");
    };
    function OnePropertyClass($constructor) {
        if (!$t.OnePropertyClass.$isStaticInitialized && ($constructor != null || !(this instanceof WootzJs.Compiler.Tests.ObjectInitializerTests.OnePropertyClass))) {
            $t.OnePropertyClass.$isStaticInitialized = true;
            $t.OnePropertyClass.$StaticInitializer();
        }
        if ($constructor != null)
            $constructor.apply(this, Array.prototype.slice.call(arguments, 1));
        if (!(this instanceof WootzJs.Compiler.Tests.ObjectInitializerTests.OnePropertyClass))
            return $t.OnePropertyClass;
    }
    $t.OnePropertyClass = OnePropertyClass;
    $t.OnePropertyClass.prototype = new System.Object();
    ($t.OnePropertyClass.$TypeInitializer = function($t, $p) {
        $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
        $p.$type = WootzJs.Compiler.Tests.ObjectInitializerTests.OnePropertyClass;
        $t.$baseType = System.Object;
        $p.$typeName = "WootzJs.Compiler.Tests.ObjectInitializerTests.OnePropertyClass";
        $t.$typeName = $p.$typeName;
        $t.$GetType = function() {
            return System.Type._GetTypeFromTypeFunc(this);
        };
        $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("OnePropertyClass", []);this.$type.Init("WootzJs.Compiler.Tests.ObjectInitializerTests.OnePropertyClass", WootzJs.Compiler.Tests.ObjectInitializerTests.OnePropertyClass, System.Object, [], [System.Reflection.FieldInfo.prototype.$ctor.$new("$MyProperty$k__BackingField", String, System.Reflection.FieldAttributes().Private, null, []), System.Reflection.FieldInfo.prototype.$ctor.$new("MyField", String, System.Reflection.FieldAttributes().Public, null, []), System.Reflection.FieldInfo.prototype.$ctor.$new("$NestedProperty$k__BackingField", WootzJs.Compiler.Tests.ObjectInitializerTests.OnePropertyClass, System.Reflection.FieldAttributes().Private, null, [])], [System.Reflection.MethodInfo.prototype.$ctor.$new("get_MyProperty", WootzJs.Compiler.Tests.ObjectInitializerTests.OnePropertyClass.prototype.get_MyProperty, [], String, System.Reflection.MethodAttributes().Public, []), System.Reflection.MethodInfo.prototype.$ctor.$new("set_MyProperty", WootzJs.Compiler.Tests.ObjectInitializerTests.OnePropertyClass.prototype.set_MyProperty, [System.Reflection.ParameterInfo.prototype.$ctor.$new("value", String, 0, 0, null, [])], System.Void, System.Reflection.MethodAttributes().Public, []), System.Reflection.MethodInfo.prototype.$ctor.$new("get_NestedProperty", WootzJs.Compiler.Tests.ObjectInitializerTests.OnePropertyClass.prototype.get_NestedProperty, [], WootzJs.Compiler.Tests.ObjectInitializerTests.OnePropertyClass, System.Reflection.MethodAttributes().Public, []), System.Reflection.MethodInfo.prototype.$ctor.$new("set_NestedProperty", WootzJs.Compiler.Tests.ObjectInitializerTests.OnePropertyClass.prototype.set_NestedProperty, [System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Compiler.Tests.ObjectInitializerTests.OnePropertyClass, 0, 0, null, [])], System.Void, System.Reflection.MethodAttributes().Public, [])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.ObjectInitializerTests.OnePropertyClass.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, [])], [System.Reflection.PropertyInfo.prototype.$ctor.$new("MyProperty", String, System.Reflection.MethodInfo.prototype.$ctor.$new("get_MyProperty", WootzJs.Compiler.Tests.ObjectInitializerTests.OnePropertyClass.prototype.get_MyProperty, [], String, System.Reflection.MethodAttributes().Public, []), System.Reflection.MethodInfo.prototype.$ctor.$new("set_MyProperty", WootzJs.Compiler.Tests.ObjectInitializerTests.OnePropertyClass.prototype.set_MyProperty, [System.Reflection.ParameterInfo.prototype.$ctor.$new("value", String, 0, 0, null, [])], System.Void, System.Reflection.MethodAttributes().Public, []), [], []), System.Reflection.PropertyInfo.prototype.$ctor.$new("NestedProperty", WootzJs.Compiler.Tests.ObjectInitializerTests.OnePropertyClass, System.Reflection.MethodInfo.prototype.$ctor.$new("get_NestedProperty", WootzJs.Compiler.Tests.ObjectInitializerTests.OnePropertyClass.prototype.get_NestedProperty, [], WootzJs.Compiler.Tests.ObjectInitializerTests.OnePropertyClass, System.Reflection.MethodAttributes().Public, []), System.Reflection.MethodInfo.prototype.$ctor.$new("set_NestedProperty", WootzJs.Compiler.Tests.ObjectInitializerTests.OnePropertyClass.prototype.set_NestedProperty, [System.Reflection.ParameterInfo.prototype.$ctor.$new("value", WootzJs.Compiler.Tests.ObjectInitializerTests.OnePropertyClass, 0, 0, null, [])], System.Void, System.Reflection.MethodAttributes().Public, []), [], [])], [], false);return this.$type;};
        $t.$StaticInitializer = function() {
        };
        $p.$ctor = function() {
            System.Object.prototype.$ctor.call(this);
        };
        $p.$ctor.$type = $t;
        $p.$ctor.$new = function() {
            return new $p.$ctor.$type(this);
        };
        $p.$MyProperty$k__BackingField = null;
        $p.get_MyProperty = function() {
            return this.$MyProperty$k__BackingField;
        };
        $p.set_MyProperty = function(value) {
            this.$MyProperty$k__BackingField = value;
        };
        $p.MyField = null;
        $p.$NestedProperty$k__BackingField = null;
        $p.get_NestedProperty = function() {
            return this.$NestedProperty$k__BackingField;
        };
        $p.set_NestedProperty = function(value) {
            this.$NestedProperty$k__BackingField = value;
        };
    }).call($t, $t.OnePropertyClass, $t.OnePropertyClass.prototype);
    $WootzJs$Compiler$Tests$AssemblyTypes.push($t.OnePropertyClass);
}).call(null, WootzJs.Compiler.Tests.ObjectInitializerTests, WootzJs.Compiler.Tests.ObjectInitializerTests.prototype);
$WootzJs$Compiler$Tests$AssemblyTypes.push(WootzJs.Compiler.Tests.ObjectInitializerTests);
WootzJs.Compiler.Tests.OperatorOverloadTests = $define("WootzJs.Compiler.Tests.OperatorOverloadTests");
WootzJs.Compiler.Tests.OperatorOverloadTests.prototype = new System.Object();
(WootzJs.Compiler.Tests.OperatorOverloadTests.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
    $p.$type = WootzJs.Compiler.Tests.OperatorOverloadTests;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Compiler.Tests.OperatorOverloadTests";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("OperatorOverloadTests", [WootzJs.Compiler.Tests.TestFixtureAttribute.prototype.$ctor.$new()]);this.$type.Init("WootzJs.Compiler.Tests.OperatorOverloadTests", WootzJs.Compiler.Tests.OperatorOverloadTests, System.Object, [], [], [System.Reflection.MethodInfo.prototype.$ctor.$new("Add", WootzJs.Compiler.Tests.OperatorOverloadTests.prototype.Add, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.OperatorOverloadTests.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
    $t.$StaticInitializer = function() {
    };
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.Add = function() {
        var three = WootzJs.Compiler.Tests.OperatorOverloadTests.IntValue.prototype.$ctor.$new(3);
        var five = WootzJs.Compiler.Tests.OperatorOverloadTests.IntValue.prototype.$ctor.$new(5);
        var threePlusFive = WootzJs.Compiler.Tests.OperatorOverloadTests.IntValue.op_Addition(three, five);
        QUnit.equal(threePlusFive.get_Value(), 8);
    };
    function IntValue($constructor) {
        if (!$t.IntValue.$isStaticInitialized && ($constructor != null || !(this instanceof WootzJs.Compiler.Tests.OperatorOverloadTests.IntValue))) {
            $t.IntValue.$isStaticInitialized = true;
            $t.IntValue.$StaticInitializer();
        }
        if ($constructor != null)
            $constructor.apply(this, Array.prototype.slice.call(arguments, 1));
        if (!(this instanceof WootzJs.Compiler.Tests.OperatorOverloadTests.IntValue))
            return $t.IntValue;
    }
    $t.IntValue = IntValue;
    $t.IntValue.prototype = new System.Object();
    ($t.IntValue.$TypeInitializer = function($t, $p) {
        $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
        $p.$type = WootzJs.Compiler.Tests.OperatorOverloadTests.IntValue;
        $t.$baseType = System.Object;
        $p.$typeName = "WootzJs.Compiler.Tests.OperatorOverloadTests.IntValue";
        $t.$typeName = $p.$typeName;
        $t.$GetType = function() {
            return System.Type._GetTypeFromTypeFunc(this);
        };
        $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("IntValue", []);this.$type.Init("WootzJs.Compiler.Tests.OperatorOverloadTests.IntValue", WootzJs.Compiler.Tests.OperatorOverloadTests.IntValue, System.Object, [], [System.Reflection.FieldInfo.prototype.$ctor.$new("$Value$k__BackingField", System.Int32, System.Reflection.FieldAttributes().Private, null, [])], [System.Reflection.MethodInfo.prototype.$ctor.$new("get_Value", WootzJs.Compiler.Tests.OperatorOverloadTests.IntValue.prototype.get_Value, [], System.Int32, System.Reflection.MethodAttributes().Public, []), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Value", WootzJs.Compiler.Tests.OperatorOverloadTests.IntValue.prototype.set_Value, [System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Int32, 0, 0, null, [])], System.Void, System.Reflection.MethodAttributes().Private, []), System.Reflection.MethodInfo.prototype.$ctor.$new("op_Addition", WootzJs.Compiler.Tests.OperatorOverloadTests.IntValue.prototype.op_Addition, [System.Reflection.ParameterInfo.prototype.$ctor.$new("left", WootzJs.Compiler.Tests.OperatorOverloadTests.IntValue, 0, 0, null, []), System.Reflection.ParameterInfo.prototype.$ctor.$new("right", WootzJs.Compiler.Tests.OperatorOverloadTests.IntValue, 1, 0, null, [])], WootzJs.Compiler.Tests.OperatorOverloadTests.IntValue, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, [])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.OperatorOverloadTests.IntValue.prototype.$ctor, [System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Int32, 0, 0, null, [])], System.Reflection.MethodAttributes().Public, [])], [System.Reflection.PropertyInfo.prototype.$ctor.$new("Value", System.Int32, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Value", WootzJs.Compiler.Tests.OperatorOverloadTests.IntValue.prototype.get_Value, [], System.Int32, System.Reflection.MethodAttributes().Public, []), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Value", WootzJs.Compiler.Tests.OperatorOverloadTests.IntValue.prototype.set_Value, [System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Int32, 0, 0, null, [])], System.Void, System.Reflection.MethodAttributes().Private, []), [], [])], [], false);return this.$type;};
        $t.$StaticInitializer = function() {
        };
        $p.$Value$k__BackingField = null;
        $p.get_Value = function() {
            return this.$Value$k__BackingField;
        };
        $p.set_Value = function(value) {
            this.$Value$k__BackingField = value;
        };
        $p.$ctor = function(value) {
            System.Object.prototype.$ctor.call(this);
            this.set_Value(value);
        };
        $p.$ctor.$type = $t;
        $p.$ctor.$new = function(value) {
            return new $p.$ctor.$type(this, value);
        };
        $t.op_Addition = function(left, right) {
            return WootzJs.Compiler.Tests.OperatorOverloadTests.IntValue.prototype.$ctor.$new(left.get_Value() + right.get_Value());
        };
    }).call($t, $t.IntValue, $t.IntValue.prototype);
    $WootzJs$Compiler$Tests$AssemblyTypes.push($t.IntValue);
}).call(null, WootzJs.Compiler.Tests.OperatorOverloadTests, WootzJs.Compiler.Tests.OperatorOverloadTests.prototype);
$WootzJs$Compiler$Tests$AssemblyTypes.push(WootzJs.Compiler.Tests.OperatorOverloadTests);
WootzJs.Compiler.Tests.PropertyTests = $define("WootzJs.Compiler.Tests.PropertyTests");
WootzJs.Compiler.Tests.PropertyTests.prototype = new System.Object();
(WootzJs.Compiler.Tests.PropertyTests.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
    $p.$type = WootzJs.Compiler.Tests.PropertyTests;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Compiler.Tests.PropertyTests";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("PropertyTests", [WootzJs.Compiler.Tests.TestFixtureAttribute.prototype.$ctor.$new()]);this.$type.Init("WootzJs.Compiler.Tests.PropertyTests", WootzJs.Compiler.Tests.PropertyTests, System.Object, [], [], [System.Reflection.MethodInfo.prototype.$ctor.$new("StaticProperty", WootzJs.Compiler.Tests.PropertyTests.prototype.StaticProperty, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.PropertyTests.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
    $t.$StaticInitializer = function() {
    };
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.StaticProperty = function() {
        WootzJs.Compiler.Tests.PropertyTests.StaticPropertyClass().set_StringProperty("foo");
        QUnit.equal(WootzJs.Compiler.Tests.PropertyTests.StaticPropertyClass().get_StringProperty(), "foo");
    };
    function StaticPropertyClass($constructor) {
        if (!$t.StaticPropertyClass.$isStaticInitialized && ($constructor != null || !(this instanceof WootzJs.Compiler.Tests.PropertyTests.StaticPropertyClass))) {
            $t.StaticPropertyClass.$isStaticInitialized = true;
            $t.StaticPropertyClass.$StaticInitializer();
        }
        if ($constructor != null)
            $constructor.apply(this, Array.prototype.slice.call(arguments, 1));
        if (!(this instanceof WootzJs.Compiler.Tests.PropertyTests.StaticPropertyClass))
            return $t.StaticPropertyClass;
    }
    $t.StaticPropertyClass = StaticPropertyClass;
    $t.StaticPropertyClass.prototype = new System.Object();
    ($t.StaticPropertyClass.$TypeInitializer = function($t, $p) {
        $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
        $p.$type = WootzJs.Compiler.Tests.PropertyTests.StaticPropertyClass;
        $t.$baseType = System.Object;
        $p.$typeName = "WootzJs.Compiler.Tests.PropertyTests.StaticPropertyClass";
        $t.$typeName = $p.$typeName;
        $t.$GetType = function() {
            return System.Type._GetTypeFromTypeFunc(this);
        };
        $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("StaticPropertyClass", []);this.$type.Init("WootzJs.Compiler.Tests.PropertyTests.StaticPropertyClass", WootzJs.Compiler.Tests.PropertyTests.StaticPropertyClass, System.Object, [], [System.Reflection.FieldInfo.prototype.$ctor.$new("$StringProperty$k__BackingField", String, System.Reflection.FieldAttributes().Private | System.Reflection.FieldAttributes().Static, null, [])], [System.Reflection.MethodInfo.prototype.$ctor.$new("get_StringProperty", WootzJs.Compiler.Tests.PropertyTests.StaticPropertyClass.prototype.get_StringProperty, [], String, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, []), System.Reflection.MethodInfo.prototype.$ctor.$new("set_StringProperty", WootzJs.Compiler.Tests.PropertyTests.StaticPropertyClass.prototype.set_StringProperty, [System.Reflection.ParameterInfo.prototype.$ctor.$new("value", String, 0, 0, null, [])], System.Void, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, [])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.PropertyTests.StaticPropertyClass.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, [])], [System.Reflection.PropertyInfo.prototype.$ctor.$new("StringProperty", String, System.Reflection.MethodInfo.prototype.$ctor.$new("get_StringProperty", WootzJs.Compiler.Tests.PropertyTests.StaticPropertyClass.prototype.get_StringProperty, [], String, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, []), System.Reflection.MethodInfo.prototype.$ctor.$new("set_StringProperty", WootzJs.Compiler.Tests.PropertyTests.StaticPropertyClass.prototype.set_StringProperty, [System.Reflection.ParameterInfo.prototype.$ctor.$new("value", String, 0, 0, null, [])], System.Void, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, []), [], [])], [], false);return this.$type;};
        $t.$StaticInitializer = function() {
        };
        $p.$ctor = function() {
            System.Object.prototype.$ctor.call(this);
        };
        $p.$ctor.$type = $t;
        $p.$ctor.$new = function() {
            return new $p.$ctor.$type(this);
        };
        $t.$StringProperty$k__BackingField = null;
        $t.get_StringProperty = function() {
            return this.$StringProperty$k__BackingField;
        };
        $t.set_StringProperty = function(value) {
            this.$StringProperty$k__BackingField = value;
        };
    }).call($t, $t.StaticPropertyClass, $t.StaticPropertyClass.prototype);
    $WootzJs$Compiler$Tests$AssemblyTypes.push($t.StaticPropertyClass);
}).call(null, WootzJs.Compiler.Tests.PropertyTests, WootzJs.Compiler.Tests.PropertyTests.prototype);
$WootzJs$Compiler$Tests$AssemblyTypes.push(WootzJs.Compiler.Tests.PropertyTests);
WootzJs.Compiler.Tests.Reflection.AttributeTests = $define("WootzJs.Compiler.Tests.Reflection.AttributeTests");
WootzJs.Compiler.Tests.Reflection.AttributeTests.prototype = new System.Object();
(WootzJs.Compiler.Tests.Reflection.AttributeTests.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
    $p.$type = WootzJs.Compiler.Tests.Reflection.AttributeTests;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Compiler.Tests.Reflection.AttributeTests";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("AttributeTests", [WootzJs.Compiler.Tests.TestFixtureAttribute.prototype.$ctor.$new()]);this.$type.Init("WootzJs.Compiler.Tests.Reflection.AttributeTests", WootzJs.Compiler.Tests.Reflection.AttributeTests, System.Object, [], [], [System.Reflection.MethodInfo.prototype.$ctor.$new("Method", WootzJs.Compiler.Tests.Reflection.AttributeTests.prototype.Method, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("Field", WootzJs.Compiler.Tests.Reflection.AttributeTests.prototype.Field, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("Parameter", WootzJs.Compiler.Tests.Reflection.AttributeTests.prototype.Parameter, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("EnumMember", WootzJs.Compiler.Tests.Reflection.AttributeTests.prototype.EnumMember, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.Reflection.AttributeTests.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
    $t.$StaticInitializer = function() {
    };
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.Method = function() {
        var method = System.Linq.Enumerable.Single$1(System.Reflection.MethodInfo, WootzJs.Compiler.Tests.Reflection.AttributeTests.TestClass.$GetType().GetMethods(), $delegate(this, (System.Func$2$(System.Reflection.MethodInfo, System.Boolean)), function(x) {
            return x.get_Name() == "Method";
        }));
        var attribute = $cast(WootzJs.Compiler.Tests.Reflection.AttributeTests.FooAttribute, method.GetCustomAttributes$1(WootzJs.Compiler.Tests.Reflection.AttributeTests.FooAttribute.$GetType(), false)[0]);
        QUnit.equal(attribute.get_ConstructorValue(), 1);
        QUnit.equal(attribute.get_PropertyValue(), "One");
    };
    $p.Field = function() {
        var field1 = System.Linq.Enumerable.Single$1(System.Reflection.FieldInfo, WootzJs.Compiler.Tests.Reflection.AttributeTests.TestClass.$GetType().GetFields(), $delegate(this, (System.Func$2$(System.Reflection.FieldInfo, System.Boolean)), function(x) {
            return x.get_Name() == "Field1";
        }));
        var field2 = System.Linq.Enumerable.Single$1(System.Reflection.FieldInfo, WootzJs.Compiler.Tests.Reflection.AttributeTests.TestClass.$GetType().GetFields(), $delegate(this, (System.Func$2$(System.Reflection.FieldInfo, System.Boolean)), function(x) {
            return x.get_Name() == "Field2";
        }));
        var attribute1 = $cast(WootzJs.Compiler.Tests.Reflection.AttributeTests.FooAttribute, field1.GetCustomAttributes$1(WootzJs.Compiler.Tests.Reflection.AttributeTests.FooAttribute.$GetType(), false)[0]);
        var attribute2 = $cast(WootzJs.Compiler.Tests.Reflection.AttributeTests.FooAttribute, field2.GetCustomAttributes$1(WootzJs.Compiler.Tests.Reflection.AttributeTests.FooAttribute.$GetType(), false)[0]);
        QUnit.equal(attribute1.get_ConstructorValue(), 2);
        QUnit.equal(attribute1.get_PropertyValue(), "Two");
        QUnit.equal(attribute2.get_ConstructorValue(), 3);
    };
    $p.Parameter = function() {
        var method = System.Linq.Enumerable.Single$1(System.Reflection.MethodInfo, WootzJs.Compiler.Tests.Reflection.AttributeTests.TestClass.$GetType().GetMethods(), $delegate(this, (System.Func$2$(System.Reflection.MethodInfo, System.Boolean)), function(x) {
            return x.get_Name() == "Parameter";
        }));
        var parameter1 = method.GetParameters()[0];
        var parameter2 = method.GetParameters()[1];
        var attribute1 = $cast(WootzJs.Compiler.Tests.Reflection.AttributeTests.FooAttribute, parameter1.GetCustomAttributes$1(WootzJs.Compiler.Tests.Reflection.AttributeTests.FooAttribute.$GetType(), false)[0]);
        var attribute2 = $cast(WootzJs.Compiler.Tests.Reflection.AttributeTests.FooAttribute, parameter2.GetCustomAttributes$1(WootzJs.Compiler.Tests.Reflection.AttributeTests.FooAttribute.$GetType(), false)[0]);
        QUnit.equal(attribute1.get_ConstructorValue(), 4);
        QUnit.equal(attribute1.get_PropertyValue(), "Four");
        QUnit.equal(attribute2.get_ConstructorValue(), 5);
        QUnit.equal(attribute2.get_PropertyValue(), "Five");
    };
    $p.EnumMember = function() {
        var field = System.Linq.Enumerable.Single(System.Reflection.FieldInfo, WootzJs.Compiler.Tests.Reflection.AttributeTests.TestEnum.$GetType().GetFields());
        var attribute = $cast(WootzJs.Compiler.Tests.Reflection.AttributeTests.FooAttribute, field.GetCustomAttributes$1(WootzJs.Compiler.Tests.Reflection.AttributeTests.FooAttribute.$GetType(), false)[0]);
        QUnit.equal(attribute.get_ConstructorValue(), 6);
        QUnit.equal(attribute.get_PropertyValue(), "Six");
    };
    function FooAttribute($constructor) {
        if (!$t.FooAttribute.$isStaticInitialized && ($constructor != null || !(this instanceof WootzJs.Compiler.Tests.Reflection.AttributeTests.FooAttribute))) {
            $t.FooAttribute.$isStaticInitialized = true;
            $t.FooAttribute.$StaticInitializer();
        }
        if ($constructor != null)
            $constructor.apply(this, Array.prototype.slice.call(arguments, 1));
        if (!(this instanceof WootzJs.Compiler.Tests.Reflection.AttributeTests.FooAttribute))
            return $t.FooAttribute;
    }
    $t.FooAttribute = FooAttribute;
    $t.FooAttribute.prototype = new System.Attribute();
    ($t.FooAttribute.$TypeInitializer = function($t, $p) {
        $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
        $p.$type = WootzJs.Compiler.Tests.Reflection.AttributeTests.FooAttribute;
        $t.$baseType = System.Attribute;
        $p.$typeName = "WootzJs.Compiler.Tests.Reflection.AttributeTests.FooAttribute";
        $t.$typeName = $p.$typeName;
        $t.$GetType = function() {
            return System.Type._GetTypeFromTypeFunc(this);
        };
        $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("FooAttribute", []);this.$type.Init("WootzJs.Compiler.Tests.Reflection.AttributeTests.FooAttribute", WootzJs.Compiler.Tests.Reflection.AttributeTests.FooAttribute, System.Attribute, [], [System.Reflection.FieldInfo.prototype.$ctor.$new("$PropertyValue$k__BackingField", String, System.Reflection.FieldAttributes().Private, null, []), System.Reflection.FieldInfo.prototype.$ctor.$new("constructorValue", System.Int32, System.Reflection.FieldAttributes().Private, null, [])], [System.Reflection.MethodInfo.prototype.$ctor.$new("get_PropertyValue", WootzJs.Compiler.Tests.Reflection.AttributeTests.FooAttribute.prototype.get_PropertyValue, [], String, System.Reflection.MethodAttributes().Public, []), System.Reflection.MethodInfo.prototype.$ctor.$new("set_PropertyValue", WootzJs.Compiler.Tests.Reflection.AttributeTests.FooAttribute.prototype.set_PropertyValue, [System.Reflection.ParameterInfo.prototype.$ctor.$new("value", String, 0, 0, null, [])], System.Void, System.Reflection.MethodAttributes().Public, []), System.Reflection.MethodInfo.prototype.$ctor.$new("get_ConstructorValue", WootzJs.Compiler.Tests.Reflection.AttributeTests.FooAttribute.prototype.get_ConstructorValue, [], System.Int32, System.Reflection.MethodAttributes().Public, [])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.Reflection.AttributeTests.FooAttribute.prototype.$ctor, [System.Reflection.ParameterInfo.prototype.$ctor.$new("constructorValue", System.Int32, 0, 0, null, [])], System.Reflection.MethodAttributes().Public, [])], [System.Reflection.PropertyInfo.prototype.$ctor.$new("PropertyValue", String, System.Reflection.MethodInfo.prototype.$ctor.$new("get_PropertyValue", WootzJs.Compiler.Tests.Reflection.AttributeTests.FooAttribute.prototype.get_PropertyValue, [], String, System.Reflection.MethodAttributes().Public, []), System.Reflection.MethodInfo.prototype.$ctor.$new("set_PropertyValue", WootzJs.Compiler.Tests.Reflection.AttributeTests.FooAttribute.prototype.set_PropertyValue, [System.Reflection.ParameterInfo.prototype.$ctor.$new("value", String, 0, 0, null, [])], System.Void, System.Reflection.MethodAttributes().Public, []), [], []), System.Reflection.PropertyInfo.prototype.$ctor.$new("ConstructorValue", System.Int32, System.Reflection.MethodInfo.prototype.$ctor.$new("get_ConstructorValue", WootzJs.Compiler.Tests.Reflection.AttributeTests.FooAttribute.prototype.get_ConstructorValue, [], System.Int32, System.Reflection.MethodAttributes().Public, []), null, [], [])], [], false);return this.$type;};
        $t.$StaticInitializer = function() {
        };
        $p.$PropertyValue$k__BackingField = null;
        $p.get_PropertyValue = function() {
            return this.$PropertyValue$k__BackingField;
        };
        $p.set_PropertyValue = function(value) {
            this.$PropertyValue$k__BackingField = value;
        };
        $p.constructorValue = null;
        $p.$ctor = function(constructorValue) {
            System.Attribute.prototype.$ctor.call(this);
            this.constructorValue = constructorValue;
        };
        $p.$ctor.$type = $t;
        $p.$ctor.$new = function(constructorValue) {
            return new $p.$ctor.$type(this, constructorValue);
        };
        $p.get_ConstructorValue = function() {
            return this.constructorValue;
        };
    }).call($t, $t.FooAttribute, $t.FooAttribute.prototype);
    $WootzJs$Compiler$Tests$AssemblyTypes.push($t.FooAttribute);
    function TestClass($constructor) {
        if (!$t.TestClass.$isStaticInitialized && ($constructor != null || !(this instanceof WootzJs.Compiler.Tests.Reflection.AttributeTests.TestClass))) {
            $t.TestClass.$isStaticInitialized = true;
            $t.TestClass.$StaticInitializer();
        }
        if ($constructor != null)
            $constructor.apply(this, Array.prototype.slice.call(arguments, 1));
        if (!(this instanceof WootzJs.Compiler.Tests.Reflection.AttributeTests.TestClass))
            return $t.TestClass;
    }
    $t.TestClass = TestClass;
    $t.TestClass.prototype = new System.Object();
    ($t.TestClass.$TypeInitializer = function($t, $p) {
        $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
        $p.$type = WootzJs.Compiler.Tests.Reflection.AttributeTests.TestClass;
        $t.$baseType = System.Object;
        $p.$typeName = "WootzJs.Compiler.Tests.Reflection.AttributeTests.TestClass";
        $t.$typeName = $p.$typeName;
        $t.$GetType = function() {
            return System.Type._GetTypeFromTypeFunc(this);
        };
        $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("TestClass", []);this.$type.Init("WootzJs.Compiler.Tests.Reflection.AttributeTests.TestClass", WootzJs.Compiler.Tests.Reflection.AttributeTests.TestClass, System.Object, [], [System.Reflection.FieldInfo.prototype.$ctor.$new("Field1", System.Object, System.Reflection.FieldAttributes().Public, null, [(function() {var $obj$ = WootzJs.Compiler.Tests.Reflection.AttributeTests.FooAttribute.prototype.$ctor.$new(2);$obj$.set_PropertyValue("Two");return $obj$;}).call(this)]), System.Reflection.FieldInfo.prototype.$ctor.$new("Field2", System.Object, System.Reflection.FieldAttributes().Public, null, [WootzJs.Compiler.Tests.Reflection.AttributeTests.FooAttribute.prototype.$ctor.$new(3)])], [System.Reflection.MethodInfo.prototype.$ctor.$new("Method", WootzJs.Compiler.Tests.Reflection.AttributeTests.TestClass.prototype.Method, [], System.Void, System.Reflection.MethodAttributes().Public, [(function() {var $obj$ = WootzJs.Compiler.Tests.Reflection.AttributeTests.FooAttribute.prototype.$ctor.$new(1);$obj$.set_PropertyValue("One");return $obj$;}).call(this)]), System.Reflection.MethodInfo.prototype.$ctor.$new("Parameter", WootzJs.Compiler.Tests.Reflection.AttributeTests.TestClass.prototype.Parameter, [System.Reflection.ParameterInfo.prototype.$ctor.$new("parameter1", System.Int32, 0, 0, null, [(function() {var $obj$ = WootzJs.Compiler.Tests.Reflection.AttributeTests.FooAttribute.prototype.$ctor.$new(4);$obj$.set_PropertyValue("Four");return $obj$;}).call(this)]), System.Reflection.ParameterInfo.prototype.$ctor.$new("parameter2", String, 1, 0, null, [(function() {var $obj$ = WootzJs.Compiler.Tests.Reflection.AttributeTests.FooAttribute.prototype.$ctor.$new(5);$obj$.set_PropertyValue("Five");return $obj$;}).call(this)])], System.Void, System.Reflection.MethodAttributes().Public, [])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.Reflection.AttributeTests.TestClass.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
        $t.$StaticInitializer = function() {
        };
        $p.$ctor = function() {
            System.Object.prototype.$ctor.call(this);
        };
        $p.$ctor.$type = $t;
        $p.$ctor.$new = function() {
            return new $p.$ctor.$type(this);
        };
        $p.Field1 = null;
        $p.Field2 = null;
        $p.Method = function() {
        };
        $p.Parameter = function(parameter1, parameter2) {
        };
    }).call($t, $t.TestClass, $t.TestClass.prototype);
    $WootzJs$Compiler$Tests$AssemblyTypes.push($t.TestClass);
    function TestEnum($constructor) {
        if (!$t.TestEnum.$isStaticInitialized && ($constructor != null || !(this instanceof WootzJs.Compiler.Tests.Reflection.AttributeTests.TestEnum))) {
            $t.TestEnum.$isStaticInitialized = true;
            $t.TestEnum.$StaticInitializer();
        }
        if ($constructor != null)
            $constructor.apply(this, Array.prototype.slice.call(arguments, 1));
        if (!(this instanceof WootzJs.Compiler.Tests.Reflection.AttributeTests.TestEnum))
            return $t.TestEnum;
    }
    $t.TestEnum = TestEnum;
    $t.TestEnum.prototype = new System.Enum();
    ($t.TestEnum.$TypeInitializer = function($t, $p) {
        $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
        $p.$type = WootzJs.Compiler.Tests.Reflection.AttributeTests.TestEnum;
        $t.$baseType = System.Enum;
        $p.$typeName = "WootzJs.Compiler.Tests.Reflection.AttributeTests.TestEnum";
        $t.$typeName = $p.$typeName;
        $t.$GetType = function() {
            return System.Type._GetTypeFromTypeFunc(this);
        };
        $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("TestEnum", []);this.$type.Init("WootzJs.Compiler.Tests.Reflection.AttributeTests.TestEnum", WootzJs.Compiler.Tests.Reflection.AttributeTests.TestEnum, System.Enum, [], [System.Reflection.FieldInfo.prototype.$ctor.$new("One", WootzJs.Compiler.Tests.Reflection.AttributeTests.TestEnum, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().Literal, 0, [(function() {var $obj$ = WootzJs.Compiler.Tests.Reflection.AttributeTests.FooAttribute.prototype.$ctor.$new(6);$obj$.set_PropertyValue("Six");return $obj$;}).call(this)])], [], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.Reflection.AttributeTests.TestEnum.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, [])], [], [], true);return this.$type;};
        $t.$StaticInitializer = function() {
            $t.One = 0;
            $t.One$ = $p.$ctor.$new("One", WootzJs.Compiler.Tests.Reflection.AttributeTests.TestEnum().One);
        };
        $p.$ctor = function(name, value) {
            System.Enum.prototype.$ctor.call(this, name, value);
        };
        $p.$ctor.$type = $t;
        $p.$ctor.$new = function(name, value) {
            return new $p.$ctor.$type(this, name, value);
        };
    }).call($t, $t.TestEnum, $t.TestEnum.prototype);
    $WootzJs$Compiler$Tests$AssemblyTypes.push($t.TestEnum);
}).call(null, WootzJs.Compiler.Tests.Reflection.AttributeTests, WootzJs.Compiler.Tests.Reflection.AttributeTests.prototype);
$WootzJs$Compiler$Tests$AssemblyTypes.push(WootzJs.Compiler.Tests.Reflection.AttributeTests);
WootzJs.Compiler.Tests.Reflection.ConstructorInfoTests = $define("WootzJs.Compiler.Tests.Reflection.ConstructorInfoTests");
WootzJs.Compiler.Tests.Reflection.ConstructorInfoTests.prototype = new System.Object();
(WootzJs.Compiler.Tests.Reflection.ConstructorInfoTests.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
    $p.$type = WootzJs.Compiler.Tests.Reflection.ConstructorInfoTests;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Compiler.Tests.Reflection.ConstructorInfoTests";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("ConstructorInfoTests", [WootzJs.Compiler.Tests.TestFixtureAttribute.prototype.$ctor.$new()]);this.$type.Init("WootzJs.Compiler.Tests.Reflection.ConstructorInfoTests", WootzJs.Compiler.Tests.Reflection.ConstructorInfoTests, System.Object, [], [], [System.Reflection.MethodInfo.prototype.$ctor.$new("InvokeParameterless", WootzJs.Compiler.Tests.Reflection.ConstructorInfoTests.prototype.InvokeParameterless, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("InvokeNoConstructor", WootzJs.Compiler.Tests.Reflection.ConstructorInfoTests.prototype.InvokeNoConstructor, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.Reflection.ConstructorInfoTests.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
    $t.$StaticInitializer = function() {
    };
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.InvokeParameterless = function() {
        var type = WootzJs.Compiler.Tests.Reflection.ConstructorInfoTests.TestClass.$GetType();
        var constructor = System.Linq.Enumerable.Single$1(System.Reflection.ConstructorInfo, type.GetConstructors(), $delegate(this, (System.Func$2$(System.Reflection.ConstructorInfo, System.Boolean)), function(x) {
            return x.GetParameters().length == 0;
        }));
        var testClass = $cast(WootzJs.Compiler.Tests.Reflection.ConstructorInfoTests.TestClass, constructor.Invoke$2(new Array(0)));
        QUnit.equal(testClass.Foo, "parameterless");
    };
    $p.InvokeNoConstructor = function() {
        var type = WootzJs.Compiler.Tests.Reflection.ConstructorInfoTests.NoConstructorClass.$GetType();
        var constructor = System.Linq.Enumerable.Single$1(System.Reflection.ConstructorInfo, type.GetConstructors(), $delegate(this, (System.Func$2$(System.Reflection.ConstructorInfo, System.Boolean)), function(x) {
            return x.GetParameters().length == 0;
        }));
        var testClass = $cast(WootzJs.Compiler.Tests.Reflection.ConstructorInfoTests.NoConstructorClass, constructor.Invoke$2(new Array(0)));
        QUnit.equal(testClass.Foo, "noconstructor");
    };
    function TestClass($constructor) {
        if (!$t.TestClass.$isStaticInitialized && ($constructor != null || !(this instanceof WootzJs.Compiler.Tests.Reflection.ConstructorInfoTests.TestClass))) {
            $t.TestClass.$isStaticInitialized = true;
            $t.TestClass.$StaticInitializer();
        }
        if ($constructor != null)
            $constructor.apply(this, Array.prototype.slice.call(arguments, 1));
        if (!(this instanceof WootzJs.Compiler.Tests.Reflection.ConstructorInfoTests.TestClass))
            return $t.TestClass;
    }
    $t.TestClass = TestClass;
    $t.TestClass.prototype = new System.Object();
    ($t.TestClass.$TypeInitializer = function($t, $p) {
        $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
        $p.$type = WootzJs.Compiler.Tests.Reflection.ConstructorInfoTests.TestClass;
        $t.$baseType = System.Object;
        $p.$typeName = "WootzJs.Compiler.Tests.Reflection.ConstructorInfoTests.TestClass";
        $t.$typeName = $p.$typeName;
        $t.$GetType = function() {
            return System.Type._GetTypeFromTypeFunc(this);
        };
        $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("TestClass", []);this.$type.Init("WootzJs.Compiler.Tests.Reflection.ConstructorInfoTests.TestClass", WootzJs.Compiler.Tests.Reflection.ConstructorInfoTests.TestClass, System.Object, [], [System.Reflection.FieldInfo.prototype.$ctor.$new("Foo", String, System.Reflection.FieldAttributes().Public, null, [])], [], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.Reflection.ConstructorInfoTests.TestClass.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
        $t.$StaticInitializer = function() {
        };
        $p.Foo = null;
        $p.$ctor = function() {
            System.Object.prototype.$ctor.call(this);
            this.Foo = "parameterless";
        };
        $p.$ctor.$type = $t;
        $p.$ctor.$new = function() {
            return new $p.$ctor.$type(this);
        };
    }).call($t, $t.TestClass, $t.TestClass.prototype);
    $WootzJs$Compiler$Tests$AssemblyTypes.push($t.TestClass);
    function NoConstructorClass($constructor) {
        if (!$t.NoConstructorClass.$isStaticInitialized && ($constructor != null || !(this instanceof WootzJs.Compiler.Tests.Reflection.ConstructorInfoTests.NoConstructorClass))) {
            $t.NoConstructorClass.$isStaticInitialized = true;
            $t.NoConstructorClass.$StaticInitializer();
        }
        if ($constructor != null)
            $constructor.apply(this, Array.prototype.slice.call(arguments, 1));
        if (!(this instanceof WootzJs.Compiler.Tests.Reflection.ConstructorInfoTests.NoConstructorClass))
            return $t.NoConstructorClass;
    }
    $t.NoConstructorClass = NoConstructorClass;
    $t.NoConstructorClass.prototype = new System.Object();
    ($t.NoConstructorClass.$TypeInitializer = function($t, $p) {
        $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
        $p.$type = WootzJs.Compiler.Tests.Reflection.ConstructorInfoTests.NoConstructorClass;
        $t.$baseType = System.Object;
        $p.$typeName = "WootzJs.Compiler.Tests.Reflection.ConstructorInfoTests.NoConstructorClass";
        $t.$typeName = $p.$typeName;
        $t.$GetType = function() {
            return System.Type._GetTypeFromTypeFunc(this);
        };
        $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("NoConstructorClass", []);this.$type.Init("WootzJs.Compiler.Tests.Reflection.ConstructorInfoTests.NoConstructorClass", WootzJs.Compiler.Tests.Reflection.ConstructorInfoTests.NoConstructorClass, System.Object, [], [System.Reflection.FieldInfo.prototype.$ctor.$new("Foo", String, System.Reflection.FieldAttributes().Public, null, [])], [], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.Reflection.ConstructorInfoTests.NoConstructorClass.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
        $t.$StaticInitializer = function() {
        };
        $p.$ctor = function() {
            System.Object.prototype.$ctor.call(this);
            this.Foo = "noconstructor";
        };
        $p.$ctor.$type = $t;
        $p.$ctor.$new = function() {
            return new $p.$ctor.$type(this);
        };
        $p.Foo = null;
    }).call($t, $t.NoConstructorClass, $t.NoConstructorClass.prototype);
    $WootzJs$Compiler$Tests$AssemblyTypes.push($t.NoConstructorClass);
}).call(null, WootzJs.Compiler.Tests.Reflection.ConstructorInfoTests, WootzJs.Compiler.Tests.Reflection.ConstructorInfoTests.prototype);
$WootzJs$Compiler$Tests$AssemblyTypes.push(WootzJs.Compiler.Tests.Reflection.ConstructorInfoTests);
WootzJs.Compiler.Tests.Reflection.EventInfoTests = $define("WootzJs.Compiler.Tests.Reflection.EventInfoTests");
WootzJs.Compiler.Tests.Reflection.EventInfoTests.prototype = new System.Object();
(WootzJs.Compiler.Tests.Reflection.EventInfoTests.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
    $p.$type = WootzJs.Compiler.Tests.Reflection.EventInfoTests;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Compiler.Tests.Reflection.EventInfoTests";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("EventInfoTests", [WootzJs.Compiler.Tests.TestFixtureAttribute.prototype.$ctor.$new()]);this.$type.Init("WootzJs.Compiler.Tests.Reflection.EventInfoTests", WootzJs.Compiler.Tests.Reflection.EventInfoTests, System.Object, [], [], [System.Reflection.MethodInfo.prototype.$ctor.$new("Name", WootzJs.Compiler.Tests.Reflection.EventInfoTests.prototype.Name, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.Reflection.EventInfoTests.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
    $t.$StaticInitializer = function() {
    };
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.Name = function() {
        var events = WootzJs.Compiler.Tests.Reflection.EventInfoTests.EventClass.$GetType().GetEvents();
        var staticEvent = System.Linq.Enumerable.Single$1(System.Reflection.EventInfo, events, $delegate(this, (System.Func$2$(System.Reflection.EventInfo, System.Boolean)), function(x) {
            return x.get_Name() == "StaticEvent";
        }));
        var stringEvent = System.Linq.Enumerable.Single$1(System.Reflection.EventInfo, events, $delegate(this, (System.Func$2$(System.Reflection.EventInfo, System.Boolean)), function(x) {
            return x.get_Name() == "StringEvent";
        }));
        QUnit.equal(staticEvent.get_Name(), "StaticEvent");
        QUnit.equal(stringEvent.get_Name(), "StringEvent");
    };
    function EventClass($constructor) {
        if (!$t.EventClass.$isStaticInitialized && ($constructor != null || !(this instanceof WootzJs.Compiler.Tests.Reflection.EventInfoTests.EventClass))) {
            $t.EventClass.$isStaticInitialized = true;
            $t.EventClass.$StaticInitializer();
        }
        if ($constructor != null)
            $constructor.apply(this, Array.prototype.slice.call(arguments, 1));
        if (!(this instanceof WootzJs.Compiler.Tests.Reflection.EventInfoTests.EventClass))
            return $t.EventClass;
    }
    $t.EventClass = EventClass;
    $t.EventClass.prototype = new System.Object();
    ($t.EventClass.$TypeInitializer = function($t, $p) {
        $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
        $p.$type = WootzJs.Compiler.Tests.Reflection.EventInfoTests.EventClass;
        $t.$baseType = System.Object;
        $p.$typeName = "WootzJs.Compiler.Tests.Reflection.EventInfoTests.EventClass";
        $t.$typeName = $p.$typeName;
        $t.$GetType = function() {
            return System.Type._GetTypeFromTypeFunc(this);
        };
        $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("EventClass", []);this.$type.Init("WootzJs.Compiler.Tests.Reflection.EventInfoTests.EventClass", WootzJs.Compiler.Tests.Reflection.EventInfoTests.EventClass, System.Object, [], [], [System.Reflection.MethodInfo.prototype.$ctor.$new("add_StaticEvent", WootzJs.Compiler.Tests.Reflection.EventInfoTests.EventClass.prototype.add_StaticEvent, [System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Action, 0, 0, null, [])], System.Void, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, []), System.Reflection.MethodInfo.prototype.$ctor.$new("remove_StaticEvent", WootzJs.Compiler.Tests.Reflection.EventInfoTests.EventClass.prototype.remove_StaticEvent, [System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Action, 0, 0, null, [])], System.Void, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, []), System.Reflection.MethodInfo.prototype.$ctor.$new("add_StringEvent", WootzJs.Compiler.Tests.Reflection.EventInfoTests.EventClass.prototype.add_StringEvent, [System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Action$1, 0, 0, null, [])], System.Void, System.Reflection.MethodAttributes().Public, []), System.Reflection.MethodInfo.prototype.$ctor.$new("remove_StringEvent", WootzJs.Compiler.Tests.Reflection.EventInfoTests.EventClass.prototype.remove_StringEvent, [System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Action$1, 0, 0, null, [])], System.Void, System.Reflection.MethodAttributes().Public, [])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.Reflection.EventInfoTests.EventClass.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, [])], [], [System.Reflection.EventInfo.prototype.$ctor.$new("StaticEvent", System.Action, System.Reflection.MethodInfo.prototype.$ctor.$new("add_StaticEvent", WootzJs.Compiler.Tests.Reflection.EventInfoTests.EventClass.prototype.add_StaticEvent, [System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Action, 0, 0, null, [])], System.Void, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, []), System.Reflection.MethodInfo.prototype.$ctor.$new("remove_StaticEvent", WootzJs.Compiler.Tests.Reflection.EventInfoTests.EventClass.prototype.remove_StaticEvent, [System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Action, 0, 0, null, [])], System.Void, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, []), []), System.Reflection.EventInfo.prototype.$ctor.$new("StringEvent", System.Action$1, System.Reflection.MethodInfo.prototype.$ctor.$new("add_StringEvent", WootzJs.Compiler.Tests.Reflection.EventInfoTests.EventClass.prototype.add_StringEvent, [System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Action$1, 0, 0, null, [])], System.Void, System.Reflection.MethodAttributes().Public, []), System.Reflection.MethodInfo.prototype.$ctor.$new("remove_StringEvent", WootzJs.Compiler.Tests.Reflection.EventInfoTests.EventClass.prototype.remove_StringEvent, [System.Reflection.ParameterInfo.prototype.$ctor.$new("value", System.Action$1, 0, 0, null, [])], System.Void, System.Reflection.MethodAttributes().Public, []), [])], false);return this.$type;};
        $t.$StaticInitializer = function() {
        };
        $p.$ctor = function() {
            System.Object.prototype.$ctor.call(this);
        };
        $p.$ctor.$type = $t;
        $p.$ctor.$new = function() {
            return new $p.$ctor.$type(this);
        };
        $p.$StaticEvent$k__BackingField = null;
        $p.add_StaticEvent = function(value) {
            this.$StaticEvent$k__BackingField = System.Delegate.Combine(this.$StaticEvent$k__BackingField, value);
        };
        $p.remove_StaticEvent = function(value) {
            this.$StaticEvent$k__BackingField = System.Delegate.Remove(this.$StaticEvent$k__BackingField, value);
        };
        $p.$StringEvent$k__BackingField = null;
        $p.add_StringEvent = function(value) {
            this.$StringEvent$k__BackingField = System.Delegate.Combine(this.$StringEvent$k__BackingField, value);
        };
        $p.remove_StringEvent = function(value) {
            this.$StringEvent$k__BackingField = System.Delegate.Remove(this.$StringEvent$k__BackingField, value);
        };
    }).call($t, $t.EventClass, $t.EventClass.prototype);
    $WootzJs$Compiler$Tests$AssemblyTypes.push($t.EventClass);
}).call(null, WootzJs.Compiler.Tests.Reflection.EventInfoTests, WootzJs.Compiler.Tests.Reflection.EventInfoTests.prototype);
$WootzJs$Compiler$Tests$AssemblyTypes.push(WootzJs.Compiler.Tests.Reflection.EventInfoTests);
WootzJs.Compiler.Tests.Reflection.PropertyInfoTests = $define("WootzJs.Compiler.Tests.Reflection.PropertyInfoTests");
WootzJs.Compiler.Tests.Reflection.PropertyInfoTests.prototype = new System.Object();
(WootzJs.Compiler.Tests.Reflection.PropertyInfoTests.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
    $p.$type = WootzJs.Compiler.Tests.Reflection.PropertyInfoTests;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Compiler.Tests.Reflection.PropertyInfoTests";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("PropertyInfoTests", [WootzJs.Compiler.Tests.TestFixtureAttribute.prototype.$ctor.$new()]);this.$type.Init("WootzJs.Compiler.Tests.Reflection.PropertyInfoTests", WootzJs.Compiler.Tests.Reflection.PropertyInfoTests, System.Object, [], [], [System.Reflection.MethodInfo.prototype.$ctor.$new("Name", WootzJs.Compiler.Tests.Reflection.PropertyInfoTests.prototype.Name, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.Reflection.PropertyInfoTests.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
    $t.$StaticInitializer = function() {
    };
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.Name = function() {
        var properties = WootzJs.Compiler.Tests.Reflection.PropertyInfoTests.PropertyClass.$GetType().GetProperties();
        var staticProperty = System.Linq.Enumerable.Single$1(System.Reflection.PropertyInfo, properties, $delegate(this, (System.Func$2$(System.Reflection.PropertyInfo, System.Boolean)), function(x) {
            return x.get_Name() == "StaticProperty";
        }));
        var stringProperty = System.Linq.Enumerable.Single$1(System.Reflection.PropertyInfo, properties, $delegate(this, (System.Func$2$(System.Reflection.PropertyInfo, System.Boolean)), function(x) {
            return x.get_Name() == "StringProperty";
        }));
        QUnit.equal(staticProperty.get_Name(), "StaticProperty");
        QUnit.equal(stringProperty.get_Name(), "StringProperty");
    };
    function PropertyClass($constructor) {
        if (!$t.PropertyClass.$isStaticInitialized && ($constructor != null || !(this instanceof WootzJs.Compiler.Tests.Reflection.PropertyInfoTests.PropertyClass))) {
            $t.PropertyClass.$isStaticInitialized = true;
            $t.PropertyClass.$StaticInitializer();
        }
        if ($constructor != null)
            $constructor.apply(this, Array.prototype.slice.call(arguments, 1));
        if (!(this instanceof WootzJs.Compiler.Tests.Reflection.PropertyInfoTests.PropertyClass))
            return $t.PropertyClass;
    }
    $t.PropertyClass = PropertyClass;
    $t.PropertyClass.prototype = new System.Object();
    ($t.PropertyClass.$TypeInitializer = function($t, $p) {
        $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
        $p.$type = WootzJs.Compiler.Tests.Reflection.PropertyInfoTests.PropertyClass;
        $t.$baseType = System.Object;
        $p.$typeName = "WootzJs.Compiler.Tests.Reflection.PropertyInfoTests.PropertyClass";
        $t.$typeName = $p.$typeName;
        $t.$GetType = function() {
            return System.Type._GetTypeFromTypeFunc(this);
        };
        $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("PropertyClass", []);this.$type.Init("WootzJs.Compiler.Tests.Reflection.PropertyInfoTests.PropertyClass", WootzJs.Compiler.Tests.Reflection.PropertyInfoTests.PropertyClass, System.Object, [], [System.Reflection.FieldInfo.prototype.$ctor.$new("$StaticProperty$k__BackingField", String, System.Reflection.FieldAttributes().Private | System.Reflection.FieldAttributes().Static, null, []), System.Reflection.FieldInfo.prototype.$ctor.$new("$StringProperty$k__BackingField", String, System.Reflection.FieldAttributes().Private, null, [])], [System.Reflection.MethodInfo.prototype.$ctor.$new("get_StaticProperty", WootzJs.Compiler.Tests.Reflection.PropertyInfoTests.PropertyClass.prototype.get_StaticProperty, [], String, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, []), System.Reflection.MethodInfo.prototype.$ctor.$new("set_StaticProperty", WootzJs.Compiler.Tests.Reflection.PropertyInfoTests.PropertyClass.prototype.set_StaticProperty, [System.Reflection.ParameterInfo.prototype.$ctor.$new("value", String, 0, 0, null, [])], System.Void, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, []), System.Reflection.MethodInfo.prototype.$ctor.$new("get_StringProperty", WootzJs.Compiler.Tests.Reflection.PropertyInfoTests.PropertyClass.prototype.get_StringProperty, [], String, System.Reflection.MethodAttributes().Public, []), System.Reflection.MethodInfo.prototype.$ctor.$new("set_StringProperty", WootzJs.Compiler.Tests.Reflection.PropertyInfoTests.PropertyClass.prototype.set_StringProperty, [System.Reflection.ParameterInfo.prototype.$ctor.$new("value", String, 0, 0, null, [])], System.Void, System.Reflection.MethodAttributes().Public, [])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.Reflection.PropertyInfoTests.PropertyClass.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, [])], [System.Reflection.PropertyInfo.prototype.$ctor.$new("StaticProperty", String, System.Reflection.MethodInfo.prototype.$ctor.$new("get_StaticProperty", WootzJs.Compiler.Tests.Reflection.PropertyInfoTests.PropertyClass.prototype.get_StaticProperty, [], String, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, []), System.Reflection.MethodInfo.prototype.$ctor.$new("set_StaticProperty", WootzJs.Compiler.Tests.Reflection.PropertyInfoTests.PropertyClass.prototype.set_StaticProperty, [System.Reflection.ParameterInfo.prototype.$ctor.$new("value", String, 0, 0, null, [])], System.Void, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, []), [], []), System.Reflection.PropertyInfo.prototype.$ctor.$new("StringProperty", String, System.Reflection.MethodInfo.prototype.$ctor.$new("get_StringProperty", WootzJs.Compiler.Tests.Reflection.PropertyInfoTests.PropertyClass.prototype.get_StringProperty, [], String, System.Reflection.MethodAttributes().Public, []), System.Reflection.MethodInfo.prototype.$ctor.$new("set_StringProperty", WootzJs.Compiler.Tests.Reflection.PropertyInfoTests.PropertyClass.prototype.set_StringProperty, [System.Reflection.ParameterInfo.prototype.$ctor.$new("value", String, 0, 0, null, [])], System.Void, System.Reflection.MethodAttributes().Public, []), [], [])], [], false);return this.$type;};
        $t.$StaticInitializer = function() {
        };
        $p.$ctor = function() {
            System.Object.prototype.$ctor.call(this);
        };
        $p.$ctor.$type = $t;
        $p.$ctor.$new = function() {
            return new $p.$ctor.$type(this);
        };
        $t.$StaticProperty$k__BackingField = null;
        $t.get_StaticProperty = function() {
            return this.$StaticProperty$k__BackingField;
        };
        $t.set_StaticProperty = function(value) {
            this.$StaticProperty$k__BackingField = value;
        };
        $p.$StringProperty$k__BackingField = null;
        $p.get_StringProperty = function() {
            return this.$StringProperty$k__BackingField;
        };
        $p.set_StringProperty = function(value) {
            this.$StringProperty$k__BackingField = value;
        };
    }).call($t, $t.PropertyClass, $t.PropertyClass.prototype);
    $WootzJs$Compiler$Tests$AssemblyTypes.push($t.PropertyClass);
}).call(null, WootzJs.Compiler.Tests.Reflection.PropertyInfoTests, WootzJs.Compiler.Tests.Reflection.PropertyInfoTests.prototype);
$WootzJs$Compiler$Tests$AssemblyTypes.push(WootzJs.Compiler.Tests.Reflection.PropertyInfoTests);
WootzJs.Compiler.Tests.ScopeTests = $define("WootzJs.Compiler.Tests.ScopeTests");
WootzJs.Compiler.Tests.ScopeTests.prototype = new System.Object();
(WootzJs.Compiler.Tests.ScopeTests.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
    $p.$type = WootzJs.Compiler.Tests.ScopeTests;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Compiler.Tests.ScopeTests";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("ScopeTests", [WootzJs.Compiler.Tests.TestFixtureAttribute.prototype.$ctor.$new()]);this.$type.Init("WootzJs.Compiler.Tests.ScopeTests", WootzJs.Compiler.Tests.ScopeTests, System.Object, [], [], [System.Reflection.MethodInfo.prototype.$ctor.$new("CanModifyClosedVariableWithAssignment", WootzJs.Compiler.Tests.ScopeTests.prototype.CanModifyClosedVariableWithAssignment, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("CanModifyClosedVariableWithIncrementor", WootzJs.Compiler.Tests.ScopeTests.prototype.CanModifyClosedVariableWithIncrementor, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("CanSeeChangesToClosedVariable", WootzJs.Compiler.Tests.ScopeTests.prototype.CanSeeChangesToClosedVariable, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.ScopeTests.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
    $t.$StaticInitializer = function() {
    };
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.CanModifyClosedVariableWithAssignment = function() {
        var i = 0;
        var action = $delegate(this, System.Action, function() {
            return i = i + 1;
        });
        action();
        QUnit.equal(i, 1);
    };
    $p.CanModifyClosedVariableWithIncrementor = function() {
        var i = 0;
        var action = $delegate(this, System.Action, function() {
            return i++;
        });
        action();
        QUnit.equal(i, 1);
    };
    $p.CanSeeChangesToClosedVariable = function() {
        var i = 0;
        var action = $delegate(this, System.Action, function() {
            return i = i + 1;
        });
        i = 1;
        action();
        QUnit.equal(i, 2);
    };
}).call(null, WootzJs.Compiler.Tests.ScopeTests, WootzJs.Compiler.Tests.ScopeTests.prototype);
$WootzJs$Compiler$Tests$AssemblyTypes.push(WootzJs.Compiler.Tests.ScopeTests);
WootzJs.Compiler.Tests.TestAttribute = $define("WootzJs.Compiler.Tests.TestAttribute");
WootzJs.Compiler.Tests.TestAttribute.prototype = new System.Attribute();
(WootzJs.Compiler.Tests.TestAttribute.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
    $p.$type = WootzJs.Compiler.Tests.TestAttribute;
    $t.$baseType = System.Attribute;
    $p.$typeName = "WootzJs.Compiler.Tests.TestAttribute";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("TestAttribute", [System.AttributeUsageAttribute.prototype.$ctor.$new(64)]);this.$type.Init("WootzJs.Compiler.Tests.TestAttribute", WootzJs.Compiler.Tests.TestAttribute, System.Attribute, [], [], [], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
    $t.$StaticInitializer = function() {
    };
    $p.$ctor = function() {
        System.Attribute.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
}).call(null, WootzJs.Compiler.Tests.TestAttribute, WootzJs.Compiler.Tests.TestAttribute.prototype);
$WootzJs$Compiler$Tests$AssemblyTypes.push(WootzJs.Compiler.Tests.TestAttribute);
WootzJs.Compiler.Tests.TestFixtureAttribute = $define("WootzJs.Compiler.Tests.TestFixtureAttribute");
WootzJs.Compiler.Tests.TestFixtureAttribute.prototype = new System.Attribute();
(WootzJs.Compiler.Tests.TestFixtureAttribute.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
    $p.$type = WootzJs.Compiler.Tests.TestFixtureAttribute;
    $t.$baseType = System.Attribute;
    $p.$typeName = "WootzJs.Compiler.Tests.TestFixtureAttribute";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("TestFixtureAttribute", [System.AttributeUsageAttribute.prototype.$ctor.$new(4)]);this.$type.Init("WootzJs.Compiler.Tests.TestFixtureAttribute", WootzJs.Compiler.Tests.TestFixtureAttribute, System.Attribute, [], [], [], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.TestFixtureAttribute.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
    $t.$StaticInitializer = function() {
    };
    $p.$ctor = function() {
        System.Attribute.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
}).call(null, WootzJs.Compiler.Tests.TestFixtureAttribute, WootzJs.Compiler.Tests.TestFixtureAttribute.prototype);
$WootzJs$Compiler$Tests$AssemblyTypes.push(WootzJs.Compiler.Tests.TestFixtureAttribute);
WootzJs.Compiler.Tests.Reflection.AssemblyTests = $define("WootzJs.Compiler.Tests.Reflection.AssemblyTests");
WootzJs.Compiler.Tests.Reflection.AssemblyTests.prototype = new System.Object();
(WootzJs.Compiler.Tests.Reflection.AssemblyTests.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
    $p.$type = WootzJs.Compiler.Tests.Reflection.AssemblyTests;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Compiler.Tests.Reflection.AssemblyTests";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("AssemblyTests", [WootzJs.Compiler.Tests.TestFixtureAttribute.prototype.$ctor.$new()]);this.$type.Init("WootzJs.Compiler.Tests.Reflection.AssemblyTests", WootzJs.Compiler.Tests.Reflection.AssemblyTests, System.Object, [], [], [System.Reflection.MethodInfo.prototype.$ctor.$new("FullName", WootzJs.Compiler.Tests.Reflection.AssemblyTests.prototype.FullName, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("AllAssemblies", WootzJs.Compiler.Tests.Reflection.AssemblyTests.prototype.AllAssemblies, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("TypeByName", WootzJs.Compiler.Tests.Reflection.AssemblyTests.prototype.TypeByName, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("TypeByNameThrowsOnNotFound", WootzJs.Compiler.Tests.Reflection.AssemblyTests.prototype.TypeByNameThrowsOnNotFound, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("TypeByNameIgnoreCase", WootzJs.Compiler.Tests.Reflection.AssemblyTests.prototype.TypeByNameIgnoreCase, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.Reflection.AssemblyTests.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
    $t.$StaticInitializer = function() {
    };
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.FullName = function() {
        var assembly = WootzJs.Compiler.Tests.TestsApplication.$GetType().get_Assembly();
        QUnit.equal(assembly.get_FullName(), "WootzJs.Compiler.Tests");
    };
    $p.AllAssemblies = function() {
        var assemblies = System.AppDomain().get_CurrentDomain().GetAssemblies();
        var mscorlib = assemblies[0];
        var tests = assemblies[1];
        QUnit.equal(mscorlib.get_FullName(), "mscorlib");
        QUnit.equal(tests.get_FullName(), "WootzJs.Compiler.Tests");
    };
    $p.TypeByName = function() {
        var assembly = System.AppDomain().get_CurrentDomain().GetAssemblies()[1];
        var type = assembly.GetType$1("WootzJs.Compiler.Tests.Reflection.AssemblyTests.TestClass");
        QUnit.ok(type != null);
    };
    $p.TypeByNameThrowsOnNotFound = function() {
        var assembly = System.AppDomain().get_CurrentDomain().GetAssemblies()[1];
        try {
            var type = assembly.GetType$2("WootzJs.Compiler.Tests.Reflection.AssemblyTests.InvalidClass", true);
            QUnit.ok(false);
        }
        catch (e) {
            QUnit.ok(true);
        }
    };
    $p.TypeByNameIgnoreCase = function() {
        var assembly = System.AppDomain().get_CurrentDomain().GetAssemblies()[1];
        var type = assembly.GetType$3("WOOTZJS.COMPILER.TESTS.REFLECTION.ASSEMBLYTESTS.TESTCLASS", false, true);
        QUnit.ok(type != null);
    };
    function TestClass($constructor) {
        if (!$t.TestClass.$isStaticInitialized && ($constructor != null || !(this instanceof WootzJs.Compiler.Tests.Reflection.AssemblyTests.TestClass))) {
            $t.TestClass.$isStaticInitialized = true;
            $t.TestClass.$StaticInitializer();
        }
        if ($constructor != null)
            $constructor.apply(this, Array.prototype.slice.call(arguments, 1));
        if (!(this instanceof WootzJs.Compiler.Tests.Reflection.AssemblyTests.TestClass))
            return $t.TestClass;
    }
    $t.TestClass = TestClass;
    $t.TestClass.prototype = new System.Object();
    ($t.TestClass.$TypeInitializer = function($t, $p) {
        $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
        $p.$type = WootzJs.Compiler.Tests.Reflection.AssemblyTests.TestClass;
        $t.$baseType = System.Object;
        $p.$typeName = "WootzJs.Compiler.Tests.Reflection.AssemblyTests.TestClass";
        $t.$typeName = $p.$typeName;
        $t.$GetType = function() {
            return System.Type._GetTypeFromTypeFunc(this);
        };
        $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("TestClass", []);this.$type.Init("WootzJs.Compiler.Tests.Reflection.AssemblyTests.TestClass", WootzJs.Compiler.Tests.Reflection.AssemblyTests.TestClass, System.Object, [], [], [], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.Reflection.AssemblyTests.TestClass.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
        $t.$StaticInitializer = function() {
        };
        $p.$ctor = function() {
            System.Object.prototype.$ctor.call(this);
        };
        $p.$ctor.$type = $t;
        $p.$ctor.$new = function() {
            return new $p.$ctor.$type(this);
        };
    }).call($t, $t.TestClass, $t.TestClass.prototype);
    $WootzJs$Compiler$Tests$AssemblyTypes.push($t.TestClass);
}).call(null, WootzJs.Compiler.Tests.Reflection.AssemblyTests, WootzJs.Compiler.Tests.Reflection.AssemblyTests.prototype);
$WootzJs$Compiler$Tests$AssemblyTypes.push(WootzJs.Compiler.Tests.Reflection.AssemblyTests);
WootzJs.Compiler.Tests.Reflection.FieldInfoTests = $define("WootzJs.Compiler.Tests.Reflection.FieldInfoTests");
WootzJs.Compiler.Tests.Reflection.FieldInfoTests.prototype = new System.Object();
(WootzJs.Compiler.Tests.Reflection.FieldInfoTests.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
    $p.$type = WootzJs.Compiler.Tests.Reflection.FieldInfoTests;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Compiler.Tests.Reflection.FieldInfoTests";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("FieldInfoTests", [WootzJs.Compiler.Tests.TestFixtureAttribute.prototype.$ctor.$new()]);this.$type.Init("WootzJs.Compiler.Tests.Reflection.FieldInfoTests", WootzJs.Compiler.Tests.Reflection.FieldInfoTests, System.Object, [], [], [System.Reflection.MethodInfo.prototype.$ctor.$new("Name", WootzJs.Compiler.Tests.Reflection.FieldInfoTests.prototype.Name, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("Visibility", WootzJs.Compiler.Tests.Reflection.FieldInfoTests.prototype.Visibility, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("ConstantValue", WootzJs.Compiler.Tests.Reflection.FieldInfoTests.prototype.ConstantValue, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("GetValue", WootzJs.Compiler.Tests.Reflection.FieldInfoTests.prototype.GetValue, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("SetValue", WootzJs.Compiler.Tests.Reflection.FieldInfoTests.prototype.SetValue, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.Reflection.FieldInfoTests.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
    $t.$StaticInitializer = function() {
    };
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.Name = function() {
        var type = WootzJs.Compiler.Tests.Reflection.FieldInfoTests.FieldClass.$GetType();
        var fields = type.GetFields();
        var stringField = System.Linq.Enumerable.Single$1(System.Reflection.FieldInfo, fields, $delegate(this, (System.Func$2$(System.Reflection.FieldInfo, System.Boolean)), function(x) {
            return x.get_Name() == "StringField";
        }));
        var intField = System.Linq.Enumerable.Single$1(System.Reflection.FieldInfo, fields, $delegate(this, (System.Func$2$(System.Reflection.FieldInfo, System.Boolean)), function(x) {
            return x.get_Name() == "IntField";
        }));
        var staticField = System.Linq.Enumerable.Single$1(System.Reflection.FieldInfo, fields, $delegate(this, (System.Func$2$(System.Reflection.FieldInfo, System.Boolean)), function(x) {
            return x.get_Name() == "StaticField";
        }));
        var protectedField = System.Linq.Enumerable.Single$1(System.Reflection.FieldInfo, fields, $delegate(this, (System.Func$2$(System.Reflection.FieldInfo, System.Boolean)), function(x) {
            return x.get_Name() == "ProtectedField";
        }));
        var privateField = System.Linq.Enumerable.Single$1(System.Reflection.FieldInfo, fields, $delegate(this, (System.Func$2$(System.Reflection.FieldInfo, System.Boolean)), function(x) {
            return x.get_Name() == "PrivateField";
        }));
        var internalField = System.Linq.Enumerable.Single$1(System.Reflection.FieldInfo, fields, $delegate(this, (System.Func$2$(System.Reflection.FieldInfo, System.Boolean)), function(x) {
            return x.get_Name() == "InternalField";
        }));
        QUnit.equal(stringField.get_Name(), "StringField");
        QUnit.equal(intField.get_Name(), "IntField");
        QUnit.equal(staticField.get_Name(), "StaticField");
        QUnit.equal(protectedField.get_Name(), "ProtectedField");
        QUnit.equal(privateField.get_Name(), "PrivateField");
        QUnit.equal(internalField.get_Name(), "InternalField");
    };
    $p.Visibility = function() {
        var type = WootzJs.Compiler.Tests.Reflection.FieldInfoTests.FieldClass.$GetType();
        var fields = type.GetFields();
        var stringField = System.Linq.Enumerable.Single$1(System.Reflection.FieldInfo, fields, $delegate(this, (System.Func$2$(System.Reflection.FieldInfo, System.Boolean)), function(x) {
            return x.get_Name() == "StringField";
        }));
        var intField = System.Linq.Enumerable.Single$1(System.Reflection.FieldInfo, fields, $delegate(this, (System.Func$2$(System.Reflection.FieldInfo, System.Boolean)), function(x) {
            return x.get_Name() == "IntField";
        }));
        var staticField = System.Linq.Enumerable.Single$1(System.Reflection.FieldInfo, fields, $delegate(this, (System.Func$2$(System.Reflection.FieldInfo, System.Boolean)), function(x) {
            return x.get_Name() == "StaticField";
        }));
        var protectedField = System.Linq.Enumerable.Single$1(System.Reflection.FieldInfo, fields, $delegate(this, (System.Func$2$(System.Reflection.FieldInfo, System.Boolean)), function(x) {
            return x.get_Name() == "ProtectedField";
        }));
        var privateField = System.Linq.Enumerable.Single$1(System.Reflection.FieldInfo, fields, $delegate(this, (System.Func$2$(System.Reflection.FieldInfo, System.Boolean)), function(x) {
            return x.get_Name() == "PrivateField";
        }));
        var internalField = System.Linq.Enumerable.Single$1(System.Reflection.FieldInfo, fields, $delegate(this, (System.Func$2$(System.Reflection.FieldInfo, System.Boolean)), function(x) {
            return x.get_Name() == "InternalField";
        }));
        var protectedInternalField = System.Linq.Enumerable.Single$1(System.Reflection.FieldInfo, fields, $delegate(this, (System.Func$2$(System.Reflection.FieldInfo, System.Boolean)), function(x) {
            return x.get_Name() == "ProtectedInternalField";
        }));
        var readonlyField = System.Linq.Enumerable.Single$1(System.Reflection.FieldInfo, fields, $delegate(this, (System.Func$2$(System.Reflection.FieldInfo, System.Boolean)), function(x) {
            return x.get_Name() == "ReadonlyField";
        }));
        var constantField = System.Linq.Enumerable.Single$1(System.Reflection.FieldInfo, fields, $delegate(this, (System.Func$2$(System.Reflection.FieldInfo, System.Boolean)), function(x) {
            return x.get_Name() == "ConstantField";
        }));
        QUnit.ok(stringField.get_IsPublic());
        QUnit.ok(intField.get_IsPublic());
        QUnit.ok(staticField.get_IsPublic());
        QUnit.ok(staticField.get_IsStatic());
        QUnit.ok(protectedField.get_IsFamily());
        QUnit.ok(!protectedField.get_IsPublic());
        QUnit.ok(privateField.get_IsPrivate());
        QUnit.ok(!privateField.get_IsPublic());
        QUnit.ok(internalField.get_IsAssembly());
        QUnit.ok(!internalField.get_IsPublic());
        QUnit.ok(!protectedInternalField.get_IsPublic());
        QUnit.ok(protectedInternalField.get_IsFamilyOrAssembly());
        QUnit.ok(readonlyField.get_IsInitOnly());
        QUnit.ok(constantField.get_IsLiteral());
    };
    $p.ConstantValue = function() {
        var type = WootzJs.Compiler.Tests.Reflection.FieldInfoTests.FieldClass.$GetType();
        var fields = type.GetFields();
        var constantField = System.Linq.Enumerable.Single$1(System.Reflection.FieldInfo, fields, $delegate(this, (System.Func$2$(System.Reflection.FieldInfo, System.Boolean)), function(x) {
            return x.get_Name() == "ConstantField";
        }));
        var constantValue = constantField.GetRawConstantValue();
        QUnit.equal(constantValue, "foo");
    };
    $p.GetValue = function() {
        var o = WootzJs.Compiler.Tests.Reflection.FieldInfoTests.FieldClass.prototype.$ctor.$new();
        var type = o.GetType();
        var fields = type.GetFields();
        var stringField = System.Linq.Enumerable.Single$1(System.Reflection.FieldInfo, fields, $delegate(this, (System.Func$2$(System.Reflection.FieldInfo, System.Boolean)), function(x) {
            return x.get_Name() == "StringField";
        }));
        var staticField = System.Linq.Enumerable.Single$1(System.Reflection.FieldInfo, fields, $delegate(this, (System.Func$2$(System.Reflection.FieldInfo, System.Boolean)), function(x) {
            return x.get_Name() == "StaticField";
        }));
        var stringFieldValue = stringField.GetValue(o);
        QUnit.equal(stringFieldValue, "bar");
        var staticFieldValue = staticField.GetValue(null);
        QUnit.equal(staticFieldValue, "foobar");
    };
    $p.SetValue = function() {
        var o = WootzJs.Compiler.Tests.Reflection.FieldInfoTests.FieldClass.prototype.$ctor.$new();
        var type = o.GetType();
        var fields = type.GetFields();
        var stringField = System.Linq.Enumerable.Single$1(System.Reflection.FieldInfo, fields, $delegate(this, (System.Func$2$(System.Reflection.FieldInfo, System.Boolean)), function(x) {
            return x.get_Name() == "StringField";
        }));
        var staticField = System.Linq.Enumerable.Single$1(System.Reflection.FieldInfo, fields, $delegate(this, (System.Func$2$(System.Reflection.FieldInfo, System.Boolean)), function(x) {
            return x.get_Name() == "StaticField";
        }));
        stringField.SetValue(o, "bar2");
        staticField.SetValue(o, "foobar2");
        var stringFieldValue = stringField.GetValue(o);
        QUnit.equal(stringFieldValue, "bar2");
        var staticFieldValue = staticField.GetValue(null);
        QUnit.equal(staticFieldValue, "foobar2");
    };
    function FieldClass($constructor) {
        if (!$t.FieldClass.$isStaticInitialized && ($constructor != null || !(this instanceof WootzJs.Compiler.Tests.Reflection.FieldInfoTests.FieldClass))) {
            $t.FieldClass.$isStaticInitialized = true;
            $t.FieldClass.$StaticInitializer();
        }
        if ($constructor != null)
            $constructor.apply(this, Array.prototype.slice.call(arguments, 1));
        if (!(this instanceof WootzJs.Compiler.Tests.Reflection.FieldInfoTests.FieldClass))
            return $t.FieldClass;
    }
    $t.FieldClass = FieldClass;
    $t.FieldClass.prototype = new System.Object();
    ($t.FieldClass.$TypeInitializer = function($t, $p) {
        $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
        $p.$type = WootzJs.Compiler.Tests.Reflection.FieldInfoTests.FieldClass;
        $t.$baseType = System.Object;
        $p.$typeName = "WootzJs.Compiler.Tests.Reflection.FieldInfoTests.FieldClass";
        $t.$typeName = $p.$typeName;
        $t.$GetType = function() {
            return System.Type._GetTypeFromTypeFunc(this);
        };
        $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("FieldClass", []);this.$type.Init("WootzJs.Compiler.Tests.Reflection.FieldInfoTests.FieldClass", WootzJs.Compiler.Tests.Reflection.FieldInfoTests.FieldClass, System.Object, [], [System.Reflection.FieldInfo.prototype.$ctor.$new("StringField", String, System.Reflection.FieldAttributes().Public, null, []), System.Reflection.FieldInfo.prototype.$ctor.$new("IntField", System.Int32, System.Reflection.FieldAttributes().Public, null, []), System.Reflection.FieldInfo.prototype.$ctor.$new("StaticField", String, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static, null, []), System.Reflection.FieldInfo.prototype.$ctor.$new("ProtectedField", System.Boolean, System.Reflection.FieldAttributes().Family, null, []), System.Reflection.FieldInfo.prototype.$ctor.$new("PrivateField", WootzJs.Compiler.Tests.Reflection.FieldInfoTests.FieldClass, System.Reflection.FieldAttributes().Private, null, []), System.Reflection.FieldInfo.prototype.$ctor.$new("InternalField", String, System.Reflection.FieldAttributes().Assembly, null, []), System.Reflection.FieldInfo.prototype.$ctor.$new("ProtectedInternalField", String, System.Reflection.FieldAttributes().FamORAssem, null, []), System.Reflection.FieldInfo.prototype.$ctor.$new("ReadonlyField", String, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().InitOnly, null, []), System.Reflection.FieldInfo.prototype.$ctor.$new("ConstantField", String, System.Reflection.FieldAttributes().Public | System.Reflection.FieldAttributes().Static | System.Reflection.FieldAttributes().Literal, "foo", [])], [System.Reflection.MethodInfo.prototype.$ctor.$new("$cctor", WootzJs.Compiler.Tests.Reflection.FieldInfoTests.FieldClass.prototype.$cctor, [], System.Void, System.Reflection.MethodAttributes().Private | System.Reflection.MethodAttributes().Static, [])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.Reflection.FieldInfoTests.FieldClass.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
        $t.$StaticInitializer = function() {
            WootzJs.Compiler.Tests.Reflection.FieldInfoTests.FieldClass.StaticField = "foobar";
            WootzJs.Compiler.Tests.Reflection.FieldInfoTests.FieldClass.ConstantField = "foo";
        };
        $p.$ctor = function() {
            System.Object.prototype.$ctor.call(this);
            this.StringField = "bar";
        };
        $p.$ctor.$type = $t;
        $p.$ctor.$new = function() {
            return new $p.$ctor.$type(this);
        };
        $p.StringField = null;
        $p.IntField = null;
        $p.StaticField = null;
        $p.ProtectedField = null;
        $p.PrivateField = null;
        $p.InternalField = null;
        $p.ProtectedInternalField = null;
        $p.ReadonlyField = null;
        $p.ConstantField = null;
    }).call($t, $t.FieldClass, $t.FieldClass.prototype);
    $WootzJs$Compiler$Tests$AssemblyTypes.push($t.FieldClass);
}).call(null, WootzJs.Compiler.Tests.Reflection.FieldInfoTests, WootzJs.Compiler.Tests.Reflection.FieldInfoTests.prototype);
$WootzJs$Compiler$Tests$AssemblyTypes.push(WootzJs.Compiler.Tests.Reflection.FieldInfoTests);
WootzJs.Compiler.Tests.Reflection.MethodInfoTests = $define("WootzJs.Compiler.Tests.Reflection.MethodInfoTests");
WootzJs.Compiler.Tests.Reflection.MethodInfoTests.prototype = new System.Object();
(WootzJs.Compiler.Tests.Reflection.MethodInfoTests.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
    $p.$type = WootzJs.Compiler.Tests.Reflection.MethodInfoTests;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Compiler.Tests.Reflection.MethodInfoTests";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("MethodInfoTests", [WootzJs.Compiler.Tests.TestFixtureAttribute.prototype.$ctor.$new()]);this.$type.Init("WootzJs.Compiler.Tests.Reflection.MethodInfoTests", WootzJs.Compiler.Tests.Reflection.MethodInfoTests, System.Object, [], [], [System.Reflection.MethodInfo.prototype.$ctor.$new("Name", WootzJs.Compiler.Tests.Reflection.MethodInfoTests.prototype.Name, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("InvokeInstanceMethod", WootzJs.Compiler.Tests.Reflection.MethodInfoTests.prototype.InvokeInstanceMethod, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.Reflection.MethodInfoTests.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
    $t.$StaticInitializer = function() {
    };
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.Name = function() {
        var methods = WootzJs.Compiler.Tests.Reflection.MethodInfoTests.MethodClass.$GetType().GetMethods();
        var method = System.Linq.Enumerable.Single$1(System.Reflection.MethodInfo, methods, $delegate(this, (System.Func$2$(System.Reflection.MethodInfo, System.Boolean)), function(x) {
            return x.get_Name() == "VoidMethod";
        }));
        QUnit.ok(true);
    };
    $p.InvokeInstanceMethod = function() {
        var methods = WootzJs.Compiler.Tests.Reflection.MethodInfoTests.MethodClass.$GetType().GetMethods();
        var method = System.Linq.Enumerable.Single$1(System.Reflection.MethodInfo, methods, $delegate(this, (System.Func$2$(System.Reflection.MethodInfo, System.Boolean)), function(x) {
            return x.get_Name() == "InstanceMethod";
        }));
        var instance = WootzJs.Compiler.Tests.Reflection.MethodInfoTests.MethodClass.prototype.$ctor.$new();
        var result = $cast(String, method.Invoke(instance, new Array(0)));
        QUnit.equal(result, "InstanceMethod");
    };
    function MethodClass($constructor) {
        if (!$t.MethodClass.$isStaticInitialized && ($constructor != null || !(this instanceof WootzJs.Compiler.Tests.Reflection.MethodInfoTests.MethodClass))) {
            $t.MethodClass.$isStaticInitialized = true;
            $t.MethodClass.$StaticInitializer();
        }
        if ($constructor != null)
            $constructor.apply(this, Array.prototype.slice.call(arguments, 1));
        if (!(this instanceof WootzJs.Compiler.Tests.Reflection.MethodInfoTests.MethodClass))
            return $t.MethodClass;
    }
    $t.MethodClass = MethodClass;
    $t.MethodClass.prototype = new System.Object();
    ($t.MethodClass.$TypeInitializer = function($t, $p) {
        $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
        $p.$type = WootzJs.Compiler.Tests.Reflection.MethodInfoTests.MethodClass;
        $t.$baseType = System.Object;
        $p.$typeName = "WootzJs.Compiler.Tests.Reflection.MethodInfoTests.MethodClass";
        $t.$typeName = $p.$typeName;
        $t.$GetType = function() {
            return System.Type._GetTypeFromTypeFunc(this);
        };
        $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("MethodClass", []);this.$type.Init("WootzJs.Compiler.Tests.Reflection.MethodInfoTests.MethodClass", WootzJs.Compiler.Tests.Reflection.MethodInfoTests.MethodClass, System.Object, [], [], [System.Reflection.MethodInfo.prototype.$ctor.$new("VoidMethod", WootzJs.Compiler.Tests.Reflection.MethodInfoTests.MethodClass.prototype.VoidMethod, [], System.Void, System.Reflection.MethodAttributes().Public, []), System.Reflection.MethodInfo.prototype.$ctor.$new("InstanceMethod", WootzJs.Compiler.Tests.Reflection.MethodInfoTests.MethodClass.prototype.InstanceMethod, [], String, System.Reflection.MethodAttributes().Public, []), System.Reflection.MethodInfo.prototype.$ctor.$new("StaticMethod", WootzJs.Compiler.Tests.Reflection.MethodInfoTests.MethodClass.prototype.StaticMethod, [], String, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, []), System.Reflection.MethodInfo.prototype.$ctor.$new("PrivateMethod", WootzJs.Compiler.Tests.Reflection.MethodInfoTests.MethodClass.prototype.PrivateMethod, [], String, System.Reflection.MethodAttributes().Private, []), System.Reflection.MethodInfo.prototype.$ctor.$new("InternalMethod", WootzJs.Compiler.Tests.Reflection.MethodInfoTests.MethodClass.prototype.InternalMethod, [], String, System.Reflection.MethodAttributes().Assembly, []), System.Reflection.MethodInfo.prototype.$ctor.$new("ProtectedMethod", WootzJs.Compiler.Tests.Reflection.MethodInfoTests.MethodClass.prototype.ProtectedMethod, [], String, System.Reflection.MethodAttributes().Family, [])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.Reflection.MethodInfoTests.MethodClass.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
        $t.$StaticInitializer = function() {
        };
        $p.$ctor = function() {
            System.Object.prototype.$ctor.call(this);
        };
        $p.$ctor.$type = $t;
        $p.$ctor.$new = function() {
            return new $p.$ctor.$type(this);
        };
        $p.VoidMethod = function() {
        };
        $p.InstanceMethod = function() {
            return "InstanceMethod";
        };
        $t.StaticMethod = function() {
            return "StaticMethod";
        };
        $p.PrivateMethod = function() {
            return "PrivateMethod";
        };
        $p.InternalMethod = function() {
            return "InternalMethod";
        };
        $p.ProtectedMethod = function() {
            return "ProtectedMethod";
        };
    }).call($t, $t.MethodClass, $t.MethodClass.prototype);
    $WootzJs$Compiler$Tests$AssemblyTypes.push($t.MethodClass);
}).call(null, WootzJs.Compiler.Tests.Reflection.MethodInfoTests, WootzJs.Compiler.Tests.Reflection.MethodInfoTests.prototype);
$WootzJs$Compiler$Tests$AssemblyTypes.push(WootzJs.Compiler.Tests.Reflection.MethodInfoTests);
WootzJs.Compiler.Tests.StringTests = $define("WootzJs.Compiler.Tests.StringTests");
WootzJs.Compiler.Tests.StringTests.prototype = new System.Object();
(WootzJs.Compiler.Tests.StringTests.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
    $p.$type = WootzJs.Compiler.Tests.StringTests;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Compiler.Tests.StringTests";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("StringTests", [WootzJs.Compiler.Tests.TestFixtureAttribute.prototype.$ctor.$new()]);this.$type.Init("WootzJs.Compiler.Tests.StringTests", WootzJs.Compiler.Tests.StringTests, System.Object, [], [], [System.Reflection.MethodInfo.prototype.$ctor.$new("ToUpper", WootzJs.Compiler.Tests.StringTests.prototype.ToUpper, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("ToLower", WootzJs.Compiler.Tests.StringTests.prototype.ToLower, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("Length", WootzJs.Compiler.Tests.StringTests.prototype.Length, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("EndsWith", WootzJs.Compiler.Tests.StringTests.prototype.EndsWith, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("StartsWith", WootzJs.Compiler.Tests.StringTests.prototype.StartsWith, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("Compare", WootzJs.Compiler.Tests.StringTests.prototype.Compare, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("IndexOf", WootzJs.Compiler.Tests.StringTests.prototype.IndexOf, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("LastIndexOf", WootzJs.Compiler.Tests.StringTests.prototype.LastIndexOf, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("Substring", WootzJs.Compiler.Tests.StringTests.prototype.Substring, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("SplitCharArray", WootzJs.Compiler.Tests.StringTests.prototype.SplitCharArray, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("SplitCharArrayWithCount", WootzJs.Compiler.Tests.StringTests.prototype.SplitCharArrayWithCount, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("CharCode", WootzJs.Compiler.Tests.StringTests.prototype.CharCode, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("PreIncrementCharacter", WootzJs.Compiler.Tests.StringTests.prototype.PreIncrementCharacter, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("PostIncrementCharacter", WootzJs.Compiler.Tests.StringTests.prototype.PostIncrementCharacter, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.StringTests.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
    $t.$StaticInitializer = function() {
    };
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.ToUpper = function() {
        var s = "foo";
        s = s.toUpperCase();
        QUnit.equal(s, "FOO");
    };
    $p.ToLower = function() {
        var s = "FOO";
        s = s.toLowerCase();
        QUnit.equal(s, "foo");
    };
    $p.Length = function() {
        var s = "FOO";
        var length = s.length;
        QUnit.equal(length, 3);
    };
    $p.EndsWith = function() {
        var s = "HelloWorld";
        QUnit.ok(String.prototype.EndsWith.call(s, "World"));
    };
    $p.StartsWith = function() {
        var s = "HelloWorld";
        QUnit.ok(String.prototype.StartsWith.call(s, "Hello"));
    };
    $p.Compare = function() {
        QUnit.equal(String.Compare("a", "b"), -1);
        QUnit.equal(String.Compare("b", "a"), 1);
        QUnit.equal(String.Compare("a", "a"), 0);
    };
    $p.IndexOf = function() {
        var s = "12341234";
        var two = "2";
        QUnit.equal(s.indexOf(two), 1);
        QUnit.equal(s.indexOf("2", 4), 5);
        QUnit.equal(s.indexOf("2"), 1);
        QUnit.equal(s.indexOf("2", 4), 5);
    };
    $p.LastIndexOf = function() {
        var s = "12341234";
        QUnit.equal(s.lastIndexOf("2"), 5);
        QUnit.equal(s.lastIndexOf("2", 4), 1);
        QUnit.equal(s.lastIndexOf("2"), 5);
        QUnit.equal(s.lastIndexOf("2", 4), 1);
    };
    $p.Substring = function() {
        var s = "12341234";
        QUnit.equal(String.prototype.Substring.call(s, 4, 2), "12");
        QUnit.equal(String.prototype.Substring.call(s, 6, 0), "34");
    };
    $p.SplitCharArray = function() {
        var s = "12a34b56c78";
        var parts = String.prototype.Split.call(s, ["a", "b", "c"]);
        QUnit.equal(parts.length, 4);
        QUnit.equal(parts[0], "12");
        QUnit.equal(parts[1], "34");
        QUnit.equal(parts[2], "56");
        QUnit.equal(parts[3], "78");
    };
    $p.SplitCharArrayWithCount = function() {
        var s = "12a34b56c78";
        var parts = String.prototype.Split$2.call(s, System.Object.$$InitializeArray(["a", "b", "c"], System.Char), 3);
        QUnit.equal(parts.length, 3);
        QUnit.equal(parts[0], "12");
        QUnit.equal(parts[1], "34");
        QUnit.equal(parts[2], "56");
    };
    $p.CharCode = function() {
        var b = "b";
        var a = "a";
        var i = b.charCodeAt(0) - a.charCodeAt(0);
        QUnit.equal(i, 1);
    };
    $p.PreIncrementCharacter = function() {
        var b = "b";
        var c = b = String.fromCharCode(b.charCodeAt(0) + 1);
        QUnit.equal(b, "c");
        QUnit.equal(c, "c");
    };
    $p.PostIncrementCharacter = function() {
        var b = "b";
        var stillB = (function() {
            var $old = b;
            b = String.fromCharCode($old.charCodeAt(0) + 1);
            return $old;
        }).call(this);
        QUnit.equal(b, "c");
        QUnit.equal(stillB, "b");
    };
}).call(null, WootzJs.Compiler.Tests.StringTests, WootzJs.Compiler.Tests.StringTests.prototype);
$WootzJs$Compiler$Tests$AssemblyTypes.push(WootzJs.Compiler.Tests.StringTests);
WootzJs.Compiler.Tests.TestsApplication = $define("WootzJs.Compiler.Tests.TestsApplication");
WootzJs.Compiler.Tests.TestsApplication.prototype = new System.Object();
(WootzJs.Compiler.Tests.TestsApplication.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
    $p.$type = WootzJs.Compiler.Tests.TestsApplication;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Compiler.Tests.TestsApplication";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("TestsApplication", []);this.$type.Init("WootzJs.Compiler.Tests.TestsApplication", WootzJs.Compiler.Tests.TestsApplication, System.Object, [], [], [System.Reflection.MethodInfo.prototype.$ctor.$new("Main", WootzJs.Compiler.Tests.TestsApplication.prototype.Main, [], System.Void, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, [])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.TestsApplication.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
    $t.$StaticInitializer = function() {
    };
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $t.Main = function() {
        System.Console.WriteLine$1("Entry points be working!");
        var assembly = WootzJs.Compiler.Tests.TestsApplication.$GetType().get_Assembly();
        System.Console.WriteLine$1(assembly.get_FullName());
        {
            var $anon$1iterator = assembly.GetTypes();
            var $anon$2enumerator = $anon$1iterator.System$Collections$IEnumerable$GetEnumerator();
            while ($anon$2enumerator.System$Collections$IEnumerator$MoveNext())
                (function() {
                    var type = $anon$2enumerator.get_Current();
                    if (System.Linq.Enumerable.Any(System.Object, type.GetCustomAttributes$1(WootzJs.Compiler.Tests.TestFixtureAttribute.$GetType(), false))) {
                        System.Console.WriteLine$1(type.get_FullName());
                        {
                            var $anon$3iterator = type.GetMethods();
                            var $anon$4enumerator = $anon$3iterator.System$Collections$IEnumerable$GetEnumerator();
                            while ($anon$4enumerator.System$Collections$IEnumerator$MoveNext())
                                (function() {
                                    var currentMethod = $anon$4enumerator.get_Current();
                                    if (System.Linq.Enumerable.Any(System.Object, currentMethod.GetCustomAttributes$1(WootzJs.Compiler.Tests.TestAttribute.$GetType(), false))) {
                                        System.Console.WriteLine$1(currentMethod.get_Name());
                                        var instance = type.GetConstructors()[0].Invoke$2(new Array(0));
                                        QUnit.test(type.get_FullName() + "." + currentMethod.get_Name(), $delegate(this, System.Action, function() {
                                            return currentMethod.Invoke(instance, new Array(0));
                                        }));
                                    }
                                }).call(this);
                        }
                    }
                }).call(this);
        }
    };
}).call(null, WootzJs.Compiler.Tests.TestsApplication, WootzJs.Compiler.Tests.TestsApplication.prototype);
$WootzJs$Compiler$Tests$AssemblyTypes.push(WootzJs.Compiler.Tests.TestsApplication);
WootzJs.Compiler.Tests.Text.StringBuilderTests = $define("WootzJs.Compiler.Tests.Text.StringBuilderTests");
WootzJs.Compiler.Tests.Text.StringBuilderTests.prototype = new System.Object();
(WootzJs.Compiler.Tests.Text.StringBuilderTests.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
    $p.$type = WootzJs.Compiler.Tests.Text.StringBuilderTests;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Compiler.Tests.Text.StringBuilderTests";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("StringBuilderTests", [WootzJs.Compiler.Tests.TestFixtureAttribute.prototype.$ctor.$new()]);this.$type.Init("WootzJs.Compiler.Tests.Text.StringBuilderTests", WootzJs.Compiler.Tests.Text.StringBuilderTests, System.Object, [], [], [System.Reflection.MethodInfo.prototype.$ctor.$new("Append", WootzJs.Compiler.Tests.Text.StringBuilderTests.prototype.Append, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.Text.StringBuilderTests.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
    $t.$StaticInitializer = function() {
    };
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.Append = function() {
        var builder = System.Text.StringBuilder.prototype.$ctor.$new();
        builder.Append("a");
        builder.Append$2("b");
        builder.AppendLine();
        builder.AppendLine$1("c");
        builder.AppendLine$2("d");
        QUnit.equal(builder.ToString(), "ab\nc\nd\n");
    };
}).call(null, WootzJs.Compiler.Tests.Text.StringBuilderTests, WootzJs.Compiler.Tests.Text.StringBuilderTests.prototype);
$WootzJs$Compiler$Tests$AssemblyTypes.push(WootzJs.Compiler.Tests.Text.StringBuilderTests);
WootzJs.Compiler.Tests.TryTests = $define("WootzJs.Compiler.Tests.TryTests");
WootzJs.Compiler.Tests.TryTests.prototype = new System.Object();
(WootzJs.Compiler.Tests.TryTests.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
    $p.$type = WootzJs.Compiler.Tests.TryTests;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Compiler.Tests.TryTests";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("TryTests", [WootzJs.Compiler.Tests.TestFixtureAttribute.prototype.$ctor.$new()]);this.$type.Init("WootzJs.Compiler.Tests.TryTests", WootzJs.Compiler.Tests.TryTests, System.Object, [], [], [System.Reflection.MethodInfo.prototype.$ctor.$new("ExceptionCaught", WootzJs.Compiler.Tests.TryTests.prototype.ExceptionCaught, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("FinallyExecuted", WootzJs.Compiler.Tests.TryTests.prototype.FinallyExecuted, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("NakedCatchClause", WootzJs.Compiler.Tests.TryTests.prototype.NakedCatchClause, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.TryTests.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
    $t.$StaticInitializer = function() {
    };
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.ExceptionCaught = function() {
        try {
            throw System.Exception.prototype.$ctor.$new().InternalInit(new Error());
            QUnit.ok(false);
        }
        catch (e) {
            QUnit.ok(true);
        }
    };
    $p.FinallyExecuted = function() {
        var success = false;
        try {
            try {
                throw System.Exception.prototype.$ctor.$new().InternalInit(new Error());
            }
            finally {
                success = true;
            }
        }
        catch (e) {
        }
        QUnit.ok(success);
    };
    $p.NakedCatchClause = function() {
        try {
            throw System.Exception.prototype.$ctor.$new().InternalInit(new Error());
            QUnit.ok(false);
        }
        catch ($exception) {
            QUnit.ok(true);
        }
    };
}).call(null, WootzJs.Compiler.Tests.TryTests, WootzJs.Compiler.Tests.TryTests.prototype);
$WootzJs$Compiler$Tests$AssemblyTypes.push(WootzJs.Compiler.Tests.TryTests);
WootzJs.Compiler.Tests.TypeOfExpressionTests = $define("WootzJs.Compiler.Tests.TypeOfExpressionTests");
WootzJs.Compiler.Tests.TypeOfExpressionTests.prototype = new System.Object();
(WootzJs.Compiler.Tests.TypeOfExpressionTests.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
    $p.$type = WootzJs.Compiler.Tests.TypeOfExpressionTests;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Compiler.Tests.TypeOfExpressionTests";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("TypeOfExpressionTests", [WootzJs.Compiler.Tests.TestFixtureAttribute.prototype.$ctor.$new()]);this.$type.Init("WootzJs.Compiler.Tests.TypeOfExpressionTests", WootzJs.Compiler.Tests.TypeOfExpressionTests, System.Object, [], [], [System.Reflection.MethodInfo.prototype.$ctor.$new("TypeOfReturnsName", WootzJs.Compiler.Tests.TypeOfExpressionTests.prototype.TypeOfReturnsName, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.TypeOfExpressionTests.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
    $t.$StaticInitializer = function() {
    };
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.TypeOfReturnsName = function() {
        var type = WootzJs.Compiler.Tests.TypeOfExpressionTests.TestClass.$GetType();
        var name = type.get_Name();
        QUnit.equal(name, "TestClass");
    };
    function TestClass($constructor) {
        if (!$t.TestClass.$isStaticInitialized && ($constructor != null || !(this instanceof WootzJs.Compiler.Tests.TypeOfExpressionTests.TestClass))) {
            $t.TestClass.$isStaticInitialized = true;
            $t.TestClass.$StaticInitializer();
        }
        if ($constructor != null)
            $constructor.apply(this, Array.prototype.slice.call(arguments, 1));
        if (!(this instanceof WootzJs.Compiler.Tests.TypeOfExpressionTests.TestClass))
            return $t.TestClass;
    }
    $t.TestClass = TestClass;
    $t.TestClass.prototype = new System.Object();
    ($t.TestClass.$TypeInitializer = function($t, $p) {
        $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
        $p.$type = WootzJs.Compiler.Tests.TypeOfExpressionTests.TestClass;
        $t.$baseType = System.Object;
        $p.$typeName = "WootzJs.Compiler.Tests.TypeOfExpressionTests.TestClass";
        $t.$typeName = $p.$typeName;
        $t.$GetType = function() {
            return System.Type._GetTypeFromTypeFunc(this);
        };
        $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("TestClass", []);this.$type.Init("WootzJs.Compiler.Tests.TypeOfExpressionTests.TestClass", WootzJs.Compiler.Tests.TypeOfExpressionTests.TestClass, System.Object, [], [], [], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.TypeOfExpressionTests.TestClass.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
        $t.$StaticInitializer = function() {
        };
        $p.$ctor = function() {
            System.Object.prototype.$ctor.call(this);
        };
        $p.$ctor.$type = $t;
        $p.$ctor.$new = function() {
            return new $p.$ctor.$type(this);
        };
    }).call($t, $t.TestClass, $t.TestClass.prototype);
    $WootzJs$Compiler$Tests$AssemblyTypes.push($t.TestClass);
}).call(null, WootzJs.Compiler.Tests.TypeOfExpressionTests, WootzJs.Compiler.Tests.TypeOfExpressionTests.prototype);
$WootzJs$Compiler$Tests$AssemblyTypes.push(WootzJs.Compiler.Tests.TypeOfExpressionTests);
WootzJs.Compiler.Tests.TypeTests = $define("WootzJs.Compiler.Tests.TypeTests");
WootzJs.Compiler.Tests.TypeTests.prototype = new System.Object();
(WootzJs.Compiler.Tests.TypeTests.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
    $p.$type = WootzJs.Compiler.Tests.TypeTests;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Compiler.Tests.TypeTests";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("TypeTests", [WootzJs.Compiler.Tests.TestFixtureAttribute.prototype.$ctor.$new()]);this.$type.Init("WootzJs.Compiler.Tests.TypeTests", WootzJs.Compiler.Tests.TypeTests, System.Object, [], [], [System.Reflection.MethodInfo.prototype.$ctor.$new("FullName", WootzJs.Compiler.Tests.TypeTests.prototype.FullName, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("InnerClassName", WootzJs.Compiler.Tests.TypeTests.prototype.InnerClassName, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("BaseType", WootzJs.Compiler.Tests.TypeTests.prototype.BaseType, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("IsAssignableFrom", WootzJs.Compiler.Tests.TypeTests.prototype.IsAssignableFrom, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("IsInstanceOfType", WootzJs.Compiler.Tests.TypeTests.prototype.IsInstanceOfType, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("GetFields", WootzJs.Compiler.Tests.TypeTests.prototype.GetFields, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("GetTypeByName", WootzJs.Compiler.Tests.TypeTests.prototype.GetTypeByName, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.TypeTests.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
    $t.$StaticInitializer = function() {
    };
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.FullName = function() {
        var type = WootzJs.Compiler.Tests.TypeTests.TestClass.$GetType();
        QUnit.equal(type.get_FullName(), "WootzJs.Compiler.Tests.TypeTests.TestClass");
    };
    $p.InnerClassName = function() {
        var type = WootzJs.Compiler.Tests.TypeTests.ClassWithInnerClass.InnerClass.$GetType();
        QUnit.equal(type.get_Name(), "InnerClass");
    };
    $p.BaseType = function() {
        var type = WootzJs.Compiler.Tests.TypeTests.SubClass.$GetType();
        QUnit.equal(type.get_FullName(), "WootzJs.Compiler.Tests.TypeTests.SubClass");
        QUnit.equal(type.get_BaseType().get_FullName(), "WootzJs.Compiler.Tests.TypeTests.TestClass");
    };
    $p.IsAssignableFrom = function() {
        var subClass = WootzJs.Compiler.Tests.TypeTests.SubClass.$GetType();
        var baseClass = WootzJs.Compiler.Tests.TypeTests.TestClass.$GetType();
        QUnit.ok(baseClass.IsAssignableFrom(subClass));
    };
    $p.IsInstanceOfType = function() {
        var subClass = WootzJs.Compiler.Tests.TypeTests.SubClass.prototype.$ctor.$new();
        var baseClass = WootzJs.Compiler.Tests.TypeTests.TestClass.$GetType();
        QUnit.ok(baseClass.IsInstanceOfType(subClass));
    };
    $p.GetFields = function() {
        var fields = WootzJs.Compiler.Tests.TypeTests.FieldsClass.$GetType().GetFields();
        QUnit.equal(fields.length, 1);
        var field = fields[0];
        QUnit.equal(field.get_Name(), "MyString");
    };
    $p.GetTypeByName = function() {
        var type = System.Type.GetType$1("WootzJs.Compiler.Tests.TypeTests.TestClass");
        QUnit.ok(type != null);
    };
    function TestClass($constructor) {
        if (!$t.TestClass.$isStaticInitialized && ($constructor != null || !(this instanceof WootzJs.Compiler.Tests.TypeTests.TestClass))) {
            $t.TestClass.$isStaticInitialized = true;
            $t.TestClass.$StaticInitializer();
        }
        if ($constructor != null)
            $constructor.apply(this, Array.prototype.slice.call(arguments, 1));
        if (!(this instanceof WootzJs.Compiler.Tests.TypeTests.TestClass))
            return $t.TestClass;
    }
    $t.TestClass = TestClass;
    $t.TestClass.prototype = new System.Object();
    ($t.TestClass.$TypeInitializer = function($t, $p) {
        $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
        $p.$type = WootzJs.Compiler.Tests.TypeTests.TestClass;
        $t.$baseType = System.Object;
        $p.$typeName = "WootzJs.Compiler.Tests.TypeTests.TestClass";
        $t.$typeName = $p.$typeName;
        $t.$GetType = function() {
            return System.Type._GetTypeFromTypeFunc(this);
        };
        $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("TestClass", []);this.$type.Init("WootzJs.Compiler.Tests.TypeTests.TestClass", WootzJs.Compiler.Tests.TypeTests.TestClass, System.Object, [], [], [], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.TypeTests.TestClass.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
        $t.$StaticInitializer = function() {
        };
        $p.$ctor = function() {
            System.Object.prototype.$ctor.call(this);
        };
        $p.$ctor.$type = $t;
        $p.$ctor.$new = function() {
            return new $p.$ctor.$type(this);
        };
    }).call($t, $t.TestClass, $t.TestClass.prototype);
    $WootzJs$Compiler$Tests$AssemblyTypes.push($t.TestClass);
    function SubClass($constructor) {
        if (!$t.SubClass.$isStaticInitialized && ($constructor != null || !(this instanceof WootzJs.Compiler.Tests.TypeTests.SubClass))) {
            $t.SubClass.$isStaticInitialized = true;
            $t.SubClass.$StaticInitializer();
        }
        if ($constructor != null)
            $constructor.apply(this, Array.prototype.slice.call(arguments, 1));
        if (!(this instanceof WootzJs.Compiler.Tests.TypeTests.SubClass))
            return $t.SubClass;
    }
    $t.SubClass = SubClass;
    $t.SubClass.prototype = new WootzJs.Compiler.Tests.TypeTests.TestClass();
    ($t.SubClass.$TypeInitializer = function($t, $p) {
        $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
        $p.$type = WootzJs.Compiler.Tests.TypeTests.SubClass;
        $t.$baseType = WootzJs.Compiler.Tests.TypeTests.TestClass;
        $p.$typeName = "WootzJs.Compiler.Tests.TypeTests.SubClass";
        $t.$typeName = $p.$typeName;
        $t.$GetType = function() {
            return System.Type._GetTypeFromTypeFunc(this);
        };
        $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("SubClass", []);this.$type.Init("WootzJs.Compiler.Tests.TypeTests.SubClass", WootzJs.Compiler.Tests.TypeTests.SubClass, WootzJs.Compiler.Tests.TypeTests.TestClass, [], [], [], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.TypeTests.SubClass.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
        $t.$StaticInitializer = function() {
        };
        $p.$ctor = function() {
            WootzJs.Compiler.Tests.TypeTests.TestClass.prototype.$ctor.call(this);
        };
        $p.$ctor.$type = $t;
        $p.$ctor.$new = function() {
            return new $p.$ctor.$type(this);
        };
    }).call($t, $t.SubClass, $t.SubClass.prototype);
    $WootzJs$Compiler$Tests$AssemblyTypes.push($t.SubClass);
    function FieldsClass($constructor) {
        if (!$t.FieldsClass.$isStaticInitialized && ($constructor != null || !(this instanceof WootzJs.Compiler.Tests.TypeTests.FieldsClass))) {
            $t.FieldsClass.$isStaticInitialized = true;
            $t.FieldsClass.$StaticInitializer();
        }
        if ($constructor != null)
            $constructor.apply(this, Array.prototype.slice.call(arguments, 1));
        if (!(this instanceof WootzJs.Compiler.Tests.TypeTests.FieldsClass))
            return $t.FieldsClass;
    }
    $t.FieldsClass = FieldsClass;
    $t.FieldsClass.prototype = new System.Object();
    ($t.FieldsClass.$TypeInitializer = function($t, $p) {
        $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
        $p.$type = WootzJs.Compiler.Tests.TypeTests.FieldsClass;
        $t.$baseType = System.Object;
        $p.$typeName = "WootzJs.Compiler.Tests.TypeTests.FieldsClass";
        $t.$typeName = $p.$typeName;
        $t.$GetType = function() {
            return System.Type._GetTypeFromTypeFunc(this);
        };
        $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("FieldsClass", []);this.$type.Init("WootzJs.Compiler.Tests.TypeTests.FieldsClass", WootzJs.Compiler.Tests.TypeTests.FieldsClass, System.Object, [], [System.Reflection.FieldInfo.prototype.$ctor.$new("MyString", String, System.Reflection.FieldAttributes().Public, null, [])], [], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.TypeTests.FieldsClass.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
        $t.$StaticInitializer = function() {
        };
        $p.$ctor = function() {
            System.Object.prototype.$ctor.call(this);
        };
        $p.$ctor.$type = $t;
        $p.$ctor.$new = function() {
            return new $p.$ctor.$type(this);
        };
        $p.MyString = null;
    }).call($t, $t.FieldsClass, $t.FieldsClass.prototype);
    $WootzJs$Compiler$Tests$AssemblyTypes.push($t.FieldsClass);
    function ClassWithInnerClass($constructor) {
        if (!$t.ClassWithInnerClass.$isStaticInitialized && ($constructor != null || !(this instanceof WootzJs.Compiler.Tests.TypeTests.ClassWithInnerClass))) {
            $t.ClassWithInnerClass.$isStaticInitialized = true;
            $t.ClassWithInnerClass.$StaticInitializer();
        }
        if ($constructor != null)
            $constructor.apply(this, Array.prototype.slice.call(arguments, 1));
        if (!(this instanceof WootzJs.Compiler.Tests.TypeTests.ClassWithInnerClass))
            return $t.ClassWithInnerClass;
    }
    $t.ClassWithInnerClass = ClassWithInnerClass;
    $t.ClassWithInnerClass.prototype = new System.Object();
    ($t.ClassWithInnerClass.$TypeInitializer = function($t, $p) {
        $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
        $p.$type = WootzJs.Compiler.Tests.TypeTests.ClassWithInnerClass;
        $t.$baseType = System.Object;
        $p.$typeName = "WootzJs.Compiler.Tests.TypeTests.ClassWithInnerClass";
        $t.$typeName = $p.$typeName;
        $t.$GetType = function() {
            return System.Type._GetTypeFromTypeFunc(this);
        };
        $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("ClassWithInnerClass", []);this.$type.Init("WootzJs.Compiler.Tests.TypeTests.ClassWithInnerClass", WootzJs.Compiler.Tests.TypeTests.ClassWithInnerClass, System.Object, [], [], [], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.TypeTests.ClassWithInnerClass.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
        $t.$StaticInitializer = function() {
        };
        $p.$ctor = function() {
            System.Object.prototype.$ctor.call(this);
        };
        $p.$ctor.$type = $t;
        $p.$ctor.$new = function() {
            return new $p.$ctor.$type(this);
        };
        function InnerClass($constructor) {
            if (!$t.InnerClass.$isStaticInitialized && ($constructor != null || !(this instanceof WootzJs.Compiler.Tests.TypeTests.ClassWithInnerClass.InnerClass))) {
                $t.InnerClass.$isStaticInitialized = true;
                $t.InnerClass.$StaticInitializer();
            }
            if ($constructor != null)
                $constructor.apply(this, Array.prototype.slice.call(arguments, 1));
            if (!(this instanceof WootzJs.Compiler.Tests.TypeTests.ClassWithInnerClass.InnerClass))
                return $t.InnerClass;
        }
        $t.InnerClass = InnerClass;
        $t.InnerClass.prototype = new System.Object();
        ($t.InnerClass.$TypeInitializer = function($t, $p) {
            $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
            $p.$type = WootzJs.Compiler.Tests.TypeTests.ClassWithInnerClass.InnerClass;
            $t.$baseType = System.Object;
            $p.$typeName = "WootzJs.Compiler.Tests.TypeTests.ClassWithInnerClass.InnerClass";
            $t.$typeName = $p.$typeName;
            $t.$GetType = function() {
                return System.Type._GetTypeFromTypeFunc(this);
            };
            $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("InnerClass", []);this.$type.Init("WootzJs.Compiler.Tests.TypeTests.ClassWithInnerClass.InnerClass", WootzJs.Compiler.Tests.TypeTests.ClassWithInnerClass.InnerClass, System.Object, [], [], [], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.TypeTests.ClassWithInnerClass.InnerClass.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
            $t.$StaticInitializer = function() {
            };
            $p.$ctor = function() {
                System.Object.prototype.$ctor.call(this);
            };
            $p.$ctor.$type = $t;
            $p.$ctor.$new = function() {
                return new $p.$ctor.$type(this);
            };
        }).call($t, $t.InnerClass, $t.InnerClass.prototype);
        $WootzJs$Compiler$Tests$AssemblyTypes.push($t.InnerClass);
    }).call($t, $t.ClassWithInnerClass, $t.ClassWithInnerClass.prototype);
    $WootzJs$Compiler$Tests$AssemblyTypes.push($t.ClassWithInnerClass);
}).call(null, WootzJs.Compiler.Tests.TypeTests, WootzJs.Compiler.Tests.TypeTests.prototype);
$WootzJs$Compiler$Tests$AssemblyTypes.push(WootzJs.Compiler.Tests.TypeTests);
WootzJs.Compiler.Tests.ConversionOperatorTests = $define("WootzJs.Compiler.Tests.ConversionOperatorTests");
WootzJs.Compiler.Tests.ConversionOperatorTests.prototype = new System.Object();
(WootzJs.Compiler.Tests.ConversionOperatorTests.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
    $p.$type = WootzJs.Compiler.Tests.ConversionOperatorTests;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Compiler.Tests.ConversionOperatorTests";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("ConversionOperatorTests", [WootzJs.Compiler.Tests.TestFixtureAttribute.prototype.$ctor.$new()]);this.$type.Init("WootzJs.Compiler.Tests.ConversionOperatorTests", WootzJs.Compiler.Tests.ConversionOperatorTests, System.Object, [], [], [System.Reflection.MethodInfo.prototype.$ctor.$new("Implicit", WootzJs.Compiler.Tests.ConversionOperatorTests.prototype.Implicit, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("Explicit", WootzJs.Compiler.Tests.ConversionOperatorTests.prototype.Explicit, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.ConversionOperatorTests.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
    $t.$StaticInitializer = function() {
    };
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.Implicit = function() {
        var o = WootzJs.Compiler.Tests.ConversionOperatorTests.ImplicitClass.op_Implicit("foo");
        QUnit.equal(o.get_Value(), "foofoo");
    };
    $p.Explicit = function() {
        var o = WootzJs.Compiler.Tests.ConversionOperatorTests.ExplicitClass.op_Explicit("foo");
        QUnit.equal(o.get_Value(), "foofoo");
    };
    function ImplicitClass($constructor) {
        if (!$t.ImplicitClass.$isStaticInitialized && ($constructor != null || !(this instanceof WootzJs.Compiler.Tests.ConversionOperatorTests.ImplicitClass))) {
            $t.ImplicitClass.$isStaticInitialized = true;
            $t.ImplicitClass.$StaticInitializer();
        }
        if ($constructor != null)
            $constructor.apply(this, Array.prototype.slice.call(arguments, 1));
        if (!(this instanceof WootzJs.Compiler.Tests.ConversionOperatorTests.ImplicitClass))
            return $t.ImplicitClass;
    }
    $t.ImplicitClass = ImplicitClass;
    $t.ImplicitClass.prototype = new System.Object();
    ($t.ImplicitClass.$TypeInitializer = function($t, $p) {
        $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
        $p.$type = WootzJs.Compiler.Tests.ConversionOperatorTests.ImplicitClass;
        $t.$baseType = System.Object;
        $p.$typeName = "WootzJs.Compiler.Tests.ConversionOperatorTests.ImplicitClass";
        $t.$typeName = $p.$typeName;
        $t.$GetType = function() {
            return System.Type._GetTypeFromTypeFunc(this);
        };
        $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("ImplicitClass", []);this.$type.Init("WootzJs.Compiler.Tests.ConversionOperatorTests.ImplicitClass", WootzJs.Compiler.Tests.ConversionOperatorTests.ImplicitClass, System.Object, [], [System.Reflection.FieldInfo.prototype.$ctor.$new("$Value$k__BackingField", String, System.Reflection.FieldAttributes().Private, null, [])], [System.Reflection.MethodInfo.prototype.$ctor.$new("get_Value", WootzJs.Compiler.Tests.ConversionOperatorTests.ImplicitClass.prototype.get_Value, [], String, System.Reflection.MethodAttributes().Public, []), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Value", WootzJs.Compiler.Tests.ConversionOperatorTests.ImplicitClass.prototype.set_Value, [System.Reflection.ParameterInfo.prototype.$ctor.$new("value", String, 0, 0, null, [])], System.Void, System.Reflection.MethodAttributes().Private, []), System.Reflection.MethodInfo.prototype.$ctor.$new("op_Implicit", WootzJs.Compiler.Tests.ConversionOperatorTests.ImplicitClass.prototype.op_Implicit, [System.Reflection.ParameterInfo.prototype.$ctor.$new("s", String, 0, 0, null, [])], WootzJs.Compiler.Tests.ConversionOperatorTests.ImplicitClass, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, [])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.ConversionOperatorTests.ImplicitClass.prototype.$ctor, [System.Reflection.ParameterInfo.prototype.$ctor.$new("value", String, 0, 0, null, [])], System.Reflection.MethodAttributes().Public, [])], [System.Reflection.PropertyInfo.prototype.$ctor.$new("Value", String, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Value", WootzJs.Compiler.Tests.ConversionOperatorTests.ImplicitClass.prototype.get_Value, [], String, System.Reflection.MethodAttributes().Public, []), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Value", WootzJs.Compiler.Tests.ConversionOperatorTests.ImplicitClass.prototype.set_Value, [System.Reflection.ParameterInfo.prototype.$ctor.$new("value", String, 0, 0, null, [])], System.Void, System.Reflection.MethodAttributes().Private, []), [], [])], [], false);return this.$type;};
        $t.$StaticInitializer = function() {
        };
        $p.$Value$k__BackingField = null;
        $p.get_Value = function() {
            return this.$Value$k__BackingField;
        };
        $p.set_Value = function(value) {
            this.$Value$k__BackingField = value;
        };
        $p.$ctor = function(value) {
            System.Object.prototype.$ctor.call(this);
            this.set_Value(value);
        };
        $p.$ctor.$type = $t;
        $p.$ctor.$new = function(value) {
            return new $p.$ctor.$type(this, value);
        };
        $t.op_Implicit = function(s) {
            return WootzJs.Compiler.Tests.ConversionOperatorTests.ImplicitClass.prototype.$ctor.$new(s + s);
        };
    }).call($t, $t.ImplicitClass, $t.ImplicitClass.prototype);
    $WootzJs$Compiler$Tests$AssemblyTypes.push($t.ImplicitClass);
    function ExplicitClass($constructor) {
        if (!$t.ExplicitClass.$isStaticInitialized && ($constructor != null || !(this instanceof WootzJs.Compiler.Tests.ConversionOperatorTests.ExplicitClass))) {
            $t.ExplicitClass.$isStaticInitialized = true;
            $t.ExplicitClass.$StaticInitializer();
        }
        if ($constructor != null)
            $constructor.apply(this, Array.prototype.slice.call(arguments, 1));
        if (!(this instanceof WootzJs.Compiler.Tests.ConversionOperatorTests.ExplicitClass))
            return $t.ExplicitClass;
    }
    $t.ExplicitClass = ExplicitClass;
    $t.ExplicitClass.prototype = new System.Object();
    ($t.ExplicitClass.$TypeInitializer = function($t, $p) {
        $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
        $p.$type = WootzJs.Compiler.Tests.ConversionOperatorTests.ExplicitClass;
        $t.$baseType = System.Object;
        $p.$typeName = "WootzJs.Compiler.Tests.ConversionOperatorTests.ExplicitClass";
        $t.$typeName = $p.$typeName;
        $t.$GetType = function() {
            return System.Type._GetTypeFromTypeFunc(this);
        };
        $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("ExplicitClass", []);this.$type.Init("WootzJs.Compiler.Tests.ConversionOperatorTests.ExplicitClass", WootzJs.Compiler.Tests.ConversionOperatorTests.ExplicitClass, System.Object, [], [System.Reflection.FieldInfo.prototype.$ctor.$new("$Value$k__BackingField", String, System.Reflection.FieldAttributes().Private, null, [])], [System.Reflection.MethodInfo.prototype.$ctor.$new("get_Value", WootzJs.Compiler.Tests.ConversionOperatorTests.ExplicitClass.prototype.get_Value, [], String, System.Reflection.MethodAttributes().Public, []), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Value", WootzJs.Compiler.Tests.ConversionOperatorTests.ExplicitClass.prototype.set_Value, [System.Reflection.ParameterInfo.prototype.$ctor.$new("value", String, 0, 0, null, [])], System.Void, System.Reflection.MethodAttributes().Private, []), System.Reflection.MethodInfo.prototype.$ctor.$new("op_Explicit", WootzJs.Compiler.Tests.ConversionOperatorTests.ExplicitClass.prototype.op_Explicit, [System.Reflection.ParameterInfo.prototype.$ctor.$new("s", String, 0, 0, null, [])], WootzJs.Compiler.Tests.ConversionOperatorTests.ExplicitClass, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, [])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.ConversionOperatorTests.ExplicitClass.prototype.$ctor, [System.Reflection.ParameterInfo.prototype.$ctor.$new("value", String, 0, 0, null, [])], System.Reflection.MethodAttributes().Public, [])], [System.Reflection.PropertyInfo.prototype.$ctor.$new("Value", String, System.Reflection.MethodInfo.prototype.$ctor.$new("get_Value", WootzJs.Compiler.Tests.ConversionOperatorTests.ExplicitClass.prototype.get_Value, [], String, System.Reflection.MethodAttributes().Public, []), System.Reflection.MethodInfo.prototype.$ctor.$new("set_Value", WootzJs.Compiler.Tests.ConversionOperatorTests.ExplicitClass.prototype.set_Value, [System.Reflection.ParameterInfo.prototype.$ctor.$new("value", String, 0, 0, null, [])], System.Void, System.Reflection.MethodAttributes().Private, []), [], [])], [], false);return this.$type;};
        $t.$StaticInitializer = function() {
        };
        $p.$Value$k__BackingField = null;
        $p.get_Value = function() {
            return this.$Value$k__BackingField;
        };
        $p.set_Value = function(value) {
            this.$Value$k__BackingField = value;
        };
        $p.$ctor = function(value) {
            System.Object.prototype.$ctor.call(this);
            this.set_Value(value);
        };
        $p.$ctor.$type = $t;
        $p.$ctor.$new = function(value) {
            return new $p.$ctor.$type(this, value);
        };
        $t.op_Explicit = function(s) {
            return WootzJs.Compiler.Tests.ConversionOperatorTests.ExplicitClass.prototype.$ctor.$new(s + s);
        };
    }).call($t, $t.ExplicitClass, $t.ExplicitClass.prototype);
    $WootzJs$Compiler$Tests$AssemblyTypes.push($t.ExplicitClass);
}).call(null, WootzJs.Compiler.Tests.ConversionOperatorTests, WootzJs.Compiler.Tests.ConversionOperatorTests.prototype);
$WootzJs$Compiler$Tests$AssemblyTypes.push(WootzJs.Compiler.Tests.ConversionOperatorTests);
WootzJs.Compiler.Tests.UsingStatementTests = $define("WootzJs.Compiler.Tests.UsingStatementTests");
WootzJs.Compiler.Tests.UsingStatementTests.prototype = new System.Object();
(WootzJs.Compiler.Tests.UsingStatementTests.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
    $p.$type = WootzJs.Compiler.Tests.UsingStatementTests;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Compiler.Tests.UsingStatementTests";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("UsingStatementTests", [WootzJs.Compiler.Tests.TestFixtureAttribute.prototype.$ctor.$new()]);this.$type.Init("WootzJs.Compiler.Tests.UsingStatementTests", WootzJs.Compiler.Tests.UsingStatementTests, System.Object, [], [], [System.Reflection.MethodInfo.prototype.$ctor.$new("SimpleUsing", WootzJs.Compiler.Tests.UsingStatementTests.prototype.SimpleUsing, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("Declaration", WootzJs.Compiler.Tests.UsingStatementTests.prototype.Declaration, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.UsingStatementTests.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
    $t.$StaticInitializer = function() {
    };
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.SimpleUsing = function() {
        var foo = WootzJs.Compiler.Tests.UsingStatementTests.Foo.prototype.$ctor.$new();
        var $anon$1 = foo;
        try {
        }
        finally {
            $anon$1.System$IDisposable$Dispose();
        }

        QUnit.ok(foo.IsDisposed);
    };
    $p.Declaration = function() {
        var _foo;
        var foo = WootzJs.Compiler.Tests.UsingStatementTests.Foo.prototype.$ctor.$new();
        try {
            _foo = foo;
        }
        finally {
            foo.System$IDisposable$Dispose();
        }

        QUnit.ok(_foo.IsDisposed);
    };
    function Foo($constructor) {
        if (!$t.Foo.$isStaticInitialized && ($constructor != null || !(this instanceof WootzJs.Compiler.Tests.UsingStatementTests.Foo))) {
            $t.Foo.$isStaticInitialized = true;
            $t.Foo.$StaticInitializer();
        }
        if ($constructor != null)
            $constructor.apply(this, Array.prototype.slice.call(arguments, 1));
        if (!(this instanceof WootzJs.Compiler.Tests.UsingStatementTests.Foo))
            return $t.Foo;
    }
    $t.Foo = Foo;
    $t.Foo.prototype = new System.Object();
    ($t.Foo.$TypeInitializer = function($t, $p) {
        $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
        $p.$type = WootzJs.Compiler.Tests.UsingStatementTests.Foo;
        $t.$baseType = System.Object;
        $p.$typeName = "WootzJs.Compiler.Tests.UsingStatementTests.Foo";
        $t.$typeName = $p.$typeName;
        $t.$GetType = function() {
            return System.Type._GetTypeFromTypeFunc(this);
        };
        $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("Foo", []);this.$type.Init("WootzJs.Compiler.Tests.UsingStatementTests.Foo", WootzJs.Compiler.Tests.UsingStatementTests.Foo, System.Object, [System.IDisposable], [System.Reflection.FieldInfo.prototype.$ctor.$new("IsDisposed", System.Boolean, System.Reflection.FieldAttributes().Public, null, [])], [System.Reflection.MethodInfo.prototype.$ctor.$new("Dispose", WootzJs.Compiler.Tests.UsingStatementTests.Foo.prototype.Dispose, [], System.Void, System.Reflection.MethodAttributes().Public, [])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.UsingStatementTests.Foo.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
        $t.$StaticInitializer = function() {
        };
        $p.$ctor = function() {
            System.Object.prototype.$ctor.call(this);
        };
        $p.$ctor.$type = $t;
        $p.$ctor.$new = function() {
            return new $p.$ctor.$type(this);
        };
        $p.IsDisposed = null;
        $p.Dispose = function() {
            this.IsDisposed = true;
        };
        $p.System$IDisposable$Dispose = $p.Dispose;
    }).call($t, $t.Foo, $t.Foo.prototype);
    $WootzJs$Compiler$Tests$AssemblyTypes.push($t.Foo);
}).call(null, WootzJs.Compiler.Tests.UsingStatementTests, WootzJs.Compiler.Tests.UsingStatementTests.prototype);
$WootzJs$Compiler$Tests$AssemblyTypes.push(WootzJs.Compiler.Tests.UsingStatementTests);
WootzJs.Compiler.Tests.VirtualMethodTests = $define("WootzJs.Compiler.Tests.VirtualMethodTests");
WootzJs.Compiler.Tests.VirtualMethodTests.prototype = new System.Object();
(WootzJs.Compiler.Tests.VirtualMethodTests.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
    $p.$type = WootzJs.Compiler.Tests.VirtualMethodTests;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Compiler.Tests.VirtualMethodTests";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("VirtualMethodTests", [WootzJs.Compiler.Tests.TestFixtureAttribute.prototype.$ctor.$new()]);this.$type.Init("WootzJs.Compiler.Tests.VirtualMethodTests", WootzJs.Compiler.Tests.VirtualMethodTests, System.Object, [], [], [System.Reflection.MethodInfo.prototype.$ctor.$new("Override", WootzJs.Compiler.Tests.VirtualMethodTests.prototype.Override, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.VirtualMethodTests.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
    $t.$StaticInitializer = function() {
    };
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.Override = function() {
        var baseClass = WootzJs.Compiler.Tests.VirtualMethodTests.BaseClass.prototype.$ctor.$new();
        var subClass = WootzJs.Compiler.Tests.VirtualMethodTests.SubClass.prototype.$ctor.$new();
        var subClassAsBaseClass = subClass;
        QUnit.equal(baseClass.Foo(), "base");
        QUnit.equal(subClass.Foo(), "sub");
        QUnit.equal(subClassAsBaseClass.Foo(), "sub");
    };
    function BaseClass($constructor) {
        if (!$t.BaseClass.$isStaticInitialized && ($constructor != null || !(this instanceof WootzJs.Compiler.Tests.VirtualMethodTests.BaseClass))) {
            $t.BaseClass.$isStaticInitialized = true;
            $t.BaseClass.$StaticInitializer();
        }
        if ($constructor != null)
            $constructor.apply(this, Array.prototype.slice.call(arguments, 1));
        if (!(this instanceof WootzJs.Compiler.Tests.VirtualMethodTests.BaseClass))
            return $t.BaseClass;
    }
    $t.BaseClass = BaseClass;
    $t.BaseClass.prototype = new System.Object();
    ($t.BaseClass.$TypeInitializer = function($t, $p) {
        $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
        $p.$type = WootzJs.Compiler.Tests.VirtualMethodTests.BaseClass;
        $t.$baseType = System.Object;
        $p.$typeName = "WootzJs.Compiler.Tests.VirtualMethodTests.BaseClass";
        $t.$typeName = $p.$typeName;
        $t.$GetType = function() {
            return System.Type._GetTypeFromTypeFunc(this);
        };
        $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("BaseClass", []);this.$type.Init("WootzJs.Compiler.Tests.VirtualMethodTests.BaseClass", WootzJs.Compiler.Tests.VirtualMethodTests.BaseClass, System.Object, [], [], [System.Reflection.MethodInfo.prototype.$ctor.$new("Foo", WootzJs.Compiler.Tests.VirtualMethodTests.BaseClass.prototype.Foo, [], String, System.Reflection.MethodAttributes().Public, [])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.VirtualMethodTests.BaseClass.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
        $t.$StaticInitializer = function() {
        };
        $p.$ctor = function() {
            System.Object.prototype.$ctor.call(this);
        };
        $p.$ctor.$type = $t;
        $p.$ctor.$new = function() {
            return new $p.$ctor.$type(this);
        };
        $p.Foo = function() {
            return "base";
        };
    }).call($t, $t.BaseClass, $t.BaseClass.prototype);
    $WootzJs$Compiler$Tests$AssemblyTypes.push($t.BaseClass);
    function SubClass($constructor) {
        if (!$t.SubClass.$isStaticInitialized && ($constructor != null || !(this instanceof WootzJs.Compiler.Tests.VirtualMethodTests.SubClass))) {
            $t.SubClass.$isStaticInitialized = true;
            $t.SubClass.$StaticInitializer();
        }
        if ($constructor != null)
            $constructor.apply(this, Array.prototype.slice.call(arguments, 1));
        if (!(this instanceof WootzJs.Compiler.Tests.VirtualMethodTests.SubClass))
            return $t.SubClass;
    }
    $t.SubClass = SubClass;
    $t.SubClass.prototype = new WootzJs.Compiler.Tests.VirtualMethodTests.BaseClass();
    ($t.SubClass.$TypeInitializer = function($t, $p) {
        $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
        $p.$type = WootzJs.Compiler.Tests.VirtualMethodTests.SubClass;
        $t.$baseType = WootzJs.Compiler.Tests.VirtualMethodTests.BaseClass;
        $p.$typeName = "WootzJs.Compiler.Tests.VirtualMethodTests.SubClass";
        $t.$typeName = $p.$typeName;
        $t.$GetType = function() {
            return System.Type._GetTypeFromTypeFunc(this);
        };
        $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("SubClass", []);this.$type.Init("WootzJs.Compiler.Tests.VirtualMethodTests.SubClass", WootzJs.Compiler.Tests.VirtualMethodTests.SubClass, WootzJs.Compiler.Tests.VirtualMethodTests.BaseClass, [], [], [System.Reflection.MethodInfo.prototype.$ctor.$new("Foo", WootzJs.Compiler.Tests.VirtualMethodTests.SubClass.prototype.Foo, [], String, System.Reflection.MethodAttributes().Public, [])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.VirtualMethodTests.SubClass.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
        $t.$StaticInitializer = function() {
        };
        $p.$ctor = function() {
            WootzJs.Compiler.Tests.VirtualMethodTests.BaseClass.prototype.$ctor.call(this);
        };
        $p.$ctor.$type = $t;
        $p.$ctor.$new = function() {
            return new $p.$ctor.$type(this);
        };
        $p.Foo = function() {
            return "sub";
        };
    }).call($t, $t.SubClass, $t.SubClass.prototype);
    $WootzJs$Compiler$Tests$AssemblyTypes.push($t.SubClass);
}).call(null, WootzJs.Compiler.Tests.VirtualMethodTests, WootzJs.Compiler.Tests.VirtualMethodTests.prototype);
$WootzJs$Compiler$Tests$AssemblyTypes.push(WootzJs.Compiler.Tests.VirtualMethodTests);
WootzJs.Compiler.Tests.YieldTests = $define("WootzJs.Compiler.Tests.YieldTests");
WootzJs.Compiler.Tests.YieldTests.prototype = new System.Object();
(WootzJs.Compiler.Tests.YieldTests.$TypeInitializer = function($t, $p) {
    $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
    $p.$type = WootzJs.Compiler.Tests.YieldTests;
    $t.$baseType = System.Object;
    $p.$typeName = "WootzJs.Compiler.Tests.YieldTests";
    $t.$typeName = $p.$typeName;
    $t.$GetType = function() {
        return System.Type._GetTypeFromTypeFunc(this);
    };
    $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("YieldTests", [WootzJs.Compiler.Tests.TestFixtureAttribute.prototype.$ctor.$new()]);this.$type.Init("WootzJs.Compiler.Tests.YieldTests", WootzJs.Compiler.Tests.YieldTests, System.Object, [], [], [System.Reflection.MethodInfo.prototype.$ctor.$new("YieldBreak", WootzJs.Compiler.Tests.YieldTests.prototype.YieldBreak, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("ReturnOne", WootzJs.Compiler.Tests.YieldTests.prototype.ReturnOne, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("ReturnTwo", WootzJs.Compiler.Tests.YieldTests.prototype.ReturnTwo, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("IfStatementTrue", WootzJs.Compiler.Tests.YieldTests.prototype.IfStatementTrue, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("IfStatementFalse", WootzJs.Compiler.Tests.YieldTests.prototype.IfStatementFalse, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("IfStatementTwoItemsTrue", WootzJs.Compiler.Tests.YieldTests.prototype.IfStatementTwoItemsTrue, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("IfStatementTwoItemsFalse", WootzJs.Compiler.Tests.YieldTests.prototype.IfStatementTwoItemsFalse, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("NestedIfTrueTrue", WootzJs.Compiler.Tests.YieldTests.prototype.NestedIfTrueTrue, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("NestedIfTrueFalse", WootzJs.Compiler.Tests.YieldTests.prototype.NestedIfTrueFalse, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("NestedIfFalseTrue", WootzJs.Compiler.Tests.YieldTests.prototype.NestedIfFalseTrue, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("NestedIfFalseFalse", WootzJs.Compiler.Tests.YieldTests.prototype.NestedIfFalseFalse, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("NestedIfTwoStatementsTrueTrue", WootzJs.Compiler.Tests.YieldTests.prototype.NestedIfTwoStatementsTrueTrue, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("NestedIfTwoStatementsTrueFalse", WootzJs.Compiler.Tests.YieldTests.prototype.NestedIfTwoStatementsTrueFalse, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("NestedIfTwoStatementsFalseTrue", WootzJs.Compiler.Tests.YieldTests.prototype.NestedIfTwoStatementsFalseTrue, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("ReturnAfterIfTrue", WootzJs.Compiler.Tests.YieldTests.prototype.ReturnAfterIfTrue, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("ReturnAfterIfFalse", WootzJs.Compiler.Tests.YieldTests.prototype.ReturnAfterIfFalse, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("IterateVariable", WootzJs.Compiler.Tests.YieldTests.prototype.IterateVariable, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("WhileLoop", WootzJs.Compiler.Tests.YieldTests.prototype.WhileLoop, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("IfWithErrataAfterYield", WootzJs.Compiler.Tests.YieldTests.prototype.IfWithErrataAfterYield, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("ForLoop", WootzJs.Compiler.Tests.YieldTests.prototype.ForLoop, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("ForLoopNoVariableWithInitializer", WootzJs.Compiler.Tests.YieldTests.prototype.ForLoopNoVariableWithInitializer, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("ForLoopNoVariableNoInitializer", WootzJs.Compiler.Tests.YieldTests.prototype.ForLoopNoVariableNoInitializer, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("ForLoopNoVariableNoInitializerNoIncrementor", WootzJs.Compiler.Tests.YieldTests.prototype.ForLoopNoVariableNoInitializerNoIncrementor, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("ForLoopTwoVariablesTwoIncrementors", WootzJs.Compiler.Tests.YieldTests.prototype.ForLoopTwoVariablesTwoIncrementors, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("NestedLoops", WootzJs.Compiler.Tests.YieldTests.prototype.NestedLoops, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("TypeParameter", WootzJs.Compiler.Tests.YieldTests.prototype.TypeParameter, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("Foreach", WootzJs.Compiler.Tests.YieldTests.prototype.Foreach, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("DoWhileFalse", WootzJs.Compiler.Tests.YieldTests.prototype.DoWhileFalse, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("DoWhileLessThan3", WootzJs.Compiler.Tests.YieldTests.prototype.DoWhileLessThan3, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("SwitchOne", WootzJs.Compiler.Tests.YieldTests.prototype.SwitchOne, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("SwitchTwo", WootzJs.Compiler.Tests.YieldTests.prototype.SwitchTwo, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("SwitchThree", WootzJs.Compiler.Tests.YieldTests.prototype.SwitchThree, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("SwitchDefault", WootzJs.Compiler.Tests.YieldTests.prototype.SwitchDefault, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("BreakWhile", WootzJs.Compiler.Tests.YieldTests.prototype.BreakWhile, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("ContinueWhile", WootzJs.Compiler.Tests.YieldTests.prototype.ContinueWhile, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("BreakFor", WootzJs.Compiler.Tests.YieldTests.prototype.BreakFor, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("ContinueFor", WootzJs.Compiler.Tests.YieldTests.prototype.ContinueFor, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("BreakForeach", WootzJs.Compiler.Tests.YieldTests.prototype.BreakForeach, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("ContinueForeach", WootzJs.Compiler.Tests.YieldTests.prototype.ContinueForeach, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("BreakDoWhile", WootzJs.Compiler.Tests.YieldTests.prototype.BreakDoWhile, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("ContinueDoWhile", WootzJs.Compiler.Tests.YieldTests.prototype.ContinueDoWhile, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("TryFinally", WootzJs.Compiler.Tests.YieldTests.prototype.TryFinally, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("NestedTryFinally", WootzJs.Compiler.Tests.YieldTests.prototype.NestedTryFinally, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("TryFinallyThrowsException", WootzJs.Compiler.Tests.YieldTests.prototype.TryFinallyThrowsException, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("LabeledStatementGotoFirst", WootzJs.Compiler.Tests.YieldTests.prototype.LabeledStatementGotoFirst, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("LabeledStatementGotoSecond", WootzJs.Compiler.Tests.YieldTests.prototype.LabeledStatementGotoSecond, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("CollidingForeach", WootzJs.Compiler.Tests.YieldTests.prototype.CollidingForeach, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()]), System.Reflection.MethodInfo.prototype.$ctor.$new("CollidingFor", WootzJs.Compiler.Tests.YieldTests.prototype.CollidingFor, [], System.Void, System.Reflection.MethodAttributes().Public, [WootzJs.Compiler.Tests.TestAttribute.prototype.$ctor.$new()])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.YieldTests.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
    $t.$StaticInitializer = function() {
    };
    $p.$ctor = function() {
        System.Object.prototype.$ctor.call(this);
    };
    $p.$ctor.$type = $t;
    $p.$ctor.$new = function() {
        return new $p.$ctor.$type(this);
    };
    $p.YieldBreak = function() {
        var strings = System.Linq.Enumerable.ToArray(String, WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldBreak());
        QUnit.equal(0, strings.length);
    };
    $p.ReturnOne = function() {
        var strings = System.Linq.Enumerable.ToArray(String, WootzJs.Compiler.Tests.YieldTests.YieldClass.ReturnOne());
        QUnit.equal(strings.length, 1);
        QUnit.equal(strings[0], "one");
    };
    $p.ReturnTwo = function() {
        var strings = System.Linq.Enumerable.ToArray(String, WootzJs.Compiler.Tests.YieldTests.YieldClass.ReturnTwo());
        QUnit.equal(strings.length, 2);
        QUnit.equal(strings[0], "one");
        QUnit.equal(strings[1], "two");
    };
    $p.IfStatementTrue = function() {
        var strings = System.Linq.Enumerable.ToArray(String, WootzJs.Compiler.Tests.YieldTests.YieldClass.IfStatement(true));
        QUnit.equal(strings.length, 1);
        QUnit.equal(strings[0], "true");
    };
    $p.IfStatementFalse = function() {
        var strings = System.Linq.Enumerable.ToArray(String, WootzJs.Compiler.Tests.YieldTests.YieldClass.IfStatement(false));
        QUnit.equal(strings.length, 1);
        QUnit.equal(strings[0], "false");
    };
    $p.IfStatementTwoItemsTrue = function() {
        var strings = System.Linq.Enumerable.ToArray(String, WootzJs.Compiler.Tests.YieldTests.YieldClass.IfStatementTwoItems(true));
        QUnit.equal(strings.length, 2);
        QUnit.equal(strings[0], "one");
        QUnit.equal(strings[1], "two");
    };
    $p.IfStatementTwoItemsFalse = function() {
        var strings = System.Linq.Enumerable.ToArray(String, WootzJs.Compiler.Tests.YieldTests.YieldClass.IfStatementTwoItems(false));
        QUnit.equal(strings.length, 2);
        QUnit.equal(strings[0], "three");
        QUnit.equal(strings[1], "four");
    };
    $p.NestedIfTrueTrue = function() {
        var strings = System.Linq.Enumerable.ToArray(String, WootzJs.Compiler.Tests.YieldTests.YieldClass.NestedIf(true, true));
        QUnit.equal(strings.length, 1);
        QUnit.equal(strings[0], "one");
    };
    $p.NestedIfTrueFalse = function() {
        var strings = System.Linq.Enumerable.ToArray(String, WootzJs.Compiler.Tests.YieldTests.YieldClass.NestedIf(true, false));
        QUnit.equal(strings.length, 1);
        QUnit.equal(strings[0], "two");
    };
    $p.NestedIfFalseTrue = function() {
        var strings = System.Linq.Enumerable.ToArray(String, WootzJs.Compiler.Tests.YieldTests.YieldClass.NestedIf(false, true));
        QUnit.equal(strings.length, 1);
        QUnit.equal(strings[0], "three");
    };
    $p.NestedIfFalseFalse = function() {
        var strings = System.Linq.Enumerable.ToArray(String, WootzJs.Compiler.Tests.YieldTests.YieldClass.NestedIf(false, false));
        QUnit.equal(strings.length, 1);
        QUnit.equal(strings[0], "four");
    };
    $p.NestedIfTwoStatementsTrueTrue = function() {
        var strings = System.Linq.Enumerable.ToArray(String, WootzJs.Compiler.Tests.YieldTests.YieldClass.NestedIfTwoStatements(true, true));
        QUnit.equal(strings.length, 2);
        QUnit.equal(strings[0], "one");
        QUnit.equal(strings[1], "two");
    };
    $p.NestedIfTwoStatementsTrueFalse = function() {
        var strings = System.Linq.Enumerable.ToArray(String, WootzJs.Compiler.Tests.YieldTests.YieldClass.NestedIfTwoStatements(true, false));
        QUnit.equal(strings.length, 2);
        QUnit.equal(strings[0], "three");
        QUnit.equal(strings[1], "four");
    };
    $p.NestedIfTwoStatementsFalseTrue = function() {
        var strings = System.Linq.Enumerable.ToArray(String, WootzJs.Compiler.Tests.YieldTests.YieldClass.NestedIfTwoStatements(false, true));
        QUnit.equal(strings.length, 2);
        QUnit.equal(strings[0], "five");
        QUnit.equal(strings[1], "six");
    };
    $p.ReturnAfterIfTrue = function() {
        var strings = System.Linq.Enumerable.ToArray(String, WootzJs.Compiler.Tests.YieldTests.YieldClass.ReturnAfterIf(true));
        QUnit.equal(strings.length, 5);
        QUnit.equal(strings[0], "zero");
        QUnit.equal(strings[1], "one");
        QUnit.equal(strings[2], "two");
        QUnit.equal(strings[3], "five");
        QUnit.equal(strings[4], "six");
    };
    $p.ReturnAfterIfFalse = function() {
        var strings = System.Linq.Enumerable.ToArray(String, WootzJs.Compiler.Tests.YieldTests.YieldClass.ReturnAfterIf(false));
        QUnit.equal(strings.length, 5);
        QUnit.equal(strings[0], "zero");
        QUnit.equal(strings[1], "three");
        QUnit.equal(strings[2], "four");
        QUnit.equal(strings[3], "five");
        QUnit.equal(strings[4], "six");
    };
    $p.IterateVariable = function() {
        var strings = System.Linq.Enumerable.ToArray(String, WootzJs.Compiler.Tests.YieldTests.YieldClass.InitializeVariable());
        QUnit.equal(strings.length, 1);
        QUnit.equal(strings[0], "foo");
    };
    $p.WhileLoop = function() {
        var ints = System.Linq.Enumerable.ToArray(System.Int32, WootzJs.Compiler.Tests.YieldTests.YieldClass.WhileLoop());
        QUnit.equal(ints.length, 3);
        QUnit.equal(ints[0], 0);
        QUnit.equal(ints[1], 1);
        QUnit.equal(ints[2], 2);
    };
    $p.IfWithErrataAfterYield = function() {
        var ints = System.Linq.Enumerable.ToArray(System.Int32, WootzJs.Compiler.Tests.YieldTests.YieldClass.IfWithErrataAfterYield(true));
        QUnit.equal(ints.length, 2);
        QUnit.equal(ints[0], 0);
        QUnit.equal(ints[1], 1);
    };
    $p.ForLoop = function() {
        var ints = System.Linq.Enumerable.ToArray(System.Int32, WootzJs.Compiler.Tests.YieldTests.YieldClass.ForLoop());
        QUnit.equal(ints.length, 3);
        QUnit.equal(ints[0], 0);
        QUnit.equal(ints[1], 1);
        QUnit.equal(ints[2], 2);
    };
    $p.ForLoopNoVariableWithInitializer = function() {
        var ints = System.Linq.Enumerable.ToArray(System.Int32, WootzJs.Compiler.Tests.YieldTests.YieldClass.ForLoopNoVariableWithInitializer());
        QUnit.equal(ints.length, 3);
        QUnit.equal(ints[0], 0);
        QUnit.equal(ints[1], 1);
        QUnit.equal(ints[2], 2);
    };
    $p.ForLoopNoVariableNoInitializer = function() {
        var ints = System.Linq.Enumerable.ToArray(System.Int32, WootzJs.Compiler.Tests.YieldTests.YieldClass.ForLoopNoVariableNoInitializer());
        QUnit.equal(ints.length, 3);
        QUnit.equal(ints[0], 0);
        QUnit.equal(ints[1], 1);
        QUnit.equal(ints[2], 2);
    };
    $p.ForLoopNoVariableNoInitializerNoIncrementor = function() {
        var ints = System.Linq.Enumerable.ToArray(System.Int32, WootzJs.Compiler.Tests.YieldTests.YieldClass.ForLoopNoVariableNoInitializerNoIncrementor());
        QUnit.equal(ints.length, 3);
        QUnit.equal(ints[0], 0);
        QUnit.equal(ints[1], 1);
        QUnit.equal(ints[2], 2);
    };
    $p.ForLoopTwoVariablesTwoIncrementors = function() {
        var ints = System.Linq.Enumerable.ToArray(System.Int32, WootzJs.Compiler.Tests.YieldTests.YieldClass.ForLoopTwoVariablesTwoIncrementors());
        QUnit.equal(ints.length, 3);
        QUnit.equal(ints[0], 1);
        QUnit.equal(ints[1], 3);
        QUnit.equal(ints[2], 5);
    };
    $p.NestedLoops = function() {
        var ints = System.Linq.Enumerable.ToArray(System.Int32, WootzJs.Compiler.Tests.YieldTests.YieldClass.NestedLoops());
        QUnit.equal(ints.length, 6);
        QUnit.equal(ints[0], 0);
        QUnit.equal(ints[1], 1);
        QUnit.equal(ints[2], 0);
        QUnit.equal(ints[3], 1);
        QUnit.equal(ints[4], 2);
        QUnit.equal(ints[5], 1);
    };
    $p.TypeParameter = function() {
        var strings = System.Linq.Enumerable.ToArray(String, WootzJs.Compiler.Tests.YieldTests.YieldClass.TypeParameter(WootzJs.Compiler.Tests.YieldTests.YieldClass));
        QUnit.equal(strings.length, 1);
        QUnit.equal(strings[0], "WootzJs.Compiler.Tests.YieldTests.YieldClass");
    };
    $p.Foreach = function() {
        var strings = System.Linq.Enumerable.ToArray(String, WootzJs.Compiler.Tests.YieldTests.YieldClass.Foreach());
        QUnit.equal(strings.length, 3);
        QUnit.equal(strings[0], "one");
        QUnit.equal(strings[1], "two");
        QUnit.equal(strings[2], "three");
    };
    $p.DoWhileFalse = function() {
        var ints = System.Linq.Enumerable.ToArray(System.Int32, WootzJs.Compiler.Tests.YieldTests.YieldClass.DoWhileFalse());
        QUnit.equal(ints.length, 1);
        QUnit.equal(ints[0], 1);
    };
    $p.DoWhileLessThan3 = function() {
        var ints = System.Linq.Enumerable.ToArray(System.Int32, WootzJs.Compiler.Tests.YieldTests.YieldClass.DoWhileLessThan3());
        QUnit.equal(ints.length, 2);
        QUnit.equal(ints[0], 1);
        QUnit.equal(ints[1], 2);
    };
    $p.SwitchOne = function() {
        var ints = System.Linq.Enumerable.ToArray(System.Int32, WootzJs.Compiler.Tests.YieldTests.YieldClass.Switch("one"));
        QUnit.equal(ints.length, 1);
        QUnit.equal(ints[0], 1);
    };
    $p.SwitchTwo = function() {
        var ints = System.Linq.Enumerable.ToArray(System.Int32, WootzJs.Compiler.Tests.YieldTests.YieldClass.Switch("two"));
        QUnit.equal(ints.length, 2);
        QUnit.equal(ints[0], 1);
        QUnit.equal(ints[1], 2);
    };
    $p.SwitchThree = function() {
        var ints = System.Linq.Enumerable.ToArray(System.Int32, WootzJs.Compiler.Tests.YieldTests.YieldClass.Switch("three"));
        QUnit.equal(ints.length, 3);
        QUnit.equal(ints[0], 1);
        QUnit.equal(ints[1], 2);
        QUnit.equal(ints[2], 3);
    };
    $p.SwitchDefault = function() {
        var ints = System.Linq.Enumerable.ToArray(System.Int32, WootzJs.Compiler.Tests.YieldTests.YieldClass.Switch("foo"));
        QUnit.equal(ints.length, 1);
        QUnit.equal(ints[0], -1);
    };
    $p.BreakWhile = function() {
        var ints = System.Linq.Enumerable.ToArray(System.Int32, WootzJs.Compiler.Tests.YieldTests.YieldClass.BreakWhile());
        QUnit.equal(ints.length, 1);
        QUnit.equal(ints[0], 1);
    };
    $p.ContinueWhile = function() {
        var ints = System.Linq.Enumerable.ToArray(System.Int32, WootzJs.Compiler.Tests.YieldTests.YieldClass.ContinueWhile());
        QUnit.equal(ints.length, 2);
        QUnit.equal(ints[0], 2);
        QUnit.equal(ints[1], 3);
    };
    $p.BreakFor = function() {
        var ints = System.Linq.Enumerable.ToArray(System.Int32, WootzJs.Compiler.Tests.YieldTests.YieldClass.BreakFor());
        QUnit.equal(ints.length, 1);
        QUnit.equal(ints[0], 1);
    };
    $p.ContinueFor = function() {
        var ints = System.Linq.Enumerable.ToArray(System.Int32, WootzJs.Compiler.Tests.YieldTests.YieldClass.ContinueFor());
        QUnit.equal(ints.length, 2);
        QUnit.equal(ints[0], 2);
        QUnit.equal(ints[1], 3);
    };
    $p.BreakForeach = function() {
        var ints = System.Linq.Enumerable.ToArray(System.Int32, WootzJs.Compiler.Tests.YieldTests.YieldClass.BreakForeach());
        QUnit.equal(ints.length, 1);
        QUnit.equal(ints[0], 1);
    };
    $p.ContinueForeach = function() {
        var ints = System.Linq.Enumerable.ToArray(System.Int32, WootzJs.Compiler.Tests.YieldTests.YieldClass.ContinueForeach());
        QUnit.equal(ints.length, 2);
        QUnit.equal(ints[0], 2);
        QUnit.equal(ints[1], 3);
    };
    $p.BreakDoWhile = function() {
        var ints = System.Linq.Enumerable.ToArray(System.Int32, WootzJs.Compiler.Tests.YieldTests.YieldClass.BreakDoWhile());
        QUnit.equal(ints.length, 1);
        QUnit.equal(ints[0], 1);
    };
    $p.ContinueDoWhile = function() {
        var ints = System.Linq.Enumerable.ToArray(System.Int32, WootzJs.Compiler.Tests.YieldTests.YieldClass.ContinueDoWhile());
        QUnit.equal(ints.length, 2);
        QUnit.equal(ints[0], 2);
        QUnit.equal(ints[1], 3);
    };
    $p.TryFinally = function() {
        var ints = System.Linq.Enumerable.ToArray(System.Int32, WootzJs.Compiler.Tests.YieldTests.YieldClass.TryFinally());
        QUnit.equal(ints.length, 3);
        QUnit.equal(ints[0], 1);
        QUnit.equal(ints[1], 2);
        QUnit.equal(ints[2], 3);
    };
    $p.NestedTryFinally = function() {
        var ints = System.Linq.Enumerable.ToArray(System.Int32, WootzJs.Compiler.Tests.YieldTests.YieldClass.NestedTryFinally());
        QUnit.equal(ints.length, 6);
        QUnit.equal(ints[0], 1);
        QUnit.equal(ints[1], 2);
        QUnit.equal(ints[2], 3);
        QUnit.equal(ints[3], 4);
        QUnit.equal(ints[4], 11);
        QUnit.equal(ints[5], 22);
    };
    $p.TryFinallyThrowsException = function() {
        var enumerator = WootzJs.Compiler.Tests.YieldTests.YieldClass.TryFinallyThrowsException(true).System$Collections$Generic$IEnumerable$1$GetEnumerator();
        QUnit.ok(enumerator.System$Collections$IEnumerator$MoveNext());
        QUnit.equal(enumerator.get_Current(), 1);
        try {
            enumerator.System$Collections$IEnumerator$MoveNext();
            QUnit.ok(false);
        }
        catch ($anon$1) {
            QUnit.ok(true);
        }
    };
    $p.LabeledStatementGotoFirst = function() {
        var ints = System.Linq.Enumerable.ToArray(System.Int32, WootzJs.Compiler.Tests.YieldTests.YieldClass.LabeledStatementGotoFirst(true));
        QUnit.equal(ints.length, 1);
        QUnit.equal(ints[0], 1);
        ints = System.Linq.Enumerable.ToArray(System.Int32, WootzJs.Compiler.Tests.YieldTests.YieldClass.LabeledStatementGotoFirst(false));
        QUnit.equal(ints.length, 2);
        QUnit.equal(ints[0], 1);
        QUnit.equal(ints[1], 2);
    };
    $p.LabeledStatementGotoSecond = function() {
        var ints = System.Linq.Enumerable.ToArray(System.Int32, WootzJs.Compiler.Tests.YieldTests.YieldClass.LabeledStatementGotoSecond());
        QUnit.equal(ints.length, 3);
        QUnit.equal(ints[0], 1);
        QUnit.equal(ints[1], 2);
        QUnit.equal(ints[2], 3);
    };
    $p.CollidingForeach = function() {
        var ints = System.Linq.Enumerable.ToArray(System.Int32, WootzJs.Compiler.Tests.YieldTests.YieldClass.CollidingForeach());
        QUnit.equal(ints.length, 4);
        QUnit.equal(ints[0], 1);
        QUnit.equal(ints[1], 2);
        QUnit.equal(ints[2], 3);
        QUnit.equal(ints[3], 4);
    };
    $p.CollidingFor = function() {
        var ints = System.Linq.Enumerable.ToArray(System.Int32, WootzJs.Compiler.Tests.YieldTests.YieldClass.CollidingForeach());
        QUnit.equal(ints.length, 4);
        QUnit.equal(ints[0], 1);
        QUnit.equal(ints[1], 2);
        QUnit.equal(ints[2], 3);
        QUnit.equal(ints[3], 4);
    };
    function YieldClass($constructor) {
        if (!$t.YieldClass.$isStaticInitialized && ($constructor != null || !(this instanceof WootzJs.Compiler.Tests.YieldTests.YieldClass))) {
            $t.YieldClass.$isStaticInitialized = true;
            $t.YieldClass.$StaticInitializer();
        }
        if ($constructor != null)
            $constructor.apply(this, Array.prototype.slice.call(arguments, 1));
        if (!(this instanceof WootzJs.Compiler.Tests.YieldTests.YieldClass))
            return $t.YieldClass;
    }
    $t.YieldClass = YieldClass;
    $t.YieldClass.prototype = new System.Object();
    ($t.YieldClass.$TypeInitializer = function($t, $p) {
        $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
        $p.$type = WootzJs.Compiler.Tests.YieldTests.YieldClass;
        $t.$baseType = System.Object;
        $p.$typeName = "WootzJs.Compiler.Tests.YieldTests.YieldClass";
        $t.$typeName = $p.$typeName;
        $t.$GetType = function() {
            return System.Type._GetTypeFromTypeFunc(this);
        };
        $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("YieldClass", []);this.$type.Init("WootzJs.Compiler.Tests.YieldTests.YieldClass", WootzJs.Compiler.Tests.YieldTests.YieldClass, System.Object, [], [], [System.Reflection.MethodInfo.prototype.$ctor.$new("YieldBreak", WootzJs.Compiler.Tests.YieldTests.YieldClass.prototype.YieldBreak, [], System.Collections.Generic.IEnumerable$1, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, []), System.Reflection.MethodInfo.prototype.$ctor.$new("ReturnOne", WootzJs.Compiler.Tests.YieldTests.YieldClass.prototype.ReturnOne, [], System.Collections.Generic.IEnumerable$1, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, []), System.Reflection.MethodInfo.prototype.$ctor.$new("ReturnTwo", WootzJs.Compiler.Tests.YieldTests.YieldClass.prototype.ReturnTwo, [], System.Collections.Generic.IEnumerable$1, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, []), System.Reflection.MethodInfo.prototype.$ctor.$new("IfStatement", WootzJs.Compiler.Tests.YieldTests.YieldClass.prototype.IfStatement, [System.Reflection.ParameterInfo.prototype.$ctor.$new("flag", System.Boolean, 0, 0, null, [])], System.Collections.Generic.IEnumerable$1, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, []), System.Reflection.MethodInfo.prototype.$ctor.$new("IfStatementTwoItems", WootzJs.Compiler.Tests.YieldTests.YieldClass.prototype.IfStatementTwoItems, [System.Reflection.ParameterInfo.prototype.$ctor.$new("flag", System.Boolean, 0, 0, null, [])], System.Collections.Generic.IEnumerable$1, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, []), System.Reflection.MethodInfo.prototype.$ctor.$new("NestedIf", WootzJs.Compiler.Tests.YieldTests.YieldClass.prototype.NestedIf, [System.Reflection.ParameterInfo.prototype.$ctor.$new("flag1", System.Boolean, 0, 0, null, []), System.Reflection.ParameterInfo.prototype.$ctor.$new("flag2", System.Boolean, 1, 0, null, [])], System.Collections.Generic.IEnumerable$1, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, []), System.Reflection.MethodInfo.prototype.$ctor.$new("NestedIfTwoStatements", WootzJs.Compiler.Tests.YieldTests.YieldClass.prototype.NestedIfTwoStatements, [System.Reflection.ParameterInfo.prototype.$ctor.$new("flag1", System.Boolean, 0, 0, null, []), System.Reflection.ParameterInfo.prototype.$ctor.$new("flag2", System.Boolean, 1, 0, null, [])], System.Collections.Generic.IEnumerable$1, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, []), System.Reflection.MethodInfo.prototype.$ctor.$new("ReturnAfterIf", WootzJs.Compiler.Tests.YieldTests.YieldClass.prototype.ReturnAfterIf, [System.Reflection.ParameterInfo.prototype.$ctor.$new("flag", System.Boolean, 0, 0, null, [])], System.Collections.Generic.IEnumerable$1, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, []), System.Reflection.MethodInfo.prototype.$ctor.$new("InitializeVariable", WootzJs.Compiler.Tests.YieldTests.YieldClass.prototype.InitializeVariable, [], System.Collections.Generic.IEnumerable$1, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, []), System.Reflection.MethodInfo.prototype.$ctor.$new("WhileLoop", WootzJs.Compiler.Tests.YieldTests.YieldClass.prototype.WhileLoop, [], System.Collections.Generic.IEnumerable$1, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, []), System.Reflection.MethodInfo.prototype.$ctor.$new("IfWithErrataAfterYield", WootzJs.Compiler.Tests.YieldTests.YieldClass.prototype.IfWithErrataAfterYield, [System.Reflection.ParameterInfo.prototype.$ctor.$new("flag", System.Boolean, 0, 0, null, [])], System.Collections.Generic.IEnumerable$1, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, []), System.Reflection.MethodInfo.prototype.$ctor.$new("ForLoop", WootzJs.Compiler.Tests.YieldTests.YieldClass.prototype.ForLoop, [], System.Collections.Generic.IEnumerable$1, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, []), System.Reflection.MethodInfo.prototype.$ctor.$new("ForLoopNoVariableWithInitializer", WootzJs.Compiler.Tests.YieldTests.YieldClass.prototype.ForLoopNoVariableWithInitializer, [], System.Collections.Generic.IEnumerable$1, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, []), System.Reflection.MethodInfo.prototype.$ctor.$new("ForLoopNoVariableNoInitializer", WootzJs.Compiler.Tests.YieldTests.YieldClass.prototype.ForLoopNoVariableNoInitializer, [], System.Collections.Generic.IEnumerable$1, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, []), System.Reflection.MethodInfo.prototype.$ctor.$new("ForLoopNoVariableNoInitializerNoIncrementor", WootzJs.Compiler.Tests.YieldTests.YieldClass.prototype.ForLoopNoVariableNoInitializerNoIncrementor, [], System.Collections.Generic.IEnumerable$1, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, []), System.Reflection.MethodInfo.prototype.$ctor.$new("ForLoopTwoVariablesTwoIncrementors", WootzJs.Compiler.Tests.YieldTests.YieldClass.prototype.ForLoopTwoVariablesTwoIncrementors, [], System.Collections.Generic.IEnumerable$1, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, []), System.Reflection.MethodInfo.prototype.$ctor.$new("NestedLoops", WootzJs.Compiler.Tests.YieldTests.YieldClass.prototype.NestedLoops, [], System.Collections.Generic.IEnumerable$1, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, []), System.Reflection.MethodInfo.prototype.$ctor.$new("TypeParameter", WootzJs.Compiler.Tests.YieldTests.YieldClass.prototype.TypeParameter, [], System.Collections.Generic.IEnumerable$1, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, []), System.Reflection.MethodInfo.prototype.$ctor.$new("Foreach", WootzJs.Compiler.Tests.YieldTests.YieldClass.prototype.Foreach, [], System.Collections.Generic.IEnumerable$1, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, []), System.Reflection.MethodInfo.prototype.$ctor.$new("DoWhileFalse", WootzJs.Compiler.Tests.YieldTests.YieldClass.prototype.DoWhileFalse, [], System.Collections.Generic.IEnumerable$1, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, []), System.Reflection.MethodInfo.prototype.$ctor.$new("DoWhileLessThan3", WootzJs.Compiler.Tests.YieldTests.YieldClass.prototype.DoWhileLessThan3, [], System.Collections.Generic.IEnumerable$1, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, []), System.Reflection.MethodInfo.prototype.$ctor.$new("Switch", WootzJs.Compiler.Tests.YieldTests.YieldClass.prototype.Switch, [System.Reflection.ParameterInfo.prototype.$ctor.$new("s", String, 0, 0, null, [])], System.Collections.Generic.IEnumerable$1, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, []), System.Reflection.MethodInfo.prototype.$ctor.$new("BreakWhile", WootzJs.Compiler.Tests.YieldTests.YieldClass.prototype.BreakWhile, [], System.Collections.Generic.IEnumerable$1, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, []), System.Reflection.MethodInfo.prototype.$ctor.$new("ContinueWhile", WootzJs.Compiler.Tests.YieldTests.YieldClass.prototype.ContinueWhile, [], System.Collections.Generic.IEnumerable$1, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, []), System.Reflection.MethodInfo.prototype.$ctor.$new("BreakFor", WootzJs.Compiler.Tests.YieldTests.YieldClass.prototype.BreakFor, [], System.Collections.Generic.IEnumerable$1, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, []), System.Reflection.MethodInfo.prototype.$ctor.$new("ContinueFor", WootzJs.Compiler.Tests.YieldTests.YieldClass.prototype.ContinueFor, [], System.Collections.Generic.IEnumerable$1, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, []), System.Reflection.MethodInfo.prototype.$ctor.$new("BreakForeach", WootzJs.Compiler.Tests.YieldTests.YieldClass.prototype.BreakForeach, [], System.Collections.Generic.IEnumerable$1, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, []), System.Reflection.MethodInfo.prototype.$ctor.$new("ContinueForeach", WootzJs.Compiler.Tests.YieldTests.YieldClass.prototype.ContinueForeach, [], System.Collections.Generic.IEnumerable$1, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, []), System.Reflection.MethodInfo.prototype.$ctor.$new("BreakDoWhile", WootzJs.Compiler.Tests.YieldTests.YieldClass.prototype.BreakDoWhile, [], System.Collections.Generic.IEnumerable$1, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, []), System.Reflection.MethodInfo.prototype.$ctor.$new("ContinueDoWhile", WootzJs.Compiler.Tests.YieldTests.YieldClass.prototype.ContinueDoWhile, [], System.Collections.Generic.IEnumerable$1, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, []), System.Reflection.MethodInfo.prototype.$ctor.$new("TryFinally", WootzJs.Compiler.Tests.YieldTests.YieldClass.prototype.TryFinally, [], System.Collections.Generic.IEnumerable$1, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, []), System.Reflection.MethodInfo.prototype.$ctor.$new("NestedTryFinally", WootzJs.Compiler.Tests.YieldTests.YieldClass.prototype.NestedTryFinally, [], System.Collections.Generic.IEnumerable$1, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, []), System.Reflection.MethodInfo.prototype.$ctor.$new("TryFinallyThrowsException", WootzJs.Compiler.Tests.YieldTests.YieldClass.prototype.TryFinallyThrowsException, [System.Reflection.ParameterInfo.prototype.$ctor.$new("flag", System.Boolean, 0, 0, null, [])], System.Collections.Generic.IEnumerable$1, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, []), System.Reflection.MethodInfo.prototype.$ctor.$new("LabeledStatementGotoFirst", WootzJs.Compiler.Tests.YieldTests.YieldClass.prototype.LabeledStatementGotoFirst, [System.Reflection.ParameterInfo.prototype.$ctor.$new("flag", System.Boolean, 0, 0, null, [])], System.Collections.Generic.IEnumerable$1, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, []), System.Reflection.MethodInfo.prototype.$ctor.$new("LabeledStatementGotoSecond", WootzJs.Compiler.Tests.YieldTests.YieldClass.prototype.LabeledStatementGotoSecond, [], System.Collections.Generic.IEnumerable$1, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, []), System.Reflection.MethodInfo.prototype.$ctor.$new("CollidingForeach", WootzJs.Compiler.Tests.YieldTests.YieldClass.prototype.CollidingForeach, [], System.Collections.Generic.IEnumerable$1, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, []), System.Reflection.MethodInfo.prototype.$ctor.$new("CollidingFor", WootzJs.Compiler.Tests.YieldTests.YieldClass.prototype.CollidingFor, [], System.Collections.Generic.IEnumerable$1, System.Reflection.MethodAttributes().Public | System.Reflection.MethodAttributes().Static, [])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.YieldTests.YieldClass.prototype.$ctor, [], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
        $t.$StaticInitializer = function() {
        };
        $p.$ctor = function() {
            System.Object.prototype.$ctor.call(this);
        };
        $p.$ctor.$type = $t;
        $p.$ctor.$new = function() {
            return new $p.$ctor.$type(this);
        };
        $t.YieldBreak = function() {
            return WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$YieldBreak.prototype.$ctor.$new(this);
        };
        $t.ReturnOne = function() {
            return WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ReturnOne.prototype.$ctor.$new(this);
        };
        $t.ReturnTwo = function() {
            return WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ReturnTwo.prototype.$ctor.$new(this);
        };
        $t.IfStatement = function(flag) {
            return WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$IfStatement.prototype.$ctor.$new(this, flag);
        };
        $t.IfStatementTwoItems = function(flag) {
            return WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$IfStatementTwoItems.prototype.$ctor.$new(this, flag);
        };
        $t.NestedIf = function(flag1, flag2) {
            return WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$NestedIf.prototype.$ctor.$new(this, flag1, flag2);
        };
        $t.NestedIfTwoStatements = function(flag1, flag2) {
            return WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$NestedIfTwoStatements.prototype.$ctor.$new(this, flag1, flag2);
        };
        $t.ReturnAfterIf = function(flag) {
            return WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ReturnAfterIf.prototype.$ctor.$new(this, flag);
        };
        $t.InitializeVariable = function() {
            return WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$InitializeVariable.prototype.$ctor.$new(this);
        };
        $t.WhileLoop = function() {
            return WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$WhileLoop.prototype.$ctor.$new(this);
        };
        $t.IfWithErrataAfterYield = function(flag) {
            return WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$IfWithErrataAfterYield.prototype.$ctor.$new(this, flag);
        };
        $t.ForLoop = function() {
            return WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ForLoop.prototype.$ctor.$new(this);
        };
        $t.ForLoopNoVariableWithInitializer = function() {
            return WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ForLoopNoVariableWithInitializer.prototype.$ctor.$new(this);
        };
        $t.ForLoopNoVariableNoInitializer = function() {
            return WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ForLoopNoVariableNoInitializer.prototype.$ctor.$new(this);
        };
        $t.ForLoopNoVariableNoInitializerNoIncrementor = function() {
            return WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ForLoopNoVariableNoInitializerNoIncrementor.prototype.$ctor.$new(this);
        };
        $t.ForLoopTwoVariablesTwoIncrementors = function() {
            return WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ForLoopTwoVariablesTwoIncrementors.prototype.$ctor.$new(this);
        };
        $t.NestedLoops = function() {
            return WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$NestedLoops.prototype.$ctor.$new(this);
        };
        $t.TypeParameter = function(T) {
            return WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$TypeParameter$1$(T).prototype.$ctor.$new(this);
        };
        $t.Foreach = function() {
            return WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$Foreach.prototype.$ctor.$new(this);
        };
        $t.DoWhileFalse = function() {
            return WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$DoWhileFalse.prototype.$ctor.$new(this);
        };
        $t.DoWhileLessThan3 = function() {
            return WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$DoWhileLessThan3.prototype.$ctor.$new(this);
        };
        $t.Switch = function(s) {
            return WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$Switch.prototype.$ctor.$new(this, s);
        };
        $t.BreakWhile = function() {
            return WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$BreakWhile.prototype.$ctor.$new(this);
        };
        $t.ContinueWhile = function() {
            return WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ContinueWhile.prototype.$ctor.$new(this);
        };
        $t.BreakFor = function() {
            return WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$BreakFor.prototype.$ctor.$new(this);
        };
        $t.ContinueFor = function() {
            return WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ContinueFor.prototype.$ctor.$new(this);
        };
        $t.BreakForeach = function() {
            return WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$BreakForeach.prototype.$ctor.$new(this);
        };
        $t.ContinueForeach = function() {
            return WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ContinueForeach.prototype.$ctor.$new(this);
        };
        $t.BreakDoWhile = function() {
            return WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$BreakDoWhile.prototype.$ctor.$new(this);
        };
        $t.ContinueDoWhile = function() {
            return WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ContinueDoWhile.prototype.$ctor.$new(this);
        };
        $t.TryFinally = function() {
            return WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$TryFinally.prototype.$ctor.$new(this);
        };
        $t.NestedTryFinally = function() {
            return WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$NestedTryFinally.prototype.$ctor.$new(this);
        };
        $t.TryFinallyThrowsException = function(flag) {
            return WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$TryFinallyThrowsException.prototype.$ctor.$new(this, flag);
        };
        $t.LabeledStatementGotoFirst = function(flag) {
            return WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$LabeledStatementGotoFirst.prototype.$ctor.$new(this, flag);
        };
        $t.LabeledStatementGotoSecond = function() {
            return WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$LabeledStatementGotoSecond.prototype.$ctor.$new(this);
        };
        $t.CollidingForeach = function() {
            return WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$CollidingForeach.prototype.$ctor.$new(this);
        };
        $t.CollidingFor = function() {
            return WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$CollidingFor.prototype.$ctor.$new(this);
        };
        function YieldEnumerator$YieldBreak($constructor) {
            if (!$t.YieldEnumerator$YieldBreak.$isStaticInitialized && ($constructor != null || !(this instanceof WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$YieldBreak))) {
                $t.YieldEnumerator$YieldBreak.$isStaticInitialized = true;
                $t.YieldEnumerator$YieldBreak.$StaticInitializer();
            }
            if ($constructor != null)
                $constructor.apply(this, Array.prototype.slice.call(arguments, 1));
            if (!(this instanceof WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$YieldBreak))
                return $t.YieldEnumerator$YieldBreak;
        }
        $t.YieldEnumerator$YieldBreak = YieldEnumerator$YieldBreak;
        $t.YieldEnumerator$YieldBreak.prototype = new System.YieldIterator$1();
        ($t.YieldEnumerator$YieldBreak.$TypeInitializer = function($t, $p) {
            $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
            $p.$type = WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$YieldBreak;
            $t.$baseType = System.YieldIterator$1;
            $p.$typeName = "WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$YieldBreak";
            $t.$typeName = $p.$typeName;
            $t.$GetType = function() {
                return System.Type._GetTypeFromTypeFunc(this);
            };
            $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("YieldEnumerator$YieldBreak", []);this.$type.Init("WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$YieldBreak", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$YieldBreak, (System.YieldIterator$1$(System.Object)), [System.Collections.Generic.IEnumerator$1, System.Collections.IEnumerator, System.IDisposable, System.Collections.Generic.IEnumerable$1, System.Collections.IEnumerable], [System.Reflection.FieldInfo.prototype.$ctor.$new("$state", System.Int32, System.Reflection.FieldAttributes().Private, null, []), System.Reflection.FieldInfo.prototype.$ctor.$new("$this", WootzJs.Compiler.Tests.YieldTests.YieldClass, System.Reflection.FieldAttributes().Private, null, [])], [System.Reflection.MethodInfo.prototype.$ctor.$new("GetEnumerator", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$YieldBreak.prototype.GetEnumerator, [], System.Collections.IEnumerator, System.Reflection.MethodAttributes().Public, []), System.Reflection.MethodInfo.prototype.$ctor.$new("MoveNext", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$YieldBreak.prototype.MoveNext, [], System.Boolean, System.Reflection.MethodAttributes().Public, [])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$YieldBreak.prototype.$ctor, [System.Reflection.ParameterInfo.prototype.$ctor.$new("$this", WootzJs.Compiler.Tests.YieldTests.YieldClass, 0, 0, null, [])], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
            $t.$StaticInitializer = function() {
            };
            $p.$state = null;
            $p.$this = null;
            $p.$ctor = function($this) {
                (System.YieldIterator$1$(System.Object)).prototype.$ctor.call(this);
                this.$this = $this;
                this.$state = 1;
            };
            $p.$ctor.$type = $t;
            $p.$ctor.$new = function($this) {
                return new $p.$ctor.$type(this, $this);
            };
            $p.GetEnumerator = function() {
                return this;
            };
            $p.System$Collections$Generic$IEnumerable$1$GetEnumerator = $p.GetEnumerator;
            $p.MoveNext = function() {
                $top:
                while (true) {
                    switch (this.$state) {
                        case 0:
                            return false;
                        case 1:
                            this.$state = 0;
                            return false;
                    }
                }
            };
            $p.System$Collections$IEnumerator$MoveNext = $p.MoveNext;
        }).call($t, $t.YieldEnumerator$YieldBreak, $t.YieldEnumerator$YieldBreak.prototype);
        $WootzJs$Compiler$Tests$AssemblyTypes.push($t.YieldEnumerator$YieldBreak);
        function YieldEnumerator$ReturnOne($constructor) {
            if (!$t.YieldEnumerator$ReturnOne.$isStaticInitialized && ($constructor != null || !(this instanceof WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ReturnOne))) {
                $t.YieldEnumerator$ReturnOne.$isStaticInitialized = true;
                $t.YieldEnumerator$ReturnOne.$StaticInitializer();
            }
            if ($constructor != null)
                $constructor.apply(this, Array.prototype.slice.call(arguments, 1));
            if (!(this instanceof WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ReturnOne))
                return $t.YieldEnumerator$ReturnOne;
        }
        $t.YieldEnumerator$ReturnOne = YieldEnumerator$ReturnOne;
        $t.YieldEnumerator$ReturnOne.prototype = new System.YieldIterator$1();
        ($t.YieldEnumerator$ReturnOne.$TypeInitializer = function($t, $p) {
            $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
            $p.$type = WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ReturnOne;
            $t.$baseType = System.YieldIterator$1;
            $p.$typeName = "WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ReturnOne";
            $t.$typeName = $p.$typeName;
            $t.$GetType = function() {
                return System.Type._GetTypeFromTypeFunc(this);
            };
            $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("YieldEnumerator$ReturnOne", []);this.$type.Init("WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ReturnOne", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ReturnOne, (System.YieldIterator$1$(System.Object)), [System.Collections.Generic.IEnumerator$1, System.Collections.IEnumerator, System.IDisposable, System.Collections.Generic.IEnumerable$1, System.Collections.IEnumerable], [System.Reflection.FieldInfo.prototype.$ctor.$new("$state", System.Int32, System.Reflection.FieldAttributes().Private, null, []), System.Reflection.FieldInfo.prototype.$ctor.$new("$this", WootzJs.Compiler.Tests.YieldTests.YieldClass, System.Reflection.FieldAttributes().Private, null, [])], [System.Reflection.MethodInfo.prototype.$ctor.$new("GetEnumerator", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ReturnOne.prototype.GetEnumerator, [], System.Collections.IEnumerator, System.Reflection.MethodAttributes().Public, []), System.Reflection.MethodInfo.prototype.$ctor.$new("MoveNext", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ReturnOne.prototype.MoveNext, [], System.Boolean, System.Reflection.MethodAttributes().Public, [])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ReturnOne.prototype.$ctor, [System.Reflection.ParameterInfo.prototype.$ctor.$new("$this", WootzJs.Compiler.Tests.YieldTests.YieldClass, 0, 0, null, [])], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
            $t.$StaticInitializer = function() {
            };
            $p.$state = null;
            $p.$this = null;
            $p.$ctor = function($this) {
                (System.YieldIterator$1$(System.Object)).prototype.$ctor.call(this);
                this.$this = $this;
                this.$state = 1;
            };
            $p.$ctor.$type = $t;
            $p.$ctor.$new = function($this) {
                return new $p.$ctor.$type(this, $this);
            };
            $p.GetEnumerator = function() {
                return this;
            };
            $p.System$Collections$Generic$IEnumerable$1$GetEnumerator = $p.GetEnumerator;
            $p.MoveNext = function() {
                $top:
                while (true) {
                    switch (this.$state) {
                        case 0:
                            return false;
                        case 1:
                            this.$state = 0;
                            this.set_Current("one");
                            return true;
                    }
                }
            };
            $p.System$Collections$IEnumerator$MoveNext = $p.MoveNext;
        }).call($t, $t.YieldEnumerator$ReturnOne, $t.YieldEnumerator$ReturnOne.prototype);
        $WootzJs$Compiler$Tests$AssemblyTypes.push($t.YieldEnumerator$ReturnOne);
        function YieldEnumerator$ReturnTwo($constructor) {
            if (!$t.YieldEnumerator$ReturnTwo.$isStaticInitialized && ($constructor != null || !(this instanceof WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ReturnTwo))) {
                $t.YieldEnumerator$ReturnTwo.$isStaticInitialized = true;
                $t.YieldEnumerator$ReturnTwo.$StaticInitializer();
            }
            if ($constructor != null)
                $constructor.apply(this, Array.prototype.slice.call(arguments, 1));
            if (!(this instanceof WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ReturnTwo))
                return $t.YieldEnumerator$ReturnTwo;
        }
        $t.YieldEnumerator$ReturnTwo = YieldEnumerator$ReturnTwo;
        $t.YieldEnumerator$ReturnTwo.prototype = new System.YieldIterator$1();
        ($t.YieldEnumerator$ReturnTwo.$TypeInitializer = function($t, $p) {
            $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
            $p.$type = WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ReturnTwo;
            $t.$baseType = System.YieldIterator$1;
            $p.$typeName = "WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ReturnTwo";
            $t.$typeName = $p.$typeName;
            $t.$GetType = function() {
                return System.Type._GetTypeFromTypeFunc(this);
            };
            $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("YieldEnumerator$ReturnTwo", []);this.$type.Init("WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ReturnTwo", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ReturnTwo, (System.YieldIterator$1$(System.Object)), [System.Collections.Generic.IEnumerator$1, System.Collections.IEnumerator, System.IDisposable, System.Collections.Generic.IEnumerable$1, System.Collections.IEnumerable], [System.Reflection.FieldInfo.prototype.$ctor.$new("$state", System.Int32, System.Reflection.FieldAttributes().Private, null, []), System.Reflection.FieldInfo.prototype.$ctor.$new("$this", WootzJs.Compiler.Tests.YieldTests.YieldClass, System.Reflection.FieldAttributes().Private, null, [])], [System.Reflection.MethodInfo.prototype.$ctor.$new("GetEnumerator", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ReturnTwo.prototype.GetEnumerator, [], System.Collections.IEnumerator, System.Reflection.MethodAttributes().Public, []), System.Reflection.MethodInfo.prototype.$ctor.$new("MoveNext", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ReturnTwo.prototype.MoveNext, [], System.Boolean, System.Reflection.MethodAttributes().Public, [])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ReturnTwo.prototype.$ctor, [System.Reflection.ParameterInfo.prototype.$ctor.$new("$this", WootzJs.Compiler.Tests.YieldTests.YieldClass, 0, 0, null, [])], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
            $t.$StaticInitializer = function() {
            };
            $p.$state = null;
            $p.$this = null;
            $p.$ctor = function($this) {
                (System.YieldIterator$1$(System.Object)).prototype.$ctor.call(this);
                this.$this = $this;
                this.$state = 1;
            };
            $p.$ctor.$type = $t;
            $p.$ctor.$new = function($this) {
                return new $p.$ctor.$type(this, $this);
            };
            $p.GetEnumerator = function() {
                return this;
            };
            $p.System$Collections$Generic$IEnumerable$1$GetEnumerator = $p.GetEnumerator;
            $p.MoveNext = function() {
                $top:
                while (true) {
                    switch (this.$state) {
                        case 0:
                            return false;
                        case 1:
                            this.$state = 2;
                            this.set_Current("one");
                            return true;
                        case 2:
                            this.$state = 0;
                            this.set_Current("two");
                            return true;
                    }
                }
            };
            $p.System$Collections$IEnumerator$MoveNext = $p.MoveNext;
        }).call($t, $t.YieldEnumerator$ReturnTwo, $t.YieldEnumerator$ReturnTwo.prototype);
        $WootzJs$Compiler$Tests$AssemblyTypes.push($t.YieldEnumerator$ReturnTwo);
        function YieldEnumerator$IfStatement($constructor) {
            if (!$t.YieldEnumerator$IfStatement.$isStaticInitialized && ($constructor != null || !(this instanceof WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$IfStatement))) {
                $t.YieldEnumerator$IfStatement.$isStaticInitialized = true;
                $t.YieldEnumerator$IfStatement.$StaticInitializer();
            }
            if ($constructor != null)
                $constructor.apply(this, Array.prototype.slice.call(arguments, 1));
            if (!(this instanceof WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$IfStatement))
                return $t.YieldEnumerator$IfStatement;
        }
        $t.YieldEnumerator$IfStatement = YieldEnumerator$IfStatement;
        $t.YieldEnumerator$IfStatement.prototype = new System.YieldIterator$1();
        ($t.YieldEnumerator$IfStatement.$TypeInitializer = function($t, $p) {
            $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
            $p.$type = WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$IfStatement;
            $t.$baseType = System.YieldIterator$1;
            $p.$typeName = "WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$IfStatement";
            $t.$typeName = $p.$typeName;
            $t.$GetType = function() {
                return System.Type._GetTypeFromTypeFunc(this);
            };
            $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("YieldEnumerator$IfStatement", []);this.$type.Init("WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$IfStatement", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$IfStatement, (System.YieldIterator$1$(System.Object)), [System.Collections.Generic.IEnumerator$1, System.Collections.IEnumerator, System.IDisposable, System.Collections.Generic.IEnumerable$1, System.Collections.IEnumerable], [System.Reflection.FieldInfo.prototype.$ctor.$new("$state", System.Int32, System.Reflection.FieldAttributes().Private, null, []), System.Reflection.FieldInfo.prototype.$ctor.$new("$this", WootzJs.Compiler.Tests.YieldTests.YieldClass, System.Reflection.FieldAttributes().Private, null, []), System.Reflection.FieldInfo.prototype.$ctor.$new("flag", System.Boolean, System.Reflection.FieldAttributes().Private, null, [])], [System.Reflection.MethodInfo.prototype.$ctor.$new("GetEnumerator", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$IfStatement.prototype.GetEnumerator, [], System.Collections.IEnumerator, System.Reflection.MethodAttributes().Public, []), System.Reflection.MethodInfo.prototype.$ctor.$new("MoveNext", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$IfStatement.prototype.MoveNext, [], System.Boolean, System.Reflection.MethodAttributes().Public, [])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$IfStatement.prototype.$ctor, [System.Reflection.ParameterInfo.prototype.$ctor.$new("$this", WootzJs.Compiler.Tests.YieldTests.YieldClass, 0, 0, null, []), System.Reflection.ParameterInfo.prototype.$ctor.$new("flag", System.Boolean, 1, 0, null, [])], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
            $t.$StaticInitializer = function() {
            };
            $p.$state = null;
            $p.$this = null;
            $p.flag = null;
            $p.$ctor = function($this, flag) {
                (System.YieldIterator$1$(System.Object)).prototype.$ctor.call(this);
                this.$this = $this;
                this.flag = flag;
                this.$state = 1;
            };
            $p.$ctor.$type = $t;
            $p.$ctor.$new = function($this, flag) {
                return new $p.$ctor.$type(this, $this, flag);
            };
            $p.GetEnumerator = function() {
                return this;
            };
            $p.System$Collections$Generic$IEnumerable$1$GetEnumerator = $p.GetEnumerator;
            $p.MoveNext = function() {
                $top:
                while (true) {
                    switch (this.$state) {
                        case 0:
                            return false;
                        case 1:
                            if (this.flag) {
                                this.$state = 0;
                                this.set_Current("true");
                                return true;
                            }
                            else {
                                this.$state = 0;
                                this.set_Current("false");
                                return true;
                            }
                            this.$state = 0;
                            continue $top;
                    }
                }
            };
            $p.System$Collections$IEnumerator$MoveNext = $p.MoveNext;
        }).call($t, $t.YieldEnumerator$IfStatement, $t.YieldEnumerator$IfStatement.prototype);
        $WootzJs$Compiler$Tests$AssemblyTypes.push($t.YieldEnumerator$IfStatement);
        function YieldEnumerator$IfStatementTwoItems($constructor) {
            if (!$t.YieldEnumerator$IfStatementTwoItems.$isStaticInitialized && ($constructor != null || !(this instanceof WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$IfStatementTwoItems))) {
                $t.YieldEnumerator$IfStatementTwoItems.$isStaticInitialized = true;
                $t.YieldEnumerator$IfStatementTwoItems.$StaticInitializer();
            }
            if ($constructor != null)
                $constructor.apply(this, Array.prototype.slice.call(arguments, 1));
            if (!(this instanceof WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$IfStatementTwoItems))
                return $t.YieldEnumerator$IfStatementTwoItems;
        }
        $t.YieldEnumerator$IfStatementTwoItems = YieldEnumerator$IfStatementTwoItems;
        $t.YieldEnumerator$IfStatementTwoItems.prototype = new System.YieldIterator$1();
        ($t.YieldEnumerator$IfStatementTwoItems.$TypeInitializer = function($t, $p) {
            $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
            $p.$type = WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$IfStatementTwoItems;
            $t.$baseType = System.YieldIterator$1;
            $p.$typeName = "WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$IfStatementTwoItems";
            $t.$typeName = $p.$typeName;
            $t.$GetType = function() {
                return System.Type._GetTypeFromTypeFunc(this);
            };
            $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("YieldEnumerator$IfStatementTwoItems", []);this.$type.Init("WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$IfStatementTwoItems", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$IfStatementTwoItems, (System.YieldIterator$1$(System.Object)), [System.Collections.Generic.IEnumerator$1, System.Collections.IEnumerator, System.IDisposable, System.Collections.Generic.IEnumerable$1, System.Collections.IEnumerable], [System.Reflection.FieldInfo.prototype.$ctor.$new("$state", System.Int32, System.Reflection.FieldAttributes().Private, null, []), System.Reflection.FieldInfo.prototype.$ctor.$new("$this", WootzJs.Compiler.Tests.YieldTests.YieldClass, System.Reflection.FieldAttributes().Private, null, []), System.Reflection.FieldInfo.prototype.$ctor.$new("flag", System.Boolean, System.Reflection.FieldAttributes().Private, null, [])], [System.Reflection.MethodInfo.prototype.$ctor.$new("GetEnumerator", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$IfStatementTwoItems.prototype.GetEnumerator, [], System.Collections.IEnumerator, System.Reflection.MethodAttributes().Public, []), System.Reflection.MethodInfo.prototype.$ctor.$new("MoveNext", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$IfStatementTwoItems.prototype.MoveNext, [], System.Boolean, System.Reflection.MethodAttributes().Public, [])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$IfStatementTwoItems.prototype.$ctor, [System.Reflection.ParameterInfo.prototype.$ctor.$new("$this", WootzJs.Compiler.Tests.YieldTests.YieldClass, 0, 0, null, []), System.Reflection.ParameterInfo.prototype.$ctor.$new("flag", System.Boolean, 1, 0, null, [])], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
            $t.$StaticInitializer = function() {
            };
            $p.$state = null;
            $p.$this = null;
            $p.flag = null;
            $p.$ctor = function($this, flag) {
                (System.YieldIterator$1$(System.Object)).prototype.$ctor.call(this);
                this.$this = $this;
                this.flag = flag;
                this.$state = 1;
            };
            $p.$ctor.$type = $t;
            $p.$ctor.$new = function($this, flag) {
                return new $p.$ctor.$type(this, $this, flag);
            };
            $p.GetEnumerator = function() {
                return this;
            };
            $p.System$Collections$Generic$IEnumerable$1$GetEnumerator = $p.GetEnumerator;
            $p.MoveNext = function() {
                $top:
                while (true) {
                    switch (this.$state) {
                        case 0:
                            return false;
                        case 1:
                            if (this.flag) {
                                this.$state = 2;
                                this.set_Current("one");
                                return true;
                            }
                            else {
                                this.$state = 3;
                                this.set_Current("three");
                                return true;
                            }
                            this.$state = 0;
                            continue $top;
                        case 2:
                            this.$state = 0;
                            this.set_Current("two");
                            return true;
                        case 3:
                            this.$state = 0;
                            this.set_Current("four");
                            return true;
                    }
                }
            };
            $p.System$Collections$IEnumerator$MoveNext = $p.MoveNext;
        }).call($t, $t.YieldEnumerator$IfStatementTwoItems, $t.YieldEnumerator$IfStatementTwoItems.prototype);
        $WootzJs$Compiler$Tests$AssemblyTypes.push($t.YieldEnumerator$IfStatementTwoItems);
        function YieldEnumerator$NestedIf($constructor) {
            if (!$t.YieldEnumerator$NestedIf.$isStaticInitialized && ($constructor != null || !(this instanceof WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$NestedIf))) {
                $t.YieldEnumerator$NestedIf.$isStaticInitialized = true;
                $t.YieldEnumerator$NestedIf.$StaticInitializer();
            }
            if ($constructor != null)
                $constructor.apply(this, Array.prototype.slice.call(arguments, 1));
            if (!(this instanceof WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$NestedIf))
                return $t.YieldEnumerator$NestedIf;
        }
        $t.YieldEnumerator$NestedIf = YieldEnumerator$NestedIf;
        $t.YieldEnumerator$NestedIf.prototype = new System.YieldIterator$1();
        ($t.YieldEnumerator$NestedIf.$TypeInitializer = function($t, $p) {
            $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
            $p.$type = WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$NestedIf;
            $t.$baseType = System.YieldIterator$1;
            $p.$typeName = "WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$NestedIf";
            $t.$typeName = $p.$typeName;
            $t.$GetType = function() {
                return System.Type._GetTypeFromTypeFunc(this);
            };
            $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("YieldEnumerator$NestedIf", []);this.$type.Init("WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$NestedIf", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$NestedIf, (System.YieldIterator$1$(System.Object)), [System.Collections.Generic.IEnumerator$1, System.Collections.IEnumerator, System.IDisposable, System.Collections.Generic.IEnumerable$1, System.Collections.IEnumerable], [System.Reflection.FieldInfo.prototype.$ctor.$new("$state", System.Int32, System.Reflection.FieldAttributes().Private, null, []), System.Reflection.FieldInfo.prototype.$ctor.$new("$this", WootzJs.Compiler.Tests.YieldTests.YieldClass, System.Reflection.FieldAttributes().Private, null, []), System.Reflection.FieldInfo.prototype.$ctor.$new("flag1", System.Boolean, System.Reflection.FieldAttributes().Private, null, []), System.Reflection.FieldInfo.prototype.$ctor.$new("flag2", System.Boolean, System.Reflection.FieldAttributes().Private, null, [])], [System.Reflection.MethodInfo.prototype.$ctor.$new("GetEnumerator", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$NestedIf.prototype.GetEnumerator, [], System.Collections.IEnumerator, System.Reflection.MethodAttributes().Public, []), System.Reflection.MethodInfo.prototype.$ctor.$new("MoveNext", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$NestedIf.prototype.MoveNext, [], System.Boolean, System.Reflection.MethodAttributes().Public, [])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$NestedIf.prototype.$ctor, [System.Reflection.ParameterInfo.prototype.$ctor.$new("$this", WootzJs.Compiler.Tests.YieldTests.YieldClass, 0, 0, null, []), System.Reflection.ParameterInfo.prototype.$ctor.$new("flag1", System.Boolean, 1, 0, null, []), System.Reflection.ParameterInfo.prototype.$ctor.$new("flag2", System.Boolean, 2, 0, null, [])], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
            $t.$StaticInitializer = function() {
            };
            $p.$state = null;
            $p.$this = null;
            $p.flag1 = null;
            $p.flag2 = null;
            $p.$ctor = function($this, flag1, flag2) {
                (System.YieldIterator$1$(System.Object)).prototype.$ctor.call(this);
                this.$this = $this;
                this.flag1 = flag1;
                this.flag2 = flag2;
                this.$state = 1;
            };
            $p.$ctor.$type = $t;
            $p.$ctor.$new = function($this, flag1, flag2) {
                return new $p.$ctor.$type(
                    this, 
                    $this, 
                    flag1, 
                    flag2
                );
            };
            $p.GetEnumerator = function() {
                return this;
            };
            $p.System$Collections$Generic$IEnumerable$1$GetEnumerator = $p.GetEnumerator;
            $p.MoveNext = function() {
                $top:
                while (true) {
                    switch (this.$state) {
                        case 0:
                            return false;
                        case 1:
                            if (this.flag1) {
                                if (this.flag2) {
                                    this.$state = 0;
                                    this.set_Current("one");
                                    return true;
                                }
                                else {
                                    this.$state = 0;
                                    this.set_Current("two");
                                    return true;
                                }
                                this.$state = 0;
                                continue $top;
                            }
                            else {
                                if (this.flag2) {
                                    this.$state = 0;
                                    this.set_Current("three");
                                    return true;
                                }
                                else {
                                    this.$state = 0;
                                    this.set_Current("four");
                                    return true;
                                }
                                this.$state = 0;
                                continue $top;
                            }
                            this.$state = 0;
                            continue $top;
                    }
                }
            };
            $p.System$Collections$IEnumerator$MoveNext = $p.MoveNext;
        }).call($t, $t.YieldEnumerator$NestedIf, $t.YieldEnumerator$NestedIf.prototype);
        $WootzJs$Compiler$Tests$AssemblyTypes.push($t.YieldEnumerator$NestedIf);
        function YieldEnumerator$NestedIfTwoStatements($constructor) {
            if (!$t.YieldEnumerator$NestedIfTwoStatements.$isStaticInitialized && ($constructor != null || !(this instanceof WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$NestedIfTwoStatements))) {
                $t.YieldEnumerator$NestedIfTwoStatements.$isStaticInitialized = true;
                $t.YieldEnumerator$NestedIfTwoStatements.$StaticInitializer();
            }
            if ($constructor != null)
                $constructor.apply(this, Array.prototype.slice.call(arguments, 1));
            if (!(this instanceof WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$NestedIfTwoStatements))
                return $t.YieldEnumerator$NestedIfTwoStatements;
        }
        $t.YieldEnumerator$NestedIfTwoStatements = YieldEnumerator$NestedIfTwoStatements;
        $t.YieldEnumerator$NestedIfTwoStatements.prototype = new System.YieldIterator$1();
        ($t.YieldEnumerator$NestedIfTwoStatements.$TypeInitializer = function($t, $p) {
            $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
            $p.$type = WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$NestedIfTwoStatements;
            $t.$baseType = System.YieldIterator$1;
            $p.$typeName = "WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$NestedIfTwoStatements";
            $t.$typeName = $p.$typeName;
            $t.$GetType = function() {
                return System.Type._GetTypeFromTypeFunc(this);
            };
            $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("YieldEnumerator$NestedIfTwoStatements", []);this.$type.Init("WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$NestedIfTwoStatements", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$NestedIfTwoStatements, (System.YieldIterator$1$(System.Object)), [System.Collections.Generic.IEnumerator$1, System.Collections.IEnumerator, System.IDisposable, System.Collections.Generic.IEnumerable$1, System.Collections.IEnumerable], [System.Reflection.FieldInfo.prototype.$ctor.$new("$state", System.Int32, System.Reflection.FieldAttributes().Private, null, []), System.Reflection.FieldInfo.prototype.$ctor.$new("$this", WootzJs.Compiler.Tests.YieldTests.YieldClass, System.Reflection.FieldAttributes().Private, null, []), System.Reflection.FieldInfo.prototype.$ctor.$new("flag1", System.Boolean, System.Reflection.FieldAttributes().Private, null, []), System.Reflection.FieldInfo.prototype.$ctor.$new("flag2", System.Boolean, System.Reflection.FieldAttributes().Private, null, [])], [System.Reflection.MethodInfo.prototype.$ctor.$new("GetEnumerator", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$NestedIfTwoStatements.prototype.GetEnumerator, [], System.Collections.IEnumerator, System.Reflection.MethodAttributes().Public, []), System.Reflection.MethodInfo.prototype.$ctor.$new("MoveNext", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$NestedIfTwoStatements.prototype.MoveNext, [], System.Boolean, System.Reflection.MethodAttributes().Public, [])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$NestedIfTwoStatements.prototype.$ctor, [System.Reflection.ParameterInfo.prototype.$ctor.$new("$this", WootzJs.Compiler.Tests.YieldTests.YieldClass, 0, 0, null, []), System.Reflection.ParameterInfo.prototype.$ctor.$new("flag1", System.Boolean, 1, 0, null, []), System.Reflection.ParameterInfo.prototype.$ctor.$new("flag2", System.Boolean, 2, 0, null, [])], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
            $t.$StaticInitializer = function() {
            };
            $p.$state = null;
            $p.$this = null;
            $p.flag1 = null;
            $p.flag2 = null;
            $p.$ctor = function($this, flag1, flag2) {
                (System.YieldIterator$1$(System.Object)).prototype.$ctor.call(this);
                this.$this = $this;
                this.flag1 = flag1;
                this.flag2 = flag2;
                this.$state = 1;
            };
            $p.$ctor.$type = $t;
            $p.$ctor.$new = function($this, flag1, flag2) {
                return new $p.$ctor.$type(
                    this, 
                    $this, 
                    flag1, 
                    flag2
                );
            };
            $p.GetEnumerator = function() {
                return this;
            };
            $p.System$Collections$Generic$IEnumerable$1$GetEnumerator = $p.GetEnumerator;
            $p.MoveNext = function() {
                $top:
                while (true) {
                    switch (this.$state) {
                        case 0:
                            return false;
                        case 1:
                            if (this.flag1) {
                                if (this.flag2) {
                                    this.$state = 2;
                                    this.set_Current("one");
                                    return true;
                                }
                                else {
                                    this.$state = 3;
                                    this.set_Current("three");
                                    return true;
                                }
                                this.$state = 0;
                                continue $top;
                            }
                            else {
                                if (this.flag2) {
                                    this.$state = 4;
                                    this.set_Current("five");
                                    return true;
                                }
                                else {
                                    this.$state = 5;
                                    this.set_Current("seven");
                                    return true;
                                }
                                this.$state = 0;
                                continue $top;
                            }
                            this.$state = 0;
                            continue $top;
                        case 2:
                            this.$state = 0;
                            this.set_Current("two");
                            return true;
                        case 3:
                            this.$state = 0;
                            this.set_Current("four");
                            return true;
                        case 4:
                            this.$state = 0;
                            this.set_Current("six");
                            return true;
                        case 5:
                            this.$state = 0;
                            this.set_Current("eight");
                            return true;
                    }
                }
            };
            $p.System$Collections$IEnumerator$MoveNext = $p.MoveNext;
        }).call($t, $t.YieldEnumerator$NestedIfTwoStatements, $t.YieldEnumerator$NestedIfTwoStatements.prototype);
        $WootzJs$Compiler$Tests$AssemblyTypes.push($t.YieldEnumerator$NestedIfTwoStatements);
        function YieldEnumerator$ReturnAfterIf($constructor) {
            if (!$t.YieldEnumerator$ReturnAfterIf.$isStaticInitialized && ($constructor != null || !(this instanceof WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ReturnAfterIf))) {
                $t.YieldEnumerator$ReturnAfterIf.$isStaticInitialized = true;
                $t.YieldEnumerator$ReturnAfterIf.$StaticInitializer();
            }
            if ($constructor != null)
                $constructor.apply(this, Array.prototype.slice.call(arguments, 1));
            if (!(this instanceof WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ReturnAfterIf))
                return $t.YieldEnumerator$ReturnAfterIf;
        }
        $t.YieldEnumerator$ReturnAfterIf = YieldEnumerator$ReturnAfterIf;
        $t.YieldEnumerator$ReturnAfterIf.prototype = new System.YieldIterator$1();
        ($t.YieldEnumerator$ReturnAfterIf.$TypeInitializer = function($t, $p) {
            $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
            $p.$type = WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ReturnAfterIf;
            $t.$baseType = System.YieldIterator$1;
            $p.$typeName = "WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ReturnAfterIf";
            $t.$typeName = $p.$typeName;
            $t.$GetType = function() {
                return System.Type._GetTypeFromTypeFunc(this);
            };
            $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("YieldEnumerator$ReturnAfterIf", []);this.$type.Init("WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ReturnAfterIf", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ReturnAfterIf, (System.YieldIterator$1$(System.Object)), [System.Collections.Generic.IEnumerator$1, System.Collections.IEnumerator, System.IDisposable, System.Collections.Generic.IEnumerable$1, System.Collections.IEnumerable], [System.Reflection.FieldInfo.prototype.$ctor.$new("$state", System.Int32, System.Reflection.FieldAttributes().Private, null, []), System.Reflection.FieldInfo.prototype.$ctor.$new("$this", WootzJs.Compiler.Tests.YieldTests.YieldClass, System.Reflection.FieldAttributes().Private, null, []), System.Reflection.FieldInfo.prototype.$ctor.$new("flag", System.Boolean, System.Reflection.FieldAttributes().Private, null, [])], [System.Reflection.MethodInfo.prototype.$ctor.$new("GetEnumerator", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ReturnAfterIf.prototype.GetEnumerator, [], System.Collections.IEnumerator, System.Reflection.MethodAttributes().Public, []), System.Reflection.MethodInfo.prototype.$ctor.$new("MoveNext", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ReturnAfterIf.prototype.MoveNext, [], System.Boolean, System.Reflection.MethodAttributes().Public, [])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ReturnAfterIf.prototype.$ctor, [System.Reflection.ParameterInfo.prototype.$ctor.$new("$this", WootzJs.Compiler.Tests.YieldTests.YieldClass, 0, 0, null, []), System.Reflection.ParameterInfo.prototype.$ctor.$new("flag", System.Boolean, 1, 0, null, [])], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
            $t.$StaticInitializer = function() {
            };
            $p.$state = null;
            $p.$this = null;
            $p.flag = null;
            $p.$ctor = function($this, flag) {
                (System.YieldIterator$1$(System.Object)).prototype.$ctor.call(this);
                this.$this = $this;
                this.flag = flag;
                this.$state = 1;
            };
            $p.$ctor.$type = $t;
            $p.$ctor.$new = function($this, flag) {
                return new $p.$ctor.$type(this, $this, flag);
            };
            $p.GetEnumerator = function() {
                return this;
            };
            $p.System$Collections$Generic$IEnumerable$1$GetEnumerator = $p.GetEnumerator;
            $p.MoveNext = function() {
                $top:
                while (true) {
                    switch (this.$state) {
                        case 0:
                            return false;
                        case 1:
                            this.$state = 2;
                            this.set_Current("zero");
                            return true;
                        case 2:
                            if (this.flag) {
                                this.$state = 4;
                                this.set_Current("one");
                                return true;
                            }
                            else {
                                this.$state = 5;
                                this.set_Current("three");
                                return true;
                            }
                            this.$state = 3;
                            continue $top;
                        case 3:
                            this.$state = 6;
                            this.set_Current("five");
                            return true;
                        case 4:
                            this.$state = 3;
                            this.set_Current("two");
                            return true;
                        case 5:
                            this.$state = 3;
                            this.set_Current("four");
                            return true;
                        case 6:
                            this.$state = 0;
                            this.set_Current("six");
                            return true;
                    }
                }
            };
            $p.System$Collections$IEnumerator$MoveNext = $p.MoveNext;
        }).call($t, $t.YieldEnumerator$ReturnAfterIf, $t.YieldEnumerator$ReturnAfterIf.prototype);
        $WootzJs$Compiler$Tests$AssemblyTypes.push($t.YieldEnumerator$ReturnAfterIf);
        function YieldEnumerator$InitializeVariable($constructor) {
            if (!$t.YieldEnumerator$InitializeVariable.$isStaticInitialized && ($constructor != null || !(this instanceof WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$InitializeVariable))) {
                $t.YieldEnumerator$InitializeVariable.$isStaticInitialized = true;
                $t.YieldEnumerator$InitializeVariable.$StaticInitializer();
            }
            if ($constructor != null)
                $constructor.apply(this, Array.prototype.slice.call(arguments, 1));
            if (!(this instanceof WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$InitializeVariable))
                return $t.YieldEnumerator$InitializeVariable;
        }
        $t.YieldEnumerator$InitializeVariable = YieldEnumerator$InitializeVariable;
        $t.YieldEnumerator$InitializeVariable.prototype = new System.YieldIterator$1();
        ($t.YieldEnumerator$InitializeVariable.$TypeInitializer = function($t, $p) {
            $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
            $p.$type = WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$InitializeVariable;
            $t.$baseType = System.YieldIterator$1;
            $p.$typeName = "WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$InitializeVariable";
            $t.$typeName = $p.$typeName;
            $t.$GetType = function() {
                return System.Type._GetTypeFromTypeFunc(this);
            };
            $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("YieldEnumerator$InitializeVariable", []);this.$type.Init("WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$InitializeVariable", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$InitializeVariable, (System.YieldIterator$1$(System.Object)), [System.Collections.Generic.IEnumerator$1, System.Collections.IEnumerator, System.IDisposable, System.Collections.Generic.IEnumerable$1, System.Collections.IEnumerable], [System.Reflection.FieldInfo.prototype.$ctor.$new("$state", System.Int32, System.Reflection.FieldAttributes().Private, null, []), System.Reflection.FieldInfo.prototype.$ctor.$new("$this", WootzJs.Compiler.Tests.YieldTests.YieldClass, System.Reflection.FieldAttributes().Private, null, []), System.Reflection.FieldInfo.prototype.$ctor.$new("s", String, System.Reflection.FieldAttributes().Private, null, [])], [System.Reflection.MethodInfo.prototype.$ctor.$new("GetEnumerator", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$InitializeVariable.prototype.GetEnumerator, [], System.Collections.IEnumerator, System.Reflection.MethodAttributes().Public, []), System.Reflection.MethodInfo.prototype.$ctor.$new("MoveNext", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$InitializeVariable.prototype.MoveNext, [], System.Boolean, System.Reflection.MethodAttributes().Public, [])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$InitializeVariable.prototype.$ctor, [System.Reflection.ParameterInfo.prototype.$ctor.$new("$this", WootzJs.Compiler.Tests.YieldTests.YieldClass, 0, 0, null, [])], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
            $t.$StaticInitializer = function() {
            };
            $p.$state = null;
            $p.$this = null;
            $p.s = null;
            $p.$ctor = function($this) {
                (System.YieldIterator$1$(System.Object)).prototype.$ctor.call(this);
                this.$this = $this;
                this.$state = 1;
            };
            $p.$ctor.$type = $t;
            $p.$ctor.$new = function($this) {
                return new $p.$ctor.$type(this, $this);
            };
            $p.GetEnumerator = function() {
                return this;
            };
            $p.System$Collections$Generic$IEnumerable$1$GetEnumerator = $p.GetEnumerator;
            $p.MoveNext = function() {
                $top:
                while (true) {
                    switch (this.$state) {
                        case 0:
                            return false;
                        case 1:
                            this.s = "foo";
                            this.$state = 0;
                            this.set_Current(this.s);
                            return true;
                    }
                }
            };
            $p.System$Collections$IEnumerator$MoveNext = $p.MoveNext;
        }).call($t, $t.YieldEnumerator$InitializeVariable, $t.YieldEnumerator$InitializeVariable.prototype);
        $WootzJs$Compiler$Tests$AssemblyTypes.push($t.YieldEnumerator$InitializeVariable);
        function YieldEnumerator$WhileLoop($constructor) {
            if (!$t.YieldEnumerator$WhileLoop.$isStaticInitialized && ($constructor != null || !(this instanceof WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$WhileLoop))) {
                $t.YieldEnumerator$WhileLoop.$isStaticInitialized = true;
                $t.YieldEnumerator$WhileLoop.$StaticInitializer();
            }
            if ($constructor != null)
                $constructor.apply(this, Array.prototype.slice.call(arguments, 1));
            if (!(this instanceof WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$WhileLoop))
                return $t.YieldEnumerator$WhileLoop;
        }
        $t.YieldEnumerator$WhileLoop = YieldEnumerator$WhileLoop;
        $t.YieldEnumerator$WhileLoop.prototype = new System.YieldIterator$1();
        ($t.YieldEnumerator$WhileLoop.$TypeInitializer = function($t, $p) {
            $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
            $p.$type = WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$WhileLoop;
            $t.$baseType = System.YieldIterator$1;
            $p.$typeName = "WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$WhileLoop";
            $t.$typeName = $p.$typeName;
            $t.$GetType = function() {
                return System.Type._GetTypeFromTypeFunc(this);
            };
            $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("YieldEnumerator$WhileLoop", []);this.$type.Init("WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$WhileLoop", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$WhileLoop, (System.YieldIterator$1$(System.Object)), [System.Collections.Generic.IEnumerator$1, System.Collections.IEnumerator, System.IDisposable, System.Collections.Generic.IEnumerable$1, System.Collections.IEnumerable], [System.Reflection.FieldInfo.prototype.$ctor.$new("$state", System.Int32, System.Reflection.FieldAttributes().Private, null, []), System.Reflection.FieldInfo.prototype.$ctor.$new("$this", WootzJs.Compiler.Tests.YieldTests.YieldClass, System.Reflection.FieldAttributes().Private, null, []), System.Reflection.FieldInfo.prototype.$ctor.$new("i", System.Int32, System.Reflection.FieldAttributes().Private, null, [])], [System.Reflection.MethodInfo.prototype.$ctor.$new("GetEnumerator", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$WhileLoop.prototype.GetEnumerator, [], System.Collections.IEnumerator, System.Reflection.MethodAttributes().Public, []), System.Reflection.MethodInfo.prototype.$ctor.$new("MoveNext", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$WhileLoop.prototype.MoveNext, [], System.Boolean, System.Reflection.MethodAttributes().Public, [])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$WhileLoop.prototype.$ctor, [System.Reflection.ParameterInfo.prototype.$ctor.$new("$this", WootzJs.Compiler.Tests.YieldTests.YieldClass, 0, 0, null, [])], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
            $t.$StaticInitializer = function() {
            };
            $p.$state = null;
            $p.$this = null;
            $p.i = null;
            $p.$ctor = function($this) {
                (System.YieldIterator$1$(System.Object)).prototype.$ctor.call(this);
                this.$this = $this;
                this.$state = 1;
            };
            $p.$ctor.$type = $t;
            $p.$ctor.$new = function($this) {
                return new $p.$ctor.$type(this, $this);
            };
            $p.GetEnumerator = function() {
                return this;
            };
            $p.System$Collections$Generic$IEnumerable$1$GetEnumerator = $p.GetEnumerator;
            $p.MoveNext = function() {
                $top:
                while (true) {
                    switch (this.$state) {
                        case 0:
                            return false;
                        case 1:
                            this.i = 0;
                            this.$state = 2;
                            continue $top;
                        case 2:
                            while (this.i < 3) {
                                this.$state = 3;
                                this.set_Current(this.i);
                                return true;
                            }
                            this.$state = 0;
                            continue $top;
                        case 3:
                            this.i++;
                            this.$state = 2;
                            continue $top;
                    }
                }
            };
            $p.System$Collections$IEnumerator$MoveNext = $p.MoveNext;
        }).call($t, $t.YieldEnumerator$WhileLoop, $t.YieldEnumerator$WhileLoop.prototype);
        $WootzJs$Compiler$Tests$AssemblyTypes.push($t.YieldEnumerator$WhileLoop);
        function YieldEnumerator$IfWithErrataAfterYield($constructor) {
            if (!$t.YieldEnumerator$IfWithErrataAfterYield.$isStaticInitialized && ($constructor != null || !(this instanceof WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$IfWithErrataAfterYield))) {
                $t.YieldEnumerator$IfWithErrataAfterYield.$isStaticInitialized = true;
                $t.YieldEnumerator$IfWithErrataAfterYield.$StaticInitializer();
            }
            if ($constructor != null)
                $constructor.apply(this, Array.prototype.slice.call(arguments, 1));
            if (!(this instanceof WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$IfWithErrataAfterYield))
                return $t.YieldEnumerator$IfWithErrataAfterYield;
        }
        $t.YieldEnumerator$IfWithErrataAfterYield = YieldEnumerator$IfWithErrataAfterYield;
        $t.YieldEnumerator$IfWithErrataAfterYield.prototype = new System.YieldIterator$1();
        ($t.YieldEnumerator$IfWithErrataAfterYield.$TypeInitializer = function($t, $p) {
            $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
            $p.$type = WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$IfWithErrataAfterYield;
            $t.$baseType = System.YieldIterator$1;
            $p.$typeName = "WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$IfWithErrataAfterYield";
            $t.$typeName = $p.$typeName;
            $t.$GetType = function() {
                return System.Type._GetTypeFromTypeFunc(this);
            };
            $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("YieldEnumerator$IfWithErrataAfterYield", []);this.$type.Init("WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$IfWithErrataAfterYield", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$IfWithErrataAfterYield, (System.YieldIterator$1$(System.Object)), [System.Collections.Generic.IEnumerator$1, System.Collections.IEnumerator, System.IDisposable, System.Collections.Generic.IEnumerable$1, System.Collections.IEnumerable], [System.Reflection.FieldInfo.prototype.$ctor.$new("$state", System.Int32, System.Reflection.FieldAttributes().Private, null, []), System.Reflection.FieldInfo.prototype.$ctor.$new("$this", WootzJs.Compiler.Tests.YieldTests.YieldClass, System.Reflection.FieldAttributes().Private, null, []), System.Reflection.FieldInfo.prototype.$ctor.$new("flag", System.Boolean, System.Reflection.FieldAttributes().Private, null, []), System.Reflection.FieldInfo.prototype.$ctor.$new("i", System.Int32, System.Reflection.FieldAttributes().Private, null, [])], [System.Reflection.MethodInfo.prototype.$ctor.$new("GetEnumerator", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$IfWithErrataAfterYield.prototype.GetEnumerator, [], System.Collections.IEnumerator, System.Reflection.MethodAttributes().Public, []), System.Reflection.MethodInfo.prototype.$ctor.$new("MoveNext", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$IfWithErrataAfterYield.prototype.MoveNext, [], System.Boolean, System.Reflection.MethodAttributes().Public, [])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$IfWithErrataAfterYield.prototype.$ctor, [System.Reflection.ParameterInfo.prototype.$ctor.$new("$this", WootzJs.Compiler.Tests.YieldTests.YieldClass, 0, 0, null, []), System.Reflection.ParameterInfo.prototype.$ctor.$new("flag", System.Boolean, 1, 0, null, [])], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
            $t.$StaticInitializer = function() {
            };
            $p.$state = null;
            $p.$this = null;
            $p.flag = null;
            $p.i = null;
            $p.$ctor = function($this, flag) {
                (System.YieldIterator$1$(System.Object)).prototype.$ctor.call(this);
                this.$this = $this;
                this.flag = flag;
                this.$state = 1;
            };
            $p.$ctor.$type = $t;
            $p.$ctor.$new = function($this, flag) {
                return new $p.$ctor.$type(this, $this, flag);
            };
            $p.GetEnumerator = function() {
                return this;
            };
            $p.System$Collections$Generic$IEnumerable$1$GetEnumerator = $p.GetEnumerator;
            $p.MoveNext = function() {
                $top:
                while (true) {
                    switch (this.$state) {
                        case 0:
                            return false;
                        case 1:
                            this.i = 0;
                            if (this.flag) {
                                this.$state = 3;
                                this.set_Current(this.i);
                                return true;
                            }
                            this.$state = 2;
                            continue $top;
                        case 2:
                            this.$state = 0;
                            this.set_Current(this.i);
                            return true;
                        case 3:
                            this.i++;
                            this.$state = 2;
                            continue $top;
                    }
                }
            };
            $p.System$Collections$IEnumerator$MoveNext = $p.MoveNext;
        }).call($t, $t.YieldEnumerator$IfWithErrataAfterYield, $t.YieldEnumerator$IfWithErrataAfterYield.prototype);
        $WootzJs$Compiler$Tests$AssemblyTypes.push($t.YieldEnumerator$IfWithErrataAfterYield);
        function YieldEnumerator$ForLoop($constructor) {
            if (!$t.YieldEnumerator$ForLoop.$isStaticInitialized && ($constructor != null || !(this instanceof WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ForLoop))) {
                $t.YieldEnumerator$ForLoop.$isStaticInitialized = true;
                $t.YieldEnumerator$ForLoop.$StaticInitializer();
            }
            if ($constructor != null)
                $constructor.apply(this, Array.prototype.slice.call(arguments, 1));
            if (!(this instanceof WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ForLoop))
                return $t.YieldEnumerator$ForLoop;
        }
        $t.YieldEnumerator$ForLoop = YieldEnumerator$ForLoop;
        $t.YieldEnumerator$ForLoop.prototype = new System.YieldIterator$1();
        ($t.YieldEnumerator$ForLoop.$TypeInitializer = function($t, $p) {
            $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
            $p.$type = WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ForLoop;
            $t.$baseType = System.YieldIterator$1;
            $p.$typeName = "WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ForLoop";
            $t.$typeName = $p.$typeName;
            $t.$GetType = function() {
                return System.Type._GetTypeFromTypeFunc(this);
            };
            $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("YieldEnumerator$ForLoop", []);this.$type.Init("WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ForLoop", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ForLoop, (System.YieldIterator$1$(System.Object)), [System.Collections.Generic.IEnumerator$1, System.Collections.IEnumerator, System.IDisposable, System.Collections.Generic.IEnumerable$1, System.Collections.IEnumerable], [System.Reflection.FieldInfo.prototype.$ctor.$new("$state", System.Int32, System.Reflection.FieldAttributes().Private, null, []), System.Reflection.FieldInfo.prototype.$ctor.$new("$this", WootzJs.Compiler.Tests.YieldTests.YieldClass, System.Reflection.FieldAttributes().Private, null, []), System.Reflection.FieldInfo.prototype.$ctor.$new("i", System.Int32, System.Reflection.FieldAttributes().Private, null, [])], [System.Reflection.MethodInfo.prototype.$ctor.$new("GetEnumerator", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ForLoop.prototype.GetEnumerator, [], System.Collections.IEnumerator, System.Reflection.MethodAttributes().Public, []), System.Reflection.MethodInfo.prototype.$ctor.$new("MoveNext", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ForLoop.prototype.MoveNext, [], System.Boolean, System.Reflection.MethodAttributes().Public, [])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ForLoop.prototype.$ctor, [System.Reflection.ParameterInfo.prototype.$ctor.$new("$this", WootzJs.Compiler.Tests.YieldTests.YieldClass, 0, 0, null, [])], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
            $t.$StaticInitializer = function() {
            };
            $p.$state = null;
            $p.$this = null;
            $p.i = null;
            $p.$ctor = function($this) {
                (System.YieldIterator$1$(System.Object)).prototype.$ctor.call(this);
                this.$this = $this;
                this.$state = 1;
            };
            $p.$ctor.$type = $t;
            $p.$ctor.$new = function($this) {
                return new $p.$ctor.$type(this, $this);
            };
            $p.GetEnumerator = function() {
                return this;
            };
            $p.System$Collections$Generic$IEnumerable$1$GetEnumerator = $p.GetEnumerator;
            $p.MoveNext = function() {
                $top:
                while (true) {
                    switch (this.$state) {
                        case 0:
                            return false;
                        case 1:
                            this.i = 0;
                            this.$state = 2;
                            continue $top;
                        case 2:
                            while (this.i < 3) {
                                this.$state = 3;
                                this.set_Current(this.i);
                                return true;
                            }
                            this.$state = 0;
                            continue $top;
                        case 3:
                            this.i++;
                            this.$state = 2;
                            continue $top;
                    }
                }
            };
            $p.System$Collections$IEnumerator$MoveNext = $p.MoveNext;
        }).call($t, $t.YieldEnumerator$ForLoop, $t.YieldEnumerator$ForLoop.prototype);
        $WootzJs$Compiler$Tests$AssemblyTypes.push($t.YieldEnumerator$ForLoop);
        function YieldEnumerator$ForLoopNoVariableWithInitializer($constructor) {
            if (!$t.YieldEnumerator$ForLoopNoVariableWithInitializer.$isStaticInitialized && ($constructor != null || !(this instanceof WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ForLoopNoVariableWithInitializer))) {
                $t.YieldEnumerator$ForLoopNoVariableWithInitializer.$isStaticInitialized = true;
                $t.YieldEnumerator$ForLoopNoVariableWithInitializer.$StaticInitializer();
            }
            if ($constructor != null)
                $constructor.apply(this, Array.prototype.slice.call(arguments, 1));
            if (!(this instanceof WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ForLoopNoVariableWithInitializer))
                return $t.YieldEnumerator$ForLoopNoVariableWithInitializer;
        }
        $t.YieldEnumerator$ForLoopNoVariableWithInitializer = YieldEnumerator$ForLoopNoVariableWithInitializer;
        $t.YieldEnumerator$ForLoopNoVariableWithInitializer.prototype = new System.YieldIterator$1();
        ($t.YieldEnumerator$ForLoopNoVariableWithInitializer.$TypeInitializer = function($t, $p) {
            $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
            $p.$type = WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ForLoopNoVariableWithInitializer;
            $t.$baseType = System.YieldIterator$1;
            $p.$typeName = "WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ForLoopNoVariableWithInitializer";
            $t.$typeName = $p.$typeName;
            $t.$GetType = function() {
                return System.Type._GetTypeFromTypeFunc(this);
            };
            $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("YieldEnumerator$ForLoopNoVariableWithInitializer", []);this.$type.Init("WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ForLoopNoVariableWithInitializer", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ForLoopNoVariableWithInitializer, (System.YieldIterator$1$(System.Object)), [System.Collections.Generic.IEnumerator$1, System.Collections.IEnumerator, System.IDisposable, System.Collections.Generic.IEnumerable$1, System.Collections.IEnumerable], [System.Reflection.FieldInfo.prototype.$ctor.$new("$state", System.Int32, System.Reflection.FieldAttributes().Private, null, []), System.Reflection.FieldInfo.prototype.$ctor.$new("$this", WootzJs.Compiler.Tests.YieldTests.YieldClass, System.Reflection.FieldAttributes().Private, null, []), System.Reflection.FieldInfo.prototype.$ctor.$new("i", System.Int32, System.Reflection.FieldAttributes().Private, null, [])], [System.Reflection.MethodInfo.prototype.$ctor.$new("GetEnumerator", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ForLoopNoVariableWithInitializer.prototype.GetEnumerator, [], System.Collections.IEnumerator, System.Reflection.MethodAttributes().Public, []), System.Reflection.MethodInfo.prototype.$ctor.$new("MoveNext", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ForLoopNoVariableWithInitializer.prototype.MoveNext, [], System.Boolean, System.Reflection.MethodAttributes().Public, [])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ForLoopNoVariableWithInitializer.prototype.$ctor, [System.Reflection.ParameterInfo.prototype.$ctor.$new("$this", WootzJs.Compiler.Tests.YieldTests.YieldClass, 0, 0, null, [])], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
            $t.$StaticInitializer = function() {
            };
            $p.$state = null;
            $p.$this = null;
            $p.i = null;
            $p.$ctor = function($this) {
                (System.YieldIterator$1$(System.Object)).prototype.$ctor.call(this);
                this.$this = $this;
                this.$state = 1;
            };
            $p.$ctor.$type = $t;
            $p.$ctor.$new = function($this) {
                return new $p.$ctor.$type(this, $this);
            };
            $p.GetEnumerator = function() {
                return this;
            };
            $p.System$Collections$Generic$IEnumerable$1$GetEnumerator = $p.GetEnumerator;
            $p.MoveNext = function() {
                $top:
                while (true) {
                    switch (this.$state) {
                        case 0:
                            return false;
                        case 1:
                            this.i = 0;
                            this.$state = 2;
                            continue $top;
                        case 2:
                            while (this.i < 3) {
                                this.$state = 3;
                                this.set_Current(this.i);
                                return true;
                            }
                            this.$state = 0;
                            continue $top;
                        case 3:
                            this.i++;
                            this.$state = 2;
                            continue $top;
                    }
                }
            };
            $p.System$Collections$IEnumerator$MoveNext = $p.MoveNext;
        }).call($t, $t.YieldEnumerator$ForLoopNoVariableWithInitializer, $t.YieldEnumerator$ForLoopNoVariableWithInitializer.prototype);
        $WootzJs$Compiler$Tests$AssemblyTypes.push($t.YieldEnumerator$ForLoopNoVariableWithInitializer);
        function YieldEnumerator$ForLoopNoVariableNoInitializer($constructor) {
            if (!$t.YieldEnumerator$ForLoopNoVariableNoInitializer.$isStaticInitialized && ($constructor != null || !(this instanceof WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ForLoopNoVariableNoInitializer))) {
                $t.YieldEnumerator$ForLoopNoVariableNoInitializer.$isStaticInitialized = true;
                $t.YieldEnumerator$ForLoopNoVariableNoInitializer.$StaticInitializer();
            }
            if ($constructor != null)
                $constructor.apply(this, Array.prototype.slice.call(arguments, 1));
            if (!(this instanceof WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ForLoopNoVariableNoInitializer))
                return $t.YieldEnumerator$ForLoopNoVariableNoInitializer;
        }
        $t.YieldEnumerator$ForLoopNoVariableNoInitializer = YieldEnumerator$ForLoopNoVariableNoInitializer;
        $t.YieldEnumerator$ForLoopNoVariableNoInitializer.prototype = new System.YieldIterator$1();
        ($t.YieldEnumerator$ForLoopNoVariableNoInitializer.$TypeInitializer = function($t, $p) {
            $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
            $p.$type = WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ForLoopNoVariableNoInitializer;
            $t.$baseType = System.YieldIterator$1;
            $p.$typeName = "WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ForLoopNoVariableNoInitializer";
            $t.$typeName = $p.$typeName;
            $t.$GetType = function() {
                return System.Type._GetTypeFromTypeFunc(this);
            };
            $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("YieldEnumerator$ForLoopNoVariableNoInitializer", []);this.$type.Init("WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ForLoopNoVariableNoInitializer", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ForLoopNoVariableNoInitializer, (System.YieldIterator$1$(System.Object)), [System.Collections.Generic.IEnumerator$1, System.Collections.IEnumerator, System.IDisposable, System.Collections.Generic.IEnumerable$1, System.Collections.IEnumerable], [System.Reflection.FieldInfo.prototype.$ctor.$new("$state", System.Int32, System.Reflection.FieldAttributes().Private, null, []), System.Reflection.FieldInfo.prototype.$ctor.$new("$this", WootzJs.Compiler.Tests.YieldTests.YieldClass, System.Reflection.FieldAttributes().Private, null, []), System.Reflection.FieldInfo.prototype.$ctor.$new("i", System.Int32, System.Reflection.FieldAttributes().Private, null, [])], [System.Reflection.MethodInfo.prototype.$ctor.$new("GetEnumerator", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ForLoopNoVariableNoInitializer.prototype.GetEnumerator, [], System.Collections.IEnumerator, System.Reflection.MethodAttributes().Public, []), System.Reflection.MethodInfo.prototype.$ctor.$new("MoveNext", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ForLoopNoVariableNoInitializer.prototype.MoveNext, [], System.Boolean, System.Reflection.MethodAttributes().Public, [])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ForLoopNoVariableNoInitializer.prototype.$ctor, [System.Reflection.ParameterInfo.prototype.$ctor.$new("$this", WootzJs.Compiler.Tests.YieldTests.YieldClass, 0, 0, null, [])], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
            $t.$StaticInitializer = function() {
            };
            $p.$state = null;
            $p.$this = null;
            $p.i = null;
            $p.$ctor = function($this) {
                (System.YieldIterator$1$(System.Object)).prototype.$ctor.call(this);
                this.$this = $this;
                this.$state = 1;
            };
            $p.$ctor.$type = $t;
            $p.$ctor.$new = function($this) {
                return new $p.$ctor.$type(this, $this);
            };
            $p.GetEnumerator = function() {
                return this;
            };
            $p.System$Collections$Generic$IEnumerable$1$GetEnumerator = $p.GetEnumerator;
            $p.MoveNext = function() {
                $top:
                while (true) {
                    switch (this.$state) {
                        case 0:
                            return false;
                        case 1:
                            this.i = 0;
                            this.$state = 2;
                            continue $top;
                        case 2:
                            while (this.i < 3) {
                                this.$state = 3;
                                this.set_Current(this.i);
                                return true;
                            }
                            this.$state = 0;
                            continue $top;
                        case 3:
                            this.i++;
                            this.$state = 2;
                            continue $top;
                    }
                }
            };
            $p.System$Collections$IEnumerator$MoveNext = $p.MoveNext;
        }).call($t, $t.YieldEnumerator$ForLoopNoVariableNoInitializer, $t.YieldEnumerator$ForLoopNoVariableNoInitializer.prototype);
        $WootzJs$Compiler$Tests$AssemblyTypes.push($t.YieldEnumerator$ForLoopNoVariableNoInitializer);
        function YieldEnumerator$ForLoopNoVariableNoInitializerNoIncrementor($constructor) {
            if (!$t.YieldEnumerator$ForLoopNoVariableNoInitializerNoIncrementor.$isStaticInitialized && ($constructor != null || !(this instanceof WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ForLoopNoVariableNoInitializerNoIncrementor))) {
                $t.YieldEnumerator$ForLoopNoVariableNoInitializerNoIncrementor.$isStaticInitialized = true;
                $t.YieldEnumerator$ForLoopNoVariableNoInitializerNoIncrementor.$StaticInitializer();
            }
            if ($constructor != null)
                $constructor.apply(this, Array.prototype.slice.call(arguments, 1));
            if (!(this instanceof WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ForLoopNoVariableNoInitializerNoIncrementor))
                return $t.YieldEnumerator$ForLoopNoVariableNoInitializerNoIncrementor;
        }
        $t.YieldEnumerator$ForLoopNoVariableNoInitializerNoIncrementor = YieldEnumerator$ForLoopNoVariableNoInitializerNoIncrementor;
        $t.YieldEnumerator$ForLoopNoVariableNoInitializerNoIncrementor.prototype = new System.YieldIterator$1();
        ($t.YieldEnumerator$ForLoopNoVariableNoInitializerNoIncrementor.$TypeInitializer = function($t, $p) {
            $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
            $p.$type = WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ForLoopNoVariableNoInitializerNoIncrementor;
            $t.$baseType = System.YieldIterator$1;
            $p.$typeName = "WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ForLoopNoVariableNoInitializerNoIncrementor";
            $t.$typeName = $p.$typeName;
            $t.$GetType = function() {
                return System.Type._GetTypeFromTypeFunc(this);
            };
            $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("YieldEnumerator$ForLoopNoVariableNoInitializerNoIncrementor", []);this.$type.Init("WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ForLoopNoVariableNoInitializerNoIncrementor", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ForLoopNoVariableNoInitializerNoIncrementor, (System.YieldIterator$1$(System.Object)), [System.Collections.Generic.IEnumerator$1, System.Collections.IEnumerator, System.IDisposable, System.Collections.Generic.IEnumerable$1, System.Collections.IEnumerable], [System.Reflection.FieldInfo.prototype.$ctor.$new("$state", System.Int32, System.Reflection.FieldAttributes().Private, null, []), System.Reflection.FieldInfo.prototype.$ctor.$new("$this", WootzJs.Compiler.Tests.YieldTests.YieldClass, System.Reflection.FieldAttributes().Private, null, []), System.Reflection.FieldInfo.prototype.$ctor.$new("i", System.Int32, System.Reflection.FieldAttributes().Private, null, [])], [System.Reflection.MethodInfo.prototype.$ctor.$new("GetEnumerator", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ForLoopNoVariableNoInitializerNoIncrementor.prototype.GetEnumerator, [], System.Collections.IEnumerator, System.Reflection.MethodAttributes().Public, []), System.Reflection.MethodInfo.prototype.$ctor.$new("MoveNext", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ForLoopNoVariableNoInitializerNoIncrementor.prototype.MoveNext, [], System.Boolean, System.Reflection.MethodAttributes().Public, [])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ForLoopNoVariableNoInitializerNoIncrementor.prototype.$ctor, [System.Reflection.ParameterInfo.prototype.$ctor.$new("$this", WootzJs.Compiler.Tests.YieldTests.YieldClass, 0, 0, null, [])], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
            $t.$StaticInitializer = function() {
            };
            $p.$state = null;
            $p.$this = null;
            $p.i = null;
            $p.$ctor = function($this) {
                (System.YieldIterator$1$(System.Object)).prototype.$ctor.call(this);
                this.$this = $this;
                this.$state = 1;
            };
            $p.$ctor.$type = $t;
            $p.$ctor.$new = function($this) {
                return new $p.$ctor.$type(this, $this);
            };
            $p.GetEnumerator = function() {
                return this;
            };
            $p.System$Collections$Generic$IEnumerable$1$GetEnumerator = $p.GetEnumerator;
            $p.MoveNext = function() {
                $top:
                while (true) {
                    switch (this.$state) {
                        case 0:
                            return false;
                        case 1:
                            this.i = 0;
                            this.$state = 2;
                            continue $top;
                        case 2:
                            while (this.i < 3) {
                                this.$state = 3;
                                this.set_Current(this.i);
                                return true;
                            }
                            this.$state = 0;
                            continue $top;
                        case 3:
                            this.i++;
                            this.$state = 2;
                            continue $top;
                    }
                }
            };
            $p.System$Collections$IEnumerator$MoveNext = $p.MoveNext;
        }).call($t, $t.YieldEnumerator$ForLoopNoVariableNoInitializerNoIncrementor, $t.YieldEnumerator$ForLoopNoVariableNoInitializerNoIncrementor.prototype);
        $WootzJs$Compiler$Tests$AssemblyTypes.push($t.YieldEnumerator$ForLoopNoVariableNoInitializerNoIncrementor);
        function YieldEnumerator$ForLoopTwoVariablesTwoIncrementors($constructor) {
            if (!$t.YieldEnumerator$ForLoopTwoVariablesTwoIncrementors.$isStaticInitialized && ($constructor != null || !(this instanceof WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ForLoopTwoVariablesTwoIncrementors))) {
                $t.YieldEnumerator$ForLoopTwoVariablesTwoIncrementors.$isStaticInitialized = true;
                $t.YieldEnumerator$ForLoopTwoVariablesTwoIncrementors.$StaticInitializer();
            }
            if ($constructor != null)
                $constructor.apply(this, Array.prototype.slice.call(arguments, 1));
            if (!(this instanceof WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ForLoopTwoVariablesTwoIncrementors))
                return $t.YieldEnumerator$ForLoopTwoVariablesTwoIncrementors;
        }
        $t.YieldEnumerator$ForLoopTwoVariablesTwoIncrementors = YieldEnumerator$ForLoopTwoVariablesTwoIncrementors;
        $t.YieldEnumerator$ForLoopTwoVariablesTwoIncrementors.prototype = new System.YieldIterator$1();
        ($t.YieldEnumerator$ForLoopTwoVariablesTwoIncrementors.$TypeInitializer = function($t, $p) {
            $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
            $p.$type = WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ForLoopTwoVariablesTwoIncrementors;
            $t.$baseType = System.YieldIterator$1;
            $p.$typeName = "WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ForLoopTwoVariablesTwoIncrementors";
            $t.$typeName = $p.$typeName;
            $t.$GetType = function() {
                return System.Type._GetTypeFromTypeFunc(this);
            };
            $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("YieldEnumerator$ForLoopTwoVariablesTwoIncrementors", []);this.$type.Init("WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ForLoopTwoVariablesTwoIncrementors", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ForLoopTwoVariablesTwoIncrementors, (System.YieldIterator$1$(System.Object)), [System.Collections.Generic.IEnumerator$1, System.Collections.IEnumerator, System.IDisposable, System.Collections.Generic.IEnumerable$1, System.Collections.IEnumerable], [System.Reflection.FieldInfo.prototype.$ctor.$new("$state", System.Int32, System.Reflection.FieldAttributes().Private, null, []), System.Reflection.FieldInfo.prototype.$ctor.$new("$this", WootzJs.Compiler.Tests.YieldTests.YieldClass, System.Reflection.FieldAttributes().Private, null, []), System.Reflection.FieldInfo.prototype.$ctor.$new("i", System.Int32, System.Reflection.FieldAttributes().Private, null, []), System.Reflection.FieldInfo.prototype.$ctor.$new("j", System.Int32, System.Reflection.FieldAttributes().Private, null, [])], [System.Reflection.MethodInfo.prototype.$ctor.$new("GetEnumerator", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ForLoopTwoVariablesTwoIncrementors.prototype.GetEnumerator, [], System.Collections.IEnumerator, System.Reflection.MethodAttributes().Public, []), System.Reflection.MethodInfo.prototype.$ctor.$new("MoveNext", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ForLoopTwoVariablesTwoIncrementors.prototype.MoveNext, [], System.Boolean, System.Reflection.MethodAttributes().Public, [])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ForLoopTwoVariablesTwoIncrementors.prototype.$ctor, [System.Reflection.ParameterInfo.prototype.$ctor.$new("$this", WootzJs.Compiler.Tests.YieldTests.YieldClass, 0, 0, null, [])], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
            $t.$StaticInitializer = function() {
            };
            $p.$state = null;
            $p.$this = null;
            $p.i = null;
            $p.j = null;
            $p.$ctor = function($this) {
                (System.YieldIterator$1$(System.Object)).prototype.$ctor.call(this);
                this.$this = $this;
                this.$state = 1;
            };
            $p.$ctor.$type = $t;
            $p.$ctor.$new = function($this) {
                return new $p.$ctor.$type(this, $this);
            };
            $p.GetEnumerator = function() {
                return this;
            };
            $p.System$Collections$Generic$IEnumerable$1$GetEnumerator = $p.GetEnumerator;
            $p.MoveNext = function() {
                $top:
                while (true) {
                    switch (this.$state) {
                        case 0:
                            return false;
                        case 1:
                            this.i = 0;
                            this.j = 1;
                            this.$state = 2;
                            continue $top;
                        case 2:
                            while (this.i < 3) {
                                this.$state = 3;
                                this.set_Current(this.i + this.j);
                                return true;
                            }
                            this.$state = 0;
                            continue $top;
                        case 3:
                            this.i++;
                            this.j++;
                            this.$state = 2;
                            continue $top;
                    }
                }
            };
            $p.System$Collections$IEnumerator$MoveNext = $p.MoveNext;
        }).call($t, $t.YieldEnumerator$ForLoopTwoVariablesTwoIncrementors, $t.YieldEnumerator$ForLoopTwoVariablesTwoIncrementors.prototype);
        $WootzJs$Compiler$Tests$AssemblyTypes.push($t.YieldEnumerator$ForLoopTwoVariablesTwoIncrementors);
        function YieldEnumerator$NestedLoops($constructor) {
            if (!$t.YieldEnumerator$NestedLoops.$isStaticInitialized && ($constructor != null || !(this instanceof WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$NestedLoops))) {
                $t.YieldEnumerator$NestedLoops.$isStaticInitialized = true;
                $t.YieldEnumerator$NestedLoops.$StaticInitializer();
            }
            if ($constructor != null)
                $constructor.apply(this, Array.prototype.slice.call(arguments, 1));
            if (!(this instanceof WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$NestedLoops))
                return $t.YieldEnumerator$NestedLoops;
        }
        $t.YieldEnumerator$NestedLoops = YieldEnumerator$NestedLoops;
        $t.YieldEnumerator$NestedLoops.prototype = new System.YieldIterator$1();
        ($t.YieldEnumerator$NestedLoops.$TypeInitializer = function($t, $p) {
            $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
            $p.$type = WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$NestedLoops;
            $t.$baseType = System.YieldIterator$1;
            $p.$typeName = "WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$NestedLoops";
            $t.$typeName = $p.$typeName;
            $t.$GetType = function() {
                return System.Type._GetTypeFromTypeFunc(this);
            };
            $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("YieldEnumerator$NestedLoops", []);this.$type.Init("WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$NestedLoops", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$NestedLoops, (System.YieldIterator$1$(System.Object)), [System.Collections.Generic.IEnumerator$1, System.Collections.IEnumerator, System.IDisposable, System.Collections.Generic.IEnumerable$1, System.Collections.IEnumerable], [System.Reflection.FieldInfo.prototype.$ctor.$new("$state", System.Int32, System.Reflection.FieldAttributes().Private, null, []), System.Reflection.FieldInfo.prototype.$ctor.$new("$this", WootzJs.Compiler.Tests.YieldTests.YieldClass, System.Reflection.FieldAttributes().Private, null, []), System.Reflection.FieldInfo.prototype.$ctor.$new("i", System.Int32, System.Reflection.FieldAttributes().Private, null, []), System.Reflection.FieldInfo.prototype.$ctor.$new("j", System.Int32, System.Reflection.FieldAttributes().Private, null, [])], [System.Reflection.MethodInfo.prototype.$ctor.$new("GetEnumerator", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$NestedLoops.prototype.GetEnumerator, [], System.Collections.IEnumerator, System.Reflection.MethodAttributes().Public, []), System.Reflection.MethodInfo.prototype.$ctor.$new("MoveNext", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$NestedLoops.prototype.MoveNext, [], System.Boolean, System.Reflection.MethodAttributes().Public, [])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$NestedLoops.prototype.$ctor, [System.Reflection.ParameterInfo.prototype.$ctor.$new("$this", WootzJs.Compiler.Tests.YieldTests.YieldClass, 0, 0, null, [])], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
            $t.$StaticInitializer = function() {
            };
            $p.$state = null;
            $p.$this = null;
            $p.i = null;
            $p.j = null;
            $p.$ctor = function($this) {
                (System.YieldIterator$1$(System.Object)).prototype.$ctor.call(this);
                this.$this = $this;
                this.$state = 1;
            };
            $p.$ctor.$type = $t;
            $p.$ctor.$new = function($this) {
                return new $p.$ctor.$type(this, $this);
            };
            $p.GetEnumerator = function() {
                return this;
            };
            $p.System$Collections$Generic$IEnumerable$1$GetEnumerator = $p.GetEnumerator;
            $p.MoveNext = function() {
                $top:
                while (true) {
                    switch (this.$state) {
                        case 0:
                            return false;
                        case 1:
                            this.i = 0;
                            this.$state = 2;
                            continue $top;
                        case 2:
                            while (this.i < 2) {
                                this.j = 0;
                                this.$state = 4;
                                continue $top;
                            }
                            this.$state = 0;
                            continue $top;
                        case 3:
                            this.i++;
                            this.$state = 2;
                            continue $top;
                        case 4:
                            while (this.j < 2) {
                                this.$state = 6;
                                this.set_Current(this.i + this.j);
                                return true;
                            }
                            this.$state = 5;
                            continue $top;
                        case 5:
                            this.$state = 3;
                            this.set_Current(this.i);
                            return true;
                        case 6:
                            this.j++;
                            this.$state = 4;
                            continue $top;
                    }
                }
            };
            $p.System$Collections$IEnumerator$MoveNext = $p.MoveNext;
        }).call($t, $t.YieldEnumerator$NestedLoops, $t.YieldEnumerator$NestedLoops.prototype);
        $WootzJs$Compiler$Tests$AssemblyTypes.push($t.YieldEnumerator$NestedLoops);
        function YieldEnumerator$TypeParameter$1($constructor) {
            if (!$t.YieldEnumerator$TypeParameter$1.$isStaticInitialized && ($constructor != null || !(this instanceof WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$TypeParameter$1))) {
                $t.YieldEnumerator$TypeParameter$1.$isStaticInitialized = true;
                $t.YieldEnumerator$TypeParameter$1.$StaticInitializer();
            }
            if ($constructor != null)
                $constructor.apply(this, Array.prototype.slice.call(arguments, 1));
            if (!(this instanceof WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$TypeParameter$1))
                return $t.YieldEnumerator$TypeParameter$1;
        }
        $t.YieldEnumerator$TypeParameter$1 = YieldEnumerator$TypeParameter$1;
        $t.YieldEnumerator$TypeParameter$1.prototype = new System.YieldIterator$1();
        ($t.YieldEnumerator$TypeParameter$1.$TypeInitializer = function($t, $p, T) {
            $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
            $p.$type = WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$TypeParameter$1;
            $t.$baseType = System.YieldIterator$1;
            $p.$typeName = "WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$TypeParameter`1";
            $t.$typeName = $p.$typeName;
            $t.$GetType = function() {
                return System.Type._GetTypeFromTypeFunc(this);
            };
            $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("YieldEnumerator$TypeParameter", []);this.$type.Init("WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$TypeParameter`1", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$TypeParameter$1, (System.YieldIterator$1$(System.Object)), [System.Collections.Generic.IEnumerator$1, System.Collections.IEnumerator, System.IDisposable, System.Collections.Generic.IEnumerable$1, System.Collections.IEnumerable], [System.Reflection.FieldInfo.prototype.$ctor.$new("$state", System.Int32, System.Reflection.FieldAttributes().Private, null, []), System.Reflection.FieldInfo.prototype.$ctor.$new("$this", WootzJs.Compiler.Tests.YieldTests.YieldClass, System.Reflection.FieldAttributes().Private, null, [])], [System.Reflection.MethodInfo.prototype.$ctor.$new("GetEnumerator", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$TypeParameter$1.prototype.GetEnumerator, [], System.Collections.IEnumerator, System.Reflection.MethodAttributes().Public, []), System.Reflection.MethodInfo.prototype.$ctor.$new("MoveNext", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$TypeParameter$1.prototype.MoveNext, [], System.Boolean, System.Reflection.MethodAttributes().Public, [])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$TypeParameter$1.prototype.$ctor, [System.Reflection.ParameterInfo.prototype.$ctor.$new("$this", WootzJs.Compiler.Tests.YieldTests.YieldClass, 0, 0, null, [])], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
            $t.$StaticInitializer = function() {
            };
            this.YieldEnumerator$TypeParameter$1$ = function() {
                return System.Object.$$MakeGenericType.call(this, this.YieldEnumerator$TypeParameter$1, arguments);
            };
            $p.$state = null;
            $p.$this = null;
            $p.$ctor = function($this) {
                (System.YieldIterator$1$(System.Object)).prototype.$ctor.call(this);
                this.$this = $this;
                this.$state = 1;
            };
            $p.$ctor.$type = $t;
            $p.$ctor.$new = function($this) {
                return new $p.$ctor.$type(this, $this);
            };
            $p.GetEnumerator = function() {
                return this;
            };
            $p.System$Collections$Generic$IEnumerable$1$GetEnumerator = $p.GetEnumerator;
            $p.MoveNext = function() {
                $top:
                while (true) {
                    switch (this.$state) {
                        case 0:
                            return false;
                        case 1:
                            this.$state = 0;
                            this.set_Current(T.$GetType().get_FullName());
                            return true;
                    }
                }
            };
            $p.System$Collections$IEnumerator$MoveNext = $p.MoveNext;
        }).call($t, $t.YieldEnumerator$TypeParameter$1, $t.YieldEnumerator$TypeParameter$1.prototype);
        $WootzJs$Compiler$Tests$AssemblyTypes.push($t.YieldEnumerator$TypeParameter$1);
        function YieldEnumerator$Foreach($constructor) {
            if (!$t.YieldEnumerator$Foreach.$isStaticInitialized && ($constructor != null || !(this instanceof WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$Foreach))) {
                $t.YieldEnumerator$Foreach.$isStaticInitialized = true;
                $t.YieldEnumerator$Foreach.$StaticInitializer();
            }
            if ($constructor != null)
                $constructor.apply(this, Array.prototype.slice.call(arguments, 1));
            if (!(this instanceof WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$Foreach))
                return $t.YieldEnumerator$Foreach;
        }
        $t.YieldEnumerator$Foreach = YieldEnumerator$Foreach;
        $t.YieldEnumerator$Foreach.prototype = new System.YieldIterator$1();
        ($t.YieldEnumerator$Foreach.$TypeInitializer = function($t, $p) {
            $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
            $p.$type = WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$Foreach;
            $t.$baseType = System.YieldIterator$1;
            $p.$typeName = "WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$Foreach";
            $t.$typeName = $p.$typeName;
            $t.$GetType = function() {
                return System.Type._GetTypeFromTypeFunc(this);
            };
            $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("YieldEnumerator$Foreach", []);this.$type.Init("WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$Foreach", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$Foreach, (System.YieldIterator$1$(System.Object)), [System.Collections.Generic.IEnumerator$1, System.Collections.IEnumerator, System.IDisposable, System.Collections.Generic.IEnumerable$1, System.Collections.IEnumerable], [System.Reflection.FieldInfo.prototype.$ctor.$new("$state", System.Int32, System.Reflection.FieldAttributes().Private, null, []), System.Reflection.FieldInfo.prototype.$ctor.$new("$this", WootzJs.Compiler.Tests.YieldTests.YieldClass, System.Reflection.FieldAttributes().Private, null, []), System.Reflection.FieldInfo.prototype.$ctor.$new("s", String, System.Reflection.FieldAttributes().Private, null, []), System.Reflection.FieldInfo.prototype.$ctor.$new("s$enumerator", System.Collections.IEnumerator, System.Reflection.FieldAttributes().Private, null, [])], [System.Reflection.MethodInfo.prototype.$ctor.$new("GetEnumerator", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$Foreach.prototype.GetEnumerator, [], System.Collections.IEnumerator, System.Reflection.MethodAttributes().Public, []), System.Reflection.MethodInfo.prototype.$ctor.$new("MoveNext", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$Foreach.prototype.MoveNext, [], System.Boolean, System.Reflection.MethodAttributes().Public, [])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$Foreach.prototype.$ctor, [System.Reflection.ParameterInfo.prototype.$ctor.$new("$this", WootzJs.Compiler.Tests.YieldTests.YieldClass, 0, 0, null, [])], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
            $t.$StaticInitializer = function() {
            };
            $p.$state = null;
            $p.$this = null;
            $p.s = null;
            $p.s$enumerator = null;
            $p.$ctor = function($this) {
                (System.YieldIterator$1$(System.Object)).prototype.$ctor.call(this);
                this.$this = $this;
                this.$state = 1;
            };
            $p.$ctor.$type = $t;
            $p.$ctor.$new = function($this) {
                return new $p.$ctor.$type(this, $this);
            };
            $p.GetEnumerator = function() {
                return this;
            };
            $p.System$Collections$Generic$IEnumerable$1$GetEnumerator = $p.GetEnumerator;
            $p.MoveNext = function() {
                $top:
                while (true) {
                    switch (this.$state) {
                        case 0:
                            return false;
                        case 1:
                            this.s$enumerator = System.Object.$$InitializeArray(["one", "two", "three"], String).GetEnumerator();
                            this.$state = 2;
                            continue $top;
                        case 2:
                            while (this.s$enumerator.System$Collections$IEnumerator$MoveNext()) {
                                this.s = this.s$enumerator.get_Current();
                                this.$state = 2;
                                this.set_Current(this.s);
                                return true;
                            }
                            this.$state = 0;
                            continue $top;
                    }
                }
            };
            $p.System$Collections$IEnumerator$MoveNext = $p.MoveNext;
        }).call($t, $t.YieldEnumerator$Foreach, $t.YieldEnumerator$Foreach.prototype);
        $WootzJs$Compiler$Tests$AssemblyTypes.push($t.YieldEnumerator$Foreach);
        function YieldEnumerator$DoWhileFalse($constructor) {
            if (!$t.YieldEnumerator$DoWhileFalse.$isStaticInitialized && ($constructor != null || !(this instanceof WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$DoWhileFalse))) {
                $t.YieldEnumerator$DoWhileFalse.$isStaticInitialized = true;
                $t.YieldEnumerator$DoWhileFalse.$StaticInitializer();
            }
            if ($constructor != null)
                $constructor.apply(this, Array.prototype.slice.call(arguments, 1));
            if (!(this instanceof WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$DoWhileFalse))
                return $t.YieldEnumerator$DoWhileFalse;
        }
        $t.YieldEnumerator$DoWhileFalse = YieldEnumerator$DoWhileFalse;
        $t.YieldEnumerator$DoWhileFalse.prototype = new System.YieldIterator$1();
        ($t.YieldEnumerator$DoWhileFalse.$TypeInitializer = function($t, $p) {
            $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
            $p.$type = WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$DoWhileFalse;
            $t.$baseType = System.YieldIterator$1;
            $p.$typeName = "WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$DoWhileFalse";
            $t.$typeName = $p.$typeName;
            $t.$GetType = function() {
                return System.Type._GetTypeFromTypeFunc(this);
            };
            $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("YieldEnumerator$DoWhileFalse", []);this.$type.Init("WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$DoWhileFalse", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$DoWhileFalse, (System.YieldIterator$1$(System.Object)), [System.Collections.Generic.IEnumerator$1, System.Collections.IEnumerator, System.IDisposable, System.Collections.Generic.IEnumerable$1, System.Collections.IEnumerable], [System.Reflection.FieldInfo.prototype.$ctor.$new("$state", System.Int32, System.Reflection.FieldAttributes().Private, null, []), System.Reflection.FieldInfo.prototype.$ctor.$new("$this", WootzJs.Compiler.Tests.YieldTests.YieldClass, System.Reflection.FieldAttributes().Private, null, []), System.Reflection.FieldInfo.prototype.$ctor.$new("i", System.Int32, System.Reflection.FieldAttributes().Private, null, [])], [System.Reflection.MethodInfo.prototype.$ctor.$new("GetEnumerator", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$DoWhileFalse.prototype.GetEnumerator, [], System.Collections.IEnumerator, System.Reflection.MethodAttributes().Public, []), System.Reflection.MethodInfo.prototype.$ctor.$new("MoveNext", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$DoWhileFalse.prototype.MoveNext, [], System.Boolean, System.Reflection.MethodAttributes().Public, [])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$DoWhileFalse.prototype.$ctor, [System.Reflection.ParameterInfo.prototype.$ctor.$new("$this", WootzJs.Compiler.Tests.YieldTests.YieldClass, 0, 0, null, [])], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
            $t.$StaticInitializer = function() {
            };
            $p.$state = null;
            $p.$this = null;
            $p.i = null;
            $p.$ctor = function($this) {
                (System.YieldIterator$1$(System.Object)).prototype.$ctor.call(this);
                this.$this = $this;
                this.$state = 1;
            };
            $p.$ctor.$type = $t;
            $p.$ctor.$new = function($this) {
                return new $p.$ctor.$type(this, $this);
            };
            $p.GetEnumerator = function() {
                return this;
            };
            $p.System$Collections$Generic$IEnumerable$1$GetEnumerator = $p.GetEnumerator;
            $p.MoveNext = function() {
                $top:
                while (true) {
                    switch (this.$state) {
                        case 0:
                            return false;
                        case 1:
                            this.i = 1;
                            this.$state = 2;
                            continue $top;
                        case 2:
                            this.$state = 4;
                            this.set_Current(this.i);
                            return true;
                        case 3:
                            if (false)
                                this.$state = 2;
                            else
                                this.$state = 0;
                            continue $top;
                        case 4:
                            this.i++;
                            this.$state = 3;
                            continue $top;
                    }
                }
            };
            $p.System$Collections$IEnumerator$MoveNext = $p.MoveNext;
        }).call($t, $t.YieldEnumerator$DoWhileFalse, $t.YieldEnumerator$DoWhileFalse.prototype);
        $WootzJs$Compiler$Tests$AssemblyTypes.push($t.YieldEnumerator$DoWhileFalse);
        function YieldEnumerator$DoWhileLessThan3($constructor) {
            if (!$t.YieldEnumerator$DoWhileLessThan3.$isStaticInitialized && ($constructor != null || !(this instanceof WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$DoWhileLessThan3))) {
                $t.YieldEnumerator$DoWhileLessThan3.$isStaticInitialized = true;
                $t.YieldEnumerator$DoWhileLessThan3.$StaticInitializer();
            }
            if ($constructor != null)
                $constructor.apply(this, Array.prototype.slice.call(arguments, 1));
            if (!(this instanceof WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$DoWhileLessThan3))
                return $t.YieldEnumerator$DoWhileLessThan3;
        }
        $t.YieldEnumerator$DoWhileLessThan3 = YieldEnumerator$DoWhileLessThan3;
        $t.YieldEnumerator$DoWhileLessThan3.prototype = new System.YieldIterator$1();
        ($t.YieldEnumerator$DoWhileLessThan3.$TypeInitializer = function($t, $p) {
            $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
            $p.$type = WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$DoWhileLessThan3;
            $t.$baseType = System.YieldIterator$1;
            $p.$typeName = "WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$DoWhileLessThan3";
            $t.$typeName = $p.$typeName;
            $t.$GetType = function() {
                return System.Type._GetTypeFromTypeFunc(this);
            };
            $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("YieldEnumerator$DoWhileLessThan3", []);this.$type.Init("WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$DoWhileLessThan3", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$DoWhileLessThan3, (System.YieldIterator$1$(System.Object)), [System.Collections.Generic.IEnumerator$1, System.Collections.IEnumerator, System.IDisposable, System.Collections.Generic.IEnumerable$1, System.Collections.IEnumerable], [System.Reflection.FieldInfo.prototype.$ctor.$new("$state", System.Int32, System.Reflection.FieldAttributes().Private, null, []), System.Reflection.FieldInfo.prototype.$ctor.$new("$this", WootzJs.Compiler.Tests.YieldTests.YieldClass, System.Reflection.FieldAttributes().Private, null, []), System.Reflection.FieldInfo.prototype.$ctor.$new("i", System.Int32, System.Reflection.FieldAttributes().Private, null, [])], [System.Reflection.MethodInfo.prototype.$ctor.$new("GetEnumerator", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$DoWhileLessThan3.prototype.GetEnumerator, [], System.Collections.IEnumerator, System.Reflection.MethodAttributes().Public, []), System.Reflection.MethodInfo.prototype.$ctor.$new("MoveNext", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$DoWhileLessThan3.prototype.MoveNext, [], System.Boolean, System.Reflection.MethodAttributes().Public, [])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$DoWhileLessThan3.prototype.$ctor, [System.Reflection.ParameterInfo.prototype.$ctor.$new("$this", WootzJs.Compiler.Tests.YieldTests.YieldClass, 0, 0, null, [])], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
            $t.$StaticInitializer = function() {
            };
            $p.$state = null;
            $p.$this = null;
            $p.i = null;
            $p.$ctor = function($this) {
                (System.YieldIterator$1$(System.Object)).prototype.$ctor.call(this);
                this.$this = $this;
                this.$state = 1;
            };
            $p.$ctor.$type = $t;
            $p.$ctor.$new = function($this) {
                return new $p.$ctor.$type(this, $this);
            };
            $p.GetEnumerator = function() {
                return this;
            };
            $p.System$Collections$Generic$IEnumerable$1$GetEnumerator = $p.GetEnumerator;
            $p.MoveNext = function() {
                $top:
                while (true) {
                    switch (this.$state) {
                        case 0:
                            return false;
                        case 1:
                            this.i = 1;
                            this.$state = 2;
                            continue $top;
                        case 2:
                            this.$state = 4;
                            this.set_Current(this.i);
                            return true;
                        case 3:
                            if (this.i < 3)
                                this.$state = 2;
                            else
                                this.$state = 0;
                            continue $top;
                        case 4:
                            this.i++;
                            this.$state = 3;
                            continue $top;
                    }
                }
            };
            $p.System$Collections$IEnumerator$MoveNext = $p.MoveNext;
        }).call($t, $t.YieldEnumerator$DoWhileLessThan3, $t.YieldEnumerator$DoWhileLessThan3.prototype);
        $WootzJs$Compiler$Tests$AssemblyTypes.push($t.YieldEnumerator$DoWhileLessThan3);
        function YieldEnumerator$Switch($constructor) {
            if (!$t.YieldEnumerator$Switch.$isStaticInitialized && ($constructor != null || !(this instanceof WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$Switch))) {
                $t.YieldEnumerator$Switch.$isStaticInitialized = true;
                $t.YieldEnumerator$Switch.$StaticInitializer();
            }
            if ($constructor != null)
                $constructor.apply(this, Array.prototype.slice.call(arguments, 1));
            if (!(this instanceof WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$Switch))
                return $t.YieldEnumerator$Switch;
        }
        $t.YieldEnumerator$Switch = YieldEnumerator$Switch;
        $t.YieldEnumerator$Switch.prototype = new System.YieldIterator$1();
        ($t.YieldEnumerator$Switch.$TypeInitializer = function($t, $p) {
            $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
            $p.$type = WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$Switch;
            $t.$baseType = System.YieldIterator$1;
            $p.$typeName = "WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$Switch";
            $t.$typeName = $p.$typeName;
            $t.$GetType = function() {
                return System.Type._GetTypeFromTypeFunc(this);
            };
            $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("YieldEnumerator$Switch", []);this.$type.Init("WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$Switch", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$Switch, (System.YieldIterator$1$(System.Object)), [System.Collections.Generic.IEnumerator$1, System.Collections.IEnumerator, System.IDisposable, System.Collections.Generic.IEnumerable$1, System.Collections.IEnumerable], [System.Reflection.FieldInfo.prototype.$ctor.$new("$state", System.Int32, System.Reflection.FieldAttributes().Private, null, []), System.Reflection.FieldInfo.prototype.$ctor.$new("$this", WootzJs.Compiler.Tests.YieldTests.YieldClass, System.Reflection.FieldAttributes().Private, null, []), System.Reflection.FieldInfo.prototype.$ctor.$new("s", String, System.Reflection.FieldAttributes().Private, null, [])], [System.Reflection.MethodInfo.prototype.$ctor.$new("GetEnumerator", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$Switch.prototype.GetEnumerator, [], System.Collections.IEnumerator, System.Reflection.MethodAttributes().Public, []), System.Reflection.MethodInfo.prototype.$ctor.$new("MoveNext", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$Switch.prototype.MoveNext, [], System.Boolean, System.Reflection.MethodAttributes().Public, [])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$Switch.prototype.$ctor, [System.Reflection.ParameterInfo.prototype.$ctor.$new("$this", WootzJs.Compiler.Tests.YieldTests.YieldClass, 0, 0, null, []), System.Reflection.ParameterInfo.prototype.$ctor.$new("s", String, 1, 0, null, [])], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
            $t.$StaticInitializer = function() {
            };
            $p.$state = null;
            $p.$this = null;
            $p.s = null;
            $p.$ctor = function($this, s) {
                (System.YieldIterator$1$(System.Object)).prototype.$ctor.call(this);
                this.$this = $this;
                this.s = s;
                this.$state = 1;
            };
            $p.$ctor.$type = $t;
            $p.$ctor.$new = function($this, s) {
                return new $p.$ctor.$type(this, $this, s);
            };
            $p.GetEnumerator = function() {
                return this;
            };
            $p.System$Collections$Generic$IEnumerable$1$GetEnumerator = $p.GetEnumerator;
            $p.MoveNext = function() {
                $top:
                while (true) {
                    switch (this.$state) {
                        case 0:
                            return false;
                        case 1:
                            switch (this.s) {
                                case "one":
                                    this.$state = 0;
                                    this.set_Current(1);
                                    return true;
                                case "two":
                                    this.$state = 2;
                                    this.set_Current(1);
                                    return true;
                                case "three":
                                    this.$state = 3;
                                    this.set_Current(1);
                                    return true;
                                default:
                                    this.$state = 0;
                                    this.set_Current(-1);
                                    return true;
                            }
                            this.$state = 0;
                            continue $top;
                        case 2:
                            this.$state = 0;
                            this.set_Current(2);
                            return true;
                        case 3:
                            this.$state = 4;
                            this.set_Current(2);
                            return true;
                        case 4:
                            this.$state = 0;
                            this.set_Current(3);
                            return true;
                    }
                }
            };
            $p.System$Collections$IEnumerator$MoveNext = $p.MoveNext;
        }).call($t, $t.YieldEnumerator$Switch, $t.YieldEnumerator$Switch.prototype);
        $WootzJs$Compiler$Tests$AssemblyTypes.push($t.YieldEnumerator$Switch);
        function YieldEnumerator$BreakWhile($constructor) {
            if (!$t.YieldEnumerator$BreakWhile.$isStaticInitialized && ($constructor != null || !(this instanceof WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$BreakWhile))) {
                $t.YieldEnumerator$BreakWhile.$isStaticInitialized = true;
                $t.YieldEnumerator$BreakWhile.$StaticInitializer();
            }
            if ($constructor != null)
                $constructor.apply(this, Array.prototype.slice.call(arguments, 1));
            if (!(this instanceof WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$BreakWhile))
                return $t.YieldEnumerator$BreakWhile;
        }
        $t.YieldEnumerator$BreakWhile = YieldEnumerator$BreakWhile;
        $t.YieldEnumerator$BreakWhile.prototype = new System.YieldIterator$1();
        ($t.YieldEnumerator$BreakWhile.$TypeInitializer = function($t, $p) {
            $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
            $p.$type = WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$BreakWhile;
            $t.$baseType = System.YieldIterator$1;
            $p.$typeName = "WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$BreakWhile";
            $t.$typeName = $p.$typeName;
            $t.$GetType = function() {
                return System.Type._GetTypeFromTypeFunc(this);
            };
            $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("YieldEnumerator$BreakWhile", []);this.$type.Init("WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$BreakWhile", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$BreakWhile, (System.YieldIterator$1$(System.Object)), [System.Collections.Generic.IEnumerator$1, System.Collections.IEnumerator, System.IDisposable, System.Collections.Generic.IEnumerable$1, System.Collections.IEnumerable], [System.Reflection.FieldInfo.prototype.$ctor.$new("$state", System.Int32, System.Reflection.FieldAttributes().Private, null, []), System.Reflection.FieldInfo.prototype.$ctor.$new("$this", WootzJs.Compiler.Tests.YieldTests.YieldClass, System.Reflection.FieldAttributes().Private, null, []), System.Reflection.FieldInfo.prototype.$ctor.$new("i", System.Int32, System.Reflection.FieldAttributes().Private, null, [])], [System.Reflection.MethodInfo.prototype.$ctor.$new("GetEnumerator", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$BreakWhile.prototype.GetEnumerator, [], System.Collections.IEnumerator, System.Reflection.MethodAttributes().Public, []), System.Reflection.MethodInfo.prototype.$ctor.$new("MoveNext", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$BreakWhile.prototype.MoveNext, [], System.Boolean, System.Reflection.MethodAttributes().Public, [])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$BreakWhile.prototype.$ctor, [System.Reflection.ParameterInfo.prototype.$ctor.$new("$this", WootzJs.Compiler.Tests.YieldTests.YieldClass, 0, 0, null, [])], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
            $t.$StaticInitializer = function() {
            };
            $p.$state = null;
            $p.$this = null;
            $p.i = null;
            $p.$ctor = function($this) {
                (System.YieldIterator$1$(System.Object)).prototype.$ctor.call(this);
                this.$this = $this;
                this.$state = 1;
            };
            $p.$ctor.$type = $t;
            $p.$ctor.$new = function($this) {
                return new $p.$ctor.$type(this, $this);
            };
            $p.GetEnumerator = function() {
                return this;
            };
            $p.System$Collections$Generic$IEnumerable$1$GetEnumerator = $p.GetEnumerator;
            $p.MoveNext = function() {
                $top:
                while (true) {
                    switch (this.$state) {
                        case 0:
                            return false;
                        case 1:
                            this.i = 0;
                            this.$state = 2;
                            continue $top;
                        case 2:
                            while (true) {
                                this.i++;
                                this.$state = 3;
                                this.set_Current(this.i);
                                return true;
                            }
                            this.$state = 0;
                            continue $top;
                        case 3:
                            this.$state = 0;
                            continue $top;
                    }
                }
            };
            $p.System$Collections$IEnumerator$MoveNext = $p.MoveNext;
        }).call($t, $t.YieldEnumerator$BreakWhile, $t.YieldEnumerator$BreakWhile.prototype);
        $WootzJs$Compiler$Tests$AssemblyTypes.push($t.YieldEnumerator$BreakWhile);
        function YieldEnumerator$ContinueWhile($constructor) {
            if (!$t.YieldEnumerator$ContinueWhile.$isStaticInitialized && ($constructor != null || !(this instanceof WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ContinueWhile))) {
                $t.YieldEnumerator$ContinueWhile.$isStaticInitialized = true;
                $t.YieldEnumerator$ContinueWhile.$StaticInitializer();
            }
            if ($constructor != null)
                $constructor.apply(this, Array.prototype.slice.call(arguments, 1));
            if (!(this instanceof WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ContinueWhile))
                return $t.YieldEnumerator$ContinueWhile;
        }
        $t.YieldEnumerator$ContinueWhile = YieldEnumerator$ContinueWhile;
        $t.YieldEnumerator$ContinueWhile.prototype = new System.YieldIterator$1();
        ($t.YieldEnumerator$ContinueWhile.$TypeInitializer = function($t, $p) {
            $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
            $p.$type = WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ContinueWhile;
            $t.$baseType = System.YieldIterator$1;
            $p.$typeName = "WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ContinueWhile";
            $t.$typeName = $p.$typeName;
            $t.$GetType = function() {
                return System.Type._GetTypeFromTypeFunc(this);
            };
            $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("YieldEnumerator$ContinueWhile", []);this.$type.Init("WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ContinueWhile", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ContinueWhile, (System.YieldIterator$1$(System.Object)), [System.Collections.Generic.IEnumerator$1, System.Collections.IEnumerator, System.IDisposable, System.Collections.Generic.IEnumerable$1, System.Collections.IEnumerable], [System.Reflection.FieldInfo.prototype.$ctor.$new("$state", System.Int32, System.Reflection.FieldAttributes().Private, null, []), System.Reflection.FieldInfo.prototype.$ctor.$new("$this", WootzJs.Compiler.Tests.YieldTests.YieldClass, System.Reflection.FieldAttributes().Private, null, []), System.Reflection.FieldInfo.prototype.$ctor.$new("i", System.Int32, System.Reflection.FieldAttributes().Private, null, [])], [System.Reflection.MethodInfo.prototype.$ctor.$new("GetEnumerator", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ContinueWhile.prototype.GetEnumerator, [], System.Collections.IEnumerator, System.Reflection.MethodAttributes().Public, []), System.Reflection.MethodInfo.prototype.$ctor.$new("MoveNext", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ContinueWhile.prototype.MoveNext, [], System.Boolean, System.Reflection.MethodAttributes().Public, [])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ContinueWhile.prototype.$ctor, [System.Reflection.ParameterInfo.prototype.$ctor.$new("$this", WootzJs.Compiler.Tests.YieldTests.YieldClass, 0, 0, null, [])], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
            $t.$StaticInitializer = function() {
            };
            $p.$state = null;
            $p.$this = null;
            $p.i = null;
            $p.$ctor = function($this) {
                (System.YieldIterator$1$(System.Object)).prototype.$ctor.call(this);
                this.$this = $this;
                this.$state = 1;
            };
            $p.$ctor.$type = $t;
            $p.$ctor.$new = function($this) {
                return new $p.$ctor.$type(this, $this);
            };
            $p.GetEnumerator = function() {
                return this;
            };
            $p.System$Collections$Generic$IEnumerable$1$GetEnumerator = $p.GetEnumerator;
            $p.MoveNext = function() {
                $top:
                while (true) {
                    switch (this.$state) {
                        case 0:
                            return false;
                        case 1:
                            this.i = 0;
                            this.$state = 2;
                            continue $top;
                        case 2:
                            while (this.i < 3) {
                                this.i++;
                                if (this.i < 2)
                                    continue;
                                this.$state = 2;
                                this.set_Current(this.i);
                                return true;
                            }
                            this.$state = 0;
                            continue $top;
                    }
                }
            };
            $p.System$Collections$IEnumerator$MoveNext = $p.MoveNext;
        }).call($t, $t.YieldEnumerator$ContinueWhile, $t.YieldEnumerator$ContinueWhile.prototype);
        $WootzJs$Compiler$Tests$AssemblyTypes.push($t.YieldEnumerator$ContinueWhile);
        function YieldEnumerator$BreakFor($constructor) {
            if (!$t.YieldEnumerator$BreakFor.$isStaticInitialized && ($constructor != null || !(this instanceof WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$BreakFor))) {
                $t.YieldEnumerator$BreakFor.$isStaticInitialized = true;
                $t.YieldEnumerator$BreakFor.$StaticInitializer();
            }
            if ($constructor != null)
                $constructor.apply(this, Array.prototype.slice.call(arguments, 1));
            if (!(this instanceof WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$BreakFor))
                return $t.YieldEnumerator$BreakFor;
        }
        $t.YieldEnumerator$BreakFor = YieldEnumerator$BreakFor;
        $t.YieldEnumerator$BreakFor.prototype = new System.YieldIterator$1();
        ($t.YieldEnumerator$BreakFor.$TypeInitializer = function($t, $p) {
            $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
            $p.$type = WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$BreakFor;
            $t.$baseType = System.YieldIterator$1;
            $p.$typeName = "WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$BreakFor";
            $t.$typeName = $p.$typeName;
            $t.$GetType = function() {
                return System.Type._GetTypeFromTypeFunc(this);
            };
            $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("YieldEnumerator$BreakFor", []);this.$type.Init("WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$BreakFor", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$BreakFor, (System.YieldIterator$1$(System.Object)), [System.Collections.Generic.IEnumerator$1, System.Collections.IEnumerator, System.IDisposable, System.Collections.Generic.IEnumerable$1, System.Collections.IEnumerable], [System.Reflection.FieldInfo.prototype.$ctor.$new("$state", System.Int32, System.Reflection.FieldAttributes().Private, null, []), System.Reflection.FieldInfo.prototype.$ctor.$new("$this", WootzJs.Compiler.Tests.YieldTests.YieldClass, System.Reflection.FieldAttributes().Private, null, []), System.Reflection.FieldInfo.prototype.$ctor.$new("i", System.Int32, System.Reflection.FieldAttributes().Private, null, [])], [System.Reflection.MethodInfo.prototype.$ctor.$new("GetEnumerator", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$BreakFor.prototype.GetEnumerator, [], System.Collections.IEnumerator, System.Reflection.MethodAttributes().Public, []), System.Reflection.MethodInfo.prototype.$ctor.$new("MoveNext", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$BreakFor.prototype.MoveNext, [], System.Boolean, System.Reflection.MethodAttributes().Public, [])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$BreakFor.prototype.$ctor, [System.Reflection.ParameterInfo.prototype.$ctor.$new("$this", WootzJs.Compiler.Tests.YieldTests.YieldClass, 0, 0, null, [])], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
            $t.$StaticInitializer = function() {
            };
            $p.$state = null;
            $p.$this = null;
            $p.i = null;
            $p.$ctor = function($this) {
                (System.YieldIterator$1$(System.Object)).prototype.$ctor.call(this);
                this.$this = $this;
                this.$state = 1;
            };
            $p.$ctor.$type = $t;
            $p.$ctor.$new = function($this) {
                return new $p.$ctor.$type(this, $this);
            };
            $p.GetEnumerator = function() {
                return this;
            };
            $p.System$Collections$Generic$IEnumerable$1$GetEnumerator = $p.GetEnumerator;
            $p.MoveNext = function() {
                $top:
                while (true) {
                    switch (this.$state) {
                        case 0:
                            return false;
                        case 1:
                            this.i = 0;
                            this.$state = 2;
                            continue $top;
                        case 2:
                            while (true) {
                                this.i++;
                                this.$state = 3;
                                this.set_Current(this.i);
                                return true;
                            }
                            this.$state = 0;
                            continue $top;
                        case 3:
                            this.$state = 0;
                            continue $top;
                    }
                }
            };
            $p.System$Collections$IEnumerator$MoveNext = $p.MoveNext;
        }).call($t, $t.YieldEnumerator$BreakFor, $t.YieldEnumerator$BreakFor.prototype);
        $WootzJs$Compiler$Tests$AssemblyTypes.push($t.YieldEnumerator$BreakFor);
        function YieldEnumerator$ContinueFor($constructor) {
            if (!$t.YieldEnumerator$ContinueFor.$isStaticInitialized && ($constructor != null || !(this instanceof WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ContinueFor))) {
                $t.YieldEnumerator$ContinueFor.$isStaticInitialized = true;
                $t.YieldEnumerator$ContinueFor.$StaticInitializer();
            }
            if ($constructor != null)
                $constructor.apply(this, Array.prototype.slice.call(arguments, 1));
            if (!(this instanceof WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ContinueFor))
                return $t.YieldEnumerator$ContinueFor;
        }
        $t.YieldEnumerator$ContinueFor = YieldEnumerator$ContinueFor;
        $t.YieldEnumerator$ContinueFor.prototype = new System.YieldIterator$1();
        ($t.YieldEnumerator$ContinueFor.$TypeInitializer = function($t, $p) {
            $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
            $p.$type = WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ContinueFor;
            $t.$baseType = System.YieldIterator$1;
            $p.$typeName = "WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ContinueFor";
            $t.$typeName = $p.$typeName;
            $t.$GetType = function() {
                return System.Type._GetTypeFromTypeFunc(this);
            };
            $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("YieldEnumerator$ContinueFor", []);this.$type.Init("WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ContinueFor", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ContinueFor, (System.YieldIterator$1$(System.Object)), [System.Collections.Generic.IEnumerator$1, System.Collections.IEnumerator, System.IDisposable, System.Collections.Generic.IEnumerable$1, System.Collections.IEnumerable], [System.Reflection.FieldInfo.prototype.$ctor.$new("$state", System.Int32, System.Reflection.FieldAttributes().Private, null, []), System.Reflection.FieldInfo.prototype.$ctor.$new("$this", WootzJs.Compiler.Tests.YieldTests.YieldClass, System.Reflection.FieldAttributes().Private, null, []), System.Reflection.FieldInfo.prototype.$ctor.$new("i", System.Int32, System.Reflection.FieldAttributes().Private, null, [])], [System.Reflection.MethodInfo.prototype.$ctor.$new("GetEnumerator", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ContinueFor.prototype.GetEnumerator, [], System.Collections.IEnumerator, System.Reflection.MethodAttributes().Public, []), System.Reflection.MethodInfo.prototype.$ctor.$new("MoveNext", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ContinueFor.prototype.MoveNext, [], System.Boolean, System.Reflection.MethodAttributes().Public, [])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ContinueFor.prototype.$ctor, [System.Reflection.ParameterInfo.prototype.$ctor.$new("$this", WootzJs.Compiler.Tests.YieldTests.YieldClass, 0, 0, null, [])], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
            $t.$StaticInitializer = function() {
            };
            $p.$state = null;
            $p.$this = null;
            $p.i = null;
            $p.$ctor = function($this) {
                (System.YieldIterator$1$(System.Object)).prototype.$ctor.call(this);
                this.$this = $this;
                this.$state = 1;
            };
            $p.$ctor.$type = $t;
            $p.$ctor.$new = function($this) {
                return new $p.$ctor.$type(this, $this);
            };
            $p.GetEnumerator = function() {
                return this;
            };
            $p.System$Collections$Generic$IEnumerable$1$GetEnumerator = $p.GetEnumerator;
            $p.MoveNext = function() {
                $top:
                while (true) {
                    switch (this.$state) {
                        case 0:
                            return false;
                        case 1:
                            this.i = 0;
                            this.$state = 2;
                            continue $top;
                        case 2:
                            while (this.i < 3) {
                                this.i++;
                                if (this.i < 2)
                                    continue;
                                this.$state = 2;
                                this.set_Current(this.i);
                                return true;
                            }
                            this.$state = 0;
                            continue $top;
                    }
                }
            };
            $p.System$Collections$IEnumerator$MoveNext = $p.MoveNext;
        }).call($t, $t.YieldEnumerator$ContinueFor, $t.YieldEnumerator$ContinueFor.prototype);
        $WootzJs$Compiler$Tests$AssemblyTypes.push($t.YieldEnumerator$ContinueFor);
        function YieldEnumerator$BreakForeach($constructor) {
            if (!$t.YieldEnumerator$BreakForeach.$isStaticInitialized && ($constructor != null || !(this instanceof WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$BreakForeach))) {
                $t.YieldEnumerator$BreakForeach.$isStaticInitialized = true;
                $t.YieldEnumerator$BreakForeach.$StaticInitializer();
            }
            if ($constructor != null)
                $constructor.apply(this, Array.prototype.slice.call(arguments, 1));
            if (!(this instanceof WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$BreakForeach))
                return $t.YieldEnumerator$BreakForeach;
        }
        $t.YieldEnumerator$BreakForeach = YieldEnumerator$BreakForeach;
        $t.YieldEnumerator$BreakForeach.prototype = new System.YieldIterator$1();
        ($t.YieldEnumerator$BreakForeach.$TypeInitializer = function($t, $p) {
            $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
            $p.$type = WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$BreakForeach;
            $t.$baseType = System.YieldIterator$1;
            $p.$typeName = "WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$BreakForeach";
            $t.$typeName = $p.$typeName;
            $t.$GetType = function() {
                return System.Type._GetTypeFromTypeFunc(this);
            };
            $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("YieldEnumerator$BreakForeach", []);this.$type.Init("WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$BreakForeach", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$BreakForeach, (System.YieldIterator$1$(System.Object)), [System.Collections.Generic.IEnumerator$1, System.Collections.IEnumerator, System.IDisposable, System.Collections.Generic.IEnumerable$1, System.Collections.IEnumerable], [System.Reflection.FieldInfo.prototype.$ctor.$new("$state", System.Int32, System.Reflection.FieldAttributes().Private, null, []), System.Reflection.FieldInfo.prototype.$ctor.$new("$this", WootzJs.Compiler.Tests.YieldTests.YieldClass, System.Reflection.FieldAttributes().Private, null, []), System.Reflection.FieldInfo.prototype.$ctor.$new("i", System.Int32, System.Reflection.FieldAttributes().Private, null, []), System.Reflection.FieldInfo.prototype.$ctor.$new("i$enumerator", System.Collections.IEnumerator, System.Reflection.FieldAttributes().Private, null, [])], [System.Reflection.MethodInfo.prototype.$ctor.$new("GetEnumerator", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$BreakForeach.prototype.GetEnumerator, [], System.Collections.IEnumerator, System.Reflection.MethodAttributes().Public, []), System.Reflection.MethodInfo.prototype.$ctor.$new("MoveNext", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$BreakForeach.prototype.MoveNext, [], System.Boolean, System.Reflection.MethodAttributes().Public, [])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$BreakForeach.prototype.$ctor, [System.Reflection.ParameterInfo.prototype.$ctor.$new("$this", WootzJs.Compiler.Tests.YieldTests.YieldClass, 0, 0, null, [])], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
            $t.$StaticInitializer = function() {
            };
            $p.$state = null;
            $p.$this = null;
            $p.i = null;
            $p.i$enumerator = null;
            $p.$ctor = function($this) {
                (System.YieldIterator$1$(System.Object)).prototype.$ctor.call(this);
                this.$this = $this;
                this.$state = 1;
            };
            $p.$ctor.$type = $t;
            $p.$ctor.$new = function($this) {
                return new $p.$ctor.$type(this, $this);
            };
            $p.GetEnumerator = function() {
                return this;
            };
            $p.System$Collections$Generic$IEnumerable$1$GetEnumerator = $p.GetEnumerator;
            $p.MoveNext = function() {
                $top:
                while (true) {
                    switch (this.$state) {
                        case 0:
                            return false;
                        case 1:
                            this.i$enumerator = System.Object.$$InitializeArray([1, 2, 3], System.Int32).GetEnumerator();
                            this.$state = 2;
                            continue $top;
                        case 2:
                            while (this.i$enumerator.System$Collections$IEnumerator$MoveNext()) {
                                this.i = this.i$enumerator.get_Current();
                                this.$state = 3;
                                this.set_Current(this.i);
                                return true;
                            }
                            this.$state = 0;
                            continue $top;
                        case 3:
                            this.$state = 0;
                            continue $top;
                    }
                }
            };
            $p.System$Collections$IEnumerator$MoveNext = $p.MoveNext;
        }).call($t, $t.YieldEnumerator$BreakForeach, $t.YieldEnumerator$BreakForeach.prototype);
        $WootzJs$Compiler$Tests$AssemblyTypes.push($t.YieldEnumerator$BreakForeach);
        function YieldEnumerator$ContinueForeach($constructor) {
            if (!$t.YieldEnumerator$ContinueForeach.$isStaticInitialized && ($constructor != null || !(this instanceof WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ContinueForeach))) {
                $t.YieldEnumerator$ContinueForeach.$isStaticInitialized = true;
                $t.YieldEnumerator$ContinueForeach.$StaticInitializer();
            }
            if ($constructor != null)
                $constructor.apply(this, Array.prototype.slice.call(arguments, 1));
            if (!(this instanceof WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ContinueForeach))
                return $t.YieldEnumerator$ContinueForeach;
        }
        $t.YieldEnumerator$ContinueForeach = YieldEnumerator$ContinueForeach;
        $t.YieldEnumerator$ContinueForeach.prototype = new System.YieldIterator$1();
        ($t.YieldEnumerator$ContinueForeach.$TypeInitializer = function($t, $p) {
            $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
            $p.$type = WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ContinueForeach;
            $t.$baseType = System.YieldIterator$1;
            $p.$typeName = "WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ContinueForeach";
            $t.$typeName = $p.$typeName;
            $t.$GetType = function() {
                return System.Type._GetTypeFromTypeFunc(this);
            };
            $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("YieldEnumerator$ContinueForeach", []);this.$type.Init("WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ContinueForeach", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ContinueForeach, (System.YieldIterator$1$(System.Object)), [System.Collections.Generic.IEnumerator$1, System.Collections.IEnumerator, System.IDisposable, System.Collections.Generic.IEnumerable$1, System.Collections.IEnumerable], [System.Reflection.FieldInfo.prototype.$ctor.$new("$state", System.Int32, System.Reflection.FieldAttributes().Private, null, []), System.Reflection.FieldInfo.prototype.$ctor.$new("$this", WootzJs.Compiler.Tests.YieldTests.YieldClass, System.Reflection.FieldAttributes().Private, null, []), System.Reflection.FieldInfo.prototype.$ctor.$new("i", System.Int32, System.Reflection.FieldAttributes().Private, null, []), System.Reflection.FieldInfo.prototype.$ctor.$new("i$enumerator", System.Collections.IEnumerator, System.Reflection.FieldAttributes().Private, null, [])], [System.Reflection.MethodInfo.prototype.$ctor.$new("GetEnumerator", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ContinueForeach.prototype.GetEnumerator, [], System.Collections.IEnumerator, System.Reflection.MethodAttributes().Public, []), System.Reflection.MethodInfo.prototype.$ctor.$new("MoveNext", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ContinueForeach.prototype.MoveNext, [], System.Boolean, System.Reflection.MethodAttributes().Public, [])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ContinueForeach.prototype.$ctor, [System.Reflection.ParameterInfo.prototype.$ctor.$new("$this", WootzJs.Compiler.Tests.YieldTests.YieldClass, 0, 0, null, [])], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
            $t.$StaticInitializer = function() {
            };
            $p.$state = null;
            $p.$this = null;
            $p.i = null;
            $p.i$enumerator = null;
            $p.$ctor = function($this) {
                (System.YieldIterator$1$(System.Object)).prototype.$ctor.call(this);
                this.$this = $this;
                this.$state = 1;
            };
            $p.$ctor.$type = $t;
            $p.$ctor.$new = function($this) {
                return new $p.$ctor.$type(this, $this);
            };
            $p.GetEnumerator = function() {
                return this;
            };
            $p.System$Collections$Generic$IEnumerable$1$GetEnumerator = $p.GetEnumerator;
            $p.MoveNext = function() {
                $top:
                while (true) {
                    switch (this.$state) {
                        case 0:
                            return false;
                        case 1:
                            this.i$enumerator = System.Object.$$InitializeArray([1, 2, 3], System.Int32).GetEnumerator();
                            this.$state = 2;
                            continue $top;
                        case 2:
                            while (this.i$enumerator.System$Collections$IEnumerator$MoveNext()) {
                                this.i = this.i$enumerator.get_Current();
                                if (this.i < 2)
                                    continue;
                                this.$state = 2;
                                this.set_Current(this.i);
                                return true;
                            }
                            this.$state = 0;
                            continue $top;
                    }
                }
            };
            $p.System$Collections$IEnumerator$MoveNext = $p.MoveNext;
        }).call($t, $t.YieldEnumerator$ContinueForeach, $t.YieldEnumerator$ContinueForeach.prototype);
        $WootzJs$Compiler$Tests$AssemblyTypes.push($t.YieldEnumerator$ContinueForeach);
        function YieldEnumerator$BreakDoWhile($constructor) {
            if (!$t.YieldEnumerator$BreakDoWhile.$isStaticInitialized && ($constructor != null || !(this instanceof WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$BreakDoWhile))) {
                $t.YieldEnumerator$BreakDoWhile.$isStaticInitialized = true;
                $t.YieldEnumerator$BreakDoWhile.$StaticInitializer();
            }
            if ($constructor != null)
                $constructor.apply(this, Array.prototype.slice.call(arguments, 1));
            if (!(this instanceof WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$BreakDoWhile))
                return $t.YieldEnumerator$BreakDoWhile;
        }
        $t.YieldEnumerator$BreakDoWhile = YieldEnumerator$BreakDoWhile;
        $t.YieldEnumerator$BreakDoWhile.prototype = new System.YieldIterator$1();
        ($t.YieldEnumerator$BreakDoWhile.$TypeInitializer = function($t, $p) {
            $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
            $p.$type = WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$BreakDoWhile;
            $t.$baseType = System.YieldIterator$1;
            $p.$typeName = "WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$BreakDoWhile";
            $t.$typeName = $p.$typeName;
            $t.$GetType = function() {
                return System.Type._GetTypeFromTypeFunc(this);
            };
            $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("YieldEnumerator$BreakDoWhile", []);this.$type.Init("WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$BreakDoWhile", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$BreakDoWhile, (System.YieldIterator$1$(System.Object)), [System.Collections.Generic.IEnumerator$1, System.Collections.IEnumerator, System.IDisposable, System.Collections.Generic.IEnumerable$1, System.Collections.IEnumerable], [System.Reflection.FieldInfo.prototype.$ctor.$new("$state", System.Int32, System.Reflection.FieldAttributes().Private, null, []), System.Reflection.FieldInfo.prototype.$ctor.$new("$this", WootzJs.Compiler.Tests.YieldTests.YieldClass, System.Reflection.FieldAttributes().Private, null, []), System.Reflection.FieldInfo.prototype.$ctor.$new("i", System.Int32, System.Reflection.FieldAttributes().Private, null, [])], [System.Reflection.MethodInfo.prototype.$ctor.$new("GetEnumerator", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$BreakDoWhile.prototype.GetEnumerator, [], System.Collections.IEnumerator, System.Reflection.MethodAttributes().Public, []), System.Reflection.MethodInfo.prototype.$ctor.$new("MoveNext", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$BreakDoWhile.prototype.MoveNext, [], System.Boolean, System.Reflection.MethodAttributes().Public, [])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$BreakDoWhile.prototype.$ctor, [System.Reflection.ParameterInfo.prototype.$ctor.$new("$this", WootzJs.Compiler.Tests.YieldTests.YieldClass, 0, 0, null, [])], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
            $t.$StaticInitializer = function() {
            };
            $p.$state = null;
            $p.$this = null;
            $p.i = null;
            $p.$ctor = function($this) {
                (System.YieldIterator$1$(System.Object)).prototype.$ctor.call(this);
                this.$this = $this;
                this.$state = 1;
            };
            $p.$ctor.$type = $t;
            $p.$ctor.$new = function($this) {
                return new $p.$ctor.$type(this, $this);
            };
            $p.GetEnumerator = function() {
                return this;
            };
            $p.System$Collections$Generic$IEnumerable$1$GetEnumerator = $p.GetEnumerator;
            $p.MoveNext = function() {
                $top:
                while (true) {
                    switch (this.$state) {
                        case 0:
                            return false;
                        case 1:
                            this.i = 0;
                            this.$state = 2;
                            continue $top;
                        case 2:
                            this.i++;
                            this.$state = 4;
                            this.set_Current(this.i);
                            return true;
                        case 3:
                            if (true)
                                this.$state = 2;
                            else
                                this.$state = 0;
                            continue $top;
                        case 4:
                            this.$state = 0;
                            continue $top;
                    }
                }
            };
            $p.System$Collections$IEnumerator$MoveNext = $p.MoveNext;
        }).call($t, $t.YieldEnumerator$BreakDoWhile, $t.YieldEnumerator$BreakDoWhile.prototype);
        $WootzJs$Compiler$Tests$AssemblyTypes.push($t.YieldEnumerator$BreakDoWhile);
        function YieldEnumerator$ContinueDoWhile($constructor) {
            if (!$t.YieldEnumerator$ContinueDoWhile.$isStaticInitialized && ($constructor != null || !(this instanceof WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ContinueDoWhile))) {
                $t.YieldEnumerator$ContinueDoWhile.$isStaticInitialized = true;
                $t.YieldEnumerator$ContinueDoWhile.$StaticInitializer();
            }
            if ($constructor != null)
                $constructor.apply(this, Array.prototype.slice.call(arguments, 1));
            if (!(this instanceof WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ContinueDoWhile))
                return $t.YieldEnumerator$ContinueDoWhile;
        }
        $t.YieldEnumerator$ContinueDoWhile = YieldEnumerator$ContinueDoWhile;
        $t.YieldEnumerator$ContinueDoWhile.prototype = new System.YieldIterator$1();
        ($t.YieldEnumerator$ContinueDoWhile.$TypeInitializer = function($t, $p) {
            $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
            $p.$type = WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ContinueDoWhile;
            $t.$baseType = System.YieldIterator$1;
            $p.$typeName = "WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ContinueDoWhile";
            $t.$typeName = $p.$typeName;
            $t.$GetType = function() {
                return System.Type._GetTypeFromTypeFunc(this);
            };
            $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("YieldEnumerator$ContinueDoWhile", []);this.$type.Init("WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ContinueDoWhile", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ContinueDoWhile, (System.YieldIterator$1$(System.Object)), [System.Collections.Generic.IEnumerator$1, System.Collections.IEnumerator, System.IDisposable, System.Collections.Generic.IEnumerable$1, System.Collections.IEnumerable], [System.Reflection.FieldInfo.prototype.$ctor.$new("$state", System.Int32, System.Reflection.FieldAttributes().Private, null, []), System.Reflection.FieldInfo.prototype.$ctor.$new("$this", WootzJs.Compiler.Tests.YieldTests.YieldClass, System.Reflection.FieldAttributes().Private, null, []), System.Reflection.FieldInfo.prototype.$ctor.$new("i", System.Int32, System.Reflection.FieldAttributes().Private, null, [])], [System.Reflection.MethodInfo.prototype.$ctor.$new("GetEnumerator", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ContinueDoWhile.prototype.GetEnumerator, [], System.Collections.IEnumerator, System.Reflection.MethodAttributes().Public, []), System.Reflection.MethodInfo.prototype.$ctor.$new("MoveNext", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ContinueDoWhile.prototype.MoveNext, [], System.Boolean, System.Reflection.MethodAttributes().Public, [])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$ContinueDoWhile.prototype.$ctor, [System.Reflection.ParameterInfo.prototype.$ctor.$new("$this", WootzJs.Compiler.Tests.YieldTests.YieldClass, 0, 0, null, [])], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
            $t.$StaticInitializer = function() {
            };
            $p.$state = null;
            $p.$this = null;
            $p.i = null;
            $p.$ctor = function($this) {
                (System.YieldIterator$1$(System.Object)).prototype.$ctor.call(this);
                this.$this = $this;
                this.$state = 1;
            };
            $p.$ctor.$type = $t;
            $p.$ctor.$new = function($this) {
                return new $p.$ctor.$type(this, $this);
            };
            $p.GetEnumerator = function() {
                return this;
            };
            $p.System$Collections$Generic$IEnumerable$1$GetEnumerator = $p.GetEnumerator;
            $p.MoveNext = function() {
                $top:
                while (true) {
                    switch (this.$state) {
                        case 0:
                            return false;
                        case 1:
                            this.i = 0;
                            this.$state = 2;
                            continue $top;
                        case 2:
                            this.i++;
                            if (this.i < 2)
                                continue;
                            this.$state = 3;
                            this.set_Current(this.i);
                            return true;
                        case 3:
                            if (this.i < 3)
                                this.$state = 2;
                            else
                                this.$state = 0;
                            continue $top;
                    }
                }
            };
            $p.System$Collections$IEnumerator$MoveNext = $p.MoveNext;
        }).call($t, $t.YieldEnumerator$ContinueDoWhile, $t.YieldEnumerator$ContinueDoWhile.prototype);
        $WootzJs$Compiler$Tests$AssemblyTypes.push($t.YieldEnumerator$ContinueDoWhile);
        function YieldEnumerator$TryFinally($constructor) {
            if (!$t.YieldEnumerator$TryFinally.$isStaticInitialized && ($constructor != null || !(this instanceof WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$TryFinally))) {
                $t.YieldEnumerator$TryFinally.$isStaticInitialized = true;
                $t.YieldEnumerator$TryFinally.$StaticInitializer();
            }
            if ($constructor != null)
                $constructor.apply(this, Array.prototype.slice.call(arguments, 1));
            if (!(this instanceof WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$TryFinally))
                return $t.YieldEnumerator$TryFinally;
        }
        $t.YieldEnumerator$TryFinally = YieldEnumerator$TryFinally;
        $t.YieldEnumerator$TryFinally.prototype = new System.YieldIterator$1();
        ($t.YieldEnumerator$TryFinally.$TypeInitializer = function($t, $p) {
            $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
            $p.$type = WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$TryFinally;
            $t.$baseType = System.YieldIterator$1;
            $p.$typeName = "WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$TryFinally";
            $t.$typeName = $p.$typeName;
            $t.$GetType = function() {
                return System.Type._GetTypeFromTypeFunc(this);
            };
            $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("YieldEnumerator$TryFinally", []);this.$type.Init("WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$TryFinally", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$TryFinally, (System.YieldIterator$1$(System.Object)), [System.Collections.Generic.IEnumerator$1, System.Collections.IEnumerator, System.IDisposable, System.Collections.Generic.IEnumerable$1, System.Collections.IEnumerable], [System.Reflection.FieldInfo.prototype.$ctor.$new("$state", System.Int32, System.Reflection.FieldAttributes().Private, null, []), System.Reflection.FieldInfo.prototype.$ctor.$new("$this", WootzJs.Compiler.Tests.YieldTests.YieldClass, System.Reflection.FieldAttributes().Private, null, []), System.Reflection.FieldInfo.prototype.$ctor.$new("i", System.Int32, System.Reflection.FieldAttributes().Private, null, []), System.Reflection.FieldInfo.prototype.$ctor.$new("$ex1", System.Exception, System.Reflection.FieldAttributes().Private, null, [])], [System.Reflection.MethodInfo.prototype.$ctor.$new("GetEnumerator", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$TryFinally.prototype.GetEnumerator, [], System.Collections.IEnumerator, System.Reflection.MethodAttributes().Public, []), System.Reflection.MethodInfo.prototype.$ctor.$new("MoveNext", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$TryFinally.prototype.MoveNext, [], System.Boolean, System.Reflection.MethodAttributes().Public, [])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$TryFinally.prototype.$ctor, [System.Reflection.ParameterInfo.prototype.$ctor.$new("$this", WootzJs.Compiler.Tests.YieldTests.YieldClass, 0, 0, null, [])], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
            $t.$StaticInitializer = function() {
            };
            $p.$state = null;
            $p.$this = null;
            $p.i = null;
            $p.$ex1 = null;
            $p.$ctor = function($this) {
                (System.YieldIterator$1$(System.Object)).prototype.$ctor.call(this);
                this.$this = $this;
                this.$state = 1;
            };
            $p.$ctor.$type = $t;
            $p.$ctor.$new = function($this) {
                return new $p.$ctor.$type(this, $this);
            };
            $p.GetEnumerator = function() {
                return this;
            };
            $p.System$Collections$Generic$IEnumerable$1$GetEnumerator = $p.GetEnumerator;
            $p.MoveNext = function() {
                $top:
                while (true) {
                    switch (this.$state) {
                        case 0:
                            return false;
                        case 1:
                            this.i = 0;
                            this.$state = 3;
                            continue $top;
                        case 2:
                            this.$state = 0;
                            this.set_Current(this.i);
                            return true;
                        case 3:
                            try {
                                this.i++;
                                this.$state = 5;
                                this.set_Current(this.i);
                                return true;
                            }
                            catch ($ex1) {
                                this.$ex1 = $ex1;
                                this.$state = 4;
                                continue $top;
                            }
                        case 4:
                            this.i++;
                            if (this.$ex1 != null)
                                throw this.$ex1.InternalInit(new Error());
                            this.$state = 2;
                            continue $top;
                        case 5:
                            try {
                                this.i++;
                                this.$state = 4;
                                this.set_Current(this.i);
                                return true;
                            }
                            catch ($ex1) {
                                this.$ex1 = $ex1;
                                this.$state = 4;
                                continue $top;
                            }
                    }
                }
            };
            $p.System$Collections$IEnumerator$MoveNext = $p.MoveNext;
        }).call($t, $t.YieldEnumerator$TryFinally, $t.YieldEnumerator$TryFinally.prototype);
        $WootzJs$Compiler$Tests$AssemblyTypes.push($t.YieldEnumerator$TryFinally);
        function YieldEnumerator$NestedTryFinally($constructor) {
            if (!$t.YieldEnumerator$NestedTryFinally.$isStaticInitialized && ($constructor != null || !(this instanceof WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$NestedTryFinally))) {
                $t.YieldEnumerator$NestedTryFinally.$isStaticInitialized = true;
                $t.YieldEnumerator$NestedTryFinally.$StaticInitializer();
            }
            if ($constructor != null)
                $constructor.apply(this, Array.prototype.slice.call(arguments, 1));
            if (!(this instanceof WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$NestedTryFinally))
                return $t.YieldEnumerator$NestedTryFinally;
        }
        $t.YieldEnumerator$NestedTryFinally = YieldEnumerator$NestedTryFinally;
        $t.YieldEnumerator$NestedTryFinally.prototype = new System.YieldIterator$1();
        ($t.YieldEnumerator$NestedTryFinally.$TypeInitializer = function($t, $p) {
            $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
            $p.$type = WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$NestedTryFinally;
            $t.$baseType = System.YieldIterator$1;
            $p.$typeName = "WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$NestedTryFinally";
            $t.$typeName = $p.$typeName;
            $t.$GetType = function() {
                return System.Type._GetTypeFromTypeFunc(this);
            };
            $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("YieldEnumerator$NestedTryFinally", []);this.$type.Init("WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$NestedTryFinally", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$NestedTryFinally, (System.YieldIterator$1$(System.Object)), [System.Collections.Generic.IEnumerator$1, System.Collections.IEnumerator, System.IDisposable, System.Collections.Generic.IEnumerable$1, System.Collections.IEnumerable], [System.Reflection.FieldInfo.prototype.$ctor.$new("$state", System.Int32, System.Reflection.FieldAttributes().Private, null, []), System.Reflection.FieldInfo.prototype.$ctor.$new("$this", WootzJs.Compiler.Tests.YieldTests.YieldClass, System.Reflection.FieldAttributes().Private, null, []), System.Reflection.FieldInfo.prototype.$ctor.$new("i", System.Int32, System.Reflection.FieldAttributes().Private, null, []), System.Reflection.FieldInfo.prototype.$ctor.$new("$ex1", System.Exception, System.Reflection.FieldAttributes().Private, null, []), System.Reflection.FieldInfo.prototype.$ctor.$new("$ex2", System.Exception, System.Reflection.FieldAttributes().Private, null, [])], [System.Reflection.MethodInfo.prototype.$ctor.$new("GetEnumerator", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$NestedTryFinally.prototype.GetEnumerator, [], System.Collections.IEnumerator, System.Reflection.MethodAttributes().Public, []), System.Reflection.MethodInfo.prototype.$ctor.$new("MoveNext", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$NestedTryFinally.prototype.MoveNext, [], System.Boolean, System.Reflection.MethodAttributes().Public, [])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$NestedTryFinally.prototype.$ctor, [System.Reflection.ParameterInfo.prototype.$ctor.$new("$this", WootzJs.Compiler.Tests.YieldTests.YieldClass, 0, 0, null, [])], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
            $t.$StaticInitializer = function() {
            };
            $p.$state = null;
            $p.$this = null;
            $p.i = null;
            $p.$ex1 = null;
            $p.$ex2 = null;
            $p.$ctor = function($this) {
                (System.YieldIterator$1$(System.Object)).prototype.$ctor.call(this);
                this.$this = $this;
                this.$state = 1;
            };
            $p.$ctor.$type = $t;
            $p.$ctor.$new = function($this) {
                return new $p.$ctor.$type(this, $this);
            };
            $p.GetEnumerator = function() {
                return this;
            };
            $p.System$Collections$Generic$IEnumerable$1$GetEnumerator = $p.GetEnumerator;
            $p.MoveNext = function() {
                $top:
                while (true) {
                    switch (this.$state) {
                        case 0:
                            return false;
                        case 1:
                            this.i = 0;
                            this.$state = 3;
                            continue $top;
                        case 2:
                            this.$state = 0;
                            this.set_Current(this.i + 20);
                            return true;
                        case 3:
                            try {
                                this.$state = 5;
                                this.set_Current(1);
                                return true;
                            }
                            catch ($ex1) {
                                this.$ex1 = $ex1;
                                this.$state = 4;
                                continue $top;
                            }
                        case 4:
                            this.i++;
                            if (this.$ex1 != null)
                                throw this.$ex1.InternalInit(new Error());
                            this.$state = 2;
                            continue $top;
                        case 5:
                            try {
                                this.$state = 6;
                                this.set_Current(2);
                                return true;
                            }
                            catch ($ex1) {
                                this.$ex1 = $ex1;
                                this.$state = 4;
                                continue $top;
                            }
                        case 6:
                            try {
                                this.$state = 9;
                                this.set_Current(3);
                                return true;
                            }
                            catch ($ex2) {
                                this.$ex2 = $ex2;
                                this.$state = 8;
                                continue $top;
                            }
                        case 7:
                            try {
                                this.$state = 4;
                                this.set_Current(this.i + 10);
                                return true;
                            }
                            catch ($ex1) {
                                this.$ex1 = $ex1;
                                this.$state = 4;
                                continue $top;
                            }
                        case 8:
                            this.i++;
                            if (this.$ex2 != null)
                                throw this.$ex2.InternalInit(new Error());
                            this.$state = 7;
                            continue $top;
                        case 9:
                            try {
                                this.$state = 8;
                                this.set_Current(4);
                                return true;
                            }
                            catch ($ex2) {
                                this.$ex2 = $ex2;
                                this.$state = 8;
                                continue $top;
                            }
                    }
                }
            };
            $p.System$Collections$IEnumerator$MoveNext = $p.MoveNext;
        }).call($t, $t.YieldEnumerator$NestedTryFinally, $t.YieldEnumerator$NestedTryFinally.prototype);
        $WootzJs$Compiler$Tests$AssemblyTypes.push($t.YieldEnumerator$NestedTryFinally);
        function YieldEnumerator$TryFinallyThrowsException($constructor) {
            if (!$t.YieldEnumerator$TryFinallyThrowsException.$isStaticInitialized && ($constructor != null || !(this instanceof WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$TryFinallyThrowsException))) {
                $t.YieldEnumerator$TryFinallyThrowsException.$isStaticInitialized = true;
                $t.YieldEnumerator$TryFinallyThrowsException.$StaticInitializer();
            }
            if ($constructor != null)
                $constructor.apply(this, Array.prototype.slice.call(arguments, 1));
            if (!(this instanceof WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$TryFinallyThrowsException))
                return $t.YieldEnumerator$TryFinallyThrowsException;
        }
        $t.YieldEnumerator$TryFinallyThrowsException = YieldEnumerator$TryFinallyThrowsException;
        $t.YieldEnumerator$TryFinallyThrowsException.prototype = new System.YieldIterator$1();
        ($t.YieldEnumerator$TryFinallyThrowsException.$TypeInitializer = function($t, $p) {
            $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
            $p.$type = WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$TryFinallyThrowsException;
            $t.$baseType = System.YieldIterator$1;
            $p.$typeName = "WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$TryFinallyThrowsException";
            $t.$typeName = $p.$typeName;
            $t.$GetType = function() {
                return System.Type._GetTypeFromTypeFunc(this);
            };
            $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("YieldEnumerator$TryFinallyThrowsException", []);this.$type.Init("WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$TryFinallyThrowsException", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$TryFinallyThrowsException, (System.YieldIterator$1$(System.Object)), [System.Collections.Generic.IEnumerator$1, System.Collections.IEnumerator, System.IDisposable, System.Collections.Generic.IEnumerable$1, System.Collections.IEnumerable], [System.Reflection.FieldInfo.prototype.$ctor.$new("$state", System.Int32, System.Reflection.FieldAttributes().Private, null, []), System.Reflection.FieldInfo.prototype.$ctor.$new("$this", WootzJs.Compiler.Tests.YieldTests.YieldClass, System.Reflection.FieldAttributes().Private, null, []), System.Reflection.FieldInfo.prototype.$ctor.$new("flag", System.Boolean, System.Reflection.FieldAttributes().Private, null, []), System.Reflection.FieldInfo.prototype.$ctor.$new("i", System.Int32, System.Reflection.FieldAttributes().Private, null, []), System.Reflection.FieldInfo.prototype.$ctor.$new("$ex1", System.Exception, System.Reflection.FieldAttributes().Private, null, [])], [System.Reflection.MethodInfo.prototype.$ctor.$new("GetEnumerator", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$TryFinallyThrowsException.prototype.GetEnumerator, [], System.Collections.IEnumerator, System.Reflection.MethodAttributes().Public, []), System.Reflection.MethodInfo.prototype.$ctor.$new("MoveNext", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$TryFinallyThrowsException.prototype.MoveNext, [], System.Boolean, System.Reflection.MethodAttributes().Public, [])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$TryFinallyThrowsException.prototype.$ctor, [System.Reflection.ParameterInfo.prototype.$ctor.$new("$this", WootzJs.Compiler.Tests.YieldTests.YieldClass, 0, 0, null, []), System.Reflection.ParameterInfo.prototype.$ctor.$new("flag", System.Boolean, 1, 0, null, [])], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
            $t.$StaticInitializer = function() {
            };
            $p.$state = null;
            $p.$this = null;
            $p.flag = null;
            $p.i = null;
            $p.$ex1 = null;
            $p.$ctor = function($this, flag) {
                (System.YieldIterator$1$(System.Object)).prototype.$ctor.call(this);
                this.$this = $this;
                this.flag = flag;
                this.$state = 1;
            };
            $p.$ctor.$type = $t;
            $p.$ctor.$new = function($this, flag) {
                return new $p.$ctor.$type(this, $this, flag);
            };
            $p.GetEnumerator = function() {
                return this;
            };
            $p.System$Collections$Generic$IEnumerable$1$GetEnumerator = $p.GetEnumerator;
            $p.MoveNext = function() {
                $top:
                while (true) {
                    switch (this.$state) {
                        case 0:
                            return false;
                        case 1:
                            this.i = 0;
                            this.$state = 3;
                            continue $top;
                        case 2:
                            this.$state = 0;
                            this.set_Current(this.i);
                            return true;
                        case 3:
                            try {
                                this.i++;
                                this.$state = 5;
                                this.set_Current(this.i);
                                return true;
                            }
                            catch ($ex1) {
                                this.$ex1 = $ex1;
                                this.$state = 4;
                                continue $top;
                            }
                        case 4:
                            this.i++;
                            if (this.$ex1 != null)
                                throw this.$ex1.InternalInit(new Error());
                            this.$state = 2;
                            continue $top;
                        case 5:
                            if (this.flag)
                                throw System.Exception.prototype.$ctor.$new().InternalInit(new Error());
                    }
                }
            };
            $p.System$Collections$IEnumerator$MoveNext = $p.MoveNext;
        }).call($t, $t.YieldEnumerator$TryFinallyThrowsException, $t.YieldEnumerator$TryFinallyThrowsException.prototype);
        $WootzJs$Compiler$Tests$AssemblyTypes.push($t.YieldEnumerator$TryFinallyThrowsException);
        function YieldEnumerator$LabeledStatementGotoFirst($constructor) {
            if (!$t.YieldEnumerator$LabeledStatementGotoFirst.$isStaticInitialized && ($constructor != null || !(this instanceof WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$LabeledStatementGotoFirst))) {
                $t.YieldEnumerator$LabeledStatementGotoFirst.$isStaticInitialized = true;
                $t.YieldEnumerator$LabeledStatementGotoFirst.$StaticInitializer();
            }
            if ($constructor != null)
                $constructor.apply(this, Array.prototype.slice.call(arguments, 1));
            if (!(this instanceof WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$LabeledStatementGotoFirst))
                return $t.YieldEnumerator$LabeledStatementGotoFirst;
        }
        $t.YieldEnumerator$LabeledStatementGotoFirst = YieldEnumerator$LabeledStatementGotoFirst;
        $t.YieldEnumerator$LabeledStatementGotoFirst.prototype = new System.YieldIterator$1();
        ($t.YieldEnumerator$LabeledStatementGotoFirst.$TypeInitializer = function($t, $p) {
            $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
            $p.$type = WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$LabeledStatementGotoFirst;
            $t.$baseType = System.YieldIterator$1;
            $p.$typeName = "WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$LabeledStatementGotoFirst";
            $t.$typeName = $p.$typeName;
            $t.$GetType = function() {
                return System.Type._GetTypeFromTypeFunc(this);
            };
            $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("YieldEnumerator$LabeledStatementGotoFirst", []);this.$type.Init("WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$LabeledStatementGotoFirst", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$LabeledStatementGotoFirst, (System.YieldIterator$1$(System.Object)), [System.Collections.Generic.IEnumerator$1, System.Collections.IEnumerator, System.IDisposable, System.Collections.Generic.IEnumerable$1, System.Collections.IEnumerable], [System.Reflection.FieldInfo.prototype.$ctor.$new("$state", System.Int32, System.Reflection.FieldAttributes().Private, null, []), System.Reflection.FieldInfo.prototype.$ctor.$new("$this", WootzJs.Compiler.Tests.YieldTests.YieldClass, System.Reflection.FieldAttributes().Private, null, []), System.Reflection.FieldInfo.prototype.$ctor.$new("flag", System.Boolean, System.Reflection.FieldAttributes().Private, null, []), System.Reflection.FieldInfo.prototype.$ctor.$new("i", System.Int32, System.Reflection.FieldAttributes().Private, null, [])], [System.Reflection.MethodInfo.prototype.$ctor.$new("GetEnumerator", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$LabeledStatementGotoFirst.prototype.GetEnumerator, [], System.Collections.IEnumerator, System.Reflection.MethodAttributes().Public, []), System.Reflection.MethodInfo.prototype.$ctor.$new("MoveNext", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$LabeledStatementGotoFirst.prototype.MoveNext, [], System.Boolean, System.Reflection.MethodAttributes().Public, [])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$LabeledStatementGotoFirst.prototype.$ctor, [System.Reflection.ParameterInfo.prototype.$ctor.$new("$this", WootzJs.Compiler.Tests.YieldTests.YieldClass, 0, 0, null, []), System.Reflection.ParameterInfo.prototype.$ctor.$new("flag", System.Boolean, 1, 0, null, [])], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
            $t.$StaticInitializer = function() {
            };
            $p.$state = null;
            $p.$this = null;
            $p.flag = null;
            $p.i = null;
            $p.$ctor = function($this, flag) {
                (System.YieldIterator$1$(System.Object)).prototype.$ctor.call(this);
                this.$this = $this;
                this.flag = flag;
                this.$state = 1;
            };
            $p.$ctor.$type = $t;
            $p.$ctor.$new = function($this, flag) {
                return new $p.$ctor.$type(this, $this, flag);
            };
            $p.GetEnumerator = function() {
                return this;
            };
            $p.System$Collections$Generic$IEnumerable$1$GetEnumerator = $p.GetEnumerator;
            $p.MoveNext = function() {
                $top:
                while (true) {
                    switch (this.$state) {
                        case 0:
                            return false;
                        case 1:
                            this.i = 1;
                            if (this.flag) {
                                this.$state = 4;
                                continue $top;
                            }
                            this.$state = 2;
                            continue $top;
                        case 2:
                            this.$state = 3;
                            this.set_Current(this.i);
                            return true;
                        case 3:
                            this.i++;
                            this.$state = 4;
                            continue $top;
                        case 4:
                            this.$state = 0;
                            this.set_Current(this.i);
                            return true;
                    }
                }
            };
            $p.System$Collections$IEnumerator$MoveNext = $p.MoveNext;
        }).call($t, $t.YieldEnumerator$LabeledStatementGotoFirst, $t.YieldEnumerator$LabeledStatementGotoFirst.prototype);
        $WootzJs$Compiler$Tests$AssemblyTypes.push($t.YieldEnumerator$LabeledStatementGotoFirst);
        function YieldEnumerator$LabeledStatementGotoSecond($constructor) {
            if (!$t.YieldEnumerator$LabeledStatementGotoSecond.$isStaticInitialized && ($constructor != null || !(this instanceof WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$LabeledStatementGotoSecond))) {
                $t.YieldEnumerator$LabeledStatementGotoSecond.$isStaticInitialized = true;
                $t.YieldEnumerator$LabeledStatementGotoSecond.$StaticInitializer();
            }
            if ($constructor != null)
                $constructor.apply(this, Array.prototype.slice.call(arguments, 1));
            if (!(this instanceof WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$LabeledStatementGotoSecond))
                return $t.YieldEnumerator$LabeledStatementGotoSecond;
        }
        $t.YieldEnumerator$LabeledStatementGotoSecond = YieldEnumerator$LabeledStatementGotoSecond;
        $t.YieldEnumerator$LabeledStatementGotoSecond.prototype = new System.YieldIterator$1();
        ($t.YieldEnumerator$LabeledStatementGotoSecond.$TypeInitializer = function($t, $p) {
            $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
            $p.$type = WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$LabeledStatementGotoSecond;
            $t.$baseType = System.YieldIterator$1;
            $p.$typeName = "WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$LabeledStatementGotoSecond";
            $t.$typeName = $p.$typeName;
            $t.$GetType = function() {
                return System.Type._GetTypeFromTypeFunc(this);
            };
            $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("YieldEnumerator$LabeledStatementGotoSecond", []);this.$type.Init("WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$LabeledStatementGotoSecond", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$LabeledStatementGotoSecond, (System.YieldIterator$1$(System.Object)), [System.Collections.Generic.IEnumerator$1, System.Collections.IEnumerator, System.IDisposable, System.Collections.Generic.IEnumerable$1, System.Collections.IEnumerable], [System.Reflection.FieldInfo.prototype.$ctor.$new("$state", System.Int32, System.Reflection.FieldAttributes().Private, null, []), System.Reflection.FieldInfo.prototype.$ctor.$new("$this", WootzJs.Compiler.Tests.YieldTests.YieldClass, System.Reflection.FieldAttributes().Private, null, []), System.Reflection.FieldInfo.prototype.$ctor.$new("i", System.Int32, System.Reflection.FieldAttributes().Private, null, [])], [System.Reflection.MethodInfo.prototype.$ctor.$new("GetEnumerator", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$LabeledStatementGotoSecond.prototype.GetEnumerator, [], System.Collections.IEnumerator, System.Reflection.MethodAttributes().Public, []), System.Reflection.MethodInfo.prototype.$ctor.$new("MoveNext", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$LabeledStatementGotoSecond.prototype.MoveNext, [], System.Boolean, System.Reflection.MethodAttributes().Public, [])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$LabeledStatementGotoSecond.prototype.$ctor, [System.Reflection.ParameterInfo.prototype.$ctor.$new("$this", WootzJs.Compiler.Tests.YieldTests.YieldClass, 0, 0, null, [])], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
            $t.$StaticInitializer = function() {
            };
            $p.$state = null;
            $p.$this = null;
            $p.i = null;
            $p.$ctor = function($this) {
                (System.YieldIterator$1$(System.Object)).prototype.$ctor.call(this);
                this.$this = $this;
                this.$state = 1;
            };
            $p.$ctor.$type = $t;
            $p.$ctor.$new = function($this) {
                return new $p.$ctor.$type(this, $this);
            };
            $p.GetEnumerator = function() {
                return this;
            };
            $p.System$Collections$Generic$IEnumerable$1$GetEnumerator = $p.GetEnumerator;
            $p.MoveNext = function() {
                $top:
                while (true) {
                    switch (this.$state) {
                        case 0:
                            return false;
                        case 1:
                            this.i = 0;
                            this.$state = 2;
                            continue $top;
                        case 2:
                            this.i++;
                            this.$state = 3;
                            continue $top;
                        case 3:
                            this.$state = 4;
                            this.set_Current(this.i);
                            return true;
                        case 4:
                            if (this.i < 3) {
                                this.$state = 2;
                                continue $top;
                            }
                            this.$state = 0;
                            continue $top;
                    }
                }
            };
            $p.System$Collections$IEnumerator$MoveNext = $p.MoveNext;
        }).call($t, $t.YieldEnumerator$LabeledStatementGotoSecond, $t.YieldEnumerator$LabeledStatementGotoSecond.prototype);
        $WootzJs$Compiler$Tests$AssemblyTypes.push($t.YieldEnumerator$LabeledStatementGotoSecond);
        function YieldEnumerator$CollidingForeach($constructor) {
            if (!$t.YieldEnumerator$CollidingForeach.$isStaticInitialized && ($constructor != null || !(this instanceof WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$CollidingForeach))) {
                $t.YieldEnumerator$CollidingForeach.$isStaticInitialized = true;
                $t.YieldEnumerator$CollidingForeach.$StaticInitializer();
            }
            if ($constructor != null)
                $constructor.apply(this, Array.prototype.slice.call(arguments, 1));
            if (!(this instanceof WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$CollidingForeach))
                return $t.YieldEnumerator$CollidingForeach;
        }
        $t.YieldEnumerator$CollidingForeach = YieldEnumerator$CollidingForeach;
        $t.YieldEnumerator$CollidingForeach.prototype = new System.YieldIterator$1();
        ($t.YieldEnumerator$CollidingForeach.$TypeInitializer = function($t, $p) {
            $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
            $p.$type = WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$CollidingForeach;
            $t.$baseType = System.YieldIterator$1;
            $p.$typeName = "WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$CollidingForeach";
            $t.$typeName = $p.$typeName;
            $t.$GetType = function() {
                return System.Type._GetTypeFromTypeFunc(this);
            };
            $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("YieldEnumerator$CollidingForeach", []);this.$type.Init("WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$CollidingForeach", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$CollidingForeach, (System.YieldIterator$1$(System.Object)), [System.Collections.Generic.IEnumerator$1, System.Collections.IEnumerator, System.IDisposable, System.Collections.Generic.IEnumerable$1, System.Collections.IEnumerable], [System.Reflection.FieldInfo.prototype.$ctor.$new("$state", System.Int32, System.Reflection.FieldAttributes().Private, null, []), System.Reflection.FieldInfo.prototype.$ctor.$new("$this", WootzJs.Compiler.Tests.YieldTests.YieldClass, System.Reflection.FieldAttributes().Private, null, []), System.Reflection.FieldInfo.prototype.$ctor.$new("item", System.Int32, System.Reflection.FieldAttributes().Private, null, []), System.Reflection.FieldInfo.prototype.$ctor.$new("item$enumerator", System.Collections.IEnumerator, System.Reflection.FieldAttributes().Private, null, []), System.Reflection.FieldInfo.prototype.$ctor.$new("item2", System.Int32, System.Reflection.FieldAttributes().Private, null, []), System.Reflection.FieldInfo.prototype.$ctor.$new("item2$enumerator", System.Collections.IEnumerator, System.Reflection.FieldAttributes().Private, null, [])], [System.Reflection.MethodInfo.prototype.$ctor.$new("GetEnumerator", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$CollidingForeach.prototype.GetEnumerator, [], System.Collections.IEnumerator, System.Reflection.MethodAttributes().Public, []), System.Reflection.MethodInfo.prototype.$ctor.$new("MoveNext", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$CollidingForeach.prototype.MoveNext, [], System.Boolean, System.Reflection.MethodAttributes().Public, [])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$CollidingForeach.prototype.$ctor, [System.Reflection.ParameterInfo.prototype.$ctor.$new("$this", WootzJs.Compiler.Tests.YieldTests.YieldClass, 0, 0, null, [])], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
            $t.$StaticInitializer = function() {
            };
            $p.$state = null;
            $p.$this = null;
            $p.item = null;
            $p.item$enumerator = null;
            $p.item2 = null;
            $p.item2$enumerator = null;
            $p.$ctor = function($this) {
                (System.YieldIterator$1$(System.Object)).prototype.$ctor.call(this);
                this.$this = $this;
                this.$state = 1;
            };
            $p.$ctor.$type = $t;
            $p.$ctor.$new = function($this) {
                return new $p.$ctor.$type(this, $this);
            };
            $p.GetEnumerator = function() {
                return this;
            };
            $p.System$Collections$Generic$IEnumerable$1$GetEnumerator = $p.GetEnumerator;
            $p.MoveNext = function() {
                $top:
                while (true) {
                    switch (this.$state) {
                        case 0:
                            return false;
                        case 1:
                            this.item$enumerator = System.Object.$$InitializeArray([1, 2], System.Int32).GetEnumerator();
                            this.$state = 2;
                            continue $top;
                        case 2:
                            while (this.item$enumerator.System$Collections$IEnumerator$MoveNext()) {
                                this.item = this.item$enumerator.get_Current();
                                this.$state = 2;
                                this.set_Current(this.item);
                                return true;
                            }
                            this.$state = 3;
                            continue $top;
                        case 3:
                            this.item2$enumerator = System.Object.$$InitializeArray([3, 4], System.Int32).GetEnumerator();
                            this.$state = 4;
                            continue $top;
                        case 4:
                            while (this.item2$enumerator.System$Collections$IEnumerator$MoveNext()) {
                                this.item2 = this.item2$enumerator.get_Current();
                                this.$state = 4;
                                this.set_Current(this.item2);
                                return true;
                            }
                            this.$state = 0;
                            continue $top;
                    }
                }
            };
            $p.System$Collections$IEnumerator$MoveNext = $p.MoveNext;
        }).call($t, $t.YieldEnumerator$CollidingForeach, $t.YieldEnumerator$CollidingForeach.prototype);
        $WootzJs$Compiler$Tests$AssemblyTypes.push($t.YieldEnumerator$CollidingForeach);
        function YieldEnumerator$CollidingFor($constructor) {
            if (!$t.YieldEnumerator$CollidingFor.$isStaticInitialized && ($constructor != null || !(this instanceof WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$CollidingFor))) {
                $t.YieldEnumerator$CollidingFor.$isStaticInitialized = true;
                $t.YieldEnumerator$CollidingFor.$StaticInitializer();
            }
            if ($constructor != null)
                $constructor.apply(this, Array.prototype.slice.call(arguments, 1));
            if (!(this instanceof WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$CollidingFor))
                return $t.YieldEnumerator$CollidingFor;
        }
        $t.YieldEnumerator$CollidingFor = YieldEnumerator$CollidingFor;
        $t.YieldEnumerator$CollidingFor.prototype = new System.YieldIterator$1();
        ($t.YieldEnumerator$CollidingFor.$TypeInitializer = function($t, $p) {
            $t.$GetAssembly = window.$WootzJs$Compiler$Tests$GetAssembly;
            $p.$type = WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$CollidingFor;
            $t.$baseType = System.YieldIterator$1;
            $p.$typeName = "WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$CollidingFor";
            $t.$typeName = $p.$typeName;
            $t.$GetType = function() {
                return System.Type._GetTypeFromTypeFunc(this);
            };
            $t.$CreateType = function() {this.$type = System.Type.prototype.$ctor.$new("YieldEnumerator$CollidingFor", []);this.$type.Init("WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$CollidingFor", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$CollidingFor, (System.YieldIterator$1$(System.Object)), [System.Collections.Generic.IEnumerator$1, System.Collections.IEnumerator, System.IDisposable, System.Collections.Generic.IEnumerable$1, System.Collections.IEnumerable], [System.Reflection.FieldInfo.prototype.$ctor.$new("$state", System.Int32, System.Reflection.FieldAttributes().Private, null, []), System.Reflection.FieldInfo.prototype.$ctor.$new("$this", WootzJs.Compiler.Tests.YieldTests.YieldClass, System.Reflection.FieldAttributes().Private, null, []), System.Reflection.FieldInfo.prototype.$ctor.$new("i", System.Int32, System.Reflection.FieldAttributes().Private, null, []), System.Reflection.FieldInfo.prototype.$ctor.$new("i2", System.Int32, System.Reflection.FieldAttributes().Private, null, [])], [System.Reflection.MethodInfo.prototype.$ctor.$new("GetEnumerator", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$CollidingFor.prototype.GetEnumerator, [], System.Collections.IEnumerator, System.Reflection.MethodAttributes().Public, []), System.Reflection.MethodInfo.prototype.$ctor.$new("MoveNext", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$CollidingFor.prototype.MoveNext, [], System.Boolean, System.Reflection.MethodAttributes().Public, [])], [System.Reflection.ConstructorInfo.prototype.$ctor.$new("$ctor", WootzJs.Compiler.Tests.YieldTests.YieldClass.YieldEnumerator$CollidingFor.prototype.$ctor, [System.Reflection.ParameterInfo.prototype.$ctor.$new("$this", WootzJs.Compiler.Tests.YieldTests.YieldClass, 0, 0, null, [])], System.Reflection.MethodAttributes().Public, [])], [], [], false);return this.$type;};
            $t.$StaticInitializer = function() {
            };
            $p.$state = null;
            $p.$this = null;
            $p.i = null;
            $p.i2 = null;
            $p.$ctor = function($this) {
                (System.YieldIterator$1$(System.Object)).prototype.$ctor.call(this);
                this.$this = $this;
                this.$state = 1;
            };
            $p.$ctor.$type = $t;
            $p.$ctor.$new = function($this) {
                return new $p.$ctor.$type(this, $this);
            };
            $p.GetEnumerator = function() {
                return this;
            };
            $p.System$Collections$Generic$IEnumerable$1$GetEnumerator = $p.GetEnumerator;
            $p.MoveNext = function() {
                $top:
                while (true) {
                    switch (this.$state) {
                        case 0:
                            return false;
                        case 1:
                            this.i = 0;
                            this.$state = 2;
                            continue $top;
                        case 2:
                            while (this.i < 3) {
                                this.$state = 4;
                                this.set_Current(this.i);
                                return true;
                            }
                            this.$state = 3;
                            continue $top;
                        case 3:
                            this.i = 2;
                            this.$state = 5;
                            continue $top;
                        case 4:
                            this.i++;
                            this.$state = 2;
                            continue $top;
                        case 5:
                            while (this.i2 < 5) {
                                this.$state = 6;
                                this.set_Current(this.i2);
                                return true;
                            }
                            this.$state = 0;
                            continue $top;
                        case 6:
                            this.i2++;
                            this.$state = 5;
                            continue $top;
                    }
                }
            };
            $p.System$Collections$IEnumerator$MoveNext = $p.MoveNext;
        }).call($t, $t.YieldEnumerator$CollidingFor, $t.YieldEnumerator$CollidingFor.prototype);
        $WootzJs$Compiler$Tests$AssemblyTypes.push($t.YieldEnumerator$CollidingFor);
    }).call($t, $t.YieldClass, $t.YieldClass.prototype);
    $WootzJs$Compiler$Tests$AssemblyTypes.push($t.YieldClass);
}).call(null, WootzJs.Compiler.Tests.YieldTests, WootzJs.Compiler.Tests.YieldTests.prototype);
$WootzJs$Compiler$Tests$AssemblyTypes.push(WootzJs.Compiler.Tests.YieldTests);
WootzJs.Compiler.Tests.TestsApplication.Main();
