using ProjectManager.Read.Sql.DTOs.BaseClasses;

namespace ProjectManager.Read.Sql.DTOs.DTO
{
    public class CustomFormContentDTO : DTOBase
    {
        public string Code { get; set; }
        public int? CustomFormId { get; set; }
    }
}
