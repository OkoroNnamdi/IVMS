using Inventory.Repository.customerTypes;
using Inventory.Services.BillTypeService;
using Inventory.ViewModel.Bill;
using Inventory.ViewModel.UserCustomerType;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.web.Controllers
{
    public class CustomerTypeController : Controller
    {
        private readonly ICustomerTypeRepo _customerTypeRepo;
        public CustomerTypeController(ICustomerTypeRepo customerTypeRepo)
        {
            _customerTypeRepo = customerTypeRepo;
        }
        [HttpGet]
        public async Task<IActionResult> Index(int pageSize = 10, int pageNumber = 1)
        {
            var customerTypes = await _customerTypeRepo.GetAll(pageNumber, pageSize);
            return View(customerTypes);
        }
        [HttpGet]
        public IActionResult Create()
        { return View(); }
        [HttpPost]
        public async Task<IActionResult> Create(CustomerTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _customerTypeRepo.Add(model);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _customerTypeRepo.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(CustomerTypeViewModel model,int id)
        {
            if (ModelState.IsValid)
            {
                await _customerTypeRepo.Update(model, id);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _customerTypeRepo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}

