using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNAMais.Domain.Entidades
{
    [Table("CONTRATO_ITEM_PRODUTO_PRECIF", Schema = "DNASITE")]
    public class ContratoEmpresaPrecificacaoItemProduto
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
        [Column("CD_ITEM_PRODUTO", Order = 2)]
        public string CodigoItemProduto { get; set; }
        [ForeignKey("CodigoItemProduto")]
        public virtual ItemProduto ItemProduto { get; set; }

        [Key]
        [Required]
        [Column("NR_ORDEM", Order=3)]
        public int Ordem { get; set; }

        [Required]
        [Column("NR_INICIO_FAIXA")]
        public int InicioFaixa { get; set; }

        [Required]
        [Column("NR_TERMINO_FAIXA")]
        public int? TerminoFaixa { get; set; }

        [Required]
        [Column("VL_CONSULTA")]
        public double? ValorConsulta { get; set; }

        #endregion

        #region Construtor

        public ContratoEmpresaPrecificacaoItemProduto()
        {

        }

        #endregion
    }
}
