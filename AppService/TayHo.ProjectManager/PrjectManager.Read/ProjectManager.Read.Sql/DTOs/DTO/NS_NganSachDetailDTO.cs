using ProjectManager.Read.Sql.DTOs.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManager.Read.Sql.DTOs.DTO
{
    public class NS_NganSachDetailDTO: DTOBase
    {
        public int NganSachId { get; set; }
        public string CongViec { get; set; }
        public decimal GiaTri { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public string DienGiai { get; set; }
        public bool isLock { get; set; }
    }
}
