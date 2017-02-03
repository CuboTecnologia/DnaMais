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
    public class UsuarioClienteController : Controller
    {
        private AcessoClienteFacade facade;
        private ProdutoFacade facadeProduto;

        //TODO: Usuario Cliente - Criar colunas para controle das permissoes na area restrita


        public UsuarioClienteController()
        {
            facade = new AcessoClienteFacade(ModelState);
            facadeProduto = new ProdutoFacade(ModelState);
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

            if (ModelState.IsValid)
            {
                ViewData["Title"] = "DNA+ :: Usuários Cliente";
                ViewData["TituloPagina"] = "Usuários Cliente";
                ViewData["messageSuccess"] = "Usuário Cliente removido com sucesso";
                ViewData["messageReturn"] = "Voltar para lista de Usuários Cliente";

                return Json(new { success = true, responseText = string.Empty }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var errorText = Helpers.DnaMaisHelperModelState.GetErrorFriendly(ModelState);
                return Json(new { success = false, responseText = errorText }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult ProdutosLiberados(int id)
        {
            UsuarioCliente usuarioCliente = facade.ConsultarUsuarioClientePorId(id);

            ViewBag.CodigousuarioCliente = id;
            ViewBag.NomeEmpresa = usuarioCliente.ClienteEmpresa.RazaoSocial;
            ViewBag.NomeUsuarioCliente = usuarioCliente.Nome;
            ViewBag.Produtos = usuarioCliente.UsuarioClienteProdutosSelecionados;

            return View("ProdutosSelecionados", facadeProduto.ListarProdutos());
        }

        [HttpPost]
        public ActionResult ProdutosLiberados(int idUsuarioCliente, List<string> produtosSelecionados)
        {
            facade.SalvarUsuarioClienteProdutosSelecionados(idUsuarioCliente, produtosSelecionados);

            if (ModelState.IsValid)
            {
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
