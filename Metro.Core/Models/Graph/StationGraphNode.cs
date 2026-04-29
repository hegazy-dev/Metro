namespace Metro.Core.Models.Graph;

public class StationGraphNode
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int LineId { get; set; }
}