using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Models
{
    public  class ShipmentType
    {
        [Key]
        public int ShipmentId { get; set; }
        [Required]
        public string ShipmentTypeName { get; set; }
        public string Description { get; set; }
    }
}
