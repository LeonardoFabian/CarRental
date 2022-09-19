using CarRental.Models;
using CarRental.Services;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace CarRental.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoriesRepository categoriesRepository;

        public CategoriesController(ICategoriesRepository categoriesRepository)
        {
            this.categoriesRepository = categoriesRepository;
        }

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

            categoriesRepository.Create(category);

            return View();
        }
    }
}
