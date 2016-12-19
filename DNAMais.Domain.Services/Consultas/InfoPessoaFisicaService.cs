using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DNAMais.Domain.Entidades;
using DNAMais.Domain.Entidades.Consultas;
using DNAMais.Framework;
using DNAMais.Infrastructure.Data.Contexts;
using DNAMais.Infrastructure.Data.Repositories;

namespace DNAMais.Domain.Services.Consultas
{
    public class InfoPessoaFisicaService
    {
        private DNAMaisSiteContext context;

        private Repository<InfoPessoaFisica> repoPF;
        private Repository<TransacaoConsulta> repoTransacao;

        public InfoPessoaFisicaService()
        {
            context = new DNAMaisSiteContext();
            repoPF = new Repository<InfoPessoaFisica>(context);
            repoTransacao = new Repository<TransacaoConsulta>(context);
        }

        public void Dispose()
        {
            context.Dispose();
        }

        private TransacaoConsulta GerarTransacao(
            int idClienteEmpresa,
            int idContratoEmpresa,
            int idUsuarioCliente,
            string itemProduto)
        {

            TransacaoConsulta transacao = new TransacaoConsulta();

            transacao.IdClienteEmpresa = idClienteEmpresa;
            transacao.IdContratoEmpresa = idContratoEmpresa;
            transacao.IdUsuarioCliente = idUsuarioCliente;
            transacao.CodigoItemProduto = itemProduto;
            transacao.DadosEncontrados = true;
            transacao.DataTransacao = DateTime.Now;
            transacao.Faturada = false;

            return transacao;
        }

        public InfoPessoaFisica ConsultarPorCPF(
            string cpf,
            int idClienteEmpresa,
            int idContratoEmpresa,
            int idUsuarioCliente,
            out TransacaoConsulta transacao)
        {
            cpf = cpf.LimparCaracteresCPF();

            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT ");
            sql.Append("ID_PESSOA_FISICA         AS Id, ");
            sql.Append("NR_CPF                   AS Cpf, ");
            sql.Append("NM_COMPLETO              AS NomeCompleto, ");
            sql.Append("NM_MAE                   AS NomeMae, ");
            sql.Append("DT_NASCIMENTO            AS DataNascimento, ");
            sql.Append("NR_IDADE                 AS Idade, ");
            sql.Append("SG_SEXO                  AS Sexo, ");
            sql.Append("CD_SITUACAO_CADASTRAL_PF AS CodigoSituacaoCadastral, ");
            sql.Append("ID_ORIGEM_DADOS          AS IdOrigemDados, ");
            sql.Append("DT_INCLUSAO              AS DataInclusao, ");
            sql.Append("DT_ULTIMA_ATUALIZACAO    AS DataUltimaAtualizacao ");
            sql.Append("FROM DNAINFO.PESSOA_FISICA ");
            sql.Append("WHERE NR_CPF = '" + cpf.PadLeft(11, '0') + "'");

            InfoPessoaFisica pessoa = context.PessoasFisicas.SqlQuery(sql.ToString()).FirstOrDefault();

            transacao = GerarTransacao(idClienteEmpresa, idContratoEmpresa, idUsuarioCliente, "CST-WEB-PF-CPF");
            if (pessoa != null)
            {
                repoTransacao.Add(transacao);
                context.SaveChanges();
            }

            return pessoa;
        }

