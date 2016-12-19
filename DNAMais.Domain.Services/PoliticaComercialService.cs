using DNAMais.Domain.Entidades;
using DNAMais.Framework;
using DNAMais.Infrastructure.Data.Contexts;
using DNAMais.Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNAMais.Domain.Services
{
    public class PoliticaComercialService
    {
        private DNAMaisSiteContext context;

        private Repository<PoliticaComercial> repoPoliticaComercial;

        public PoliticaComercialService()
        {
            context = new DNAMaisSiteContext();
            repoPoliticaComercial = new Repository<PoliticaComercial>(context);
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public PoliticaComercial Consultar()
        {
            return repoPoliticaComercial.FindFirst();
        }
    }
}
