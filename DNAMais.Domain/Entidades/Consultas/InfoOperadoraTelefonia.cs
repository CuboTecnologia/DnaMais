using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DNAMais.Domain.Entidades.Consultas
{
    [Table("OPERADORA_TELEFONIA", Schema = "DNAINFO")]
    public class InfoOperadoraTelefonia
    {
        #region Propriedades Públicas

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("CD_OPERADORA_TELEFONIA")]
        public byte? Codigo { get; set; }

        [Column("NM_OPERADORA_TELEFONIA")]
        public string Descricao { get; set; }

        [Column("DT_INCLUSAO")]
        public DateTime? DataInclusao { get; set; }

        [Column("DT_ULTIMA_ATUALIZACAO")]
        public DateTime? DataUltimaAtualizacao { get; set; }

        public virtual ICollection<InfoPessoaJuridicaTelefone> TelefonesPessoaJuridica { get; set; }

        #endregion

        #region Construtor

        public InfoOperadoraTelefonia()
        {
            TelefonesPessoaJuridica = new HashSet<InfoPessoaJuridicaTelefone>();
        }

        #endregion
    }
}
