using ProjectManager.Read.Sql.DTOs.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManager.Read.Sql.DTOs.DTO
{
    public class NS_LoaiThauDTO: DTOChilCountBase
    {
        public int? ParentId { get; set; }
        public string TenGoiThau { get; set; }
        public string DienGiai { get; set; }
        public int? ProjectId { get; set; }
    }
}
