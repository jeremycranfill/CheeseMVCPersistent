﻿using CheeseMVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CheeseMVC.ViewModels
{
    public class AddCheeseViewModel
    {
        [Required]
        [Display(Name = "Cheese Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You must give your cheese a description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int CategoryID { get; set; }
        public List<SelectListItem> Categories { get; set; } = new List<SelectListItem>();

        public AddCheeseViewModel() { }

        public AddCheeseViewModel(List<CheeseCategory> catList)
        {
            foreach (CheeseCategory field in catList)
            {
                Categories.Add(new SelectListItem
                {
                    Value = field.ID.ToString(),
                    Text = field.Name
                }

                );
            }
            
        }


    }
    



    }
