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
    public class UsuarioBackOfficeService
    {
        private DNAMaisSiteContext context;

        private Repository<UsuarioBackOffice> repoUsuarioBackOffice;

        public UsuarioBackOfficeService()
        {
            context = new DNAMaisSiteContext();
            repoUsuarioBackOffice = new Repository<UsuarioBackOffice>(context);
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public IQueryable<UsuarioBackOffice> ListarTodos()
        {
            return repoUsuarioBackOffice.GetAll();
        }

        public UsuarioBackOffice ConsultarPorId(int id)
        {
            return repoUsuarioBackOffice.GetById(id);
        }

        public UsuarioBackOffice ConsultarPorLogin(string login)
        {
            return repoUsuarioBackOffice.FindFirst(i => i.Login == login);
        }

        public ResultValidation Salvar(UsuarioBackOffice usuarioBackOffice)
        {
            ResultValidation returnValidation = new ResultValidation();


            if (repoUsuarioBackOffice.Exists(i => i.Email.ToUpper().Trim() == usuarioBackOffice.Email.ToUpper().Trim() &&
                i.Id != usuarioBackOffice.Id))
            {
                returnValidation.AddMessage("Email", "E-mail já existente.");
            }


            if (repoUsuarioBackOffice.Exists(i => i.Login.ToUpper().Trim() == usuarioBackOffice.Login.ToUpper().Trim() &&
               i.Id != usuarioBackOffice.Id))
            {
                returnValidation.AddMessage("Login", "Login já existente.");
            }


            if (!returnValidation.Ok) return returnValidation;

            try
            {
                if (usuarioBackOffice.Id == null)
                {
                    usuarioBackOffice.DataCriacao = DateTime.Now;
                    usuarioBackOffice.Senha = Security.Encryption(usuarioBackOffice.Login + usuarioBackOffice.Senha);
                    
                    repoUsuarioBackOffice.Add(usuarioBackOffice);
                }
                else
                {
                    repoUsuarioBackOffice.Update(usuarioBackOffice);
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
                repoUsuarioBackOffice.Remove(id);

                context.SaveChanges();
            }
            catch (Exception err)
            {
                returnValidation.AddMessage("", err.Message);
            }

            return returnValidation;
        }
    }
}
