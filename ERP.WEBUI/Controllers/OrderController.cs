using ERP.BusinessLogicLayer;
using ERP.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.WEBUI.Controllers
{
    public class OrderController : Controller
    {
        private ProductManager productManager = new ProductManager();
        private OrderManager orderManager = new OrderManager();
        // GET: Order
        public ActionResult AddOrder()
        {
            ViewBag.ProductId = new SelectList(productManager.GetAll(), "Id", "Brand");
            ViewBag.ModelId = new SelectList(productManager.GetAll(), "Id", "Model");

            List<SelectListItem> Colors = new List<SelectListItem>()
            {
          new SelectListItem {Text="Red",Value="Red",Selected=true },
          new SelectListItem {Text="Blue",Value="Blue" },
          new SelectListItem {Text="Black",Value="Black"}
            };
            ViewBag.Color = Colors;

            return View(new OrderDetail());
        }

        [HttpPost]
        public ActionResult AddOrder(OrderDetail model)
        {
            Order order = new Order();
            order.Customer = Session["customer"] as Customer;
            order.OrderDetails.Add(new OrderDetail()
            {
                Product=productManager.GetById(model.ProductId),
                Quantity=model.Quantity,
                UnitPrice= productManager.GetById(model.ProductId).Price,
                Color=model.Color,
                Total=model.Quantity* productManager.GetById(model.ProductId).Price,
            });
            order.OrderDate = DateTime.Now;

            if (orderManager.AddOrder(order) > 0)
            {
                return View("AddOrder", "Order");
            }

            return View(model);
        }

    }
}