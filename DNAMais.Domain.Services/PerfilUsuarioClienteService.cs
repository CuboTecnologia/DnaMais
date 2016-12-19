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
    public class PerfilUsuarioClienteService
    {
        private DNAMaisSiteContext context;

        private Repository<PerfilUsuarioCliente> repoPerfilUsuarioCliente;

        public PerfilUsuarioClienteService()
        {
            context = new DNAMaisSiteContext();
            repoPerfilUsuarioCliente = new Repository<PerfilUsuarioCliente>(context);
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public IQueryable<PerfilUsuarioCliente> ListarTodos()
        {
            return repoPerfilUsuarioCliente.GetAll();
        }

        public PerfilUsuarioCliente ConsultarPorId(byte id)
        {
            return repoPerfilUsuarioCliente.GetById(id);
        }
    }
}
