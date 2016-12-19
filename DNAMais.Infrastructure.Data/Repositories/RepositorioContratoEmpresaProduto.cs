using DNAMais.Infrastructure.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNAMais.Infrastructure.Data.Repositories
{
    public class RepositorioContratoEmpresaProduto
    {
        DNAMaisSiteContext context;

        public RepositorioContratoEmpresaProduto()
        {
            context = new DNAMaisSiteContext();
        }
    }
}
