Important Update on Requirements
======
With the latest Roslyn bits, you **must** obtain the [Microsoft Build Tools 2015 Preview](http://www.visualstudio.com/en-us/downloads/visual-studio-2015-downloads-vs).  The latest version of
roslyn has dependencies on assemblies from this download and are absolutely required.

WootzJs
----

WootzJs is a C# to Javascript cross-compiler.  You write your code in C#, and the result is
Javascript that can be run in any browser (or other host).  It's built on top of [Microsoft Roslyn](http://msdn.microsoft.com/en-us/vstudio/roslyn.aspx), which handles the complex process of converting your C# code into syntax trees with symbol information.

The design is focused on facilitating [single-page applications](http://en.wikipedia.org/wiki/Single-page_application).  While it is possible to build standard web sites where each URL resolves to a different page, you will be fighting WootzJs in order to achieve this.   The goal is to produce a single `.js` file for the entire site (or at least for every "sub site").  To a large extent, it is far simpler to bind HTML elements to your C# code than vice-versa.  That being said, any metaphor is workable.

WootzJs also includes a web framework, `WootzJs.Mvc` for creating single-page applications.  It leverages the HTML 5 history API to create an MVC framework with routing, controllers, models, and views.  The views are generated programmatically via C#, in a style similar to Google Web Toolkit.  The MVC portion looks substantively similar to what you'd expect coming from ASP.NET/MVC.  

* [Getting Started](https://github.com/kswoll/WootzJs/wiki/Getting-Started)
    A series of guides starting with writing a "Hello World" app.
* [Interacting with the Browser](https://github.com/kswoll/WootzJs/wiki/Interacting-With-the-Browser)
    The next in the series, showing how create HTML content in the browser.
* [Limitations](https://github.com/kswoll/WootzJs/wiki/Limitations)
    A list of C# language features that are not supported.
* [Comparisons with other C# to Javascript cross-compilers](https://github.com/kswoll/WootzJs/wiki/Comparisons-with-other-C%23-to-JS-Cross-compilers)
    There are several other options available to those who want to convert C# to Javascript.  How do the available options compare with WootzJs?
* [Technical Overview](https://github.com/kswoll/WootzJs/wiki/Technical-Design)
    A technical description of the transformation process and its generated output.
* [JSNI](https://github.com/kswoll/WootzJs/wiki/JSNI---JavaScript-Native-Interface), or JavaScript Native Interface, is how you generate JS code that would be otherwise inexpressible in C#.
* [Customizing the Generated Output](https://github.com/kswoll/WootzJs/wiki/Customizing-the-Generated-Output)
    Similar to JSNI, you can use `[Js]` attribute to customize various aspects of the generation process.  
* [Contributing](https://github.com/kswoll/WootzJs/wiki/Contributing) to WootzJs
* [Project Map](https://github.com/kswoll/WootzJs/wiki/Project-Map)
