﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Models
{
    public  class Product
    {
        public int ProductId { get; set; }
        [Required]
        public string  ProductName { get; set; }
        public string  ProductCode { get; set; }
        public string BarCode { get; set; }
        public string  Description { get; set; }
        public string  ProductImage { get; set; }
        [Display(Name = "Measure Unit")]
        public int MeasureUnitId { get; set; }
        public double BuyingPrice { get; set; }
        public double SellingPrice { get; set;}
        [Display (Name ="Branch")]
        public int BranchId { get; set; }
        [Display(Name = "Currency")]
        public int CurrencyId { get; set; }
    }
}
