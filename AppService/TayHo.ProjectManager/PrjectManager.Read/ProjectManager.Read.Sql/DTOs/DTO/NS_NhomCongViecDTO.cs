using ProjectManager.Read.Sql.DTOs.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManager.Read.Sql.DTOs.DTO
{
    public class NS_NhomCongViecDTO : DTOChilCountBase
    {
        public int? HangMucId { get; set; }
        public int? LoaiThauId { get; set; }
        public int? GiaiDoanId { get; set; }
        public int? HopDongId { get; set; }
        public int? NhomChiPhiId { get; set; }
        public string TenNhomCongViec { get; set; }
        public string DienGiai { get; set; }
        public decimal? GiaTri { get; set; }
        public bool? isLock { get; set; }
    }
}
