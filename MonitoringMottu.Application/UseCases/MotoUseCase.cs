using MonitoringMottu.Domain.Entities;
using MonitoringMottu.Domain.Interfaces;
using MonitoringMottu.Domain.Pagination;

namespace MonitoringMottu.Application.UseCases;

public class MotoUseCase : IMotoUseCases
{
    private readonly IMotoRepository _repository;
    
    public MotoUseCase(IMotoRepository repository) => _repository = repository;

    public Task<PageResult<Moto>> GetPaginationAsync(int page, int pageSize) =>
        _repository.GetPaginationAsyncMoto(page, pageSize);
}