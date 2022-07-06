using Masa.Webaligner.Core.Interfaces.Repositories;
using Masa.Webaligner.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Masa.Webaligner.Infrastructure.Repositories
{
    public class EntityBaseRepository<TEntity> : IEntityBaseRepository<TEntity>
        where TEntity : class
    {
        protected readonly MasaContext Context;
        protected readonly DbSet<TEntity> DbSet;

        public EntityBaseRepository(MasaContext context)
        {
            Context = context;
            DbSet = Context.Set<TEntity>();
        }

        public void Add(TEntity obj)
        {
            DbSet.Add(obj);
        }

        public void Update(TEntity obj)
        {
            DbSet.Update(obj);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Context.Dispose();
            }
        }
    }
}
