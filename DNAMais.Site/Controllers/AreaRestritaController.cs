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
        AutenticacaoFacade facadeAutenticacao;
        
        PessoaFisicaFacade facadePF;
        PessoaJuridicaFacade facadePJ;

        private readonly int _idClienteEmpresa;
        private readonly int _idContratoEmpresa;
        private readonly int _idUsuarioCliente;

        public AreaRestritaController()
        {
            facadePF = new PessoaFisicaFacade(ModelState);
            facadePJ = new PessoaJuridicaFacade(ModelState);
            facadeAutenticacao = new AutenticacaoFacade(ModelState); 

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
            var usuarioCliente = CarregaDadosUsuarioCliente();

            AreaRestritaModel model = new AreaRestritaModel
            {
                UsuarioCliente = usuarioCliente
            };

            return View(model);
        }

        public ActionResult PesquisaVeiculo()
        {
            var usuarioCliente = CarregaDadosUsuarioCliente();

            AreaRestritaModel model = new AreaRestritaModel
            {
                UsuarioCliente = usuarioCliente
            };

            return View(model);
        }

        public ActionResult ListarMunicipios(string uf)
        {
            ViewBag.UF = uf;
            return PartialView("_Municipios");
        }

        public UsuarioCliente CarregaDadosUsuarioCliente()
        {
            if (Session["user"] != null)
            {
                var usuarioCliente = facadeAutenticacao.ConsultarPorId((int)((UsuarioCliente)Session["user"]).Id);

                return usuarioCliente;
            }
            else
            {
                return new UsuarioCliente();
            }
        }

        #region Pessoa Fisica
        
        public ActionResult PesquisaPessoaFisica()
        {
            var usuarioCliente = CarregaDadosUsuarioCliente();

            AreaRestritaModel model = new AreaRestritaModel()
            {
                UsuarioCliente = usuarioCliente
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

        public ActionResult PesquisarPessoaFisicaPorCPFModal(string txtCpfPesquisaPorCpf)
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
                return PartialView("_ResultadoPesquisaPessoaFisicaModal", pessoaFisica);
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

        public ActionResult PesquisarPessoaFisicaPorCepNumero(string txtCepPesquisaPorCepNumero, string txtNumeroPesquisaPorCepNumero)
        {
            TransacaoConsulta transacao = new TransacaoConsulta();

            List<InfoPessoaFisica> pessoasFisica = facadePF.ConsultarPessoaFisicaPorCepNumero(
                txtCepPesquisaPorCepNumero,
                txtNumeroPesquisaPorCepNumero,
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
            var usuarioCliente = CarregaDadosUsuarioCliente();

            AreaRestritaModel model = new AreaRestritaModel
            {
                UsuarioCliente = usuarioCliente
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

        public ActionResult PesquisarPessoaJuridicaPorCNPJModal(string txtCnpjPesquisaPorCnpj)
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
                return PartialView("_ResultadoPesquisaPessoaJuridicaModal", pessoaJuridica);
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
            var usuarioCliente = CarregaDadosUsuarioCliente();

            ControleArquivoModel model = new ControleArquivoModel
            {
                UsuarioCliente = usuarioCliente
            };

            if (usuarioCliente.Id != null)
            {
                var existePastaFtp = CreateFTPDirectory(ConfigurationManager.AppSettings["FtpUrl"] +
                                                        usuarioCliente.ClienteEmpresa.NomePastaFtp);

                if (existePastaFtp)
                {
                    #region FTP Entrada

                    var caminhoEntrada = ConfigurationManager.AppSettings["FtpUrl"] +
                                         usuarioCliente.ClienteEmpresa.NomePastaFtp + "/" +
                                         ConfigurationManager.AppSettings["FtpEntrada"] + "/";

                    var existePastaEntrada = CreateFTPDirectory(caminhoEntrada);

                    if (existePastaEntrada)
                    {
                        var uri = new Uri(caminhoEntrada);
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
                    }

                    #endregion

                    #region FTP Saida

                    var caminhoSaida = ConfigurationManager.AppSettings["FtpUrl"] +
                                       usuarioCliente.ClienteEmpresa.NomePastaFtp + "/" +
                                       ConfigurationManager.AppSettings["FtpSaida"] + "/";

                    var existePastaSaida = CreateFTPDirectory(caminhoSaida);

                    if (existePastaSaida)
                    {
                        var uri = new Uri(caminhoSaida);
                        var ftp = (FtpWebRequest)WebRequest.Create(uri);
                        ftp.Method = System.Net.WebRequestMethods.Ftp.ListDirectory;

                        ftp.Credentials = CreateCredential();

                        var response = (FtpWebResponse)ftp.GetResponse();

                        var responseStream = response.GetResponseStream();
                        var reader = new StreamReader(responseStream);

                        List<string> listaArquivoSaidaFtp = new List<string>();

                        var lines = reader.ReadToEnd().Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                        foreach (string item in lines)
                        {
                            listaArquivoSaidaFtp.Add(item);
                        }

                        ViewBag.ListaArquivoSaidaFtp = listaArquivoSaidaFtp;
                    }

                    #endregion
                }
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult PesquisaFtp(HttpPostedFileBase file)
        {
            var usuarioCliente = CarregaDadosUsuarioCliente();

            ControleArquivoModel model = new ControleArquivoModel
            {
                UsuarioCliente = usuarioCliente
            };

            var caminhoEntrada = ConfigurationManager.AppSettings["FtpUrl"] +
                                 usuarioCliente.ClienteEmpresa.NomePastaFtp + "/" +
                                 ConfigurationManager.AppSettings["FtpEntrada"] + "/";

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

                        var request = CreateFtpRequest(caminhoEntrada + file.FileName);

                        using (var arquivo = request.GetRequestStream())
                            file.InputStream.CopyTo(arquivo);

                        var result = (FtpWebResponse)request.GetResponse();

                        if (result.StatusCode == FtpStatusCode.CommandOK || result.StatusCode == FtpStatusCode.ClosingData || result.StatusCode == FtpStatusCode.FileActionOK)
                        {
                            PesquisaFtp();
                            TempData["msg"] = "<script>toastr['success']('Arquivo enviado com sucesso');</script>";

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

                        TempData["msg"] = "<script>toastr['error']('Arquivo não localizado');</script>";

                        return View();
                    }
                }
                else
                {
                    PesquisaFtp();

                    TempData["msg"] = "<script>toastr['error']('Arquivo não permitido');</script>";

                    return View();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult DownloadFtpSaida(string nomeArquivoDownload)
        {
            var usuarioCliente = CarregaDadosUsuarioCliente();

            ControleArquivoModel model = new ControleArquivoModel
            {
                UsuarioCliente = usuarioCliente
            };

            var caminhoSaida = ConfigurationManager.AppSettings["FtpUrl"] +
                                 usuarioCliente.ClienteEmpresa.NomePastaFtp + "/" +
                                 ConfigurationManager.AppSettings["FtpSaida"] + "/" + nomeArquivoDownload;
            try
            {
                FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(new Uri(caminhoSaida));
                request.Method = WebRequestMethods.Ftp.DownloadFile;

                request.Credentials = CreateCredential();
                request.UsePassive = true;
                request.UseBinary = true;
                request.EnableSsl = false;

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                using (MemoryStream stream = new MemoryStream())
                {
                    response.GetResponseStream().CopyTo(stream);
                    Response.AddHeader("content-disposition", "attachment;filename=" + nomeArquivoDownload);
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.BinaryWrite(stream.ToArray());
                    Response.End();
                }
            }
            catch (WebException ex)
            {
                throw new Exception((ex.Response as FtpWebResponse).StatusDescription);
            }

            return RedirectToAction("PesquisaFtp");
        }

        private static FtpWebRequest CreateFtpRequest(string PathAndFileName)
        {
            var uri = new Uri(PathAndFileName);
            var ftp = (FtpWebRequest)WebRequest.Create(uri);
            ftp.Method = WebRequestMethods.Ftp.UploadFile;

            ftp.Credentials = CreateCredential();
            return ftp;
        }

        private static NetworkCredential CreateCredential()
        {
            var username = ConfigurationManager.AppSettings["FtpUsername"];
            var password = ConfigurationManager.AppSettings["FtpPassword"];
            return new NetworkCredential(username, password);
        }

        private bool CreateFTPDirectory(string directory)
        {

            try
            {
                if (directory == null)
                    return false;

                if (directory.Trim() == string.Empty)
                    return false;

                //create the directory
                FtpWebRequest requestDir = (FtpWebRequest)FtpWebRequest.Create(new Uri(directory));
                requestDir.Method = WebRequestMethods.Ftp.MakeDirectory;
                requestDir.Credentials = CreateCredential();
                requestDir.UsePassive = true;
                requestDir.UseBinary = true;
                requestDir.KeepAlive = false;
                FtpWebResponse response = (FtpWebResponse)requestDir.GetResponse();
                Stream ftpStream = response.GetResponseStream();

                ftpStream.Close();
                response.Close();

                return true;
            }
            catch (WebException ex)
            {
                FtpWebResponse response = (FtpWebResponse)ex.Response;
                if (response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable)
                {
                    response.Close();
                    return true;
                }
                else
                {
                    response.Close();
                    return false;
                }
            }
        }

        #endregion

    }
}
