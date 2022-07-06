using Masa.Webaligner.Core.Interfaces.UoW;
using Masa.Webaligner.Infrastructure.Context;
using Microsoft.EntityFrameworkCore.Storage;

namespace Masa.Webaligner.Infrastructure.UoW
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly MasaContext _context;
        private IDbContextTransaction _transaction;

        #pragma warning disable CS8618
        public UnitOfWork(MasaContext context)
        {
            _context = context;
        }
        #pragma warning restore CS8618

        public void BeginCommit()
        {
            _transaction.Commit();
        }

        public void BeginRollBack()
        {
            _transaction.Rollback();
        }

        public void BeginTransaction()
        {
            _transaction = _context.Database.BeginTransaction();
        }

        public int Commit()
        {
            return _context.SaveChanges();
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
                _context.Dispose();

                if (_transaction is not null)
                {
                    _transaction.Dispose();
                }
            }
        }
    }
}
