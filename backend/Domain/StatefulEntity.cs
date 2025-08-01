namespace Domain;

public abstract class StatefulEntity<TState>(TState initialState) : EntityBase
    where TState : Enum
{
    public virtual TState State
    {
        get => state;
        protected set => state = value;
    }

    private TState state = initialState;
}