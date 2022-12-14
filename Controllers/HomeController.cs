using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;
using CarInventory.Models;
using Microsoft.AspNetCore.Authorization;

namespace CarInventory.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CarsContext _db;

        public HomeController(ILogger<HomeController> logger, CarsContext db)
        {
            _logger = logger;
            _db = db;
        }
        
        public IActionResult Index()
        {
            _logger.LogInformation("Started Index page");
            return View(_db.cars.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            _logger.LogInformation("Started Index page");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Car car)
        {
            if (ModelState.IsValid)
            {
                _db.Add(car);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                _logger.LogError("Started create page");
            }

            return View(car);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var carsList = _db.cars.Find(id);
            if (carsList == null)
            {
                _logger.LogError("Not Found");
                return NotFound();
            }
            _db.cars.Remove(carsList);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var carsList = _db.cars.Find(id);
            if (carsList == null)
            {
                _logger.LogError("Not Found");
                return NotFound();
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]

        public IActionResult Edit(Car car)
        {
            if (ModelState.IsValid)
            {
                _db.Update(car);
                _db.SaveChanges();
                return RedirectToAction(nameof(Edit));
            }
            else
            {
                _logger.LogError("Not valid");
            }
            return View(car);
        }
        
    }
}