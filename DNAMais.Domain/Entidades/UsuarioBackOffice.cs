using DNAMais.Domain.CustomAttributes;
using DNAMais.Domain.Entidades;
using DNAMais.Domain.Validacao;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNAMais.Domain.Entidades
{
    [Table("USUARIO_BACKOFFICE", Schema = "DNASITE")]
    [SequenceOracle("SQ_USUARIO_BACKOFFICE")]
    public class UsuarioBackOffice
    {
        #region Propriedades Públicas

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("ID_USUARIO_BACKOFFICE")]
        public int? Id { get; set; }

        [Column("NM_USUARIO")]
        [Required(ErrorMessage = "Informe o nome.")]
        [StringLength(200)]
        public string Nome { get; set; }

        [Column("DS_EMAIL")]
        [Required(ErrorMessage = "Informe o e-mail.")]
        [EmailValidation(ErrorMessage="Informe um e-mail válido.")]
        [StringLength(80)]
        public string Email { get; set; }

        [Column("DS_LOGIN")]
        [Required(ErrorMessage = "Informe o login.")]
        [StringLength(20)]
        public string Login { get; set; }

        [Column("DS_SENHA")]
        [Required(ErrorMessage="Informe a senha.")]
        [StringLength(32)]
        public string Senha { get; set; }

        [Column("DT_CRIACAO")]
        public DateTime? DataCriacao { get; set; }

        [NotMapped]
        public bool? Admin { get; set; }

        [Column("IS_ADMIN")]
        public string AdminDescricao
        {
            get { return Admin ?? false ? "S" : "N"; }
            set { Admin = value == "S" ? true : false; }
        }

        [Column("ID_PERFIL_ACESSO_BACKOFFICE")]
        public byte? IdPerfil { get; set; }

        [ForeignKey("IdPerfil")]
        public PerfilAcessoBackOffice PerfilAcessoBackOffice { get; set; }

        public virtual ICollection<MensagemContato> MensagensContatos { get; set; }
        //public virtual ICollection<UsuarioBackOffice> UsuariosBackOffice { get; set; }
        public virtual ICollection<ClienteEmpresa> ClientesEmpresas { get; set; }
        public virtual ICollection<TipoEndereco> TiposEnderecos { get; set; }
        public virtual ICollection<ClienteEmpresaEndereco> ClientesEmpresasEnderecos { get; set; }
        public virtual ICollection<TipoContato> TiposContatos { get; set; }
        public virtual ICollection<ClienteEmpresaContato> ClientesEmpresasContatos { get; set; }
        public virtual ICollection<ClienteEmpresaContatoFone> ClientesEmpresasContatosFones { get; set; }
        public virtual ICollection<ClienteEmpresaContatoEmail> ClientesEmpresasContatosEmails { get; set; }
        public virtual ICollection<ContratoEmpresa> ContratosEmpresas { get; set; }
        public virtual ICollection<UsuarioCliente> UsuariosClientes { get; set; }
        public virtual ICollection<UsuarioClientePerfil> UsuariosClientesPerfis { get; set; }
        public virtual ICollection<GrupoUsuarioCliente> GruposUsuariosClientes { get; set; }
        public virtual ICollection<UsuarioClienteGrupo> UsuariosClientesGrupos { get; set; }

        #endregion

        #region Construtor

        public UsuarioBackOffice()
        {
            MensagensContatos = new HashSet<MensagemContato>();
            //UsuariosBackOffice = new HashSet<UsuarioBackOffice>();
            ClientesEmpresas = new HashSet<ClienteEmpresa>();
            TiposEnderecos = new HashSet<TipoEndereco>();
            ClientesEmpresasEnderecos = new HashSet<ClienteEmpresaEndereco>();
            TiposContatos = new HashSet<TipoContato>();
            ClientesEmpresasContatos = new HashSet<ClienteEmpresaContato>();
            ClientesEmpresasContatosFones = new HashSet<ClienteEmpresaContatoFone>();
            ClientesEmpresasContatosEmails = new HashSet<ClienteEmpresaContatoEmail>();
            ContratosEmpresas = new HashSet<ContratoEmpresa>();
            UsuariosClientes = new HashSet<UsuarioCliente>();
            UsuariosClientesPerfis = new HashSet<UsuarioClientePerfil>();
            GruposUsuariosClientes = new HashSet<GrupoUsuarioCliente>();
            UsuariosClientesGrupos = new HashSet<UsuarioClienteGrupo>();
        }

        #endregion
    }
}