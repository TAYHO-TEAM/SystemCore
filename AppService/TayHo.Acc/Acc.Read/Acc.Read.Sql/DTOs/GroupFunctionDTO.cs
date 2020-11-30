using Acc.Read.Sql.DTOs.BaseClasses;

namespace Acc.Read.Sql.DTOs
{
    public class GroupFunctionDTO : SysDTOBase
    {
        public int? GroupId { get; set; }
        public int? FunctionId { get; set; }
    }
}
