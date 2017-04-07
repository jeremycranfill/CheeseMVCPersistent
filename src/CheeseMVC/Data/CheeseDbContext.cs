using CheeseMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace CheeseMVC.Data
{
    public class CheeseDbContext : DbContext
    {
        public DbSet<Cheese> Cheeses { get; set; }
        public object Categories { get; internal set; }

        public CheeseDbContext(DbContextOptions<CheeseDbContext> options) 
            : base(options)
        { }

    }
}
