using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DNAMais.Domain.Entidades.Consultas
{
    [Table("PESSOA_JURIDICA_TELEFONE", Schema = "DNAINFO")]
    public class InfoPessoaJuridicaTelefone
    {
        #region Propriedades Públicas

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("ID_PESSOA_JURIDICA_TELEFONE")]
        public long? Id { get; set; }

        [Column("ID_PESSOA_JURIDICA")]
        public long? IdPessoaJuridica { get; set; }
        [ForeignKey("IdPessoaJuridica")]
        public virtual InfoPessoaJuridica PessoaJuridica { get; set; }

        [Column("NR_DDD")]
        public byte? Ddd { get; set; }

        [Column("NR_TELEFONE")]
        public int? Telefone { get; set; }

        [Column("CD_OPERADORA_TELEFONIA")]
        public byte? CodigoOperadoraTelefonia { get; set; }
        [ForeignKey("CodigoOperadoraTelefonia")]
        public virtual InfoOperadoraTelefonia OperadoraTelefonia { get; set; }

        [NotMapped]
        public bool? Procon { get; set; }

        [Column("IS_PROCON")]
        public string ProconDescricao
        {
            get { return Procon ?? false ? "S" : "N"; }
            set { Procon = value == "S" ? true : false; }
        }

        [Column("DT_CADASTRO_PROCON")]
        public DateTime? DataCadastroProcon { get; set; }

        [Column("DT_BLOQUEIO_PROCON")]
        public DateTime? DataBloqueioProcon { get; set; }

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

        public InfoPessoaJuridicaTelefone()
        {

        }

        #endregion
    }
}
