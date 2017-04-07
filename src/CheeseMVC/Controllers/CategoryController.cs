using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CheeseMVC.Data;
using CheeseMVC.Models;

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

            List<CheeseCategory> cheeseCats = new List<CheeseCategory>();
            
            ViewBag.Add(context.Categories.ToList());
            return View();
        }
    }
}
