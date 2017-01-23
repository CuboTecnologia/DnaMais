using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using DNAMais.Framework;

namespace DNAMais.BackOffice.Helpers
{
    public static class DnaMaisHelperTextDatePicker
    {
        // ********************************************
        // DatePicker
        // ********************************************
        public static HtmlString DnaMaisDatePicker(this HtmlHelper htmlHelper, string display, string name, Object value, bool disabled)
        {
            //var superDiv = new TagBuilder("div");

            var label = new TagBuilder("label");
            label.Attributes["class"] = "col-md-2 control-label";
            label.Attributes["for"] = name;
            label.InnerHtml = (display ?? name);

            var controle = new TagBuilder("div");
            controle.Attributes["class"] = "controls";

            var divInput = new TagBuilder("div");
            divInput.Attributes["class"] = "input-append";

            var input = new TagBuilder("input");
            input.Attributes["type"] = "text";
            input.Attributes["id"] = name;
            input.Attributes["name"] = name;
            input.Attributes["class"] = "form-control jsDatePicker";
            input.Attributes["maxlength"] = "10";
            input.Attributes["style"] = "width:100px;";
            input.Attributes["onkeyup"] = "maskDate(this)";
            input.Attributes["data-plugin-datepicker"] = null;
            input.Attributes["value"] = (value == null ? "" : value.ToString().ToDateTime().FormatarData());

            if (disabled)
            {
                input.Attributes["disabled"] = "disabled";
            }

            //var span = new TagBuilder("span");
            //span.Attributes["class"] = "icon icon-lg";
            //span.InnerHtml = "<i class='fa fa-calendar'></i>";

            divInput.InnerHtml = input.ToString();

            controle.InnerHtml = divInput.ToString();

            var div = new TagBuilder("div");
            div.Attributes["class"] = "form-group";
            div.InnerHtml = label.ToString() + controle.ToString();

            //superDiv.InnerHtml = System.Web.HttpUtility.HtmlDecode(div.ToString());

            return new HtmlString(div.ToString());
        }

        public static HtmlString DnaMaisDatePickerFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, bool disabled)
        {
            var name = ExpressionHelper.GetExpressionText(expression);
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            var display = metadata.DisplayName;
            return DnaMaisDatePicker(htmlHelper, display, name, metadata.Model, disabled);
        }
    }
}