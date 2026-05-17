using IndustrialSystem.API.DTOs;
using IndustrialSystem.Core;
using IndustrialSystem.Infrastructure.Repositories;

namespace IndustrialSystem.API.Services
{
    public class WorkOrderService : IWorkOrderService
    {
        private readonly IWorkOrderRepository _repo;

        public WorkOrderService(IWorkOrderRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<WorkOrderDto>> GetAllAsync()
        {
            var items = await _repo.GetAllAsync();

            return items.Select(w => new WorkOrderDto
            {
                Id = w.Id,
                Title = w.Title,
                Description = w.Description,
                Status = w.Status,
                Progress = w.Progress,
                CreatedAt = w.CreatedAt
            });
        }

        public async Task<WorkOrderDto?> GetByIdAsync(int id)
        {
            var w = await _repo.GetByIdAsync(id);
            if (w == null)
                return null;

            return new WorkOrderDto
            {
                Id = w.Id,
                Title = w.Title,
                Description = w.Description,
                Status = w.Status,
                Progress = w.Progress,
                CreatedAt = w.CreatedAt
            };
        }

        public async Task<WorkOrderDto> CreateAsync(CreateWorkOrderDto dto)
        {
            var w = new WorkOrder
            {
                Title = dto.Title,
                Description = dto.Description,
                Status = "New",
                Progress = 0,
                CreatedAt = DateTime.UtcNow
            };

            await _repo.AddAsync(w);
            await _repo.SaveChangesAsync();

            return new WorkOrderDto
            {
                Id = w.Id,
                Title = w.Title,
                Description = w.Description,
                Status = w.Status,
                Progress = w.Progress,
                CreatedAt = w.CreatedAt
            };
        }

        public async Task<bool> UpdateAsync(int id, UpdateWorkOrderDto dto)
        {
            var w = await _repo.GetByIdAsync(id);
            if (w == null)
                return false;

            w.Title = dto.Title;
            w.Description = dto.Description;
            w.Status = dto.Status;
            w.Progress = dto.Progress;

            await _repo.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var w = await _repo.GetByIdAsync(id);
            if (w == null)
                return false;

            _repo.Remove(w);
            await _repo.SaveChangesAsync();
            return true;
        }
    }
}
