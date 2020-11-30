using Services.Common.Paging;

namespace Acc.Read.Sql.Parameters
{
    public class RequestBaseFilterParam : QueryPaging
    {
        public string FindId { get; set; }
        public string TableName { get; set; }
        public string SortCol { get; set; }
        public string SortADSC { get; set; }
        public string KeyWord { get; set; }
        public string ColumName { get; set; }
    }
}
