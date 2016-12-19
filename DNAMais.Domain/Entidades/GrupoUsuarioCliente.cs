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
    [Table("GRUPO_USUARIO_CLIENTE", Schema = "DNASITE")]
    [SequenceOracle("SQ_GRUPO_USUARIO_CLIENTE")]
    public class GrupoUsuarioCliente
    {
        #region Propriedades Públicas

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("ID_GRUPO_USUARIO_CLIENTE")]
        public int? Id { get; set; }

        [Required(ErrorMessage="Selecione a Empresa Cliente")]
        [Display(Name="Cliente Empresa")]
        [Column("ID_CLIENTE_EMPRESA")]
        public int? IdClienteEmpresa { get; set; }
        [ForeignKey("IdClienteEmpresa")]
        public virtual ClienteEmpresa ClienteEmpresa { get; set; }

        [Required(ErrorMessage="Informe o nome do grupo")]
        [Display(Name = "Nome")]
        [Column("NM_GRUPO")]
        [StringLength(40)]
        public string Nome { get; set; }

        [Required(ErrorMessage="Informe a descrição do grupo")]
        [Display(Name = "Descrição")]
        [Column("DS_GRUPO")]
        [StringLength(200)]
        public string Descricao { get; set; }

        [Column("DT_CADASTRO")]
        public DateTime? DataCadastro { get; set; }

        [Column("ID_USUARIO_BACKOFFICE_CADASTRO")]
        public int? IdUsuarioBackOfficeCadastro { get; set; }
        [ForeignKey("IdUsuarioBackOfficeCadastro")]
        public virtual UsuarioBackOffice UsuarioBackOffice { get; set; }

        [Column("ID_USUARIO_CLIENTE_CADASTRO")]
        public int? IdUsuarioClienteCadastro { get; set; }
        [ForeignKey("IdUsuarioClienteCadastro")]
        public virtual UsuarioCliente UsuarioCliente { get; set; }

        public virtual ICollection<UsuarioClienteGrupo> UsuariosClientesGrupos { get; set; }

        #endregion

        #region Construtor

        public GrupoUsuarioCliente()
        {
            UsuariosClientesGrupos = new HashSet<UsuarioClienteGrupo>();
        }

        #endregion
    }
}
