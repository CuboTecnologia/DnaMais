using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DNAMais.Domain.Entidades.Consultas
{
    [Table("PESSOA_FISICA_TELEFONE", Schema = "DNAINFO")]
    public class InfoPessoaFisicaTelefone
    {
        #region Propriedades Públicas

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("ID_PESSOA_FISICA_TELEFONE")]
        public long? Id { get; set; }

        [Column("ID_PESSOA_FISICA")]
        public long? IdPessoaFisica { get; set; }
        [ForeignKey("IdPessoaFisica")]
        public virtual InfoPessoaFisica PessoaFisica { get; set; }

        [Column("NR_DDD")]
        public byte? Ddd { get; set; }

        [Column("NR_TELEFONE")]
        public int? Telefone { get; set; }

        [Column("DS_EXTENSAO")]
        public int? Extensao { get; set; }

        [Column("ID_TIPO_TELEFONE")]
        public byte? IdTipoTelefone { get; set; }
        [ForeignKey("IdTipoTelefone")]
        public virtual InfoTipoTelefone TipoTelefone { get; set; }

        [Column("ID_PESSOA_FISICA_ENDERECO")]
        public long? IdPessoaFisicaEndereco { get; set; }
        [ForeignKey("IdPessoaFisicaEndereco")]
        public virtual InfoPessoaFisicaEndereco Endereco { get; set; }

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

        public InfoPessoaFisicaTelefone()
        {

        }

        #endregion
    }
}
