namespace Specification
{
    public interface IEntity<TId>
    {
        TId Id { get; set; }
    }
}
