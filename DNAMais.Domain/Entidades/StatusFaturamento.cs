using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNAMais.Domain.Entidades
{
    [Table("STATUS_FATURAMENTO", Schema = "DNASITE")]
    public class StatusFaturamento
    {
        #region Propriedades Públicas

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("CD_STATUS_FATURAMENTO")]
        public byte? Codigo { get; set; }

        [Required]
        [Column("NM_STATUS")]
        [StringLength(20)]
        public string Nome { get; set; }

        public virtual ICollection<Faturamento> Faturamentos { get; set; }

        #endregion

        #region Construtor

        public StatusFaturamento()
        {
            Faturamentos = new HashSet<Faturamento>();
        }

        #endregion
    }
}
