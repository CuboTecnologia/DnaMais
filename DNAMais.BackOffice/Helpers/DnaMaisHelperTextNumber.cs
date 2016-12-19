using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DNAMais.Framework;
using System.Web.Mvc;
using System.Linq.Expressions;

namespace DNAMais.BackOffice.Helpers
{
    public static class DnaMaisHelperTextNumber
    {
        public static HtmlString DnaMaisTextBoxNumber(this HtmlHelper htmlHelper, string display, string name, object value, int maxlength, int width, bool disabled)
        {
            //var superDiv = new TagBuilder("div");

            var label = new TagBuilder("label");
            label.Attributes["class"] = "col-md-2 control-label";
            label.Attributes["for"] = name;
            label.InnerHtml = (display ?? name);

            var controle = new TagBuilder("div");
            controle.Attributes["class"] = "controls";

            var input = new TagBuilder("input");
            input.Attributes["type"] = "text";
            input.Attributes["id"] = name;
            input.Attributes["name"] = name;
            input.Attributes["class"] = "form-control";
            input.Attributes["maxlength"] = maxlength.ToString();
            input.Attributes["value"] = (value == null ? "" : value.ToString());
            input.Attributes["style"] = "width:" + width.ToString() + "px;";
            if (disabled)
            {
                input.Attributes["disabled"] = "disabled";
            }
            input.Attributes["onkeypress"] = "return onlyNumbers(event)";

            controle.InnerHtml = input.ToString();

            var div = new TagBuilder("div");
            div.Attributes["class"] = "form-group";
            div.InnerHtml = label.ToString() + controle.ToString();

            //superDiv.InnerHtml = div.ToString();

            return new HtmlString(div.ToString());
        }

        public static HtmlString DnaMaisTextBoxNumberFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, int width, bool disabled, int maxlength = 10)
        {
            var name = ExpressionHelper.GetExpressionText(expression);
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            var display = metadata.DisplayName;

            return DnaMaisTextBoxNumber(htmlHelper, display, name, metadata.Model, maxlength, width, disabled);
        }
    }
}