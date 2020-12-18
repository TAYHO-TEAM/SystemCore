using System.ComponentModel.DataAnnotations;

namespace Services.Common.Paging
{
    public class QueryPaging
    {
        private int _pageSize;
        private int _pageNumber;

        [Required]
        public int PageSize
        {
            get => _pageSize;
            set
            {
                _pageSize = value;
                if (_pageSize > Settings.PageSizeMax) _pageSize = Settings.PageSizeMax;
                if (_pageSize < 0) _pageSize = Settings.DefaultPageSize;
            }
        }

        [Required]
        public int PageNumber
        {
            get => _pageNumber;
            set
            {
                _pageNumber = value;
                if (_pageNumber < 0) _pageNumber = 1;
            }
        }

        public int GetSkipItems()
        {
            return (_pageNumber - 1) * _pageSize;
        }
    }
}