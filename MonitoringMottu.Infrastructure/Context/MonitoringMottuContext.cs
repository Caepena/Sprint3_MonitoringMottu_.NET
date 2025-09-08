using CP2.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;
using MonitoringMottu.Domain.Entities;

namespace MonitoringMottu.Infrastructure.Context;

public class MonitoringMottuContext : DbContext
{
    public MonitoringMottuContext(DbContextOptions<MonitoringMottuContext> options) : base(options)
    {
    }
    
    public DbSet<Moto> Motos { get; set; }
    public DbSet<Garagem> Garagens  { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new MotoMapping());
        modelBuilder.ApplyConfiguration(new GaragemMapping());
        
        base.OnModelCreating(modelBuilder);
    }
}