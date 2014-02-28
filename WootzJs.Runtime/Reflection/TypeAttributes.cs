#region License

//-----------------------------------------------------------------------
// <copyright>
// The MIT License (MIT)
// 
// Copyright (c) 2014 Kirk S Woll
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of
// this software and associated documentation files (the "Software"), to deal in
// the Software without restriction, including without limitation the rights to
// use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
// the Software, and to permit persons to whom the Software is furnished to do so,
// subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
// FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
// COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
// IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
// CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// </copyright>
//-----------------------------------------------------------------------

#endregion

namespace System.Reflection
{
    /// <summary>
    /// Specifies type attributes.
    /// </summary>
    [Flags]
    public enum TypeAttributes
    {
        VisibilityMask    =   0x00000007,
        NotPublic         =   0x00000000,     // Class is not public scope.
        Public            =   0x00000001,     // Class is public scope.
        NestedPublic      =   0x00000002,     // Class is nested with public visibility.
        NestedPrivate     =   0x00000003,     // Class is nested with private visibility.
        NestedFamily      =   0x00000004,     // Class is nested with family visibility.
        NestedAssembly    =   0x00000005,     // Class is nested with assembly visibility.
        NestedFamANDAssem =   0x00000006,     // Class is nested with family and assembly visibility.
        NestedFamORAssem  =   0x00000007,     // Class is nested with family or assembly visibility.
    
        // Use this mask to retrieve class layout informaiton
        // 0 is AutoLayout, 0x2 is SequentialLayout, 4 is ExplicitLayout
        LayoutMask        =   0x00000018,
        AutoLayout        =   0x00000000,     // Class fields are auto-laid out
        SequentialLayout  =   0x00000008,     // Class fields are laid out sequentially
        ExplicitLayout    =   0x00000010,     // Layout is supplied explicitly
        // end layout mask
    
        // Use this mask to distinguish whether a type declaration is an interface.  (Class vs. ValueType done based on whether it subclasses S.ValueType)
        ClassSemanticsMask=   0x00000020,
        Class             =   0x00000000,     // Type is a class (or a value type).
        Interface         =   0x00000020,     // Type is an interface.
    
        // Special semantics in addition to class semantics.
        Abstract          =   0x00000080,     // Class is abstract
        Sealed            =   0x00000100,     // Class is concrete and may not be extended
        SpecialName       =   0x00000400,     // Class name is special.  Name describes how.
    
        // Implementation attributes.
        Import            =   0x00001000,     // Class / interface is imported
        Serializable      =   0x00002000,     // The class is Serializable.
 
        // Use tdStringFormatMask to retrieve string information for native interop
        StringFormatMask  =   0x00030000,     
        AnsiClass         =   0x00000000,     // LPTSTR is interpreted as ANSI in this class
        UnicodeClass      =   0x00010000,     // LPTSTR is interpreted as UNICODE
        AutoClass         =   0x00020000,     // LPTSTR is interpreted automatically
        CustomFormatClass =   0x00030000,     // A non-standard encoding specified by CustomFormatMask
        CustomFormatMask  =   0x00C00000,     // Use this mask to retrieve non-standard encoding information for native interop. The meaning of the values of these 2 bits is unspecified.
        // end string format mask
 
        BeforeFieldInit   =   0x00100000,     // Initialize the class any time before first static field access.
 
        // Flags reserved for runtime use.
        ReservedMask      =   0x00040800,
        RTSpecialName     =   0x00000800,     // Runtime should check name encoding.
        HasSecurity       =   0x00040000,     // Class has security associate with it.
    }
}