using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNAMais.Domain.Entidades
{
    [Table("USUARIO_CLIENTE_PERFIL", Schema = "DNASITE")]
    public class UsuarioClientePerfil
    {
        #region Propriedades Públicas

        [Key]
        [Required]
        [Column("ID_USUARIO_CLIENTE", Order = 1)]
        public int? IdUsuarioCliente { get; set; }
        [ForeignKey("IdUsuarioCliente")]
        public virtual UsuarioCliente UsuarioCliente { get; set; }

        [Key]
        [Required]
        [Column("ID_PERFIL_USUARIO_CLIENTE", Order = 2)]
        public int? IdPerfilUsuarioCliente { get; set; }
        [ForeignKey("IdPerfilUsuarioCliente")]
        public virtual PerfilUsuarioCliente PerfilUsuarioCliente { get; set; }

        [Required]
        [Column("DT_CADASTRO")]
        public DateTime? DataCadastro { get; set; }

        [Required]
        [Column("ID_USUARIO_BACKOFFICE_CADASTRO")]
        public int? IdUsuarioBackOfficeCadastro { get; set; }
        [ForeignKey("IdUsuarioBackOfficeCadastro")]
        public virtual UsuarioBackOffice UsuarioBackOffice { get; set; }

        [Required]
        [Column("ID_USUARIO_CLIENTE_CADASTRO")]
        public int? IdUsuarioClienteCadastro { get; set; }
        [ForeignKey("IdUsuarioClienteCadastro")]
        public virtual UsuarioCliente UsuarioClienteCadastro { get; set; }

        #endregion

        #region Construtor

        public UsuarioClientePerfil()
        {

        }

        #endregion
    }
}
