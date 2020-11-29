using System;
using System.Linq;
using System.Linq.Expressions;

namespace Micropack.DesignPattern.Specification
{
    public class OrSpecification<TEntity> : Specification<TEntity> where TEntity : class
    {
        private readonly Specification<TEntity> _left;

        private readonly Specification<TEntity> _right;

        public OrSpecification(Specification<TEntity> left, Specification<TEntity> right)
        {
            _right = right;
            _left = left;
        }

        public override Expression<Func<TEntity, bool>> Predictate
        {
            get
            {
                BinaryExpression andExpression = Expression.Or(_left.Predictate.Body, _right.Predictate.Body);

                return Expression.Lambda<Func<TEntity, bool>>(andExpression, _right.Predictate.Parameters.Single());
            }
        }

        //public override bool IsSatisfiedBy(TEntity entity) => _left.IsSatisfiedBy(entity) || _right.IsSatisfiedBy(entity);
    }
}