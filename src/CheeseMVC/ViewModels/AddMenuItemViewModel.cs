using CheeseMVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheeseMVC.ViewModels
{
    public class AddMenuItemViewModel
    {
       public int cheeseID { get; set; }
        public int menuID { get; set; }
        public Menu menu { get; set; }
      public  List<SelectListItem> Cheeses { get; set; }


        public AddMenuItemViewModel()
        {
            Cheeses = new List<SelectListItem>();
        }

        public AddMenuItemViewModel(Menu varmenu, IEnumerable<Cheese> cheese)
        {

            menu = varmenu;
            foreach (var iecheese in cheese)
            {
                Cheeses.Add(new SelectListItem
                {
                    Value = iecheese.ID.ToString(),
                    Text = iecheese.Name

                });


            }


        }   

    }
}
