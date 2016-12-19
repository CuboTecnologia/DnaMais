using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DNAMais.Domain.Entidades.Consultas
{
    [Table("SITUACAO_CADASTRAL_PF", Schema = "DNAINFO")]
    public class InfoSituacaoCadastralPF
    {
        #region Propriedades Públicas

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("CD_SITUACAO_CADASTRAL_PF")]
        public byte? Id { get; set; }

        [Column("DS_SITUACAO_CADASTRAL_PF")]
        public string Descricao { get; set; }

        [Column("DT_INCLUSAO")]
        public DateTime? DataInclusao { get; set; }

        [Column("DT_ULTIMA_ATUALIZACAO")]
        public DateTime? DataUltimaAtualizacao { get; set; }

        public virtual ICollection<InfoPessoaFisica> PessoasFisicas { get; set; }

        #endregion

        #region Construtor

        public InfoSituacaoCadastralPF()
        {
            PessoasFisicas = new HashSet<InfoPessoaFisica>();
        }

        #endregion
    }
}
