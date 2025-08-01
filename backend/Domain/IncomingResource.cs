namespace Domain;

public class IncomingResouce : EntityBase
{
    public Resource Resource { get; set; } = null!;

    public Measure Measure { get; set; } = null!;

    public int Amount { get; set; }
}