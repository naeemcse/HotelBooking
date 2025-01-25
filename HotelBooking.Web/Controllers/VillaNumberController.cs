using HotelBooking.Domain.Entities;
using HotelBooking.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Serialization;

namespace HotelBooking.Web.Controllers
{
    public class VillaNumberController : Controller
    {
        private readonly ApplicationDbContext _db;

        public VillaNumberController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var villaNumbers = _db.VillaNumbers.ToList();
            return View(villaNumbers);
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(VillaNumber obj)
        {
            if (ModelState.IsValid)
            {
                _db.VillaNumbers.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "The villaNumber has been created successfully.";

                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Update(int villaNumberId)
        {
            VillaNumber? obj = _db.VillaNumbers.FirstOrDefault(u => u.Equals(villaNumberId));
            if (obj is null)
                return RedirectToAction("Error", "Home");

            return View(obj);
        }

        [HttpPost]
        public IActionResult Update(VillaNumber obj)
        {
            _db.VillaNumbers.Update(obj);
            _db.SaveChanges();
            TempData["success"] = "The villa has been updated successfully.";
            return RedirectToAction("Index");
        }



        public IActionResult Delete(int villaNumberId)
        {
            VillaNumber? obj = _db.VillaNumbers.FirstOrDefault(u => u.Id == villaNumberId);
            if (obj is null)
                return RedirectToAction("Error", "Home");

            return View(obj);
        }
        [HttpPost]
        public IActionResult Delete(VillaNumber obj)
        {
            VillaNumber? objFromDb = _db.VillaNumbers.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromDb is not null)
            {
                _db.VillaNumbers.Remove(objFromDb);
                _db.SaveChanges();
                TempData["success"] = "The villa has been deleted successfully.";

                return RedirectToAction("Index");
            }
            return View();
        }

    }
}
