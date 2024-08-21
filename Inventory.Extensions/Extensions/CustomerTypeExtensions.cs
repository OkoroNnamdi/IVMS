using Inventory.Models;
using Inventory.ViewModel.Customer;

namespace Inventory.web.Extensions
{
    public static  class CustomerTypeExtensions
    {
        public static IEnumerable<CustomerTypeListViewModel> ModelToVM(this IEnumerable<CustomerType> customerTypes)
        {
            return customerTypes.Select(ct => new CustomerTypeListViewModel
            {
                CustomerTypeId = ct.CustomerTypeId,
                CustomerTypeName = ct.CustomerTypeName,
                Description = ct.Description
            });
        }  }
}
