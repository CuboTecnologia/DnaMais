using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNAMais.Domain.Entidades
{
    [Table("ITEM_PRODUTO", Schema = "DNASITE")]
    public class ItemProduto
    {
        #region Propriedades Públicas

        [Key]
        [Required]
        [Column("CD_ITEM_PRODUTO")]
        [StringLength(40)]
        public string Id { get; set; }

        [Required]
        [Column("NM_ITEM_PRODUTO")]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        [Column("DS_ITEM_PRODUTO")]
        [StringLength(200)]
        public string Descricao { get; set; }

        [Required]
        [Column("CD_PRODUTO")]
        [StringLength(20)]
        public string CodigoProduto { get; set; }
        [ForeignKey("CodigoProduto")]
        public virtual Produto Produto { get; set; }

        public virtual ICollection<TransacaoConsulta> TransacoesConsultas { get; set; }
        public virtual ICollection<SolicitacaoContagem> SolicitacoesContagens { get; set; }

        #endregion

        #region Construtor

        public ItemProduto()
        {
            TransacoesConsultas = new HashSet<TransacaoConsulta>();
            SolicitacoesContagens = new HashSet<SolicitacaoContagem>();
        }

        #endregion
    }
}
