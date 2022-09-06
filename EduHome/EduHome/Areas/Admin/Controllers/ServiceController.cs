using EduHome.DAL;
using EduHome.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServiceController : Controller
    {
        private readonly AppDbContext _db;
       

        public ServiceController(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            List<Service> services = await _db.Services.Where(x => !x.IsDeactive).ToListAsync();
            return View(services);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Service service)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            bool isExist = await _db.Services.AnyAsync(x => x.Name == service.Name);
            if (isExist)
            {
                ModelState.AddModelError("Name", "this is error");

            }
            await _db.Services.AddAsync(service);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Service service = await _db.Services.FirstOrDefaultAsync(x => x.Id == id);
            if (service == null)
            {
                return BadRequest();

            }

            return View(service);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Service service = await _db.Services.FirstOrDefaultAsync(x => x.Id == id);
            if (service == null)
            {
                return BadRequest();

            }
            return View(service);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeletePost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Service service = await _db.Services.FirstOrDefaultAsync(x => x.Id == id);
            if (service == null)
            {
                return BadRequest();

            }
            service.IsDeactive = true;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Service dbService = await _db.Services.FirstOrDefaultAsync(x => x.Id == id);
            if (dbService == null)
            {
                return BadRequest();

            }
            return View(dbService);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Service service)
        {

            if (id == null)
            {
                return NotFound();
            }
            Service dbservice = await _db.Services.FirstOrDefaultAsync(x => x.Id == id );
            if (dbservice==null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return View(dbservice);
            }
            bool isExist = await _db.Services.AnyAsync(x => x.Name == service.Name && x.Id != id);
            if (isExist)
            {
                ModelState.AddModelError("Name", "this is error");

            }
            dbservice.Name = service.Name;
            dbservice.Title = service.Title;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}
