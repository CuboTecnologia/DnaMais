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
    public class ContratoEmpresaPrecificacaoItemProdutoFacade : BaseFacade, IDisposable
    {
        private ContratoEmpresaPrecificacaoItemProdutoService serviceContratoEmpresaPrecificacaoItemProduto;

        public ContratoEmpresaPrecificacaoItemProdutoFacade(ModelStateDictionary modelState)
            : base(modelState)
        {
            serviceContratoEmpresaPrecificacaoItemProduto = new ContratoEmpresaPrecificacaoItemProdutoService();
        }

        public void Dispose()
        {
            serviceContratoEmpresaPrecificacaoItemProduto.Dispose();
        }

        #region Contrato Empresa Precificacao

        public IQueryable<ContratoEmpresaPrecificacaoItemProduto> ListarContratos()
        {
            return serviceContratoEmpresaPrecificacaoItemProduto.ListarTodos();
        }

        public ContratoEmpresaPrecificacaoItemProduto ListarContratoPorId(int id)
        {
            return serviceContratoEmpresaPrecificacaoItemProduto.ConsultarPorId(id);
        }

        public ContratoEmpresaPrecificacaoItemProduto RetornarPrimeiroContratoPrecificacao(int id)
        {
            return serviceContratoEmpresaPrecificacaoItemProduto.RetornarPrimeiroContratoPrecificacaoItemProduto(id);
        }

        public void SalvarContratoEmpresaPrecificacao(List<ContratoEmpresaPrecificacaoItemProduto> precificacoes)
        {
            serviceContratoEmpresaPrecificacaoItemProduto.SalvarContratoEmpresaPrecificacaoItemProduto(precificacoes);
        }

        public void RemoverContratoEmpresaPrecificacao(int id)
        {
            ResultValidation retorno = serviceContratoEmpresaPrecificacaoItemProduto.Excluir(id);

            PreencherModelState(retorno);
        }

        //public void AlterarPrecificacao(ContratoEmpresaPrecificacao contratoPrecificacao)
        //{
        //    ResultValidation retorno = serviceContratoEmpresaPrecificacao.Salvar(contratoPrecificacao);

        //    PreencherModelState(retorno);
        //}

        public ContratoEmpresaPrecificacaoItemProduto popularPrecificacao(string idItemProduto, FormCollection form)
        {
            ContratoEmpresaPrecificacaoItemProduto objContratoPrecificacao = new ContratoEmpresaPrecificacaoItemProduto();

            objContratoPrecificacao.CodigoItemProduto = idItemProduto;
            objContratoPrecificacao.InicioFaixa = Convert.ToInt32(form["data[InicioFaixa]"]);
            objContratoPrecificacao.TerminoFaixa = Convert.ToInt32(form["data[TerminoFaixa]"]);

            return objContratoPrecificacao;
        }


        #endregion
    }
}