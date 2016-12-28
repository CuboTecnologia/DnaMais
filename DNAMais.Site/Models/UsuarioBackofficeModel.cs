using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DNAMais.Site.Models
{
    public class UsuarioBackofficeModel
    {
        public int? Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public bool Admin { get; set; }
        public byte? IdPerfil { get; set; }
        public string PerfilAcessoBackOffice { get; set; }
    }
}