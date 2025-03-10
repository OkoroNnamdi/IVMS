﻿using Inventory.Repository.Paging;
using Inventory.Services;
using Inventory.ViewModel.Bill;
using Inventory.ViewModel.Customer;
using Inventory.ViewModel.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Repository.BillService
{
   public  class BillRepo:IBillRepo
    {
        private readonly ApplicationDbContext _context;
        public BillRepo(ApplicationDbContext context)
        {
             _context = context;
        }
        public async Task<PaginatedList<BillListViewModel>> GetAll(int pageSize, int pageNumber)
        {
            var BillList = _context.bills ;
            var vm = BillList.BillModelToVM().AsQueryable();
            return await PaginatedList<BillListViewModel>.CreateAsync(vm, pageSize, pageNumber);
        }
    }
}
