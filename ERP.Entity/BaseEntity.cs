using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Entity
{
    public class BaseEntity
    {
        public int Id { get; set; }

        [Required,DisplayName("Oluşturulma Tarihi")]
        public DateTime CreateOn { get; set; }

        [Required, DisplayName("Güncellenme Tarihi")]
        public DateTime ModifiedOn { get; set; }

        [Required, DisplayName("Güncelleyen Kişi")]
        public string ModifiedUsername { get; set; }
    }
}
