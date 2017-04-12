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

            
        }

        public AddMenuItemViewModel(Menu varmenu, IEnumerable<Cheese> cheese)
        {
            Cheeses = new List<SelectListItem>();
            menu = varmenu;
            foreach (var ieCheese in cheese)
            {
                Cheeses.Add(new SelectListItem
                {
                    Value = ieCheese.ID.ToString(),
                    Text = ieCheese.Name

                });


            }


        }   

    }
}
