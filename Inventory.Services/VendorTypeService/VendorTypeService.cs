using Inventory.Models;
using Inventory.Repository.Paging;
using Inventory.ViewModel.Mapping;
using Inventory.ViewModel.UserCustomerType;
using Inventory.ViewModel.Vendor;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Services.VendorTypeService
{
    public class VendorTypeService : IVendorTypeRepo
    {
        public readonly ApplicationDbContext _context;
        public VendorTypeService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Add(VendorTypeViewModel model)
        {
            var vendorType = new VendorType()
            {
                VendorTypeName = model.VendorTypeName,
                Description = model.Description,
            };
            _context.vendorsTypes.Add(vendorType);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var existRecord = await _context.vendorsTypes.FirstOrDefaultAsync(x => x.VendorTypeId == id);
            if (existRecord != null)
            {
                _context.vendorsTypes.Remove(existRecord);
            }
            await _context.SaveChangesAsync();
        }
        public async Task<PaginatedList<VendorTypeViewModel>> GetAll(int pageSize, int pageNumber)
        {
            var vendorTypeList = _context.vendorsTypes;
            var vm = vendorTypeList.VendorTypeModelToVM().AsQueryable();
            return await PaginatedList<VendorTypeViewModel>.CreateAsync(vm, pageSize, pageNumber);
        }
        public async Task<VendorTypeViewModel> GetById(int id)

        {
            var vendorType = new VendorTypeViewModel();

            var existRecord = await _context.vendorsTypes.FirstOrDefaultAsync(x => x.VendorTypeId == id);
            if (existRecord != null)
            {

                vendorType.VendorTypeId = existRecord.VendorTypeId;
                vendorType.VendorTypeName = existRecord.VendorTypeName;
                vendorType.Description = existRecord.Description;
            }
            return vendorType;
        }
        public async Task Update(VendorTypeViewModel model, int id)
        {
            var existRecord = await _context.vendorsTypes.FindAsync(id);
            if (existRecord != null)
            {
                existRecord.VendorTypeName = model.VendorTypeName;
                existRecord.Description = model.Description;
                _context.vendorsTypes.Update(existRecord);
            }

            await _context.SaveChangesAsync();

        }
    }
}
