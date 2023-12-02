using Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Entity
{
    public abstract class BaseEntity: IBaseEntity
    {
        public int Id { get; set; }
        public readonly List<IDomainEvent> domainEvent;
    }
}
