using ProjectManager.Read.Sql.DTOs.BaseClasses;
using System.Collections.Generic;

namespace ProjectManager.Read.Sql.DTOs.DTO
{
    public class CustomFormDTO : DTOBase
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public string Header { get; set; }
        public string Style { get; set; }
    }
    public class CustomFormDetailDTO : CustomFormDTO
    {
        public CustomFormDetailDTO()
        {
            CustomFormBodyDetailDTOs = new List<CustomFormBodyDetailDTO>();
        }
        public List<CustomFormBodyDetailDTO> CustomFormBodyDetailDTOs { get; set; }
    }
}
