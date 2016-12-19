using DNAMais.Domain;
using DNAMais.Infrastructure.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNAMais.Infrastructure.Data.Repositories
{
    public class RepositorioUsuario
    {
        DNAMaisSiteContext context;

        public RepositorioUsuario()
        {
            context = new DNAMaisSiteContext();
        }

        //public List<UsuarioBackOffice> ListarTodos()
        //{
        //    return context.BackOfficeUsers.ToList();
        //}

    }
}
