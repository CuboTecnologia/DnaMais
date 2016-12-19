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
    public class InfoPessoaJuridicaService
    {
        private DNAMaisSiteContext context;

        private Repository<InfoPessoaJuridica> repoPJ;
        private Repository<TransacaoConsulta> repoTransacao;

        public InfoPessoaJuridicaService()
        {
            context = new DNAMaisSiteContext();
            repoPJ = new Repository<InfoPessoaJuridica>(context);
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

        public InfoPessoaJuridica ConsultarPorCNPJ(
            string cnpj,
            int idClienteEmpresa,
            int idContratoEmpresa,
            int idUsuarioCliente,
            out TransacaoConsulta transacao)
        {
            cnpj = cnpj.LimparCaracteresCNPJ();

            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT ");
            sql.Append("ID_PESSOA_JURIDICA AS Id, ");
            sql.Append("NR_CNPJ AS CNPJ, ");
            sql.Append("NM_RAZAO_SOCIAL AS RazaoSocial, ");
            sql.Append("NM_FANTASIA AS NomeFantasia, ");
            sql.Append("CD_TIPO_UNIDADE AS CodigoTipoUnidade, ");
            sql.Append("DT_ABERTURA AS DataAbertura, ");
            sql.Append("CD_NATUREZA_JURIDICA AS CodigoNaturezaJuridica, ");
            sql.Append("CD_SITUACAO_CADASTRAL_PJ AS CodigoSituacaoCadastral, ");
            sql.Append("DT_SITUACAO_CADASTRAL_PJ AS DataSituacaoCadastral, ");
            sql.Append("DS_MOTIVO_SITUACAO_CADASTRAL AS MotivoSituacaoCadastral, ");
            sql.Append("IS_DOMICILIADA_EXTERIOR AS DomiciliadaExteriorDescricao, ");
            sql.Append("DS_SITUACAO_ESPECIAL AS SituacaoEspecial, ");
            sql.Append("DT_SITUACAO_ESPECIAL AS DataSituacaoEspecial, ");
            sql.Append("QT_FILIAIS AS QuantidadeFiliais, ");
            sql.Append("CD_PORTE_EMPRESA AS CodigoPorteEmpresa, ");
            sql.Append("DS_ENTE_FEDERATIVO_RESPONSAVEL AS EnteFederativoResponsavel, ");
            sql.Append("DS_CAPITAL_SOCIAL AS CapitalSocial, ");
            sql.Append("VL_FATURAMENTO_ANUAL AS FaturamentoAnual, ");
            sql.Append("ID_ORIGEM_DADOS AS IdOrigemDados, ");
            sql.Append("DT_INCLUSAO AS DataInclusao, ");
            sql.Append("DT_ULTIMA_ATUALIZACAO AS DataUltimaAtualizacao ");
            sql.Append("FROM DNAINFO.PESSOA_JURIDICA ");
            sql.Append("WHERE NR_CNPJ = '" + cnpj + "'");

            InfoPessoaJuridica pessoa = context.PessoasJuridicas.SqlQuery(sql.ToString()).FirstOrDefault();

            transacao = GerarTransacao(idClienteEmpresa, idContratoEmpresa, idUsuarioCliente, "CST-WEB-PJ-CNPJ");
            if (pessoa != null)
            {
                repoTransacao.Add(transacao);
                context.SaveChanges();
            }

            return pessoa;
        }

        public List<InfoPessoaJuridica> ConsultarPorCEP(
            string cep,
            int idClienteEmpresa,
            int idContratoEmpresa,
            int idUsuarioCliente,
            out TransacaoConsulta transacao)
        {
            cep = cep.LimparCaracteresCEP();

            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT ");
            sql.Append("PJ.ID_PESSOA_JURIDICA AS Id, ");
            sql.Append("PJ.NR_CNPJ AS CNPJ, ");
            sql.Append("PJ.NM_RAZAO_SOCIAL AS RazaoSocial, ");
            sql.Append("PJ.NM_FANTASIA AS NomeFantasia, ");
            sql.Append("PJ.CD_TIPO_UNIDADE AS CodigoTipoUnidade, ");
            sql.Append("PJ.DT_ABERTURA AS DataAbertura, ");
            sql.Append("PJ.CD_NATUREZA_JURIDICA AS CodigoNaturezaJuridica, ");
            sql.Append("PJ.CD_SITUACAO_CADASTRAL_PJ AS CodigoSituacaoCadastral, ");
            sql.Append("PJ.DT_SITUACAO_CADASTRAL_PJ AS DataSituacaoCadastral, ");
            sql.Append("PJ.DS_MOTIVO_SITUACAO_CADASTRAL AS MotivoSituacaoCadastral, ");
            sql.Append("PJ.IS_DOMICILIADA_EXTERIOR AS DomiciliadaExteriorDescricao, ");
            sql.Append("PJ.DS_SITUACAO_ESPECIAL AS SituacaoEspecial, ");
            sql.Append("PJ.DT_SITUACAO_ESPECIAL AS DataSituacaoEspecial, ");
            sql.Append("PJ.QT_FILIAIS AS QuantidadeFiliais, ");
            sql.Append("PJ.CD_PORTE_EMPRESA AS CodigoPorteEmpresa, ");
            sql.Append("PJ.DS_ENTE_FEDERATIVO_RESPONSAVEL AS EnteFederativoResponsavel, ");
            sql.Append("PJ.DS_CAPITAL_SOCIAL AS CapitalSocial, ");
            sql.Append("PJ.VL_FATURAMENTO_ANUAL AS FaturamentoAnual, ");
            sql.Append("PJ.ID_ORIGEM_DADOS AS IdOrigemDados, ");
            sql.Append("PJ.DT_INCLUSAO AS DataInclusao, ");
            sql.Append("PJ.DT_ULTIMA_ATUALIZACAO AS DataUltimaAtualizacao ");
            sql.Append("FROM DNAINFO.PESSOA_JURIDICA PJ ");
            sql.Append("INNER JOIN DNAINFO.PESSOA_JURIDICA_ENDERECO PJ_END ");
            sql.Append("ON PJ_END.ID_PESSOA_JURIDICA = PJ.ID_PESSOA_JURIDICA ");
            sql.Append("WHERE PJ_END.NR_CEP = '" + cep + "'");

            List<InfoPessoaJuridica> pessoas = context.PessoasJuridicas.SqlQuery(sql.ToString()).ToList();

            transacao = GerarTransacao(idClienteEmpresa, idContratoEmpresa, idUsuarioCliente, "CST-WEB-PJ-END");
            if (pessoas != null)
            {
                repoTransacao.Add(transacao);
                context.SaveChanges();
            }

            return pessoas;
        }

        public List<InfoPessoaJuridica> ConsultarPorEndereco(
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
            sql.Append("PJ.ID_PESSOA_JURIDICA AS Id, ");
            sql.Append("PJ.NR_CNPJ AS CNPJ, ");
            sql.Append("PJ.NM_RAZAO_SOCIAL AS RazaoSocial, ");
            sql.Append("PJ.NM_FANTASIA AS NomeFantasia, ");
            sql.Append("PJ.CD_TIPO_UNIDADE AS CodigoTipoUnidade, ");
            sql.Append("PJ.DT_ABERTURA AS DataAbertura, ");
            sql.Append("PJ.CD_NATUREZA_JURIDICA AS CodigoNaturezaJuridica, ");
            sql.Append("PJ.CD_SITUACAO_CADASTRAL_PJ AS CodigoSituacaoCadastral, ");
            sql.Append("PJ.DT_SITUACAO_CADASTRAL_PJ AS DataSituacaoCadastral, ");
            sql.Append("PJ.DS_MOTIVO_SITUACAO_CADASTRAL AS MotivoSituacaoCadastral, ");
            sql.Append("PJ.IS_DOMICILIADA_EXTERIOR AS DomiciliadaExteriorDescricao, ");
            sql.Append("PJ.DS_SITUACAO_ESPECIAL AS SituacaoEspecial, ");
            sql.Append("PJ.DT_SITUACAO_ESPECIAL AS DataSituacaoEspecial, ");
            sql.Append("PJ.QT_FILIAIS AS QuantidadeFiliais, ");
            sql.Append("PJ.CD_PORTE_EMPRESA AS CodigoPorteEmpresa, ");
            sql.Append("PJ.DS_ENTE_FEDERATIVO_RESPONSAVEL AS EnteFederativoResponsavel, ");
            sql.Append("PJ.DS_CAPITAL_SOCIAL AS CapitalSocial, ");
            sql.Append("PJ.VL_FATURAMENTO_ANUAL AS FaturamentoAnual, ");
            sql.Append("PJ.ID_ORIGEM_DADOS AS IdOrigemDados, ");
            sql.Append("PJ.DT_INCLUSAO AS DataInclusao, ");
            sql.Append("PJ.DT_ULTIMA_ATUALIZACAO AS DataUltimaAtualizacao ");
            sql.Append("FROM DNAINFO.PESSOA_JURIDICA PJ ");
            sql.Append("INNER JOIN DNAINFO.PESSOA_JURIDICA_ENDERECO PJ_END ");
            sql.Append("ON PJ_END.ID_PESSOA_JURIDICA = PJ.ID_PESSOA_JURIDICA ");
            sql.Append("WHERE PJ_END.SG_UF = '" + uf + "' ");
            sql.Append("AND PJ_END.NM_CIDADE = '" + municipio.ToUpper().Trim() + "' ");
            sql.Append("AND PJ_END.NM_BAIRRO LIKE '" + bairro.ToUpper().Trim() + "%' ");
            sql.Append("AND PJ_END.DS_LOGRADOURO LIKE '" + logradouro.ToUpper().Trim() + "%' ");

            if (numero != null)
            {
                sql.Append("AND PJ_END.NR_LOGRADOURO LIKE '%" + numero.ToUpper().Trim() + "%' ");
            }

            if (complemento != null)
            {
                sql.Append("AND PJ_END.DS_COMPLEMENTO LIKE '%" + complemento.ToUpper().Trim() + "%' ");
            }

            List<InfoPessoaJuridica> pessoas = context.PessoasJuridicas.SqlQuery(sql.ToString()).ToList();

            transacao = GerarTransacao(idClienteEmpresa, idContratoEmpresa, idUsuarioCliente, "CST-WEB-PJ-END");
            if (pessoas != null)
            {
                repoTransacao.Add(transacao);
                context.SaveChanges();
            }

            return pessoas;
        }

        public List<InfoPessoaJuridica> ConsultarPorNome(
            string nome,
            int idClienteEmpresa,
            int idContratoEmpresa,
            int idUsuarioCliente,
            out TransacaoConsulta transacao)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT ");
            sql.Append("ID_PESSOA_JURIDICA AS Id, ");
            sql.Append("NR_CNPJ AS CNPJ, ");
            sql.Append("NM_RAZAO_SOCIAL AS RazaoSocial, ");
            sql.Append("NM_FANTASIA AS NomeFantasia, ");
            sql.Append("CD_TIPO_UNIDADE AS CodigoTipoUnidade, ");
            sql.Append("DT_ABERTURA AS DataAbertura, ");
            sql.Append("CD_NATUREZA_JURIDICA AS CodigoNaturezaJuridica, ");
            sql.Append("CD_SITUACAO_CADASTRAL_PJ AS CodigoSituacaoCadastral, ");
            sql.Append("DT_SITUACAO_CADASTRAL_PJ AS DataSituacaoCadastral, ");
            sql.Append("DS_MOTIVO_SITUACAO_CADASTRAL AS MotivoSituacaoCadastral, ");
            sql.Append("IS_DOMICILIADA_EXTERIOR AS DomiciliadaExteriorDescricao, ");
            sql.Append("DS_SITUACAO_ESPECIAL AS SituacaoEspecial, ");
            sql.Append("DT_SITUACAO_ESPECIAL AS DataSituacaoEspecial, ");
            sql.Append("QT_FILIAIS AS QuantidadeFiliais, ");
            sql.Append("CD_PORTE_EMPRESA AS CodigoPorteEmpresa, ");
            sql.Append("DS_ENTE_FEDERATIVO_RESPONSAVEL AS EnteFederativoResponsavel, ");
            sql.Append("DS_CAPITAL_SOCIAL AS CapitalSocial, ");
            sql.Append("VL_FATURAMENTO_ANUAL AS FaturamentoAnual, ");
            sql.Append("ID_ORIGEM_DADOS AS IdOrigemDados, ");
            sql.Append("DT_INCLUSAO AS DataInclusao, ");
            sql.Append("DT_ULTIMA_ATUALIZACAO AS DataUltimaAtualizacao ");
            sql.Append("FROM DNAINFO.PESSOA_JURIDICA ");
            sql.Append("WHERE NM_RAZAO_SOCIAL LIKE '" + nome.ToUpper().Trim() + "%'");

            List<InfoPessoaJuridica> pessoas = context.PessoasJuridicas.SqlQuery(sql.ToString()).ToList();

            transacao = GerarTransacao(idClienteEmpresa, idContratoEmpresa, idUsuarioCliente, "CST-WEB-PJ-NOME");
            if (pessoas != null)
            {
                repoTransacao.Add(transacao);
                context.SaveChanges();
            }

            return pessoas;
        }

        public List<InfoPessoaJuridica> ConsultarPorTelefone(
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
            sql.Append("PJ.ID_PESSOA_JURIDICA AS Id, ");
            sql.Append("PJ.NR_CNPJ AS CNPJ, ");
            sql.Append("PJ.NM_RAZAO_SOCIAL AS RazaoSocial, ");
            sql.Append("PJ.NM_FANTASIA AS NomeFantasia, ");
            sql.Append("PJ.CD_TIPO_UNIDADE AS CodigoTipoUnidade, ");
            sql.Append("PJ.DT_ABERTURA AS DataAbertura, ");
            sql.Append("PJ.CD_NATUREZA_JURIDICA AS CodigoNaturezaJuridica, ");
            sql.Append("PJ.CD_SITUACAO_CADASTRAL_PJ AS CodigoSituacaoCadastral, ");
            sql.Append("PJ.DT_SITUACAO_CADASTRAL_PJ AS DataSituacaoCadastral, ");
            sql.Append("PJ.DS_MOTIVO_SITUACAO_CADASTRAL AS MotivoSituacaoCadastral, ");
            sql.Append("PJ.IS_DOMICILIADA_EXTERIOR AS DomiciliadaExteriorDescricao, ");
            sql.Append("PJ.DS_SITUACAO_ESPECIAL AS SituacaoEspecial, ");
            sql.Append("PJ.DT_SITUACAO_ESPECIAL AS DataSituacaoEspecial, ");
            sql.Append("PJ.QT_FILIAIS AS QuantidadeFiliais, ");
            sql.Append("PJ.CD_PORTE_EMPRESA AS CodigoPorteEmpresa, ");
            sql.Append("PJ.DS_ENTE_FEDERATIVO_RESPONSAVEL AS EnteFederativoResponsavel, ");
            sql.Append("PJ.DS_CAPITAL_SOCIAL AS CapitalSocial, ");
            sql.Append("PJ.VL_FATURAMENTO_ANUAL AS FaturamentoAnual, ");
            sql.Append("PJ.ID_ORIGEM_DADOS AS IdOrigemDados, ");
            sql.Append("PJ.DT_INCLUSAO AS DataInclusao, ");
            sql.Append("PJ.DT_ULTIMA_ATUALIZACAO AS DataUltimaAtualizacao ");
            sql.Append("FROM DNAINFO.PESSOA_JURIDICA PJ ");
            sql.Append("INNER JOIN DNAINFO.PESSOA_JURIDICA_TELEFONE PJ_FONE ");
            sql.Append("ON PJ_FONE.ID_PESSOA_JURIDICA = PJ.ID_PESSOA_JURIDICA ");
            sql.Append("WHERE PJ_FONE.NR_DDD = '" + numeroDdd + "' ");
            sql.Append("AND REVERSE(TO_CHAR(PJ_FONE.NR_TELEFONE)) LIKE '" + numeroTelefoneInvertido + "%' ");

            List<InfoPessoaJuridica> pessoas = context.PessoasJuridicas.SqlQuery(sql.ToString()).ToList();

            transacao = GerarTransacao(idClienteEmpresa, idContratoEmpresa, idUsuarioCliente, "CST-WEB-PJ-END");
            if (pessoas != null)
            {
                repoTransacao.Add(transacao);
                context.SaveChanges();
            }

            return pessoas;
        }
    }
}
