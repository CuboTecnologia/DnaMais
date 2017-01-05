using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DNAMais.Domain.Entidades.Consultas
{
    [Table("PESSOA_JURIDICA_QSA", Schema = "DNAINFO")]
    public class InfoPessoaJuridicaQsa
    {
        #region Propriedades Públicas

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("ID_PESSOA_JURIDICA_QSA")]
        public long? Id { get; set; }

        [Required]
        [Column("ID_PESSOA_JURIDICA")]
        public long? IdPessoaJuridica { get; set; }
        [ForeignKey("IdPessoaJuridica")]
        public virtual InfoPessoaJuridica PessoaJuridica { get; set; }

        [Column("NR_CNPJ")]
        public string CNPJ { get; set; }

        [Column("NR_DOCUMENTO_SOCIO")]
        public string DocumentoSocio { get; set; }

        [Column("NM_NOME_SOCIO")]
        public string NomeSocio { get; set; }

        [Column("DS_QUALIFICACAO")]
        public string Qualificacao { get; set; }

        [Column("DT_DATA_ENTRADA_SOCIEDADE")]
        public DateTime? DataEntradaSociedade { get; set; }

        [Column("VL_VALOR_PARTICIPACAO")]
        public string ValorParticipacao { get; set; }

        [Column("DS_ARQUIVO")]
        public string Arquivo { get; set; }

        [Column("NR_ID_TABLE")]
        public int? IdTable { get; set; }

        [Column("NR_OLD_SOCIO")]
        public int? OldSocio { get; set; }

        [Column("DT_CONSULTA")]
        public DateTime? DataConsulta { get; set; }

        [Column("NR_ORDEM_SOC")]
        public int? OrdemSocio { get; set; }

        [Column("NR_FLAG")]
        public int? Flag { get; set; }

        #endregion

        #region Construtor

        public InfoPessoaJuridicaQsa()
        {

        }

        #endregion
    }
}
