using Library_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Library_Management.Services
{
    public class AuthorService
    {
        // Singleton pattern
        private static AuthorService _instance;
        public static AuthorService Instance => _instance ??= new AuthorService();

        private List<Author> authors = new List<Author>();

        private AuthorService()
        {
            SeedData(); // optional: default authors for testing
        }

        // Sample seed data
        private void SeedData()
        {
            authors.Add(new Author
            {
                AuthorId = Guid.NewGuid(),
                Name = "George Orwell",
                Biography = "English novelist, essayist, journalist and critic.",
                Birthdate = new DateTime(1903, 6, 25),
                ProfileImageUrl = "https://example.com/orwell.jpg",
                IsArchived = false
            });

            authors.Add(new Author
            {
                AuthorId = Guid.NewGuid(),
                Name = "J.K. Rowling",
                Biography = "British author, best known for the Harry Potter series.",
                Birthdate = new DateTime(1965, 7, 31),
                ProfileImageUrl = "https://example.com/rowling.jpg",
                IsArchived = false
            });
        }

        // Get all authors, optionally including archived
        public List<Author> GetAuthors(bool includeArchived = false)
        {
            return includeArchived ? authors : authors.Where(a => !a.IsArchived).ToList();
        }

        // Get author by Id
        public Author? GetAuthorById(Guid id)
        {
            return authors.FirstOrDefault(a => a.AuthorId == id);
        }

        // Add new author
        public void AddAuthor(Author author)
        {
            if (author == null) throw new ArgumentNullException(nameof(author));

            author.AuthorId = Guid.NewGuid(); // ensure new Id
            author.IsArchived = false;        // default active
            authors.Add(author);
        }

        // Update existing author
        public void UpdateAuthor(Author updated)
        {
            if (updated == null) throw new ArgumentNullException(nameof(updated));

            var existing = GetAuthorById(updated.AuthorId);
            if (existing != null)
            {
                existing.Name = updated.Name;
                existing.Biography = updated.Biography;
                existing.Birthdate = updated.Birthdate;
                existing.ProfileImageUrl = updated.ProfileImageUrl;
            }
        }

        // Delete author permanently
        public void DeleteAuthor(Guid id)
        {
            var author = GetAuthorById(id);
            if (author != null)
            {
                authors.Remove(author);
            }
        }

        // Archive author (soft delete)
        public void ArchiveAuthor(Guid id)
        {
            var author = GetAuthorById(id);
            if (author != null)
            {
                author.IsArchived = true;
            }
        }

        // Restore archived author
        public void RestoreAuthor(Guid id)
        {
            var author = GetAuthorById(id);
            if (author != null)
            {
                author.IsArchived = false;
            }
        }
    }
}
