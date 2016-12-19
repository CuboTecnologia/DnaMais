using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace DNAMais.BackOffice.Helpers
{
    public static class DnaMaisHelperFileUpload
    {
        // ********************************************
        // File
        // ********************************************
        public static HtmlString DnaMaisFileUpload(this HtmlHelper htmlHelper, string display, string name)
        {
            var label = new TagBuilder("label");
            label.Attributes["class"] = "control-label";
            label.InnerHtml = "<label for=\"" + name + "\">" + (display ?? name) + "</label>";

            var controle = new TagBuilder("div");
            controle.Attributes["class"] = "controls";
            controle.InnerHtml = "<div class=\"fileupload fileupload-new\" data-provides=\"fileupload\">";
            controle.InnerHtml += "<div class=\"input-append\">";
            controle.InnerHtml += "<div class=\"uneditable-input span3\"><i class=\"icon-file fileupload-exists\"></i> <span class=\"fileupload-preview\"></span></div><span class=\"btn btn-file\"><span class=\"fileupload-new\">Selecionar</span><span class=\"fileupload-exists\">Alterar</span><input type=\"file\" name=\"" + name + "\"/></span><a href=\"#\" class=\"btn fileupload-exists\" data-dismiss=\"fileupload\">Remover</a>";
            controle.InnerHtml += "</div>";
            controle.InnerHtml += "</div>";

            var div = new TagBuilder("div");
            div.Attributes["class"] = "control-group";
            div.InnerHtml = label.ToString() + controle.ToString();

            return new HtmlString(div.ToString());
        }

        public static HtmlString DnaMaisFileUploadFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {
            var name = ExpressionHelper.GetExpressionText(expression);
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            var display = metadata.DisplayName;

            return DnaMaisFileUpload(htmlHelper, display, name);
        }
    }
}