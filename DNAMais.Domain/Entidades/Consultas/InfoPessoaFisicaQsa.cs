using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNAMais.Domain.Entidades.Consultas
{
    [Table("VW_PESSOA_JURIDICA_QSA", Schema = "DNAINFO")]
    public class InfoPessoaFisicaQsa
    {
        #region Propriedades Públicas

        [Column("ID_PESSOA_JURIDICA_QSA")]
        public long? Id { get; set; }

        [Column("ID_PESSOA_JURIDICA")]
        public long? IdPessoaJuridica { get; set; }

        [Column("NR_CNPJ")]
        public string CNPJ { get; set; }

        [Column("NR_DOCUMENTO_SOCIO")]
        public string DocumentoSocio { get; set; }

        [Column("NM_NOME_SOCIO")]
        public string NomeSocio { get; set; }

        [Column("DS_QUALIFICACAO")]
        public string Qualificacao { get; set; }

        [Column("DT_DATA_ENTRADA_SOCIEDADE")]
        public DateTime? DataEntradaSociedade { get; set; }

        [Column("VL_VALOR_PARTICIPACAO")]
        public string ValorParticipacao { get; set; }

        [Column("DS_ARQUIVO")]
        public string Arquivo { get; set; }

        [Column("NR_ID_TABLE")]
        public int? IdTable { get; set; }

        [Column("NR_OLD_SOCIO")]
        public int? OldSocio { get; set; }

        [Column("DT_CONSULTA")]
        public DateTime? DataConsulta { get; set; }

        [Column("NR_ORDEM_SOC")]
        public int? OrdemSocio { get; set; }

        [Column("NR_FLAG")]
        public int? Flag { get; set; }

        [Column("NM_RAZAO_SOCIAL")]
        public string RazaoSocial { get; set; }

        [Column("NM_FANTASIA")]
        public string NomeFantasia { get; set; }

        #endregion

        #region Construtor

        public InfoPessoaFisicaQsa()
        {
        }

        #endregion
    }
}
