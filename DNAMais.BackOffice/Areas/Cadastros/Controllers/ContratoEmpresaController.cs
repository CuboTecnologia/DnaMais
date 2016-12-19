using DNAMais.BackOffice.Facades;
using DNAMais.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DNAMais.BackOffice.Areas.Cadastros.Controllers
{
    public class ContratoEmpresaController : Controller
    {
        private ContratoEmpresaFacade facadeContratoEmpresa;
        private ProdutoFacade facadeProduto;
        private ContratoEmpresaProdutoFacade facadeContratoEmpresaProduto;
        private ContratoEmpresaPrecificacaoFacade facadeContratoEmpresaPrecificacao;
        private TransacaoConsultaFacade facadeTransacaoConsulta;

        public ContratoEmpresaController()
        {
            //REFATORAR ESSA BOSTA. CRIAR FACADES E SERVICES SEPARADAMENTE PARA CONTRATOEMPRESA, CONTRATOEMPRESAPRODUTO E PRECIFICACAO
            facadeContratoEmpresa = new ContratoEmpresaFacade(ModelState);
            facadeProduto = new ProdutoFacade(ModelState);
            facadeContratoEmpresaProduto = new ContratoEmpresaProdutoFacade(ModelState);
            facadeContratoEmpresaPrecificacao = new ContratoEmpresaPrecificacaoFacade(ModelState);
            facadeTransacaoConsulta = new TransacaoConsultaFacade(ModelState);
        }

        protected override void Initialize(RequestContext context)
        {
            base.Initialize(context);

            ViewBag.Menu = "MENU-CONTRATO";
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (disposing && this.facadeContratoEmpresa != null)
            {
                this.facadeContratoEmpresa.Dispose();
            }
        }

        //[AutorizacaoDnaMais]
        public ActionResult Index()
        {
            return View(facadeContratoEmpresa.ListarContratos());
        }

        //[AutorizacaoDnaMais]
        public ActionResult Details(int id)
        {
            ViewData["LOCKED"] = true;
            return View("Cadastro", facadeContratoEmpresa.ListarContratoPorId(id));
        }

        //[AutorizacaoDnaMais]
        public ActionResult Create()
        {
            return View("Cadastro", new ContratoEmpresa());
        }

        [HttpPost]
        //[AutorizacaoDnaMais]
        public ActionResult Create(ContratoEmpresa contratoEmpresa)
        {
            facadeContratoEmpresa.SalvarContratoEmpresa(contratoEmpresa);
            return View("Cadastro", contratoEmpresa);
        }

        public ActionResult Produtos(int id)
        {
            ContratoEmpresa contratoEmpresa = facadeContratoEmpresa.ListarContratoPorId(id);

            ViewBag.NomeEmpresa = contratoEmpresa.ClienteEmpresa.RazaoSocial;
            ViewBag.IdContrato = contratoEmpresa.Id;
            ViewBag.Produtos = contratoEmpresa.ContratosEmpresasProdutos;

            return View("Produtos", facadeProduto.ListarProdutos());
        }

        [HttpPost]
        public ActionResult Produtos(int idContrato, List<string> produtosSelecionados)
        {
            facadeContratoEmpresaProduto.SalvarContratoEmpresaProduto(idContrato, produtosSelecionados);

            ContratoEmpresa contratoEmpresa = facadeContratoEmpresa.ListarContratoPorId(idContrato);

            return View("Cadastro", contratoEmpresa);
        }

        public ActionResult Precificacao(int id)
        {
            ContratoEmpresa contratoEmpresa = facadeContratoEmpresa.ListarContratoPorId(id);

            ViewBag.NomeEmpresa = contratoEmpresa.ClienteEmpresa.NomeFantasia;
            ViewBag.IdContrato = contratoEmpresa.Id;

            return View("Precificacao", contratoEmpresa.ContratosEmpresasPrecificacoes.ToList());
        }

        [HttpPost]
        public ActionResult Precificacao(int idContrato, string codigoCategoria, FormCollection valores)
        {
            ContratoEmpresa contratoEmpresa = facadeContratoEmpresa.ListarContratoPorId(idContrato);

            List<ContratoEmpresaPrecificacao> precificacoes = new List<ContratoEmpresaPrecificacao>();

            string valorFaixaA = valores["valor_A"];
            string valorFaixaB = valores["valor_B"];
            string valorFaixaC = valores["valor_C"];
            string valorFaixaD = valores["valor_D"];

            double valorConsulta = 0;

            foreach (ContratoEmpresaPrecificacao precificacao in contratoEmpresa.ContratosEmpresasPrecificacoes.Where(i => i.CodigoCategoriaConsulta == codigoCategoria))
            {
                if (precificacao.CodigoFaixa == "A")
                {
                    valorConsulta = double.Parse(valorFaixaA);
                }
                if (precificacao.CodigoFaixa == "B")
                {
                    valorConsulta = double.Parse(valorFaixaB);
                }
                if (precificacao.CodigoFaixa == "C")
                {
                    valorConsulta = double.Parse(valorFaixaC);
                }
                if (precificacao.CodigoFaixa == "D")
                {
                    valorConsulta = double.Parse(valorFaixaD);
                }

                precificacoes.Add(new ContratoEmpresaPrecificacao
                {
                    IdContratoEmpresa = idContrato,
                    CodigoCategoriaConsulta = codigoCategoria,
                    CodigoFaixa = precificacao.CodigoFaixa,
                    DescricaoFaixa = precificacao.DescricaoFaixa,
                    InicioFaixa = precificacao.InicioFaixa,
                    TerminoFaixa = precificacao.TerminoFaixa,
                    ValorConsulta = valorConsulta
                });
            }

            facadeContratoEmpresaPrecificacao.SalvarContratoEmpresaPrecificacao(precificacoes);


            return View("Cadastro", contratoEmpresa);
        }

        //[AutorizacaoDnaMais]
        public ActionResult Remove(int id)
        {
            facadeContratoEmpresaPrecificacao.RemoverContratoEmpresaPrecificacao(id);

            facadeContratoEmpresaProduto.RemoverContratoEmpresaProduto(id);

            facadeTransacaoConsulta.RemoverConsultaTransacao(id);
                
            facadeContratoEmpresa.RemoverContratoEmpresa(id);
            

            ViewData["Title"] = "DNA+ :: Contratos";
            ViewData["TituloPagina"] = "Contratos";
            ViewData["messageSuccess"] = "Contrato removido com sucesso";
            ViewData["messageReturn"] = "Voltar para lista de Contratos";

            return View("_Remove");
        }
    }
}