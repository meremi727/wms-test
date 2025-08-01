namespace Domain;

public class Resource() 
    : StatefulEntity<ActivityState>(ActivityState.Active)
{
    public string Name { get; set; } = null!;
}