using DNAMais.BackOffice.Facades;
using DNAMais.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DNAMais.BackOffice.Areas.Cadastros.Controllers
{
    public class ClienteEmpresaController : Controller
    {
        private ClienteEmpresaFacade facade;

        public ClienteEmpresaController()
        {
            facade = new ClienteEmpresaFacade(ModelState);
        }

        protected override void Initialize(RequestContext context)
        {
            base.Initialize(context);

            ViewBag.Menu = "MENU-CLIENTE";
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (disposing && this.facade != null)
            {
                this.facade.Dispose();
            }
        }

        //[AutorizacaoDnaMais]
        public ActionResult Index()
        {
            return View(facade.ListarClientesEmpresa());
        }

        //[AutorizacaoDnaMais]
        public ActionResult Details(int id)
        {
            ViewData["LOCKED"] = true;
            return View("Cadastro", facade.ConsultarClienteEmpresaPorId(id));
        }

        //[AutorizacaoDnaMais]
        public ActionResult Create()
        {
            return View("Cadastro", new ClienteEmpresa());
        }

        [HttpPost]
        //[AutorizacaoDnaMais]
        public ActionResult Create(ClienteEmpresa clienteEmpresa)
        {
            facade.SalvarClienteEmpresa(clienteEmpresa);

            #region Cria Pasta FTP do Cliente

            if (CreateFTPDirectory(clienteEmpresa.NomePastaFtp))
            {
                var pastaEntrada = CreateFTPDirectory(clienteEmpresa.NomePastaFtp + "\\" + ConfigurationManager.AppSettings["FtpEntrada"]);
                var pastaSaida = CreateFTPDirectory(clienteEmpresa.NomePastaFtp + "\\" + ConfigurationManager.AppSettings["FtpSaida"]);
            }

            #endregion

            return View("Cadastro", clienteEmpresa);
        }

        //[AutorizacaoDnaMais]
        public ActionResult Edit(int id)
        {
            return View("Cadastro", facade.ConsultarClienteEmpresaPorId(id));
        }

        [HttpPost]
        //[AutorizacaoDnaMais]
        public ActionResult Edit(ClienteEmpresa clienteEmpresa)
        {
            facade.SalvarClienteEmpresa(clienteEmpresa);

            #region Cria Pasta FTP do Cliente

            if (CreateFTPDirectory(clienteEmpresa.NomePastaFtp))
            {
                var pastaEntrada = CreateFTPDirectory(clienteEmpresa.NomePastaFtp + "\\" + ConfigurationManager.AppSettings["FtpEntrada"]);
                var pastaSaida = CreateFTPDirectory(clienteEmpresa.NomePastaFtp + "\\" + ConfigurationManager.AppSettings["FtpSaida"]);
            }

            #endregion

            return View("Cadastro", clienteEmpresa);
        }

        //[AutorizacaoDnaMais]
        public ActionResult Remove(int id)
        {
            facade.RemoverClienteEmpresa(id);

            ViewData["Title"] = "DNA+ :: Clientes Empresa";
            ViewData["TituloPagina"] = "Clientes Empresa";
            ViewData["messageSuccess"] = "Cliente Empresa removido com sucesso";
            ViewData["messageReturn"] = "Voltar para lista de Clientes Empresa";

            return View("_Remove");
        }

        #region FTP

        private bool CreateFTPDirectory(string directory)
        {

            try
            {
                if (directory == null)
                    return false;

                if (directory.Trim() == string.Empty)
                    return false;

                var diretorio = ConfigurationManager.AppSettings["FtpUrl"] + directory;

                //create the directory
                FtpWebRequest requestDir = (FtpWebRequest)FtpWebRequest.Create(new Uri(diretorio));
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

        private static NetworkCredential CreateCredential()
        {
            var username = ConfigurationManager.AppSettings["FtpUsername"];
            var password = ConfigurationManager.AppSettings["FtpPassword"];
            return new NetworkCredential(username, password);
        }

        #endregion
    }
}
