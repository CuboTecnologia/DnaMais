using DNAMais.Domain.Entidades;
using DNAMais.Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNAMais.Domain.Services
{
    public class TesteServico
    {
        private readonly RepositorioGenerico<MensagemContato> repositorio;

        public TesteServico()
        {
            repositorio = new RepositorioGenerico<MensagemContato>();
        }

        public List<MensagemContato> ListarMensagens()
        {
            return repositorio.ListarTodos();
        }

        public List<MensagemContato> ListarMensagensPendentes()
        {
            return repositorio.Filtrar(i => i.DataResposta == null && i.DataRegistro >= DateTime.Now.AddDays(-15));
        }

        public void Remover(int id)
        {
            repositorio.Excluir(id);
        }

        public void RemoverPendentesAntigos()
        {
            repositorio.Excluir(i => i.DataResposta == null && i.DataRegistro >= DateTime.Now.AddDays(-15));
        }
    }
}
