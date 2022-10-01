using ERP.BusinessLogicLayer;
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
        UnitManager unitManager = new UnitManager();
        // GET: Home
        public ActionResult Index()
        {
            return View(unitManager.GetUnits());
        }
    }
}