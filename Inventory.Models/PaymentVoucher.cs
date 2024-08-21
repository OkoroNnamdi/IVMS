using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Models
{
    public  class PaymentVoucher
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="Payment Voucher Number")]
        public string Name { get; set; }
        [Display(Name = "Bill")]
        public int BillId { get; set; }
       
        public DateTimeOffset  PaymentDate { get; set; }
        [Display(Name = "Payment Amount")]
        public decimal  PaymentAmount { get; set; }
        [Display(Name = "Payment type")]
        public int PaymentTypeId { get; set; }
        [Display(Name = "Cash Source")]
        public int CashBankId { get; set; }
        [Display(Name = "Fully Payment ")]
        public bool IsFullyPayment { get; set; }
    }
}
