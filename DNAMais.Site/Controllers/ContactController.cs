using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DNAMais.Site.Controllers
{
    public class ContactController : Controller
    {
        //
        // GET: /Contact/

        public ActionResult Location()
        {
            return View();
        }

        public ActionResult Propose()
        {
            return View();
        }
    }
}