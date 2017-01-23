using DNAMais.Domain.CustomAttributes;
using DNAMais.Domain.Validacao;
using DNAMais.Domain.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNAMais.Domain.Entidades
{
    [Table("USUARIO_CLIENTE_PRODUTO", Schema = "DNASITE")]
    public class UsuarioClienteProduto
    {
        #region Propriedades Públicas

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("ID_USUARIO_CLIENTE", Order=1)]
        public int? Id { get; set; }

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("ID_CONTRATO_EMPRESA", Order=2)]
        public int? IdContratoEmpresa { get; set; }
        [ForeignKey("IdContratoEmpresa")]
        public virtual ContratoEmpresa ContratoEmpresa { get; set; }

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("CD_PRODUTO", Order=3)]
        [StringLength(20)]
        public string CodigoProduto { get; set; }
        [ForeignKey("CodigoProduto")]
        public virtual Produto Produto { get; set; }

        [Column("DT_CADASTRO")]
        public DateTime? DataCadastro { get; set; }

        [Column("ID_USUARIO_BACKOFFICE_CADASTRO")]
        public int? IdUsuarioBackOfficeCadastro { get; set; }
        [ForeignKey("IdUsuarioBackOfficeCadastro")]
        public virtual UsuarioBackOffice UsuarioBackOffice { get; set; }

        #endregion

        #region Construtor

        public UsuarioClienteProduto()
        {

        }

        #endregion
    }
}
