using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Entity
{
    public class Product:BaseEntity
    {
        [Required, StringLength(25)]
        public string Brand { get; set; }
        [Required, StringLength(25)]
        public string Model { get; set; }
        [Required, StringLength(15)]
        public string Color { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public short Stock { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
