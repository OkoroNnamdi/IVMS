using Inventory.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.ViewModel.Bill
{
    public class CreateBillTypeViewmodel
    {
        public int BillTypeID { get; set; }
        [Required]
        public string BillTypeName { get; set; }
        public string Description { get; set; }

        public BillType VMToModel()
        {
            return new BillType
            {
                BillTypeID = BillTypeID,
                BillTypeName = BillTypeName,
                Description = Description
            };
        }
    }
}
