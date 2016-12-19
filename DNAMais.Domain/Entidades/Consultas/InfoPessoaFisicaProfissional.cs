using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DNAMais.Domain.Entidades.Consultas
{
    [Table("PESSOA_FISICA_PROFISSIONAL", Schema = "DNAINFO")]
    public class InfoPessoaFisicaProfissional
    {
        #region Propriedades Públicas

        [Key]
        [ForeignKey("PessoaFisica")]
        [Column("ID_PESSOA_FISICA")]
        public long? IdPessoaFisica { get; set; }
        public virtual InfoPessoaFisica PessoaFisica { get; set; }

        [Column("NM_PROFISSIONAL")]
        public string NomeProfissional { get; set; }

        [Column("NR_CNPJ_CONTRATANTE")]
        public string CNPJContratante { get; set; }

        [Column("NR_PIS")]
        public string NumeroPIS { get; set; }

        [Column("CD_GRAU_ESCOLARIDADE")]
        public byte? CodigoGrauEscolaridade { get; set; }
        [ForeignKey("CodigoGrauEscolaridade")]
        public virtual InfoGrauEscolaridade GrauEscolaridade { get; set; }

        [Column("CD_CBO")]
        public string CodigoCBO { get; set; }
        [ForeignKey("CodigoCBO")]
        public virtual InfoCBO CBO { get; set; }

        [Column("VL_RENDA_ATUAL")]
        public decimal? ValorRendaAtual { get; set; }

        [Column("CD_FAIXA_RENDA")]
        public byte? CodigoFaixaRenda { get; set; }
        [ForeignKey("CodigoFaixaRenda")]
        public virtual InfoFaixaRenda FaixaRenda { get; set; }

        [Column("CD_CLASSE_SOCIAL")]
        public string CodigoClasseSocial { get; set; }
        [ForeignKey("CodigoClasseSocial")]
        public virtual InfoClasseSocial ClassSocial { get; set; }

        [Column("ID_ORIGEM_DADOS")]
        public short? IdOrigemDados { get; set; }
        [ForeignKey("IdOrigemDados")]
        public virtual InfoOrigemDados OrigemDados { get; set; }

        [Column("DT_INCLUSAO")]
        public DateTime? DataInclusao { get; set; }

        [Column("DT_ULTIMA_ATUALIZACAO")]
        public DateTime? DataUltimaAtualizacao { get; set; }

        #endregion

        #region Construtor

        public InfoPessoaFisicaProfissional()
        {

        }

        #endregion
    }
}
