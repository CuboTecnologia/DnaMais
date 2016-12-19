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
    public class StatusSolicitacaoContagemService
    {
        private DNAMaisSiteContext context;

        private Repository<StatusSolicitacaoContagem> repoStatusSolicitacaoContagem;

        public StatusSolicitacaoContagemService()
        {
            context = new DNAMaisSiteContext();
            repoStatusSolicitacaoContagem = new Repository<StatusSolicitacaoContagem>(context);
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public IQueryable<StatusSolicitacaoContagem> ListarTodos()
        {
            return repoStatusSolicitacaoContagem.GetAll();
        }

        public StatusSolicitacaoContagem ConsultarPorId(byte id)
        {
            return repoStatusSolicitacaoContagem.GetById(id);
        }
    }
}
