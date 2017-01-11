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
    public class ClienteEmpresaService
    {
        private DNAMaisSiteContext context;

        private Repository<ClienteEmpresa> repoClienteEmpresa;

        public ClienteEmpresaService()
        {
            context = new DNAMaisSiteContext();
            repoClienteEmpresa = new Repository<ClienteEmpresa>(context);
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public IQueryable<ClienteEmpresa> ListarTodos()
        {
            return repoClienteEmpresa.GetAll();
        }

        public ClienteEmpresa ConsultarPorId(int id)
        {
            return repoClienteEmpresa.GetById(id);
        }

        public ResultValidation Salvar(ClienteEmpresa clienteEmpresa)
        {
            ResultValidation returnValidation = new ResultValidation();

            if (!returnValidation.Ok) return returnValidation;

            var cnpj = clienteEmpresa.Cnpj.LimparCaracteresCNPJ();

            if (repoClienteEmpresa.Exists(i => i.Cnpj == cnpj &&
                i.Id != clienteEmpresa.Id))
            {
                returnValidation.AddMessage("CNPJ", "CNPJ já cadastrado.");
            }

            clienteEmpresa.Cnpj = cnpj;

            try
            {
                if (clienteEmpresa.Id == null)
                {
                    repoClienteEmpresa.Add(clienteEmpresa);
                }
                else
                {
                    repoClienteEmpresa.Update(clienteEmpresa);
                }

                context.SaveChanges();
            }
            catch (Exception err)
            {
                returnValidation.AddMessage("", err);
            }

            return returnValidation;
        }

        public ResultValidation Excluir(int id)
        {
            ResultValidation returnValidation = new ResultValidation();

            if (!returnValidation.Ok) return returnValidation;

            try
            {
                repoClienteEmpresa.Remove(id);

                context.SaveChanges();
            }
            catch (Exception err)
            {
                returnValidation.AddMessage("", err);
            }

            return returnValidation;
        }
    }
}
