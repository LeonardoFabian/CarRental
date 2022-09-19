using CarRental.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create( Categories category)
        {
            if ( !ModelState.IsValid)
            {
                return View(category);
            }
            return View();
        }
    }
}
