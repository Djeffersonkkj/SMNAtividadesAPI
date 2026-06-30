using Filminho.Models;
using Microsoft.EntityFrameworkCore;

namespace Filminho.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Filme> Filme { get; set; }

    override protected void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Filme>(entity =>
        {
            entity.HasKey(e => e.Title);
            entity.Property(e => e.Title).IsRequired();
            entity.Property(e => e.Year).IsRequired();
            entity.Property(e => e.Released).IsRequired();
            entity.Property(e => e.Runtime).IsRequired();
            entity.Property(e => e.Genre).IsRequired();
            entity.Property(e => e.Director).IsRequired();
            entity.Property(e => e.Writer).IsRequired();
            entity.Property(e => e.Country).IsRequired();
            entity.Property(e => e.imdbRating).IsRequired();
        });
    }
}
