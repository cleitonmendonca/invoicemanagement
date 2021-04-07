namespace Specification.Builder
{
    public interface IIncludableSpecificationBuilder<T, out TProperty>
    {
        IIncludeAggregator Aggregator { get; }
    }
}
