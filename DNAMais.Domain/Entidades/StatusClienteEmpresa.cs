using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNAMais.Domain.Entidades
{
    [Table("STATUS_CLIENTE_EMPRESA", Schema = "DNASITE")]
    public class StatusClienteEmpresa
    {
        #region Propriedades Públicas

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("CD_STATUS_CLIENTE_EMPRESA")]
        public short? Codigo { get; set; }

        [Required]
        [Column("NM_STATUS_CLIENTE_EMPRESA")]
        [StringLength(30)]
        public string Nome { get; set; }

        public virtual ICollection<ClienteEmpresa> ClientesEmpresas { get; set; }

        #endregion

        #region Construtor

        public StatusClienteEmpresa()
        {
            ClientesEmpresas = new HashSet<ClienteEmpresa>();
        }

        #endregion
    }
}
