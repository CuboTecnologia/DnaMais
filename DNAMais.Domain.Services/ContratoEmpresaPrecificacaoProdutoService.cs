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
    public class ContratoEmpresaPrecificacaoProdutoService
    {
        private DNAMaisSiteContext context;

        private Repository<ContratoEmpresaPrecificacaoProduto> repoContratoEmpresaPrecificacaoProduto;

        public ContratoEmpresaPrecificacaoProdutoService()
        {
            context = new DNAMaisSiteContext();
            repoContratoEmpresaPrecificacaoProduto = new Repository<ContratoEmpresaPrecificacaoProduto>(context);
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public List<ContratoEmpresaPrecificacaoProduto> ListarTodos(int idContrato, string codigoProduto)
        {
            var lista = context.ContratosEmpresasPrecificacoesProdutos.Where(u => u.IdContratoEmpresa == idContrato && u.CodigoProduto == codigoProduto).OrderBy(u => u.InicioFaixa).ToList();

            return lista;
        }

        public ContratoEmpresaPrecificacaoProduto ConsultarPorId(int id)
        {
            return repoContratoEmpresaPrecificacaoProduto.GetById(id);
        }

        public ContratoEmpresaPrecificacaoProduto RetornarPrimeiroContratoPrecificacaoProduto(int id)
        {
            return repoContratoEmpresaPrecificacaoProduto.FindFirst(c => c.IdContratoEmpresa == id);
        }

        public ResultValidation VerificaSobreposicaoFaixas(int? id, int inicio, int? termino)
        {
            ResultValidation returnValidation = new ResultValidation();

            if (!returnValidation.Ok) return returnValidation;

            try
            {
                if (id != null)
                {
                    var lista = context.ContratosEmpresasPrecificacoesProdutos.Where(u => (u.TerminoFaixa > inicio || u.InicioFaixa < termino) && u.Id != id).ToList();

                    if (lista.Count() > 0)
                    {
                        returnValidation.AddMessage("", "Existe sobreposição de faixas, não será possível efetuar a alteração");
                    }
                }
                else
                {
                    var lista = context.ContratosEmpresasPrecificacoesProdutos.Where(u => u.TerminoFaixa > inicio && u.InicioFaixa < termino).ToList();

                    if (lista.Count() > 0)
                    {
                        returnValidation.AddMessage("", "Existe sobreposição de faixas, não será possível efetuar a inclusão");
                    }
                }
            }
            catch (Exception err)
            {
                returnValidation.AddMessage("", err);
            }

            return returnValidation;
        }

        public ResultValidation Salvar(ContratoEmpresaPrecificacaoProduto precificacao)
        {
            ResultValidation returnValidation = new ResultValidation();

            if (!returnValidation.Ok) return returnValidation;

            returnValidation = this.VerificaSobreposicaoFaixas(precificacao.Id, precificacao.InicioFaixa, precificacao.TerminoFaixa);
            if (!returnValidation.Ok) return returnValidation;

            try
            {
                if (precificacao.Id == null)
                {
                    repoContratoEmpresaPrecificacaoProduto.Add(precificacao);
                }
                else
                {
                    repoContratoEmpresaPrecificacaoProduto.Update(precificacao);
                }

                context.SaveChanges();
            }
            catch (Exception err)
            {
                returnValidation.AddMessage("", err);
            }

            return returnValidation;
        }

        public ResultValidation Excluir(int id)
        {
            ResultValidation returnValidation = new ResultValidation();

            if (!returnValidation.Ok) return returnValidation;

            try
            {
                repoContratoEmpresaPrecificacaoProduto.Remove(id);
                context.SaveChanges();
            }
            catch (Exception err)
            {
                returnValidation.AddMessage("", err);
            }

            return returnValidation;
        }
    }
}
