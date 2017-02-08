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
    public class ContratoEmpresaPrecificacaoItemProdutoService
    {
        private DNAMaisSiteContext context;

        private Repository<ContratoEmpresaPrecificacaoItemProduto> repoContratoEmpresaPrecificacaoItemProduto;

        public ContratoEmpresaPrecificacaoItemProdutoService()
        {
            context = new DNAMaisSiteContext();
            repoContratoEmpresaPrecificacaoItemProduto = new Repository<ContratoEmpresaPrecificacaoItemProduto>(context);
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public IQueryable<ContratoEmpresaPrecificacaoItemProduto> ListarTodos()
        {
            return repoContratoEmpresaPrecificacaoItemProduto.GetAll();
        }

        public ContratoEmpresaPrecificacaoItemProduto ConsultarPorId(int id)
        {
            return repoContratoEmpresaPrecificacaoItemProduto.GetById(id);
        }

        public ContratoEmpresaPrecificacaoItemProduto RetornarPrimeiroContratoPrecificacaoItemProduto(int id)
        {
            return repoContratoEmpresaPrecificacaoItemProduto.FindFirst(c => c.IdContratoEmpresa == id);
        }

        public void SalvarContratoEmpresaPrecificacaoItemProduto(List<ContratoEmpresaPrecificacaoItemProduto> precificacoes)
        {
            foreach (var item in precificacoes)
            {
                repoContratoEmpresaPrecificacaoItemProduto.Update(item);
            }

            context.SaveChanges();

        }

        public ResultValidation Excluir(int id)
        {
            ResultValidation returnValidation = new ResultValidation();

            List<string> itens = context.ContratosEmpresasPrecificacoesItensProduto.Where(u => u.IdContratoEmpresa == id).Select(u => u.CodigoItemProduto).Distinct().ToList();

            if (!returnValidation.Ok) return returnValidation;

            try
            {
                foreach (var item in itens)
                {
                    repoContratoEmpresaPrecificacaoItemProduto.Remove(id, item);

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