        public List<InfoPessoaFisica> ConsultarPorCEP(
            string cep,
            int idClienteEmpresa,
            int idContratoEmpresa,
            int idUsuarioCliente,
            out TransacaoConsulta transacao)
        {
            cep = cep.LimparCaracteresCEP();

            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT ");
            sql.Append("PF.ID_PESSOA_FISICA         AS Id, ");
            sql.Append("PF.NR_CPF                   AS Cpf, ");
            sql.Append("PF.NM_COMPLETO              AS NomeCompleto, ");
            sql.Append("PF.NM_MAE                   AS NomeMae, ");
            sql.Append("PF.DT_NASCIMENTO            AS DataNascimento, ");
            sql.Append("PF.NR_IDADE                 AS Idade, ");
            sql.Append("PF.SG_SEXO                  AS Sexo, ");
            sql.Append("PF.CD_SITUACAO_CADASTRAL_PF AS CodigoSituacaoCadastral, ");
            sql.Append("PF.ID_ORIGEM_DADOS          AS IdOrigemDados, ");
            sql.Append("PF.DT_INCLUSAO              AS DataInclusao, ");
            sql.Append("PF.DT_ULTIMA_ATUALIZACAO    AS DataUltimaAtualizacao ");
            sql.Append("FROM DNAINFO.PESSOA_FISICA PF ");
            sql.Append("INNER JOIN DNAINFO.PESSOA_FISICA_ENDERECO PF_END ");
            sql.Append("ON PF_END.ID_PESSOA_FISICA = PF.ID_PESSOA_FISICA ");
            sql.Append("WHERE PF_END.NR_CEP = '" + cep + "'");

            List<InfoPessoaFisica> pessoas = context.PessoasFisicas.SqlQuery(sql.ToString()).ToList();

            transacao = GerarTransacao(idClienteEmpresa, idContratoEmpresa, idUsuarioCliente, "CST-WEB-PF-END");
            if (pessoas != null)
            {
                repoTransacao.Add(transacao);
                context.SaveChanges();
            }

            return pessoas;
        }

        public List<InfoPessoaFisica> ConsultarPorEndereco(
            string uf,
            string municipio,
            string bairro,
            string logradouro,
            string numero,
            string complemento,
            int idClienteEmpresa,
            int idContratoEmpresa,
            int idUsuarioCliente,
            out TransacaoConsulta transacao)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT ");
            sql.Append("PF.ID_PESSOA_FISICA         AS Id, ");
            sql.Append("PF.NR_CPF                   AS Cpf, ");
            sql.Append("PF.NM_COMPLETO              AS NomeCompleto, ");
            sql.Append("PF.NM_MAE                   AS NomeMae, ");
            sql.Append("PF.DT_NASCIMENTO            AS DataNascimento, ");
            sql.Append("PF.NR_IDADE                 AS Idade, ");
            sql.Append("PF.SG_SEXO                  AS Sexo, ");
            sql.Append("PF.CD_SITUACAO_CADASTRAL_PF AS CodigoSituacaoCadastral, ");
            sql.Append("PF.ID_ORIGEM_DADOS          AS IdOrigemDados, ");
            sql.Append("PF.DT_INCLUSAO              AS DataInclusao, ");
            sql.Append("PF.DT_ULTIMA_ATUALIZACAO    AS DataUltimaAtualizacao ");
            sql.Append("FROM DNAINFO.PESSOA_FISICA PF ");
            sql.Append("INNER JOIN DNAINFO.PESSOA_FISICA_ENDERECO PF_END ");
            sql.Append("ON PF_END.ID_PESSOA_FISICA = PF.ID_PESSOA_FISICA ");
            sql.Append("WHERE PF_END.SG_UF = '" + uf + "' ");
            sql.Append("AND PF_END.NM_CIDADE = '" + municipio.ToUpper().Trim() + "' ");
            sql.Append("AND PF_END.NM_BAIRRO LIKE '" + bairro.ToUpper().Trim() + "%' ");
            sql.Append("AND PF_END.DS_LOGRADOURO LIKE '" + logradouro.ToUpper().Trim() + "%' ");

            if (numero != null)
            {
                sql.Append("AND PF_END.NR_LOGRADOURO LIKE '%" + numero.ToUpper().Trim() + "%' ");
            }

            if (complemento != null)
            {
                sql.Append("AND PF_END.DS_COMPLEMENTO LIKE '%" + complemento.ToUpper().Trim() + "%' ");
            }

            List<InfoPessoaFisica> pessoas = context.PessoasFisicas.SqlQuery(sql.ToString()).ToList();

            transacao = GerarTransacao(idClienteEmpresa, idContratoEmpresa, idUsuarioCliente, "CST-WEB-PF-END");
            if (pessoas != null)
            {
                repoTransacao.Add(transacao);
                context.SaveChanges();
            }

            return pessoas;
        }

