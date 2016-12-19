using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using DNAMais.BackOffice.Facades;
using DNAMais.Domain.Entidades;

namespace DNAMais.BackOffice.Areas.ConfiguracoesProduto.Controllers
{
    public class ProdutoController : Controller
    {
        private ProdutoFacade facade;

        public ProdutoController()
        {
            facade = new ProdutoFacade(ModelState);
        }

        protected override void Initialize(RequestContext context)
        {
            base.Initialize(context);

            ViewBag.Menu = "MENU-PRODUTO";
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (disposing && this.facade != null && facade != null)
            {
                this.facade.Dispose();
            }
        }

        public ActionResult Index()
        {
            return View(facade.ListarProdutos().ToList());
        }

        public ActionResult Edit(string id)
        {
            return View("Cadastro", facade.ConsultarProdutoPorId(id));
        }

        [HttpPost]
        public ActionResult Edit(Produto produto)
        {
            facade.AlterarProduto(produto);
            return View("Cadastro", produto);
        }
    }
}