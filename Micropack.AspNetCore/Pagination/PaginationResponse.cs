using System.Text;
using System.Collections.Generic;

namespace Micropack.AspNetCore
{
    public class PaginationResponse<TResponse> where TResponse : class, new()
    {
        private readonly int _pageSize;
        private readonly int _pageNumber;
        private readonly PaginationRequest _request;

        public PaginationResponse(int totalRecords, IEnumerable<TResponse> result, PaginationRequest request)
        {
            _request = request;

            _pageSize = request.Size;
            _pageNumber = request.Page;

            Records = result;
            TotalRecords = totalRecords;
        }

        public int TotalRecords { get; }

        public int CurrentPage => _pageNumber;

        public IEnumerable<TResponse> Records { get; }

        //public string PreviousPage => GetPreviousPage();

        //public string NextPage => GetNextPage();


        //private string GetNextPage()
        //{
        //    if (TotalRecords < ((_pageNumber + 1) * _pageSize))
        //        return null;

        //    var queryString = new StringBuilder($"?pageNumbe={_pageNumber + 1}&pageSize={_pageSize}");

        //    queryString.Append(_request.NoSort ? string.Empty : $"&sort={_request.OrderBy}");
        //    queryString.Append(_request.NoSelect ? string.Empty : $"&select={_request.Select}");
        //    queryString.Append(_request.NoFilter ? string.Empty : $"&filter={_request.Filter}");

        //    return queryString.ToString();
        //}

        //private string GetPreviousPage()
        //{
        //    if (_pageNumber == 1)
        //        return null;

        //    var queryString = new StringBuilder($"?pageNumbe={_pageNumber - 1}&pageSize={_pageSize}");

        //    queryString.Append(_request.NoSort ? string.Empty : $"&sort={_request.OrderBy}");
        //    queryString.Append(_request.NoSelect ? string.Empty : $"&select={_request.Select}");
        //    queryString.Append(_request.NoFilter ? string.Empty : $"&filter={_request.Filter}");

        //    return queryString.ToString();
        //}
    }
}
