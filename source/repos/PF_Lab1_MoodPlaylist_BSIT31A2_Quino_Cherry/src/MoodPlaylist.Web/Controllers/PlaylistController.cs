using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoodPlaylist.SQLite.Repository;
using MoodPlaylist.SQLite.Repository.Models;
using System.Linq;

namespace MoodPlaylist.Web.Controllers
{
    public class PlaylistController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PlaylistController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Show all playlists
        public IActionResult Index()
        {
            var playlists = _context.Playlists.ToList();
            foreach (var p in playlists)
            {
                p.Songs = _context.Songs.Where(s => s.PlaylistId == p.Id).ToList();
            }
            return View(playlists);
        }

        // Create playlist
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Playlist playlist)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }

            _context.Playlists.Add(playlist);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // Playlist details
        public IActionResult Details(int id)
        {
            var playlist = _context.Playlists
                                   .Include(p => p.Songs)
                                   .FirstOrDefault(p => p.Id == id);

            if (playlist == null) return NotFound();
            return View(playlist);
        }

        // Add song to playlist
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddSong(AddSongViewModel vm)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Details", new { id = vm.PlaylistId });

            var song = new Song
            {
                PlaylistId = vm.PlaylistId,
                Title = vm.Title,
                Url = vm.Url
            };

            _context.Songs.Add(song);
            _context.SaveChanges();
            return RedirectToAction("Details", new { id = vm.PlaylistId });
        }

        // ------------------ DELETE ACTIONS ------------------

        // Delete entire playlist + its songs
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePlaylist(int id)
        {
            var playlist = _context.Playlists
                                   .Include(p => p.Songs)
                                   .FirstOrDefault(p => p.Id == id);
            if (playlist == null) return NotFound();

            _context.Songs.RemoveRange(playlist.Songs);
            _context.Playlists.Remove(playlist);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        // Delete individual song
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteSong(int id)
        {
            var song = _context.Songs.FirstOrDefault(s => s.Id == id);
            if (song == null) return NotFound();

            int playlistId = song.PlaylistId;
            _context.Songs.Remove(song);
            _context.SaveChanges();

            return RedirectToAction("Details", new { id = playlistId });
        }

        // ------------------ VIEW MODELS ------------------
        public class AddSongViewModel
        {
            public int PlaylistId { get; set; }
            public string Title { get; set; }
            public string Url { get; set; }
        }
    }
}
