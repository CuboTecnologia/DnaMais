using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNAMais.Domain.Entidades
{
    [Table("CONTRATO_EMPRESA_PRODUTO", Schema = "DNASITE")]
    public class ContratoEmpresaProduto
    {
        #region Propriedades Públicas

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("ID_CONTRATO_EMPRESA", Order=1)]
        public int? IdContratoEmpresa { get; set; }
        [ForeignKey("IdContratoEmpresa")]
        public virtual ContratoEmpresa ContratoEmpresa { get; set; }

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("CD_PRODUTO", Order=2)]
        [StringLength(20)]
        public string CodigoProduto { get; set; }
        [ForeignKey("CodigoProduto")]
        public virtual Produto Produto { get; set; }

        #endregion

        #region Construtor

        public ContratoEmpresaProduto()
        {

        }

        #endregion
    }
}