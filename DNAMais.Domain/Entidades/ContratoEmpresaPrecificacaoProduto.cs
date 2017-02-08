using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNAMais.Domain.Entidades
{
    [Table("CONTRATO_PRODUTO_PRECIFICACAO", Schema = "DNASITE")]
    public class ContratoEmpresaPrecificacaoProduto
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
        [Column("CD_PRODUTO", Order = 2)]
        public string CodigoProduto { get; set; }
        [ForeignKey("CodigoProduto")]
        public virtual Produto Produto { get; set; }

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

        public ContratoEmpresaPrecificacaoProduto()
        {

        }

        #endregion
    }
}
