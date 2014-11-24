﻿using WootzJs.Compiler.Tests.SubNamespaceForTest;

namespace WootzJs.Compiler.Tests
{
    partial class PartialClassWithUsings
    {
        static void PlatformInit()
        {
            Value = new PartialClassWithUsingsTestClass("initialized").Value;
        }
    }
}
