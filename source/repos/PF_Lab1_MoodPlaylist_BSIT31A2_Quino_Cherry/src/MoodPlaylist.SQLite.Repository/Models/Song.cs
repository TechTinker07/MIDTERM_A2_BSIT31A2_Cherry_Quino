namespace MoodPlaylist.SQLite.Repository.Models
{
    public class Song
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Url { get; set; } = "";   // <-- string, hindi int
        public int PlaylistId { get; set; }
        public Playlist Playlist { get; set; } = null!;
    }

}