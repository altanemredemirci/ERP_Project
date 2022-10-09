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
    public class CategoryManager
    {
        private Repository<Category> repo_category = new Repository<Category>();

        public List<Category> GetAll()
        {
            return repo_category.List();
        }
        public int Insert(Category entity)
        {
            return repo_category.Insert(entity);
        }

        public Category Find(Expression<Func<Category, bool>> where)
        {
            using(var context = new DatabaseContext())
            {
                var category = context.Categories.Include("Products").Where(where).FirstOrDefault();

                return category;
            }           
        }

        public int Update(Category model)
        {
            using (var context = new DatabaseContext())
            {
                context.Entry(model).State = EntityState.Modified;

                return context.SaveChanges();
            }
            //return repo_category.Update(model);
        }
        public int Delete(Category cat)
        {            
            using(var context = new DatabaseContext())
            {
               
                context.Entry(cat).State = EntityState.Deleted;

                context.Categories.Remove(cat);

                return context.SaveChanges();
            }
            //return repo_category.Delete(cat);
        }
    }
}
