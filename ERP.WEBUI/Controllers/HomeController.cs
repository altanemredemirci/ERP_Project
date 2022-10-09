using ERP.BusinessLogicLayer;
using ERP.Entity;
using ERP.WEBUI.Models;
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

        public ActionResult Register()
        {
            return View(new RegisterModel());
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {

            }
            return View();
        }

        public ActionResult Login()
        {
            return View(new LoginModel());
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {

            }
            return View();
        }
    }
}