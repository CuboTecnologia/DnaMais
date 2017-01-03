using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNAMais.Framework
{
    public class ResultValidation
    {
        public bool Ok { get; set; }
        public string Message { get; set; }
        public List<ResultValidationField> Fields { get; set; }

        public ResultValidation()
        {
            this.Ok = true;
            this.Message = string.Empty;
            this.Fields = new List<ResultValidationField>();
        }

        public void AddMessage(string field, string message)
        {
            if (field.Trim() != string.Empty)
                this.Fields.Add(new ResultValidationField(field, message));
            else
                this.Message = message;

            this.Ok = false;
        }

        public void AddMessage(string message)
        {
            this.Ok = false;
            this.Message = message;
        }

        public void Success(string message)
        {
            this.Ok = true;
            this.Message = message;
        }
    }
}
