using IndustrialSystem.API.DTOs;

namespace IndustrialSystem.API.Services
{
    public interface IWorkOrderService
    {
        Task<IEnumerable<WorkOrderDto>> GetAllAsync();
        Task<WorkOrderDto?> GetByIdAsync(int id);
        Task<WorkOrderDto> CreateAsync(CreateWorkOrderDto dto);
        Task<bool> UpdateAsync(int id, UpdateWorkOrderDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
