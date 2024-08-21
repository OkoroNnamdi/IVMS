
using Inventory.Services.BillTypeService;
using Inventory.ViewModel.Bill;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Runtime.InteropServices;

namespace Inventory.web.Controllers
{
    public class BillTypesController : Controller
    {
        private IBillTypeRepo _BillTypeRepo;

        public BillTypesController(IBillTypeRepo billTypeRepo)
        {
            _BillTypeRepo = billTypeRepo;
        }
        [HttpGet]
        public async Task< IActionResult> Index(int pageSize =10,int pageNumber=1)
        {
            var billTypes = await _BillTypeRepo.GetAll( pageNumber, pageSize);
            return View(billTypes);
        }
        [HttpGet]
        public IActionResult Create() 
        { return View(); }
        [HttpPost]
        public async Task<IActionResult>Create(CreateBillTypeViewmodel model)
        {
            if (ModelState.IsValid)
            {
                await _BillTypeRepo.Add(model);
               return  RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet ]
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _BillTypeRepo.GetById(id);
            if (result == null) 
            {
                return NotFound();
            }
            return View(result);
        }
        [HttpPost ]
        public async Task<IActionResult> Edit(BillTypeViewModel model, int id)
        {
          if (ModelState.IsValid)
            {
              await _BillTypeRepo.Update(model, id);
                 return   RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet ]
        public async Task<IActionResult>Delete(int id)
        {
            await _BillTypeRepo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
