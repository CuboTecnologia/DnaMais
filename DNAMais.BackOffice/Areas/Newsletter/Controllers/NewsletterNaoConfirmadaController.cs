using DNAMais.BackOffice.Facades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DNAMais.BackOffice.Areas.Newsletter.Controllers
{
    public class NewsletterNaoConfirmadaController : Controller
    {
        private NewsletterFacade facade;

        public NewsletterNaoConfirmadaController()
        {
            facade = new NewsletterFacade(ModelState);
        }

        protected override void Initialize(RequestContext context)
        {
            base.Initialize(context);

            ViewBag.Menu = "MENU-NEWSLETTER-NAO-CONFIRMADA";
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
            return View(facade.ListarNaoConfirmadas());
        }

        public ActionResult Confirm(int id)
        {
            facade.SalvarMensagemContato(facade.ConfirmarNewsletter(id));

            TempData["msgSucesso"] = "Newsletter confirmada com sucesso";

            return View("Index", facade.ListarNaoConfirmadas());
        }
    }
}