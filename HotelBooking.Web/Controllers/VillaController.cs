using HotelBooking.Domain.Entities;
using HotelBooking.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Serialization;

namespace HotelBooking.Web.Controllers
{
    public class VillaController : Controller
    {
        private readonly ApplicationDbContext _db;
        
        public VillaController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {  
            var villas = _db.Villas.ToList();
            return View(villas);
        }

        public IActionResult Create()
        {  
          
            return View( );
        }

        [HttpPost]
        public IActionResult Create( Villa obj)
        {
            _db.Villas.Add(obj);
            _db.SaveChanges();
             return  RedirectToAction("Index");
        }

        public IActionResult Delete()
        {
            return View();
        }

    }
}
