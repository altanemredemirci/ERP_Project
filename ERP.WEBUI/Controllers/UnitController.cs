using ERP.BusinessLogicLayer;
using ERP.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Unit = ERP.Entity.Unit;

namespace ERP.WEBUI.Controllers
{
    public class UnitController : Controller
    {
        private UnitManager unitManager = new UnitManager();
        // GET: Unit
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Create()
        {
            return View(new Unit());
        }
        public ActionResult Create(Unit model)
        {
            if (ModelState.IsValid)
            {
                unitManager.AddUnit(model);
            }
            
            return View(model);
        }

    }
}