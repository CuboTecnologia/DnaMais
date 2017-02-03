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
    public class CategoriaProdutoFaixaController : Controller
    {

        private CategoriaProdutoFacade facade;
        private CategoriaProdutoFaixaFacade facadeCategoriaFaixa;

        public CategoriaProdutoFaixaController()
        {
            facade = new CategoriaProdutoFacade(ModelState);

            facadeCategoriaFaixa = new CategoriaProdutoFaixaFacade(ModelState);

        }
        protected override void Initialize(RequestContext context)
        {
            base.Initialize(context);

            ViewBag.Menu = "MENU-CATEGORIA-PRODUTO";
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (disposing && this.facade != null && facadeCategoriaFaixa != null)
            {
                this.facade.Dispose();

                this.facadeCategoriaFaixa.Dispose();
            }
        }
        //
        // GET: /ConfiguracoesProduto/CategoriaProdutoFaixa/

        public ActionResult Index()
        {
            return View(facade.ListarTodasCategorias());
        }
        
        public ActionResult CategoriaFaixa(string id)
        {
           CategoriaProduto categoriaProduto =  facade.ConsultarCategoria(id);

           return PartialView(categoriaProduto.CategoriasFaixas.ToList());
        }

        public ActionResult EditarFaixa(string id)
        {
            return View("Cadastro", facadeCategoriaFaixa.ConsultarCategoriaFaixa(id));
        }

        [HttpPost]
        public JsonResult EditarFaixa(FormCollection form)
        {
            try
            {
                string idCategoria = form["data[IdCategoria]"];

                string codigoFaixa = form["data[CodigoFaixa]"];


                CategoriaProduto categoriaProduto = facade.ConsultarCategoria(idCategoria);

                CategoriaProdutoFaixa objCategoriaFaixa = new CategoriaProdutoFaixa();

                objCategoriaFaixa.CodigoCategoria = idCategoria;
                objCategoriaFaixa.CodigoFaixa = codigoFaixa;
                objCategoriaFaixa.DescricaoFaixa = form["data[Descricao]"];
                objCategoriaFaixa.InicioFaixa = Convert.ToInt32(form["data[InicioFaixa]"]);
                objCategoriaFaixa.TerminoFaixa = Convert.ToInt32(form["data[TerminoFaixa]"]);
                objCategoriaFaixa.InicioVigencia = DateTime.Now.Date;

                facadeCategoriaFaixa.AlterarFaixa(objCategoriaFaixa);

                return Json(new { success = true,idCategoria = idCategoria });
                
            }
            catch (Exception)
            {

                return Json(new { success = false });
            }
            
        }
    }
}
