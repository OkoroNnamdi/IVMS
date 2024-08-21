using Inventory.Repository.Paging;
using Inventory.ViewModel.Bill;
using Inventory.ViewModel.Vendor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Services.VendorTypeService
{
    public  interface IVendorTypeRepo
    {
        Task<PaginatedList<VendorTypeViewModel>> GetAll(int pageSize, int pageNumber);
        Task Add(VendorTypeViewModel model);
        Task Delete(int id);
        Task Update(VendorTypeViewModel model, int id);
        Task<VendorTypeViewModel> GetById(int id);
    }
}
