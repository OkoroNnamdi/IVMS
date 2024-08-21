using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Models
{
    public  class Warehouse
    {
        public int WarehouseId { get; set; }
        [Display (Name ="Name")]
        public string WarehouseName { get; set; }
        public string WarehouseDescription { get; set; }
        public Branch Branch { get; set; }
        [Display (Name ="Branch ID")]
        public int BranchId { get; set; }
    }
}
