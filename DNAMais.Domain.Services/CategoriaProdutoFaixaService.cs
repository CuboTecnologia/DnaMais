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
    public class CategoriaProdutoFaixaService
    {
        private DNAMaisSiteContext context;

        private Repository<CategoriaProdutoFaixa> repoCategoriaProdutoFaixa;

        public CategoriaProdutoFaixaService()
        {
            context = new DNAMaisSiteContext();

            repoCategoriaProdutoFaixa = new Repository<CategoriaProdutoFaixa>(context);
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public IQueryable<CategoriaProdutoFaixa> ListarTodos()
        {
            return repoCategoriaProdutoFaixa.GetAll();
        }

        public CategoriaProdutoFaixa ConsultarPorId(string id)
        {
            return repoCategoriaProdutoFaixa.GetById(id);
        }

        public ResultValidation Salvar(CategoriaProdutoFaixa categoriaProdutoFaixa)
        {
            ResultValidation returnValidation = new ResultValidation();

            if (!returnValidation.Ok) return returnValidation;

            try
            {
                if (categoriaProdutoFaixa.CodigoCategoria == null)
                {
                    repoCategoriaProdutoFaixa.Add(categoriaProdutoFaixa);
                }
                else
                {
                    repoCategoriaProdutoFaixa.Update(categoriaProdutoFaixa);
                }

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
