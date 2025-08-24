using Library_Management_Domain.Entities;
using System;
using System.Collections.Generic;

namespace Library_Management.Models
{
    public class Author
    {
        public Guid AuthorId { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public string? Biography { get; set; }
        public DateTime? Birthdate { get; set; }
        public string? ProfileImageUrl { get; set; }
        public bool IsArchived { get; set; } = false;

        // dynamic books (we will populate this from BookService)
        public List<Book> Books { get; set; } = new List<Book>();
    }
}
