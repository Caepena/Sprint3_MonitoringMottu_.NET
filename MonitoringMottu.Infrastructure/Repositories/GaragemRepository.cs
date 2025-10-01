using Microsoft.EntityFrameworkCore;
using MonitoringMottu.Domain.Entities;
using MonitoringMottu.Domain.Interfaces;
using MonitoringMottu.Domain.Pagination;
using MonitoringMottu.Infrastructure.Context;

namespace MonitoringMottu.Infrastructure.Repositories;

public class GaragemRepository : IGaragemRepository
{
    private readonly MonitoringMottuContext  _context;
    public GaragemRepository(MonitoringMottuContext context) => _context = context;

    public async Task<PageResult<Garagem>> GetPaginationAsyncGaragem(int page, int pageSize, CancellationToken cancellationToken = default)
    {
        if (page <= 0) page = 1;
        if (pageSize <= 0) pageSize = 10;

        var query = _context.Garagens
            .AsNoTracking()
            .OrderByDescending(n => n.Endereco);

        var total = await query.CountAsync(cancellationToken);
        
        var items = await query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);
        return new PageResult<Garagem>()
        {
            Items = items,
            Total = total,
            Page = page,
            PageSize = pageSize
        };
    }
}