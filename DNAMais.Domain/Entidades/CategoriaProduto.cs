using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNAMais.Domain.Entidades
{
    [Table("CATEGORIA_PRODUTO", Schema = "DNASITE")]
    public class CategoriaProduto
    {
        #region Propriedades Públicas

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("CD_CATEGORIA_PRODUTO")]
        [StringLength(10)]
        public string Codigo { get; set; }

        [Required]
        [Column("NM_CATEGORIA_PRODUTO")]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        [Column("CD_TIPO_PRECIFICACAO")]
        public short? CodigoPrecificacao { get; set; }
        [ForeignKey("CodigoPrecificacao")]
        public virtual TipoPrecificacao TipoPrecificacao { get; set; }

        public virtual ICollection<CategoriaProdutoFaixa> CategoriasFaixas { get; set; }
        public virtual ICollection<CategoriaProdutoFaixaLog> LogCategoriasFaixas { get; set; }
        public virtual ICollection<Produto> Produtos { get; set; }
        //CCB public virtual ICollection<ContratoEmpresaPrecificacao> ContratosEmpresasPrecificacoes { get; set; }
        public virtual ICollection<ItemFaturamento> ItensFaturamentos { get; set; }

        #endregion

        #region Construtor

        public CategoriaProduto()
        {
            CategoriasFaixas = new HashSet<CategoriaProdutoFaixa>();
            LogCategoriasFaixas = new HashSet<CategoriaProdutoFaixaLog>();
            Produtos = new HashSet<Produto>();
            //CCB ContratosEmpresasPrecificacoes = new HashSet<ContratoEmpresaPrecificacao>();
            ItensFaturamentos = new HashSet<ItemFaturamento>();
        }

        #endregion
    }
}
