using DNAMais.BackOffice.Facades.Base;
using DNAMais.Domain.Entidades;
using DNAMais.Domain.Services;
using DNAMais.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DNAMais.BackOffice.Facades
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

        #region Newsletter

        public IQueryable ListarNaoConfirmadas()
        {
            return serviceNewsletter.ListarNaoConfirmadas();
        }

        public IQueryable ListarConfirmadas()
        {
            return serviceNewsletter.ListarConfirmadas();
        }

        public IQueryable ListarCanceladas()
        {
            return serviceNewsletter.ListarCanceladas();
        }

        public Newsletter ConfirmarNewsletter(int id)
        {
            Newsletter newsletter = serviceNewsletter.ConfirmarNewsletter(id);

            newsletter.DataRegistroOptIn = DateTime.Now;

            return newsletter;
        }

        public void SalvarMensagemContato(Newsletter newsletter)
        {
            if (!modelState.IsValid)
            {
                return;
            }

            ResultValidation retorno = serviceNewsletter.Salvar(newsletter);

            PreencherModelState(retorno);
        }

        #endregion
    }
}