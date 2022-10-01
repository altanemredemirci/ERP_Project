using ERP.DataAccessLayer.EF;
using ERP.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.BusinessLogicLayer
{
    public class Test
    {
        private Repository<Category> repo_category = new Repository<Category>();
        private Repository<Person> repo_person = new Repository<Person>();
        private Repository<Product> repo_product = new Repository<Product>();
        public Test()
        {      
            //Category c = new Category();
            //c.Name = "Telefon";
            //c.Description = "Telefon Hoştur";
            //c.CreateOn = DateTime.Now;
            //c.ModifiedOn = DateTime.Now;
            //c.ModifiedUsername = "mahmut";
            //repo.Insert(c);

            //Category c = repo.Find(i => i.Id == 4);
            //repo.Delete(c);
        }

        public void UpdateTest()
        {
            Person p = repo_person.Find(x => x.Name == "Altan Emre");

            if (p != null)
            {
                p.Name = "Altan";
                repo_person.Update(p);
            }
        }

        public void InsertTest()
        {
            Category c = repo_category.Find(i => i.Id == 1);

            Product p = new Product()
            {
                Brand = "Asus",
                Model = "KV5342s",
                Color = "Platin",
                Price = 15000,
                Stock = 50,
                Category = c,
                CreateOn = DateTime.Now,
                ModifiedOn = DateTime.Now,
                ModifiedUsername = "system"
            };

            repo_product.Insert(p);
        }
    }
}
