using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.Validation;

namespace DNAMais.Domain.Validacao
{
    public enum ExceptionLevel
    {
        Error,
        Warning
    }

    public class ValidationException : Exception
    {
        private ExceptionLevel m_exceptionLevel;

        public ExceptionLevel ExceptionLevel
        {
            get { return m_exceptionLevel; }
            set { m_exceptionLevel = value; }
        }

        public ValidationException(string message)
            : base(message)
        {
            m_exceptionLevel = ExceptionLevel.Warning;
        }

        public ValidationException(Exception exception)
            : base(exception.Message, exception)
        {
            m_exceptionLevel = ExceptionLevel.Error;
        }

        private static string EntityErrorMessage(DbEntityValidationException exception)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var validError in exception.EntityValidationErrors)
            {
                sb.Append(String.Format("Entidade do tipo \"{0}\" no estado \"{1}\" contém os seguintes erros de mapeamento:", validError.Entry.Entity.GetType().Name, validError.Entry.State));

                foreach (var error in validError.ValidationErrors)
                {
                    sb.Append(String.Format("Propriedade: \"{0}\", Erro: \"{1}\"", error.PropertyName, error.ErrorMessage));
                }
            }

            return sb.ToString();
        }

        public ValidationException(DbEntityValidationException exception)
            : base(EntityErrorMessage(exception), exception)
        {
            m_exceptionLevel = ExceptionLevel.Error;


        }
    }
}
