using DNAMais.Domain.DTO;
using DNAMais.Domain.Entidades;
using DNAMais.Framework;
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

                return Json(new { success = true, responseText = "Login validado com sucesso", changePassword = (usuarioAutenticado.AlterarSenha == true ? true : false) }, JsonRequestBehavior.AllowGet);
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

        [HttpPost]
        public ActionResult ChangePassword(LoginUser user)
        {
            if (user.NewPassword == user.ConfirmNewPassword)
            {
                var usuarioAutenticado = facadeAutenticacao.ConsultarPorLogin(user.Login);

                if (usuarioAutenticado.Id != null)
                {
                    usuarioAutenticado.Senha = user.NewPassword;
                    usuarioAutenticado.AlterarSenha = false;

                    var resultAlt = facadeAutenticacao.AlterarUsuarioCliente(usuarioAutenticado);

                    if (resultAlt.Ok)
                    {
                        return Json(new { success = true, responseText = "Senha alterada com sucesso" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { success = false, responseText = resultAlt.Message }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { success = false, responseText = "As senhas não conferem" }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { success = false, responseText = "Usuário não localizado" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult SendNewPassword(LoginUser user)
        {
            if (user.Email.Trim() != string.Empty)
            {
                var usuarioAutenticado = facadeAutenticacao.ConsultarPorEmail(user.Email);

                if (usuarioAutenticado.Id != null && usuarioAutenticado.Ativo == true)
                {
                    string password = Membership.GeneratePassword(12, 1);

                    usuarioAutenticado.Senha = password;

                    var resultAlt = facadeAutenticacao.AlterarUsuarioCliente(usuarioAutenticado);

                    if (resultAlt.Ok)
                    {
                        var quebra = " \n\r";
                        var corpo = "Sua nova senha é " + password + quebra;

                        corpo += "Será solicitado que seja alterada a senha no primeiro login efetuado." + quebra + quebra;
                        corpo += "Atenciosamente" + quebra;
                        corpo += "DNA+" + quebra;

                        Email.SendEmailSubscriptionNewsletter(user.Email, corpo);

                        return Json(new { success = true, responseText = "Nova senha enviada com sucesso para o seu e-mail" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { success = false, responseText = resultAlt.Message }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { success = false, responseText = "E-mail não localizado." }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { success = false, responseText = "E-mail inválido" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
