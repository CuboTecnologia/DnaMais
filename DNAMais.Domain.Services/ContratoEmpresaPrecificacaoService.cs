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
    public class ContratoEmpresaPrecificacaoService
    {
        private DNAMaisSiteContext context;

        private Repository<ContratoEmpresaPrecificacao> repoContratoEmpresaPrecificacao;

        public ContratoEmpresaPrecificacaoService()
        {
            context = new DNAMaisSiteContext();
            repoContratoEmpresaPrecificacao = new Repository<ContratoEmpresaPrecificacao>(context);
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public IQueryable<ContratoEmpresaPrecificacao> ListarTodos()
        {
            return repoContratoEmpresaPrecificacao.GetAll();
        }

        public ContratoEmpresaPrecificacao ConsultarPorId(int id)
        {
            return repoContratoEmpresaPrecificacao.GetById(id);
        }

        public ContratoEmpresaPrecificacao RetornarPrimeiroContratoPrecificacao(int id)
        {
            return repoContratoEmpresaPrecificacao.FindFirst(c => c.IdContratoEmpresa == id);
        }

        public void SalvarContratoEmpresaPrecificacao(List<ContratoEmpresaPrecificacao> precificacoes)
        {
            foreach (var item in precificacoes)
            {
                repoContratoEmpresaPrecificacao.Update(item);
            }

            context.SaveChanges();

        }

        public ResultValidation Excluir(int id)
        {
            ResultValidation returnValidation = new ResultValidation();

            List<string> faixas = context.ContratosEmpresasPrecificacoes.Where(u => u.IdContratoEmpresa == id).Select(u => u.CodigoFaixa).Distinct().ToList();
            List<string> categorias = context.ContratosEmpresasPrecificacoes.Where(u => u.IdContratoEmpresa == id).Select(u => u.CodigoCategoriaConsulta).Distinct().ToList();

            if (!returnValidation.Ok) return returnValidation;

            try
            {
                foreach (var categoria in categorias)
                {
                    foreach (var faixa in faixas)
                    {
                        repoContratoEmpresaPrecificacao.Remove(id, categoria, faixa);

                        context.SaveChanges();
                    }
                }
            }
            catch (Exception err)
            {
                returnValidation.AddMessage("", err.Message);
            }

            return returnValidation;
        }
    }
}
