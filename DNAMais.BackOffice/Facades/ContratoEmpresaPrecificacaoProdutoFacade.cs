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
    public class ContratoEmpresaPrecificacaoProdutoFacade : BaseFacade, IDisposable
    {
        private ContratoEmpresaPrecificacaoProdutoService serviceContratoEmpresaPrecificacaoProduto;

        public ContratoEmpresaPrecificacaoProdutoFacade(ModelStateDictionary modelState)
            : base(modelState)
        {
            serviceContratoEmpresaPrecificacaoProduto = new ContratoEmpresaPrecificacaoProdutoService();
        }

        public void Dispose()
        {
            serviceContratoEmpresaPrecificacaoProduto.Dispose();
        }

        #region Contrato Empresa Precificacao

        public ContratoEmpresaPrecificacaoProduto ConsultarPorId(int id)
        {
            return serviceContratoEmpresaPrecificacaoProduto.ConsultarPorId(id);
        }

        public List<ContratoEmpresaPrecificacaoProduto> ListarFaixas(int idContrato, string codigoProduto)
        {
            return serviceContratoEmpresaPrecificacaoProduto.ListarTodos(idContrato, codigoProduto);
        }

        public ContratoEmpresaPrecificacaoProduto ListarContratoPorId(int id)
        {
            return serviceContratoEmpresaPrecificacaoProduto.ConsultarPorId(id);
        }

        public ContratoEmpresaPrecificacaoProduto RetornarPrimeiroContratoPrecificacao(int id)
        {
            return serviceContratoEmpresaPrecificacaoProduto.RetornarPrimeiroContratoPrecificacaoProduto(id);
        }

        public void SalvarContratoEmpresaPrecificacao(ContratoEmpresaPrecificacaoProduto precificacao)
        {
            ResultValidation retorno = serviceContratoEmpresaPrecificacaoProduto.Salvar(precificacao);

            PreencherModelState(retorno);
        }

        public void RemoverContratoEmpresaPrecificacao(int id)
        {
            ResultValidation retorno = serviceContratoEmpresaPrecificacaoProduto.Excluir(id);

            PreencherModelState(retorno);
        }

        //public void AlterarPrecificacao(ContratoEmpresaPrecificacao contratoPrecificacao)
        //{
        //    ResultValidation retorno = serviceContratoEmpresaPrecificacao.Salvar(contratoPrecificacao);

        //    PreencherModelState(retorno);
        //}

        public ContratoEmpresaPrecificacaoProduto popularPrecificacao(string idProduto, FormCollection form)
        {
            ContratoEmpresaPrecificacaoProduto objContratoPrecificacao = new ContratoEmpresaPrecificacaoProduto();

            objContratoPrecificacao.CodigoProduto = idProduto;
            objContratoPrecificacao.InicioFaixa = Convert.ToInt32(form["data[InicioFaixa]"]);
            objContratoPrecificacao.TerminoFaixa = Convert.ToInt32(form["data[TerminoFaixa]"]);

            return objContratoPrecificacao;
        }


        #endregion
    }
}