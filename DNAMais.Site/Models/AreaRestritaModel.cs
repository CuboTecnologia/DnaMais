using DNAMais.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DNAMais.Site.Models
{
    public class AreaRestritaModel
    {
        public bool HabilitaConsultaPF { get; set; }
        public bool HabilitaConsultaPJ { get; set; }
        public bool HabilitaConsultaFTP { get; set; }
        public bool HabilitaConsultaVeiculo { get; set; }

        public UsuarioCliente UsuarioCliente { get; set; }
    }
}