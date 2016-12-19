using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DNAMais.BackOffice.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated == false)
            {
                FormsAuthentication.RedirectToLoginPage();
            }
            return View();
        }

    }
}
