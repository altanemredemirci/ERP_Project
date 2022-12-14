using ERP.BusinessLogicLayer;
using ERP.Entity;
using ERP.WEBUI.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Unit = ERP.Entity.Unit;

namespace ERP.WEBUI.Controllers
{
    [Auth]
    public class UnitController : Controller
    {
        private UnitManager unitManager = new UnitManager();
        private PersonManager personManager = new PersonManager();
        // GET: Unit
        public ActionResult Index()
        {
            return View(unitManager.GetUnits());
        }
        public ActionResult Create()
        {
            return View(new Unit());
        }

        [HttpPost]
        public ActionResult Create(Unit model)
        {
            ModelState.Remove("ModifiedUsername");
            if (ModelState.IsValid)
            {
                if (unitManager.AddUnit(model) == 0)
                {
                    ModelState.AddModelError("", "Aynı isimde bir birim bulunmaktadır.");
                    return View(model);
                }

                return RedirectToAction("Index");
            }
            
            return View(model);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Unit unit = unitManager.GetUnitById(id.Value);
                   
            if (unit == null)
            {
                return HttpNotFound();
            }
            unit.Persons = personManager.GetPersonByUnit(unit.Id);
            return View(unit);
        }

        [HttpPost]
        public ActionResult Edit(Unit model)
        {
            ModelState.Remove("ModifiedUsername");
            if (ModelState.IsValid)
            {

                var unit = unitManager.GetUnitById(model.Id);
                if (unit != null)
                {
                    unit.Name = model.Name;

                    unitManager.UpdateUnit(unit);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(model);
                }
               
            }

            return View(model);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var unit = unitManager.GetUnitById(id.Value);

            if (unit != null)
            {
                unitManager.DeleteUnit(unit);

                return RedirectToAction("Index");
            }

            return View(unit);
        }
       
    }
}