using Microsoft.EntityFrameworkCore;
using CarInventory.Models;
using CarInventory.Models;

namespace CarInventory.Models
{
    public class CarsContext : DbContext
    {
        public CarsContext(DbContextOptions<CarsContext> options):base(options)
        {

        }

        public DbSet<Car> cars { get; set; }
    }
}
