using Combine_Day_Twenty_N_tier_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Combine_Day_Twenty_N_tier_API.Data
{
    // The DbContext is the connection to the database
    public class AppDbContext : DbContext
    {
        
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        //Here we set our tables.
        //Each DbSet is one table.

        public DbSet<Supply> Supplies {get; set;}
    }
}