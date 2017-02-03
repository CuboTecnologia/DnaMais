using DNAMais.BackOffice.ActionFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DNAMais.BackOffice.Views.Home
{
    [ValidateUrlActionFilter]
    public class NewsletterController : Controller
    {
        //
        // GET: /Newsletter/

        public ActionResult NotConfirmed()
        {
            return View();
        }

        public ActionResult Confirmed()
        {
            return View();
        }

        public ActionResult Canceled()
        {
            return View();
        }

    }
}
