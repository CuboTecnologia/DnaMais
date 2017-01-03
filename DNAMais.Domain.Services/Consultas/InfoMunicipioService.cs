using System.Linq;
using DNAMais.Domain.Entidades;
using DNAMais.Domain.Entidades.Consultas;
using DNAMais.Infrastructure.Data.Contexts;
using DNAMais.Infrastructure.Data.Repositories;

namespace DNAMais.Domain.Services.Consultas
{
    public class InfoMunicipioService
    {
        private DNAMaisSiteContext context;

        private Repository<InfoMunicipio> repoMunicipio;

        public InfoMunicipioService()
        {
            context = new DNAMaisSiteContext();
            repoMunicipio = new Repository<InfoMunicipio>(context);
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public IQueryable<InfoMunicipio> ListarPorUf(string uf)
        {
            return repoMunicipio.Filter(i => i.SiglaUF == uf).OrderBy(x => x.Nome);
        }
    }
}
