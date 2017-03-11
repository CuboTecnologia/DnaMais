using DNAMais.Domain.CustomAttributes;
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
    [SequenceOracle("SQ_CONTRATO_PRODUTO_PRECIF")]
    public class ContratoEmpresaPrecificacaoProduto
    {
        #region Propriedades Públicas

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("ID_CONTRATO_PRODUTO_PRECIF")]
        public int? Id { get; set; }

        [Required]
        [Column("ID_CONTRATO_EMPRESA")]
        public int? IdContratoEmpresa { get; set; }
        [ForeignKey("IdContratoEmpresa")]
        public virtual ContratoEmpresa ContratoEmpresa { get; set; }

        [Required]
        [Column("CD_PRODUTO")]
        [Display(Name = "Código Produto")]
        public string CodigoProduto { get; set; }
        [ForeignKey("CodigoProduto")]
        public virtual Produto Produto { get; set; }

        [Required]
        [Column("NR_INICIO_FAIXA")]
        [Display(Name = "Início da faixa")]
        public int InicioFaixa { get; set; }

        [Required]
        [Display(Name = "Término da Faixa")]
        [Column("NR_TERMINO_FAIXA")]
        public int? TerminoFaixa { get; set; }

        [Required]
        [Display(Name = "Valor da consulta")]
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