        public List<InfoPessoaFisica> ConsultarPorNome(
            string nome,
            int idClienteEmpresa,
            int idContratoEmpresa,
            int idUsuarioCliente,
            out TransacaoConsulta transacao)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT ");
            sql.Append("ID_PESSOA_FISICA         AS Id, ");
            sql.Append("NR_CPF                   AS Cpf, ");
            sql.Append("NM_COMPLETO              AS NomeCompleto, ");
            sql.Append("NM_MAE                   AS NomeMae, ");
            sql.Append("DT_NASCIMENTO            AS DataNascimento, ");
            sql.Append("NR_IDADE                 AS Idade, ");
            sql.Append("SG_SEXO                  AS Sexo, ");
            sql.Append("CD_SITUACAO_CADASTRAL_PF AS CodigoSituacaoCadastral, ");
            sql.Append("ID_ORIGEM_DADOS          AS IdOrigemDados, ");
            sql.Append("DT_INCLUSAO              AS DataInclusao, ");
            sql.Append("DT_ULTIMA_ATUALIZACAO    AS DataUltimaAtualizacao ");
            sql.Append("FROM DNAINFO.PESSOA_FISICA ");
            sql.Append("WHERE NM_COMPLETO LIKE '" + nome.ToUpper().Trim() + "%'");

            List<InfoPessoaFisica> pessoas = context.PessoasFisicas.SqlQuery(sql.ToString()).ToList();

            transacao = GerarTransacao(idClienteEmpresa, idContratoEmpresa, idUsuarioCliente, "CST-WEB-PF-NOME");
            if (pessoas != null)
            {
                repoTransacao.Add(transacao);
                context.SaveChanges();
            }

            return pessoas;
        }

        public List<InfoPessoaFisica> ConsultarPorTelefone(
            byte? numeroDdd,
            string numeroTelefone,
            int idClienteEmpresa,
            int idContratoEmpresa,
            int idUsuarioCliente,
            out TransacaoConsulta transacao)
        {
            char[] telefoneArray = numeroTelefone.ToCharArray();
            Array.Reverse(telefoneArray);
            string numeroTelefoneInvertido = new string(telefoneArray);

            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT ");
            sql.Append("PF.ID_PESSOA_FISICA         AS Id, ");
            sql.Append("PF.NR_CPF                   AS Cpf, ");
            sql.Append("PF.NM_COMPLETO              AS NomeCompleto, ");
            sql.Append("PF.NM_MAE                   AS NomeMae, ");
            sql.Append("PF.DT_NASCIMENTO            AS DataNascimento, ");
            sql.Append("PF.NR_IDADE                 AS Idade, ");
            sql.Append("PF.SG_SEXO                  AS Sexo, ");
            sql.Append("PF.CD_SITUACAO_CADASTRAL_PF AS CodigoSituacaoCadastral, ");
            sql.Append("PF.ID_ORIGEM_DADOS          AS IdOrigemDados, ");
            sql.Append("PF.DT_INCLUSAO              AS DataInclusao, ");
            sql.Append("PF.DT_ULTIMA_ATUALIZACAO    AS DataUltimaAtualizacao ");
            sql.Append("FROM DNAINFO.PESSOA_FISICA PF ");
            sql.Append("INNER JOIN DNAINFO.PESSOA_FISICA_TELEFONE PF_FONE ");
            sql.Append("ON PF_FONE.ID_PESSOA_FISICA = PF.ID_PESSOA_FISICA ");
            sql.Append("WHERE PF_FONE.NR_DDD = '" + numeroDdd + "' ");
            sql.Append("AND REVERSE(TO_CHAR(PF_FONE.NR_TELEFONE)) LIKE '" + numeroTelefoneInvertido + "%' ");

            List<InfoPessoaFisica> pessoas = context.PessoasFisicas.SqlQuery(sql.ToString()).ToList();

            transacao = GerarTransacao(idClienteEmpresa, idContratoEmpresa, idUsuarioCliente, "CST-WEB-PF-FONE");
            if (pessoas != null)
            {
                repoTransacao.Add(transacao);
                context.SaveChanges();
            }

            return pessoas;
        }
    }
}
