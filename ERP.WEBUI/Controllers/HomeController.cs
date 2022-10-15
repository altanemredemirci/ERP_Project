using ERP.BusinessLogicLayer;
using ERP.Entity;
using ERP.Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.WEBUI.Controllers
{
    public class HomeController : Controller
    {       
        CustomerManager customerManager = new CustomerManager();
        PersonManager personManager = new PersonManager();
      
        public ActionResult Register()
        {
            return View(new RegisterModel());
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                int sonuc = customerManager.RegisterCustomer(model);
                if (sonuc == -1)
                {
                    ModelState.AddModelError("", "Email adresi veya Telefon Numarası başka müşteri tarafından kayıtlıdır..");
                    return View(model);
                }

                else if (sonuc == 1)
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    return View(model);
                }
            }
            return View(model);
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

                if (model.IsPerson)
                {
                    Person person = personManager.LoginPerson(model);
                    if (person == null)
                    {
                        ModelState.AddModelError("", "Giriş Bilgisi Hatalı!!");
                        return View(model);
                    }
                    Session["login"] = person;
                    return RedirectToAction("Index", "Unit");
                }

                Customer customer = customerManager.LoginCustomer(model);
                if(customer==null)
                {
                    ModelState.AddModelError("", "Giriş Bilgisi Hatalı veya Kayıtlı Olmayan Giriş");
                    return View(model);
                }
                Session["login"]=customer;
                return RedirectToAction("Index","Order");
            }
            return View(model);
        }
    }
}