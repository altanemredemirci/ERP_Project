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
using ERP.WEBUI.Filters;

namespace ERP.WEBUI.Controllers
{
    [Auth]
    public class ProductController : Controller
    {
        private ProductManager productManager = new ProductManager();
        private CategoryManager categoryManager = new CategoryManager();
        // GET: Product
        public ActionResult Index()
        {
            var products = productManager.GetAll();
            return View(products);
        }

        // GET: Product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = productManager.GetById(id.Value);
            product.Category = categoryManager.Find(i => i.Id == product.CategoryId);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(categoryManager.GetAll(), "Id", "Name");
            return View();
        }

        // POST: Product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            ModelState.Remove("ModifiedUsername");
            if (ModelState.IsValid)
            {
                productManager.Insert(product);
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(categoryManager.GetAll(), "Id", "Name", product.CategoryId);
            return View(product);
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = productManager.Find(i=> i.Id==id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(categoryManager.GetAll(), "Id", "Name", product.CategoryId);
            return View(product);
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            ModelState.Remove("ModifiedUsername");
            if (ModelState.IsValid)
            {
                Product model = productManager.GetById(product.Id);

                model.Color = product.Color;
                model.Model = product.Model;
                model.Price = product.Price;
                model.Brand = product.Brand;
                model.Stock = product.Stock;
                model.CategoryId = product.CategoryId;

                productManager.Update(model);
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(categoryManager.GetAll(), "Id", "Name", product.CategoryId);
            return View(product);
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product =productManager.Find(i=> i.Id==id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = productManager.Find(i => i.Id == id);
            productManager.Delete(product);
            return RedirectToAction("Index");
        }

    }
}
