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
    public class PersonManager
    {
        private Repository<Person> repo_person = new Repository<Person>();
        public List<Person> GetPersonByUnit(int id)
        {
           return repo_person.List(i => i.UnitId == id);
        }

        public List<Person> GetAll()
        {
            return repo_person.List();
        }

        public int AddPerson(Person p)
        {
            var person = repo_person.Find(i => i.Email == p.Email);
            if (person != null)
            {
                return 0;
            }

            return repo_person.Insert(p);

        }

        public Person GetById(int id)
        {
           return repo_person.Find(i => i.Id == id);
        }

        public int UpdatePerson(Person model)
        {
            return repo_person.Update(model);
        }

        public int DeletePerson(int id)
        {
            var model = repo_person.Find(i => i.Id == id);

            return repo_person.Delete(model);
        }

        public Person LoginPerson(LoginModel model)
        {
            return repo_person.Find(i => i.Email == model.Email && i.Password == model.Password);
        }
    }
}
