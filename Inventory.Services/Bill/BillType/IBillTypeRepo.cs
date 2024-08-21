using Inventory.Repository.Paging;
using Inventory.ViewModel.Bill;
using Inventory.ViewModel.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Services.BillTypeService
{
    public  interface IBillTypeRepo
    {
        Task<  PaginatedList<BillTypeListViewModel>> GetAll(int pageSize, int pageNumber);
        Task Add(CreateBillTypeViewmodel model);
        Task Delete(int id);
        Task Update(BillTypeViewModel model, int id);
        Task <BillTypeViewModel> GetById(int id);
    }
}
