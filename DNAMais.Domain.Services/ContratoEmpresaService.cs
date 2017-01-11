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
    public class ContratoEmpresaService
    {
        private DNAMaisSiteContext context;

        private Repository<ContratoEmpresa> repoContratoEmpresa;
        private Repository<ContratoEmpresaProduto> repoContratoEmpresaProduto;
        private Repository<ContratoEmpresaPrecificacao> repoContratoEmpresaPrecificacao;
        private Repository<Produto> repoProduto;

        public ContratoEmpresaService()
        {
            context = new DNAMaisSiteContext();
            repoContratoEmpresa = new Repository<ContratoEmpresa>(context);
            repoContratoEmpresaProduto = new Repository<ContratoEmpresaProduto>(context);
            repoContratoEmpresaPrecificacao = new Repository<ContratoEmpresaPrecificacao>(context);
            repoProduto = new Repository<Produto>(context);
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public IQueryable<ContratoEmpresa> ListarTodos()
        {
            return repoContratoEmpresa.GetAll();
        }

        public ContratoEmpresa ConsultarPorId(int id)
        {
            return repoContratoEmpresa.GetById(id);
        }

        public ResultValidation Salvar(ContratoEmpresa contratoEmpresa)
        {
            ResultValidation returnValidation = new ResultValidation();

            if (!returnValidation.Ok) return returnValidation;

            try
            {
                if (contratoEmpresa.Id == null)
                {
                    if (contratoEmpresa.DataAquisicao >= contratoEmpresa.DataCadastro)
                    {
                        returnValidation.AddMessage("DataAquisicao", "A data de aquisição não pode ser superior à data atual.");
                    }
                    else if (contratoEmpresa.DiaCorte > contratoEmpresa.DiaFaturamento)
                    {
                        returnValidation.AddMessage("DiaCorte", "O dia de corte não pode ser superior ao dia de faturamento.");
                    }
                    else
                    {
                        contratoEmpresa.DataCadastro = DateTime.Now;

                        repoContratoEmpresa.Add(contratoEmpresa);

                        context.SaveChanges();
                    }
                }
                else
                {
                    repoContratoEmpresa.Update(contratoEmpresa);
                }
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
                repoContratoEmpresa.Remove(id);

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
