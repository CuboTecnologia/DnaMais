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
    public class GrupoUsuarioClienteService
    {
        private DNAMaisSiteContext context;

        private Repository<GrupoUsuarioCliente> repoGrupoUsuarioCliente;

        public GrupoUsuarioClienteService()
        {
            context = new DNAMaisSiteContext();
            repoGrupoUsuarioCliente = new Repository<GrupoUsuarioCliente>(context);
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public IQueryable<GrupoUsuarioCliente> ListarTodos()
        {
            return repoGrupoUsuarioCliente.GetAll();
        }

        public GrupoUsuarioCliente ConsultarPorId(int id)
        {
            return repoGrupoUsuarioCliente.GetById(id);
        }

        public ResultValidation Salvar(GrupoUsuarioCliente grupoUsuarioCliente)
        {
            ResultValidation returnValidation = new ResultValidation();

            if (repoGrupoUsuarioCliente.Contains(m => m.Nome == grupoUsuarioCliente.Nome && m.IdClienteEmpresa == grupoUsuarioCliente.IdClienteEmpresa))
            {
                returnValidation.AddMessage("Nome", "Já existe um grupo cadastrado com esse nome para o cliente selecionado.");
            }

            if (!returnValidation.Ok) return returnValidation;

            try
            {
                if (grupoUsuarioCliente.Id == null)
                {
                    repoGrupoUsuarioCliente.Add(grupoUsuarioCliente);
                }
                else
                {
                    repoGrupoUsuarioCliente.Update(grupoUsuarioCliente);
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
                repoGrupoUsuarioCliente.Remove(id);

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
