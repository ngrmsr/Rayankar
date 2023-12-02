using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Command
{
    public class Result
    {
        public readonly IEnumerable<string> error;

        public Result(bool success, IEnumerable<string> error)
        {
            this.error = error;
        }
    }
}
