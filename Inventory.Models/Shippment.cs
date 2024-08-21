using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Models
{
    public class Shippment
    {
        public int Id { get; set; }
        [Display(Name ="Shipment Number")]
        public string ShippinmentName { get; set; }
        [Display(Name = "Sales Order")]
        public int SalesOrderId { get; set; }
        public DateTimeOffset ShippingmentDate { get; set; }
        [Display(Name = "Shipment Type")]
        public int ShippmentTypeId { get; set; }
        [Display(Name = "Warehouse")]
        public int WarehouseId { get; set; }
        [Display(Name = "Full shipment")]
        public bool IsFullyShipped { get; set; } = true;
    }
}
