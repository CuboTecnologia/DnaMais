using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace DNAMais.BackOffice.Helpers
{
    public static class DnaMaisHelperTable
    {
        public static HtmlString DnaMaisTableLinkDetails(this HtmlHelper helper, string action, object id)
        {
            string area = helper.ViewContext.RouteData.DataTokens["area"].ToString();
            string controller = helper.ViewContext.Controller.ValueProvider.GetValue("Controller").RawValue.ToString();

            string href = new UrlHelper(helper.ViewContext.HttpContext.Request.RequestContext).Action(action, controller, new { area = area, id = id });

            string tag = String.Format("<a href=\"{0}\" class=\"btn btn-default\" title=\"consultar\">&nbsp;<i class=\"fa fa-search\"></i>&nbsp;</a>&nbsp;", href);
            return new HtmlString(tag);
        }

        public static HtmlString DnaMaisTableLinkCheck(this HtmlHelper helper, string action, object id)
        {
            string area = helper.ViewContext.RouteData.DataTokens["area"].ToString();
            string controller = helper.ViewContext.Controller.ValueProvider.GetValue("Controller").RawValue.ToString();

            string href = new UrlHelper(helper.ViewContext.HttpContext.Request.RequestContext).Action(action, controller, new { area = area, id = id });

            string tag = String.Format("<a href=\"{0}\" class=\"btn btn-default\" title=\"confirmar\">&nbsp;<i class=\"fa fa-check\"></i>&nbsp;</a>&nbsp;", href);
            return new HtmlString(tag);
        }

        public static HtmlString DnaMaisTableLinkEdit(this HtmlHelper helper, string action, object id)
        {
            string area = helper.ViewContext.RouteData.DataTokens["area"].ToString();
            string controller = helper.ViewContext.Controller.ValueProvider.GetValue("Controller").RawValue.ToString();

            string tag = string.Empty;
            string href = new UrlHelper(helper.ViewContext.HttpContext.Request.RequestContext).Action(action, controller, new { area = area, id = id });

            tag = String.Format("<a href=\"{0}\" class=\"btn btn-default\" title=\"editar\">&nbsp;<i class=\"fa fa-pencil\"></i>&nbsp;</a>&nbsp;", href);

            return new HtmlString(tag);
        }

        public static HtmlString DnaMaisTableLinkEdit(this HtmlHelper helper, string action, string name, object id)
        {
            string area = helper.ViewContext.RouteData.DataTokens["area"].ToString();
            string controller = helper.ViewContext.Controller.ValueProvider.GetValue("Controller").RawValue.ToString();

            string tag = string.Empty;
            string href = new UrlHelper(helper.ViewContext.HttpContext.Request.RequestContext).Action(action, controller, new { area = area, id = id });

            tag = String.Format("<a href=\"{0}\" class=\"btn btn-default\" title=\"editar\" id=\"{1}\">&nbsp;<i class=\"fa fa-pencil\"><i></i>&nbsp;</a>&nbsp;", href, name);

            return new HtmlString(tag);
        }

        public static HtmlString DnaMaisTableLinkRemove(this HtmlHelper helper, string action, object id, string message)
        {
            string area = helper.ViewContext.RouteData.DataTokens["area"].ToString();
            string controller = helper.ViewContext.Controller.ValueProvider.GetValue("Controller").RawValue.ToString();

            string tag = string.Empty;
            string href = new UrlHelper(helper.ViewContext.HttpContext.Request.RequestContext).Action(action, controller, new { area = area, id = id });

            tag = String.Format("<a href=\"{0}\" class=\"btn btn-default\" title=\"remover\" onclick=\"return confirm('{1}');\">&nbsp;<i class=\"fa fa-remove\"></i>&nbsp;</a>&nbsp;", href, message);

            return new HtmlString(tag);
        }

        public static HtmlString DnaMaisTableLinkRemove(this HtmlHelper helper, string action, string name, object id)
        {
            string area = helper.ViewContext.RouteData.DataTokens["area"].ToString();
            string controller = helper.ViewContext.Controller.ValueProvider.GetValue("Controller").RawValue.ToString();

            string tag = string.Empty;
            string href = new UrlHelper(helper.ViewContext.HttpContext.Request.RequestContext).Action(action, controller, new { area = area, id = id });

            tag = String.Format("<a href=\"{0}\" class=\"btn btn-default\" title=\"remover\" id=\"{1}\">&nbsp;<i class=\"fa fa-remove\"></i>&nbsp;</a>&nbsp;", href, name);

            return new HtmlString(tag);
        }

        public static HtmlString DnaMaisTableLinkAnexo(this HtmlHelper helper, string action, string name, object id)
        {
            string area = helper.ViewContext.RouteData.DataTokens["area"].ToString();
            string controller = helper.ViewContext.Controller.ValueProvider.GetValue("Controller").RawValue.ToString();

            string tag = string.Empty;
            string href = new UrlHelper(helper.ViewContext.HttpContext.Request.RequestContext).Action(action, controller, new { area = area, id = id });

            tag = String.Format("<a href=\"{0}\" class=\"btn btn-default\" title=\"anexo\" id=\"{1}\">&nbsp;<i class=\"fa fa-paperclip\"></i>&nbsp;</a>&nbsp;", href, name);

            return new HtmlString(tag);
        }

        public static HtmlString DnaMaisTableLinkIcone(this HtmlHelper helper, string area, string controller, string action, string name, object id, string icone, string titulo)
        {
            string tag = string.Empty;
            string href = new UrlHelper(helper.ViewContext.HttpContext.Request.RequestContext).Action(action, controller, new { area = area, id = id });

            tag = String.Format("<a href=\"{0}\" class=\"btn btn-default\" title=\"" + titulo + "\" id=\"{1}\">&nbsp;<i class=\"fa fa-" + icone + "\"></i>&nbsp;</a>&nbsp;", href, name);

            return new HtmlString(tag);
        }

        public static HtmlString DnaMaisTableLinkIcone(this HtmlHelper helper, string action, string name, object id, string icone, string titulo)
        {
            string area = helper.ViewContext.RouteData.DataTokens["area"].ToString();
            string controller = helper.ViewContext.Controller.ValueProvider.GetValue("Controller").RawValue.ToString();

            string tag = string.Empty;
            string href = new UrlHelper(helper.ViewContext.HttpContext.Request.RequestContext).Action(action, controller, new { area = area, id = id });

            tag = String.Format("<a href=\"{0}\" class=\"btn btn-default\" title=\"" + titulo + "\" id=\"{1}\">&nbsp;<i class=\"fa fa-" + icone + "\"></i>&nbsp;</a>&nbsp;", href, name);

            return new HtmlString(tag);
        }

        public static WebGridColumn BoundField(string nome, string titulo, string estilo)
        {
            return new WebGridColumn { ColumnName = nome, Header = titulo, Style = estilo };
        }
    }
}
