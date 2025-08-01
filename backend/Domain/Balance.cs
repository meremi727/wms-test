namespace Domain;

public class Balance : EntityBase
{
    public Resource Resource { get; set; } = null!;

    public Measure Measure { get; set; } = null!;

    public int Amount { get; set; } 
}