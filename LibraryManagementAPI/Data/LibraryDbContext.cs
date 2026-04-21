using LibraryManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementAPI.Data
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<BookIssue> BookIssues { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // User
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            // Book -> Author relationship
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Author)
                .WithMany()
                .HasForeignKey(b => b.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            // BookIssue -> Book relationship
            modelBuilder.Entity<BookIssue>()
                .HasOne(bi => bi.Book)
                .WithMany()
                .HasForeignKey(bi => bi.BookId)
                .OnDelete(DeleteBehavior.Restrict);

            // BookIssue -> Student relationship
            modelBuilder.Entity<BookIssue>()
                .HasOne(bi => bi.Student)
                .WithMany()
                .HasForeignKey(bi => bi.StudentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}