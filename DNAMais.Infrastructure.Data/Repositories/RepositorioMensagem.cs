using DNAMais.Domain;
using DNAMais.Domain.Entidades;
using DNAMais.Infrastructure.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNAMais.Infrastructure.Data.Repositories
{
    public class RepositorioMensagem
    {
        DNAMaisSiteContext context;

        public RepositorioMensagem()
        {
            context = new DNAMaisSiteContext();
        }

        //public List<MensagemContato> ListarTodos()
        //{
        //    return context.Messages.ToList();
        //}
    }
}
