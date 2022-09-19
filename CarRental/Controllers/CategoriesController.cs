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
        public async Task<IActionResult> Create( Categories category)
        {
            if ( !ModelState.IsValid)
            {
                return View(category);
            }

            var ifExistsCategory = await categoriesRepository.Exists(category.Name);

            if (ifExistsCategory)
            {
                ModelState.AddModelError(nameof(Categories.Name), $"The name {category.Name} already exists.");

                return View(category);
            }

            await categoriesRepository.Create(category);

            return View();
        }
    }
}
