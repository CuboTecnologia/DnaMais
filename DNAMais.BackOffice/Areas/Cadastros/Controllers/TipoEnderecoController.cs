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
    public class TipoEnderecoController : Controller
    {
        private ClienteEmpresaFacade facade;

        public TipoEnderecoController()
        {
            facade = new ClienteEmpresaFacade(ModelState);
        }

        protected override void Initialize(RequestContext context)
        {
            base.Initialize(context);
            //context.HttpContext.Session["currentFuncionality"] = "CRMPF-CADASTRO-MEIOCAPTACAO";

            ViewBag.Menu = "MENU-TIPO-ENDERECO";
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
            return View(facade.ListarTiposEndereco());
        }

        //[AutorizacaoDnaMais]
        public ActionResult Details(int id)
        {
            ViewData["LOCKED"] = true;
            return View("Cadastro", facade.ConsultarTipoEnderecoPorId(id));
        }

        //[AutorizacaoDnaMais]
        public ActionResult Create()
        {
            return View("Cadastro", new TipoEndereco());
        }

        [HttpPost]
        //[AutorizacaoDnaMais]
        public ActionResult Create(TipoEndereco tipoEndereco)
        {
            facade.IncluirTipoEndereco(tipoEndereco);
            return View("Cadastro", tipoEndereco);
        }

        //[AutorizacaoDnaMais]
        public ActionResult Edit(short id)
        {
            return View("Cadastro", facade.ConsultarTipoEnderecoPorId(id));
        }

        [HttpPost]
        //[AutorizacaoDnaMais]
        public ActionResult Edit(TipoEndereco tipoEndereco)
        {
            facade.AlterarTipoEndereco(tipoEndereco);
            return View("Cadastro", tipoEndereco);
        }

        //[AutorizacaoDnaMais]
        public ActionResult Remove(short id)
        {
            facade.RemoverTipoEndereco(id);

            ViewData["Title"] = "DNA+ :: Tipos de Endereço";
            ViewData["TituloPagina"] = "Tipos de Endereço";
            ViewData["messageSuccess"] = "Tipo de endereço removido com sucesso";
            ViewData["messageReturn"] = "Voltar para lista de Tipos de Endereço";

            return View("_Remove");
        }

    }
}
