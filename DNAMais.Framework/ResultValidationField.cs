using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNAMais.Framework
{
    public class ResultValidationField
    {
        public string Field { get; set; }
        public string Message { get; set; }

        public ResultValidationField(string field, string message)
        {
            this.Field = field;
            this.Message = message;
        }
    }
}
