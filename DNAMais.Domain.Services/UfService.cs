using System.Linq;
using DNAMais.Domain.Entidades;
using DNAMais.Infrastructure.Data.Contexts;
using DNAMais.Infrastructure.Data.Repositories;

namespace DNAMais.Domain.Services
{
    public class UfService
    {
        private DNAMaisSiteContext context;

        private Repository<Uf> repoUf;

        public UfService()
        {
            context = new DNAMaisSiteContext();
            repoUf = new Repository<Uf>(context);
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public IQueryable<Uf> ListarTodos()
        {
            return repoUf.GetAll();
        }

        public Uf ConsultarPorSigla(string sigla)
        {
            return repoUf.GetById(sigla);
        }
    }
}
