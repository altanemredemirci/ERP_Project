using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ERP.BusinessLogicLayer;
using ERP.Entity;

namespace ERP.WEBUI.Controllers
{
    public class CategoryController : Controller
    {
        private CategoryManager categoryManager = new CategoryManager();

        // GET: Category
        public ActionResult Index()
        {
            return View(categoryManager.GetAll());
        }

        // GET: Category/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = categoryManager.Find(i=> i.Id==id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }


        public ActionResult Create()
        {
            return View(new Category());
        }

  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            ModelState.Remove("ModifiedUsername");
            if (ModelState.IsValid)
            {
                categoryManager.Insert(category);
                return RedirectToAction("Index");
            }

            return View(category);
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = categoryManager.Find(cat => cat.Id==id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }
               
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category cat)
        {
            ModelState.Remove("ModifiedUsername");
            if (ModelState.IsValid)
            {
                Category category = categoryManager.Find(i => i.Id == cat.Id);

                if (category == null)
                    return HttpNotFound();

                category.Products = cat.Products;
                category.Name = cat.Name;
                category.Description = cat.Description;

                categoryManager.Update(category);

                return RedirectToAction("Index","Category");
            }

            return View(cat);
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = categoryManager.Find(i=> i.Id==id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = categoryManager.Find(i => i.Id == id);
            categoryManager.Delete(category);
            return RedirectToAction("Index");
        }

    }
}
