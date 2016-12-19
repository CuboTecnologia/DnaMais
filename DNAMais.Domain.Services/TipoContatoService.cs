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
    public class TipoContatoService
    {
        private DNAMaisSiteContext context;

        private Repository<TipoContato> repoTipoContato;

        public TipoContatoService()
        {
            context = new DNAMaisSiteContext();
            repoTipoContato = new Repository<TipoContato>(context);
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public IQueryable<TipoContato> ListarTodos()
        {
            return repoTipoContato.GetAll();
        }

        public TipoContato ConsultarPorId(int id)
        {
            return repoTipoContato.GetById(id);
        }

        public ResultValidation Incluir(TipoContato tipoContato)
        {
            ResultValidation returnValidation = new ResultValidation();

            if (repoTipoContato.Exists(i => i.Nome.ToUpper().Trim() == tipoContato.Nome.ToUpper().Trim() &&
                i.Id != tipoContato.Id))
            {
                returnValidation.AddMessage("Nome", "Nome já cadastrado.");
            }

            if (!returnValidation.Ok) return returnValidation;

            try
            {
                repoTipoContato.Add(tipoContato);

                context.SaveChanges();
            }
            catch (Exception err)
            {
                returnValidation.AddMessage("", err.Message);
            }

            return returnValidation;
        }

        public ResultValidation Alterar(TipoContato tipoContato)
        {
            ResultValidation returnValidation = new ResultValidation();

            if (repoTipoContato.Exists(i => i.Nome.ToUpper().Trim() == tipoContato.Nome.ToUpper().Trim() &&
                i.Id != tipoContato.Id))
            {
                returnValidation.AddMessage("Nome", "Nome já cadastrado.");
            }

            if (!returnValidation.Ok) return returnValidation;

            try
            {
                repoTipoContato.Update(tipoContato);

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
                repoTipoContato.Remove(id);

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
