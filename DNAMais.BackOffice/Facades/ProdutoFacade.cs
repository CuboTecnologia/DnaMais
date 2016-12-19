using DNAMais.BackOffice.Facades.Base;
using DNAMais.Domain;
using DNAMais.Domain.Entidades;
using DNAMais.Domain.Services;
using DNAMais.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DNAMais.BackOffice.Facades
{
    public class ProdutoFacade : BaseFacade, IDisposable
    {
        private CategoriaProdutoService serviceCategoriaProduto;
        private ProdutoService serviceProduto;
        private ItemProdutoService serviceItemProduto;

        public ProdutoFacade(ModelStateDictionary modelState)
            : base(modelState)
        {
            serviceCategoriaProduto = new CategoriaProdutoService();
            serviceProduto = new ProdutoService();
            serviceItemProduto = new ItemProdutoService();
        }

        public void Dispose()
        {
            serviceCategoriaProduto.Dispose();
            serviceProduto.Dispose();
            serviceItemProduto.Dispose();
        }

        #region Categoria Produto

        public IQueryable<CategoriaProduto> ListarCategoriasProduto()
        {
            return serviceCategoriaProduto.ListarTodos();
        }

        public CategoriaProduto ConsultarCategoriaProdutoPorId(string id)
        {
            return serviceCategoriaProduto.ConsultarPorId(id);
        }

        #endregion

        #region Produto

        public IQueryable<Produto> ListarProdutos()
        {
            return serviceProduto.ListarTodos();
        }

        public Produto ConsultarProdutoPorId(string id)
        {
            Produto produtos = serviceProduto.ConsultarPorId(id);
            produtos.CategoriaProduto = serviceCategoriaProduto.ConsultarPorId(id);

            return produtos;
        }

        public void AlterarProduto(Produto produto)
        {
            if (!modelState.IsValid)
            {
                return;
            }

            ResultValidation retorno = serviceProduto.Alterar(produto);

            PreencherModelState(retorno);
        }

        public void SalvarProduto(Produto produto)
        {
            if (!modelState.IsValid)
            {
                return;
            }

            ResultValidation retorno = serviceProduto.Salvar(produto);

            PreencherModelState(retorno);
        }

        #endregion

        #region Item Produto

        public IQueryable<ItemProduto> ListarItensProduto()
        {
            return serviceItemProduto.ListarTodos();
        }

        public ItemProduto ConsultarItemProdutoPorId(string id)
        {
            return serviceItemProduto.ConsultarPorId(id);
        }

        public void AlterarItemProduto(ItemProduto itemProduto)
        {
            if (!modelState.IsValid)
            {
                return;
            }

            ResultValidation retorno = serviceItemProduto.Alterar(itemProduto);

            PreencherModelState(retorno);
        }

        #endregion
    }
}