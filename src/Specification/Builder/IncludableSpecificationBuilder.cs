namespace Specification.Builder
{
    public class IncludableSpecificationBuilder<T, TProperty> : IIncludableSpecificationBuilder<T, TProperty>
    {
        public IIncludeAggregator Aggregator { get; }


        public IncludableSpecificationBuilder(IIncludeAggregator aggregator)
        {
            this.Aggregator = aggregator;
        }
    }
}