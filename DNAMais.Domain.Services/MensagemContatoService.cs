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
    public class MensagemContatoService
    {
        private DNAMaisSiteContext context;

        private Repository<MensagemContato> repoMensagemContato;

        public MensagemContatoService()
        {
            context = new DNAMaisSiteContext();
            repoMensagemContato = new Repository<MensagemContato>(context);
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public MensagemContato ConsultarPorId(int id)
        {
            return repoMensagemContato.GetById(id);
        }

        public ResultValidation Salvar(MensagemContato mensagemContato)
        {
            ResultValidation returnValidation = new ResultValidation();

            if (!returnValidation.Ok) return returnValidation;

            try
            {
                if (mensagemContato.Id == null)
                {
                    mensagemContato.DataRegistro = DateTime.Now;
                    mensagemContato.Respondida = false;

                    repoMensagemContato.Add(mensagemContato);
                }
                else
                {
                    repoMensagemContato.Update(mensagemContato);
                }

                context.SaveChanges();
            }
            catch (Exception err)
            {
                returnValidation.AddMessage("", err.Message);
            }

            return returnValidation;
        }

        public void Excluir(int id)
        {
            repoMensagemContato.Remove(id);
        }

        public IQueryable<MensagemContato> ListarRespondidas()
        {
            return repoMensagemContato.Filter(i => i.MensagemRespondida == "S");
        }

        public IQueryable<MensagemContato> ListarNaoRespondidas()
        {
            return repoMensagemContato.Filter(i => i.MensagemRespondida == "N");
        }

    }
}
