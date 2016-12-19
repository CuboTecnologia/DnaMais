using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNAMais.Domain.Entidades
{
    [Table("ITEM_FATURAMENTO", Schema = "DNASITE")]
    public class ItemFaturamento
    {
        #region Propriedades Públicas

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("ID_ITEM_FATURAMENTO")]
        public int? Id { get; set; }

        [Required]
        [Column("ID_FATURAMENTO")]
        public int? IdFaturamento { get; set; }
        [ForeignKey("IdFaturamento")]
        public virtual Faturamento Faturamento { get; set; }

        [Required]
        [Column("CD_CATEGORIA_PRODUTO")]
        public string CodigoCategoriaProduto { get; set; }
        [ForeignKey("CodigoCategoriaProduto")]
        public virtual CategoriaProduto CategoriaProduto { get; set; }

        [Required]
        [Column("DS_ITEM_FATURAMENTO")]
        public string Descricao { get; set; }

        [Required]
        [Column("QT_ITEM_FATURAMENTO")]
        public int? Quantidade { get; set; }

        [Required]
        [Column("VL_ITEM_FATURAMENTO")]
        public double? Valor { get; set; }

        #endregion

        #region Construtor

        public ItemFaturamento()
        {

        }

        #endregion
    }
}
