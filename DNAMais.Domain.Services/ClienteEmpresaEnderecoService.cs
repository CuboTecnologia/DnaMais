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
    public class ClienteEmpresaEnderecoService
    {
        private DNAMaisSiteContext context;

        private Repository<ClienteEmpresaEndereco> repoClienteEmpresaEndereco;

        public ClienteEmpresaEnderecoService()
        {
            context = new DNAMaisSiteContext();
            repoClienteEmpresaEndereco = new Repository<ClienteEmpresaEndereco>(context);
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public IQueryable<ClienteEmpresaEndereco> ListarPorClienteEmpresa(int idClienteEmpresa)
        {
            return repoClienteEmpresaEndereco.Filter(i => i.IdClienteEmpresa == idClienteEmpresa);
        }

        public ClienteEmpresaEndereco ConsultarPorId(int id)
        {
            return repoClienteEmpresaEndereco.GetById(id);
        }

        public ResultValidation Salvar(ClienteEmpresaEndereco clienteEmpresaEndereco)
        {
            ResultValidation returnValidation = new ResultValidation();

            if (!returnValidation.Ok) return returnValidation;

            try
            {
                if (clienteEmpresaEndereco.Id == null)
                {
                    clienteEmpresaEndereco.DataCadastro = DateTime.Now;

                    repoClienteEmpresaEndereco.Add(clienteEmpresaEndereco);
                }
                else
                {
                    repoClienteEmpresaEndereco.Update(clienteEmpresaEndereco);
                }

                context.SaveChanges();
            }
            catch (Exception err)
            {
                returnValidation.AddMessage("", err.Message);
            }

            return returnValidation;
        }

        public void Excluir(int id)
        {
            repoClienteEmpresaEndereco.Remove(id);
        }
    }
}
