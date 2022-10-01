using ERP.DataAccessLayer.Abstract;
using ERP.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ERP.DataAccessLayer.EF
{
    public class Repository<T>: RepositoryBase,IRepository<T> where T : class // where T class yazılmaz ise T generic olarak int bile gelse Set etmeye çalışır.
    {
        //private DatabaseContext db = new DatabaseContext();//singleton Pattern

       private DbSet<T> _objectSet;

        public Repository()
        {
            _objectSet = db.Set<T>();
        }
        public List<T> List()
        {
            return _objectSet.ToList(); 
        }

        public List<T> List(Expression<Func<T,bool>> where) //Expression<Func<T,bool>> where  =>  (i=> i.Name=="Laptop")
        {
            return _objectSet.Where(where).ToList();
        }

        public T Find(Expression<Func<T, bool>> where) //Expression<Func<T,bool>> where  =>  (i=> i.Name=="Laptop")
        {
            return _objectSet.FirstOrDefault(where);
        }

        public int Insert(T obj) // Product obj
        {
            _objectSet.Add(obj); // db.Products.Add(obj)

            if(obj is BaseEntity)
            {
                BaseEntity o = obj as BaseEntity;
                DateTime now = DateTime.Now;

                o.CreateOn = now;
                o.ModifiedOn = now;
                o.ModifiedUsername = "altanemre";
            }

            return Save();
        }

        public int Update(T obj)
        {
            if (obj is BaseEntity)
            {
                BaseEntity o = obj as BaseEntity;
                DateTime now = DateTime.Now;

                o.CreateOn = now;
                o.ModifiedOn = now;
                o.ModifiedUsername = "altanemre";
            }
            return Save();
        }
        public int Delete(T obj)
        {
            _objectSet.Remove(obj); 
            return Save();
        }
        public int Save()
        {
            return db.SaveChanges();
        }

        public IQueryable<T> ListQueryable()
        {
            return _objectSet.AsQueryable<T>();
        }
    }
}
