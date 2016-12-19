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
    public class ContratoEmpresaFacade : BaseFacade, IDisposable
    {
        private ContratoEmpresaService serviceContratoEmpresa;
        private ClienteEmpresaService serviceClienteEmpresa;
        private ContratoEmpresaProdutoService serviceContratoEmpresaProduto;
        private ContratoEmpresaPrecificacaoService serviceContratoEmpresaPrecificacao;

        public ContratoEmpresaFacade(ModelStateDictionary modelState)
            : base(modelState)
        {
            serviceContratoEmpresa = new ContratoEmpresaService();
            serviceClienteEmpresa = new ClienteEmpresaService();
            serviceContratoEmpresaProduto = new ContratoEmpresaProdutoService();
            serviceContratoEmpresaPrecificacao = new ContratoEmpresaPrecificacaoService();
        }

        public void Dispose()
        {
            serviceContratoEmpresa.Dispose();
            serviceClienteEmpresa.Dispose();
            serviceContratoEmpresaProduto.Dispose();
            serviceContratoEmpresaPrecificacao.Dispose();
        }

        #region Contrato Empresa

        public IQueryable<ContratoEmpresa> ListarContratos()
        {
            return serviceContratoEmpresa.ListarTodos();
        }

        public ContratoEmpresa ListarContratoPorId(int id)
        {
            return serviceContratoEmpresa.ConsultarPorId(id);
        }

        public void SalvarContratoEmpresa(ContratoEmpresa contratoEmpresa)
        {
            if (!modelState.IsValid)
            {
                return;
            }

            contratoEmpresa.DataCadastro = DateTime.Now;
            contratoEmpresa.IdUsuarioCadastro = ((UsuarioBackOffice)HttpContext.Current.Session["user"]).Id;

            if (contratoEmpresa.Id == null)
            {
                contratoEmpresa.Vigente = true;
            }

            ResultValidation retorno = serviceContratoEmpresa.Salvar(contratoEmpresa);

            PreencherModelState(retorno);
        }

        public void RemoverContratoEmpresa(int id)
        {
            ResultValidation retorno = serviceContratoEmpresa.Excluir(id);

            PreencherModelState(retorno);
        }

        #endregion

        #region Cliente Empresa

        public IQueryable<ClienteEmpresa> ListarEmpresas()
        {
            return serviceClienteEmpresa.ListarTodos();
        }

        #endregion
    }
}