using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Specification.Builder
{
    public class OrderedSpecificationBuilder<T> : IOrderedSpecificationBuilder<T>
    {
        private readonly Specification<T> _specification;
        public OrderedSpecificationBuilder(Specification<T> specification)
        {
            this._specification = specification;
        }

        public IOrderedSpecificationBuilder<T> ThenBy(Expression<Func<T, object>> orderExpression)
        {
            ((List<(Expression<Func<T, object>> OrderExpression, OrderTypeEnum OrderType)>)_specification.OrderExpressions).Add((orderExpression, OrderTypeEnum.ThenBy));
            return this;
        }

        public IOrderedSpecificationBuilder<T> ThenByDescending(Expression<Func<T, object>> orderExpression)
        {
            ((List<(Expression<Func<T, object>> OrderExpression, OrderTypeEnum OrderType)>)_specification.OrderExpressions).Add((orderExpression, OrderTypeEnum.ThenByDescending));
            return this;
        }
    }
}