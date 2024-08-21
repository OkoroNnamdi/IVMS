using Inventory.Repository.Paging;
using Inventory.Services;
using Inventory.ViewModel.Customer;
using Inventory.ViewModel.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Repository.CustomerService
{
    public class CustomerRepo : ICustomerRepo
    {
        public readonly ApplicationDbContext _context;
        public CustomerRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<PaginatedList<CustomerListViewModel>> GetAll(int pageSize, int pageNumber)
        {
            var customerList = _context.customers ;
            var vm = customerList.CustomerModelToVM().AsQueryable();
            return await PaginatedList<CustomerListViewModel>.CreateAsync(vm, pageSize, pageNumber);
        }
    }
}
