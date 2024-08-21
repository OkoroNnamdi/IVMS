using Inventory.Services.BillTypeService;
using Inventory.Services.VendorTypeService;
using Inventory.ViewModel.Bill;
using Inventory.ViewModel.Vendor;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.web.Controllers
{
    public class VendorTypesController : Controller
    {
        private readonly IVendorTypeRepo _vendorTypeRepo;
        public VendorTypesController(IVendorTypeRepo vendorTypeRepo)
        {
            _vendorTypeRepo = vendorTypeRepo;
        }
        [HttpGet]
        public async Task<IActionResult> Index(int pageSize = 10, int pageNumber = 1)
        {
            var vendorTypes = await _vendorTypeRepo.GetAll(pageNumber, pageSize);
            return View(vendorTypes);
        }
        [HttpGet]
        public IActionResult Create()
        { return View(); }
        [HttpPost]
        public async Task<IActionResult> Create(VendorTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _vendorTypeRepo.Add(model);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _vendorTypeRepo.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(VendorTypeViewModel model, int id)
        {
            if (ModelState.IsValid)
            {
                await _vendorTypeRepo.Update(model, id);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _vendorTypeRepo.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
          var details =  await _vendorTypeRepo.GetById(id);
            return View(details);
        }
    }
}

