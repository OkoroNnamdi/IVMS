using Inventory.Repository;
using Inventory.Repository.Paging;
using Inventory.ViewModel.Bill;
using Inventory.ViewModel.Mapping;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Services.BillTypeService
{
    public class BillTypeRepo : IBillTypeRepo
    {
        private readonly ApplicationDbContext _context;
        public BillTypeRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(CreateBillTypeViewmodel model)
        {
            var billType = model.VMToModel();
            _context.billTypes .Add(billType);
            await _context.SaveChangesAsync();
        }



        public async Task Delete(int id)
        {
            var existRecord = await _context.billTypes.FirstOrDefaultAsync(x => x.BillTypeID == id);
            if(existRecord!= null)
            {
                _context.billTypes.Remove(existRecord);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<PaginatedList<BillTypeListViewModel>> GetAll(int pageSize, int pageNumber)
        {
            var BillTypeList = _context.billTypes;
            var vm = BillTypeList.BillTypeModelToVM();
            return await PaginatedList<BillTypeListViewModel>.CreateAsync(vm, pageSize, pageNumber);
        }

        public async Task<BillTypeViewModel> GetById(int id)
        {
            var billType = new BillTypeViewModel();
            var existRecord = await _context.billTypes.FirstOrDefaultAsync(x => x.BillTypeID == id);
            if (existRecord!= null)
            {
              
                billType.BillTypeID = id;
                billType.BillTypeName = existRecord.BillTypeName;
                billType.Description = existRecord.Description;
            }
            return billType;
        }

        public async Task Update(BillTypeViewModel model, int id)
        {
            var existRecord =await _context.billTypes.FirstOrDefaultAsync(x => x.BillTypeID ==id);
            if (existRecord != null)
            {
                existRecord.BillTypeName = model.BillTypeName;
                existRecord.Description = model.Description;
            }
            await _context.SaveChangesAsync();   
        }
        
    }
}
