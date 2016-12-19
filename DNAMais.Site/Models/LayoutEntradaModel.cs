using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DNAMais.Site.Models
{
    public sealed class LayoutEntradaModel
    {
        [Key]
        public int Codigo { get; set; }
        [Required]
        public string Nome { get; set; }
    }
}