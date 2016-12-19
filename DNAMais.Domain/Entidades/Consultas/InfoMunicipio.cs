using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DNAMais.Domain.Entidades.Consultas
{
    [Table("MUNICIPIO", Schema = "DNAINFO")]
    public class InfoMunicipio
    {
        #region Propriedades Públicas

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("CD_MUNICIPIO")]
        public string Codigo { get; set; }

        [Column("NM_MUNICIPIO")]
        public string Nome { get; set; }

        [Column("SG_UF")]
        public string SiglaUF { get; set; }
        [ForeignKey("SiglaUF")]
        public virtual InfoUf Uf { get; set; }

        [Column("DT_INCLUSAO")]
        public DateTime? DataInclusao { get; set; }

        [Column("DT_ULTIMA_ATUALIZACAO")]
        public DateTime? DataUltimaAtualizacao { get; set; }

        #endregion

        #region Construtor

        public InfoMunicipio()
        {

        }

        #endregion
    }
}
