using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Models
{
    public class PurchaseOrderLine
    {
        public int Id { get; set; }
        
        public int PurchaseOrderId { get; set; }
        public PurchaseOrder PurchaseOrder{ get; set; }
        public int ProductId { get; set; }
        public string  Description { get; set; }
        public int Quantity { get; set; }
        public double  Amount { get; set; }
        public double  UnitPrice { get; set; }
        [Display(Name ="Discount Percentage")]
        public int DiscountPercentage { get; set; }
        [Display (Name ="Discount Amount")]
        public double  DiscountAmount { get; set;}
        [Display (Name ="Sub Total")]
        public double  SubTotal { get; set;}
        [Display(Name = "Tax Percentage")]
        public double TaxPercentage {  get; set; }
        [Display(Name = "Tax amount")]
        public double TaxAmount { get; set;}
        public double  Total { get; set; }
    }
}
