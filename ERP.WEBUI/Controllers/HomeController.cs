using ERP.BusinessLogicLayer;
using ERP.Entity;
using ERP.Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
                    Customer customer = customerManager.GetByEmail(model.Email);

                    string siteUrl = "https://localhost:44345/";
                    string activeUrl = $"{siteUrl}Home/UserActivate?email={customer.Email}";
                    string body = $"Merhaba {customer.Name} {customer.Surname};<br><br>Hesabınızı aktifleştirmek için <a href='{activeUrl}' target='_blank'> tıklayınız.</a>.";


                    var message = new MailMessage();

                    message.From = new MailAddress("test_altan_emre_1989@hotmail.com");

                    message.To.Add(new MailAddress(customer.Email));

                    message.Subject = "Üyelik Onayı";
                    message.Body = body;
                    message.IsBodyHtml = true;

                    using(var smtp = new SmtpClient("smtp-mail.outlook.com", 587))
                    {
                        smtp.EnableSsl = true;
                        smtp.Credentials = new NetworkCredential("test_altan_emre_1989@hotmail.com", "UBY12345");

                        smtp.Send(message);
                            
                    }

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
        [ValidateAntiForgeryToken]
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
                    Session["person"] = person;
                    return RedirectToAction("Index", "Unit");
                }

                Customer customer = customerManager.LoginCustomer(model);
                if(customer==null)
                {
                    ModelState.AddModelError("", "Giriş Bilgisi Hatalı veya Kayıtlı Olmayan Giriş");
                    return View(model);
                }
                Session["customer"]=customer;
                return RedirectToAction("AddOrder","Order");
            }
            return View(model);
        }

        public ActionResult UserActivate(string email)
        {
            if (customerManager.UserActivate(email) > 0)
            {
                return RedirectToAction("Login");
            }
            return RedirectToAction("Register");
        }
    }
}