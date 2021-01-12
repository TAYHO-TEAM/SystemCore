using ProjectManager.Read.Sql.DTOs.BaseClasses;
using System.Collections.Generic;

namespace ProjectManager.Read.Sql.DTOs.DTO
{
    public class CustomFormContentDTO : DTOBase
    {
        public string Code { get; set; }
        public int? CustomFormId { get; set; }
    }
    public class CustomFormContentDetailDTO : CustomFormContentDTO
    {
        public CustomFormContentDetailDTO()
        {
            CustomCellContentDTOs = new List<CustomCellContentDTO>();
        }
        public CustomFormDetailBodyDTO CustomFormDetailBodyDTO { get; set; }
        public List<CustomCellContentDTO> CustomCellContentDTOs { get; set; }

    }
}
