using System;
using System.Linq.Expressions;

namespace Micropack.DesignPattern.Specification
{
    public class NotSpecification<TEntity> : Specification<TEntity> where TEntity : class
    {
        private readonly Specification<TEntity> _specification;

        public NotSpecification(Specification<TEntity> specification)
        {
            _specification = specification;
        }

        public override Expression<Func<TEntity, bool>> Predictate => Expression.Lambda<Func<TEntity, bool>>(Expression.Not(Predictate));

        //public override bool IsSatisfiedBy(TEntity entity) => !_specification.IsSatisfiedBy(entity);
    }
}