using DNAMais.BackOffice.ActionFilters;
using DNAMais.BackOffice.Facades;
using DNAMais.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DNAMais.BackOffice.Areas.Mensagens.Controllers
{
    [ValidateUrlActionFilter]
    public class MensagensNaoRespondidasController : Controller
    {
        private MensagemContatoFacade facade;

        public MensagensNaoRespondidasController()
        {
            facade = new MensagemContatoFacade(ModelState);
        }

        protected override void Initialize(RequestContext context)
        {
            base.Initialize(context);

            ViewBag.Menu = "MENU-MENSAGEM-NAO-RESPONDIDA";
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
            return View(facade.ListarNaoRespondidas());

        }

        public ActionResult Details(int id)
        {
            return View(facade.ConsultarMensagemNaoRespondidaPorId(id));
        }

        public ActionResult Answer(int id)
        {
            return View(facade.ConsultarMensagemNaoRespondidaPorId(id));
        }

        [HttpPost]
        public ActionResult Answer(MensagemContato mensagemContato)
        {
            facade.SalvarMensagemContato(mensagemContato);
            TempData["msgSucesso"] = "Resposta Enviada com sucesso";
            return View("Index", facade.ListarNaoRespondidas());
        }
    }
}