namespace MoodPlaylist.SQLite.Repository.Models
{
    public class Playlist   // <-- gawin public
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Mood { get; set; }    

        public string? Description { get; set; }

        public string? CoverUrl { get; set; } = "";  // default empty string
        public List<Song> Songs { get; set; } = new List<Song>();
    }
}

