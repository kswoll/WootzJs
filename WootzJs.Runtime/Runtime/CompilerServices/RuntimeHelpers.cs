using System.Runtime.WootzJs;

namespace System.Runtime.CompilerServices
{
    [Js(Export = false)]
    public static class RuntimeHelpers
    {
        /// <summary>
        /// Gets the offset, in bytes, to the data in the given string.
        /// </summary>
        /// 
        /// <returns>
        /// The byte offset, from the start of the <see cref="T:System.String"/> object to the first character in the string.
        /// </returns>
        public static int OffsetToStringData
        {
            get { return 8; }
        }
         
        public static void InitializeArray(Array array, RuntimeFieldHandle fldHandle)
        {
        }
    }
}
