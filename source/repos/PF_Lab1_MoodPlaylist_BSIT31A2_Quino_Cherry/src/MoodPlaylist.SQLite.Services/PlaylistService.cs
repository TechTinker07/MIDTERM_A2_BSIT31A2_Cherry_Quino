using MoodPlaylist.SQLite.Repository;
using MoodPlaylist.SQLite.Repository.Models;

namespace MoodPlaylist.SQLite.Services
{
    public class PlaylistService   // <-- siguraduhin public
    {
        private readonly ApplicationDbContext _context;

        public PlaylistService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Playlist> GetAllPlaylists()
        {
            return _context.Playlists.ToList();
        }

        public void AddPlaylist(Playlist playlist)
        {
            _context.Playlists.Add(playlist);
            _context.SaveChanges();
        }
    }
}
