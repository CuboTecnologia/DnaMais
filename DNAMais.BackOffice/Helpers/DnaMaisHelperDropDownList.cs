using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace DNAMais.BackOffice.Helpers
{
    public static class DnaMaisHelperDropDownList
    {
        // ********************************************
        // DropDownList
        // ********************************************
        public static HtmlString DnaMaisDropDownList(this HtmlHelper htmlHelper, string display, string name, string value, List<SelectListItem> itens, int width, bool disabled)
        {
            //var superDiv = new TagBuilder("div");

            var label = new TagBuilder("label");
            label.Attributes["class"] = "col-md-2 control-label";
            label.InnerHtml = "<label for=\"" + name + "\">" + (display ?? name) + "</label>";

            var select = new TagBuilder("select");
            select.Attributes["data-val"] = "true";
            select.Attributes["id"] = name;
            select.Attributes["name"] = name;
            select.Attributes["class"] = "form-control";
            select.Attributes["style"] = "width:" + width.ToString() + "px;";

            if (disabled)
            {
                select.Attributes["disabled"] = "disabled";
            }

            itens.ForEach(i => select.InnerHtml += "<option value=\"" + i.Value + "\" " + (i.Selected ? "selected=\"selected\"" : (i.Value == (value ?? string.Empty) ? "selected=\"selected\"" : "")) + ">" + i.Text + "</option>");

            var controle = new TagBuilder("div");
            controle.Attributes["class"] = "";
            controle.InnerHtml = select.ToString();

            var div = new TagBuilder("div");
            div.Attributes["class"] = "form-group";
            div.InnerHtml = label.ToString() + controle.ToString();

            //superDiv.InnerHtml = div.ToString();

            return new HtmlString(div.ToString());
        }

        public static HtmlString DnaMaisDropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, List<SelectListItem> itens, int width, bool disabled)
        {
            var name = ExpressionHelper.GetExpressionText(expression);
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            var display = metadata.DisplayName;
            var value = metadata.Model != null ? metadata.Model.ToString() : null;
            return DnaMaisDropDownList(htmlHelper, display, name, value, itens, width, disabled);
        }
    }
}