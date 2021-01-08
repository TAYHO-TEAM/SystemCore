using ProjectManager.Read.Sql.DTOs.BaseClasses;

namespace ProjectManager.Read.Sql.DTOs.DTO
{
    public class CustomFormBodyDTO : DTOBase
    {
        public byte? Priority { get; set; }
        public string Header { get; set; }
        public int? CustomTableId { get; set; }
        public int? CustomFormId { get; set; }
    }
}
