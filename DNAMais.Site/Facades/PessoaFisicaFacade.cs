using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DNAMais.Domain.Entidades;
using DNAMais.Domain.Entidades.Consultas;
using DNAMais.Domain.Services.Consultas;
using DNAMais.Site.Facades.Base;

namespace DNAMais.Site.Facades
{
    public class PessoaFisicaFacade : BaseFacade, IDisposable
    {
        private InfoPessoaFisicaService service;

        public PessoaFisicaFacade(ModelStateDictionary modelState)
            : base(modelState)
        {
            service = new InfoPessoaFisicaService();
        }

        public void Dispose()
        {
            service.Dispose();
        }

        public InfoPessoaFisica ConsultarPessoaFisicaPorCPF(
            string cpf,
            int idClienteEmpresa,
            int idContratoEmpresa,
            int idUsuarioCliente,
            out TransacaoConsulta transacao)
        {
            return service.ConsultarPorCPF(cpf, idClienteEmpresa, idContratoEmpresa, idUsuarioCliente, out transacao);
        }

        public List<InfoPessoaFisica> ConsultarPessoaFisicaPorCEP(
            string cep,
            int idClienteEmpresa,
            int idContratoEmpresa,
            int idUsuarioCliente,
            out TransacaoConsulta transacao)
        {
            return service.ConsultarPorCEP(cep, idClienteEmpresa, idContratoEmpresa, idUsuarioCliente, out transacao);
        }

        public List<InfoPessoaFisica> ConsultarPessoaFisicaPorCepNumero(
            string cep,
            string numero,
            int idClienteEmpresa,
            int idContratoEmpresa,
            int idUsuarioCliente,
            out TransacaoConsulta transacao)
        {
            return service.ConsultarPorCepNumero(cep, numero, idClienteEmpresa, idContratoEmpresa, idUsuarioCliente, out transacao);
        }

        public List<InfoPessoaFisica> ConsultarPessoaFisicaPorEndereco(
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

        public List<InfoPessoaFisica> ConsultarPessoaFisicaPorNome(
            string nome,
            int idClienteEmpresa,
            int idContratoEmpresa,
            int idUsuarioCliente,
            out TransacaoConsulta transacao)
        {
            return service.ConsultarPorNome(nome, idClienteEmpresa, idContratoEmpresa, idUsuarioCliente, out transacao);
        }

        public List<InfoPessoaFisica> ConsultarPessoaFisicaPorTelefone(
            byte? numeroDdd,
            string numeroTelefone,
            int idClienteEmpresa,
            int idContratoEmpresa,
            int idUsuarioCliente,
            out TransacaoConsulta transacao)
        {
            return service.ConsultarPorTelefone(numeroDdd, numeroTelefone, idClienteEmpresa, idContratoEmpresa, idUsuarioCliente, out transacao);
        }

        public List<InfoPessoaFisicaQsa> ConsultarPessoaFisicaQSA(string cpf)
        {
            return service.ConsultarQSA(cpf);
        }
    }
}