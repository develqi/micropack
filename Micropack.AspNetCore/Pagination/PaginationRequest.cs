using System;
using Microsoft.AspNetCore.Mvc;

namespace Micropack.AspNetCore
{
    public class PaginationRequest
    {
        private int _page = 1;
        private int _size = 10;

        [FromQuery]
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

        [FromQuery]
        public int Size
        {
            get => _size;
            set
            {
                if (value < 1 || value > 100)
                    throw new ArgumentException("Size parameter must between 1 to 100.");

                _size = value;
            }
        }

        [FromQuery]
        public string Filter { get; set; }

        [FromQuery]
        public string OrderBy { get; set; }

        [FromQuery]
        public string Select { get; set; }

        [FromQuery]
        public int RecordId { get; set; }

        public bool NoSort => string.IsNullOrWhiteSpace(OrderBy);

        public bool NoFilter => string.IsNullOrWhiteSpace(Filter);

        public bool NoSelect => string.IsNullOrWhiteSpace(Select);

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
