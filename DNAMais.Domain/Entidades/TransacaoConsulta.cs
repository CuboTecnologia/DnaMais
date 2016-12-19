using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DNAMais.Domain.CustomAttributes;

namespace DNAMais.Domain.Entidades
{
    [Table("TRANSACAO_CONSULTA", Schema = "DNASITE")]
    [SequenceOracle("SQ_TRANSACAO_CONSULTA")]
    public class TransacaoConsulta
    {
        #region Propriedades Públicas

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("ID_TRANSACAO_CONSULTA")]
        public int? Id { get; set; }

        [Column("ID_CLIENTE_EMPRESA")]
        public int? IdClienteEmpresa { get; set; }
        [ForeignKey("IdClienteEmpresa")]
        public virtual ClienteEmpresa ClienteEmpresa { get; set; }

        [Column("ID_CONTRATO_EMPRESA")]
        public int? IdContratoEmpresa { get; set; }
        [ForeignKey("IdContratoEmpresa")]
        public virtual ContratoEmpresa ContratoEmpresa { get; set; }

        [Column("ID_USUARIO_CLIENTE")]
        public int? IdUsuarioCliente { get; set; }
        [ForeignKey("IdUsuarioCliente")]
        public virtual UsuarioCliente UsuarioCliente { get; set; }

        [Column("CD_ITEM_PRODUTO")]
        public string CodigoItemProduto { get; set; }
        [ForeignKey("CodigoItemProduto")]
        public virtual ItemProduto ItemProduto { get; set; }

        [NotMapped]
        public bool? DadosEncontrados { get; set; }

        [Column("IS_DADOS_ENCONTRADOS")]
        public string DadosEncontradosDescricao
        {
            get { return DadosEncontrados ?? false ? "S" : "N"; }
            set { DadosEncontrados = value == "S" ? true : false; }
        }
        
        [Column("DT_TRANSACAO")]
        public DateTime? DataTransacao { get; set; }

        [NotMapped]
        public bool? Faturada { get; set; }

        [Column("IS_FATURADA")]
        public string FaturadaDescricao
        {
            get { return Faturada ?? false ? "S" : "N"; }
            set { Faturada = value == "S" ? true : false; }
        }

        [Column("ID_FATURAMENTO")]
        public int? IdFaturamento { get; set; }
        [ForeignKey("IdFaturamento")]
        public virtual Faturamento Faturamento { get; set; }

        #endregion

        #region Construtor

        public TransacaoConsulta()
        {
        }

        #endregion
    }

}
