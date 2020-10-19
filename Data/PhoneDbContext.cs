using Microsoft.EntityFrameworkCore;
using PhoneDataWarehouse.Data.Models;

namespace PhoneDataWarehouse.Data
{
    public class PhoneDbContext : DbContext
    {
        public DbSet<Phone> Phones { get; set; }
        public PhoneDbContext(DbContextOptions<PhoneDbContext> options) 
            : base(options)
        {
            
        }
    }
}