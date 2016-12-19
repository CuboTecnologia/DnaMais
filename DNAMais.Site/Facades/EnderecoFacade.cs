using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DNAMais.Domain.Entidades.Consultas;
using DNAMais.Domain.Services.Consultas;
using DNAMais.Site.Facades.Base;

namespace DNAMais.Site.Facades
{
    public class EnderecoFacade : BaseFacade, IDisposable
    {
        private InfoUfService serviceUF;
        private InfoMunicipioService serviceMunicipio;

        public EnderecoFacade(ModelStateDictionary modelState)
            : base(modelState)
        {
            serviceUF = new InfoUfService();
            serviceMunicipio = new InfoMunicipioService();
        }

        public void Dispose()
        {
            serviceUF.Dispose();
            serviceMunicipio.Dispose();
        }

        public List<InfoUf> ListarUFs()
        {
            return serviceUF.ListarTodos().ToList();
        }

        public List<InfoMunicipio> ListarMunicipiosPorUF(string uf)
        {
            return serviceMunicipio.ListarPorUf(uf).ToList();
        }
    }
}