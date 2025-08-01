namespace Domain;

public class IncomingDocument : EntityBase
{
    public string Number { get; set; } = null!;

    public DateOnly Date { get; set; }

    public IEnumerable<IncomingResouce> Resouces { get; set; } = [];
} 