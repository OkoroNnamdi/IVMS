using Inventory.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Services
{
   public  class ApplicationDbContext:IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options) { }
       public DbSet <AppUser> applicationUser {  get; set; }
        public DbSet<Bank>Banks { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Bill> bills { get; set; }
        public DbSet<BillType > billTypes  { get; set; }
        public DbSet<Branch> branches { get; set; }
        public DbSet<Brand> brands { get; set; }
        public DbSet<Currency > Currencies { get; set;}
        public DbSet<Customer> customers { get; set; }
        public DbSet<CustomerType> CustomersTypes { get; set; }
        public DbSet<Invoice > invoices { get; set; }
        public DbSet<InvoiceType > invoicesTypes { get; set; }
        public DbSet<Item > items { get; set; }
        public DbSet<MeasureUnit > measureUnits { get; set; }
        public DbSet<NumberSquence > numberSquences { get; set;}
        public DbSet<ProductType > productTypes { get; set; }
        public DbSet<PurchaseOrder > purchaseOrders { get; set; }
        public DbSet<PurchaseOrderLine > purchaseOrdersLine { get; set;}
        public DbSet<PurchaseType > purchaseTypes { get; set; }
        public DbSet<ReceivedNote > receivedNotes { get; set; }
        public DbSet<SalesOrder>salesOrders { get; set; }
        public DbSet<SalesOrderLine > salesOrdersLine { get; set;}
        public DbSet<SalesType>SalesTypes { get; set; }
        public DbSet <ShipmentType> shipmentTypes { get; set; }
        public DbSet<Shippment>Shippments { get; set; }
        public DbSet <UserProfile> userProfiles { get; set; }
        public DbSet<Vendor > vendors { get; set; }
        public DbSet<VendorType> vendorsTypes { get; set;}
        public DbSet<Warehouse>Warehouses { get; set; }


                
    }
}
