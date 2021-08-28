using System.Collections.Generic;

namespace Micropack.DesignPattern.Specification
{
    public class AdvanceSearch
    {
        public List<SearchItem> SearchItems { get; set; }
    }

    public class SearchItem
    {
        public string Column { get; set; }

        public string Operator { get; set; }

        public string Filter { get; set; }
    }

    public class AdvanceSearchQuery<TEntity> : QueryFilter<TEntity> where TEntity : class
    {
        protected readonly AdvanceSearch _advanceSearch;

        public AdvanceSearchQuery(AdvanceSearch advanceSearch)
        {
            _advanceSearch = advanceSearch;
        }
    }
}
