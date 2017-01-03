using DNAMais.BackOffice.Facades;
using DNAMais.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DNAMais.BackOffice.Areas.Cadastros.Controllers
{
    public class TipoContatoController : Controller
    {
        private ClienteEmpresaFacade facade;

        public TipoContatoController()
        {
            facade = new ClienteEmpresaFacade(ModelState);
        }

        protected override void Initialize(RequestContext context)
        {
            base.Initialize(context);
            //context.HttpContext.Session["currentFuncionality"] = "CRMPF-CADASTRO-MEIOCAPTACAO";

            ViewBag.Menu = "MENU-TIPO-CONTATO";
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (disposing && this.facade != null)
            {
                this.facade.Dispose();
            }
        }

        //[AutorizacaoDnaMais]
        public ActionResult Index()
        {
            return View(facade.ListarTiposContato());
        }

        //[AutorizacaoDnaMais]
        public ActionResult Details(int id)
        {
            ViewData["LOCKED"] = true;
            return View("Cadastro", facade.ConsultarTipoContatoPorId(id));
        }

        //[AutorizacaoDnaMais]
        public ActionResult Create()
        {
            return View("Cadastro", new TipoContato());
        }

        [HttpPost]
        //[AutorizacaoDnaMais]
        public ActionResult Create(TipoContato tipoContato)
        {
            facade.IncluirTipoContato(tipoContato);

            if (ModelState.IsValid)
            {
                var x = "1";
            }
            else
            {
                var x = Helpers.DnaMaisHelperModelState.GetErrors(ModelState);
            }

            return View("Cadastro", tipoContato);
        }

        //[AutorizacaoDnaMais]
        public ActionResult Edit(short id)
        {
            return View("Cadastro", facade.ConsultarTipoContatoPorId(id));
        }

        [HttpPost]
        //[AutorizacaoDnaMais]
        public ActionResult Edit(TipoContato tipoContato)
        {
            facade.AlterarTipoContato(tipoContato);
            return View("Cadastro", tipoContato);
        }

        //[AutorizacaoDnaMais]
        public ActionResult Remove(short id)
        {
            facade.RemoverTipoContato(id);

            ViewData["Title"] = "DNA+ :: Tipos de Contato";
            ViewData["TituloPagina"] = "Tipos de Contato";
            ViewData["messageSuccess"] = "Tipo de contato removido com sucesso";
            ViewData["messageReturn"] = "Voltar para lista de Tipos de Contato";

            return View("_Remove");
        }

    }
}
