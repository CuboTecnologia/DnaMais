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
    [Table("CLIENTE_EMPRESA_CONTATO_EMAIL", Schema = "DNASITE")]
    [SequenceOracle("SQ_CLIENTE_EMPRE_CONTATO_EMAIL")]
    public class ClienteEmpresaContatoEmail
    {
        #region Propriedades Públicas

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("ID_CLI_EMPRESA_CONTATO_EMAIL")]
        public int? Id { get; set; }

        [Required]
        [Column("ID_CLI_EMPRESA_CONTATO")]
        public int? IdClienteEmpresaContato { get; set; }
        [ForeignKey("IdClienteEmpresaContato")]
        public virtual ClienteEmpresaContato ClienteEmpresaContato { get; set; }

        [Required]
        [Column("DS_EMAIL")]
        [StringLength(80)]
        public string Email { get; set; }

        [Column("DS_OBSERVACAO")]
        [StringLength(1000)]
        public string Observacao { get; set; }

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

        public ClienteEmpresaContatoEmail()
        {

        }

        #endregion
    }
}
