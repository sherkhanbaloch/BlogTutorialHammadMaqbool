using BlogTutorialHammadMaqbool.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogTutorialHammadMaqbool.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Post> Tbl_Post { get; set; }
        public DbSet<Profile> Tbl_Profile { get; set; }
    }
}
