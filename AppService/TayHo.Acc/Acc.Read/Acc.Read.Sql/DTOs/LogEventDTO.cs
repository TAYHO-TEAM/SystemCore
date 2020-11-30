using Acc.Read.Sql.DTOs.BaseClasses;

namespace Acc.Read.Sql.DTOs
{
    public class LogEventDTO : SysDTOBase
    {
        public int? UserId { get; set; }
        public string Event { get; set; }
        public string Action { get; set; }
        public string Function { get; set; }
        public string Message { get; set; }
    }
}
