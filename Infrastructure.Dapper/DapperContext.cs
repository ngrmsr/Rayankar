using Infrastructure.Dapper.Contracts;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dapper
{
    public class DapperContext : IDapperContext
    {
        public IDbConnection CreateConnection() => new SqlConnection("Server=.;Database=RayankarDB;Trusted_Connection=True;");
    }
}
