using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Model
{
    public interface IMapperSession
    {
        void BeginTransaction();
        Task Commit();
        Task Rollback();
        void CloseTransaction();
        Task Save(Book entity);
        Task Delete(Book entity);

        IQueryable<Book> Books { get; }
    }
}
