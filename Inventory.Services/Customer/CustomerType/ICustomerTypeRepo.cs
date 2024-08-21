using Inventory.Repository.Paging;
using Inventory.ViewModel.Bill;
using Inventory.ViewModel.Customer;
using Inventory.ViewModel.UserCustomerType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Repository.customerTypes
{
    public  interface ICustomerTypeRepo
    {
        Task<PaginatedList<CustomerTypeViewModel>> GetAll(int pageSize,int pageNumber);
        Task Add(CustomerTypeViewModel model);
        Task Delete(int id);
        Task Update(CustomerTypeViewModel model,int id);
        Task<CustomerTypeViewModel> GetById(int id);
    }
}
