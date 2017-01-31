using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace DNAMais.BackOffice.Helpers
{
    public static class DnaMaisHelperTextBox
    {
        // ********************************************
        // TextBox
        // ********************************************

        public static HtmlString DnaMaisTextBox(this HtmlHelper htmlHelper, string display, string name, object value, int maxlength, int width, bool disabled)
        {
            return DnaMaisTextBox(htmlHelper, display, name, value, maxlength, width, disabled, false);
        }

        public static HtmlString DnaMaisTextBox(this HtmlHelper htmlHelper, string display, string name, object value, int maxlength, int width, bool disabled, bool textReadonly)
        {
            //var superDiv = new TagBuilder("div");

            var label = new TagBuilder("label");
            label.Attributes["class"] = "col-md-2 control-label";
            label.Attributes["for"] = name;
            label.InnerHtml = (display ?? name);

            var controle = new TagBuilder("div");
            controle.Attributes["class"] = "";

            var input = new TagBuilder("input");
            input.Attributes["type"] = "text";
            input.Attributes["id"] = name;
            input.Attributes["name"] = name;
            input.Attributes["class"] = "form-control";
            input.Attributes["maxlength"] = maxlength.ToString();
            input.Attributes["value"] = value == null ? string.Empty : value.ToString();
            input.Attributes["style"] = "width:" + width.ToString() + "px;";
            input.Attributes["autocomplete"] = "off";

            if (disabled)
            {
                input.Attributes["disabled"] = "disabled";
            }
            if (textReadonly)
            {
                input.Attributes["readonly"] = "readonly";
            }

            controle.InnerHtml = input.ToString();

            var div = new TagBuilder("div");
            div.Attributes["class"] = "form-group";
            div.InnerHtml = label.ToString() + controle.ToString();

            //superDiv.InnerHtml = div.ToString();

            return new HtmlString(div.ToString());
        }

        public static HtmlString DnaMaisTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, int width, bool disabled)
        {
            return DnaMaisTextBoxFor(htmlHelper, expression, width, disabled, false);
        }

        public static HtmlString DnaMaisTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, int width, bool disabled, bool textReadonly)
        {
            var name = ExpressionHelper.GetExpressionText(expression);
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            var display = metadata.DisplayName;

            var prop = metadata.ContainerType.GetProperty(metadata.PropertyName);
            var attribute = prop.GetCustomAttributes(typeof(StringLengthAttribute), false).OfType<StringLengthAttribute>().FirstOrDefault();
            int maxlength = attribute != null ? attribute.MaximumLength : 1;

            return DnaMaisTextBox(htmlHelper, display, name, metadata.Model as string, maxlength, width, disabled, textReadonly);
        }
    }
}