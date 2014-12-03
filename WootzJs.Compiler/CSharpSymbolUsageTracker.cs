using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.WootzJs;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.MSBuild;
using WootzJs.Compiler.JsAst;

namespace WootzJs.Compiler
{
    public class CSharpSymbolUsageTracker : CSharpSyntaxWalker
    {
        private HashSet<string> usedSymbols = new HashSet<string>();
        private HashSet<string> allSymbols = new HashSet<string>();

    }
}