using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DNAMais.Domain.Entidades;
using DNAMais.Domain.Entidades.Consultas;
using DNAMais.Domain.Services.Consultas;
using DNAMais.Site.Facades.Base;
using DNAMais.Domain.Services;

namespace DNAMais.Site.Facades
{
    public class ContratoEmpresaFacade : BaseFacade, IDisposable
    {
        private ContratoEmpresaService service;

        public ContratoEmpresaFacade(ModelStateDictionary modelState)
            : base(modelState)
        {
            service = new ContratoEmpresaService();
        }

        public void Dispose()
        {
            service.Dispose();
        }

        public ContratoEmpresa ConsultarContratoPorProduto(
            int idClienteEmpresa,
            string cdProduto)
        {
            return service.ConsultarPorProduto(idClienteEmpresa, cdProduto);
        }

    }
}