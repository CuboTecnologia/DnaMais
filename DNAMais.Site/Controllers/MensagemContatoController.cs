using DNAMais.Domain.Entidades;
using DNAMais.Site.Facades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DNAMais.Site.Controllers
{
    public class MensagemContatoController : Controller
    {
        MensagemContatoFacade facade;

        public MensagemContatoController()
        {
            facade = new MensagemContatoFacade(ModelState);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (disposing && facade != null)
            {
                facade.Dispose();
            }
        }

        [HttpPost]
        public ActionResult EnviarMensagem(MensagemContato mensagemContato, string assuntoVisualizacao)
        {
            if (assuntoVisualizacao != null)
            {
                mensagemContato.Assunto = assuntoVisualizacao;
            }

            facade.EnviarMensagem(mensagemContato);

            TempData["msgSucesso"] = "Mensagem enviada com sucesso!";

            return RedirectToAction("Propose", "Contact");
        }
    }
}