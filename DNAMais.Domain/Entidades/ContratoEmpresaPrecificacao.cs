using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNAMais.Domain.Entidades
{
    [Table("CONTRATO_EMPRESA_PRECIFICACAO", Schema = "DNASITE")]
    public class ContratoEmpresaPrecificacaoX
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
        [Column("CD_CATEGORIA_PRODUTO_CONSULTA", Order=2)]
        public string CodigoCategoriaConsulta { get; set; }
        [ForeignKey("CodigoCategoriaConsulta")]
        public virtual CategoriaProduto CategoriaProduto { get; set; }

        [Key]
        [Required]
        [Column("CD_FAIXA", Order=3)]
        public string CodigoFaixa { get; set; }

        [Required]
        [Column("DS_FAIXA")]
        public string DescricaoFaixa { get; set; }

        [Required]
        [Column("NR_INICIO_FAIXA")]
        public int? InicioFaixa { get; set; }

        [Required]
        [Column("NR_TERMINO_FAIXA")]
        public int? TerminoFaixa { get; set; }

        [Required]
        [Column("VL_CONSULTA")]
        public double? ValorConsulta { get; set; }

        #endregion

        #region Construtor

        public ContratoEmpresaPrecificacaoX()
        {

        }

        #endregion
    }
}
