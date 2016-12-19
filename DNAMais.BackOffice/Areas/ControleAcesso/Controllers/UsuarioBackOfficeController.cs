using DNAMais.BackOffice.Facades;
using DNAMais.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DNAMais.BackOffice.Areas.ControleAcesso.Controllers
{
    public class UsuarioBackOfficeController : Controller
    {
        private AcessoFacade facade;

        public UsuarioBackOfficeController()
        {
            facade = new AcessoFacade(ModelState);
        }

        protected override void Initialize(RequestContext context)
        {
            base.Initialize(context);
            //context.HttpContext.Session["currentFuncionality"] = "CRMPF-CADASTRO-MEIOCAPTACAO";

            ViewBag.Menu = "MENU-USUARIO-BACKOFFICE";
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
            return View(facade.ListarUsuariosBackOffice());
        }

        //[AutorizacaoDnaMais]
        public ActionResult Details(int id)
        {
            ViewData["LOCKED"] = true;
            return View("Cadastro", facade.ConsultarUsuarioBackOfficePorId(id));
        }

        //[AutorizacaoDnaMais]
        public ActionResult Create()
        {
            return View("Cadastro", new UsuarioBackOffice());
        }

        [HttpPost]
        //[AutorizacaoDnaMais]
        public ActionResult Create(UsuarioBackOffice usuarioBackOffice)
        {
            facade.IncluirUsuarioBackOffice(usuarioBackOffice);
            return View("Cadastro", usuarioBackOffice);
        }

        //[AutorizacaoDnaMais]
        public ActionResult Edit(int id)
        {
            return View("Cadastro", facade.ConsultarUsuarioBackOfficePorId(id));
        }

        [HttpPost]
        //[AutorizacaoDnaMais]
        public ActionResult Edit(UsuarioBackOffice usuarioBackOffice)
        {
            facade.AlterarUsuarioBackOffice(usuarioBackOffice);
            return View("Cadastro", usuarioBackOffice);
        }

        //[AutorizacaoDnaMais]
        public ActionResult Remove(int id)
        {
            facade.RemoverUsuarioBackOffice(id);

            ViewData["Title"] = "DNA+ :: Usuários BackOffice";
            ViewData["TituloPagina"] = "Usuários BackOffice";
            ViewData["messageSuccess"] = "Usuário BackOffice removido com sucesso";
            ViewData["messageReturn"] = "Voltar para lista de Usuários BackOffice";

            return View("_Remove");
        }

    }
}
