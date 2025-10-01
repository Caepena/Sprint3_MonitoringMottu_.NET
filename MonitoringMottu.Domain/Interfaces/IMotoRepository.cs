using MonitoringMottu.Domain.Entities;
using MonitoringMottu.Domain.Pagination;

namespace MonitoringMottu.Domain.Interfaces;

public interface IMotoRepository
{
    Task<PageResult<Moto>>
        GetPaginationAsyncMoto(int page, int pageSize, CancellationToken cancellationToken = default);
}