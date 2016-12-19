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
    public class ClienteEmpresaContatoFoneService
    {
        private DNAMaisSiteContext context;

        private Repository<ClienteEmpresaContatoFone> repoClienteEmpresaContatoFone;

        public ClienteEmpresaContatoFoneService()
        {
            context = new DNAMaisSiteContext();
            repoClienteEmpresaContatoFone = new Repository<ClienteEmpresaContatoFone>(context);
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public IQueryable<ClienteEmpresaContatoFone> ListarPorContato(int idClienteEmpresaContato)
        {
            return repoClienteEmpresaContatoFone.Filter(i => i.IdClienteEmpresaContato == idClienteEmpresaContato);
        }

        public ClienteEmpresaContatoFone ConsultarPorId(int id)
        {
            return repoClienteEmpresaContatoFone.GetById(id);
        }

        public ResultValidation Salvar(ClienteEmpresaContatoFone clienteEmpresaContatoFone)
        {
            ResultValidation returnValidation = new ResultValidation();

            if (!returnValidation.Ok) return returnValidation;

            try
            {
                if (clienteEmpresaContatoFone.Id == null)
                {
                    clienteEmpresaContatoFone.DataCadastro = DateTime.Now;

                    repoClienteEmpresaContatoFone.Add(clienteEmpresaContatoFone);
                }
                else
                {
                    repoClienteEmpresaContatoFone.Update(clienteEmpresaContatoFone);
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
            repoClienteEmpresaContatoFone.Remove(id);
        }
    }
}
