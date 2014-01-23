using System.Reflection;
using System.Runtime.WootzJs;

namespace System
{
    public class AppDomain
    {
        private static AppDomain instance = new AppDomain();

        public static AppDomain CurrentDomain
        {
            get { return instance; }
        }

        /// <summary>
        /// Gets the assemblies that have been loaded into the execution context of this application domain.
        /// </summary>
        /// 
        /// <returns>
        /// An array of assemblies in this application domain.
        /// </returns>
        /// <exception cref="T:System.AppDomainUnloadedException">The operation is attempted on an unloaded application domain. </exception><filterpriority>2</filterpriority>
        public Assembly[] GetAssemblies()
        {
            var array = Jsni.reference("$assemblies").As<JsArray>();
            var result = new Assembly[array.length];
            for (var i = 0; i < result.Length; i++)
            {
                var getAssembly = array[i].As<JsFunction>();
                result[i] = getAssembly.invoke().As<Assembly>();
            }

            return result;
        }
    }
}