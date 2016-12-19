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
    public class StatusFaturamentoService
    {
        private DNAMaisSiteContext context;

        private Repository<StatusFaturamento> repoStatusFaturamento;

        public StatusFaturamentoService()
        {
            context = new DNAMaisSiteContext();
            repoStatusFaturamento = new Repository<StatusFaturamento>(context);
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public IQueryable<StatusFaturamento> ListarTodos()
        {
            return repoStatusFaturamento.GetAll();
        }

        public StatusFaturamento ConsultarPorId(byte id)
        {
            return repoStatusFaturamento.GetById(id);
        }
    }
}
