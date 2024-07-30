using Microsoft.EntityFrameworkCore;
using BookStore.Data.Configuration;
using BookStore.Data.Domain;

namespace BookStore.Data.Context;

public class BookDbContext : DbContext
{
    public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<Book> Books { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new BookConfiguration());
    }
}