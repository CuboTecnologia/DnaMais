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
    public class MensagemContatoFacade : BaseFacade, IDisposable
    {
        private MensagemContatoService serviceMensagem;
        private UsuarioBackOfficeService serviceBackOffice;

        public MensagemContatoFacade(ModelStateDictionary modelState)
            : base(modelState)
        {
            serviceMensagem = new MensagemContatoService();
            serviceBackOffice = new UsuarioBackOfficeService();
        }

        public void Dispose()
        {
            serviceMensagem.Dispose();
            serviceBackOffice.Dispose();
        }

        #region Mensagem Contato

        public IQueryable<MensagemContato> ListarNaoRespondidas()
        {
            return serviceMensagem.ListarNaoRespondidas();
        }

        public IQueryable<MensagemContato> ListarRespondidas()
        {
            return serviceMensagem.ListarRespondidas();
        }

        public MensagemContato ConsultarMensagemNaoRespondidaPorId(int id)
        {
            return serviceMensagem.ConsultarPorId(id);
        }

        public MensagemContato ConsultarMensagemRespondidaPorId(int id)
        {
            MensagemContato mensagemContato = serviceMensagem.ConsultarPorId(id);

            mensagemContato.UsuarioBackOffice = serviceBackOffice.ConsultarPorId(id);

            return mensagemContato;
        }

        public void SalvarMensagemContato(MensagemContato mensagemContato)
        {
            if (!modelState.IsValid)
            {
                return;
            }

            mensagemContato.DataResposta = DateTime.Now;
            mensagemContato.MensagemRespondida = "S";
            mensagemContato.IdUsuarioBackOfficeResposta = ((UsuarioBackOffice)HttpContext.Current.Session["user"]).Id;

            ResultValidation retorno = serviceMensagem.Salvar(mensagemContato);

            PreencherModelState(retorno);
        }

        #endregion

    }
}