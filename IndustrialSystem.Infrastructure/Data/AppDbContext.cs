using IndustrialSystem.Core;
using Microsoft.EntityFrameworkCore;

namespace IndustrialSystem.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<WorkOrder> WorkOrders { get; set; }
}