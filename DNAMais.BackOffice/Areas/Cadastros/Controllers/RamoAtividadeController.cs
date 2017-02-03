using DNAMais.BackOffice.ActionFilters;
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
    [ValidateUrlActionFilter]
    public class RamoAtividadeController : Controller
    {
        private ClienteEmpresaFacade facade;

        public RamoAtividadeController()
        {
            facade = new ClienteEmpresaFacade(ModelState);
        }

        protected override void Initialize(RequestContext context)
        {
            base.Initialize(context);
            //context.HttpContext.Session["currentFuncionality"] = "CRMPF-CADASTRO-MEIOCAPTACAO";

            ViewBag.Menu = "MENU-RAMO-ATIVIDADE";
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
            return View(facade.ListarRamosAtividade());
        }

        //[AutorizacaoDnaMais]
        public ActionResult Details(int id)
        {
            ViewData["LOCKED"] = true;
            return View("Cadastro", facade.ConsultarRamoAtividadePorId(id));
        }

        //[AutorizacaoDnaMais]
        public ActionResult Create()
        {
            return View("Cadastro", new RamoAtividade());
        }

        [HttpPost]
        //[AutorizacaoDnaMais]
        public ActionResult Create(RamoAtividade ramoAtividade)
        {
            facade.SalvarRamoAtividade(ramoAtividade);
            return View("Cadastro", ramoAtividade);
        }

        //[AutorizacaoDnaMais]
        public ActionResult Edit(short id)
        {
            return View("Cadastro", facade.ConsultarRamoAtividadePorId(id));
        }

        [HttpPost]
        //[AutorizacaoDnaMais]
        public ActionResult Edit(RamoAtividade ramoAtividade)
        {
            facade.SalvarRamoAtividade(ramoAtividade);
            return View("Cadastro", ramoAtividade);
        }

        //[AutorizacaoDnaMais]
        public ActionResult Remove(short id)
        {
            facade.RemoverRamoAtividade(id);

            if (ModelState.IsValid)
            {
                ViewData["Title"] = "DNA+ :: Ramos de Atividade";
                ViewData["TituloPagina"] = "Ramos de Atividade";
                ViewData["messageSuccess"] = "Ramo de Atividade removido com sucesso";
                ViewData["messageReturn"] = "Voltar para lista de Ramos de Atividade";

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
