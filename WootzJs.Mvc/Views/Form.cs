using System;
using WootzJs.Web;

namespace WootzJs.Mvc.Views
{
    public class Form : Control
    {
        public event Action Submitting;

        private Control content;
        private FormElement form;

        public Form() 
        {
        }

        public Form(Control content, Link submitLink = null) 
        {
            Content = content;
            SubmitLink = submitLink;
        }

        public Link SubmitLink { get; set; }

        public Control Content
        {
            get { return content; }
            set
            {
                EnsureNodeExists();
                if (content != null)
                {
                    RemoveChild(content);
                    form.RemoveChild(content.Node);
                }
                content = value;
                if (content != null)
                {
                    AddChild(content);
                    form.AppendChild(content.Node);
                }
            }
        }

        public void Submit()
        {
            EnsureNodeExists();
            form.Submit();
        }

        protected virtual void OnSubmitting(Event evt)
        {
            var submitting = Submitting;
            if (submitting != null || SubmitLink != null)
            {
                evt.PreventDefault();
                if (submitting != null)
                    submitting();
                if (SubmitLink != null)
                    SubmitLink.FireClick();
            }
        }

        protected override Element CreateNode()
        {
            form = Browser.Document.CreateElement<FormElement>("form");
            form.AddEventListener("submit", OnSubmitting);

            // This is necessary for enter-on-submit to work since it requires
            // the presence of a submit button in the form.
            var hiddenSubmit = Browser.Document.CreateElement("input");
            hiddenSubmit.Style.Position = "absolute";
            hiddenSubmit.Style.Height = "0px";
            hiddenSubmit.Style.Width = "0px";
            hiddenSubmit.Style.Border = "none";
            hiddenSubmit.Style.Padding = "0px";
            hiddenSubmit.SetAttribute("type", "submit");
            hiddenSubmit.SetAttribute("hidefocus", "true");
            hiddenSubmit.SetAttribute("tabindex", "-1");
            form.AppendChild(hiddenSubmit);

            return form;
        }
    }
}