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
            var lista = context.ContratosEmpresasPrecificacoesProdutos.Where(u => u.IdContratoEmpresa == idContrato && u.CodigoProduto == codigoProduto).ToList();

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

        public void SalvarContratoEmpresaPrecificacaoProduto(List<ContratoEmpresaPrecificacaoProduto> precificacoes)
        {
            foreach (var item in precificacoes)
            {
                repoContratoEmpresaPrecificacaoProduto.Update(item);
            }

            context.SaveChanges();

        }

        public ResultValidation Excluir(int id)
        {
            ResultValidation returnValidation = new ResultValidation();

            List<string> produtos = context.ContratosEmpresasPrecificacoesProdutos.Where(u => u.IdContratoEmpresa == id).Select(u => u.CodigoProduto).Distinct().ToList();

            if (!returnValidation.Ok) return returnValidation;

            try
            {
                foreach (var produto in produtos)
                {
                    repoContratoEmpresaPrecificacaoProduto.Remove(id, produto);

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
