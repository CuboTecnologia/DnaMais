using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNAMais.Domain.Entidades
{
    [Table("TIPO_PRECIFICACAO", Schema = "DNASITE")]
    public class TipoPrecificacao
    {
        #region Propriedades Públicas

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("CD_TIPO_PRECIFICACAO")]
        public short? Codigo { get; set; }

        [Required]
        [Column("NM_TIPO_PRECIFICACAO")]
        [StringLength(100)]
        public string Nome { get; set; }

        public virtual ICollection<CategoriaProduto> Categorias { get; set; }

        #endregion

        #region Construtor

        public TipoPrecificacao()
        {
            Categorias = new HashSet<CategoriaProduto>();
        }

        #endregion
    }
}
