using MonitoringMottu.Domain.Entities;
using MonitoringMottu.Domain.Pagination;

namespace MonitoringMottu.Domain.Interfaces;

public interface IGaragemUseCases
{
    Task<PageResult<Garagem>> GetPaginationAsync(int page, int pageSize);
}