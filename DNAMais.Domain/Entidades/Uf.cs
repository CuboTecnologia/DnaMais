using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNAMais.Domain.Entidades
{
    [Table("UF", Schema = "DNASITE")]
    public class Uf
    {
        #region Propriedades Públicas

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("SG_UF")]
        [StringLength(2)]
        public string Sigla { get; set; }

        [Required]
        [Column("NM_UF")]
        [StringLength(60)]
        public string Nome { get; set; }

        public virtual ICollection<ClienteEmpresaEndereco> ClientesEmpresasEnderecos { get; set; }

        #endregion

        #region Construtor

        public Uf()
        {
            ClientesEmpresasEnderecos = new HashSet<ClienteEmpresaEndereco>();
        }

        #endregion
    }
}
