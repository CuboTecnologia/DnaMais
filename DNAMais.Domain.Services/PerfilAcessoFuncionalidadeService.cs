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
    public class PerfilAcessoFuncionalidadeService
    {
        private DNAMaisSiteContext context;

        private Repository<PerfilAcessoFuncionalidade> repoPerfilAcessoFuncionalidade;

        public PerfilAcessoFuncionalidadeService()
        {
            context = new DNAMaisSiteContext();
            repoPerfilAcessoFuncionalidade = new Repository<PerfilAcessoFuncionalidade>(context);
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public ResultValidation Excluir(byte id)
        {
            ResultValidation returnValidation = new ResultValidation();

            if (!returnValidation.Ok) return returnValidation;

            try
            {
                repoPerfilAcessoFuncionalidade.Remove(i => i.IdPerfilBackOffice == id);

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