using DNAMais.Domain;
using DNAMais.Domain.Entidades;
using DNAMais.Framework;
using DNAMais.Site.Facades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DNAMais.Site.Controllers
{
    public class NewsletterController : Controller
    {
        NewsletterFacade facade;

        public NewsletterController()
        {
            facade = new NewsletterFacade(ModelState);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (disposing && facade != null)
            {
                facade.Dispose();
            }
        }

        [HttpPost]
        public ActionResult SaveNewsletter(string newsletterName, string newsletterEmail)
        {
            Newsletter subscriptionConsult = facade.GetNewsletterByEmail(newsletterEmail);

            string guidSubscription = string.Empty;

            if (subscriptionConsult != null)
            {
                if (subscriptionConsult.OptIn == true)
                {
                    if (subscriptionConsult.OptOut == true)
                    {
                        subscriptionConsult.OptIn = false;
                        subscriptionConsult.OptOut = false;

                        facade.SaveNewsletter(subscriptionConsult);
                    }
                    else
                    {
                        //TODO
                        return PartialView("_NewsletterSubscriptionConfirmed");
                    }
                }
                else
                {
                    return PartialView("_NewsletterSubscriptionNotOptIn");
                }
            }
            else
            {
                //INCLUSAO DO NEWS
                Newsletter newsletter = new Newsletter();

                guidSubscription = Guid.NewGuid().ToString().Substring(0, 32);

                newsletter.Nome = newsletterName;
                newsletter.Email = newsletterEmail;
                newsletter.GUID = guidSubscription;

                facade.SaveNewsletter(newsletter);
            }

            if (ModelState.IsValid)
            {
                StreamReader emailKit = new StreamReader(Server.MapPath("~/EmailCommunication/EmailInscricaoNewsletter.html"));

                string corpo = emailKit.ReadToEnd();

                string controllerName = ControllerContext.Controller.ValueProvider.GetValue("Controller").RawValue.ToString();
                string actionName = ControllerContext.Controller.ValueProvider.GetValue("Action").RawValue.ToString();
                string url = Request.Url.AbsoluteUri.Replace("/" + controllerName, "").Replace("/" + actionName, "");

                string link = url + "/Newsletter/Confirmacao/?subscription=" + guidSubscription;

                corpo = corpo.Replace("@link@", link);

                Email.SendEmailSubscriptionNewsletter(newsletterEmail, corpo);

                emailKit.Dispose();

                return PartialView("_NewsletterSuccess");
            }
            else
            {
                return PartialView("_NewsletterError");
            }
        }

        public ActionResult SubscriptionEmailNewsletter()
        {
            return View();
        }

        public ActionResult Confirmacao(string subscription)
        {
            try
            {
                var newsletter = facade.GetNewsletterByGUID(subscription);

                if (newsletter.Id != null)
                {
                    newsletter.OptIn = true;
                    newsletter.DataRegistroOptIn = DateTime.Now;

                    facade.SaveNewsletter(newsletter);

                    return View();
                }
            }
            catch (Exception ex)
            {
                var x = ex.Message;
            }
            return View();
        }

        public ActionResult Cancelamento(string subscription)
        {
            try
            {
                var newsletter = facade.GetNewsletterByGUID(subscription);

                if (newsletter.Id != null)
                {
                    newsletter.OptOut = true;
                    newsletter.DataRegistroOptOut = DateTime.Now;

                    facade.SaveNewsletter(newsletter);

                    return View();
                }
            }
            catch (Exception ex)
            {
                var x = ex.Message;
            }
            return View();
        }

    }
}
