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
    public class TipoPrecificacaoService
    {
        private DNAMaisSiteContext context;

        private Repository<TipoPrecificacao> repoTipoPrecificacao;

        public TipoPrecificacaoService()
        {
            context = new DNAMaisSiteContext();
            repoTipoPrecificacao = new Repository<TipoPrecificacao>(context);
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public IQueryable<TipoPrecificacao> ListarTodos()
        {
            return repoTipoPrecificacao.GetAll();
        }

        public TipoPrecificacao ConsultarPorId(byte id)
        {
            return repoTipoPrecificacao.GetById(id);
        }
    }
}
