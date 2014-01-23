using System.Reflection;

namespace System.Runtime.WootzJs
{
    [Js(Export = false)]
    public static class Jsni
    {
        public static JsObject @new(JsObject target)
        {
            return null;
        }

        public static JsObject arguments()
        {
            return null;
        }

        public static JsObject @this()
        {
            return null;
        }

        public static JsObject apply(JsObject target, JsObject thisReference, JsArray arguments)
        {
            return null;
        }

        public static JsObject call(JsObject target, JsObject thisReference, params JsObject[] arguments)
        {
            return null;
        }

        public static JsObject apply<T>(Action<T> method, JsObject thisReference, JsArray arguments)
        {
            return null;
        }

        public static JsObject call<T>(Action<T> method, JsObject thisReference, params JsObject[] arguments)
        {
            return null;
        }

        public static void delete(JsObject o)
        {
        }

        public static JsFunction procedure(Action a)
        {
            return null;
        }

        public static JsFunction procedure(Action<JsObject> a, string nameOverride1 = null)
        {
            return null;
        }

        public static JsFunction procedure(Action<JsObject, JsObject> a, string nameOverride1 = null, string nameOverride2 = null)
        {
            return null;
        }

        public static JsFunction procedure(Action<JsObject, JsObject, JsObject> a,
            string nameOverride1 = null, string nameOverride2 = null, string nameOverride3 = null)
        {
            return null;
        }

        public static JsFunction procedure(Action<JsObject, JsObject, JsObject, JsObject> a,
            string nameOverride1 = null, string nameOverride2 = null, string nameOverride3 = null, string nameOverride4 = null)
        {
            return null;
        }

        public static JsFunction procedure(Action<JsObject, JsObject, JsObject, JsObject, JsObject> a,
            string nameOverride1 = null, string nameOverride2 = null, string nameOverride3 = null, string nameOverride4 = null, string nameOverride5 = null)
        {
            return null;
        }

        public static JsFunction procedure(Action<JsObject, JsObject, JsObject, JsObject, JsObject, JsObject> a,
            string nameOverride1 = null, string nameOverride2 = null, string nameOverride3 = null, string nameOverride4 = null, string nameOverride5 = null, 
            string nameOverride6 = null)
        {
            return null;
        }

        public static JsFunction procedure(Action<JsObject, JsObject, JsObject, JsObject, JsObject, JsObject, JsObject> a, 
            string nameOverride1 = null, string nameOverride2 = null, string nameOverride3 = null, string nameOverride4 = null, string nameOverride5 = null, 
            string nameOverride6 = null, string nameOverride7 = null)
        {
            return null;
        }

        public static JsFunction procedure(Action<JsObject, JsObject, JsObject, JsObject, JsObject, JsObject, JsObject, JsObject> a,
            string nameOverride1 = null, string nameOverride2 = null, string nameOverride3 = null, string nameOverride4 = null, string nameOverride5 = null, 
            string nameOverride6 = null, string nameOverride7 = null, string nameOverride8 = null)
        {
            return null;
        }

        public static JsFunction function(Func<JsObject> a)
        {
            return null;
        }

        public static JsFunction function(Func<JsObject, JsObject> a,
            string nameOverride1 = null)
        {
            return null;
        }

        public static JsFunction function(Func<JsObject, JsObject, JsObject> a,
            string nameOverride1 = null, string nameOverride2 = null)
        {
            return null;
        }

        public static JsFunction function(Func<JsObject, JsObject, JsObject, JsObject> a,
            string nameOverride1 = null, string nameOverride2 = null, string nameOverride3 = null)
        {
            return null;
        }

        public static JsFunction function(Func<JsObject, JsObject, JsObject, JsObject, JsObject> a,
            string nameOverride1 = null, string nameOverride2 = null, string nameOverride3 = null, string nameOverride4 = null)
        {
            return null;
        }

        public static JsFunction function(Func<JsObject, JsObject, JsObject, JsObject, JsObject, JsObject> a,
            string nameOverride1 = null, string nameOverride2 = null, string nameOverride3 = null, string nameOverride4 = null, string nameOverride5 = null)
        {
            return null;
        }

        public static JsFunction function(Func<JsObject, JsObject, JsObject, JsObject, JsObject, JsObject, JsObject> a,
            string nameOverride1 = null, string nameOverride2 = null, string nameOverride3 = null, string nameOverride4 = null, string nameOverride5 = null, 
            string nameOverride6 = null)
        {
            return null;
        }

        public static JsFunction function(Func<JsObject, JsObject, JsObject, JsObject, JsObject, JsObject, JsObject, JsObject> a,
            string nameOverride1 = null, string nameOverride2 = null, string nameOverride3 = null, string nameOverride4 = null, string nameOverride5 = null, 
            string nameOverride6 = null, string nameOverride7 = null)
        {
            return null;
        }

        public static JsFunction function(Func<JsObject, JsObject, JsObject, JsObject, JsObject, JsObject, JsObject, JsObject, JsObject> a,
            string nameOverride1 = null, string nameOverride2 = null, string nameOverride3 = null, string nameOverride4 = null, string nameOverride5 = null, 
            string nameOverride6 = null, string nameOverride7 = null, string nameOverride8 = null)
        {
            return null;
        }

        public static JsString _typeof(JsObject o)
        {
            return null;
        }

        public static JsObject member(JsObject target, string name)
        {
            return null;
        }

        public static JsObject memberset(JsObject target, string name, JsObject value)
        {
            return null;
        }

        public static JsArray array(params JsObject[] elements)
        {
            return null;
        }

        public static JsObject invoke(JsObject target, params JsObject[] arguments)
        {
            return null;
        }

        public static JsTypeFunction type<T>()
        {
            return null;
        }

        public static JsTypeFunction type(Type type)
        {
            return null;
        }

        public static JsObject reference(string identifier)
        {
            return null;
        }

        public static JsNumber parseInt(string s, int radix = 0)
        {
            return null;
        }

        public static bool isNaN(JsNumber number)
        {
            return false;
        }

        public static bool instanceof(JsObject expression, JsObject type)
        {
            return false;
        }
    }
}
