using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace DNAMais.BackOffice.Helpers
{
    public static class DnaMaisHelperFileDownload
    {
        // ********************************************
        // File
        // ********************************************
        public static HtmlString DnaMaisFileDownload(this HtmlHelper htmlHelper, string display, string name, string Area, string Controller, string Action, string Id, string fileName, byte[] fileBytes)
        {
            var label = new TagBuilder("label");
            label.Attributes["class"] = "control-label";
            label.InnerHtml = "<label for=\"" + name + "\">" + (display ?? name) + "</label>";

            var controle = new TagBuilder("div");
            controle.Attributes["class"] = "controls";
            controle.InnerHtml = "<a href=\"/" + Area + "/" + Controller + "/" + Action + "/" + Id + "\">" + fileName + "</a>";

            var div = new TagBuilder("div");
            div.Attributes["class"] = "control-group";
            div.InnerHtml = label.ToString() + controle.ToString();

            return new HtmlString(div.ToString());
        }

        public static HtmlString DnaMaisFileDownloadFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string Area, string Controller, string Action, string Id, string fileName)
        {
            var name = ExpressionHelper.GetExpressionText(expression);
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            var display = metadata.DisplayName;

            if (metadata != null)
            {
                return DnaMaisFileDownload(htmlHelper, display, name, Area, Controller, Action, Id, fileName, metadata.Model as byte[]);
            }
            else
            {
                return new HtmlString(string.Empty);
            }
        }
    }
}