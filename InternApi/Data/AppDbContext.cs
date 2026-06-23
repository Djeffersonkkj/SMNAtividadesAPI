using InternApi.Models;
using Microsoft.EntityFrameworkCore;


namespace InternApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Endereco> Endereco { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Endereco>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Cep).IsRequired();
            entity.Property(e => e.Uf).IsRequired().HasMaxLength(150);
            entity.Property(e => e.Bairro).IsRequired().HasMaxLength(150);
            entity.Property(e => e.Logradouro).IsRequired().HasMaxLength(150);
            entity.Property(e => e.Localidade).IsRequired().HasMaxLength(150);
            entity.Property(e => e.SalvoEmCache).IsRequired().HasDefaultValue(true);
        });
    }
    
}
