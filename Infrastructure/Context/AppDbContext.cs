using System.Linq.Expressions;
using Domain.Common;
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
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;

public class AppDbContext : IdentityDbContext<User, Role, int>
{
    public AppDbContext() { }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { }

    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        ApplyAuditInfo();
        return base.SaveChanges(acceptAllChangesOnSuccess);
    }

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
        ApplyAuditInfo();
        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        ApplySoftDeleteFilters(modelBuilder);

        modelBuilder.Entity<User>()
            .HasIndex(u => u.NormalizedUserName)
            .HasDatabaseName("UserNameIndex")
            .IsUnique()
            .HasFilter("[IsDeleted] = 0");

        modelBuilder.Entity<User>()
            .HasIndex(u => u.NormalizedEmail)
            .HasDatabaseName("EmailIndex")
            .IsUnique()
            .HasFilter("[IsDeleted] = 0");

        ConfigureCatalog(modelBuilder);
        ConfigureComputer(modelBuilder);
        ConfigureLinkTables(modelBuilder);
    }

    private static void ApplySoftDeleteFilters(ModelBuilder modelBuilder)
    {
        var auditableTypes = modelBuilder.Model.GetEntityTypes()
            .Where(t => t.BaseType == null && typeof(IAuditable).IsAssignableFrom(t.ClrType))
            .Select(t => t.ClrType)
            .ToList();

        foreach (var clrType in auditableTypes)
        {
            modelBuilder.Entity(clrType).HasQueryFilter(BuildNotDeletedFilter(clrType));
        }
    }

    private static LambdaExpression BuildNotDeletedFilter(Type clrType)
    {
        var entity = Expression.Parameter(clrType, "e");
        var isDeleted = Expression.Property(entity, nameof(IAuditable.IsDeleted));
        return Expression.Lambda(Expression.Not(isDeleted), entity);
    }

    private static void ConfigureCatalog(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Series>()
            .HasOne(s => s.Brand)
            .WithMany()
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<SocketCPU>()
            .HasOne(s => s.Brand)
            .WithMany()
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Case>()
            .HasOne(c => c.Series)
            .WithMany()
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<CPU>()
            .HasOne(c => c.Series)
            .WithMany()
            .HasForeignKey(c => c.SeriesId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<CPU>()
            .HasOne(c => c.SocketCPU)
            .WithMany()
            .HasForeignKey(c => c.SocketCpuId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<GPU>()
            .HasOne(g => g.Series)
            .WithMany()
            .HasForeignKey(g => g.SeriesId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<GPU>()
            .HasOne(g => g.ChipsetSeries)
            .WithMany()
            .HasForeignKey(g => g.ChipsetSeriesId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Motherboard>()
            .HasOne(m => m.Series)
            .WithMany()
            .HasForeignKey(m => m.SeriesId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Motherboard>()
            .HasOne(m => m.SocketCPU)
            .WithMany()
            .HasForeignKey(m => m.SocketCpuId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<PowerSupply>()
            .HasOne(p => p.Series)
            .WithMany()
            .HasForeignKey(p => p.SeriesId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<RamMemories>()
            .HasOne(r => r.series)
            .WithMany()
            .HasForeignKey(r => r.SeriesId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<RamMemories>()
            .HasOne(r => r.MemorySpeed)
            .WithMany()
            .HasForeignKey(r => r.MemorySpeedId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Hdd>()
            .HasOne(h => h.Series)
            .WithMany()
            .HasForeignKey(h => h.SeriesId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Hdd>()
            .HasOne(h => h.Slot)
            .WithMany()
            .HasForeignKey(h => h.SlotInterfaceId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Ssd>()
            .HasOne(s => s.Series)
            .WithMany()
            .HasForeignKey(s => s.SeriesId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Ssd>()
            .HasOne(s => s.Slot)
            .WithMany()
            .HasForeignKey(s => s.SlotInterfaceId)
            .OnDelete(DeleteBehavior.NoAction);
    }

    private static void ConfigureComputer(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Computer>().Ignore(c => c.Drives);
        modelBuilder.Entity<Computer>().Ignore(c => c.Ssds);

        modelBuilder.Entity<Computer>()
            .HasOne(c => c.Case)
            .WithMany()
            .HasForeignKey(c => c.CaseId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Computer>()
            .HasOne(c => c.Gpu)
            .WithMany()
            .HasForeignKey(c => c.GpuId)
            .IsRequired(false)
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
    }

    // Link tables have no IsDeleted; filtering them by their owner keeps them consistent with the
    // soft-delete filters of the entities they point to (otherwise EF warns about required navigations).
    private static void ConfigureLinkTables(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ComputerHdds>(b =>
        {
            b.HasQueryFilter(x => !x.Computer!.IsDeleted);
            b.HasIndex(x => new { x.ComputerId, x.HddId }).IsUnique();
            b.HasOne(x => x.Computer).WithMany().HasForeignKey(x => x.ComputerId).OnDelete(DeleteBehavior.Cascade);
            b.HasOne(x => x.Hdd).WithMany().HasForeignKey(x => x.HddId).OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<ComputerSsds>(b =>
        {
            b.HasQueryFilter(x => !x.Computer!.IsDeleted);
            b.HasIndex(x => new { x.ComputerId, x.SsdId }).IsUnique();
            b.HasOne(x => x.Computer).WithMany().HasForeignKey(x => x.ComputerId).OnDelete(DeleteBehavior.Cascade);
            b.HasOne(x => x.Ssd).WithMany().HasForeignKey(x => x.SsdId).OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<MotheboardMemory>(b =>
        {
            b.HasQueryFilter(x => !x.Motherboard!.IsDeleted);
            b.HasIndex(x => new { x.MotherBoardId, x.MemoryId }).IsUnique();
            b.HasOne(x => x.Motherboard).WithMany(m => m.Memories).HasForeignKey(x => x.MotherBoardId).OnDelete(DeleteBehavior.Cascade);
            b.HasOne(x => x.Memory).WithMany().HasForeignKey(x => x.MemoryId).OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<SlotsGPU>(b =>
        {
            b.HasQueryFilter(x => !x.Gpu!.IsDeleted);
            b.HasIndex(x => new { x.SlotId, x.GpuId }).IsUnique();
            b.HasOne(x => x.Gpu).WithMany().HasForeignKey(x => x.GpuId).OnDelete(DeleteBehavior.Cascade);
            b.HasOne(x => x.Slot).WithMany().HasForeignKey(x => x.SlotId).OnDelete(DeleteBehavior.NoAction);
        });
    }

    private void ApplyAuditInfo()
    {
        var now = DateTime.UtcNow;
        var entries = ChangeTracker.Entries<IAuditable>().ToList();

        foreach (var entry in entries)
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.Created = now;
                entry.Entity.LastModified = null;
                entry.Entity.IsDeleted = false;
            }
            else if (entry.State == EntityState.Modified)
            {
                entry.Property(e => e.Created).IsModified = false;
                entry.Entity.LastModified = now;
            }
        }
    }

    public DbSet<Brand> Brands { get; set; }
    public DbSet<Series> Series { get; set; }
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
