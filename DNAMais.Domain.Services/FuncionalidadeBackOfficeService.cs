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
    public class FuncionalidadeBackOfficeService
    {
        private DNAMaisSiteContext context;

        private Repository<FuncionalidadeBackOffice> repoFuncionalidadeBackOffice;

        public FuncionalidadeBackOfficeService()
        {
            context = new DNAMaisSiteContext();
            repoFuncionalidadeBackOffice = new Repository<FuncionalidadeBackOffice>(context);
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public IQueryable<FuncionalidadeBackOffice> ListarTodos()
        {
            return repoFuncionalidadeBackOffice.GetAll();
        }

        public FuncionalidadeBackOffice ConsultarPorId(string id)
        {
            return repoFuncionalidadeBackOffice.GetById(id);
        }
    }
}
