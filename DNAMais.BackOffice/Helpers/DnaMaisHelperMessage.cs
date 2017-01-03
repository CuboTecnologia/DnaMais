using DNAMais.Domain.Validacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace DNAMais.BackOffice.Helpers
{
    public static class DnaMaisHelperMessage
    {
        public static HtmlString DnaMaisMessageError(this HtmlHelper helper, ModelStateDictionary ModelState)
        {
            StringBuilder sbUnexpected = new StringBuilder();

            //sbUnexpected.Append("<div class=\"alert alert-info\">");
            //sbUnexpected.Append("<button type=\"button\" class=\"close\" data-dismiss=\"alert\">");
            //sbUnexpected.Append("&times;</button>");
            //sbUnexpected.Append("<strong>Alerta! </strong>Ocorreu um erro inesperado.</div>");

            StringBuilder sb = new StringBuilder();

            int qtdAlertas = 0;

            foreach (ModelState ms in ModelState.Values)
            {
                if (ms == null)
                {
                    continue;
                }

                foreach (ModelError error in ms.Errors)
                {
                    ExceptionLevel level;

                    if (error.Exception is DNAMais.Domain.Validacao.ValidationException)
                    {
                        level = ((DNAMais.Domain.Validacao.ValidationException)error.Exception).ExceptionLevel;
                    }
                    else
                    {
                        level = ExceptionLevel.Error;
                    }

                    string cssClass = string.Empty;
                    string subTitle = string.Empty;

                    if (level == ExceptionLevel.Error)
                    {
                        cssClass = "alert alert-danger";
                        subTitle = "Alerta! ";

                        qtdAlertas++;
                    }
                    else
                    {
                        cssClass = "alert";
                        subTitle = "Alerta! ";
                    }

                    string mensagem = string.Empty;

                    if (error.Exception != null)
                    {
                        mensagem = error.Exception.Message;

                        bool endInnerException = false;

                        Exception errorFind = error.Exception;

                        while (!endInnerException)
                        {
                            if (errorFind.InnerException != null)
                            {
                                errorFind = errorFind.InnerException;
                                mensagem += " - " + errorFind.Message;
                            }
                            else
                            {
                                endInnerException = true;
                            }
                        }
                    }
                    else
                    {
                        mensagem = error.ErrorMessage;
                    }

                    sb.Append("<div class=\"" + cssClass + "\">");
                    sb.Append("<button type=\"button\" class=\"close\" data-dismiss=\"alert\">");
                    sb.Append("&times;</button>");
                    sb.Append("<strong>" + subTitle + "</strong>" + mensagem + "</div>");
                }
            }

            return new HtmlString((qtdAlertas > 0 ? sbUnexpected.ToString() : "") + sb.ToString());
        }

        public static HtmlString DnaMaisMessageSuccess(this HtmlHelper helper, string message)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("<div class=\"alert alert-success\">");
            sb.Append("<button type=\"button\" class=\"close\" data-dismiss=\"alert\">");
            sb.Append("&times;</button>");
            sb.Append("<strong>Sucesso! </strong>" + message + "</div>");

            return new HtmlString(sb.ToString());
        }

        public static HtmlString DnaMaisMessageChanges(this HtmlHelper helper, string message)
        {
            StringBuilder sb = new StringBuilder();

            //sb.Append("<div class=\"alert alert-primary\">");
            //sb.Append("<button type=\"button\" class=\"close\" data-dismiss=\"alert\">");
            //sb.Append("&times;</button>");
            //sb.Append("<strong>Mudanças Realizadas! </strong>" + message + "</div>");

            return new HtmlString(sb.ToString());
        }
    }
}