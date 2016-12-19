using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNAMais.Domain.Entidades.Consultas
{
    [Table("PESSOA_JURIDICA", Schema = "DNAINFO")]
    public class InfoPessoaJuridica
    {
        #region Propriedades Públicas

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("ID_PESSOA_JURIDICA")]
        public long? Id { get; set; }

        [Column("NR_CNPJ")]
        public string CNPJ { get; set; }

        [Column("NM_RAZAO_SOCIAL")]
        public string RazaoSocial { get; set; }

        [Column("NM_FANTASIA")]
        public string NomeFantasia { get; set; }

        [Column("CD_TIPO_UNIDADE")]
        public string CodigoTipoUnidade { get; set; }

        [Column("DT_ABERTURA")]
        public DateTime? DataAbertura { get; set; }

        [Column("CD_NATUREZA_JURIDICA")]
        public string CodigoNaturezaJuridica { get; set; }

        [ForeignKey("CodigoNaturezaJuridica")]
        public virtual InfoNaturezaJuridica NaturezaJuridica { get; set; }

        [Column("CD_SITUACAO_CADASTRAL_PJ")]
        public byte? CodigoSituacaoCadastral { get; set; }

        [ForeignKey("CodigoSituacaoCadastral")]
        public virtual InfoSituacaoCadastralPJ SituacaoCadastral { get; set; }

        [Column("DT_SITUACAO_CADASTRAL_PJ")]
        public DateTime? DataSituacaoCadastral { get; set; }

        [Column("DS_MOTIVO_SITUACAO_CADASTRAL")]
        public string MotivoSituacaoCadastral { get; set; }

        [NotMapped]
        public bool? DomiciliadaExterior { get; set; }

        [Column("IS_DOMICILIADA_EXTERIOR")]
        public string DomiciliadaExteriorDescricao
        {
            get { return DomiciliadaExterior ?? false ? "S" : "N"; }
            set { DomiciliadaExterior = value == "S" ? true : false; }
        }

        [Column("DS_SITUACAO_ESPECIAL")]
        public string SituacaoEspecial { get; set; }

        [Column("DT_SITUACAO_ESPECIAL")]
        public DateTime? DataSituacaoEspecial { get; set; }

        [Column("QT_FILIAIS")]
        public int? QuantidadeFiliais { get; set; }

        [Column("CD_PORTE_EMPRESA")]
        public byte? CodigoPorteEmpresa { get; set; }

        [ForeignKey("CodigoPorteEmpresa")]
        public virtual InfoPorteEmpresa PorteEmpresa { get; set; }

        [Column("DS_ENTE_FEDERATIVO_RESPONSAVEL")]
        public string EnteFederativoResponsavel { get; set; }

        [Column("DS_CAPITAL_SOCIAL")]
        public string CapitalSocial { get; set; }

        [Column("VL_FATURAMENTO_ANUAL")]
        public decimal? FaturamentoAnual { get; set; }

        [Column("ID_ORIGEM_DADOS")]
        public short? IdOrigemDados { get; set; }

        [ForeignKey("IdOrigemDados")]
        public virtual InfoOrigemDados OrigemDados { get; set; }

        [Column("DT_INCLUSAO")]
        public DateTime? DataInclusao { get; set; }

        [Column("DT_ULTIMA_ATUALIZACAO")]
        public DateTime? DataUltimaAtualizacao { get; set; }

        public virtual ICollection<InfoPessoaJuridicaEmail> Emails { get; set; }
        public virtual ICollection<InfoPessoaJuridicaEndereco> Enderecos { get; set; }
        public virtual ICollection<InfoPessoaJuridicaTelefone> Telefones { get; set; }

        #endregion

        #region Construtor

        public InfoPessoaJuridica()
        {
            //Emails = new HashSet<InfoPessoaJuridicaEmail>();
            //Enderecos = new HashSet<InfoPessoaJuridicaEndereco>();
            //Telefones = new HashSet<InfoPessoaJuridicaTelefone>();
        }

        #endregion
    }
}
