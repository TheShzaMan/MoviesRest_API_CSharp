using Microsoft.EntityFrameworkCore;
using MoviesRestWebAPI.Models;

namespace MoviesRestWebAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public ApplicationDbContext(DbContextOptions options) 
            : base(options)
        {
            
        }
    }
}
