using Inventory.Models;
using Inventory.Repository.customerTypes;
using Inventory.Repository.Paging;
using Inventory.Services;
using Inventory.ViewModel.Bill;
using Inventory.ViewModel.Customer;
using Inventory.ViewModel.Mapping;
using Inventory.ViewModel.UserCustomerType;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

namespace Inventory.Repository.InventoryCustomerType
{
    public  class CustomerTypeRepo:ICustomerTypeRepo
    {
        public readonly ApplicationDbContext _context;
        public CustomerTypeRepo(ApplicationDbContext context)
        {
            _context = context ;
        }
        public async Task Add(CustomerTypeViewModel model)
        {
            var customerType = new CustomerType()
            {
                CustomerTypeName = model.CustomerTypeName,
                Description = model.Description,
            };
            _context.CustomersTypes.Add(customerType);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var existRecord = await _context.CustomersTypes.FirstOrDefaultAsync(x => x.CustomerTypeId == id);
            if (existRecord != null)
            {
                _context.CustomersTypes.Remove(existRecord);
            }
            await _context.SaveChangesAsync();
        }
        public async Task<PaginatedList<CustomerTypeViewModel>> GetAll(int pageSize, int pageNumber)
        {
            var customerTypeList = _context.CustomersTypes;
            var vm = customerTypeList.ModelToVM().AsQueryable(); 
            return await PaginatedList<CustomerTypeViewModel>.CreateAsync(vm, pageSize, pageNumber);
        }
        public async Task<CustomerTypeViewModel> GetById(int id)

        {
            var customerType = new CustomerTypeViewModel();

            var existRecord = await _context.CustomersTypes.FirstOrDefaultAsync(x => x.CustomerTypeId == id);
            if (existRecord != null)
            {

                customerType.CustomerTypeId = id;
                customerType.CustomerTypeName = existRecord.CustomerTypeName;
                customerType.Description = existRecord.Description;
            }
            return customerType;
        }
        public async Task Update(CustomerTypeViewModel model, int id)
        {
            var existRecord = await _context.CustomersTypes.FindAsync(id);
            if (existRecord != null)
            {
                existRecord.CustomerTypeName = model.CustomerTypeName;
                existRecord.Description = model.Description;
                _context.CustomersTypes.Update(existRecord);
            }
          
            await _context.SaveChangesAsync();

        }
    }
}
