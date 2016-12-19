using DNAMais.Infrastructure.Data.Contexts;
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace DNAMais.Infrastructure.Data.Repositories
{
    public class Repository<T>
            where T : class
    {
        public Repository(DNAMaisSiteContext context)
        {
            Context = context;
        }

        protected DbContext Context = null;

        protected DbSet<T> DbSet
        {
            get
            {
                return Context.Set<T>();
            }
        }

        public IQueryable<T> GetAll()
        {
            return DbSet.AsQueryable();
        }

        public IQueryable<T> Filter(Expression<Func<T, bool>> predicate)
        {
            return DbSet.AsNoTracking().Where(predicate).AsQueryable<T>();
        }

        public IQueryable<T> Filter(Expression<Func<T, bool>> filter, out int total, int index = 0, int size = 50)
        {
            int skipCount = index * size;
            var _resetSet = filter != null ? DbSet.Where(filter).AsQueryable() : DbSet.AsQueryable();
            _resetSet = skipCount == 0 ? _resetSet.Take(size) : _resetSet.Skip(skipCount).Take(size);
            total = _resetSet.Count();
            return _resetSet.AsQueryable();
        }

        public bool Contains(Expression<Func<T, bool>> predicate)
        {
            return DbSet.Count(predicate) > 0;
        }

        public T GetById(params object[] keys)
        {
            return DbSet.Find(keys);
        }

        public T FindFirst(Expression<Func<T, bool>> predicate)
        {
            return DbSet.FirstOrDefault(predicate);
        }

        public T FindFirst()
        {
            return DbSet.FirstOrDefault();
        }

        public T Add(T t)
        {
            var newEntry = DbSet.Add(t);
            return newEntry;
        }

        public void Update(T t)
        {
            var entry = Context.Entry(t);
            //DbSet.Attach(t);
            entry.State = EntityState.Modified;
        }

        public void Update(T t, params string[] notUpdated)
        {
            var entry = Context.Entry(t);
            DbSet.Attach(t);
            entry.State = EntityState.Modified;
            foreach (var name in notUpdated)
            {
                entry.Property(name).IsModified = false;
            }
        }

        public void Remove(params object[] keys)
        {
            T t = GetById(keys);
            Remove(t);
        }

        public void Remove(T t)
        {
            DbSet.Remove(t);
        }

        public void Remove(Expression<Func<T, bool>> predicate)
        {
            var objects = Filter(predicate);
            foreach (var obj in objects)
            {
                DbSet.Remove(obj);
            }
        }

        public int Count(Expression<Func<T, bool>> predicate)
        {
            return DbSet.Count(predicate);
        }

        public virtual int Count()
        {
            return DbSet.Count();
        }

        public bool Exists(Expression<Func<T, bool>> predicate)
        {
            return DbSet.Count(predicate) > 0;
        }
    }
}
