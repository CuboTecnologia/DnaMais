using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DNAMais.Domain.Entidades.Consultas
{
    [Table("TIPO_TELEFONE", Schema = "DNAINFO")]
    public class InfoTipoTelefone
    {
        #region Propriedades Públicas

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("ID_TIPO_TELEFONE")]
        public byte? Id { get; set; }

        [Column("DS_TIPO_TELEFONE")]
        public string Descricao { get; set; }

        [Column("DT_INCLUSAO")]
        public DateTime? DataInclusao { get; set; }

        [Column("DT_ULTIMA_ATUALIZACAO")]
        public DateTime? DataUltimaAtualizacao { get; set; }

        public virtual ICollection<InfoPessoaFisicaTelefone> TelefonesPessoaFisica { get; set; }

        #endregion

        #region Construtor

        public InfoTipoTelefone()
        {
            TelefonesPessoaFisica = new HashSet<InfoPessoaFisicaTelefone>();
        }

        #endregion
    }
}
