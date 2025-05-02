using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using pc2_progra.Models;
using System.Collections.Generic;

namespace pc2_progra.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Pets> Pets { get; set; }
    public DbSet<Adopters> Adopters { get; set; }
    public DbSet<Adoptions> Adoptions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Pets>()
            .HasOne(p => p.Adoption)
            .WithOne(a => a.Pet)
            .HasForeignKey<Adoptions>(a => a.PetId);
    }
}
