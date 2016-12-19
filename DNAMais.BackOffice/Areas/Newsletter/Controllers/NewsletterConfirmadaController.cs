using DNAMais.BackOffice.Facades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DNAMais.BackOffice.Areas.Newsletter.Controllers
{
    public class NewsletterConfirmadaController : Controller
    {
        private NewsletterFacade facade;

        public NewsletterConfirmadaController()
        {
            facade = new NewsletterFacade(ModelState);
        }

        protected override void Initialize(RequestContext context)
        {
            base.Initialize(context);

            ViewBag.Menu = "MENU-NEWSLETTER-CONFIRMADA";
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (disposing && this.facade != null)
            {
                this.facade.Dispose();
            }
        }

        public ActionResult Index()
        {
            return View(facade.ListarConfirmadas());
        }
    }
}