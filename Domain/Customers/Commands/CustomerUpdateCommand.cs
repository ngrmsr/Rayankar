﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Customers.Commands
{
    public class CustomerUpdateCommand: CustomerBaseCommand
    {
        public int CustomerId { get; set; }
    }
}
