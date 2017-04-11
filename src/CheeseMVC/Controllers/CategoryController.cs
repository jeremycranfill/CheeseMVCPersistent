using System;



using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CheeseMVC.Data;
using CheeseMVC.Models;
using CheeseMVC.ViewModels;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CheeseMVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CheeseDbContext context;
        public CategoryController(CheeseDbContext dbContext) { context = dbContext;}
        // GET: /<controller>/
        public IActionResult Index()

        {

            List<CheeseCategory> cheeseCats = context.Categories.ToList();




            return View(cheeseCats);
        }

        public IActionResult Add()
        {

            var addViewmodel = new AddCategoryViewModel();

            return View(addViewmodel);
        }

        [HttpPost]
        public IActionResult Add(AddCategoryViewModel AddModel)
        {
            if(ModelState.IsValid)
            {
                CheeseCategory newCategory = new CheeseCategory();
                newCategory.Name = AddModel.Name;
                context.Categories.Add(newCategory);
                context.SaveChanges();
                return Redirect("/");
            }
            return View(AddModel);
        }


    }
}
