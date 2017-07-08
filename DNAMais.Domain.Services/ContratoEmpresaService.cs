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
        //CCB private Repository<ContratoEmpresaPrecificacao> repoContratoEmpresaPrecificacao;
        private Repository<ContratoEmpresaPrecificacaoProduto> repoContratoEmpresaPrecificacaoProduto;
        private Repository<ContratoEmpresaPrecificacaoItemProduto> repoContratoEmpresaPrecificacaoItemProduto;
        private Repository<Produto> repoProduto;

        public ContratoEmpresaService()
        {
            context = new DNAMaisSiteContext();
            repoContratoEmpresa = new Repository<ContratoEmpresa>(context);
            repoContratoEmpresaProduto = new Repository<ContratoEmpresaProduto>(context);
            //CCB repoContratoEmpresaPrecificacao = new Repository<ContratoEmpresaPrecificacao>(context);
            repoContratoEmpresaPrecificacaoProduto = new Repository<ContratoEmpresaPrecificacaoProduto>(context);
            repoContratoEmpresaPrecificacaoItemProduto = new Repository<ContratoEmpresaPrecificacaoItemProduto>(context);
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

        public ContratoEmpresa ConsultarPorProduto(
            int idClienteEmpresa,
            string cdProduto)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT ");
            sql.Append(" CE.ID_CONTRATO_EMPRESA AS Id, ");
            sql.Append(" CE.ID_CLIENTE_EMPRESA  AS IdClienteEmpresa, ");
            sql.Append(" CE.DT_AQUISICAO        AS DataAquisicao, ");
            sql.Append(" CE.IS_VIGENTE          AS VigenteDescricao, ");
            sql.Append(" CE.DD_CORTE            AS DiaCorte, ");
            sql.Append(" CE.DD_FATURAMENTO      AS DiaFaturamento, ");
            sql.Append(" CE.DT_CADASTRO         AS DataCadastro, ");
            sql.Append(" CE.ID_USUARIO_CADASTRO AS IdUsuarioCadastro ");
            sql.Append(" FROM  ");
            sql.Append("      DNASITE.CONTRATO_EMPRESA CE, ");
            sql.Append("      DNASITE.CONTRATO_EMPRESA_PRODUTO CEP ");
            sql.Append(" WHERE ");
            sql.Append("      CE.ID_CONTRATO_EMPRESA = CEP.ID_CONTRATO_EMPRESA ");
            sql.Append("      AND CE.ID_CLIENTE_EMPRESA = " + idClienteEmpresa);
            sql.Append("      AND CEP.CD_PRODUTO = '" + cdProduto + "'");

            ContratoEmpresa contratoEmpresa = context.ContratosEmpresa.SqlQuery(sql.ToString()).FirstOrDefault();

            return contratoEmpresa;
        }

    }
}
