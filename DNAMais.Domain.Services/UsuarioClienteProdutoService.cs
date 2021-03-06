﻿using DNAMais.Domain.Entidades;
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
    public class UsuarioClienteProdutoService
    {
        private DNAMaisSiteContext context;

        private Repository<UsuarioClienteProduto> repoUsuarioClienteProduto;
        private Repository<UsuarioCliente> repoUsuarioCliente;

        public UsuarioClienteProdutoService()
        {
            context = new DNAMaisSiteContext();
            repoUsuarioClienteProduto = new Repository<UsuarioClienteProduto>(context);
            repoUsuarioCliente = new Repository<UsuarioCliente>(context);
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public IQueryable<UsuarioClienteProduto> ListarPorId(int id)
        {
            return repoUsuarioClienteProduto.Filter(x => x.Id == id);
        }

        public ResultValidation Salvar(UsuarioClienteProduto usuarioClienteProduto)
        {
            ResultValidation returnValidation = new ResultValidation();

            if (!returnValidation.Ok) return returnValidation;

            try
            {
                if (usuarioClienteProduto.Id == null)
                {
                    repoUsuarioClienteProduto.Add(usuarioClienteProduto);
                }
                else
                {
                    repoUsuarioClienteProduto.Update(usuarioClienteProduto);
                }

                context.SaveChanges();
            }
            catch (Exception err)
            {
                returnValidation.AddMessage("", err);
            }

            return returnValidation;
        }

        public ResultValidation Excluir(int idUsuarioCliente, int codigoProduto)
        {
            ResultValidation returnValidation = new ResultValidation();

            if (!returnValidation.Ok) return returnValidation;

            try
            {
                repoUsuarioClienteProduto.Remove(idUsuarioCliente, codigoProduto);

                context.SaveChanges();
            }
            catch (Exception err)
            {
                returnValidation.AddMessage("", err);
            }

            return returnValidation;
        }

        public ResultValidation SalvarProdutosSelecionados(int idUsuarioCliente, List<string> produtosSelecionados)
        {
            ResultValidation returnValidation = new ResultValidation();
            UsuarioCliente usuarioCliente = repoUsuarioCliente.GetById(idUsuarioCliente);

            if (!returnValidation.Ok) return returnValidation;

            usuarioCliente.UsuarioClienteProdutosSelecionados.Clear();

            try
            {
                foreach (var item in produtosSelecionados)
                {
                    UsuarioClienteProduto usuarioClienteProduto = new UsuarioClienteProduto();

                    usuarioClienteProduto.Id = idUsuarioCliente;
                    usuarioClienteProduto.CodigoProduto = item;

                    repoUsuarioClienteProduto.Add(usuarioClienteProduto);
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
