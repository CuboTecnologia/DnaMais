using DNAMais.BackOffice.Facades.Base;
using DNAMais.Domain;
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
    public class AcessoClienteFacade : BaseFacade, IDisposable
    {
        private GrupoUsuarioClienteService serviceGrupoUsuarioCliente;
        private UsuarioClienteService serviceUsuario;
        private UsuarioClienteProdutoService serviceUsuarioClienteProduto;

        public AcessoClienteFacade(ModelStateDictionary modelState)
            : base(modelState)
        {
            serviceGrupoUsuarioCliente = new GrupoUsuarioClienteService();
            serviceUsuario = new UsuarioClienteService();
            serviceUsuarioClienteProduto = new UsuarioClienteProdutoService();
        }

        public void Dispose()
        {
            serviceGrupoUsuarioCliente.Dispose();
            serviceUsuario.Dispose();
            serviceUsuarioClienteProduto.Dispose();
        }

        #region Grupo de Usuários Cliente

        public List<GrupoUsuarioCliente> ListarGruposUsuarioCliente()
        {
            return serviceGrupoUsuarioCliente.ListarTodos().ToList();
        }

        public GrupoUsuarioCliente ConsultarGrupoUsuarioClientePorId(int id)
        {
            return serviceGrupoUsuarioCliente.ConsultarPorId(id);
        }

        public List<UsuarioClienteProduto> ListarUsuarioClienteProduto(int id)
        {
            return serviceUsuarioClienteProduto.ListarPorId(id).ToList();
        }

        public void IncluirGrupoUsuarioCliente(GrupoUsuarioCliente grupoUsuarioCliente)
        {
            if (!modelState.IsValid)
            {
                return;
            }

            grupoUsuarioCliente.DataCadastro = DateTime.Now;
            grupoUsuarioCliente.IdUsuarioBackOfficeCadastro = ((UsuarioBackOffice)HttpContext.Current.Session["user"]).Id;

            ResultValidation retorno = serviceGrupoUsuarioCliente.Salvar(grupoUsuarioCliente);

            PreencherModelState(retorno);
        }

        public void AlterarGrupoUsuarioCliente(GrupoUsuarioCliente grupoUsuarioCliente)
        {
            if (!modelState.IsValid)
            {
                return;
            }

            grupoUsuarioCliente.DataCadastro = DateTime.Now;
            grupoUsuarioCliente.IdUsuarioBackOfficeCadastro = ((UsuarioBackOffice)HttpContext.Current.Session["user"]).Id;

            ResultValidation retorno = serviceGrupoUsuarioCliente.Salvar(grupoUsuarioCliente);

            PreencherModelState(retorno);
        }

        public void RemoverGrupoUsuarioCliente(int id)
        {
            ResultValidation retorno = serviceGrupoUsuarioCliente.Excluir(id);

            PreencherModelState(retorno);
        }

        #endregion

        #region Usuário Cliente

        public List<UsuarioCliente> ListarUsuariosCliente()
        {
            return serviceUsuario.ListarTodos().ToList();
        }

        public UsuarioCliente ConsultarUsuarioClientePorId(int id)
        {
            return serviceUsuario.ConsultarPorId(id);
        }

        public void IncluirUsuarioCliente(UsuarioCliente usuarioCliente)
        {
            if (!modelState.IsValid)
            {
                return;
            }

            usuarioCliente.Cpf = usuarioCliente.Cpf.LimparCaracteresCPF();
            usuarioCliente.DataCadastro = DateTime.Now;
            usuarioCliente.IdUsuarioBackOfficeCadastro = ((UsuarioBackOffice)HttpContext.Current.Session["user"]).Id;

            ResultValidation retorno = serviceUsuario.Salvar(usuarioCliente);

            PreencherModelState(retorno);
        }

        public void AlterarUsuarioCliente(UsuarioCliente usuarioCliente)
        {
            if (!modelState.IsValid)
            {
                return;
            }

            usuarioCliente.Cpf = usuarioCliente.Cpf.LimparCaracteresCPF();
            usuarioCliente.DataCadastro = DateTime.Now;
            usuarioCliente.IdUsuarioBackOfficeCadastro = ((UsuarioBackOffice)HttpContext.Current.Session["user"]).Id;

            ResultValidation retorno = serviceUsuario.Salvar(usuarioCliente);

            PreencherModelState(retorno);
        }

        public void RemoverUsuarioCliente(int id)
        {
            ResultValidation retorno = serviceUsuario.Excluir(id);

            PreencherModelState(retorno);
        }

        #endregion

        #region Usuario Cliente x Produtos Selecionados
        
        public void SalvarUsuarioClienteProdutosSelecionados(int idUsuarioCliente, List<string> produtosSelecionados)
        {
            serviceUsuarioClienteProduto.SalvarProdutosSelecionados(idUsuarioCliente, produtosSelecionados);
        }

        #endregion
    }
}