using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MonitoringMottu.Infrastructure.Context;

public class MonitoringMottuContextFactory : IDesignTimeDbContextFactory<MonitoringMottuContext>
{
    public MonitoringMottuContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<MonitoringMottuContext>();

        optionsBuilder.UseOracle("User ID=rm557984;Password=191101;Data Source=oracle.fiap.com.br:1521/orcl;");
        
        return new MonitoringMottuContext(optionsBuilder.Options);
    }
}