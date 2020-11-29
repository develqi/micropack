using System;
using System.Linq.Expressions;

namespace Micropack.DesignPattern.Specification
{
    public abstract class Specification<TEntity> where TEntity : class
    {
        public virtual Expression<Func<TEntity, bool>> Predictate { get; }

        public virtual bool IsSatisfiedBy(TEntity entity) => Predictate.Compile()(entity);

        public Specification<TEntity> And(Specification<TEntity> specification) => new AndSpecification<TEntity>(this, specification);

        public Specification<TEntity> Or(Specification<TEntity> specification) => new OrSpecification<TEntity>(this, specification);

        public Specification<TEntity> Not(Specification<TEntity> specification) => new NotSpecification<TEntity>(specification);
    }
}