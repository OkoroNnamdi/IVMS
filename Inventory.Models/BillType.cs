﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Models
{
    public  class BillType
    {
        public int BillTypeID { get; set; }
        [Required]
        public string BillTypeName { get; set; }
        public string Description {  get; set; }
    }
}
