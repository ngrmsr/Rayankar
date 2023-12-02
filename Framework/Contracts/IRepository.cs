using Framework.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Contracts
{
    public interface IRepository<in T> : IDisposable where T : IBaseEntity
    {
        void Add(T entity);
        void Update(T entity);
        int SaveChange();
    }
}
