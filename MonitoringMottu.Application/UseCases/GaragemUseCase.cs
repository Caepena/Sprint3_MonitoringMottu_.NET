using MonitoringMottu.Domain.Entities;
using MonitoringMottu.Domain.Interfaces;
using MonitoringMottu.Domain.Pagination;

namespace MonitoringMottu.Application.UseCases;

public class GaragemUseCase
{
    private readonly IGaragemRepository _repository;
    
    public GaragemUseCase(IGaragemRepository repository) => _repository = repository;

    public Task<PageResult<Garagem>> GetPaginationAsync(int page, int pageSize) =>
        _repository.GetPaginationAsyncGaragem(page, pageSize);
}