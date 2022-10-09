using ERP.DataAccessLayer;
using ERP.DataAccessLayer.EF;
using ERP.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ERP.BusinessLogicLayer
{
    public class ProductManager
    {
        private Repository<Product> repo_product = new Repository<Product>();

        public List<Product> GetAll()
        {
            using (var context = new DatabaseContext())
            {
                var products = context.Products.Include("Category").ToList();

                return products;
            }
        }

        public int Insert(Product p)
        {
            return repo_product.Insert(p);
        }

        public int Delete(Product p)
        {
            return repo_product.Delete(p);
        }

        public Product GetById(int id)
        {
            return repo_product.Find(i => i.Id == id);
        }

        public Product Find(Expression<Func<Product, bool>> where)
        {
            return repo_product.Find(where);
        }

        public int Update(Product product)
        {
            using (var context = new DatabaseContext())
            {
                context.Entry(product).State = EntityState.Modified;

                return repo_product.Update(product);
            }            
        }
    }
}
