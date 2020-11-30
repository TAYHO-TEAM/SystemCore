using System.Collections.Generic;

namespace Services.Common.Paging
{
    public class PagingItems<T> where T : class
    {
        public PagingItems()
        {
        }

        public PagingItems(int pageSize, int pageNumber, int totalItems)
        {
            PagingInfo = new PagingInfo
            {
                PageSize = pageSize,
                PageNumber = pageNumber,
                TotalItems = totalItems
            };
        }

        public IEnumerable<T> Items { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}