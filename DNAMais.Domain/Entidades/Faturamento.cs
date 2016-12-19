using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNAMais.Domain.Entidades
{
    [Table("FATURAMENTO", Schema = "DNASITE")]
    public class Faturamento
    {
        #region Propriedades Públicas

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("ID_FATURAMENTO")]
        public int? Id { get; set; }

        [Required]
        [Column("ID_CONTRATO_EMPRESA")]
        public int? IdContratoEmpresa { get; set; }
        [ForeignKey("IdContratoEmpresa")]
        public virtual ContratoEmpresa ContratoEmpresa { get; set; }

        [Required]
        [Column("CD_STATUS_FATURAMENTO")]
        public byte? CodigoStatusFaturamento { get; set; }
        [ForeignKey("CodigoStatusFaturamento")]
        public virtual StatusFaturamento StatusFaturamento { get; set; }

        [Required]
        [Column("DT_INICIO_FATURAMENTO")]
        public DateTime? InicioFaturamento { get; set; }

        [Required]
        [Column("DT_CORTE_FATURAMENTO")]
        public DateTime? CorteFaturamento { get; set; }

        [Required]
        [Column("DT_FATURAMENTO")]
        public DateTime? DataFaturamento { get; set; }

        [Required]
        [Column("QT_CONSULTAS_WEB")]
        public int? ConsultasWeb { get; set; }

        [Required]
        [Column("CD_FAIXA_WEB_APLICADA")]
        public byte? CodigoFaixaWeb { get; set; }

        [Required]
        [Column("DS_FAIXA_WEB_APLICADA")]
        [StringLength(200)]
        public string DescricaoFaixaWeb { get; set; }

        [Required]
        [Column("VL_CONSULTA_ITEM_WEB")]
        public double? ValorConsultaWeb { get; set; }

        [Required]
        [Column("QT_CONSULTAS_WS")]
        public int? ConsultasWs { get; set; }

        [Required]
        [Column("CD_FAIXA_WS_APLICADA")]
        public byte? CodigoFaixaWs { get; set; }

        [Required]
        [Column("DS_FAIXA_WS_APLICADA")]
        [StringLength(200)]
        public string DescricaoFaixaWs { get; set; }

        [Required]
        [Column("VL_CONSULTA_ITEM_WS")]
        public double? ValorConsultaWs { get; set; }

        [Required]
        [Column("QT_CONTAGEM_SOLICITADA")]
        public int? ContagemSolicitada { get; set; }

        [Required]
        [Column("VL_CONTAGEM_SOLICITADA")]
        public double? ValorConsultaSolicitada { get; set; }

        [Required]
        [Column("QT_CONTAGEM_EFETIVADA")]
        public int? ContagemEfetivada { get; set; }

        [Required]
        [Column("VL_CONTAGEM_EFETIVADA")]
        public double? ValorContagemEfetivada { get; set; }

        [Required]
        [Column("VL_TOTAL_FATURAMENTO")]
        public double? TotalFaturamento { get; set; }

        [Column("DT_PAGAMENTO")]
        public DateTime? DataPagamento { get; set; }

        [Column("DT_CANCELAMENTO")]
        public DateTime? DataCancelamento { get; set; }

        [Column("DS_MOTIVO_CANCELAMENTO")]
        [StringLength(200)]
        public string MotivoCancelamento { get; set; }

        public virtual ICollection<ItemFaturamento> ItensFaturamentos { get; set; }
        public virtual ICollection<TransacaoConsulta> TransacoesConsultas { get; set; }
        public virtual ICollection<SolicitacaoContagem> SolicitacoesContagens { get; set; }

        #endregion

        #region Construtor

        public Faturamento()
        {
            ItensFaturamentos = new HashSet<ItemFaturamento>();
            TransacoesConsultas = new HashSet<TransacaoConsulta>();
            SolicitacoesContagens = new HashSet<SolicitacaoContagem>();
        }

        #endregion
    }
}
