using Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Customers.Events
{
    public class CustomerDeleteEvent : IDomainEvent
    {
        public int CustomerId { get; set; }
    }
}
