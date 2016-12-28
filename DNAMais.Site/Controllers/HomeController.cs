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
            UsuarioBackOffice usuarioAutenticado;

            facadeAutenticacao.AutenticarUsuario(user, out usuarioAutenticado);

            if (ModelState.IsValid)
            {
                FormsAuthentication.SetAuthCookie(user.Login, false);

                Session.Add("user", usuarioAutenticado);

                return RedirectToAction("ProdutosContratados", "AreaRestrita");
            }
            else
            {
                return View("Index", user);
            }
        }
    }
}
