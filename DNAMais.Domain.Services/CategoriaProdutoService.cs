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
    public class CategoriaProdutoService
    {
        private DNAMaisSiteContext context;

        private Repository<CategoriaProduto> repoCategoriaProduto;

        public CategoriaProdutoService()
        {
            context = new DNAMaisSiteContext();
            repoCategoriaProduto = new Repository<CategoriaProduto>(context);
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public IQueryable<CategoriaProduto> ListarTodos()
        {
            return repoCategoriaProduto.GetAll();
        }

        public CategoriaProduto ConsultarPorId(string id)
        {
            return repoCategoriaProduto.GetById(id);
        }
    }
}
