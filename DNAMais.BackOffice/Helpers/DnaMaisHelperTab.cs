using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DNAMais.BackOffice.Helpers
{
    public static class DnaMaisHelperTab
    {
        // ********************************************
        // WIDGET-TABS
        // ********************************************
        //public static IDisposable BeginBootStrapTabContent(this HtmlHelper helper)
        //{
        //    helper.ViewContext.Writer.Write(string.Format("<div class=\"widget-body\"><div class=\"tab-content\">"));

        //    return new BootStrapTabContent(helper);
        //}

        //class BootStrapTabContent : IDisposable
        //{
        //    private HtmlHelper helper;

        //    public BootStrapTabContent(HtmlHelper helper)
        //    {
        //        this.helper = helper;
        //    }

        //    public void Dispose()
        //    {
        //        this.helper.ViewContext.Writer.Write("</div></div>");
        //    }
        //}

        // ********************************************
        // TAB-WIZARD
        // ********************************************
        //public static IDisposable BeginBootStrapTabWizard(this HtmlHelper helper)
        //{
        //    helper.ViewContext.Writer.Write(string.Format("<div class=\"wizard\"><div class=\"widget widget-tabs\">"));

        //    return new BootStrapTabWizard(helper);
        //}

        //class BootStrapTabWizard : IDisposable
        //{
        //    private HtmlHelper helper;

        //    public BootStrapTabWizard(HtmlHelper helper)
        //    {
        //        this.helper = helper;
        //    }

        //    public void Dispose()
        //    {
        //        this.helper.ViewContext.Writer.Write("</div></div>");
        //    }
        //}

        // ********************************************
        // WIDGET-TABS
        // ********************************************
        //public static IDisposable BeginBootStrapWidgetTabs(this HtmlHelper helper)
        //{
        //    helper.ViewContext.Writer.Write(string.Format("<div class=\"widget-head\"><ul>"));

        //    return new BootStrapWidgetTabs(helper);
        //}

        //class BootStrapWidgetTabs : IDisposable
        //{
        //    private HtmlHelper helper;

        //    public BootStrapWidgetTabs(HtmlHelper helper)
        //    {
        //        this.helper = helper;
        //    }

        //    public void Dispose()
        //    {
        //        this.helper.ViewContext.Writer.Write("</ul></div>");
        //    }
        //}

        public static HtmlString DnaMaisTabItem(this HtmlHelper helper, string titulo, string icon, string area, string controller, string action, string parameter, string id, bool active)
        {
            string tag = String.Format("<li" + (active ? " class=\"active\"" : "") + "><a href=\"/{1}/{2}/{3}/?{4}={5}\" class=\"fa " + icon + "\"><i></i>{0}</a></li>", titulo, area, controller, action, parameter, id);
            return new HtmlString(tag);
        }
    }
}