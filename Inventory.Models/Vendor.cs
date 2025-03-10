﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Models
{
    public class Vendor
    {
        public int VendorId { get; set; }
        [Required]
        public string VendorName { get; set; }
        [Display(Name ="Vendor Type")]
        public string VendorTypeId { get; set;}
        [Display (Name ="Street Address")]
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        [Display (Name ="Zip code")]
        public string Zipcode { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        [Display (Name ="Contact Person")]
        public string ContactPerson { get; set; }
    }
}
