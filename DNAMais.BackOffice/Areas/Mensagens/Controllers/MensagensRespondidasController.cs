using DNAMais.BackOffice.ActionFilters;
using DNAMais.BackOffice.Facades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DNAMais.BackOffice.Areas.Mensagens.Controllers
{
    [ValidateUrlActionFilter]
    public class MensagensRespondidasController : Controller
    {
        private MensagemContatoFacade facade;

        public MensagensRespondidasController()
        {
            facade = new MensagemContatoFacade(ModelState);
        }

        protected override void Initialize(RequestContext context)
        {
            base.Initialize(context);

            ViewBag.Menu = "MENU-MENSAGEM-RESPONDIDA";
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
            return View(facade.ListarRespondidas());

        }

        public ActionResult Details(int id)
        {
            return View(facade.ConsultarMensagemRespondidaPorId(id));
        }
    }
}