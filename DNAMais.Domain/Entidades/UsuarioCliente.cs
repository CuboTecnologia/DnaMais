using DNAMais.Domain.CustomAttributes;
using DNAMais.Domain.Validacao;
using DNAMais.Domain.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNAMais.Domain.Entidades
{
    [Table("USUARIO_CLIENTE", Schema = "DNASITE")]
    [SequenceOracle("SQ_USUARIO_CLIENTE")]
    public class UsuarioCliente
    {
        #region Propriedades Públicas

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("ID_USUARIO_CLIENTE")]
        public int? Id { get; set; }

        [Required(ErrorMessage="Selecione o Cliente Empresa")]
        [Column("ID_CLIENTE_EMPRESA")]
        [Display(Name="Cliente Empresa")]
        public int? IdClienteEmpresa { get; set; }
        [ForeignKey("IdClienteEmpresa")]
        public virtual ClienteEmpresa ClienteEmpresa { get; set; }

        [Required(ErrorMessage = "Informe o nome")]
        [Display(Name = "Nome")]
        [Column("NM_USUARIO")]
        [StringLength(200)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o login")]
        [Display(Name="Login")]
        [Column("DS_LOGIN")]
        [StringLength(20)]
        public string Login { get; set; }

        [Required(ErrorMessage="Informe a senha")]
        [Display(Name = "Senha")]
        [Column("DS_SENHA")]
        [StringLength(32)]
        public string Senha { get; set; }

        [Required(ErrorMessage="Informe o CPF")]
        [CPFValidation(ErrorMessage="Informe um CPF válido.")]
        [Display(Name = "CPF")]
        [Column("NR_CPF")]
        public string Cpf { get; set; }

        [Required(ErrorMessage="Informe o e-mail.")]
        [EmailValidation(ErrorMessage="Informe um e-mail válido.")]
        [Display(Name = "E-mail")]
        [Column("DS_EMAIL")]
        [StringLength(80)]
        public string Email { get; set; }

        [NotMapped]
        public bool? Master { get; set; }
        [Required]
        [Column("IS_MASTER")]
        public string IsMaster 
        {
            get { return Master.ParseFlag(); }
            protected set { Master = value.ParseFlag(); }
        }

        [NotMapped]
        public bool? ApenasAcessoWs { get; set; }
        [Required]
        [Column("IS_APENAS_ACESSO_WS")]
        public string IsApenasAcessoWs
        {
            get { return ApenasAcessoWs.ParseFlag(); }
            protected set { ApenasAcessoWs = value.ParseFlag(); }
        }

        [NotMapped]
        public bool? Ativo { get; set; }
        [Required]
        [Column("IS_ATIVO")]
        public string IsAtivo
        {
            get { return Ativo.ParseFlag(); }
            protected set { Ativo = value.ParseFlag(); }
        }

        [NotMapped]
        public bool? AlterarSenha { get; set; }
        [Required]
        [Column("IS_ALTERAR_SENHA")]
        public string IsAlterarSenha
        {
            get { return AlterarSenha.ParseFlag(); }
            protected set { AlterarSenha = value.ParseFlag(); }
        }

        [Column("DT_CADASTRO")]
        public DateTime? DataCadastro { get; set; }

        [Column("DT_INICIO_ACESSO")]
        [Display(Name = "Data Início Acesso")]
        public DateTime? DataInicioAcesso { get; set; }

        [Column("DT_TERMINO_ACESSO")]
        [Display(Name = "Data Término Acesso")]
        public DateTime? DataTerminoAcesso { get; set; }

        [Column("NR_SALDO_CONSULTA")]
        [Display(Name = "Saldo de consultas")]
        public int? SaldoConsulta { get; set; }

        [Column("ID_USUARIO_BACKOFFICE_CADASTRO")]
        public int? IdUsuarioBackOfficeCadastro { get; set; }
        [ForeignKey("IdUsuarioBackOfficeCadastro")]
        public virtual UsuarioBackOffice UsuarioBackOffice { get; set; }

        [Column("ID_USUARIO_CLIENTE_CADASTRO")]
        public int? IdUsuarioClienteCadastro { get; set; }

        //Verificar como efetuar o relacionamento
        //(Foreign Key referenciando a própria classe/tabela e pluralização)

        [ForeignKey("IdUsuarioClienteCadastro")]
        public virtual UsuarioCliente UsuarioClienteCadastro { get; set; }

        public virtual ICollection<UsuarioCliente> UsuariosCadastrados { get; set; }
        public virtual ICollection<UsuarioClientePerfil> UsuariosClientesPerfis { get; set; }
        public virtual ICollection<GrupoUsuarioCliente> GruposUsuariosClientes { get; set; }
        public virtual ICollection<UsuarioClienteGrupo> UsuariosClientesGrupos { get; set; }
        public virtual ICollection<TransacaoConsulta> TransacoesConsultas { get; set; }
        public virtual ICollection<SolicitacaoContagem> SolicitacoesContagens { get; set; }
        public virtual ICollection<UsuarioClienteProduto> UsuarioClienteProdutosSelecionados { get; set; }

        #endregion

        #region Construtor

        public UsuarioCliente()
        {
            UsuariosCadastrados = new HashSet<UsuarioCliente>();
            UsuariosClientesPerfis = new HashSet<UsuarioClientePerfil>();
            GruposUsuariosClientes = new HashSet<GrupoUsuarioCliente>();
            UsuariosClientesGrupos = new HashSet<UsuarioClienteGrupo>();
            TransacoesConsultas = new HashSet<TransacaoConsulta>();
            SolicitacoesContagens = new HashSet<SolicitacaoContagem>();
            UsuarioClienteProdutosSelecionados = new HashSet<UsuarioClienteProduto>();
        }

        #endregion
    }
}
