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
    public class TipoParametroContagemService
    {
        private DNAMaisSiteContext context;

        private Repository<TipoParametroContagem> repoTipoParametroContagem;

        public TipoParametroContagemService()
        {
            context = new DNAMaisSiteContext();
            repoTipoParametroContagem = new Repository<TipoParametroContagem>(context);
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public IQueryable<TipoParametroContagem> ListarTodos()
        {
            return repoTipoParametroContagem.GetAll();
        }

        public TipoParametroContagem ConsultarPorId(byte id)
        {
            return repoTipoParametroContagem.GetById(id);
        }
    }
}
