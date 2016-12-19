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
    [Table("CLIENTE_EMPRESA_ENDERECO", Schema = "DNASITE")]
    [SequenceOracle("SQ_CLIENTE_EMPRESA_ENDERECO")]
    public class ClienteEmpresaEndereco
    {
        #region Propriedades Públicas

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("ID_CLIENTE_EMPRESA_ENDERECO")]
        public int? Id { get; set; }

        [Required]
        [Column("ID_CLIENTE_EMPRESA")]
        public int? IdClienteEmpresa { get; set; }
        [ForeignKey("IdClienteEmpresa")]
        public virtual ClienteEmpresa ClienteEmpresa { get; set; }

        [Required]
        [Column("DS_ENDERECO")]
        [StringLength(100)]
        public string Endereco { get; set; }

        [Column("DS_COMPLEMENTO")]
        [StringLength(30)]
        public string Complemento { get; set; }

        [Required]
        [Column("NM_BAIRRO")]
        [StringLength(60)]
        public string Bairro { get; set; }

        [Required]
        [Column("NM_CIDADE")]
        [StringLength(60)]
        public string Cidade { get; set; }

        [Required]
        [Column("NR_CEP")]
        public int? Cep { get; set; }

        [Required]
        [Column("SG_UF")]
        [StringLength(2)]
        public string SiglaUf { get; set; }
        [ForeignKey("SiglaUf")]
        public virtual Uf Uf { get; set; }

        [Required]
        [Column("ID_TIPO_ENDERECO")]
        public int? IdTipoEndereco { get; set; }
        [ForeignKey("IdTipoEndereco")]
        public virtual TipoEndereco TipoEndereco { get; set; }

        [Required]
        [Column("DT_CADASTRO")]
        public DateTime? DataCadastro { get; set; }

        [Required]
        [Column("ID_USUARIO_CADASTRO")]
        public int? IdUsuarioCadastro { get; set; }
        [ForeignKey("IdUsuarioCadastro")]
        public virtual UsuarioBackOffice UsuarioBackOffice { get; set; }

        #endregion

        #region Construtor

        public ClienteEmpresaEndereco()
        {

        }

        #endregion
    }
}
