using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DNAMais.Domain.Entidades.Consultas
{
    [Table("NATUREZA_JURIDICA", Schema = "DNAINFO")]
    public class InfoNaturezaJuridica
    {
        #region Propriedades Públicas

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("CD_NATUREZA_JURIDICA")]
        public string Codigo { get; set; }

        [Column("NM_NATUREZA_JURIDICA")]
        public string Nome { get; set; }

        [Column("DT_INCLUSAO")]
        public DateTime? DataInclusao { get; set; }

        [Column("DT_ULTIMA_ATUALIZACAO")]
        public DateTime? DataUltimaAtualizacao { get; set; }

        public virtual ICollection<InfoPessoaJuridica> PessoasJuridicas { get; set; }

        #endregion

        #region Construtor

        public InfoNaturezaJuridica()
        {
            PessoasJuridicas = new HashSet<InfoPessoaJuridica>();
        }

        #endregion
    }
}
