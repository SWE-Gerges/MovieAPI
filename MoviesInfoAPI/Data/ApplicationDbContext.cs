using MoviesInfoAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MoviesInfoAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
            
        }

        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Movie> Movies { get; set; }
    }
}
