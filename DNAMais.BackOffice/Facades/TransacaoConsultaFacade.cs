using DNAMais.BackOffice.Facades.Base;
using DNAMais.Domain.Services;
using DNAMais.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DNAMais.BackOffice.Facades
{
    public class TransacaoConsultaFacade : BaseFacade, IDisposable
    {
        private TransacaoConsultaService serviceTransacaoConsulta;

        public TransacaoConsultaFacade(ModelStateDictionary modelState)
            : base(modelState)
        {
            serviceTransacaoConsulta = new TransacaoConsultaService();
        }

        public void Dispose()
        {
            serviceTransacaoConsulta.Dispose();
        }

        public void RemoverConsultaTransacao(int id)
        {
            ResultValidation retorno = serviceTransacaoConsulta.Excluir(id);

            PreencherModelState(retorno);
        }
    }
}