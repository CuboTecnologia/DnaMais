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
    public class ClienteEmpresaContatoEmailService
    {
        private DNAMaisSiteContext context;

        private Repository<ClienteEmpresaContatoEmail> repoClienteEmpresaContatoEmail;

        public ClienteEmpresaContatoEmailService()
        {
            context = new DNAMaisSiteContext();
            repoClienteEmpresaContatoEmail = new Repository<ClienteEmpresaContatoEmail>(context);
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public IQueryable<ClienteEmpresaContatoEmail> ListarPorContato(int idClienteEmpresaContato)
        {
            return repoClienteEmpresaContatoEmail.Filter(i => i.IdClienteEmpresaContato == idClienteEmpresaContato);
        }

        public ClienteEmpresaContatoEmail ConsultarPorId(int id)
        {
            return repoClienteEmpresaContatoEmail.GetById(id);
        }

        public ResultValidation Salvar(ClienteEmpresaContatoEmail clienteEmpresaContatoEmail)
        {
            ResultValidation returnValidation = new ResultValidation();

            if (!returnValidation.Ok) return returnValidation;

            try
            {
                if (clienteEmpresaContatoEmail.Id == null)
                {
                    clienteEmpresaContatoEmail.DataCadastro = DateTime.Now;

                    repoClienteEmpresaContatoEmail.Add(clienteEmpresaContatoEmail);
                }
                else
                {
                    repoClienteEmpresaContatoEmail.Update(clienteEmpresaContatoEmail);
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
            repoClienteEmpresaContatoEmail.Remove(id);
        }
    }
}
