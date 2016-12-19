using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DNAMais.Domain.Entidades.Consultas
{
    [Table("PORTE_EMPRESA", Schema = "DNAINFO")]
    public class InfoPorteEmpresa
    {
        #region Propriedades Públicas

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("CD_PORTE_EMPRESA")]
        public byte? Codigo { get; set; }

        [Column("DS_PORTE_EMPRESA")]
        public string Descricao { get; set; }

        [Column("DT_INCLUSAO")]
        public DateTime? DataInclusao { get; set; }

        [Column("DT_ULTIMA_ATUALIZACAO")]
        public DateTime? DataUltimaAtualizacao { get; set; }

        public virtual ICollection<InfoPessoaJuridica> PessoasJuridicas { get; set; }

        #endregion

        #region Construtor

        public InfoPorteEmpresa()
        {
            PessoasJuridicas = new HashSet<InfoPessoaJuridica>();
        }

        #endregion
    }
}
