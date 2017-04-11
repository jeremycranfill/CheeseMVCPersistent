using CheeseMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace CheeseMVC.Data
{
    public class CheeseDbContext : DbContext
    {
        public DbSet<CheeseCategory> Categories { get; set; }

        public DbSet<Cheese> Cheeses { get; set; }

        public DbSet<Menu> Menus { get; set; }

        public DbSet<CheeseMenu> CheeseMenus {get; set;}
        
       
       

        public CheeseDbContext(DbContextOptions<CheeseDbContext> options) 
            : base(options) {        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<Cheese>().HasKey(c => c.ID);
            modelBuilder.Entity<Menu>().HasKey(m => m.ID);
            modelBuilder.Entity<CheeseMenu>().HasKey(c => new { c.CheeseID, c.MenuID });


            modelBuilder.Entity<Cheese>().HasMany(cm => cm.CheeseMenus);
            modelBuilder.Entity<Menu>().HasMany(cm => cm.CheeseMenus);

        }


    }
}
