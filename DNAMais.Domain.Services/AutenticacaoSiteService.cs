using DNAMais.Domain.DTO;
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
    public class AutenticacaoSiteService
    {
        private DNAMaisSiteContext context;

        private Repository<UsuarioCliente> repoUsuario;

        public AutenticacaoSiteService()
        {
            context = new DNAMaisSiteContext();
            repoUsuario = new Repository<UsuarioCliente>(context);
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public ResultValidation AutenticarUsuario(LoginUser user, out UsuarioCliente usuarioAutenticado)
        {
            ResultValidation retorno = new ResultValidation();

            if (user.Login == null)
            {
                retorno.AddMessage("", "Usuário/Senha não conferem.");
                usuarioAutenticado = new UsuarioCliente { Login = user.Login, Senha = user.Password };
            }

            if (user.Password == null)
            {
                retorno.AddMessage("", "Usuário/Senha não conferem.");
                usuarioAutenticado = new UsuarioCliente { Login = user.Login, Senha = user.Password };
            }

            UsuarioCliente userByLogin = repoUsuario.FindFirst(u => u.Login == user.Login);

            if (userByLogin == null)
            {
                retorno.AddMessage("", "Usuário/Senha não conferem.");
                usuarioAutenticado = new UsuarioCliente { Login = user.Login, Senha = string.Empty };
            }
            else if (userByLogin.Ativo == false)
            {
                retorno.AddMessage("", "Acesso negado.");
                usuarioAutenticado = new UsuarioCliente { Login = user.Login, Senha = string.Empty };
            }
            else if (userByLogin.Senha != Security.Encryption(user.Password))
            {
                retorno.AddMessage("", "Usuário/Senha não conferem.");
                usuarioAutenticado = new UsuarioCliente { Login = user.Login, Senha = string.Empty };
            }

            usuarioAutenticado = userByLogin;

            return retorno;
        }

        public ResultValidation SalvarNovaSenha(UsuarioCliente usuarioCliente)
        {
            ResultValidation returnValidation = new ResultValidation();

            usuarioCliente.Senha = Security.Encryption(usuarioCliente.Senha);

            if (!returnValidation.Ok) return returnValidation;

            try
            {
                repoUsuario.Update(usuarioCliente);

                context.SaveChanges();
            }
            catch (Exception err)
            {
                returnValidation.AddMessage("", err);
            }

            return returnValidation;
        }

        public UsuarioCliente ConsultarPorEmail(string email)
        {
            return repoUsuario.FindFirst(i => i.Email == email);
        }


    }
}
