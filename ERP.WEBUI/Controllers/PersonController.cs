using ERP.BusinessLogicLayer;
using ERP.Entity;
using ERP.WEBUI.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.WEBUI.Controllers
{
    [Auth]
    public class PersonController : Controller
    {
        private PersonManager personManager = new PersonManager();
        private UnitManager unitManager = new UnitManager();
        // GET: Person
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return View(personManager.GetAll());
            }

            return View(personManager.GetPersonByUnit(id.Value));
        }

        public ActionResult GetPersonByUnit(int? id)
        {           
                var model = personManager.GetPersonByUnit(id.Value);

                return PartialView("_PartialPersons", model);
                      
        }

        public ActionResult Create()
        {
            ViewBag.Units = new SelectList(unitManager.GetUnits(), "Id", "Name");
            return View(new Person());
        }

        [HttpPost]
        public ActionResult Create(Person p)
        {
            ModelState.Remove("ModifiedUsername");
            if (ModelState.IsValid)
            {
                if (personManager.AddPerson(p) == 0)
                {
                    ModelState.AddModelError("", "Email adresi başka bir personel tarafından kullanılıyor");
                    ViewBag.Units = new SelectList(unitManager.GetUnits(), "Id", "Name");
                    return View(p);
                }

                return RedirectToAction("Index");
            }
            ViewBag.Units = new SelectList(unitManager.GetUnits(), "Id", "Name");
            return View(p);
        }

        public ActionResult Edit(int id)
        {
            Person p = personManager.GetById(id);

            if (p == null)
            {
                return HttpNotFound();
            }

            ViewBag.Units = new SelectList(unitManager.GetUnits(), "Id", "Name");
            return View(p);
        }

        [HttpPost]
        public ActionResult Edit(Person p)
        {
            ModelState.Remove("ModifiedUsername");
            ModelState.Remove("Password");
            if (ModelState.IsValid)
            {
                var person = personManager.GetById(p.Id);

                if (person != null)
                {
                    person.Name = p.Name;
                    person.Surname = p.Surname;
                    person.Email = p.Email;
                    person.IsAdmin = p.IsAdmin;

                    personManager.UpdatePerson(person);
                }

                return RedirectToAction("Index");
            }
            ViewBag.Units = new SelectList(unitManager.GetUnits(), "Id", "Name");
            return View(p);
        }

        public ActionResult Delete(int id)
        {
            personManager.DeletePerson(id);
            return RedirectToAction("Index");
        }
    }
}