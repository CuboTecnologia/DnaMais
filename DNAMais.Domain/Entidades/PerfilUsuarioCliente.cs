using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNAMais.Domain.Entidades
{
    [Table("PERFIL_USUARIO_CLIENTE", Schema = "DNASITE")]
    public class PerfilUsuarioCliente
    {
        #region Propriedades Públicas

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("ID_PERFIL_USUARIO_CLIENTE")]
        public int? Id { get; set; }

        [Required]
        [Column("NM_PERFIL")]
        [StringLength(60)]
        public string Nome { get; set; }

        [Required]
        [Column("DS_PERFIL")]
        [StringLength(100)]
        public string Descricao { get; set; }

        public virtual ICollection<UsuarioClientePerfil> UsuariosClientesPerfis { get; set; }

        #endregion

        #region Construtor

        public PerfilUsuarioCliente()
        {
            UsuariosClientesPerfis = new HashSet<UsuarioClientePerfil>();
        }

        #endregion
    }
}
