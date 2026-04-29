namespace Metro.Core.Entities;

public class Line
{
    public int Id { get; private set; }

    public string Name { get; private set; }

    public string Color { get; private set; }

    public ICollection<Station> Stations { get; private set; }
        = new List<Station>();

    private Line() { } // EF

    public Line(int id, string name, string color)
    {
        Id = id;
        Name = name;
        Color = color;
    }

}