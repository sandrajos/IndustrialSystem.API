using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IndustrialSystem.API.Controllers;
using IndustrialSystem.API.DTOs;
using IndustrialSystem.API.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace IndustrialSystem.Tests;

public class WorkOrdersControllerTests
{
    [Fact]
    public async Task GetAll_ReturnsOkWithWorkOrders()
    {
        var mockService = new Mock<IWorkOrderService>();

        var workOrders = new List<WorkOrderDto>
        {
            new()
            {
                Id = 1,
                Title = "Maintenance",
                Description = "Routine machine maintenance",
                Progress = 50,
                Status = "In Progress",
                CreatedAt = DateTime.UtcNow
            }
        };

        mockService
            .Setup(service => service.GetAllAsync())
            .ReturnsAsync(workOrders);

        var controller = new WorkOrdersController(mockService.Object);

        var result = await controller.GetAll();

        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnedItems = Assert.IsAssignableFrom<IEnumerable<WorkOrderDto>>(okResult.Value);

        Assert.Single(returnedItems);
    }

    [Fact]
    public async Task GetById_ReturnsNotFound_WhenWorkOrderDoesNotExist()
    {
        var mockService = new Mock<IWorkOrderService>();

        mockService
            .Setup(service => service.GetByIdAsync(999))
            .ReturnsAsync((WorkOrderDto?)null);

        var controller = new WorkOrdersController(mockService.Object);

        var result = await controller.GetById(999);

        Assert.IsType<NotFoundResult>(result.Result);
    }

    [Fact]
    public async Task Create_ReturnsCreatedAtAction()
    {
        var mockService = new Mock<IWorkOrderService>();

        var input = new CreateWorkOrderDto
        {
            Title = "New Work Order",
            Description = "Test work order"
        };

        var created = new WorkOrderDto
        {
            Id = 1,
            Title = input.Title,
            Description = input.Description,
            Progress = 0,
            Status = "New",
            CreatedAt = DateTime.UtcNow
        };

        mockService
            .Setup(service => service.CreateAsync(input))
            .ReturnsAsync(created);

        var controller = new WorkOrdersController(mockService.Object);

        var result = await controller.Create(input);

        var createdResult = Assert.IsType<CreatedAtActionResult>(result.Result);

        Assert.Equal(nameof(WorkOrdersController.GetById), createdResult.ActionName);
        Assert.Equal(1, createdResult.RouteValues!["id"]);
    }

    [Fact]
    public async Task Update_ReturnsNoContent_WhenUpdateSucceeds()
    {
        var mockService = new Mock<IWorkOrderService>();

        var input = new UpdateWorkOrderDto
        {
            Title = "Updated Work Order",
            Description = "Updated description",
            Progress = 75,
            Status = "In Progress"
        };

        mockService
            .Setup(service => service.UpdateAsync(1, input))
            .ReturnsAsync(true);

        var controller = new WorkOrdersController(mockService.Object);

        var result = await controller.Update(1, input);

        Assert.IsType<NoContentResult>(result);
    }
}
