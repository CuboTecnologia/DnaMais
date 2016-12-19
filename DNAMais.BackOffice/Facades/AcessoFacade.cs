using DNAMais.BackOffice.Facades.Base;
using DNAMais.Domain.Entidades;
using DNAMais.Domain.Services;
using DNAMais.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DNAMais.BackOffice.Facades
{
    public class AcessoFacade : BaseFacade, IDisposable
    {
        private FuncionalidadeBackOfficeService serviceFuncionalidade;
        private PerfilAcessoBackOfficeService servicePerfilAcesso;
        private PerfilAcessoFuncionalidadeService servicePerfilAcessoFuncionalidade;
        private UsuarioBackOfficeService serviceUsuario;
        private RamoAtividadeService serviceRamoAtividade;

        public AcessoFacade(ModelStateDictionary modelState)
            : base(modelState)
        {
            serviceFuncionalidade = new FuncionalidadeBackOfficeService();
            servicePerfilAcesso = new PerfilAcessoBackOfficeService();
            servicePerfilAcessoFuncionalidade = new PerfilAcessoFuncionalidadeService();
            serviceUsuario = new UsuarioBackOfficeService();
            serviceRamoAtividade = new RamoAtividadeService();
        }

        public void Dispose()
        {
            serviceFuncionalidade.Dispose();
            servicePerfilAcesso.Dispose();
            servicePerfilAcessoFuncionalidade.Dispose();
            serviceUsuario.Dispose();
            serviceRamoAtividade.Dispose();
        }

        #region Funcionalidades BackOffice

        public IQueryable<FuncionalidadeBackOffice> ListarFuncionalidadesBackOffice()
        {
            return serviceFuncionalidade.ListarTodos();
        }

        public FuncionalidadeBackOffice ConsultarFuncionalidadeBackOfficePorId(string id)
        {
            return serviceFuncionalidade.ConsultarPorId(id);
        }

        #endregion

        #region Perfil de Acesso BackOffice

        public List<PerfilAcessoBackOffice> ListarPerfisAcessoBackOffice()
        {
            return servicePerfilAcesso.ListarTodos().ToList();
        }

        public PerfilAcessoBackOffice ConsultarPerfilAcessoBackOfficePorId(byte id)
        {
            return servicePerfilAcesso.ConsultarPorId(id);
        }

        public void IncluirPerfilAcessoBackOffice(PerfilAcessoBackOffice perfilAcessoBackOffice)
        {
            if (!modelState.IsValid)
            {
                return;
            }

            ResultValidation retorno = servicePerfilAcesso.Salvar(perfilAcessoBackOffice);

            PreencherModelState(retorno);
        }

        public void AlterarPerfilAcessoBackOffice(PerfilAcessoBackOffice perfilAcessoBackOffice)
        {
            if (!modelState.IsValid)
            {
                return;
            }

            ResultValidation retorno = servicePerfilAcesso.Salvar(perfilAcessoBackOffice);

            PreencherModelState(retorno);
        }

        public void RemoverPerfilAcessoBackOffice(byte id)
        {
            ResultValidation retorno = servicePerfilAcesso.Excluir(id);

            PreencherModelState(retorno);
        }

        #endregion

        #region Perfil de Acesso Funcionalidade

        public void RemoverPerfilAcessoFuncionalidade(byte id)
        {
            ResultValidation retorno = servicePerfilAcessoFuncionalidade.Excluir(id);

            PreencherModelState(retorno);
        }

        #endregion

        #region Usuário BackOffice

        public List<UsuarioBackOffice> ListarUsuariosBackOffice()
        {
            return serviceUsuario.ListarTodos().ToList();
        }

        public UsuarioBackOffice ConsultarUsuarioBackOfficePorId(int id)
        {
            return serviceUsuario.ConsultarPorId(id);
        }

        public void IncluirUsuarioBackOffice(UsuarioBackOffice usuarioBackOffice)
        {
            if (!modelState.IsValid)
            {
                return;
            }

            ResultValidation retorno = serviceUsuario.Salvar(usuarioBackOffice);

            PreencherModelState(retorno);
        }

        public void AlterarUsuarioBackOffice(UsuarioBackOffice usuarioBackOffice)
        {
            if (!modelState.IsValid)
            {
                return;
            }

            usuarioBackOffice.DataCriacao = DateTime.Now;

            ResultValidation retorno = serviceUsuario.Salvar(usuarioBackOffice);

            PreencherModelState(retorno);
        }

        public void RemoverUsuarioBackOffice(int id)
        {
            ResultValidation retorno = serviceUsuario.Excluir(id);

            PreencherModelState(retorno);
        }

        #endregion

    }
}