using Inventory.Models;
using Inventory.ViewModel.Bill;
using Inventory.ViewModel.Customer;
using Inventory.ViewModel.Product;
using Inventory.ViewModel.Sales;
using Inventory.ViewModel.UserCustomerType;
using Inventory.ViewModel.Vendor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.ViewModel.Mapping
{
    public static  class Relationship
    {
        public static IEnumerable< CustomerTypeViewModel> ModelToVM(this IEnumerable < CustomerType>customerType)
        {
            List<CustomerTypeViewModel> list = new List<CustomerTypeViewModel>();
            foreach (var ct in customerType)
            {
                list.Add(new CustomerTypeViewModel
                {
                    CustomerTypeId = ct.CustomerTypeId,
                    CustomerTypeName = ct.CustomerTypeName,
                    Description = ct.Description,
                });

            }
            return list;
            
        }

        public static IEnumerable<CustomerListViewModel>CustomerModelToVM(this IEnumerable<Inventory.Models.Customer> customer)
        {
            List<CustomerListViewModel> list = new List<CustomerListViewModel>();
            foreach (var ct in customer)
            {
                list.Add(new CustomerListViewModel
                {
                    CustomerId = ct.CustomerId,
                    City = ct.City,
                    ContactPerson = ct.ContactPerson,
                    CustomerName = ct.CustomerName,
                    Address = ct.Address,
                    Email = ct.Email,
                    PhoneNumber = ct.PhoneNumber,
                    State = ct.State,
                    Zipcode = ct.Zipcode,
                    CustomerTypeId = ct.CustomerTypeId,
                   
                });

            }
            return list;

        }
        public static IEnumerable<BillListViewModel> BillModelToVM(this IEnumerable<Inventory.Models.Bill> customerBill)
        {
            List<BillListViewModel> list = new List<BillListViewModel>();
            foreach (var ct in customerBill)
            {
                list.Add(new BillListViewModel
                {
                    
                     BillDate = ct.BillDate,
                     BillId = ct.BillId,
                     BillName = ct.BillName,
                     BillType = ct.BillType,
                     GoodsReceivedNoteId = ct.GoodsReceivedNoteId,
                     VendorDoNumber = ct.VendorDoNumber,
                     VendorInvoiceNumber = ct.VendorInvoiceNumber,
                     BillTypeId = ct.BillTypeId,
                        
                });

            }
            return list;

        }
        public static IEnumerable<BillTypeListViewModel> BillTypeModelToVM(this IEnumerable<Inventory.Models.BillType> customerTypeBill)
        {
            List<BillTypeListViewModel> Billlist = new List<BillTypeListViewModel>();
            foreach (var ct in customerTypeBill)
            {
                Billlist.Add(new BillTypeListViewModel
                {
                     BillTypeID = ct.BillTypeID,
                     BillTypeName = ct.BillTypeName,
                     Description = ct.Description,
                });

            }
            return Billlist;

        }
        public static IEnumerable<ProductTypeListViewModel> ProductTypeModelToVM(this IEnumerable<Inventory.Models.ProductType> productTypeList)///
        {
            List<ProductTypeListViewModel> ProductTypeList = new List<ProductTypeListViewModel>();
            foreach (var ct in ProductTypeList)
            {
                ProductTypeList.Add(new ProductTypeListViewModel
                {
                     Description = ct.Description,
                      ProductTypeId = ct.ProductTypeId,
                      ProductTypeName = ct.ProductTypeName,
                });

            }
            return ProductTypeList;

        }
        public static IEnumerable<ProductListViewModel> ProductModelToVM(this IEnumerable<Inventory.Models.Product> productList)///
        {
            List<ProductListViewModel> ProductList = new List<ProductListViewModel>();
            foreach (var ct in ProductList)
            {
                ProductList.Add(new ProductListViewModel
                {
                    Description = ct.Description,
                    BranchId = ct.BranchId,
                    BarCode = ct.BarCode,
                    BuyingPrice = ct.BuyingPrice,
                    CurrencyId = ct.CurrencyId,
                    MeasureUnitId = ct.MeasureUnitId,
                    ProductCode = ct.ProductCode,
                    ProductName = ct.ProductName,
                    ProductId = ct.ProductId,
                    ProductImage = ct.ProductImage,
                    SellingPrice = ct.SellingPrice,           
                });

            }
            return ProductList;

        }
        public static IEnumerable<VendorTypeViewModel> VendorTypeModelToVM(this IEnumerable< VendorType>vendorTypes)
        { 
            var list = new List<VendorTypeViewModel>();
            foreach (var vendorType in vendorTypes)
            {
                list.Add(new VendorTypeViewModel
                {
                    VendorTypeName = vendorType.VendorTypeName,
                    VendorTypeId = vendorType.VendorTypeId,
                    Description = vendorType.Description,
                });
            }
            return list;
        }
        public static IEnumerable<SalesTypeViewModel> SalesTypeModelToVM(this IEnumerable<SalesType> salesTypes)
        {
            var list = new List<SalesTypeViewModel>();
            foreach (var saleType in salesTypes)
            {
                list.Add(new SalesTypeViewModel
                {
                    SalesTypeId = saleType.SalesTypeId,
                    SalesTypeName = saleType.SalesTypeName,
                    Description = saleType.Description,
                });
            }
            return list;
        }
    }
}
