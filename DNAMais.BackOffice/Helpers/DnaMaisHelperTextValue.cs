using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using DNAMais.Framework;

namespace DNAMais.BackOffice.Helpers
{
    public static class DnaMaisHelperTextValue
    {
        // ********************************************
        // TextBox
        // ********************************************
        public static HtmlString DnaMaisTextBoxValue(this HtmlHelper htmlHelper, string display, string name, object value, int maxlength, int width, bool disabled)
        {
            var superDiv = new TagBuilder("div");

            var label = new TagBuilder("label");
            label.Attributes["class"] = "control-label";
            label.InnerHtml = "<label for=\"" + name + "\">" + (display ?? name) + "</label>";

            var controle = new TagBuilder("div");
            controle.Attributes["class"] = "controls";

            var input = new TagBuilder("input");
            input.Attributes["type"] = "text";
            input.Attributes["id"] = name;
            input.Attributes["name"] = name;
            input.Attributes["maxlength"] = maxlength.ToString();
            input.Attributes["value"] = (value == null ? "0".ToDecimal().FormatarValor() : value.ToString().ToDecimal().FormatarValor());
            input.Attributes["style"] = "width:" + width.ToString() + "px;";
            if (disabled)
            {
                input.Attributes["disabled"] = "disabled";
            }
            input.Attributes["onkeypress"] = "return onlyNumbers(event)";
            input.Attributes["onkeyup"] = "maskValue(this)";

            controle.InnerHtml = input.ToString();

            var div = new TagBuilder("div");
            div.Attributes["class"] = "control-group";
            div.InnerHtml = label.ToString() + controle.ToString();

            superDiv.InnerHtml = div.ToString();

            return new HtmlString(superDiv.ToString());
        }

        public static HtmlString DnaMaisTextBoxValueFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, int width, bool disabled)
        {
            var name = ExpressionHelper.GetExpressionText(expression);
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            var display = metadata.DisplayName;

            var prop = metadata.ContainerType.GetProperty(metadata.PropertyName);
            var attribute = prop.GetCustomAttributes(typeof(StringLengthAttribute), false).OfType<StringLengthAttribute>().FirstOrDefault();
            int maxlength = 10; //attribute != null ? attribute.MaximumLength : 1;

            return DnaMaisTextBoxValue(htmlHelper, display, name, metadata.Model, maxlength, width, disabled);
        }

    }
}