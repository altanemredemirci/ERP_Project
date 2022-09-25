using ERP.Entity;
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
            BusinessLogicLayer.Test test = new BusinessLogicLayer.Test();

            //test.UpdateTest();
            test.InsertTest();
            return View();
        }
    }
}