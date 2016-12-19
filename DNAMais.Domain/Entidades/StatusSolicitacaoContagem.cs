using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNAMais.Domain.Entidades
{
    [Table("STATUS_SOLICITACAO_CONTAGEM", Schema = "DNASITE")]
    public class StatusSolicitacaoContagem
    {
        #region Propriedades Públicas

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("CD_STATUS_SOLICITACAO_CONTAGEM")]
        public byte? Codigo { get; set; }

        [Required]
        [StringLength(30)]
        [Column("NM_STATUS")]
        public string Nome { get; set; }

        public virtual ICollection<SolicitacaoContagem> SolicitacoesContagens { get; set; }

        #endregion

        #region Construtor

        public StatusSolicitacaoContagem()
        {
            SolicitacoesContagens = new HashSet<SolicitacaoContagem>();
        }

        #endregion
    }
}
