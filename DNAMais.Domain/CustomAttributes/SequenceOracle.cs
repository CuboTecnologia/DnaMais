using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNAMais.Domain.CustomAttributes
{
    public class SequenceOracle : Attribute
    {
        public string SequenceName { get; private set; }

        public SequenceOracle(string sequenceName)
        {
            this.SequenceName = sequenceName;
        }
    }
}
