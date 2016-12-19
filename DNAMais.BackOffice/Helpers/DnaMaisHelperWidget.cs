using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace DNAMais.BackOffice.Helpers
{
    public static class DnaMaisHelperWidget
    {
        public static HtmlString DnaMaisSubTitle(this HtmlHelper helper, string titulo)
        {
            string tag = String.Format("<div class=\"widget-head\"><h4 class=\"heading\">{0}</h4></div>", titulo);
            return new HtmlString(tag);
        }

        public static HtmlString DnaMaisSubTitle(this HtmlHelper helper, string titulo, string icon)
        {
            string tag = String.Format("<div class=\"widget-head\"><h4 class=\"heading fa " + icon + "\"><i></i>{0}</h4></div>", titulo);
            return new HtmlString(tag);
        }

        // ********************************************
        // CONTENT
        // ********************************************
        public static IDisposable DnaMaisBeginContent(this HtmlHelper helper, string titulo)
        {
            StringBuilder tag = new StringBuilder();
            tag.Append(string.Format("<div class=\"col-lg-12\"><section class=\"panel\">"));
            tag.Append(string.Format("<header class=\"panel-heading\"><h2 class=\"panel-title\">{0}</h4></header>", titulo));
            tag.Append(string.Format("<div class=\"panel-body\">"));

            helper.ViewContext.Writer.Write(tag.ToString());

            return new DnaMaisContent(helper);
        }

        //public static IDisposable BeginBootStrapContent(this HtmlHelper helper, string titulo, icons icon)
        //{
        //    StringBuilder tag = new StringBuilder();
        //    tag.Append(string.Format("<div class=\"widget\">"));
        //    tag.Append(string.Format("<div class=\"widget-head\"><h4 class=\"heading fa " + icon.ToString().Replace("@", "") + "\"><i></i>{0}</h4></div>", titulo));
        //    tag.Append(string.Format("<div class=\"widget-body\">"));

        //    helper.ViewContext.Writer.Write(tag.ToString());

        //    return new BootStrapContent(helper);
        //}

        class DnaMaisContent : IDisposable
        {
            private HtmlHelper helper;

            public DnaMaisContent(HtmlHelper helper)
            {
                this.helper = helper;
            }

            public void Dispose()
            {
                this.helper.ViewContext.Writer.Write("</div></section></div>");
            }
        }


        // ********************************************
        // WIDGET
        // ********************************************
        //public static IDisposable BeginBootStrapWidget(this HtmlHelper helper, string id = "divWidget")
        //{
        //    helper.ViewContext.Writer.Write(string.Format("<div id=\"" + id + "\" class=\"widget\">"));

        //    return new BootStrapWidget(helper);
        //}

        //class BootStrapWidget : IDisposable
        //{
        //    private HtmlHelper helper;

        //    public BootStrapWidget(HtmlHelper helper)
        //    {
        //        this.helper = helper;
        //    }

        //    public void Dispose()
        //    {
        //        this.helper.ViewContext.Writer.Write("</div>");
        //    }
        //}

        // ********************************************
        // WIDGET BODY
        // ********************************************
        //public static IDisposable BeginBootStrapWidgetBody(this HtmlHelper helper)
        //{
        //    helper.ViewContext.Writer.Write(string.Format("<div class=\"widget-body\">"));

        //    return new BootStrapWidgetBody(helper);
        //}

        //class BootStrapWidgetBody : IDisposable
        //{
        //    private HtmlHelper helper;

        //    public BootStrapWidgetBody(HtmlHelper helper)
        //    {
        //        this.helper = helper;
        //    }

        //    public void Dispose()
        //    {
        //        this.helper.ViewContext.Writer.Write("</div>");
        //    }
        //}

        // ********************************************
        // ROW FLUID
        // ********************************************
        //public static IDisposable BeginBootStrapRowFluid(this HtmlHelper helper)
        //{
        //    helper.ViewContext.Writer.Write(string.Format("<div class=\"row-fluid\">"));

        //    return new BootStrapRowFluid(helper);
        //}

        //class BootStrapRowFluid : IDisposable
        //{
        //    private bool disposed;
        //    private readonly TextWriter writer;

        //    public BootStrapRowFluid(HtmlHelper helper)
        //    {
        //        this.writer = helper.ViewContext.Writer;
        //    }

        //    public void Dispose()
        //    {
        //        if (disposed) return;

        //        disposed = true;

        //        writer.WriteLine("</div>");
        //    }
        //}

        // ********************************************
        // SPAN
        // ********************************************
        //public static IDisposable BeginBootStrapSpan(this HtmlHelper helper, string span)
        //{
        //    helper.ViewContext.Writer.Write(string.Format("<div class=\"span6\" style=\"width:100%;\">"));

        //    return new BootStrapSpan(helper);
        //}

        //class BootStrapSpan : IDisposable
        //{
        //    private bool disposed;
        //    private readonly TextWriter writer;

        //    public BootStrapSpan(HtmlHelper helper)
        //    {
        //        this.writer = helper.ViewContext.Writer;
        //    }

        //    public void Dispose()
        //    {
        //        if (disposed) return;

        //        disposed = true;

        //        writer.WriteLine("</div>");
        //    }
        //}

        // ********************************************
        // DIV-ACTIONS
        // ********************************************
        //public static IDisposable BeginBootStrapDivActions(this HtmlHelper helper)
        //{
        //    helper.ViewContext.Writer.Write(string.Format("<div class=\"form-actions\">"));

        //    return new BootStrapDivActions(helper);
        //}

        //class BootStrapDivActions : IDisposable
        //{
        //    private HtmlHelper helper;

        //    public BootStrapDivActions(HtmlHelper helper)
        //    {
        //        this.helper = helper;
        //    }

        //    public void Dispose()
        //    {
        //        this.helper.ViewContext.Writer.Write("</div>");
        //    }
        //}

        /*
        public static HtmlString BootStrapDivSeparador(this HtmlHelper helper)
        {
            string tag = String.Format("<div class=\"separator bottom\"></div>");
            return new HtmlString(tag);
        }
        */

        /*
        public static HtmlString BootStrapHrSeparador(this HtmlHelper helper)
        {
            string tag = String.Format("<hr class=\"separator\" />");
            return new HtmlString(tag);
        }
        */

        /*
        public static HtmlString BootStrapTitle(this HtmlHelper helper, string titulo)
        {
            string tag = String.Format("<h3>{0}</h3>", titulo);
            return new HtmlString(tag);
        }
        */

    }
}