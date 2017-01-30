using DNAMais.Domain;
using DNAMais.Domain.DTO;
using DNAMais.Domain.Entidades;
using DNAMais.Domain.Services;
using DNAMais.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DNAMais.Site.Facades.Base;

namespace DNAMais.Site.Facades
{
    public class AutenticacaoFacade : BaseFacade
    {
        private AutenticacaoSiteService servicoAutenticacao;
        private UsuarioClienteService servicoUsuarioCliente;

        public AutenticacaoFacade(ModelStateDictionary modelState)
            : base(modelState)
        {
            servicoAutenticacao = new AutenticacaoSiteService();
            servicoUsuarioCliente = new UsuarioClienteService();
        }
        public void Dispose()
        {
            servicoAutenticacao.Dispose();
            servicoUsuarioCliente.Dispose();
        }

        public ResultValidation AutenticarUsuario(LoginUser usuario, out UsuarioCliente usuarioAutenticado)
        {
            ResultValidation retorno = servicoAutenticacao.AutenticarUsuario(usuario, out usuarioAutenticado);

            FillModelState(retorno);

            return retorno;
        }

        public ResultValidation AlterarUsuarioCliente(UsuarioCliente usuarioCliente)
        {
            ResultValidation retorno = servicoAutenticacao.SalvarNovaSenha(usuarioCliente);

            FillModelState(retorno);

            return retorno;
        }

        public UsuarioCliente ConsultarPorLogin(string login)
        {
            UsuarioCliente retorno = servicoUsuarioCliente.ConsultarPorLogin(login);

            return retorno;
        }

        public UsuarioCliente ConsultarPorEmail(string email)
        {
            UsuarioCliente retorno = servicoAutenticacao.ConsultarPorEmail(email);

            return retorno;
        }


    }
}