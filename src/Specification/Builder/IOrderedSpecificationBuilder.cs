using System;
using System.Linq.Expressions;

namespace Specification.Builder
{
    public interface IOrderedSpecificationBuilder<T>
    {
        IOrderedSpecificationBuilder<T> ThenBy(Expression<Func<T, object>> orderExpression);
        IOrderedSpecificationBuilder<T> ThenByDescending(Expression<Func<T, object>> orderExpression);
    }
}