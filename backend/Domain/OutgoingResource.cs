namespace Domain;

public class OutgoingResource : EntityBase
{
    public Resource Resource { get; set; } = null!;

    public Measure Measure { get; set; } = null!;

    public int Amount { get; set; }

    public IEnumerable<Resource> Resources { get; set; } = [];
}