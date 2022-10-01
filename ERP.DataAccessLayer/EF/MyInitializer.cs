using ERP.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.DataAccessLayer
{
    public class MyInitializer:CreateDatabaseIfNotExists<DatabaseContext>
    {        
        protected override void Seed(DatabaseContext context)       
        {
            // Adding Categories..
            context.Categories.AddRange(Categories);

            // Adding Products
            context.Products.AddRange(Products);

            context.SaveChanges();

            // Adding Units..
            Unit unit = new Unit()
            {
                Name = "Üretim",
                CreateOn = DateTime.Now,
                ModifiedOn = DateTime.Now,
                ModifiedUsername = "system"
            };
            

            Person p = new Person()
            {
                Name = "Caner",
                Surname = "Uçar",
                Email = "canerucar@erp.com",
                Password = "ucar",
                IsAdmin = false,
                CreateOn = DateTime.Now,
                ModifiedOn = DateTime.Now,
                ModifiedUsername = "system"
            };
            unit.Persons.Add(p);

            Person p2 = new Person()
            {
                Name = "Vusal",
                Surname = "Kurbanov",
                Email = "vusalkurbanov@erp.com",
                Password = "kurbanov",
                IsAdmin = false,
                CreateOn = DateTime.Now,
                ModifiedOn = DateTime.Now,
                ModifiedUsername = "system"
            };
            unit.Persons.Add(p2);

            context.Units.Add(unit);


            Unit unit2 = new Unit()
            {
                Name = "Pazarlama",
                CreateOn = DateTime.Now,
                ModifiedOn = DateTime.Now,
                ModifiedUsername = "system"
            };


            Person p3 = new Person()
            {
                Name = "Enes",
                Surname = "Şimsek",
                Email = "enessimsek@erp.com",
                Password = "simsek",
                IsAdmin = false,
                CreateOn = DateTime.Now,
                ModifiedOn = DateTime.Now,
                ModifiedUsername = "system"
            };
            unit2.Persons.Add(p3);

            Person p4 = new Person()
            {
                Name = "Maksut",
                Surname = "Özdemir",
                Email = "maksutozdemir@erp.com",
                Password = "ozdemir",
                IsAdmin = false,
                CreateOn = DateTime.Now,
                ModifiedOn = DateTime.Now,
                ModifiedUsername = "system"
            };
            unit2.Persons.Add(p4);

            context.Units.Add(unit2);


            Unit unit3 = new Unit()
            {
                Name = "Insan Kaynaklari",
                CreateOn = DateTime.Now,
                ModifiedOn = DateTime.Now,
                ModifiedUsername = "system"
            };


            Person p5 = new Person()
            {
                Name = "Altan Emre",
                Surname = "Demirci",
                Email = "altanemredemirci@erp.com",
                Password = "demirci",
                IsAdmin = false,
                CreateOn = DateTime.Now,
                ModifiedOn = DateTime.Now,
                ModifiedUsername = "system"
            };
            unit3.Persons.Add(p5);

            Person p6 = new Person()
            {
                Name = "Berat",
                Surname = "Begovic",
                Email = "beratbegovic@erp.com",
                Password = "begovic",
                IsAdmin = false,
                CreateOn = DateTime.Now,
                ModifiedOn = DateTime.Now,
                ModifiedUsername = "system"
            };
            unit3.Persons.Add(p6);

            context.Units.Add(unit3);

            context.SaveChanges();

            //base.Seed(context);
        }

        private List<Category> Categories = new List<Category>()
        {
            new Category(){Name="Laptop",Description="Dizüstü Bilgisayar",CreateOn=DateTime.Now,ModifiedOn=DateTime.Now,ModifiedUsername="system"},
            new Category(){Name="Masaüstü",Description="Masaüstü Bilgisayar",CreateOn=DateTime.Now,ModifiedOn=DateTime.Now,ModifiedUsername="system"},
            new Category(){Name="Tablet",Description="Tablet Bilgisayar",CreateOn=DateTime.Now,ModifiedOn=DateTime.Now,ModifiedUsername="system"}
        };

        private List<Product> Products = new List<Product>()
        {
            new Product(){Brand="Asus",Model="ROG Gamer",Color="Black",Price=20000,Stock=50,CategoryId=1,CreateOn=DateTime.Now,ModifiedOn=DateTime.Now,ModifiedUsername="system"},
            new Product(){Brand="Asus",Model="ROG Gamer2",Color="White",Price=25000,Stock=50,CategoryId=1,CreateOn=DateTime.Now,ModifiedOn=DateTime.Now,ModifiedUsername="system"},
            new Product(){Brand="Apple",Model="IOS2",Color="White",Price=30000,Stock=50,CategoryId=2,CreateOn=DateTime.Now,ModifiedOn=DateTime.Now,ModifiedUsername="system"},
            new Product(){Brand="Casper",Model="Excalubur",Color="Blue",Price=10000,Stock=50,CategoryId=2,CreateOn=DateTime.Now,ModifiedOn=DateTime.Now,ModifiedUsername="system"},
            new Product(){Brand="Lenovo",Model="M10",Color="Black",Price=5000,Stock=50,CategoryId=3,CreateOn=DateTime.Now,ModifiedOn=DateTime.Now,ModifiedUsername="system"}
        };
    }
}
