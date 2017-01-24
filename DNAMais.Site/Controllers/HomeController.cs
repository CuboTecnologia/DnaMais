using DNAMais.Domain.DTO;
using DNAMais.Domain.Entidades;
using DNAMais.Site.Facades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DNAMais.Site.Controllers
{
    public class HomeController : Controller
    {
        private AutenticacaoFacade facadeAutenticacao;

        public HomeController()
        {
            facadeAutenticacao = new AutenticacaoFacade(ModelState);
        }

        public ActionResult Index()
        {
            LoginUser login = new LoginUser();

            return View(login);
        }

        [HttpPost]
        public ActionResult Index(LoginUser user, bool? rememberMe)
        {
            UsuarioCliente usuarioAutenticado;

            var result = facadeAutenticacao.AutenticarUsuario(user, out usuarioAutenticado);

            if (result.Ok && usuarioAutenticado.Id != null)
            {
                FormsAuthentication.SetAuthCookie(user.Login, false);
                Session.Add("user", usuarioAutenticado);

                return Json(new { success = true, responseText = "Login validado com sucesso" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false, responseText = result.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();

            return RedirectToAction("Index");
        }
    }
}
