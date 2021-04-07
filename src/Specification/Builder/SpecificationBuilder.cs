using Specification.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Specification.Builder
{
    public class SpecificationBuilder<T, TResult> : SpecificationBuilder<T>, ISpecificationBuilder<T, TResult>
    {
        private readonly Specification<T, TResult> _specification;

        public SpecificationBuilder(Specification<T, TResult> specification) : base(specification)
        {
            this._specification = specification;

        }

        public ISpecificationBuilder<T> Select(Expression<Func<T, TResult>> selector)
        {
            _specification.Selector = selector;
            return this;
        }
    }

    public class SpecificationBuilder<T> : ISpecificationBuilder<T>
    {
        private readonly Specification<T> _specification;
        private readonly IOrderedSpecificationBuilder<T> _orderedSpecificationBuilder;

        public SpecificationBuilder(Specification<T> specification)
        {
            this._specification = specification;
            this._orderedSpecificationBuilder = new OrderedSpecificationBuilder<T>(specification);
        }

        public ISpecificationBuilder<T> Where(Expression<Func<T, bool>> criteria)
        {
            ((List<Expression<Func<T, bool>>>)_specification.WhereExpressions).Add(criteria);
            return this;
        }

        public IOrderedSpecificationBuilder<T> OrderBy(Expression<Func<T, object>> orderExpression)
        {
            ((List<(Expression<Func<T, object>> OrderExpression, OrderTypeEnum OrderType)>)_specification.OrderExpressions).Add((orderExpression, OrderTypeEnum.OrderBy));
            return _orderedSpecificationBuilder;
        }

        public IOrderedSpecificationBuilder<T> OrderByDescending(Expression<Func<T, object>> orderExpression)
        {
            ((List<(Expression<Func<T, object>> OrderExpression, OrderTypeEnum OrderType)>)_specification.OrderExpressions).Add((orderExpression, OrderTypeEnum.OrderByDescending));
            return _orderedSpecificationBuilder;
        }

        public ISpecificationBuilder<T> Include(string includeString)
        {
            ((List<string>)_specification.IncludeStrings).Add(includeString);
            return this;
        }

        public IIncludableSpecificationBuilder<T, TProperty> Include<TProperty>(Expression<Func<T, TProperty>> includeExpression)
        {
            var aggregator = new IncludeAggregator((includeExpression.Body as MemberExpression)?.Member.Name);
            var includeBuilder = new IncludableSpecificationBuilder<T, TProperty>(aggregator);

            ((List<IIncludeAggregator>)_specification.IncludeAggregators).Add(aggregator);
            return includeBuilder;
        }

        public ISpecificationBuilder<T> Take(int take)
        {
            if (_specification.Take != null)
            {
                throw new DuplicateTakeException();
            }

            _specification.Take = take;
            return this;
        }

        public ISpecificationBuilder<T> Skip(int skip)
        {
            if (_specification.Skip != null)
            {
                throw new DuplicateSkipException();
            }

            _specification.Skip = skip;
            return this;
        }

        [Obsolete]
        public ISpecificationBuilder<T> Paginate(int skip, int take)
        {
            Skip(skip);
            Take(take);
            return this;
        }

        /// <summary>
        /// Must be called after specifying criteria
        /// </summary>
        /// <param name="specificationName"></param>
        /// <param name="args">Any arguments used in defining the specification</param>
        public ISpecificationBuilder<T> EnableCache(string specificationName, params object[] args)
        {
            throw new NotImplementedException();
        }
    }
}
