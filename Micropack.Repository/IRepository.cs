//using Micropack.Domain.Abstraction;
//using System;

//namespace Micropack.Repository
//{
//    public interface IRepository<TEntity> where TEntity : class, IEntityNumeric
//    {
//        ICommit Create<TDestination>(TDestination destination) where TDestination : class, new();

//        Task<int> CreateAsync<TSource>(TSource source);

//        Task CreateAsync(TEntity entity);

//        ICodeGenerator CreatePartial<TDestination>(TDestination destination) where TDestination : class, new();

//        Task CreateOrUpdate<Tdestination>(int id, Tdestination destination, CancellationToken cancellation) where Tdestination : class, new();

//        Task AddRangeAsync(ICollection<TEntity> entities, CancellationToken cancellationToken);

//        Task DeleteAsync<TSource>(TSource source);

//        IQueryable<TEntity> Filter(Expression<Func<TEntity, bool>> expression);

//        IQueryable<TEntity> FilterQuery(QueryFilter<TEntity> query);

//        IPagination FilterQuery(QueryFilter<TEntity> query);

//        IPagination FilterWithPagination(Expression<Func<TEntity, bool>> expression);

//        IFind Find(int id);

//        Task<TResponse> FindAsync<TResponse>(int id, CancellationToken cancellationToken) where TResponse : class;

//        Task<IFind> FindAsync(int id, CancellationToken cancellationToken);

//        Task<TDestination> FindAsync<TDestination>(int id);

//        Task<TEntity> FindAsync(int id);

//        Task<List<TDestination>> GetListByConditionAsync<TDestination>(Expression<Func<TEntity, bool>> expression);

//        Task<List<TEntity>> GetListByConditionAsync(Expression<Func<TEntity, bool>> expression);

//        IRepository<TEntity> OrderBy(string orderBy);

//        IRepository<TEntity> OrderBy<TKey>(Expression<Func<TEntity, TKey>> orderBy);

//        IRepository<TEntity> OrderByDescending<TKey>(Expression<Func<TEntity, TKey>> orderBy);

//        IRepository<TEntity> RuleFilter(BusinessRule<TEntity> rule);

//        void TryUpdateManyToMany<T, TKey>(IEnumerable<T> currentItems, IEnumerable<T> newItems, Func<T, TKey> getKey) where T : class, IEntity;

//        Task UpdateAsync<TSource>(int id, TSource source);

//        Task UpdateAsync(int id, TEntity source);


//    }
//}
