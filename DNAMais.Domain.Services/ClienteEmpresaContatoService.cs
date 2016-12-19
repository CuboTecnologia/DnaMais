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
    public class ClienteEmpresaContatoService
    {
        private DNAMaisSiteContext context;

        private Repository<ClienteEmpresaContato> repoClienteEmpresaContato;

        public ClienteEmpresaContatoService()
        {
            context = new DNAMaisSiteContext();
            repoClienteEmpresaContato = new Repository<ClienteEmpresaContato>(context);
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public IQueryable<ClienteEmpresaContato> ListarPorClienteEmpresa(int idClienteEmpresa)
        {
            return repoClienteEmpresaContato.Filter(i => i.IdClienteEmpresa == idClienteEmpresa);
        }

        public ClienteEmpresaContato ConsultarPorId(int id)
        {
            return repoClienteEmpresaContato.GetById(id);
        }

        public ResultValidation Salvar(ClienteEmpresaContato clienteEmpresaContato)
        {
            ResultValidation returnValidation = new ResultValidation();

            if (!returnValidation.Ok) return returnValidation;

            try
            {
                if (clienteEmpresaContato.Id == null)
                {
                    clienteEmpresaContato.DataCadastro = DateTime.Now;

                    repoClienteEmpresaContato.Add(clienteEmpresaContato);
                }
                else
                {
                    repoClienteEmpresaContato.Update(clienteEmpresaContato);
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
            repoClienteEmpresaContato.Remove(id);
        }
    }
}
