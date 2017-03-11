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
    [Table("TIPO_ENDERECO", Schema = "DNASITE")]
    [SequenceOracle("SQ_TESTE_CLAUDIO")]
//    [SequenceOracle("SQ_TIPO_ENDERECO")]
    public class TipoEndereco
    {
        #region Propriedades Públicas

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("ID_TIPO_ENDERECO")]
        public int? Id { get; set; }

        [Required(ErrorMessage = "Informe o nome.")]
        [Column("NM_TIPO_ENDERECO")]
        [StringLength(20)]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Column("DT_CADASTRO")]
        public DateTime? DataCadastro { get; set; }

        [Column("ID_USUARIO_CADASTRO")]
        public int? IdUsuarioCadastro { get; set; }
        [ForeignKey("IdUsuarioCadastro")]
        public virtual UsuarioBackOffice UsuarioBackOffice { get; set; }

        public virtual ICollection<ClienteEmpresaEndereco> ClientesEmpresasEnderecos { get; set; }

        #endregion

        #region Construtor

        public TipoEndereco()
        {
            ClientesEmpresasEnderecos = new HashSet<ClienteEmpresaEndereco>();
        }

        #endregion
    }
}
