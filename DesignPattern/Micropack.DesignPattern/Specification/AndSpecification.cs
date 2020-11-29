using System;
using System.Linq;
using System.Linq.Expressions;

namespace Micropack.DesignPattern.Specification
{
    public class AndSpecification<TEntity> : Specification<TEntity> where TEntity : class
    {
        private readonly Specification<TEntity> _left;

        private readonly Specification<TEntity> _right;

        public AndSpecification(Specification<TEntity> left, Specification<TEntity> right)
        {
            _left = left;
            _right = right;
        }

        public override Expression<Func<TEntity, bool>> Predictate
        {
            get
            {
                var andExpression = Expression.AndAlso(_left.Predictate.Body, _right.Predictate.Body);
                
                return Expression.Lambda<Func<TEntity, bool>>(andExpression, _left.Predictate.Parameters.Single());
            }
        }

        //public override bool IsSatisfiedBy(TEntity entity) => _left.IsSatisfiedBy(entity) && _right.IsSatisfiedBy(entity);
    }
}