using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DNAMais.Framework;
using System.Web.Mvc;
using System.Linq.Expressions;

namespace DNAMais.BackOffice.Helpers
{
    public static class DnaMaisHelperTextCNPJ
    {
        // ********************************************
        // TextBox - CNPJ
        // ********************************************
        public static HtmlString DnaMaisTextBoxCNPJ(this HtmlHelper htmlHelper, string display, string name, string value, int width, bool disabled)
        {
            //var superDiv = new TagBuilder("div");

            var label = new TagBuilder("label");
            label.Attributes["class"] = "col-md-2 control-label";
            label.InnerHtml = "<label for=\"" + name + "\">" + (display ?? name) + "</label>";

            var controle = new TagBuilder("div");
            controle.Attributes["class"] = "";

            var input = new TagBuilder("input");
            input.Attributes["type"] = "text";
            input.Attributes["id"] = name;
            input.Attributes["name"] = name;
            input.Attributes["class"] = "form-control";
            input.Attributes["maxlength"] = "18";
            input.Attributes["value"] = value == null ? string.Empty : value.FormatarCNPJ();
            input.Attributes["style"] = "width:" + width.ToString() + "px;";
            if (disabled)
            {
                input.Attributes["disabled"] = "disabled";
            }
            input.Attributes["onkeypress"] = "return onlyNumbers(event)";
            input.Attributes["onkeyup"] = "maskCNPJ(this, event)";

            controle.InnerHtml = input.ToString();

            var div = new TagBuilder("div");
            div.Attributes["class"] = "form-group";
            div.InnerHtml = label.ToString() + controle.ToString();

            //superDiv.InnerHtml = div.ToString();

            return new HtmlString(div.ToString());
        }

        public static HtmlString DnaMaisTextBoxCNPJFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, int width, bool disabled)
        {
            var name = ExpressionHelper.GetExpressionText(expression);
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            var display = metadata.DisplayName;

            return DnaMaisTextBoxCNPJ(htmlHelper, display, name, metadata.Model as string, width, disabled);
        }

    }
}