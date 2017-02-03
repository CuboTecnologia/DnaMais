using DNAMais.BackOffice.ActionFilters;
using DNAMais.BackOffice.Facades;
using DNAMais.Domain;
using DNAMais.Domain.DTO;
using DNAMais.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DNAMais.BackOffice.Controllers
{
    public class AutenticacaoController : Controller
    {
        private AutenticacaoFacade facadeAutenticacao;

        public AutenticacaoController()
        {
            facadeAutenticacao = new AutenticacaoFacade(ModelState);
        }

        public ActionResult Index()
        {
            Session.Abandon();
            FormsAuthentication.SignOut();

            LoginUser login = new LoginUser();


            //login.Login = "admin";
            //login.Password = "1234";

            return View(login);
        }

        [HttpPost]
        public ActionResult Authenticate(LoginUser user, bool? rememberMe)
        {
            UsuarioBackOffice usuarioAutenticado;

            facadeAutenticacao.AutenticarUsuario(user, out usuarioAutenticado);

            if (ModelState.IsValid)
            {
                FormsAuthentication.SetAuthCookie(user.Login, false);

                Session.Add("user", usuarioAutenticado);

                return Json(new { success = true, responseText = string.Empty }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false, responseText = "Usuário ou senha inválidos" }, JsonRequestBehavior.AllowGet);
            }
        }

        public RedirectToRouteResult LogOff()
        {
            Session.Abandon();
            FormsAuthentication.SignOut();

            return RedirectToAction("Index");
        }

        public ActionResult AcessoNegado()
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            
            return View();
        }
    }
}
