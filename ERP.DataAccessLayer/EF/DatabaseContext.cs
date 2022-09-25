using ERP.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.DataAccessLayer
{
    public class DatabaseContext:DbContext
    {
        //public DatabaseContext()//:base("Server = DESKTOP - 9IJKPL9\SQLDERS; Database=ERPDB; uid=sa;pwd=1") 
        public DatabaseContext():base("MSSQL") 
        {
            //Database.Connection.ConnectionString = "Server = DESKTOP - 9IJKPL9\SQLDERS; Database = ERPDB; uid = sa; pwd = 1";
            //Database.Connection.ConnectionString = ConfigurationManager.ConnectionStrings["MSSQL"].ConnectionString;

            Database.SetInitializer(new MyInitializer());
        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Unit> Units { get; set; }
    }
}
