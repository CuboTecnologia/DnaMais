using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNAMais.Domain.Entidades.Consultas
{
    [Table("ORIGEM_DADOS", Schema = "DNAINFO")]
    public class InfoOrigemDados
    {
        #region Propriedades Públicas

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("ID_ORIGEM_DADOS")]
        public short? Id { get; set; }

        [Column("ID_ORIGEM_DADOS_MIGRACAO")]
        public short? IdMigracao { get; set; }

        [Column("CD_TIPO_ORIGEM")]
        public string TipoOrigem { get; set; }

        [Column("NM_ORIGEM_DADOS")]
        public string Nome { get; set; }

        [Column("DS_ORIGEM_DADOS")]
        public string Descricao { get; set; }

        [Column("NM_ARQUIVO")]
        public string NomeArquivo { get; set; }

        [Column("DT_INCLUSAO")]
        public DateTime? DataInclusao { get; set; }

        [Column("DT_ULTIMA_ATUALIZACAO")]
        public DateTime? DataUltimaAtualizacao { get; set; }

        [Column("DIRETORIO")]
        public string Diretorio { get; set; }

        public virtual ICollection<InfoPessoaFisica> PessoasFisicas { get; set; }
        public virtual ICollection<InfoPessoaFisicaEndereco> EnderecosPessoaFisica { get; set; }
        public virtual ICollection<InfoPessoaFisicaTelefone> TelefonesPessoaFisica { get; set; }

        #endregion

        #region Construtor

        public InfoOrigemDados()
        {
            PessoasFisicas = new HashSet<InfoPessoaFisica>();
            EnderecosPessoaFisica = new HashSet<InfoPessoaFisicaEndereco>();
            TelefonesPessoaFisica = new HashSet<InfoPessoaFisicaTelefone>();
        }

        #endregion
    }
}
