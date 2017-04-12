using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CheeseMVC.Data;
using CheeseMVC.Models;
using CheeseMVC.ViewModels;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CheeseMVC.Controllers
{
    public class MenuController : Controller
    {
        
        private CheeseDbContext context;

        public MenuController(CheeseDbContext dbContext)
        {
            context = dbContext;
        }



        // GET: /<controller>/
        public IActionResult Index()
        {
            IList<Menu> Menus = context.Menus.ToList();
            return View(Menus);
        }

        [HttpGet]
        public IActionResult Add()
        {
            AddMenuViewModel menumodel = new AddMenuViewModel();
            return View(menumodel);

        }


        [HttpPost]
        public IActionResult Add(AddMenuViewModel viewmodel)
        {
            if (ModelState.IsValid)
            {
                Menu newmenu = new Menu();
                newmenu.Name = viewmodel.Name;
                context.Menus.Add(newmenu);
                context.SaveChanges();
                return Redirect("/Menu/ViewMenu/" + newmenu.ID);
                    }

            return View("Add", viewmodel);
        }


        [HttpGet]
        public IActionResult ViewMenu(int id)
        {
            Menu dbMenu = context.Menus.Where(c => c.ID == id).Single();


            List<CheeseMenu> items = context
           .CheeseMenus
           .Include(item => item.Cheese)
           .Where(cm => cm.MenuID == id)
           .ToList(); 

            ViewMenuViewModel ViewModel = new ViewMenuViewModel();
            ViewModel.Items = items;
            ViewModel.Menu = dbMenu;
            return View(ViewModel);

        }

        [HttpGet]
        public IActionResult AddItem(int id)
        {
            Menu menu = context.Menus.Single(c => c.ID == id);
            IList<Cheese> cheeses = context.Cheeses.ToList();

            AddMenuItemViewModel model = new AddMenuItemViewModel(menu,cheeses);
            return View(model);

        }

        [HttpPost]
        public IActionResult AddItem(AddMenuItemViewModel model)
        {
            if(ModelState.IsValid)
                {
                IList<CheeseMenu> existingItems = context.CheeseMenus
                .Where(cm => cm.CheeseID == model.cheeseID)
                .Where(cm => cm.MenuID == model.menuID).ToList();

                if (existingItems.Count < 1)
                {
                    CheeseMenu cheesemenu = new CheeseMenu();
                    cheesemenu.CheeseID = model.cheeseID;
                    cheesemenu.MenuID = model.menuID;
                    context.CheeseMenus.Add(cheesemenu);
                    context.SaveChanges();
                    return Redirect("/Menu/ViewMenu/" + cheesemenu.MenuID);
                }
                else { return Redirect("/Menu/ViewMenu/" + model.menuID); }


            }

            return View(model);

        }

    }
}
