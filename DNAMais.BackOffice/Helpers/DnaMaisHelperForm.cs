using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DNAMais.BackOffice.Helpers
{
    public static class DnaMaisHelperForm
    {
        // ********************************************
        // FORM
        // ********************************************

        public static IDisposable DnaMaisBeginFormDetails(this HtmlHelper helper)
        {
            helper.ViewContext.Writer.Write(string.Format("<form class=\"form-horizontal form-bordered\">"));

            return new DnaMaisForm(helper);
        }

        public static IDisposable DnaMaisBeginForm(this HtmlHelper helper, string area, string controller, string action, string formid, bool autocomplete)
        {
            string href = new UrlHelper(helper.ViewContext.HttpContext.Request.RequestContext).Action(action, controller, new { area = area });

            helper.ViewContext.Writer.Write(string.Format("<form action=\"{0}\" id=\"{1}\" autocomplete=\"{2}\" class=\"form-horizontal\" method=\"post\" style=\"margin-bottom: 0;\">", href, formid, (autocomplete ? "on" : "off")));

            return new DnaMaisForm(helper);
        }

        public static IDisposable DnaMaisBeginForm(this HtmlHelper helper, string area, string controller, string action, object id, string formid, bool autocomplete, string enctype = null)
        {
            if (id == null)
            {
                string href = new UrlHelper(helper.ViewContext.HttpContext.Request.RequestContext).Action(action, controller, new { area = area });

                if (enctype == null)
                {
                    helper.ViewContext.Writer.Write(string.Format("<form action=\"{0}\" id=\"{1}\" autocomplete=\"{2}\" class=\"form-horizontal\" method=\"post\" style=\"margin-bottom: 0;\">", href, formid, (autocomplete ? "on" : "off")));
                }
                else
                {
                    helper.ViewContext.Writer.Write(string.Format("<form action=\"{0}\" id=\"{1}\" autocomplete=\"{2}\" enctype=\"multipart/form-data\" class=\"form-horizontal\" method=\"post\" style=\"margin-bottom: 0;\">", href, formid, autocomplete.ToString()));
                    
                }
            }
            else
            {
                string href = new UrlHelper(helper.ViewContext.HttpContext.Request.RequestContext).Action(action, controller, new { area = area, id = id });

                if (enctype == null)
                {
                    helper.ViewContext.Writer.Write(string.Format("<form action=\"{0}\" id=\"{1}\" autocomplete=\"{2}\" class=\"form-horizontal\" method=\"post\" style=\"margin-bottom: 0;\">", href, formid, autocomplete.ToString()));
                }
                else
                {
                    helper.ViewContext.Writer.Write(string.Format("<form action=\"{0}\" id=\"{1}\" autocomplete=\"{2}\" enctype=\"multipart/form-data\" class=\"form-horizontal\" method=\"post\" style=\"margin-bottom: 0;\">", href, formid, autocomplete.ToString()));
                }
            }

            return new DnaMaisForm(helper);
        }

        class DnaMaisForm : IDisposable
        {
            private HtmlHelper helper;

            public DnaMaisForm(HtmlHelper helper)
            {
                this.helper = helper;
            }

            public void Dispose()
            {
                this.helper.ViewContext.Writer.Write("</form>");
            }
        }

    }
}