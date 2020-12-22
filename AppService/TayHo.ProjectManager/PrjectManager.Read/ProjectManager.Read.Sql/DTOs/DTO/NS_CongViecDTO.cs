using ProjectManager.Read.Sql.DTOs.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManager.Read.Sql.DTOs.DTO
{
    public class NS_CongViecDTO : DTOChilCountBase
    {
        public int? NhomCongViecId { get; set; }
        public int? ReasonId { get; set; }
        public string TenCongViec { get; set; }
        public string DienGiai { get; set; }
        public string DonViTinh { get; set; }
    }
}
