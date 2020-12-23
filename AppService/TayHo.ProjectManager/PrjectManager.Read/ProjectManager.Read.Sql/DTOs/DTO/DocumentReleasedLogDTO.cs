using ProjectManager.Read.Sql.DTOs.BaseClasses;

namespace ProjectManager.Read.Sql.DTOs.DTO
{
    public class DocumentReleasedLogDTO : DTOBase
    {
        public int? AccountId { get; set; }
        public int? DocumentReleasedId { get; set; }
        public string Note { get; set; }
    }
}
