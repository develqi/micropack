using System;

namespace Micropack.Domain.Abstraction
{
    public record PaginationRequest
    {
        private int _page = 1;
        private int _size = 10;

        private int _maximumSize = 500;

        public int Page
        {
            get => _page;
            set
            {
                if(value < 1)
                    throw new ArgumentException("Page parameter greater than 0.");

                _page = value;
            }
        }

        public int Size
        {
            get => _size;
            set
            {
                if (value < 1 || value > _maximumSize)
                    throw new ArgumentException("Size parameter must between 1 to 100.");

                _size = value;
            }
        }

        private string _filter;

        public string Filter
        {
            get => _filter.ApplyCorrectYeKe();
            set => _filter = value;
        }

        public string OrderBy { get; set; }

        public string Select { get; set; }

        public int RecordId { get; set; }

        public bool NoSort => string.IsNullOrWhiteSpace(OrderBy);

        public bool NoFilter => string.IsNullOrWhiteSpace(Filter);

        public bool NoSelect => string.IsNullOrWhiteSpace(Select);

        public void SetMaximumSize(int maximumSize) => _maximumSize = maximumSize;

        //public string QueryString => GetQueryString();

        //private string GetQueryString()
        //{
        //    var queryString = new StringBuilder($"?page={Page}&size={Size}");

        //    queryString.Append(NoSort ? string.Empty : $"&orderby={OrderBy}");
        //    queryString.Append(NoSelect ? string.Empty : $"&select={Select}");
        //    queryString.Append(NoFilter ? string.Empty : $"&filter={Filter}");

        //    return queryString.ToString();
        //}
    }
}
