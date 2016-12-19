using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DNAMais.Domain.Entidades.Consultas
{
    [Table("PESSOA_FISICA_COMPLEMENTAR", Schema = "DNAINFO")]
    public class InfoPessoaFisicaComplementar
    {
        #region Propriedades Públicas

        [Key]
        [ForeignKey("PessoaFisica")]
        [Column("ID_PESSOA_FISICA")]
        public long? IdPessoaFisica { get; set; }
        public virtual InfoPessoaFisica PessoaFisica { get; set; }

        [Column("NR_RG")]
        public string NumeroRG { get; set; }

        [Column("NR_TITULO_ELEITOR")]
        public string TituloEleitor { get; set; }

        [Column("DS_ESTADO_CIVIL")]
        public string EstadoCivil { get; set; }

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

        public InfoPessoaFisicaComplementar()
        {

        }

        #endregion
    }
}
