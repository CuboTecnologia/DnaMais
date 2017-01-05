using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNAMais.Domain.Entidades.Consultas
{
    [Table("PESSOA_FISICA", Schema = "DNAINFO")]
    public class InfoPessoaFisica
    {
        #region Propriedades Públicas

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("ID_PESSOA_FISICA")]
        public long? Id { get; set; }

        [Column("NR_CPF")]
        public string Cpf { get; set; }

        [Column("NM_COMPLETO")]
        public string NomeCompleto { get; set; }

        [Column("NM_MAE")]
        public string NomeMae { get; set; }

        [Column("DT_NASCIMENTO")]
        public DateTime? DataNascimento { get; set; }

        [Column("NR_IDADE")]
        public long? Idade { get; set; }

        [Column("SG_SEXO")]
        public string Sexo { get; set; }

        [Column("CD_SITUACAO_CADASTRAL_PF")]
        public byte? CodigoSituacaoCadastral { get; set; }

        [ForeignKey("CodigoSituacaoCadastral")]
        public virtual InfoSituacaoCadastralPF SituacaoCadastral { get; set; }

        [Column("ID_ORIGEM_DADOS")]
        public short? IdOrigemDados { get; set; }

        [ForeignKey("IdOrigemDados")]
        public virtual InfoOrigemDados OrigemDados { get; set; }

        [Column("DT_INCLUSAO")]
        public DateTime? DataInclusao { get; set; }

        [Column("DT_ULTIMA_ATUALIZACAO")]
        public DateTime? DataUltimaAtualizacao { get; set; }

        public virtual InfoPessoaFisicaComplementar DadosComplementares { get; set; }
        public virtual InfoPessoaFisicaProfissional DadosProfissionais { get; set; }

        public virtual ICollection<InfoPessoaFisicaEmail> Emails { get; set; }
        public virtual ICollection<InfoPessoaFisicaEndereco> Enderecos { get; set; }
        public virtual ICollection<InfoPessoaFisicaTelefone> Telefones { get; set; }
        public virtual ICollection<InfoPessoaFisicaQsa> Qsa { get; set; }

        #endregion

        #region Construtor

        public InfoPessoaFisica()
        {
            //Emails = new HashSet<InfoPessoaFisicaEmail>();
            //Enderecos = new HashSet<InfoPessoaFisicaEndereco>();
            //Telefones = new HashSet<InfoPessoaFisicaTelefone>();
        }

        #endregion
    }
}
