using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DNAMais.BackOffice.Helpers
{
    public static class DnaMaisHelperModelState
    {
        public static IEnumerable<String> GetErrors(this ModelStateDictionary modelState)
        {
            return modelState.Values.SelectMany(v => v.Errors)
                                    .Select(v => v.ErrorMessage + " " + v.Exception).ToList();

        }

        public static string GetErrors(this ModelStateDictionary modelState, string separator)
        {
            string messages = string.Join(separator + " ", modelState.Values
                                                    .SelectMany(x => x.Errors)
                                                    .Select(x => x.ErrorMessage));
            return messages;
        }

        public static string GetErrorFriendly(this ModelStateDictionary modelState)
        {
            var list = modelState.Values.SelectMany(v => v.Errors)
                                    .Select(v => v.ErrorMessage + " " + v.Exception).ToList();

            var retorno = string.Empty;

            foreach (string item in list)
            {
                if (item.Contains("ORA-02291"))
                {
                    retorno = "Existem informações que dependem desse registro. Não será possível a sua exclusão.";
                    break;
                }
                else if (item.Contains("ORA-02292"))
                {
                    retorno = "Existem informações que dependem desse registro. Não será possível a sua exclusão.";
                    break;
                }
                else if (item.Contains("ORA-"))
                {
                    retorno = "Ocorreu o seguinte erro: " + item;
                    break;
                }
            }

            return retorno;
        }
    }
}