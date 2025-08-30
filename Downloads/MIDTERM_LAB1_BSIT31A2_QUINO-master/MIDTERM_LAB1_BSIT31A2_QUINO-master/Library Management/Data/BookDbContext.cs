using System;
using System.Collections.Generic;
using Library_Management.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace Library_Management.Data;

public partial class BookDbContext : DbContext
{
    public BookDbContext()
    {
    }

    public BookDbContext(DbContextOptions<BookDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<BookCopy> BookCopies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Librarydb;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Author");

            entity.Property(e => e.Biography)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.BirthDate).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ProfileImageUrl)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Book");

            entity.Property(e => e.Description).HasMaxLength(50);
            entity.Property(e => e.Genre).HasMaxLength(50);
            entity.Property(e => e.Isbn)
                .HasMaxLength(50)
                .HasColumnName("ISBN");
            entity.Property(e => e.PublishedDate).HasColumnType("datetime");
            entity.Property(e => e.Title).HasMaxLength(50);
        });

        modelBuilder.Entity<BookCopy>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("BookCopy");

            entity.Property(e => e.AddedDate).HasColumnType("datetime");
            entity.Property(e => e.Condition).HasMaxLength(50);
            entity.Property(e => e.CoverImageUrl).HasMaxLength(50);
            entity.Property(e => e.PulloutDate).HasColumnType("datetime");
            entity.Property(e => e.PulloutReason).HasMaxLength(50);
            entity.Property(e => e.Source).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
