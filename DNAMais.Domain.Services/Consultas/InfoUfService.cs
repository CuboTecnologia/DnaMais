using System.Linq;
using DNAMais.Domain.Entidades;
using DNAMais.Domain.Entidades.Consultas;
using DNAMais.Infrastructure.Data.Contexts;
using DNAMais.Infrastructure.Data.Repositories;

namespace DNAMais.Domain.Services.Consultas
{
    public class InfoUfService
    {
        private DNAMaisSiteContext context;

        private Repository<InfoUf> repoUf;

        public InfoUfService()
        {
            context = new DNAMaisSiteContext();
            repoUf = new Repository<InfoUf>(context);
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public IQueryable<InfoUf> ListarTodos()
        {
            return repoUf.GetAll();
        }

        public InfoUf ConsultarPorSigla(string sigla)
        {
            return repoUf.GetById(sigla);
        }
    }
}
