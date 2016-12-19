using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DNAMais.Domain.Entidades.Consultas
{
    [Table("CBO", Schema = "DNAINFO")]
    public class InfoCBO
    {
        #region Propriedades Públicas

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("CD_CBO")]
        public string Codigo { get; set; }

        [Column("DS_CBO")]
        public string Descricao { get; set; }

        [Column("DT_INCLUSAO")]
        public DateTime? DataInclusao { get; set; }

        [Column("DT_ULTIMA_ATUALIZACAO")]
        public DateTime? DataUltimaAtualizacao { get; set; }

        public virtual ICollection<InfoPessoaFisicaProfissional> ProfissionaisPessoaFisica { get; set; }

        #endregion

        #region Construtor

        public InfoCBO()
        {
            ProfissionaisPessoaFisica = new HashSet<InfoPessoaFisicaProfissional>();
        }

        #endregion
    }
}
