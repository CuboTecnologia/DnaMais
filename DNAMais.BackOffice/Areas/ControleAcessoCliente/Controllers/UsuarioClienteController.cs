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
    public class UsuarioClienteController : Controller
    {
        private AcessoClienteFacade facade;

        public UsuarioClienteController()
        {
            facade = new AcessoClienteFacade(ModelState);
        }

        protected override void Initialize(RequestContext context)
        {
            base.Initialize(context);
            //context.HttpContext.Session["currentFuncionality"] = "CRMPF-CADASTRO-MEIOCAPTACAO";

            ViewBag.Menu = "MENU-USUARIO-CLIENTE";
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
            return View(facade.ListarUsuariosCliente());
        }

        //[AutorizacaoDnaMais]
        public ActionResult Details(int id)
        {
            ViewData["LOCKED"] = true;
            return View("Cadastro", facade.ConsultarUsuarioClientePorId(id));
        }

        //[AutorizacaoDnaMais]
        public ActionResult Create()
        {
            return View("Cadastro", new UsuarioCliente());
        }

        [HttpPost]
        //[AutorizacaoDnaMais]
        public ActionResult Create(UsuarioCliente usuarioCliente)
        {
            facade.IncluirUsuarioCliente(usuarioCliente);
            return View("Cadastro", usuarioCliente);
        }

        //[AutorizacaoDnaMais]
        public ActionResult Edit(int id)
        {
            return View("Cadastro", facade.ConsultarUsuarioClientePorId(id));
        }

        [HttpPost]
        //[AutorizacaoDnaMais]
        public ActionResult Edit(UsuarioCliente usuarioCliente)
        {
            facade.AlterarUsuarioCliente(usuarioCliente);
            return View("Cadastro", usuarioCliente);
        }

        //[AutorizacaoDnaMais]
        public ActionResult Remove(int id)
        {
            facade.RemoverUsuarioCliente(id);

            ViewData["Title"] = "DNA+ :: Usuários Cliente";
            ViewData["TituloPagina"] = "Usuários Cliente";
            ViewData["messageSuccess"] = "Usuário Cliente removido com sucesso";
            ViewData["messageReturn"] = "Voltar para lista de Usuários Cliente";

            return View("_Remove");
        }

    }
}
