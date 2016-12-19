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
    public class RamoAtividadeService
    {
        private DNAMaisSiteContext context;

        private Repository<RamoAtividade> repoRamoAtividade;

        public RamoAtividadeService()
        {
            context = new DNAMaisSiteContext();
            repoRamoAtividade = new Repository<RamoAtividade>(context);
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public IQueryable<RamoAtividade> ListarTodos()
        {
            return repoRamoAtividade.GetAll();
        }

        public RamoAtividade ConsultarPorId(int id)
        {
            return repoRamoAtividade.GetById(id);
        }

        public ResultValidation Salvar(RamoAtividade ramoAtividade)
        {
            ResultValidation returnValidation = new ResultValidation();

            if (repoRamoAtividade.Exists(i => i.Nome.ToUpper().Trim() == ramoAtividade.Nome.ToUpper().Trim() &&
                i.Id != ramoAtividade.Id))
            {
                returnValidation.AddMessage("Nome", "Nome já cadastrado.");
            }

            if (!returnValidation.Ok) return returnValidation;

            try
            {
                if (ramoAtividade.Id == null)
                {
                    repoRamoAtividade.Add(ramoAtividade);
                }
                else
                {
                    repoRamoAtividade.Update(ramoAtividade);
                }

                context.SaveChanges();
            }
            catch (Exception err)
            {
                returnValidation.AddMessage("", err.Message);
            }

            return returnValidation;
        }

        public ResultValidation Excluir(int id)
        {
            ResultValidation returnValidation = new ResultValidation();

            if (!returnValidation.Ok) return returnValidation;

            try
            {
                repoRamoAtividade.Remove(id);

                context.SaveChanges();
            }
            catch (Exception err)
            {
                returnValidation.AddMessage("", err.Message);
            }

            return returnValidation;
        }
    }
}
