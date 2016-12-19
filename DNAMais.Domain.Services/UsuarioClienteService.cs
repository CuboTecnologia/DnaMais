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
    public class UsuarioClienteService
    {
        private DNAMaisSiteContext context;

        private Repository<UsuarioCliente> repoUsuarioCliente;

        public UsuarioClienteService()
        {
            context = new DNAMaisSiteContext();
            repoUsuarioCliente = new Repository<UsuarioCliente>(context);
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public IQueryable<UsuarioCliente> ListarTodos()
        {
            return repoUsuarioCliente.GetAll();
        }

        public UsuarioCliente ConsultarPorId(int id)
        {
            return repoUsuarioCliente.GetById(id);
        }

        public UsuarioCliente ConsultarPorLogin(string login)
        {
            return repoUsuarioCliente.FindFirst(i => i.Login == login);
        }

        public ResultValidation Salvar(UsuarioCliente usuarioCliente)
        {
            ResultValidation returnValidation = new ResultValidation();

            if (repoUsuarioCliente.Exists(i => i.Email.ToUpper().Trim() == usuarioCliente.Email.ToUpper().Trim() &&
                i.Id != usuarioCliente.Id))
            {
                returnValidation.AddMessage("E-mail", "E-mail já existente.");
            }

            if (repoUsuarioCliente.Exists(i => i.Login.ToUpper().Trim() == usuarioCliente.Login.ToUpper().Trim() &&
              i.Id != usuarioCliente.Id))
            {
                returnValidation.AddMessage("E-mail", "Login já existente.");
            }

            usuarioCliente.Cpf = usuarioCliente.Cpf.LimparCaracteresCPF();

            if (!returnValidation.Ok) return returnValidation;

            try
            {
                if (usuarioCliente.Id == null)
                {
                    repoUsuarioCliente.Add(usuarioCliente);
                }
                else
                {
                    repoUsuarioCliente.Update(usuarioCliente);
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
                repoUsuarioCliente.Remove(id);

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
