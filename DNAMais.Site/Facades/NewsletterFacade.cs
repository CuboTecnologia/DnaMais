using System;
using System.Web.Mvc;
using DNAMais.Domain.Entidades;
using DNAMais.Domain.Services;
using DNAMais.Framework;
using DNAMais.Site.Facades.Base;

namespace DNAMais.Site.Facades
{
    public class NewsletterFacade : BaseFacade, IDisposable
    {
        private NewsletterService serviceNewsletter;

        public NewsletterFacade(ModelStateDictionary modelState)
            : base(modelState)
        {
            serviceNewsletter = new NewsletterService();
        }

        public void Dispose()
        {
            serviceNewsletter.Dispose();
        }

        public void SaveNewsletter(Newsletter subscriptionNewsletter)
        {
            if (!modelState.IsValid)
            {
                return;
            }

            ResultValidation result = serviceNewsletter.Salvar(subscriptionNewsletter);

            FillModelState(result);
        }

        public Newsletter GetNewsletterByGUID(string guid)
        {
            return serviceNewsletter.ConsultarPorGuid(guid);
        }

        public Newsletter GetNewsletterByEmail(string email)
        {
            return serviceNewsletter.ConsultarPorEmail(email);
        }
    }
}