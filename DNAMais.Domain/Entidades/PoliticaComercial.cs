using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNAMais.Domain.Entidades
{
    [Table("POLITICA_COMERCIAL", Schema = "DNASITE")]
    public class PoliticaComercial
    {
        #region Propriedades Públicas

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("ID_POLITICA_COMERCIAL")]
        public int? Id { get; set; }

        [Required]
        [Column("VL_SOLICITACAO_CONTAGEM")]
        public int? ValorContagem { get; set; }

        [Required]
        [Column("DT_INICIO_VIGENCIA")]
        public DateTime? InicioVigencia { get; set; }

        [Column("DT_TERMINO_VIGENCIA")]
        public DateTime? TerminoVigencia { get; set; }

        [Required]
        [Column("IS_VIGENTE")]
        public bool? Vigente { get; set; }

        #endregion

        #region Construtor

        public PoliticaComercial()
        {

        }

        #endregion
    }
}
