using Microsoft.EntityFrameworkCore;
using MonitoringMottu.Domain.Entities;
using MonitoringMottu.Domain.Interfaces;
using MonitoringMottu.Domain.Pagination;
using MonitoringMottu.Infrastructure.Context;

namespace MonitoringMottu.Infrastructure.Repositories;

public class MotoRepository : IMotoRepository
{
    private readonly MonitoringMottuContext  _context;
    public MotoRepository(MonitoringMottuContext context) => _context = context;

    public async Task<PageResult<Moto>> GetPaginationAsyncMoto(int page, int pageSize, CancellationToken cancellationToken = default)
    {
        if (page <= 0) page = 1;
        if (pageSize <= 0) pageSize = 10;

        var query = _context.Motos
            .AsNoTracking()
            .OrderByDescending(n => n.StatusMoto);

        var total = await query.CountAsync(cancellationToken);
        
        var items = await query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);
        return new PageResult<Moto>()
        {
            Items = items,
            Total = total,
            Page = page,
            PageSize = pageSize
        };
    }
}