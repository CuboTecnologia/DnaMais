using DNAMais.Domain.CustomAttributes;
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
    [Table("CLIENTE_EMPRESA", Schema = "DNASITE")]
    [SequenceOracle("SQ_CLIENTE_EMPRESA")]
    public class ClienteEmpresa
    {
        #region Propriedades Públicas

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("ID_CLIENTE_EMPRESA")]
        public int? Id { get; set; }

        [Required(ErrorMessage="Informe o CNPJ.")]
        [Column("NR_CNPJ")]
        [CNPJValidation(ErrorMessage="Informe um CNPJ válido.")]
        public string Cnpj { get; set; }

        [Required(ErrorMessage = "Insira uma Razão Social")]
        [Column("NM_RAZAO_SOCIAL")]
        [StringLength(100)]
        [Display(Name = "Razão Social")]
        public string RazaoSocial { get; set; }

        [Required(ErrorMessage = "Insira um Nome Fantasia")]
        [Column("NM_FANTASIA")]
        [StringLength(100)]
        [Display(Name = "Nome Fantasia")]
        public string NomeFantasia { get; set; }

        [Required(ErrorMessage = "Insira o nome da pasta de FTP")]
        [Column("NM_PASTA_FTP")]
        [StringLength(30)]
        [Display(Name = "Nome pasta FTP")]
        public string NomePastaFtp { get; set; }

        [Column("ID_RAMO_ATIVIDADE")]
        [Display(Name = "Ramo de Atividade")]
        public int? IdRamoAtividade { get; set; }
        [ForeignKey("IdRamoAtividade")]
        public virtual RamoAtividade RamoAtividade { get; set; }

        [Column("CD_STATUS_CLIENTE_EMPRESA")]
        public short? CodigoStatus { get; set; }
        [ForeignKey("CodigoStatus")]
        public virtual StatusClienteEmpresa StatusClienteEmpresa { get; set; }

        [Column("DT_CADASTRO")]
        public DateTime? DataCadastro { get; set; }

        [Column("ID_USUARIO_CADASTRO")]
        public int? IdUsuarioCadastro { get; set; }
        [ForeignKey("IdUsuarioCadastro")]
        public virtual UsuarioBackOffice UsuarioBackOffice { get; set; }

        public virtual ICollection<ClienteEmpresaEndereco> ClientesEmpresasEnderecos { get; set; }
        public virtual ICollection<ClienteEmpresaContato> ClientesEmpresasContatos { get; set; }
        public virtual ICollection<ContratoEmpresa> ContratosEmpresas { get; set; }
        public virtual ICollection<UsuarioCliente> UsuariosClientes { get; set; }
        public virtual ICollection<GrupoUsuarioCliente> GruposUsuariosClientes { get; set; }
        public virtual ICollection<TransacaoConsulta> TransacoesConsultas { get; set; }
        public virtual ICollection<SolicitacaoContagem> SolicitacoesContagens { get; set; }

        #endregion

        #region Construtor

        public ClienteEmpresa()
        {
            ClientesEmpresasEnderecos = new HashSet<ClienteEmpresaEndereco>();
            ClientesEmpresasContatos = new HashSet<ClienteEmpresaContato>();
            ContratosEmpresas = new HashSet<ContratoEmpresa>();
            UsuariosClientes = new HashSet<UsuarioCliente>();
            GruposUsuariosClientes = new HashSet<GrupoUsuarioCliente>();
            TransacoesConsultas = new HashSet<TransacaoConsulta>();
            SolicitacoesContagens = new HashSet<SolicitacaoContagem>();
        }

        #endregion
    }
}
