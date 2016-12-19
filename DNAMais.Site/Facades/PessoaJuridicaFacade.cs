using System;
using System.Collections.Generic;
using System.Web.Mvc;
using DNAMais.Domain.Entidades;
using DNAMais.Domain.Entidades.Consultas;
using DNAMais.Domain.Services.Consultas;
using DNAMais.Site.Facades.Base;

namespace DNAMais.Site.Facades
{
    public class PessoaJuridicaFacade : BaseFacade, IDisposable
    {
        private InfoPessoaJuridicaService service;

        public PessoaJuridicaFacade(ModelStateDictionary modelState)
            : base(modelState)
        {
            service = new InfoPessoaJuridicaService();
        }

        public void Dispose()
        {
            service.Dispose();
        }

        public InfoPessoaJuridica ConsultarPessoaJuridicaPorCNPJ(
            string cnpj,
            int idClienteEmpresa,
            int idContratoEmpresa,
            int idUsuarioCliente,
            out TransacaoConsulta transacao)
        {
            return service.ConsultarPorCNPJ(cnpj, idClienteEmpresa, idContratoEmpresa, idUsuarioCliente, out transacao);
        }

        public List<InfoPessoaJuridica> ConsultarPessoaJuridicaPorCEP(
            string cep,
            int idClienteEmpresa,
            int idContratoEmpresa,
            int idUsuarioCliente,
            out TransacaoConsulta transacao)
        {
            return service.ConsultarPorCEP(cep, idClienteEmpresa, idContratoEmpresa, idUsuarioCliente, out transacao);
        }

        public List<InfoPessoaJuridica> ConsultarPessoaJuridicaPorEndereco(
            string uf,
            string municipio,
            string bairro,
            string logradouro,
            string numero,
            string complemento,
            int idClienteEmpresa,
            int idContratoEmpresa,
            int idUsuarioCliente,
            out TransacaoConsulta transacao)
        {
            return service.ConsultarPorEndereco(uf, municipio, bairro, logradouro, numero, complemento, idClienteEmpresa, idContratoEmpresa, idUsuarioCliente, out transacao);
        }

        public List<InfoPessoaJuridica> ConsultarPessoaJuridicaPorNome(
            string nome,
            int idClienteEmpresa,
            int idContratoEmpresa,
            int idUsuarioCliente,
            out TransacaoConsulta transacao)
        {
            return service.ConsultarPorNome(nome, idClienteEmpresa, idContratoEmpresa, idUsuarioCliente, out transacao);
        }

        public List<InfoPessoaJuridica> ConsultarPessoaJuridicaPorTelefone(
            byte? numeroDdd,
            string numeroTelefone,
            int idClienteEmpresa,
            int idContratoEmpresa,
            int idUsuarioCliente,
            out TransacaoConsulta transacao)
        {
            return service.ConsultarPorTelefone(numeroDdd, numeroTelefone, idClienteEmpresa, idContratoEmpresa, idUsuarioCliente, out transacao);
        }
    }
}