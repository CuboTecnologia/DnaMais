using DNAMais.Domain.Entidades;
using DNAMais.Domain.Services;
using DNAMais.Framework;
using DNAMais.Site.Facades.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DNAMais.Site.Facades
{
    public class MensagemContatoFacade : BaseFacade, IDisposable
    {
        private MensagemContatoService serviceMensagem;

        public MensagemContatoFacade(ModelStateDictionary modelState)
            : base(modelState)
        {
            serviceMensagem = new MensagemContatoService();
        }

        public void Dispose()
        {
            serviceMensagem.Dispose();
        }

        public void EnviarMensagem(MensagemContato mensagemContato)
        {
            if (!modelState.IsValid)
            {
                return;
            }

            ResultValidation result = serviceMensagem.Salvar(mensagemContato);

            FillModelState(result);
        }
    }
}