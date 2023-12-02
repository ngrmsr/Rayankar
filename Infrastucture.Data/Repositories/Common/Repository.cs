using Framework.Contracts;
using Framework.Entity;
using Infrastructure.SqlServer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastucture.Data.Repositories.Common
{
    public partial class Repository<T> : IRepository<T> where T : IBaseEntity
    {
        public readonly Context context;

        public Repository(Context context)
        {
            this.context = context;
        }
        public void Add(T entity)
        {
            context.Add(entity);
        }

        public void Dispose()
        {
            context.Dispose();
            GC.SuppressFinalize(this);
        }

        public int SaveChange()
        {
            return context.SaveChangesAsync().Result;
        }

        public void Update(T entity)
        {
            context.Update(entity);
        }
    }

}
