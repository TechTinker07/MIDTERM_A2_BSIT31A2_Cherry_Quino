using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MoodPlaylist.SQLite.Repository
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

            // same connection string as in Web project (adjust if needed)
            optionsBuilder.UseSqlite("Data Source=playlist.db");

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
