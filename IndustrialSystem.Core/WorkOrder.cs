namespace IndustrialSystem.Core;

public class WorkOrder
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;

    // 👇 Add this property — it fixes the redline
    public string Description { get; set; } = string.Empty;

    public string Status { get; set; } = "New";
    public int Progress { get; set; }

    // 👇 Optional but recommended for consistency with DTOs
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
