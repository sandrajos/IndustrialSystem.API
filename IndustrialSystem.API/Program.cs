using FluentValidation;
using FluentValidation.AspNetCore;
using IndustrialSystem.API.Validators;
using IndustrialSystem.API.Services;  
using IndustrialSystem.Infrastructure.Data;
using IndustrialSystem.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ----------------------------
// Controllers
// ----------------------------
builder.Services.AddControllers();

// ----------------------------
// FluentValidation
// ----------------------------
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<CreateWorkOrderValidator>();

// ----------------------------
// Repository + Service Layer
// ----------------------------
builder.Services.AddScoped<IWorkOrderRepository, WorkOrderRepository>();
builder.Services.AddScoped<IWorkOrderService, WorkOrderService>();

// ----------------------------
// Database (SQL Server + Migrations Assembly)
// ----------------------------
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        sql => sql.MigrationsAssembly("IndustrialSystem.Infrastructure")
    )
);

// ----------------------------
// Swagger
// ----------------------------
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// ----------------------------
// Middleware
// ----------------------------
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
