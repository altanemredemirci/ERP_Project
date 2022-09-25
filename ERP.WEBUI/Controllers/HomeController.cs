using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.WEBUI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ERP.BusinessLogicLayer.Test test = new BusinessLogicLayer.Test();
            return View();
        }
    }
}