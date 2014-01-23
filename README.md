WootzJs
=======

WootzJs is a C# to Javascript cross-compiler.  You write your code in C#, and the result is
Javascript that can be run in any browser (or other host).  You may be wondering why we need
another C# to JS compiler, since there are already at least three options available to 
developers wishing to leverage this concept.  

* Script#
* JSIL
* SharpKit

All of these products bring something to the table that the others do not.  

Script#
-------

Script# is very stable and consistent -- the featureset it implements works and there are rarely edge-case 
surprises that fail.  However, it is still stuck in C# 2.0 (without even the generics found in
that version of C#).  This means that the modern C# developer is giving up an *enormous* set of
language features that most of us depend on without reservation -- particularly the 
aforementioned generics in addition to lambdas and LINQ.  This makes Script# essentially a non-starter
for many developers.

JSIL
-------

JSIL is an *extremely* impressive work that cross-compiles IL into Javascript.  It is so robust it can easily
handle the cross-compilation of large 3d video games.  The downside is that because of its completeness the 
resultant Javascript files are *enormous*.  If you just want mscorlib.dll and System.dll, it's about a 50MB
download.  Furthermore, this project is really not designed to be used in the context of a web application, 
and the amount of effort required to get started is a bit daunting.

SharpKit
-------

This commercial product strives to provide support for most of the C# 4.0 language features.  It generally
succeeds and there's a decent chance this product will meet your needs.  It is lightweight (small .JS files),
supports modern C# language features (generics, LINQ, etc.) and is usually reliable, though there are a 
surprising number of edge cases that you will invariably encounter that are not supported.  For example,
the type system is shallow and does not support representing generics or arrays (i.e. `typeof(Foo[]) == 
typeof(Bar[])`, `typeof(List<string>) == typeof(List<int>)`).  The support for reflection is limited,
with various member types incapable of supporting attributes.  Expression tree support is non-existent, 
and the yield implementation is inefficient (no state machine).

So that brings us back to...

WootzJs
-------

WootzJs strives to be a fairly lightweight (goal is a ~100k minified JS file) cross-compiler that allows
for all the major C# language features.  In fact, all features except for async/await should be already
supported. (and support for async is forthcoming, but will probably take a couple weeks to implement)

Notable Language Features Supported:

* `yield` statements (generated as an efficient state machine)
* `ref` and `out` parameters
* lambdas and anonymous methods
* expression trees
* lambdas and delegates (with proper capturing of `this`)
* generics support in both the compiler and the runtime
* C# semantics for closures (if you capture a variable via closure, that variable retains its value
at the time of capture if the value were to change in the outer scope.

There are extensive QUnit tests that allow for a high degree of confidence in the reliability
of its output.  

What WootzJs Is Not
------

WootzJs has been designed from the beginning with the following goals as *explicitly* not part of the 
mission.

* The prettiness of the JS.  Obviously it's better for the code to look pretty than not, and the output
should be fairly readable.  That being said, if there's ever even a bit of tradeoff between the looks of the
output and the behavior of the code, behavior wins every time.
* The size of the output.  Again, it's clearly better for the output to be smaller than larger, but if for
example, we have to decide between reflection and output size, reflection wins.  That being said, it is 
a requirement that the output size be manageable, so anything over a few 100K would be way over the 
limit.
* The interoperability of your C# types with Javascript APIs.  For example, C# properties are implemented 
using a getter and setter.  Anonymous types are classes composed of properties.  Therefore, anonymous types
are composed of backing fields with getters and setters.  This is clearly fine when living in C#, but if 
you try to pass an object with properties (anonymous or otherwise) to something expecting to consume JSON,
the consumer will have a sad.  That being said, there are (will) of course be APIs to serialize to and from
JSON.
* The appearance that your C# classes and methods are actually Javascript "classes" and functions.  For 
example, the `new` operator in Javascript applies to a function.  Naturally, this means that the concept
of constructor overloads go right out the window.  (Needless to say, all forms of method overloading is a 
foreign concept to JS).  This means that if you have a class `Foo` in Javascript, you would construct it via 
`new Foo(arg1, arg2, ...)`.  In WootzJs, each constructor is its own method defined in the prototype.  Thus,
to instantiate `Foo` in WootzJs, the compiler generates code like `Foo.prototype.$ctor.$new()`.  