using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DNAMais.Domain.Entidades;
using DNAMais.Domain.Entidades.Consultas;
using DNAMais.Framework;
using DNAMais.Site.Facades;
using DNAMais.Site.Models;

namespace DNAMais.Site.Controllers
{
    public class AreaRestritaController : Controller
    {
        PessoaFisicaFacade facadePF;
        PessoaJuridicaFacade facadePJ;

        private readonly int _idClienteEmpresa;
        private readonly int _idContratoEmpresa;
        private readonly int _idUsuarioCliente;

        public AreaRestritaController()
        {
            facadePF = new PessoaFisicaFacade(ModelState);
            facadePJ = new PessoaJuridicaFacade(ModelState);

            _idClienteEmpresa = 1;
            _idContratoEmpresa = 3;
            _idUsuarioCliente = 21;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (disposing && facadePF != null)
            {
                facadePF.Dispose();
            }

            if (disposing && facadePJ != null)
            {
                facadePJ.Dispose();
            }
        }

        private void PreencherDadosTransacao(TransacaoConsulta transacao)
        {
            ViewBag.NumeroTransacao = transacao.Id.ToString().PadLeft(8, '0');
            ViewBag.DataTransacao = transacao.DataTransacao.FormatarDataHora();
        }

        public ActionResult ProdutosContratados()
        {
            var model = new AreaRestritaModel()
            {
                UsuarioCliente = CarregaDadosUsuarioCliente()
            };

            return View(model);
        }

        public ActionResult PesquisaVeiculo()
        {
            var model = new AreaRestritaModel()
            {
                UsuarioCliente = CarregaDadosUsuarioCliente()
            };

            return View(model);
        }

        public ActionResult ListarMunicipios(string uf)
        {
            ViewBag.UF = uf;
            return PartialView("_Municipios");
        }

        public UsuarioClienteModel CarregaDadosUsuarioCliente()
        {
            if (Session["user"] != null)
            {
                var usuarioCliente = new UsuarioClienteModel()
                {
                    Id = ((UsuarioCliente)Session["user"]).Id,
                    Nome = ((UsuarioCliente)Session["user"]).Nome,
                    Email = ((UsuarioCliente)Session["user"]).Email,
                    Login = ((UsuarioCliente)Session["user"]).Login
                };

                return usuarioCliente;
            }
            else
            {
                return new UsuarioClienteModel();
            }
        }

        #region Pessoa Fisica
        
        public ActionResult PesquisaPessoaFisica()
        {
            var model = new AreaRestritaModel()
            {
                UsuarioCliente = CarregaDadosUsuarioCliente()
            };

            return View(model);
        }

        public ActionResult PesquisarPessoaFisicaPorCPF(string txtCpfPesquisaPorCpf)
        {
            TransacaoConsulta transacao = new TransacaoConsulta();

            InfoPessoaFisica pessoaFisica = facadePF.ConsultarPessoaFisicaPorCPF(
                txtCpfPesquisaPorCpf,
                _idClienteEmpresa,
                _idContratoEmpresa,
                _idUsuarioCliente,
                out transacao);

            if (pessoaFisica != null)
            {
                PreencherDadosTransacao(transacao);
                return PartialView("_ResultadoPesquisaPessoaFisica", pessoaFisica);
            }
            else
            {
                return PartialView("_ResultadoNaoEncontrado");
            }
        }

        public ActionResult PesquisarPessoaFisicaPorCEP(string txtCepPesquisaPorEndereco)
        {
            TransacaoConsulta transacao = new TransacaoConsulta();

            List<InfoPessoaFisica> pessoasFisica = facadePF.ConsultarPessoaFisicaPorCEP(
                txtCepPesquisaPorEndereco,
                _idClienteEmpresa,
                _idContratoEmpresa,
                _idUsuarioCliente,
                out transacao);

            if (pessoasFisica.Count > 0)
            {
                PreencherDadosTransacao(transacao);
                return PartialView("_ResultadoPesquisaPessoaFisicaLista", pessoasFisica);
            }
            else
            {
                return PartialView("_ResultadoNaoEncontrado");
            }
        }

