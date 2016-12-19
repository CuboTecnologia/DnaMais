using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNAMais.Domain.Extensions
{
    public static class EnumExtensions
    {
        public static bool? ParseFlag(this string value)
        {
            switch (value)
            {
                case "S":
                    return true;
                case "N":
                    return false;
                default:
                    return false;
            }
        }

        public static string ParseFlag (this bool? value)
        {
            switch (value)
            {
                case true:
                    return "S";
                case false:
                    return "N";
                default:
                    return "N";
            }
        }
    }
}
