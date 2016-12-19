using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNAMais.Domain.Entidades
{
    [Table("SOLICITACAO_CONTAGEM", Schema = "DNASITE")]
    public class SolicitacaoContagem
    {
        #region Propriedades Públicas

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("ID_SOLICITACAO_CONTAGEM")]
        public int? Id { get; set; }

        [Required]
        [Column("ID_CLIENTE_EMPRESA")]
        public int? IdClienteEmpresa { get; set; }
        [ForeignKey("IdClienteEmpresa")]
        public virtual ClienteEmpresa ClienteEmpresa { get; set; }

        [Required]
        [Column("ID_CONTRATO_EMPRESA")]
        public int? IdContratoEmpresa { get; set; }
        [ForeignKey("IdContratoEmpresa")]
        public virtual ContratoEmpresa ContratoEmpresa { get; set; }

        [Required]
        [Column("ID_USUARIO_CLIENTE")]
        public int? IdUsuarioCliente { get; set; }
        [ForeignKey("IdUsuarioCliente")]
        public virtual UsuarioCliente UsuarioCliente { get; set; }

        [Required]
        [Column("CD_ITEM_PRODUTO")]
        public string CodigoItemProduto { get; set; }
        [ForeignKey("CodigoItemProduto")]
        public virtual ItemProduto ItemProduto { get; set; }

        [Required]
        [Column("CD_STATUS_SOLICITACAO_CONTAGEM")]
        public byte? CodigoStatusContagem { get; set; }
        [ForeignKey("CodigoStatusContagem")]
        public virtual StatusSolicitacaoContagem StatusSolicitacaoContagem { get; set; }

        [Required]
        [Column("DT_SOLICITACAO")]
        public DateTime? DataSolicitacao { get; set; }

        [Required]
        [Column("DT_CONTAGEM")]
        public DateTime? DataContagem { get; set; }

        [Column("NR_PROTOCOLO_CONTAGEM")]
        public int? ProtocoloContagem { get; set; }

        [Column("QT_CONTAGEM")]
        public int? Contagem { get; set; }

        [Column("DT_LIMITE_EFETIVACAO")]
        public DateTime? DataEfetivacao { get; set; }

        [Required]
        [Column("IS_AUTORIZADA")]
        public bool? Autorizada { get; set; }

        [Required]
        [Column("IS_FATURADA")]
        public bool? Faturada { get; set; }

        [Column("ID_FATURAMENTO")]
        public int? IdFaturamento { get; set; }
        [ForeignKey("IdFaturamento")]
        public virtual Faturamento Faturamento { get; set; }

        public virtual ICollection<SolicitacaoContagemParametro> SolicitacoesContagensParametros { get; set; }

        #endregion

        #region Construtor

        public SolicitacaoContagem()
        {
            SolicitacoesContagensParametros = new HashSet<SolicitacaoContagemParametro>();
        }

        #endregion
    }
}
