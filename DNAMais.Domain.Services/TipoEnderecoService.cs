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
    public class TipoEnderecoService
    {
        private DNAMaisSiteContext context;

        private Repository<TipoEndereco> repoTipoEndereco;

        public TipoEnderecoService()
        {
            context = new DNAMaisSiteContext();
            repoTipoEndereco = new Repository<TipoEndereco>(context);
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public IQueryable<TipoEndereco> ListarTodos()
        {
            return repoTipoEndereco.GetAll();
        }

        public TipoEndereco ConsultarPorId(int id)
        {
            return repoTipoEndereco.GetById(id);
        }

        public ResultValidation Incluir(TipoEndereco tipoEndereco)
        {
            ResultValidation returnValidation = new ResultValidation();

            if (!returnValidation.Ok) return returnValidation;

            try
            {
                repoTipoEndereco.Add(tipoEndereco);

                context.SaveChanges();
            }
            catch (Exception err)
            {
                returnValidation.AddMessage("", err);
            }

            return returnValidation;
        }

        public ResultValidation Alterar(TipoEndereco tipoEndereco)
        {
            ResultValidation returnValidation = new ResultValidation();

            if (!returnValidation.Ok) return returnValidation;

            try
            {
                repoTipoEndereco.Update(tipoEndereco);

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
                repoTipoEndereco.Remove(id);

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
