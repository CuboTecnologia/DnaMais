using DNAMais.Domain.CustomAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DNAMais.Domain.Extensions;

namespace DNAMais.Domain.Entidades
{
    [Table("MENSAGEM_CONTATO", Schema = "DNASITE")]
    [SequenceOracle("SQ_MENSAGEM_CONTATO")]
    public class MensagemContato
    {
        #region Propriedades Públicas

        [Key]
        [Column("ID_MENSAGEM_CONTATO")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Index("TS_DNASITE_INDEX")]
        public int? Id { get; set; }

        [Required]
        [Column("NM_CONTATO")]
        [Display(Name="Nome")]
        [StringLength(200)]
        public string Nome { get; set; }

        [Required]
        [Column("DS_EMAIL")]
        [Display(Name="E-Mail")]
        [StringLength(80)]
        public string Email { get; set; }

        [Column("DS_ASSUNTO")]
        [Display(Name="Assunto")]
        [StringLength(60)]
        public string Assunto { get; set; }

        [Required]
        [Column("DS_CONTEUDO")]
        [Display(Name="Conteúdo")]
        public string Conteudo { get; set; }

        [Column("DT_REGISTRO")]
        [Display(Name="Data de Registro")]
        public DateTime? DataRegistro { get; set; }

        [NotMapped]
        public bool? Respondida { get; set; }
        [Required]
        [Column("IS_RESPONDIDA")]
        public string MensagemRespondida
        {
            get { return Respondida.ParseFlag(); }
            set { Respondida = value.ParseFlag(); }
        }

        [Column("ID_USUARIO_BACKOFFICE_RESPOSTA")]
        [Index("MENSAGEM_CONTATO_IDX_01")]
        public int? IdUsuarioBackOfficeResposta { get; set; }
        [ForeignKey("IdUsuarioBackOfficeResposta")]
        public virtual UsuarioBackOffice UsuarioBackOffice { get; set; }

        [Column("DT_RESPOSTA")]
        public DateTime? DataResposta { get; set; }

        [Column("DS_RESPOSTA")]
        [StringLength(1000)]
        public string DescricaoResposta { get; set; }

        [Required]
        [Column("DS_TELEFONE")]
        [StringLength(10)]
        public string Telefone { get; set; }

        [Required]
        [Column("DS_CELULAR")]
        [StringLength(11)]
        public string Celular { get; set; }

        #endregion

        #region Construtor

        public MensagemContato()
        {
            
        }

        #endregion
    }
}