        public ActionResult PesquisarPessoaFisicaPorEndereco(
            string ddlUfPesquisaPorEndereco,
            string ddlMunicipioPesquisaPorEndereco,
            string txtBairroPesquisaPorEndereco,
            string txtLogradouroPesquisaPorEndereco,
            string txtNumeroPesquisaPorEndereco,
            string txtComplementoPesquisaPorEndereco)
        {
            TransacaoConsulta transacao = new TransacaoConsulta();

            List<InfoPessoaFisica> pessoasFisica = facadePF.ConsultarPessoaFisicaPorEndereco(
                ddlUfPesquisaPorEndereco,
                ddlMunicipioPesquisaPorEndereco,
                txtBairroPesquisaPorEndereco,
                txtLogradouroPesquisaPorEndereco,
                txtNumeroPesquisaPorEndereco,
                txtComplementoPesquisaPorEndereco,
                _idClienteEmpresa,
                _idContratoEmpresa,
                _idUsuarioCliente,
                out transacao);

            if (pessoasFisica.Count > 0)
            {
                PreencherDadosTransacao(transacao);
                return PartialView("_ResultadoPesquisaPessoaFisicaLista", pessoasFisica);
            }
            else
            {
                return PartialView("_ResultadoNaoEncontrado");
            }
        }

        public ActionResult PesquisarPessoaFisicaPorNome(string txtNomePesquisaPorNome)
        {
            TransacaoConsulta transacao = new TransacaoConsulta();

            List<InfoPessoaFisica> pessoasFisica = facadePF.ConsultarPessoaFisicaPorNome(
                txtNomePesquisaPorNome,
                _idClienteEmpresa,
                _idContratoEmpresa,
                _idUsuarioCliente,
                out transacao);

            if (pessoasFisica.Count > 0)
            {
                PreencherDadosTransacao(transacao);
                return PartialView("_ResultadoPesquisaPessoaFisicaLista", pessoasFisica);
            }
            else
            {
                return PartialView("_ResultadoNaoEncontrado");
            }
        }

        public ActionResult PesquisarPessoaFisicaPorTelefone(byte? txtDddPesquisaPorTelefone, string txtTelefonePesquisaPorTelefone)
        {
            TransacaoConsulta transacao = new TransacaoConsulta();

            List<InfoPessoaFisica> pessoasFisica = facadePF.ConsultarPessoaFisicaPorTelefone(
                txtDddPesquisaPorTelefone,
                txtTelefonePesquisaPorTelefone,
                _idClienteEmpresa,
                _idContratoEmpresa,
                _idUsuarioCliente,
                out transacao);

            if (pessoasFisica.Count > 0)
            {
                PreencherDadosTransacao(transacao);
                return PartialView("_ResultadoPesquisaPessoaFisicaLista", pessoasFisica);
            }
            else
            {
                return PartialView("_ResultadoNaoEncontrado");
            }
        }

        #endregion

        #region Pessoa Juridica
        
        public ActionResult PesquisaPessoaJuridica()
        {
            var model = new AreaRestritaModel()
            {
                UsuarioCliente = CarregaDadosUsuarioCliente()
            };

            return View(model);
        }

        public ActionResult PesquisarPessoaJuridicaPorCNPJ(string txtCnpjPesquisaPorCnpj)
        {
            TransacaoConsulta transacao = new TransacaoConsulta();

            InfoPessoaJuridica pessoaJuridica = facadePJ.ConsultarPessoaJuridicaPorCNPJ(
                txtCnpjPesquisaPorCnpj,
                _idClienteEmpresa,
                _idContratoEmpresa,
                _idUsuarioCliente,
                out transacao);

            if (pessoaJuridica != null)
            {
                PreencherDadosTransacao(transacao);
                return PartialView("_ResultadoPesquisaPessoaJuridica", pessoaJuridica);
            }
            else
            {
                return PartialView("_ResultadoNaoEncontrado");
            }
        }

