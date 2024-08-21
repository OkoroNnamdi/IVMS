using Inventory.Repository.Paging;
using Inventory.ViewModel.Sales;
using Inventory.ViewModel.Vendor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Services.SalesTypeService
{
    public interface ISalesTypeService
    {
        Task<PaginatedList<SalesTypeViewModel>> GetAll(int pageSize, int pageNumber);
        Task Add(CreateSaleTypeViewModel model);
        Task Delete(int id);
        Task Update(SalesTypeViewModel model, int id);
        Task<SalesTypeViewModel> GetById(int id);
    }
}
