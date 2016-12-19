using DNAMais.Domain.Entidades;
using DNAMais.Framework;
using DNAMais.Infrastructure.Data.Contexts;
using DNAMais.Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNAMais.Domain.Services
{
    public class NewsletterService
    {
        private DNAMaisSiteContext context;

        private Repository<Newsletter> repoNewsletter;

        public NewsletterService()
        {
            context = new DNAMaisSiteContext();
            repoNewsletter = new Repository<Newsletter>(context);
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public ResultValidation Salvar(Newsletter subscriptionNewsletter)
        {
            ResultValidation returnValidation = new ResultValidation();

            if (repoNewsletter.Contains(m => m.Email.ToUpper() == subscriptionNewsletter.Email.ToUpper()
                && m.Id != subscriptionNewsletter.Id))
            {
                returnValidation.AddMessage("Email", "Já existe inscrição newsletter cadastrada com este e-mail.");
            }

            if (!returnValidation.Ok) return returnValidation;

            try
            {
                if (subscriptionNewsletter.Id == null)
                {
                    subscriptionNewsletter.DataRegistro = DateTime.Now;
                    subscriptionNewsletter.OptIn = false;
                    subscriptionNewsletter.OptOut = false;

                    repoNewsletter.Add(subscriptionNewsletter);
                }
                else
                {
                    repoNewsletter.Update(subscriptionNewsletter);
                }

                context.SaveChanges();
            }
            catch (Exception err)
            {
                returnValidation.AddMessage("", err.Message);
            }

            return returnValidation;
        }

        public ResultValidation Excluir(int id)
        {
            ResultValidation returnValidation = new ResultValidation();

            if (!returnValidation.Ok) return returnValidation;

            try
            {
                repoNewsletter.Remove(id);
                context.SaveChanges();
            }
            catch (Exception err)
            {
                returnValidation.AddMessage("", err.Message);
            }

            return returnValidation;
        }

        public IQueryable<Newsletter> ListarNaoConfirmadas()
        {
            return repoNewsletter.Filter(i => i.OptInText == "N");
        }

        public IQueryable<Newsletter> ListarConfirmadas()
        {
            return repoNewsletter.Filter(i => i.OptInText == "S" && i.OptOutText == "N");
        }

        public IQueryable<Newsletter> ListarCanceladas()
        {
            return repoNewsletter.Filter(i => i.OptOutText == "S" && i.OptInText == "S");
        }

        public Newsletter ConsultarPorId(int id)
        {
            return repoNewsletter.GetById(id);
        }

        public Newsletter ConsultarPorGuid(string guid)
        {
            return repoNewsletter.FindFirst(i => i.GUID == guid);
        }

        public Newsletter ConsultarPorEmail(string email)
        {
            return repoNewsletter.FindFirst(i => i.Email == email);
        }

        public Newsletter ConfirmarNewsletter(int id)
        {
            Newsletter newsletter = repoNewsletter.GetById(id);

            newsletter.OptIn = true;

            return newsletter;
        }

        public Newsletter CancelarNewsletter(int id)
        {
            Newsletter newsletter = repoNewsletter.GetById(id);

            newsletter.OptOut = true;

            return newsletter;
        }
    }
}
