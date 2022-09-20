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

        public async Task<IActionResult> Index()
        {
            var categories = await categoriesRepository.Get();
            return View(categories);
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

            var alreadyExistsCategory = await categoriesRepository.Exists(category.Name);

            if (alreadyExistsCategory)
            {
                ModelState.AddModelError(nameof(Categories.Name), $"The name {category.Name} already exists.");

                return View(category);
            }

            await categoriesRepository.Create(category);

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> VerifyIfCategoryAlreadyExists(string name)
        {
            var alreadyExistsCategory = await categoriesRepository.Exists(name);

            if ( alreadyExistsCategory )
            {
                return Json($"The name {name} already exists.");
            }

            return Json(true);
        }
    }
}
