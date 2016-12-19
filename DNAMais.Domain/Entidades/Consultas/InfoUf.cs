using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DNAMais.Domain.Entidades.Consultas
{
    [Table("UF", Schema = "DNAINFO")]
    public class InfoUf
    {
        #region Propriedades Públicas

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("SG_UF")]
        public string Sigla { get; set; }

        [Column("NM_UF")]
        public string Nome { get; set; }

        [Column("DT_INCLUSAO")]
        public DateTime? DataInclusao { get; set; }

        [Column("DT_ULTIMA_ATUALIZACAO")]
        public DateTime? DataUltimaAtualizacao { get; set; }

        public virtual ICollection<InfoPessoaFisicaEndereco> EnderecosPessoaFisica { get; set; }

        #endregion

        #region Construtor

        public InfoUf()
        {
            EnderecosPessoaFisica = new HashSet<InfoPessoaFisicaEndereco>();
        }

        #endregion
    }
}
