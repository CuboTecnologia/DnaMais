using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DNAMais.Domain.Entidades.Consultas
{
    [Table("FAIXA_RENDA", Schema = "DNAINFO")]
    public class InfoFaixaRenda
    {
        #region Propriedades Públicas

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("CD_FAIXA_RENDA")]
        public byte? Codigo { get; set; }

        [Column("DS_FAIXA_RENDA")]
        public string Descricao { get; set; }

        [Column("DT_INCLUSAO")]
        public DateTime? DataInclusao { get; set; }

        [Column("DT_ULTIMA_ATUALIZACAO")]
        public DateTime? DataUltimaAtualizacao { get; set; }

        public virtual ICollection<InfoPessoaFisicaProfissional> ProfissionaisPessoaFisica { get; set; }

        #endregion

        #region Construtor

        public InfoFaixaRenda()
        {
            ProfissionaisPessoaFisica = new HashSet<InfoPessoaFisicaProfissional>();
        }

        #endregion
    }
}
