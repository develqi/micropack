namespace Micropack.DesignPattern.Specification
{
    public class SearchQuery<TEntity> : QueryFilter<TEntity> where TEntity : class
    {
        protected readonly string _filter;
        protected readonly bool _noFilter;

        public SearchQuery(string filter)
        {
            _filter = filter;
            _noFilter = string.IsNullOrWhiteSpace(filter);
        }
    }
}
