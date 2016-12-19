using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace DNAMais.BackOffice.Helpers
{
    public static class DnaMaisHelperTextBoxCombinated
    {
        // ********************************************
        // TextBox Combinated
        // ********************************************
        public static HtmlString DnaMaisTextBoxCombinated(this HtmlHelper htmlHelper, string display, string name1, string value1, int maxlength1, int width1, string name2, string value2, int maxlength2, int width2, bool disabled)
        {
            var superDiv = new TagBuilder("div");

            var label = new TagBuilder("label");
            label.Attributes["class"] = "control-label";
            label.InnerHtml = "<label for=\"" + name1 + "\">" + (display ?? name1) + "</label>";

            var controle = new TagBuilder("div");
            controle.Attributes["class"] = "controls";
            controle.InnerHtml = "<input type=\"text\" id=\"" + name1 + "\" name=\"" + name1 + "\" maxlength=\"" + maxlength1.ToString() + "\" value=\"" + value1 + "\" style=\"width:" + width1.ToString() + "px;\" " + (disabled ? "disabled" : "") + " >";
            controle.InnerHtml += " - <input type=\"text\" id=\"" + name2 + "\" name=\"" + name2 + "\" maxlength=\"" + maxlength2.ToString() + "\" value=\"" + value2 + "\" style=\"width:" + width2.ToString() + "px;\" " + (disabled ? "disabled" : "") + " >";

            var div = new TagBuilder("div");
            div.Attributes["class"] = "control-group";
            div.InnerHtml = label.ToString() + controle.ToString();

            superDiv.InnerHtml = div.ToString();

            return new HtmlString(superDiv.ToString());
        }

        public static HtmlString DnaMaisTextBoxCombinatedFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression1, int width1, Expression<Func<TModel, TProperty>> expression2, int width2, bool disabled)
        {
            var name1 = ExpressionHelper.GetExpressionText(expression1);
            var metadata1 = ModelMetadata.FromLambdaExpression(expression1, htmlHelper.ViewData);
            var display = metadata1.DisplayName;

            var prop1 = metadata1.ContainerType.GetProperty(metadata1.PropertyName);
            var attribute1 = prop1.GetCustomAttributes(typeof(StringLengthAttribute), false).OfType<StringLengthAttribute>().FirstOrDefault();
            int maxlength1 = attribute1 != null ? attribute1.MaximumLength : 1;

            var name2 = ExpressionHelper.GetExpressionText(expression2);
            var metadata2 = ModelMetadata.FromLambdaExpression(expression2, htmlHelper.ViewData);

            var prop2 = metadata2.ContainerType.GetProperty(metadata2.PropertyName);
            var attribute2 = prop2.GetCustomAttributes(typeof(StringLengthAttribute), false).OfType<StringLengthAttribute>().FirstOrDefault();
            int maxlength2 = attribute2 != null ? attribute2.MaximumLength : 1;

            return DnaMaisTextBoxCombinated(htmlHelper, display, name1, metadata1.Model as string, maxlength1, width1, name2, metadata2.Model as string, maxlength2, width2, disabled);
        }

    }
}