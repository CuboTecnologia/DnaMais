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
    public class ContratoEmpresaProdutoFacade : BaseFacade, IDisposable
    {
        private ContratoEmpresaProdutoService serviceContratoEmpresaProduto;

        public ContratoEmpresaProdutoFacade(ModelStateDictionary modelState)
            : base(modelState)
        {
            serviceContratoEmpresaProduto = new ContratoEmpresaProdutoService();
        }

        public void Dispose()
        {
            serviceContratoEmpresaProduto.Dispose();
        }

        #region Contrato Empresa Produto

        public IQueryable<ContratoEmpresaProduto> ListarProdutosContrato()
        {
            return serviceContratoEmpresaProduto.ListarTodos();
        }

        public ContratoEmpresaProduto ListarProdutoContratoPorId(int id)
        {
            return serviceContratoEmpresaProduto.ConsultarPorId(id);
        }

        public ContratoEmpresaProduto RetornarPrimeiroContratoProduto(int id)
        {
            return serviceContratoEmpresaProduto.RetornarPrimeiroContratoProduto(id);
        }

        public void SalvarContratoEmpresaProduto(int idContrato, List<string> produtosSelecionados)
        {
            serviceContratoEmpresaProduto.SalvarContratoEmpresaProduto(idContrato, produtosSelecionados);
        }


        public void RemoverContratoEmpresaProduto(int id)
        {
            ResultValidation retorno = serviceContratoEmpresaProduto.Excluir(id);

            PreencherModelState(retorno);
        }


        #endregion
    }
}