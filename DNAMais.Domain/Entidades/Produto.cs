using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNAMais.Domain.Entidades
{
    [Table("PRODUTO", Schema = "DNASITE")]
    public class Produto
    {
        #region Propriedades Públicas

        [Key]
        [Column("CD_PRODUTO")]
        [StringLength(20)]
        [Display(Name = "Código")]
        public string Id { get; set; }

        [Column("NM_PRODUTO")]
        [StringLength(100)]
        [Display(Name="Nome")]
        public string Nome { get; set; }

        [Required]
        [Column("DS_PRODUTO")]
        [Display(Name = "Descrição")]
        [StringLength(200)]
        public string Descricao { get; set; }

        [Column("CD_CATEGORIA_PRODUTO")]
        [StringLength(10)]
        public string CodigoCategoria { get; set; }
        [ForeignKey("CodigoCategoria")]
        public virtual CategoriaProduto CategoriaProduto { get; set; }

        public virtual ICollection<ItemProduto> ItensProdutos { get; set; }
        public virtual ICollection<ContratoEmpresaProduto> ContratosEmpresasProdutos { get; set; }

        #endregion

        #region Construtor

        public Produto()
        {
            ItensProdutos = new HashSet<ItemProduto>();
            ContratosEmpresasProdutos = new HashSet<ContratoEmpresaProduto>();
        }

        #endregion
    }
}
