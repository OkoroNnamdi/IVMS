﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Models
{
    public  class PaymentRecieve
    {
        public int Id { get; set; }
        [Display(Name ="Payment")]
        public string Name { get; set; }
        [Display(Name = "Invoce")]
        public int InvoiceId { get; set; }
        public DateTimeOffset DateOfpayment { get; set; }
        [Display(Name = "Payment Type")]
        public int PaymentTypeId { get; set; }
        [Display(Name = "Payment Amount")]
        public double PaymentAmount { get; set; }
        [Display(Name = "Full Payment")]
        public bool IsFullPayment { get; set; }


    }
}
