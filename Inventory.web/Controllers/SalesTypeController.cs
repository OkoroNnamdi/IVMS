using Inventory.Repository.customerTypes;
using Inventory.Services.SalesTypeService;
using Inventory.ViewModel.Sales;
using Inventory.ViewModel.UserCustomerType;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.web.Controllers
{
    public class SalesTypeController : Controller
    {
        private readonly ISalesTypeService _salesTypeService;
        public SalesTypeController(ISalesTypeService salesTypeService)
        {
            _salesTypeService = salesTypeService;
        }
        [HttpGet]
        public async Task<IActionResult> Index(int pageSize = 10, int pageNumber = 1)
        {
            var salesTypes = await _salesTypeService.GetAll(pageNumber, pageSize);
            return View(salesTypes);
        }
        [HttpGet]
        public IActionResult Create()
        { return View(); }
        [HttpPost]
        public async Task<IActionResult> Create(CreateSaleTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _salesTypeService.Add(model);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _salesTypeService.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(SalesTypeViewModel model, int id)
        {
            if (ModelState.IsValid)
            {
                await _salesTypeService.Update(model, id);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _salesTypeService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
