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
    public class TransacaoConsultaService
    {
        private DNAMaisSiteContext context;

        private Repository<TransacaoConsulta> repoTransacaoConsulta;

        public TransacaoConsultaService()
        {
            context = new DNAMaisSiteContext();
            repoTransacaoConsulta = new Repository<TransacaoConsulta>(context);
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public ResultValidation Excluir(int id)
        {
            ResultValidation returnValidation = new ResultValidation();

            List<int?> transacoes = context.TransacoesConsultas.Where(u => u.ContratoEmpresa.Id == id).Select(u => u.Id).ToList();

            if (!returnValidation.Ok) return returnValidation;

            try
            {
                foreach (var transacao in transacoes)
                {
                    repoTransacaoConsulta.Remove(transacao);

                    context.SaveChanges();
                }

            }
            catch (Exception err)
            {
                returnValidation.AddMessage("", err);
            }

            return returnValidation;
        }
    }
}
