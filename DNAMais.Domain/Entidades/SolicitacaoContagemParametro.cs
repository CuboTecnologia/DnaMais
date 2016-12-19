using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNAMais.Domain.Entidades
{
    [Table("SOLICITACAO_CONTAGEM_PARAM", Schema = "DNASITE")]
    public class SolicitacaoContagemParametro
    {
        #region Propriedades Públicas

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("ID_SOLICITACAO_CONTAGEM", Order = 1)]
        public int? IdSolicitacaoContagem { get; set; }
        [ForeignKey("IdSolicitacaoContagem")]
        public virtual SolicitacaoContagem SolicitacaoContagem { get; set; }

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("CD_TIPO_PARAMETRO_CONTAGEM", Order = 2)]
        public byte? CodigoTipoParametroContagem { get; set; }
        [ForeignKey("CodigoTipoParametroContagem")]
        public virtual TipoParametroContagem TipoParametroContagem { get; set; }

        [Column("VL_PARAMETRO")]
        public double? ValorParametro { get; set; }

        #endregion

        #region Construtor

        public SolicitacaoContagemParametro()
        {

        }

        #endregion
    }
}
