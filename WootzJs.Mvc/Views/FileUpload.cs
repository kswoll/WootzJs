using System;
using System.Runtime.WootzJs;
using WootzJs.Web;

namespace WootzJs.Mvc.Views
{
    public class FileUpload : Control
    {
        public event Action Changed;

        public new InputElement Node
        {
            get { return base.Node.As<InputElement>(); }
        }

        public void ChooseFile()
        {
            Node.Click();
        }

        public FileList Files
        {
            get { return Node.Files; }
        }

        public string Name
        {
            get { return Node.GetAttribute("name"); }
            set { Node.SetAttribute("name", value); }
        }

        public string Placeholder
        {
            get { return Node.GetAttribute("placeholder"); }
            set { Node.SetAttribute("placeholder", value); }
        }

        protected override Element CreateNode()
        {
            var textBox = Browser.Document.CreateElement("input");
            textBox.SetAttribute("type", "file");
            textBox.AddEventListener("change", OnJsChanged);

            return textBox;
        }

        private void OnJsChanged(Event evt)
        {
            var changed = Changed;
            if (changed != null)
                changed();
        }

        public string Text
        {
            get
            {
                EnsureNodeExists();
                return Node.Value;
            }
        }
    }
}