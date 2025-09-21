using Microsoft.EntityFrameworkCore;
using MoodPlaylist.SQLite.Repository.Models;

namespace MoodPlaylist.SQLite.Repository
{
    public class ApplicationDbContext : DbContext   // <-- gawin public
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<Song> Songs { get; set; }
    }
}
