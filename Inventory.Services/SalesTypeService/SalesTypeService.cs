using Inventory.Models;
using Inventory.Repository.Paging;
using Inventory.ViewModel.Bill;
using Inventory.ViewModel.Mapping;
using Inventory.ViewModel.Sales;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Services.SalesTypeService
{
    public class SalesTypeService : ISalesTypeService
    {
        private readonly ApplicationDbContext _context;
        public SalesTypeService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Add(CreateSaleTypeViewModel model)
        {
            var saleType = new SalesType
            {
                SalesTypeName = model.SalesTypeName,
                Description= model.Description,
            };
            _context.SalesTypes.Add(saleType);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var existRecord = await _context.SalesTypes.FirstOrDefaultAsync(x => x.SalesTypeId == id);
            if (existRecord != null)
            {
                _context.SalesTypes.Remove(existRecord);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<PaginatedList<SalesTypeViewModel>> GetAll(int pageSize, int pageNumber)
        {
            var salesTypeList = _context.SalesTypes;
            var vm = salesTypeList.SalesTypeModelToVM();
            return await PaginatedList<SalesTypeViewModel>.CreateAsync(vm, pageSize, pageNumber);
        }

        public async Task<SalesTypeViewModel> GetById(int id)
        {
            var salesType = new SalesTypeViewModel();
            var existRecord = await _context.SalesTypes.FirstOrDefaultAsync(x => x.SalesTypeId == id);
            if (existRecord != null)
            {

                salesType.SalesTypeId = id;
                salesType.SalesTypeName = existRecord.SalesTypeName;
                salesType.Description = existRecord.Description;
            }
            return salesType;
        }

        public async Task Update(SalesTypeViewModel model, int id)
        {
            var existRecord = await _context.SalesTypes.FirstOrDefaultAsync(x => x.SalesTypeId == id);
            if (existRecord != null)
            {
                existRecord.SalesTypeName = model.SalesTypeName;
                existRecord.Description = model.Description;
                _context.SalesTypes.Update (existRecord);
            }
            await _context.SaveChangesAsync();
        }
    }
}
