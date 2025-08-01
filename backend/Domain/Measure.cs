namespace Domain;

public class Measure() 
    : StatefulEntity<ActivityState>(ActivityState.Active)
{
    public string Name { get; set; } = null!;
}