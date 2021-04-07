#nullable enable
namespace Specification.Builder
{
    public interface IIncludeAggregator
    {
        void AddNavigationPropertyName(string? navigationPropertyName);
        string? IncludeString { get; }
    }
}