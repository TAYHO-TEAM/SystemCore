using ProjectManager.Read.Sql.DTOs.BaseClasses;
using System.Collections.Generic;

namespace ProjectManager.Read.Sql.DTOs.DTO
{
    public class CustomFormBodyDTO : DTOBase
    {
        public byte? Priority { get; set; }
        public string Header { get; set; }
        public int? CustomTableId { get; set; }
        public int? CustomFormId { get; set; }
    }
    public class CustomFormBodyDetailDTO : CustomFormBodyDTO
    {
      
        public string CustomTableCode { get; set; }
        public string CustomTableTitle { get; set; }
        public int? CustomTableNoColum { get; set; }
        public int? CustomTableNoRown { get; set; }
        public string CustomTableStyle { get; set; }
        public int? CustomTablePriority { get; set; }
        public List<CustomColumDetailDTO> CustomColumDetailDTOs { get; set; }
        public CustomFormBodyDetailDTO()
        {
            CustomColumDetailDTOs = new List<CustomColumDetailDTO>();
        }
    }
}
