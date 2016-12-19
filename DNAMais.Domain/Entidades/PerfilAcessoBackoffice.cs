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
    [Table("PERFIL_ACESSO_BACKOFFICE", Schema = "DNASITE")]
    [SequenceOracle("SQ_PERFIL_ACESSO_BACKOFFICE")]
    public class PerfilAcessoBackOffice
    {
        #region Propriedades Públicas

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("ID_PERFIL_ACESSO_BACKOFFICE")]
        public byte? Id { get; set; }

        [Column("NM_PERFIL")]
        [Required(ErrorMessage="Informe o nome")]
        [StringLength(40)]
        public string Nome { get; set; }

        public virtual ICollection<PerfilAcessoFuncionalidade> PerfisFuncionalidades { get; set; }

        #endregion

        #region Construtor

        public PerfilAcessoBackOffice()
        {
            PerfisFuncionalidades = new HashSet<PerfilAcessoFuncionalidade>();
        }

        #endregion
    }
}
