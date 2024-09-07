namespace clean_architecture_csharp.Domain.Entities;

public abstract class Entity
{
    public int Id { get; protected set; }
}