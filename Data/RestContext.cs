using Microsoft.EntityFrameworkCore;
using RestASPNET.Api.Model;

namespace RestASPNET.Api.Data;

public class RestContext : DbContext
{
    public RestContext (DbContextOptions<RestContext> options)
        : base(options)
    {
    }

    public DbSet<Person> People { get; set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>(entity =>
        {
            entity.ToTable("person", "dbo");
            entity.HasKey(p => p.Id);

            entity.Property(p => p.FirstName)
                .HasColumnName("first_name")
                .HasColumnType("varchar(80)")
                .IsRequired();

            entity.Property(p => p.LastName)
                .HasColumnName("last_name")
                .HasColumnType("varchar(80)")
                .IsRequired();

            entity.Property(p => p.Address)
                .HasColumnName("address")
                .HasColumnType("varchar(100)")
                .IsRequired();

            entity.Property(p => p.Gender)
                .HasColumnName("gender")
                .HasColumnType("varchar(6)")
                .IsRequired();
        });
    }
}