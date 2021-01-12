using ProjectManager.Read.Sql.DTOs.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManager.Read.Sql.DTOs.DTO
{
    public class NS_NghiemThuDTO : DTOAccountInfoBase
    {
        public int? CongViecDetailId { get; set; }
        public int? GoiThauId { get; set; }
        public int? Dot { get; set; }
        public double? KhoiLuong { get; set; }
    }
}
