using ProjectManager.Read.Sql.DTOs.BaseClasses;

namespace ProjectManager.Read.Sql.DTOs.DTO
{
    public class DocumentReleasedDTO : DTOBase
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int? DocumentTypeId { get; set; }
        public byte? NoAttachment { get; set; }
    }
}
