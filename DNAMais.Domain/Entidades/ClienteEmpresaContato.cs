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
    [Table("CLIENTE_EMPRESA_CONTATO", Schema = "DNASITE")]
    [SequenceOracle("SQ_CLIENTE_EMPRESA_CONTATO")]
    public class ClienteEmpresaContato
    {
        #region Propriedades Públicas

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("ID_CLI_EMPRESA_CONTATO")]
        public int? Id { get; set; }

        [Required]
        [Column("ID_CLIENTE_EMPRESA")]
        public int? IdClienteEmpresa { get; set; }
        [ForeignKey("IdClienteEmpresa")]
        public virtual ClienteEmpresa ClienteEmpresa { get; set; }

        [Required]
        [Column("NM_CONTATO")]
        [StringLength(100)]
        public string NomeContato { get; set; }

        [Column("NM_DEPARTAMENTO")]
        [StringLength(60)]
        public string NomeDepartamento { get; set; }

        [Required]
        [Column("ID_TIPO_CONTATO")]
        public int? IdTipoContato { get; set; }
        [ForeignKey("IdTipoContato")]
        public virtual TipoContato TipoContato { get; set; }

        [Required]
        [Column("IS_ATIVO")]
        public bool Ativo { get; set; }

        [Required]
        [Column("DT_CADASTRO")]
        public DateTime? DataCadastro { get; set; }

        [Required]
        [Column("ID_USUARIO_CADASTRO")]
        public int? IdUsuarioCadastro { get; set; }
        [ForeignKey("IdUsuarioCadastro")]
        public virtual UsuarioBackOffice UsuarioBackOffice { get; set; }

        public virtual ICollection<ClienteEmpresaContatoFone> ClientesEmpresasContatosFones { get; set; }
        public virtual ICollection<ClienteEmpresaContatoEmail> ClientesEmpresasContatosEmails { get; set; }

        #endregion

        #region Construtor

        public ClienteEmpresaContato()
        {
            ClientesEmpresasContatosFones = new HashSet<ClienteEmpresaContatoFone>();
            ClientesEmpresasContatosEmails = new HashSet<ClienteEmpresaContatoEmail>();
        }

        #endregion
    }
}
