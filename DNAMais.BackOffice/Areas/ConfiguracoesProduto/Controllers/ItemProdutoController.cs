using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using DNAMais.BackOffice.Facades;
using DNAMais.Domain.Entidades;
using DNAMais.BackOffice.ActionFilters;

namespace DNAMais.BackOffice.Areas.ConfiguracoesProduto.Controllers
{
    [ValidateUrlActionFilter]
    public class ItemProdutoController : Controller
    {
        private ProdutoFacade facade;

        public ItemProdutoController()
        {
            facade = new ProdutoFacade(ModelState);
        }

        protected override void Initialize(RequestContext context)
        {
            base.Initialize(context);

            ViewBag.Menu = "MENU-ITEM-PRODUTO";
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
            return View(facade.ListarItensProduto().ToList());
        }

        public ActionResult Edit(string id)
        {
            return View("Cadastro", facade.ConsultarItemProdutoPorId(id));
        }

        [HttpPost]
        //[AutorizacaoDnaMais]
        public ActionResult Edit(ItemProduto itemProduto)
        {
            facade.AlterarItemProduto(itemProduto);
            return View("Cadastro", itemProduto);
        }
    }
}