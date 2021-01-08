using ProjectManager.Read.Sql.DTOs.BaseClasses;

namespace ProjectManager.Read.Sql.DTOs.DTO
{
    public class CustomTableDTO : DTOBase
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public int? NoColum { get; set; }
        public int? NoRown { get; set; }
        public string Style { get; set; }
        public int? Priority { get; set; }
    }
}
