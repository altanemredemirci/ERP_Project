using ERP.DataAccessLayer.EF;
using ERP.Entity;
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
    }
}
