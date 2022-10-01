using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Entity
{
    public class Unit : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public List<Person> Persons { get; set; }

        public Unit()
        {
            Persons = new List<Person>();
        }
    }
}