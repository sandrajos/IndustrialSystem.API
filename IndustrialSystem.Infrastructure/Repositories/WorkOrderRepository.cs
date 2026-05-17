using IndustrialSystem.Core;
using IndustrialSystem.Infrastructure.Data;

namespace IndustrialSystem.Infrastructure.Repositories;

public class WorkOrderRepository : Repository<WorkOrder>, IWorkOrderRepository
{
    public WorkOrderRepository(AppDbContext context) : base(context)
    {
    }
}
