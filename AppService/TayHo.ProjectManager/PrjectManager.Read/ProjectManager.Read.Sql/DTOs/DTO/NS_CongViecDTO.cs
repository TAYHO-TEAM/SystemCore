using ProjectManager.Read.Sql.DTOs.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManager.Read.Sql.DTOs.DTO
{
    public class NS_CongViecDTO : DTOChilCountBase
    {
        public int? NhomCongViecId { get; set; }
        public int? GiaiDoanId { get; set; }
        public string TenCongViec { get; set; }
        public string DienGiai { get; set; }
        public decimal? DonGia { get; set; }
        public int? KhoiLuong { get; set; }
        public string DonViTinh { get; set; }
        public bool? isLock { get; set; }
    }
}
