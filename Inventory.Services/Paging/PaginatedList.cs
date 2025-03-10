﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Repository.Paging
{
    public  class PaginatedList<T>:List<T>
    {
        public int PageIndex { get; set; }
        public int TotalPages {  get; set; }
        public PaginatedList(List<T>items, int count,int pageIndex,int pageSize) 
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling (count/(double)pageSize);
            this.AddRange(items);
        }
        public bool HasPreviousPage => PageIndex > 1;
        public bool HasNextPage => PageIndex < TotalPages;

        public static async Task<PaginatedList<T>> CreateAsync(IEnumerable<T> source, int pageIndex,int pageSiize)
        {
            var count = source.Count();
            var items =  source.Skip((pageIndex-1)*pageSiize).Take(pageSiize).ToList();
            return new PaginatedList<T> (items, count, pageIndex, pageSiize);
        }
    }
}
