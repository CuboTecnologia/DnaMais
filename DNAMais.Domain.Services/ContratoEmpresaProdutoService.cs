using DNAMais.Domain.Entidades;
using DNAMais.Framework;
using DNAMais.Infrastructure.Data.Contexts;
using DNAMais.Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNAMais.Domain.Services
{
    public class ContratoEmpresaProdutoService
    {
        private DNAMaisSiteContext context;

        private Repository<ContratoEmpresaProduto> repoContratoEmpresaProduto;
        private Repository<ContratoEmpresaPrecificacao> repoContratoEmpresaPrecificacao;
        private Repository<ContratoEmpresa> repoContratoEmpresa;
        private Repository<Produto> repoProduto;

        public ContratoEmpresaProdutoService()
        {
            context = new DNAMaisSiteContext();
            repoContratoEmpresaProduto = new Repository<ContratoEmpresaProduto>(context);
            repoContratoEmpresaPrecificacao = new Repository<ContratoEmpresaPrecificacao>(context);
            repoContratoEmpresa = new Repository<ContratoEmpresa>(context);
            repoProduto = new Repository<Produto>(context);
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public IQueryable<ContratoEmpresaProduto> ListarTodos()
        {
            return repoContratoEmpresaProduto.GetAll();
        }

        public ContratoEmpresaProduto ConsultarPorId(int id)
        {
            return repoContratoEmpresaProduto.GetById(id);
        }

        public ContratoEmpresaProduto RetornarPrimeiroContratoProduto(int id)
        {
            return repoContratoEmpresaProduto.FindFirst(c => c.IdContratoEmpresa == id);
        }

        public void SalvarContratoEmpresaProduto(int idContrato, List<string> produtosSelecionados)
        {
            List<ContratoEmpresaPrecificacao> precificacoes = new List<ContratoEmpresaPrecificacao>();

            foreach (var item in produtosSelecionados)
            {
                Produto produto = repoProduto.GetById(item);

                if (!precificacoes.Exists(i => i.CodigoCategoriaConsulta == produto.CodigoCategoria))
                {
                    foreach (CategoriaProdutoFaixa faixa in produto.CategoriaProduto.CategoriasFaixas)
                    {
                        precificacoes.Add(new ContratoEmpresaPrecificacao
                        {
                            IdContratoEmpresa = idContrato,
                            CodigoCategoriaConsulta = produto.CodigoCategoria,
                            CodigoFaixa = faixa.CodigoFaixa,
                            DescricaoFaixa = faixa.DescricaoFaixa,
                            InicioFaixa = faixa.InicioFaixa,
                            TerminoFaixa = faixa.TerminoFaixa,
                            ValorConsulta = 0
                        });
                    }
                }
            }

            ContratoEmpresa contratoEmpresa = repoContratoEmpresa.GetById(idContrato);

            contratoEmpresa.ContratosEmpresasProdutos.Clear();

            foreach (var item in produtosSelecionados)
            {
                ContratoEmpresaProduto contratoEmpresaProduto = new ContratoEmpresaProduto();

                contratoEmpresaProduto.IdContratoEmpresa = idContrato;
                contratoEmpresaProduto.CodigoProduto = item;


                repoContratoEmpresaProduto.Add(contratoEmpresaProduto);
            }

            contratoEmpresa.ContratosEmpresasPrecificacoes.Clear();

            foreach (var item in precificacoes)
            {
                repoContratoEmpresaPrecificacao.Add(item);
            }

            context.SaveChanges();

        }

        public ResultValidation Excluir(int id)
        {
            ResultValidation returnValidation = new ResultValidation();

            List<string> codigos = context.ContratosEmpresasProdutos.Where(u => u.IdContratoEmpresa == id).Select(u => u.CodigoProduto).Distinct().ToList();

            if (!returnValidation.Ok) return returnValidation;

            try
            {
                foreach (var codigo in codigos)
                {
                    repoContratoEmpresaProduto.Remove(id, codigo);

                    context.SaveChanges();
                }

            }
            catch (Exception err)
            {
                returnValidation.AddMessage("", err);
            }

            return returnValidation;
        }
    }
}
