using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace DNAMais.BackOffice.Helpers
{
    public static class DnaMaisHelperTextArea
    {
        // ********************************************
        // TextArea
        // ********************************************
        public static HtmlString DnaMaisTextArea(this HtmlHelper htmlHelper, string display, string name, string value, int maxlength, int width, int rows, bool disabled)
        {
            //var superDiv = new TagBuilder("div");
            //superDiv.Attributes["style"] = "margin-bottom: 5px;";

            var label = new TagBuilder("label");
            label.Attributes["class"] = "col-md-2 control-label";
            label.InnerHtml = "<label for=\"" + name + "\">" + (display ?? name) + "</label>";

            var controle = new TagBuilder("div");
            controle.Attributes["class"] = "controls";

            var input = new TagBuilder("textarea");
            input.Attributes["type"] = "text";
            input.Attributes["id"] = name;
            input.Attributes["name"] = name;
            input.Attributes["class"] = "form-control";
            input.Attributes["maxlength"] = maxlength.ToString();
            input.Attributes["style"] = "width:" + width.ToString() + "px;";
            input.Attributes["rows"] = rows.ToString();
            if (disabled)
            {
                input.Attributes["disabled"] = "disabled";
            }
            input.Attributes["onkeypress"] = "if (this.value.length > " + maxlength.ToString() + ") { return false; }";
            input.InnerHtml = value ?? string.Empty;

            controle.InnerHtml = input.ToString();

            var div = new TagBuilder("div");
            div.Attributes["class"] = "control-group";
            div.InnerHtml = label.ToString() + controle.ToString();

            //superDiv.InnerHtml = div.ToString();

            return new HtmlString(div.ToString());
        }

        public static HtmlString DnaMaisTextAreaFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, int width, int rows, bool disabled)
        {
            var name = ExpressionHelper.GetExpressionText(expression);
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            var display = metadata.DisplayName;

            var prop = metadata.ContainerType.GetProperty(metadata.PropertyName);
            var attribute = prop.GetCustomAttributes(typeof(StringLengthAttribute), false).OfType<StringLengthAttribute>().FirstOrDefault();
            int maxlength = attribute != null ? attribute.MaximumLength - 1 : 99999;

            return DnaMaisTextArea(htmlHelper, display, name, metadata.Model as string, maxlength, width, rows, disabled);
        }

    }
}