        public ActionResult PesquisarPessoaJuridicaPorCEP(string txtCepPesquisaPorEndereco)
        {
            TransacaoConsulta transacao = new TransacaoConsulta();

            List<InfoPessoaJuridica> pessoasJuridica = facadePJ.ConsultarPessoaJuridicaPorCEP(
                txtCepPesquisaPorEndereco,
                _idClienteEmpresa,
                _idContratoEmpresa,
                _idUsuarioCliente,
                out transacao);

            if (pessoasJuridica.Count > 0)
            {
                PreencherDadosTransacao(transacao);
                return PartialView("_ResultadoPesquisaPessoaJuridicaLista", pessoasJuridica);
            }
            else
            {
                return PartialView("_ResultadoNaoEncontrado");
            }
        }

        public ActionResult PesquisarPessoaJuridicaPorEndereco(
            string ddlUfPesquisaPorEndereco,
            string ddlMunicipioPesquisaPorEndereco,
            string txtBairroPesquisaPorEndereco,
            string txtLogradouroPesquisaPorEndereco,
            string txtNumeroPesquisaPorEndereco,
            string txtComplementoPesquisaPorEndereco)
        {
            TransacaoConsulta transacao = new TransacaoConsulta();

            List<InfoPessoaJuridica> pessoasJuridica = facadePJ.ConsultarPessoaJuridicaPorEndereco(
                ddlUfPesquisaPorEndereco,
                ddlMunicipioPesquisaPorEndereco,
                txtBairroPesquisaPorEndereco,
                txtLogradouroPesquisaPorEndereco,
                txtNumeroPesquisaPorEndereco,
                txtComplementoPesquisaPorEndereco,
                _idClienteEmpresa,
                _idContratoEmpresa,
                _idUsuarioCliente,
                out transacao);

            if (pessoasJuridica.Count > 0)
            {
                PreencherDadosTransacao(transacao);
                return PartialView("_ResultadoPesquisaPessoaJuridicaLista", pessoasJuridica);
            }
            else
            {
                return PartialView("_ResultadoNaoEncontrado");
            }
        }

        public ActionResult PesquisarPessoaJuridicaPorNome(string txtNomePesquisaPorNome)
        {
            TransacaoConsulta transacao = new TransacaoConsulta();

            List<InfoPessoaJuridica> pessoasJuridica = facadePJ.ConsultarPessoaJuridicaPorNome(
                txtNomePesquisaPorNome,
                _idClienteEmpresa,
                _idContratoEmpresa,
                _idUsuarioCliente,
                out transacao);

            if (pessoasJuridica.Count > 0)
            {
                PreencherDadosTransacao(transacao);
                return PartialView("_ResultadoPesquisaPessoaJuridicaLista", pessoasJuridica);
            }
            else
            {
                return PartialView("_ResultadoNaoEncontrado");
            }
        }

        public ActionResult PesquisarPessoaJuridicaPorTelefone(
            byte? txtDddPesquisaPorTelefone,
            string txtTelefonePesquisaPorTelefone)
        {
            TransacaoConsulta transacao = new TransacaoConsulta();

            List<InfoPessoaJuridica> pessoasJuridica = facadePJ.ConsultarPessoaJuridicaPorTelefone(
                txtDddPesquisaPorTelefone,
                txtTelefonePesquisaPorTelefone,
                _idClienteEmpresa,
                _idContratoEmpresa,
                _idUsuarioCliente,
                out transacao);

            if (pessoasJuridica.Count > 0)
            {
                PreencherDadosTransacao(transacao);
                return PartialView("_ResultadoPesquisaPessoaJuridicaLista", pessoasJuridica);
            }
            else
            {
                return PartialView("_ResultadoNaoEncontrado");
            }
        }

        #endregion

        #region FTP

