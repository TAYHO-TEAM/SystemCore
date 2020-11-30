using ProjectManager.Read.Sql.DTOs.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManager.Read.Sql.DTOs.DTO
{
    public class NS_GiaiDoanDTO: DTOBase
    {
        public string DienGiai { get; set; }
        public string TenGiaiDoan { get; set; }
    }
}
