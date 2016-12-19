using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace DNAMais.BackOffice.Helpers
{
    public static class DnaMaisHelperRadioButtonList
    {
        // ********************************************
        // RaddionButtonList
        // ********************************************
        public static HtmlString DnaMaisRadioButtonList(this HtmlHelper htmlHelper, string display, string name, string value, List<SelectListItem> itens, bool disabled)
        {
            var superDiv = new TagBuilder("div");

            var label = new TagBuilder("label");
            label.Attributes["class"] = "control-label";
            label.InnerHtml = "<label for=\"" + name + "\">" + (display ?? name) + "</label>";

            string options = string.Empty;
            itens.ForEach(i => options += "<label for=\"" + name + "_" + i.Value + "\" class=\"radio\"><input type=\"radio\" class=\"radio\" id=\"" + name + "_" + i.Value + "\" name=\"" + name + "\" value=\"" + i.Value + "\" " + (i.Selected ? "checked" : (i.Value == (value != null ? value.ToString() : "") ? "checked" : "")) + " " + (disabled ? "disabled" : "") + " />" + i.Text + "</label><br/>");

            var controle = new TagBuilder("div");
            controle.Attributes["class"] = "controls";
            controle.InnerHtml = options;

            var div = new TagBuilder("div");
            div.Attributes["class"] = "uniformjs";
            div.InnerHtml = label.ToString() + controle.ToString();

            var outerDiv = new TagBuilder("div");
            outerDiv.Attributes["class"] = "control-group";
            outerDiv.InnerHtml = div.ToString();

            superDiv.InnerHtml = outerDiv.ToString();

            return new HtmlString(superDiv.ToString());
        }

        public static HtmlString DnaMaisRadioButtonListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, List<SelectListItem> itens, bool disabled)
        {
            var name = ExpressionHelper.GetExpressionText(expression);
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            var display = metadata.DisplayName;
            var value = metadata.Model != null ? metadata.Model.ToString() : null;
            return DnaMaisRadioButtonList(htmlHelper, display, name, value, itens, disabled);
        }
    }
}