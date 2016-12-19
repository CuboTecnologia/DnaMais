using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DNAMais.BackOffice.Helpers
{
    public static class DnaMaisHelperButton
    {
        // ********************************************
        // Button
        // ********************************************
        public static HtmlString DnaMaisButton(this HtmlHelper htmlHelper, string area, string controller, string action, string name, string display, string type, string icon)
        {
            string href = new UrlHelper(htmlHelper.ViewContext.HttpContext.Request.RequestContext).Action(action, controller, new { area = area });

            var button = new TagBuilder("button");
            button.Attributes["id"] = name;
            button.Attributes["name"] = name;
            button.Attributes["type"] = "button";
            button.Attributes["class"] = "btn btn-icon btn-" + type + " fa " + icon;
            button.MergeAttribute("onclick", "location.href='" + href + "';");
            button.InnerHtml = "<i></i>" + display;

            return new HtmlString(System.Web.HttpUtility.HtmlDecode(button.ToString() + "&nbsp;"));
        }

        public static HtmlString DnaMaisButton(this HtmlHelper htmlHelper, string action, string name, string display, string type, string icon)
        {
            string area = htmlHelper.ViewContext.RouteData.DataTokens["area"].ToString();
            string controller = htmlHelper.ViewContext.Controller.ValueProvider.GetValue("Controller").RawValue.ToString();

            string href = new UrlHelper(htmlHelper.ViewContext.HttpContext.Request.RequestContext).Action(action, controller, new { area = area });

            var button = new TagBuilder("button");
            button.Attributes["id"] = name;
            button.Attributes["name"] = name;
            button.Attributes["type"] = "button";
            button.Attributes["class"] = "btn btn-icon btn-" + type;
            button.MergeAttribute("onclick", "location.href='" + href + "';");
            button.InnerHtml = "<i class=\"fa fa-" + icon + "\"></i>&nbsp;" + display;

            return new HtmlString(System.Web.HttpUtility.HtmlDecode(button.ToString() + "&nbsp;"));
        }

        public static HtmlString DnaMaisButton(this HtmlHelper htmlHelper, string name, string display, string type, string icon)
        {
            var button = new TagBuilder("button");
            button.Attributes["id"] = name;
            button.Attributes["name"] = name;
            button.Attributes["type"] = "button";
            button.Attributes["class"] = "btn btn-" + type;
            button.InnerHtml = "<i class=\"fa fa-" + icon + "\"></i>&nbsp;" + display;

            return new HtmlString(button.ToString() + "&nbsp;");
        }

        // ********************************************
        // ButtonSubmit
        // ********************************************
        public static HtmlString DnaMaisSubmitButton(this HtmlHelper htmlHelper, string name, string display, string type, string icon)
        {
            return DnaMaisSubmitButton(htmlHelper, name, display, type, icon, "");
        }

        public static HtmlString DnaMaisSubmitButton(this HtmlHelper htmlHelper, string name, string display, string type, string icon, string value)
        {
            var button = new TagBuilder("button");
            button.Attributes["id"] = name;
            button.Attributes["name"] = name;
            button.Attributes["type"] = "submit";
            button.Attributes["class"] = "btn btn-" + type;
            button.Attributes["value"] = value;
            button.InnerHtml = "<i class=\"fa fa-" + icon + "\"></i>&nbsp;" + display;

            return new HtmlString(button.ToString() + "&nbsp;");
        }

    }
}