        public ActionResult PesquisaFtp()
        {
            ControleArquivoModel model = new ControleArquivoModel
            {
                UsuarioCliente = CarregaDadosUsuarioCliente()
            };

            var caminho = ConfigurationManager.AppSettings["FtpUrl"];
            var uri = new Uri(caminho);
            var ftp = (FtpWebRequest)WebRequest.Create(uri);
            ftp.Method = System.Net.WebRequestMethods.Ftp.ListDirectory;

            ftp.Credentials = CreateCredential();

            FtpWebResponse response = (FtpWebResponse)ftp.GetResponse();

            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);

            List<string> listaArquivoEntradaFtp = new List<string>();

            string[] lines = reader.ReadToEnd().Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string item in lines)
            {
                listaArquivoEntradaFtp.Add(item);
            }

            ViewBag.ListaArquivoEntradaFtp = listaArquivoEntradaFtp;


            caminho = ConfigurationManager.AppSettings["FtpSaida"];
            uri = new Uri(caminho);
            ftp = (FtpWebRequest)WebRequest.Create(uri);
            ftp.Method = System.Net.WebRequestMethods.Ftp.ListDirectory;

            ftp.Credentials = CreateCredential();

            response = (FtpWebResponse)ftp.GetResponse();

            responseStream = response.GetResponseStream();
            reader = new StreamReader(responseStream);

            List<string> listaArquivoSaidaFtp = new List<string>();

            lines = reader.ReadToEnd().Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string item in lines)
            {
                listaArquivoSaidaFtp.Add(item);
            }

            ViewBag.ListaArquivoSaidaFtp = listaArquivoSaidaFtp;


            return View(model);
        }

        [HttpPost]
        public ActionResult PesquisaFtp(HttpPostedFileBase file)
        {
            ControleArquivoModel model = new ControleArquivoModel
            {
                UsuarioCliente = CarregaDadosUsuarioCliente()
            };

            model.NomeArquivoEntrada = file.FileName;
            model.Arquivo = file;

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            bool encontrou = false;
            string[] extensoes = file.FileName.Split('.');

            string[] extensoesPermitidas = new string[] { "TXT", "CSV", "XLS", "XLSX" };  //txt , csv, xls, xlsx


            for (int i = 0; i < extensoesPermitidas.Length; i++)
            {
                if (extensoesPermitidas[i] == extensoes[(extensoes.Length - 1)].ToUpper())
                {

                    encontrou = true;
                }
            }

            try
            {

                if (encontrou)
                {
                    if (file != null && file.ContentLength > 0)
                    {
                        // extract only the filename
                        var fileName = Path.GetFileName(file.FileName);
                        // store the file inside ~/App_Data/uploads folder
                        var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);

                    }

                    var request = CreateFtpRequest(file.FileName);

                    using (var arquivo = request.GetRequestStream())
                        file.InputStream.CopyTo(arquivo);

                    var result = (FtpWebResponse)request.GetResponse();

                    if (result.StatusCode == FtpStatusCode.CommandOK || result.StatusCode == FtpStatusCode.ClosingData || result.StatusCode == FtpStatusCode.FileActionOK)
                    {
                        PesquisaFtp();


                        TempData["msg"] = "<script>alert('Enviado com Sucesso!');</script>";

                        //return View(ViewBag.ListaArquivoEntradaFtp);
                        return View(model);
                    }
                    else
                    {

                        return RedirectToAction("ListarFtpEntrada");
                    }

                }
                else
                {

                    PesquisaFtp();

                    TempData["msg"] = "<script>alert('Arquivo não permitido');</script>";

                    return View();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static FtpWebRequest CreateFtpRequest(string fileName)
        {
            var caminho = ConfigurationManager.AppSettings["FtpUrl"];
            var uri = new Uri(string.Format(@"{0}{1}", caminho, fileName));
            var ftp = (FtpWebRequest)WebRequest.Create(uri);
            ftp.Method = System.Net.WebRequestMethods.Ftp.UploadFile;

            ftp.Credentials = CreateCredential();
            return ftp;
        }

        private static NetworkCredential CreateCredential()
        {
            var username = ConfigurationManager.AppSettings["FtpUsername"];
            var password = ConfigurationManager.AppSettings["FtpPassword"];
            return new NetworkCredential(username, password);
        }

        #endregion

    }
}
