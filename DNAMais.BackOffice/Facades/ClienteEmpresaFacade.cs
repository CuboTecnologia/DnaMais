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
    public class ClienteEmpresaFacade : BaseFacade, IDisposable
    {
        private TipoContatoService serviceTipoContato;
        private TipoEnderecoService serviceTipoEndereco;
        private RamoAtividadeService serviceRamoAtividade;
        private ClienteEmpresaService serviceClienteEmpresa;

        public ClienteEmpresaFacade(ModelStateDictionary modelState)
            : base(modelState)
        {
            serviceTipoContato = new TipoContatoService();
            serviceTipoEndereco = new TipoEnderecoService();
            serviceRamoAtividade = new RamoAtividadeService();
            serviceClienteEmpresa = new ClienteEmpresaService();
        }

        public void Dispose()
        {
            serviceTipoContato.Dispose();
            serviceTipoEndereco.Dispose();
            serviceRamoAtividade.Dispose();
            serviceClienteEmpresa.Dispose();
        }

        #region Tipo de Contato

        public List<TipoContato> ListarTiposContato()
        {
            return serviceTipoContato.ListarTodos().ToList();
        }

        public TipoContato ConsultarTipoContatoPorId(int id)
        {
            return serviceTipoContato.ConsultarPorId(id);
        }

        public void IncluirTipoContato(TipoContato tipoContato)
        {
            if (!modelState.IsValid)
            {
                return;
            }

            tipoContato.DataCadastro = DateTime.Now;
            tipoContato.IdUsuarioCadastro = ((UsuarioBackOffice)HttpContext.Current.Session["user"]).Id;

            ResultValidation retorno = serviceTipoContato.Incluir(tipoContato);

            PreencherModelState(retorno);
        }

        public void AlterarTipoContato(TipoContato tipoContato)
        {
            if (!modelState.IsValid)
            {
                return;
            }

            tipoContato.DataCadastro = DateTime.Now;
            tipoContato.IdUsuarioCadastro = ((UsuarioBackOffice)HttpContext.Current.Session["user"]).Id;

            ResultValidation retorno = serviceTipoContato.Alterar(tipoContato);

            PreencherModelState(retorno);
        }

        public void RemoverTipoContato(int id)
        {
            ResultValidation retorno = serviceTipoContato.Excluir(id);

            PreencherModelState(retorno);
        }

        #endregion

        #region Tipo de Endereço

        public List<TipoEndereco> ListarTiposEndereco()
        {
            return serviceTipoEndereco.ListarTodos().ToList();
        }

        public TipoEndereco ConsultarTipoEnderecoPorId(int id)
        {
            return serviceTipoEndereco.ConsultarPorId(id);
        }

        public void IncluirTipoEndereco(TipoEndereco tipoEndereco)
        {
            if (!modelState.IsValid)
            {
                return;
            }

            tipoEndereco.DataCadastro = DateTime.Now;
            tipoEndereco.IdUsuarioCadastro = ((UsuarioBackOffice)HttpContext.Current.Session["user"]).Id;

            ResultValidation retorno = serviceTipoEndereco.Incluir(tipoEndereco);

            PreencherModelState(retorno);
        }

        public void AlterarTipoEndereco(TipoEndereco tipoEndereco)
        {
            if (!modelState.IsValid)
            {
                return;
            }

            tipoEndereco.DataCadastro = DateTime.Now;
            tipoEndereco.IdUsuarioCadastro = ((UsuarioBackOffice)HttpContext.Current.Session["user"]).Id;

            ResultValidation retorno = serviceTipoEndereco.Alterar(tipoEndereco);

            PreencherModelState(retorno);
        }

        public void RemoverTipoEndereco(int id)
        {
            ResultValidation retorno = serviceTipoEndereco.Excluir(id);

            PreencherModelState(retorno);
        }

        #endregion

        #region Ramo de Atividade

        public List<RamoAtividade> ListarRamosAtividade()
        {
            return serviceRamoAtividade.ListarTodos().ToList();
        }

        public RamoAtividade ConsultarRamoAtividadePorId(int id)
        {
            return serviceRamoAtividade.ConsultarPorId(id);
        }

        public void SalvarRamoAtividade(RamoAtividade ramoAtividade)
        {
            if (!modelState.IsValid)
            {
                return;
            }

            ramoAtividade.DataCadastro = DateTime.Now;
            ramoAtividade.IdUsuarioCadastro = ((UsuarioBackOffice)HttpContext.Current.Session["user"]).Id;

            ResultValidation retorno = serviceRamoAtividade.Salvar(ramoAtividade);

            PreencherModelState(retorno);
        }

        public void RemoverRamoAtividade(int id)
        {
            ResultValidation retorno = serviceRamoAtividade.Excluir(id);

            PreencherModelState(retorno);
        }

        #endregion

        #region Cliente Empresa

        public List<ClienteEmpresa> ListarClientesEmpresa()
        {
            return serviceClienteEmpresa.ListarTodos().ToList();
        }

        public ClienteEmpresa ConsultarClienteEmpresaPorId(int id)
        {
            return serviceClienteEmpresa.ConsultarPorId(id);
        }

        public void SalvarClienteEmpresa(ClienteEmpresa clienteEmpresa)
        {
            if (!modelState.IsValid)
            {
                return;
            }

            clienteEmpresa.DataCadastro = DateTime.Now;
            clienteEmpresa.IdUsuarioCadastro = ((UsuarioBackOffice)HttpContext.Current.Session["user"]).Id;

            if (clienteEmpresa.Id == null)
            {
                clienteEmpresa.CodigoStatus = 1;
            }
            
            ResultValidation retorno = serviceClienteEmpresa.Salvar(clienteEmpresa);

            PreencherModelState(retorno);
        }

        public void RemoverClienteEmpresa(int id)
        {
            ResultValidation retorno = serviceClienteEmpresa.Excluir(id);

            PreencherModelState(retorno);
        }

        #endregion

    }
}