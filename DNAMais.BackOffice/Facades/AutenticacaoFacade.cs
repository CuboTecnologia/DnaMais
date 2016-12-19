using DNAMais.BackOffice.Facades.Base;
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

namespace DNAMais.BackOffice.Facades
{
    public class AutenticacaoFacade : BaseFacade
    {
        private AutenticacaoService servicoAutenticacao;

        public AutenticacaoFacade(ModelStateDictionary modelState)
            : base(modelState)
        {
            servicoAutenticacao = new AutenticacaoService();
        }
        public void Dispose()
        {
            servicoAutenticacao.Dispose();
        }

        public void AutenticarUsuario(LoginUser usuario, out UsuarioBackOffice usuarioAutenticado)
        {
            ResultValidation retorno = servicoAutenticacao.AutenticarUsuario(usuario, out usuarioAutenticado);

            PreencherModelState(retorno);
        }
    }
}