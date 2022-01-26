using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace WebApplication1.Model
{
    public class BookMap :ClassMapping<Book>
    {
        public BookMap()
        {
            Id(x => x.Id, x =>
            {
                x.Generator(Generators.Guid);
                x.Type(NHibernateUtil.Guid);
                x.Column("Id");
                x.UnsavedValue(Guid.Empty);
            });

            Property(b => b.Name, x =>
            {
                x.Length(50);
                x.Type(NHibernateUtil.StringClob);
                x.NotNullable(true);
            });

            Table("Book");
        }
    }
}
