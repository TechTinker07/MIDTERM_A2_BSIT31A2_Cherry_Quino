using Microsoft.EntityFrameworkCore;
using MoodPlaylist.SQLite.Repository.Models;

namespace MoodPlaylist.SQLite.Repository
{
    public class PlaylistDbContext : DbContext
    {
        public PlaylistDbContext(DbContextOptions<PlaylistDbContext> options) : base(options)
        {
        }

        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<Song> Songs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Playlist>()
                .HasMany(p => p.Songs)
                .WithOne()
                .HasForeignKey(s => s.PlaylistId);
        }
    }
}
