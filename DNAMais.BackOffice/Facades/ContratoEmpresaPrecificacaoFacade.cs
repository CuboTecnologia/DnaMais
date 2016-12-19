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
    public class ContratoEmpresaPrecificacaoFacade : BaseFacade, IDisposable
    {
        private ContratoEmpresaPrecificacaoService serviceContratoEmpresaPrecificacao;

        public ContratoEmpresaPrecificacaoFacade(ModelStateDictionary modelState)
            : base(modelState)
        {
            serviceContratoEmpresaPrecificacao = new ContratoEmpresaPrecificacaoService();
        }

        public void Dispose()
        {
            serviceContratoEmpresaPrecificacao.Dispose();
        }

        #region Contrato Empresa Precificacao

        public IQueryable<ContratoEmpresaPrecificacao> ListarContratos()
        {
            return serviceContratoEmpresaPrecificacao.ListarTodos();
        }

        public ContratoEmpresaPrecificacao ListarContratoPorId(int id)
        {
            return serviceContratoEmpresaPrecificacao.ConsultarPorId(id);
        }

        public ContratoEmpresaPrecificacao RetornarPrimeiroContratoPrecificacao(int id)
        {
            return serviceContratoEmpresaPrecificacao.RetornarPrimeiroContratoPrecificacao(id);
        }

        public void SalvarContratoEmpresaPrecificacao(List<ContratoEmpresaPrecificacao> precificacoes)
        {
            serviceContratoEmpresaPrecificacao.SalvarContratoEmpresaPrecificacao(precificacoes);
        }

        public void RemoverContratoEmpresaPrecificacao(int id)
        {
            ResultValidation retorno = serviceContratoEmpresaPrecificacao.Excluir(id);

            PreencherModelState(retorno);
        }

        //public void AlterarPrecificacao(ContratoEmpresaPrecificacao contratoPrecificacao)
        //{
        //    ResultValidation retorno = serviceContratoEmpresaPrecificacao.Salvar(contratoPrecificacao);

        //    PreencherModelState(retorno);
        //}

        public ContratoEmpresaPrecificacao popularPrecificacao(string idCategoria, string codigoFaixa, FormCollection form)
        {
            ContratoEmpresaPrecificacao objContratoPrecificacao = new ContratoEmpresaPrecificacao();

            objContratoPrecificacao.CodigoCategoriaConsulta = idCategoria;
            objContratoPrecificacao.CodigoFaixa = codigoFaixa;
            objContratoPrecificacao.DescricaoFaixa = form["data[Descricao]"];
            objContratoPrecificacao.InicioFaixa = Convert.ToInt32(form["data[InicioFaixa]"]);
            objContratoPrecificacao.TerminoFaixa = Convert.ToInt32(form["data[TerminoFaixa]"]);

            return objContratoPrecificacao;
        }


        #endregion
    }
}