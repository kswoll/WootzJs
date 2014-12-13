using System;
using System.Linq.Expressions;
using WootzJs.Models;

namespace WootzJs.Mvc.Views.Binders
{
    public static class TextBinders
    {
        public static void BindText<TModel, TValue>(this Bindings<TModel> bindings, Text text, Expression<Func<TModel, TValue>> property) where TModel : Model<TModel>
        {
            var model = bindings.Model;
            var prop = model.GetProperty(property);

            Action updateText = () => text.Value = (string)Convert.ChangeType(prop.Value, typeof(string));
            updateText();

            prop.Changed += updateText;
            prop.Validated += validations => 
            {
                var application = text.ViewContext.ControllerContext.Application;
                application.NotifyOnValidatedControl(text, validations);
            };
        }         
    }
}