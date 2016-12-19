using DNAMais.Domain.Validacao;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace DNAMais.BackOffice.Helpers
{
    public static class DnaMaisHelperFormValidation
    {
        public static HtmlString Validations<TModel>(this HtmlHelper<TModel> helper, object model, int? totalIndexes = null, string formId = "frmStandard", bool isSubmitHandler = false)
        {
            StringBuilder script = new StringBuilder();

            StringBuilder rules = new StringBuilder();
            StringBuilder messages = new StringBuilder();

            script.Append("<script type=\"text/javascript\">");

            rules.Append("rules: { ");
            messages.Append("messages: { ");

            for (int index = 0; index <= (totalIndexes ?? 0); index++)
            {
                foreach (PropertyInfo property in model.GetType().GetProperties())
                {
                    StringBuilder fieldRules = new StringBuilder();
                    StringBuilder fieldMessages = new StringBuilder();

                    if (totalIndexes == null)
                    {
                        fieldRules.Append(property.Name + ": { ");
                        fieldMessages.Append(property.Name + ": { ");
                    }
                    else
                    {
                        fieldRules.Append("\"[" + index.ToString() + "]." + property.Name + "\": { ");
                        fieldMessages.Append("\"[" + index.ToString() + "]." + property.Name + "\": { ");
                    }

                    bool aplyRule = false;

                    foreach (object custom in property.GetCustomAttributes(false))
                    {
                        if (custom is RequiredAttribute)
                        {
                            fieldRules.Append("required: true,");
                            fieldMessages.Append("required: \"" + ((RequiredAttribute)custom).ErrorMessage + "\",");
                            aplyRule = true;
                        }

                        if (custom is CNPJValidation)
                        {
                            fieldRules.Append("cnpj: true,");
                            fieldMessages.Append("cnpj: \"" + ((CNPJValidation)custom).ErrorMessage + "\",");

                            fieldRules.Append("cnpjDigit: true,");
                            fieldMessages.Append("cnpjDigit: \"" + ((CNPJValidation)custom).ErrorMessage + "\",");

                            aplyRule = true;
                        }

                        if (custom is CPFValidation)
                        {
                            fieldRules.Append("cpf: true,");
                            fieldMessages.Append("cpf: \"" + ((CPFValidation)custom).ErrorMessage + "\",");

                            fieldRules.Append("cpfDigit: true,");
                            fieldMessages.Append("cpfDigit: \"" + ((CPFValidation)custom).ErrorMessage + "\",");

                            aplyRule = true;
                        }

                        if (custom is EmailValidation)
                        {
                            fieldRules.Append("email: true,");
                            fieldMessages.Append("email: \"" + ((EmailValidation)custom).ErrorMessage + "\",");
                            aplyRule = true;
                        }
                    }

                    fieldRules.Remove(fieldRules.Length - 1, 1);
                    fieldMessages.Remove(fieldMessages.Length - 1, 1);


                    fieldRules.Append(" },");
                    fieldMessages.Append(" },");

                    if (!aplyRule)
                    {
                        fieldRules.Clear();
                        fieldMessages.Clear();
                    }

                    rules.Append(fieldRules);
                    messages.Append(fieldMessages);

                }
            }

            rules.Remove(rules.Length - 1, 1);
            messages.Remove(messages.Length - 1, 1);

            rules.Append("},");
            messages.Append("}");

            script.Append("$(function () { $(\"#" + formId + "\").validate({");

            script.Append(rules);
            script.Append(messages);

            if (!isSubmitHandler)
            {
                script.Append("}); });");
            }
            else
            {
                script.Append(", submitHandler: function(form) {return false;}    }); });");
            }

            script.Append("</script>");

            return new HtmlString(script.ToString());
        }
    }
}