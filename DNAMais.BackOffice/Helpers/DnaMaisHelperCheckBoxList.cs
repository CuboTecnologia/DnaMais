using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace DNAMais.BackOffice.Helpers
{
    public static class DnaMaisHelperCheckBoxList
    {
        // ********************************************
        // CheckBoxList
        // ********************************************
        public static HtmlString DnaMaisCheckBoxList(this HtmlHelper htmlHelper, string display, string name, List<SelectListItem> itens, bool disabled)
        {
            var label = new TagBuilder("label");
            label.Attributes["class"] = "control-label";
            label.InnerHtml = "<label for=\"" + name + "\">" + (display ?? name) + "</label>";

            string options = string.Empty;
            itens.ForEach(i => options += "<label for=\"" + name + "_" + i.Value + "\" class=\"checkbox\"><input type=\"checkbox\" class=\"checkbox\" id=\"" + name + "_" + i.Value + "\" name=\"" + name + "\" value=\"" + i.Value + "\" " + (i.Selected ? "checked" : "") + " " + (disabled ? "disabled" : "") + " />" + i.Text + "</label>");

            var controle = new TagBuilder("div");
            controle.Attributes["class"] = "controls";
            controle.InnerHtml = options;

            var div = new TagBuilder("div");
            div.Attributes["class"] = "uniformjs";
            div.InnerHtml = label.ToString() + controle.ToString();

            var outerDiv = new TagBuilder("div");
            outerDiv.Attributes["class"] = "control-group";
            outerDiv.InnerHtml = div.ToString();

            return new HtmlString(outerDiv.ToString());
        }

        public static HtmlString DnaMaisCheckBoxListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, List<SelectListItem> itens, bool disabled)
        {
            var name = ExpressionHelper.GetExpressionText(expression);
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            var display = metadata.DisplayName;

            return DnaMaisCheckBoxList(htmlHelper, display, name, itens, disabled);
        }
    }
}