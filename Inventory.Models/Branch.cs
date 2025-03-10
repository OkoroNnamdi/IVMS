﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Models
{
    public class Branch { 
        public int BranchId { get; set; }
        [Required]
        public string BranchName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        [Display(Name = "Currency")]
        public int CurrencyId { get; set; } 
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PhoneNumber { get; set; }
        [Display(Name ="Contact Person")]
        public string ContactPerson { get; set; }
        public string Email { get; set; }
    }
         
    
}

