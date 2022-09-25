using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.BusinessLogicLayer
{
    public class Test
    {
        public Test()
        {
            ERP.DataAccessLayer.DatabaseContext db = new DataAccessLayer.DatabaseContext();
            db.Categories.ToList();
        }
    }
}
