using App.Models;
using Microsoft.EntityFrameworkCore;

namespace App.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; }  
    public DbSet<Book> Books { get; set; }  

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>()
            .HasMany(e => e.Books)
            .WithOne(e => e.Category)
            .HasForeignKey(e => e.CategoryId);

        modelBuilder.Entity<Book>();
    }
}
