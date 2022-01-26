using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using NHibernate;
using ISession = NHibernate.ISession;

namespace WebApplication1.Model
{
    public class NHibernateMapperSession :IMapperSession
    {
        private readonly ISession _session;
        private ITransaction _transaction;

        public NHibernateMapperSession(ISession session)
        {
            _session = session;
        }
        public void BeginTransaction()
        {
            _transaction = _session.BeginTransaction();
        }

        public async Task Commit()
        {
            await _transaction.CommitAsync();
        }

        public async Task Rollback()
        {
            await _transaction.RollbackAsync();
        }

        public void CloseTransaction()
        {
            if (_transaction != null)
            {
                _transaction.Dispose();
                _transaction = null;
            }
        }

        public async Task Save(Book entity)
        {
            await _session.SaveOrUpdateAsync(entity);
        }

        public async Task Delete(Book entity)
        {
            _session.Delete(entity);
        }

        

        public IQueryable<Book> Books => _session.Query<Book>();
    }
}
