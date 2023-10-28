using Domain.Entities;
using Domain.Entities.Components.Case;
using Domain.Entities.Components.CPU;
using Domain.Entities.Components.RamMemory;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;

public class AppDbContext : DbContext
{
    public AppDbContext() { }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasOne(u => u.Rank);

        modelBuilder.Entity<Case>()
            .HasOne(b => b.Brand);
        modelBuilder.Entity<Case>()
            .HasOne(b => b.Series);

        base.OnModelCreating(modelBuilder);            
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial " +
            "Catalog=PCBuilder;Integrated " +
            "Security=True;MultipleActiveResultSets=True;TrustServerCertificate=True");
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Series> Series { get; set; }
    public DbSet<Rank> Ranks { get; set; }
    public DbSet<Case> Cases { get; set; }
    public DbSet<RamMemory> RAMs {  get; set; }
    public DbSet <MemorySpeed> MemorySpeeds { get; set; }
    public DbSet <CPU> CPUs { get; set; }
    public DbSet <SocketCPU> SocketCPUs { get; set; }
}
