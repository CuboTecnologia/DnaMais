using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DNAMais.Domain.Entidades.Consultas
{
    [Table("TIPO_ENDERECO", Schema = "DNAINFO")]
    public class InfoTipoEndereco
    {
        #region Propriedades Públicas

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("ID_TIPO_ENDERECO")]
        public byte? Id { get; set; }

        [Column("DS_TIPO_ENDERECO")]
        public string Descricao { get; set; }

        [Column("DT_INCLUSAO")]
        public DateTime? DataInclusao { get; set; }

        [Column("DT_ULTIMA_ATUALIZACAO")]
        public DateTime? DataUltimaAtualizacao { get; set; }

        public virtual ICollection<InfoPessoaFisicaEndereco> EnderecosPessoaFisica { get; set; }

        #endregion

        #region Construtor

        public InfoTipoEndereco()
        {
            EnderecosPessoaFisica = new HashSet<InfoPessoaFisicaEndereco>();
        }

        #endregion
    }
}
