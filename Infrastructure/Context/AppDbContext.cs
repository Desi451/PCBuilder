using Domain.Entities;
using Domain.Entities.Components;
using Domain.Entities.Components.Case;
using Domain.Entities.Components.CPU;
using Domain.Entities.Components.Drives;
using Domain.Entities.Components.GPU;
using Domain.Entities.Components.Motherboard;
using Domain.Entities.Components.RamMemory;
using Domain.Entities.Computer;
using Domain.Entities.Slots;
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
            .HasOne(b => b.Series)
            .WithMany()
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Series>()
            .HasOne(b => b.Brand)
            .WithMany()
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<SocketCPU>()
            .HasOne(b => b.Brand)
            .WithMany()
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<GPU>()
            .HasOne(d => d.Series);

        modelBuilder.Entity<GPU>()
            .HasOne(c => c.ChipsetSeries)
            .WithMany()
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Computer>()
            .HasOne(c => c.Case)
            .WithMany()
            .HasForeignKey(c => c.CaseId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Computer>()
            .HasOne(c => c.Gpu)
            .WithMany()
            .HasForeignKey(c => c.GpuId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Computer>()
            .HasOne(c => c.Mobo)
            .WithMany()
            .HasForeignKey(c => c.MotherboardId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Computer>()
            .HasOne(c => c.RamMemory)
            .WithMany()
            .HasForeignKey(c => c.RamMemoryId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Computer>()
            .HasOne(c => c.Psu)
            .WithMany()
            .HasForeignKey(c => c.PsuId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Computer>()
            .HasOne(c => c.Cpu)
            .WithMany()
            .HasForeignKey(c => c.CpuId)
            .OnDelete(DeleteBehavior.NoAction);

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
    public DbSet<RamMemories> RAMs {  get; set; }
    public DbSet <RamSpeed> RamSpeeds { get; set; }
    public DbSet <CPU> CPUs { get; set; }
    public DbSet <SocketCPU> SocketCPUs { get; set; }
    public DbSet <PowerSupply> PSUs { get; set; }
    public DbSet <SlotInterface> SlotInterfaces { get; set; }
    public DbSet<SlotsGPU> SlotGpus { get; set; }
    public DbSet <GPU> GPUs { get; set; }
    public DbSet <Motherboard> Motherboards { get; set; }
    public DbSet <MotheboardMemory> MotherboardMemories { get; set; }
    public DbSet <Hdd> Hdds { get; set; }
    public DbSet <Ssd> Ssds { get; set; }


    public DbSet <Computer> Computers { get; set; }
    public DbSet <ComputerHdds> ComputerHdds { get; set; }
    public DbSet <ComputerSsds> ComputerSsds { get; set; }
}
