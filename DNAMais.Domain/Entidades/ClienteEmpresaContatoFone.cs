using DNAMais.Domain.CustomAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNAMais.Domain.Entidades
{
    [Table("CLIENTE_EMPRESA_CONTATO_FONE", Schema = "DNASITE")]
    [SequenceOracle("SQ_CLIENTE_EMPRE_CONTATO_FONE")]
    public class ClienteEmpresaContatoFone
    {
        #region Propriedades Públicas

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("ID_CLI_EMPRESA_CONTATO_FONE")]
        public int? Id { get; set; }

        [Required]
        [Column("ID_CLI_EMPRESA_CONTATO")]
        public int? IdClienteEmpresaContato { get; set; }
        [ForeignKey("IdClienteEmpresaContato")]
        public virtual ClienteEmpresaContato ClienteEmpresaContato { get; set; }

        [Required]
        [Column("NR_DDD")]
        public byte? Ddd { get; set; }

        [Required]
        [Column("NR_TELEFONE")]
        public int? Telefone { get; set; }

        [Column("NR_RAMAL")]
        public short? Ramal { get; set; }

        [Column("DS_OBSERVACAO")]
        [StringLength(1000)]
        public string Observacao { get; set; }

        [Required]
        [Column("DT_CADASTRO")]
        public DateTime? DataCadastro { get; set; }

        [Required]
        [Column("ID_USUARIO_CADASTRO")]
        public int? IdUsuarioCadastro { get; set; }
        [ForeignKey("IdUsuarioCadastro")]
        public virtual UsuarioBackOffice UsuarioBackOffice { get; set; }

        #endregion

        #region Construtor

        public ClienteEmpresaContatoFone()
        {

        }

        #endregion

    }
}
