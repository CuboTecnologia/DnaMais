using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNAMais.Domain.Entidades
{
    [Table("USUARIO_CLIENTE_GRUPO", Schema = "DNASITE")]
    public class UsuarioClienteGrupo
    {
        #region Propriedades Públicas

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("ID_USUARIO_CLIENTE", Order = 1)]
        public int? IdUsuarioCliente { get; set; }
        [ForeignKey("IdUsuarioCliente")]
        public virtual UsuarioCliente UsuarioCliente { get; set; }

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("ID_GRUPO_USUARIO_CLIENTE", Order = 2)]
        public int? IdGrupoUsuarioCliente { get; set; }
        [ForeignKey("IdGrupoUsuarioCliente")]
        public virtual GrupoUsuarioCliente GrupoUsuarioCliente { get; set; }

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

        public UsuarioClienteGrupo()
        {

        }

        #endregion
    }
}
