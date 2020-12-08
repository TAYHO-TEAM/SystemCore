using ProjectManager.Read.Sql.DTOs.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManager.Read.Sql.DTOs.DTO
{
    public class NS_NganSachDTO: DTOChilCountBase
    {
        public int? ProjectId { get; set; }
        public int? HangMucId { get; set; }
        public int? LoaiThauId { get; set; }
        public int? GiaiDoanId { get; set; }
        public string DienGiai { get; set; }
        public decimal GiaTri { get; set; }
        public bool isLock { get; set; }
    }
}
