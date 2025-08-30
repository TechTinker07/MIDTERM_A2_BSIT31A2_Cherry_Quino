namespace Library_Management.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public string AuthorName { get; set; }
        public int TotalCopies { get; set; }
        public int AvailableCopies { get; set; }
        public bool IsArchived { get; set; }
        public DateTime? PublishedDate { get; set; } = default!;
    }

}
