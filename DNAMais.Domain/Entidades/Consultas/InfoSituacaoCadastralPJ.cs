using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DNAMais.Domain.Entidades.Consultas
{
    [Table("SITUACAO_CADASTRAL_PJ", Schema = "DNAINFO")]
    public class InfoSituacaoCadastralPJ
    {
        #region Propriedades Públicas

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("CD_SITUACAO_CADASTRAL_PJ")]
        public byte? Id { get; set; }

        [Column("DS_SITUACAO_CADASTRAL_PJ")]
        public string Descricao { get; set; }

        [Column("DT_INCLUSAO")]
        public DateTime? DataInclusao { get; set; }

        [Column("DT_ULTIMA_ATUALIZACAO")]
        public DateTime? DataUltimaAtualizacao { get; set; }

        public virtual ICollection<InfoPessoaJuridica> PessoasJuridicas { get; set; }

        #endregion

        #region Construtor

        public InfoSituacaoCadastralPJ()
        {
            PessoasJuridicas = new HashSet<InfoPessoaJuridica>();
        }

        #endregion
    }
}
