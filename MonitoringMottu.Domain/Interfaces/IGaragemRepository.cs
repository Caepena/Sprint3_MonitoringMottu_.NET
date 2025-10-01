using MonitoringMottu.Domain.Entities;
using MonitoringMottu.Domain.Pagination;

namespace MonitoringMottu.Domain.Interfaces;

public interface IGaragemRepository
{
    Task<PageResult<Garagem>>
        GetPaginationAsyncGaragem(int page, int pageSize, CancellationToken cancellationToken = default);
}