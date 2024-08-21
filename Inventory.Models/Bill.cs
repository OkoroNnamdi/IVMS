using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Models
{
    public class Bill
    {
         public int BillId {  get; set; }
        [Display(Name ="Bill/Invoice Number")]
        public string BillName { get; set; } = string.Empty;
        [Display(Name = "GRN")]
        public int GoodsReceivedNoteId { get; set; }
        [Display(Name = "Vendor Delivery Order")]
        public string VendorDoNumber { get; set; } = string.Empty;
        [Display(Name = "Vendor Bill/Invoice")]
        public string VendorInvoiceNumber { get; set; } = string.Empty;
        [Display(Name = "Bill Date")]
        public DateTimeOffset BillDate { get; set; }
        [Display(Name = "Bill Type")]
        public DateTimeOffset BillDueDate { get;}
        
        public int BillTypeId { get; set; } 
        public BillType BillType { get; set; }
    }
}
