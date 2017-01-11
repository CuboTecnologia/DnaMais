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
    public class ProdutoService
    {
        private DNAMaisSiteContext context;

        private Repository<Produto> repoProduto;

        public ProdutoService()
        {
            context = new DNAMaisSiteContext();
            repoProduto = new Repository<Produto>(context);
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public IQueryable<Produto> ListarTodos()
        {
            return repoProduto.GetAll();
        }

        public Produto ConsultarPorId(string id)
        {
            return repoProduto.GetById(id);
        }

        public ResultValidation Alterar(Produto produto)
        {
            ResultValidation returnValidation = new ResultValidation();

            if (repoProduto.Exists(i => i.Descricao.ToUpper().Trim() == produto.Descricao.ToUpper().Trim() &&
                i.Id != produto.Id))
            {
                returnValidation.AddMessage("Descrição", "Descrição já cadastrada.");
            }

            if (!returnValidation.Ok) return returnValidation;

            try
            {
                repoProduto.Update(produto);

                context.SaveChanges();
            }
            catch (Exception err)
            {
                returnValidation.AddMessage("", err);
            }

            return returnValidation;
        }

        public ResultValidation Salvar(Produto produto)
        {
            ResultValidation returnValidation = new ResultValidation();

            if (repoProduto.Exists(i => i.Descricao.ToUpper().Trim() == produto.Descricao.ToUpper().Trim() &&
                i.Id != produto.Id))
            {
                returnValidation.AddMessage("Descricao", "Descrição já cadastrada.");
            }

            if (!returnValidation.Ok) return returnValidation;

            try
            {
                if (produto.Id == null)
                {
                    repoProduto.Add(produto);
                }
                else
                {
                    repoProduto.Update(produto);
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
