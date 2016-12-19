using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DNAMais.Site.Controllers
{
    public class BlogController : Controller
    {
        //
        // GET: /Blog/

        public ActionResult BlogList()
        {
            return View();
        }

        public ActionResult BlogPost()
        {
            return View();
        }
    }
}
