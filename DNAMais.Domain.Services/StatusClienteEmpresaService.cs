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
    public class StatusClienteEmpresaService
    {
        private DNAMaisSiteContext context;

        private Repository<StatusClienteEmpresa> repoStatusClienteEmpresa;

        public StatusClienteEmpresaService()
        {
            context = new DNAMaisSiteContext();
            repoStatusClienteEmpresa = new Repository<StatusClienteEmpresa>(context);
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public IQueryable<StatusClienteEmpresa> ListarTodos()
        {
            return repoStatusClienteEmpresa.GetAll();
        }

        public StatusClienteEmpresa ConsultarPorId(byte id)
        {
            return repoStatusClienteEmpresa.GetById(id);
        }
    }
}
