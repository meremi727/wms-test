namespace Domain;

public class OutgoingDocument()
    : StatefulEntity<DocumentState>(DocumentState.Created)
{
    public string Number { get; set; } = null!;

    public Client Client { get; set; } = null!;

    public DateOnly Date { get; set; }

    public IEnumerable<OutgoingResource> Resources { get; set; } = [];
}