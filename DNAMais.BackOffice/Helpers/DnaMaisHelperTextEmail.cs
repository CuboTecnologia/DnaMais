using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DNAMais.Framework;
using System.Web.Mvc;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace DNAMais.BackOffice.Helpers
{
    public static class DnaMaisHelperTextEmail
    {
        // ********************************************
        // TextBox - Email
        // ********************************************
        public static HtmlString DnaMaisTextBoxEmail(this HtmlHelper htmlHelper, string display, string name, string value, int maxlength, int width, bool disabled)
        {
            var superDiv = new TagBuilder("div");

            var label = new TagBuilder("label");
            label.Attributes["class"] = "control-label";
            label.InnerHtml = "<label for=\"" + name + "\">" + (display ?? name) + "</label>";

            var controle = new TagBuilder("div");
            controle.Attributes["class"] = "controls";
            controle.InnerHtml = "<div class=\"input-prepend\"><span class=\"add-on fa envelope\"><i></i></span><input type=\"text\" id=\"" + name + "\" name=\"" + name + "\" maxlength=\"" + maxlength.ToString() + "\" value=\"" + value + "\" style=\"width:" + width.ToString() + "px;\" " + (disabled ? "disabled" : "") + " onkeypress=\"return onlyNumbers(event);\" onkeyup=\"maskCPF(this);\" ></div>";

            var preprend = new TagBuilder("div");
            preprend.Attributes["class"] = "input-prepend";

            var span = new TagBuilder("div");
            span.Attributes["class"] = "add-on fa envelope";
            span.InnerHtml = "<i></i>";

            var input = new TagBuilder("input");
            input.Attributes["type"] = "text";
            input.Attributes["id"] = name;
            input.Attributes["name"] = name;
            input.Attributes["maxlength"] = maxlength.ToString();
            input.Attributes["value"] = value;
            input.Attributes["style"] = "width:" + width.ToString() + "px;";
            if (disabled)
            {
                input.Attributes["disabled"] = "disabled";
            }
            input.Attributes["onkeypress"] = "return onlyNumbers(event)";

            preprend.InnerHtml = span.ToString() + input.ToString();
            controle.InnerHtml = preprend.ToString();

            var div = new TagBuilder("div");
            div.Attributes["class"] = "control-group";
            div.InnerHtml = label.ToString() + controle.ToString();

            superDiv.InnerHtml = div.ToString();

            return new HtmlString(superDiv.ToString());
        }

        public static HtmlString DnaMaisTextBoxEmailFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, int width, bool disabled)
        {
            var name = ExpressionHelper.GetExpressionText(expression);
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            var display = metadata.DisplayName;

            var prop = metadata.ContainerType.GetProperty(metadata.PropertyName);
            var attribute = prop.GetCustomAttributes(typeof(StringLengthAttribute), false).OfType<StringLengthAttribute>().FirstOrDefault();
            int maxlength = attribute != null ? attribute.MaximumLength : 1;

            return DnaMaisTextBoxEmail(htmlHelper, display, name, metadata.Model as string, maxlength, width, disabled);
        }

    }
}