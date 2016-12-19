using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DNAMais.Domain.Entidades.Consultas
{
    [Table("GRAU_ESCOLARIDADE", Schema = "DNAINFO")]
    public class InfoGrauEscolaridade
    {
        #region Propriedades Públicas

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("CD_GRAU_ESCOLARIDADE")]
        public byte? Codigo { get; set; }

        [Column("DS_GRAU_ESCOLARIDADE")]
        public string Descricao { get; set; }

        [Column("DT_INCLUSAO")]
        public DateTime? DataInclusao { get; set; }

        [Column("DT_ULTIMA_ATUALIZACAO")]
        public DateTime? DataUltimaAtualizacao { get; set; }

        public virtual ICollection<InfoPessoaFisicaProfissional> ProfissionaisPessoaFisica { get; set; }

        #endregion

        #region Construtor

        public InfoGrauEscolaridade()
        {
            ProfissionaisPessoaFisica = new HashSet<InfoPessoaFisicaProfissional>();
        }

        #endregion
    }
}
