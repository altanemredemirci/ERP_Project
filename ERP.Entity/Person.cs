using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Entity
{
    public class Person : BaseEntity
    {
        [Required,StringLength(25)]
        public string Name { get; set; }
        [Required, StringLength(25)]
        public string Surname { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        public bool IsAdmin { get; set; }
        public int UnitId { get; set; }
        public Unit Unit { get; set; }
    }

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
