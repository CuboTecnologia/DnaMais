using DNAMais.BackOffice.ActionFilters;
using DNAMais.BackOffice.Facades;
using DNAMais.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DNAMais.BackOffice.Areas.ControleAcessoCliente.Controllers
{
    [ValidateUrlActionFilter]
    public class GrupoUsuarioClienteController : Controller
    {
        private AcessoClienteFacade facade;

        public GrupoUsuarioClienteController()
        {
            facade = new AcessoClienteFacade(ModelState);
        }

        protected override void Initialize(RequestContext context)
        {
            base.Initialize(context);
            //context.HttpContext.Session["currentFuncionality"] = "CRMPF-CADASTRO-MEIOCAPTACAO";

            ViewBag.Menu = "MENU-GRUPO-USUARIO-CLIENTE";
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
            return View(facade.ListarGruposUsuarioCliente());
        }

        //[AutorizacaoDnaMais]
        public ActionResult Details(int id)
        {
            ViewData["LOCKED"] = true;
            return View("Cadastro", facade.ConsultarGrupoUsuarioClientePorId(id));
        }

        //[AutorizacaoDnaMais]
        public ActionResult Create()
        {
            return View("Cadastro", new GrupoUsuarioCliente());
        }

        [HttpPost]
        //[AutorizacaoDnaMais]
        public ActionResult Create(GrupoUsuarioCliente grupoUsuarioCliente)
        {
            facade.IncluirGrupoUsuarioCliente(grupoUsuarioCliente);
            return View("Cadastro", grupoUsuarioCliente);
        }

        //[AutorizacaoDnaMais]
        public ActionResult Edit(int id)
        {
            return View("Cadastro", facade.ConsultarGrupoUsuarioClientePorId(id));
        }

        [HttpPost]
        //[AutorizacaoDnaMais]
        public ActionResult Edit(GrupoUsuarioCliente grupoUsuarioCliente)
        {
            facade.AlterarGrupoUsuarioCliente(grupoUsuarioCliente);
            return View("Cadastro", grupoUsuarioCliente);
        }

        //[AutorizacaoDnaMais]
        public ActionResult Remove(int id)
        {
            facade.RemoverGrupoUsuarioCliente(id);

            if (ModelState.IsValid)
            {
                ViewData["Title"] = "DNA+ :: Grupos de Usuários Cliente";
                ViewData["TituloPagina"] = "Grupos de Usuários Cliente";
                ViewData["messageSuccess"] = "Grupo de usuário cliente removido com sucesso";
                ViewData["messageReturn"] = "Voltar para lista de Grupos de Usuários Cliente";

                return Json(new { success = true, responseText = string.Empty }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var errorText = Helpers.DnaMaisHelperModelState.GetErrorFriendly(ModelState);
                return Json(new { success = false, responseText = errorText }, JsonRequestBehavior.AllowGet);
            }
        }

    }
}
