namespace Domain;

public class Client(string name, string address)
    : StatefulEntity<ActivityState>(ActivityState.Active)
{
    public string Name { get; set; } = name;

    public string Address { get; set; } = address;

    public IEnumerable<OutgoingDocument> OutgoingDocuments { get; set; } = [];
}