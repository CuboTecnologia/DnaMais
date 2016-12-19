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
                usuarioAutenticado = new UsuarioCliente { Login = user.Login, Senha = user.Password };
            }

            if (userByLogin.Senha != Security.Encryption(user.Login + user.Password))
            {
                retorno.AddMessage("", "Usuário/Senha não conferem.");
                usuarioAutenticado = new UsuarioCliente { Login = user.Login, Senha = user.Password };
            }

            usuarioAutenticado = userByLogin;

            return retorno;
        }
    }
}
