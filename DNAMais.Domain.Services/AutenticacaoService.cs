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
    public class AutenticacaoService
    {
        private DNAMaisSiteContext context;

        private Repository<UsuarioBackOffice> repoUsuario;

        public AutenticacaoService()
        {
            context = new DNAMaisSiteContext();
            repoUsuario = new Repository<UsuarioBackOffice>(context);
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public ResultValidation AutenticarUsuario(LoginUser user, out UsuarioBackOffice usuarioAutenticado)
        {
            ResultValidation retorno = new ResultValidation();

            if (user.Login == null)
            {
                retorno.AddMessage("login", "Usuário/Senha não conferem.");
                usuarioAutenticado = new UsuarioBackOffice { Login = user.Login, Senha = user.Password };
            }

            if (user.Password == null)
            {
                retorno.AddMessage("password", "Usuário/Senha não conferem.");
                usuarioAutenticado = new UsuarioBackOffice { Login = user.Login, Senha = user.Password };
            }

            UsuarioBackOffice userByLogin = repoUsuario.FindFirst(u => u.Login == user.Login);

            if (userByLogin == null)
            {
                retorno.AddMessage("login", "Usuário/Senha não conferem.");
                usuarioAutenticado = new UsuarioBackOffice { Login = user.Login, Senha = user.Password,  };
            }
            else if(userByLogin.Senha != Security.Encryption(user.Login + user.Password))
            {
                retorno.AddMessage("password", "Usuário/Senha não conferem.");
                usuarioAutenticado = new UsuarioBackOffice { Login = user.Login, Senha = user.Password };
            }
            else
            {
                retorno.Success("usuário validado com sucesso.");
                usuarioAutenticado = userByLogin;
            }

            return retorno;
        }
    }
}
