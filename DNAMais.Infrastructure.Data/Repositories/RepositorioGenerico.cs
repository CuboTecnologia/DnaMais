using DNAMais.Infrastructure.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DNAMais.Infrastructure.Data.Repositories
{
    public class RepositorioGenerico<T>
        where T : class, new()
    {
        DNAMaisSiteContext context;

        public RepositorioGenerico()
        {
            context = new DNAMaisSiteContext();
        }

        private DbSet<T> SetEntidade
        {
            get { return context.Set<T>(); }
        }

        public List<T> ListarTodos()
        {
            return SetEntidade.ToList();
        }

        public T Consultar(params object[] ids)
        {
            return SetEntidade.Find(ids);
        }

        public List<T> Filtrar(Expression<Func<T, bool>> filtro)
        {
            return SetEntidade.Where(filtro).ToList();
        }

        public void Salvar(T entidade)
        {
            SetEntidade.Add(entidade);
        }

        public void Excluir(params object[] ids)
        {
            T entidade = Consultar(ids);
            SetEntidade.Remove(entidade);
        }

        public void Excluir(T entidade)
        {
            SetEntidade.Remove(entidade);
        }

        public void Excluir(Expression<Func<T,bool>> filtro)
        {
            foreach (T item in Filtrar(filtro))
            {
                Excluir(item);
            }
        }
    }
}
