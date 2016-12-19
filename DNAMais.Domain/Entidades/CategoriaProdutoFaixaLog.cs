using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNAMais.Domain.Entidades
{
    [Table("CATEGORIA_PRODUTO_FAIXA_LOG", Schema = "DNASITE")]
    public class CategoriaProdutoFaixaLog
    {
        #region Propriedades Públicas

        [Key]
        [Required]
        [Column("CD_CATEGORIA_PRODUTO", Order=1)]
        [StringLength(10)]
        public string CodigoCategoria { get; set; }
        [ForeignKey("CodigoCategoria")]
        public virtual CategoriaProduto CategoriaProduto { get; set; }

        [Key]
        [Required]
        [Column("CD_FAIXA", Order=2)]
        public bool? CodigoFaixa { get; set; }

        [Required]
        [Column("DT_INICIO_VIGENCIA")]
        public DateTime? InicioVigencia { get; set; }

        [Key]
        [Required]
        [Column("DT_TERMINO_VIGENCIA", Order=3)]
        public DateTime? TerminoVigencia { get; set; }

        [Required]
        [Column("DS_FAIXA")]
        [StringLength(200)]
        public string DescricaoFaixa { get; set; }

        [Required]
        [Column("NR_INICIO_FAIXA")]
        public int? InicioFaixa { get; set; }

        [Required]
        [Column("NR_TERMINO_FAIXA")]
        public int? TerminoFaixa { get; set; }

        #endregion

        #region Construtor

        public CategoriaProdutoFaixaLog()
        {

        }

        #endregion
    }
}
