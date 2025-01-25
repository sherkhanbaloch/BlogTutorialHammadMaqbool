using Microsoft.EntityFrameworkCore;

namespace BlogTutorialHammadMaqbool.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
    }
}
