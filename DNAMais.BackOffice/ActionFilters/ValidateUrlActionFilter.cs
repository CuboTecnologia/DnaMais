using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace DNAMais.BackOffice.ActionFilters
{
    public class ValidateUrlActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                #region Valida Sessão e Login

                if (filterContext.RequestContext.HttpContext.Session["user"] == null)
                {
                    FormsAuthentication.SignOut();
                    filterContext.RequestContext.HttpContext.Session.Abandon();

                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary { 
                        { "Controller", "Autenticacao" }, 
                        { "Action", "Index" },                          
                        { "Area", String.Empty } });
                }

                #endregion
            }
            catch
            {
            }
        }

    }
}