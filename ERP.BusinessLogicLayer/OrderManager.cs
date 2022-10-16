using ERP.DataAccessLayer.EF;
using ERP.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.BusinessLogicLayer
{
    public class OrderManager
    {
        private Repository<Order> repo_order = new Repository<Order>();

        public int AddOrder(Order model)
        {
            return repo_order.Insert(model);
        }
    }
}
