using ERP.DataAccessLayer.EF;
using ERP.Entity;
using ERP.Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.BusinessLogicLayer
{
    public class CustomerManager
    {
        private Repository<Customer> repo_customer = new Repository<Customer>();

        public int RegisterCustomer(RegisterModel model)
        {
            var cus = repo_customer.Find(i => i.Email == model.Email || i.Phone == model.Phone);

            if (cus != null)
            {
                return -1; // Email veya Phone eşleşmesi
            }

            Customer customer = new Customer();
            customer.Address = model.Address;
            customer.Phone = model.Phone;
            customer.Email = model.Email;
            customer.Name = model.Name;
            customer.Surname = model.Surname;
            customer.Password = model.Password;

            return repo_customer.Insert(customer);
        }

        public Customer LoginCustomer(LoginModel model)
        {
            return repo_customer.Find(i => i.Email == model.Email && i.Password == model.Password);
        }
    }
}
