using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Models
{
   public  class ReceivedNote
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTimeOffset GRNDate { get; set; }
        public string  VenderNumber { get; set; }
        public string  VendorInvoiceNumber { get; set; }
        public int WarehouseId { get; set; }
        public bool IsReceived { get; set; } = true;
    }
}
