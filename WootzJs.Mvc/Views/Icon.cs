using System;
using System.Linq;
using System.Text;
using WootzJs.Mvc.Extensions;
using WootzJs.Web;

namespace WootzJs.Mvc.Views
{
    public class Icon : Control
    {
        public bool IsSpinning
        {
            get { return Node.ClassName.Split(' ').Contains("fa-spin"); }
            set
            {
                var classes = Node.ClassName.Split(' ').ToList();
                if (value)
                {
                    if (!classes.Contains("fa-spin"))
                        Node.ClassName += " " + "fa-spin";                    
                }
                else
                {
                    if (classes.Contains("fa-spin"))
                    {
                        classes.Remove("fa-spin");
                        Node.ClassName = string.Join(" ", classes);
                    }
                }
            }
        }

        public IconType Source
        {
            get
            {
                var cssClass = Node.ClassName;
                if (cssClass == null)
                    return IconType.None;
                var parts = cssClass.Split(' ').ToList();
                parts.Remove("fa");
                if (parts.Count > 1)
                    return IconType.None;
                var part = parts.Single();

                var slug = part.SlugToCamelcase();
                return (IconType)Enum.Parse(typeof(IconType), slug);
            }
            set
            {
                var slug = value.ToString().Decapitalize().CamelcaseToSlug();
                Node.ClassName = "fa fa-" + slug;
            }
        }

        protected override Element CreateNode()
        {
            var node = Browser.Document.CreateElement("i");


            return node;
        }
    }
}