using DNAMais.BackOffice.ActionFilters;
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
    [ValidateUrlActionFilter]
    public class PerfilAcessoBackOfficeController : Controller
    {
        private AcessoFacade facade;

        public PerfilAcessoBackOfficeController()
        {
            facade = new AcessoFacade(ModelState);
        }

        protected override void Initialize(RequestContext context)
        {
            base.Initialize(context);
            //context.HttpContext.Session["currentFuncionality"] = "CRMPF-CADASTRO-MEIOCAPTACAO";

            ViewBag.Menu = "MENU-PERFIL-ACESSO-BACKOFFICE";
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
            return View(facade.ListarPerfisAcessoBackOffice());
        }

        //[AutorizacaoDnaMais]
        public ActionResult Details(byte id)
        {
            ViewData["LOCKED"] = true;
            return View("Cadastro", facade.ConsultarPerfilAcessoBackOfficePorId(id));
        }

        //[AutorizacaoDnaMais]
        public ActionResult Create()
        {
            return View("Cadastro", new PerfilAcessoBackOffice());
        }

        [HttpPost]
        //[AutorizacaoDnaMais]
        public ActionResult Create(PerfilAcessoBackOffice perfilAcessoBackOffice, string[] Funcionalidades)
        {
            if (Funcionalidades != null)
            {
                foreach (string codigoFuncionalidade in Funcionalidades)
                {
                    perfilAcessoBackOffice.PerfisFuncionalidades.Add(new PerfilAcessoFuncionalidade
                    {
                        CodigoFuncionalidadeBackOffice = codigoFuncionalidade
                    });
                }
            }
            facade.IncluirPerfilAcessoBackOffice(perfilAcessoBackOffice);
            return View("Cadastro", perfilAcessoBackOffice);
        }

        //[AutorizacaoDnaMais]
        public ActionResult Edit(byte id)
        {
            //facade.RemoverPerfilAcessoFuncionalidade(id);
            return View("Cadastro", facade.ConsultarPerfilAcessoBackOfficePorId(id));
        }

        [HttpPost]
        //[AutorizacaoDnaMais]
        public ActionResult Edit(PerfilAcessoBackOffice perfilAcessoBackOffice, string[] Funcionalidades)
        {
            //perfilAcessoBackOffice.PerfisFuncionalidades.Clear();

            if (Funcionalidades != null)
            {
                foreach (string codigoFuncionalidade in Funcionalidades)
                {
                    perfilAcessoBackOffice.PerfisFuncionalidades.Add(new PerfilAcessoFuncionalidade
                    {
                        IdPerfilBackOffice = perfilAcessoBackOffice.Id,
                        CodigoFuncionalidadeBackOffice = codigoFuncionalidade
                    });
                }
            }
            facade.AlterarPerfilAcessoBackOffice(perfilAcessoBackOffice);
            return View("Cadastro", perfilAcessoBackOffice);
        }

        //[AutorizacaoDnaMais]
        public ActionResult Remove(byte id)
        {
            facade.RemoverPerfilAcessoFuncionalidade(id);
            facade.RemoverPerfilAcessoBackOffice(id);

            if (ModelState.IsValid)
            {
                ViewData["Title"] = "DNA+ :: Perfis de Acesso BackOffice";
                ViewData["TituloPagina"] = "Perfis de Acesso BackOffice";
                ViewData["messageSuccess"] = "Perfil de Acesso BackOffice removido com sucesso";
                ViewData["messageReturn"] = "Voltar para lista de Perfis de Acesso BackOffice";

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
