namespace IndustrialSystem.API.DTOs;

public class UpdateWorkOrderDto
{
    public string Title { get; set; } = "";
    public string Description { get; set; } = "";
    public int Progress { get; set; }          
    public string Status { get; set; } = "";
}
