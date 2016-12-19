using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNAMais.Domain.Entidades.Consultas
{
    [Table("PESSOA_FISICA_EMAIL", Schema = "DNAINFO")]
    public class InfoPessoaFisicaEmail
    {
        #region Propriedades Públicas

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("ID_PESSOA_FISICA_EMAIL")]
        public long? Id { get; set; }

        [Column("ID_PESSOA_FISICA")]
        public long? IdPessoaFisica { get; set; }
        [ForeignKey("IdPessoaFisica")]
        public virtual InfoPessoaFisica PessoaFisica { get; set; }

        [Column("DS_EMAIL")]
        public string Email { get; set; }

        [Column("ID_ORIGEM_DADOS")]
        public short? IdOrigemDados { get; set; }
        [ForeignKey("IdOrigemDados")]
        public virtual InfoOrigemDados OrigemDados { get; set; }

        [Column("DT_INCLUSAO")]
        public DateTime? DataInclusao { get; set; }

        [Column("DT_ULTIMA_ATUALIZACAO")]
        public DateTime? DataUltimaAtualizacao { get; set; }

        #endregion

        #region Construtor

        public InfoPessoaFisicaEmail()
        {

        }

        #endregion
    }
}
