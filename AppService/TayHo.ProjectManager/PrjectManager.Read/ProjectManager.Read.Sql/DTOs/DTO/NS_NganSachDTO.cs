using ProjectManager.Read.Sql.DTOs.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManager.Read.Sql.DTOs.DTO
{
    public class NS_NganSachDTO: DTOBase
    {
        public int HangMucId { get; set; }
        public int GoiThauId { get; set; }
        public int GiaiDoanId { get; set; }
        public string DienGiai { get; set; }
        public decimal GiaTri { get; set; }
        public bool isLock { get; set; }
    }
}
