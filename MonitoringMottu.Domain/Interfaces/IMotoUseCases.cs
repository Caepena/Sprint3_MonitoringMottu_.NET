using MonitoringMottu.Domain.Entities;
using MonitoringMottu.Domain.Pagination;

namespace MonitoringMottu.Domain.Interfaces;

public interface IMotoUseCases
{
    Task<PageResult<Moto>> GetPaginationAsync(int page, int pageSize);
}