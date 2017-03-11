using DNAMais.BackOffice.ActionFilters;
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
    [ValidateUrlActionFilter]
    public class ContratoEmpresaController : Controller
    {
        private ContratoEmpresaFacade facadeContratoEmpresa;
        private ProdutoFacade facadeProduto;
        private ContratoEmpresaProdutoFacade facadeContratoEmpresaProduto;
        //CCB private ContratoEmpresaPrecificacaoFacade facadeContratoEmpresaPrecificacao;
        private ContratoEmpresaPrecificacaoProdutoFacade facadeContratoEmpresaPrecificacaoProduto;
        private TransacaoConsultaFacade facadeTransacaoConsulta;

        public ContratoEmpresaController()
        {
            //REFATORAR ESSA BOSTA. CRIAR FACADES E SERVICES SEPARADAMENTE PARA CONTRATOEMPRESA, CONTRATOEMPRESAPRODUTO E PRECIFICACAO
            facadeContratoEmpresa = new ContratoEmpresaFacade(ModelState);
            facadeProduto = new ProdutoFacade(ModelState);
            facadeContratoEmpresaProduto = new ContratoEmpresaProdutoFacade(ModelState);
            //CCB facadeContratoEmpresaPrecificacao = new ContratoEmpresaPrecificacaoFacade(ModelState);
            facadeContratoEmpresaPrecificacaoProduto = new ContratoEmpresaPrecificacaoProdutoFacade(ModelState);
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

        //[AutorizacaoDnaMais]
        public ActionResult Remove(int id)
        {
            facadeContratoEmpresaPrecificacaoProduto.RemoverContratoEmpresaPrecificacao(id);

            if (ModelState.IsValid)
            {
                ViewData["Title"] = "DNA+ :: Contratos";
                ViewData["TituloPagina"] = "Contratos";
                ViewData["messageSuccess"] = "Contrato removido com sucesso";
                ViewData["messageReturn"] = "Voltar para lista de Contratos";

                return Json(new { success = true, responseText = string.Empty }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var errorText = Helpers.DnaMaisHelperModelState.GetErrorFriendly(ModelState);
                return Json(new { success = false, responseText = errorText }, JsonRequestBehavior.AllowGet);
            }
        }

        #region Produtos

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

        #endregion

        #region Precificação

        public ActionResult Precificacao(int id)
        {
            ContratoEmpresa contratoEmpresa = facadeContratoEmpresa.ListarContratoPorId(id);
            ContratoEmpresaPrecificacaoProduto model = new ContratoEmpresaPrecificacaoProduto
            {
                ContratoEmpresa = contratoEmpresa
            };

            return View("Precificacao", model);
        }

        [HttpPost]
        public ActionResult Precificacao(int idContrato, string codigoCategoria, FormCollection valores)
        {
            ContratoEmpresa contratoEmpresa = facadeContratoEmpresa.ListarContratoPorId(idContrato);

            //List<ContratoEmpresaPrecificacao> precificacoes = new List<ContratoEmpresaPrecificacao>();

            //string valorFaixaA = valores["valor_A"];
            //string valorFaixaB = valores["valor_B"];
            //string valorFaixaC = valores["valor_C"];
            //string valorFaixaD = valores["valor_D"];

            //double valorConsulta = 0;

            //foreach (ContratoEmpresaPrecificacao precificacao in contratoEmpresa.ContratosEmpresasPrecificacoes.Where(i => i.CodigoCategoriaConsulta == codigoCategoria))
            //{
            //    if (precificacao.CodigoFaixa == "A")
            //    {
            //        valorConsulta = double.Parse(valorFaixaA);
            //    }
            //    if (precificacao.CodigoFaixa == "B")
            //    {
            //        valorConsulta = double.Parse(valorFaixaB);
            //    }
            //    if (precificacao.CodigoFaixa == "C")
            //    {
            //        valorConsulta = double.Parse(valorFaixaC);
            //    }
            //    if (precificacao.CodigoFaixa == "D")
            //    {
            //        valorConsulta = double.Parse(valorFaixaD);
            //    }

            //    precificacoes.Add(new ContratoEmpresaPrecificacao
            //    {
            //        IdContratoEmpresa = idContrato,
            //        CodigoCategoriaConsulta = codigoCategoria,
            //        CodigoFaixa = precificacao.CodigoFaixa,
            //        DescricaoFaixa = precificacao.DescricaoFaixa,
            //        InicioFaixa = precificacao.InicioFaixa,
            //        TerminoFaixa = precificacao.TerminoFaixa,
            //        ValorConsulta = valorConsulta
            //    });
            //}

            //facadeContratoEmpresaPrecificacao.SalvarContratoEmpresaPrecificacao(precificacoes);


            return View("Cadastro", contratoEmpresa);
        }

        public ActionResult PrecificacaoProduto(string idContrato, string codigoProduto)
        {
            List<ContratoEmpresaPrecificacaoProduto> faixas = facadeContratoEmpresaPrecificacaoProduto.ListarFaixas(Convert.ToInt32(idContrato), codigoProduto).ToList();

            return PartialView("~/Areas/Cadastros/Views/ContratoEmpresa/PrecificacaoFaixa.cshtml", faixas);
        }

        //[HttpPost]
        public ActionResult PrecificacaoCadastro(string idContrato, string codigoProduto)
        {
            ContratoEmpresa contratoEmpresa = facadeContratoEmpresa.ListarContratoPorId(Convert.ToInt32(idContrato));
            Produto produto = facadeProduto.ConsultarProdutoPorId(codigoProduto);

            ContratoEmpresaPrecificacaoProduto model = new ContratoEmpresaPrecificacaoProduto
            {
                ContratoEmpresa = contratoEmpresa,
                CodigoProduto = codigoProduto,
                Produto = produto
            };

            return View("PrecificacaoCadastro", model);
        }

        [HttpPost]
        //[AutorizacaoDnaMais]
        public ActionResult CreateFaixaxxx(ContratoEmpresaPrecificacaoProduto contratoEmpresaPrecificacaoProduto)
        {
            facadeContratoEmpresaPrecificacaoProduto.SalvarContratoEmpresaPrecificacao(contratoEmpresaPrecificacaoProduto);
            return View("PrecificacaoCadastro", contratoEmpresaPrecificacaoProduto);
        }

        [HttpPost]
        public JsonResult Save(string id, string idContrato, string codigoProduto, string inicio, string termino, string valor)
        {
            try
            {
                int codigo;
                double valor_teste;
                if (codigoProduto.Trim().Length > 0 && int.TryParse(idContrato, out codigo) && int.TryParse(inicio, out codigo) &&
                    int.TryParse(termino, out codigo) && double.TryParse(valor.Replace(".", "").Replace(",", "."), out valor_teste))
                {
                    ContratoEmpresaPrecificacaoProduto preco = new ContratoEmpresaPrecificacaoProduto
                    {
                        Id = (int.TryParse(id, out codigo) ? Convert.ToInt32(id) : (int?)null),
                        IdContratoEmpresa = Convert.ToInt32(idContrato),
                        CodigoProduto = codigoProduto,
                        InicioFaixa = Convert.ToInt32(inicio),
                        TerminoFaixa = Convert.ToInt32(termino),
                        ValorConsulta = Convert.ToDouble(valor.Replace(".", ""))
                    };

                    facadeContratoEmpresaPrecificacaoProduto.SalvarContratoEmpresaPrecificacao(preco);

                    if (ModelState.IsValid)
                    {
                        return new JsonResult
                        {
                            Data = new { ErrorMessage = "", Success = true },
                            ContentEncoding = System.Text.Encoding.UTF8,
                            JsonRequestBehavior = JsonRequestBehavior.AllowGet
                        };
                    }
                    else
                    {
                        var errorText = Helpers.DnaMaisHelperModelState.GetErrors(ModelState);
                        return new JsonResult
                        {
                            Data = new { ErrorMessage = errorText, Success = false },
                            ContentEncoding = System.Text.Encoding.UTF8,
                            JsonRequestBehavior = JsonRequestBehavior.AllowGet
                        };
                    }
                }
                else
                {
                    return new JsonResult
                    {
                        Data = new { ErrorMessage = "Dados Invalidos", Success = false },
                        ContentEncoding = System.Text.Encoding.UTF8,
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    };
                }
            }
            catch (Exception ex)
            {
                return new JsonResult
                {
                    Data = new { ErrorMessage = ex.Message, Success = false },
                    ContentEncoding = System.Text.Encoding.UTF8,
                    JsonRequestBehavior = JsonRequestBehavior.DenyGet
                };
            }

            return null;
        }

        public JsonResult Edit(string id)
        {

            try
            {
                int valueTest;

                if (int.TryParse(id, out valueTest))
                {

                    ContratoEmpresaPrecificacaoProduto preco = facadeContratoEmpresaPrecificacaoProduto.ConsultarPorId(Convert.ToInt32(id));

                    if (preco.Id > 0)
                    {
                        return new JsonResult
                        {
                            Data = new
                            {
                                Success = true,
                                id = preco.Id,
                                idContratoEmpresa = preco.ContratoEmpresa.Id,
                                codigoProduto = preco.CodigoProduto,
                                nomeProduto = preco.Produto.CategoriaProduto.Nome + " - " + preco.Produto.Nome,
                                inicio = preco.InicioFaixa,
                                termino = preco.TerminoFaixa,
                                valor = preco.ValorConsulta.ToString().Replace(".", ",")
                            },
                            ContentEncoding = System.Text.Encoding.UTF8,
                            JsonRequestBehavior = JsonRequestBehavior.AllowGet
                        };
                    }
                }
                else
                {
                    return new JsonResult
                    {
                        Data = new { ErrorMessage = "Ocorreu um erro na consulta", Success = false },
                        ContentEncoding = System.Text.Encoding.UTF8,
                        JsonRequestBehavior = JsonRequestBehavior.DenyGet
                    };
                }

            }
            catch (Exception ex)
            {
                return new JsonResult
                {
                    Data = new { ErrorMessage = ex.Message, Success = false },
                    ContentEncoding = System.Text.Encoding.UTF8,
                    JsonRequestBehavior = JsonRequestBehavior.DenyGet
                };
            }


            return null;
        }

        public ActionResult RemoveFaixa(short id)
        {
            facadeContratoEmpresaPrecificacaoProduto.RemoverContratoEmpresaPrecificacao(id);

            if (ModelState.IsValid)
            {
                return Json(new { success = true, responseText = string.Empty }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var errorText = Helpers.DnaMaisHelperModelState.GetErrorFriendly(ModelState);
                return Json(new { success = false, responseText = errorText }, JsonRequestBehavior.AllowGet);
            }

        }

        #endregion


    }
}