using System.Runtime.WootzJs;

namespace System.CodeDom.Compiler
{
    [Js(Export = false)]
	[AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = false)]
	public sealed class GeneratedCodeAttribute : Attribute
	{
		private string _tool;
		private string _version;
		public string Tool
		{
			get
			{
				return this._tool;
			}
		}
		public string Version
		{
			get
			{
				return this._version;
			}
		}
		public GeneratedCodeAttribute(string tool, string version)
		{
			this._tool = tool;
			this._version = version;
		}
	}
}
