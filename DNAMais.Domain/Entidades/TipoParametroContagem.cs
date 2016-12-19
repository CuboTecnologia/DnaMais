using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNAMais.Domain.Entidades
{
    [Table("TIPO_PARAMETRO_CONTAGEM", Schema = "DNASITE")]
    public class TipoParametroContagem
    {
        #region Propriedades Públicas

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("CD_TIPO_PARAMETRO_CONTAGEM")]
        public byte? Codigo { get; set; }

        [Required]
        [Column("NM_TIPO_PARAMETRO")]
        [StringLength(40)]
        public string TipoParametro { get; set; }

        [Required]
        [Column("CD_TIPO_VALOR")]
        public bool? TipoValor { get; set; }

        public virtual ICollection<SolicitacaoContagemParametro> SolicitacoesContagensParametros { get; set; }

        #endregion

        #region Construtor

        public TipoParametroContagem()
        {
            SolicitacoesContagensParametros = new HashSet<SolicitacaoContagemParametro>();
        }

        #endregion
    }
}
