using ProjectManager.Read.Sql.DTOs.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManager.Read.Sql.DTOs.DTO
{
    public class NS_CongViecDetailDTO : DTOChilCountBase
    {
        public int? CongViecId { get; set; }
        public int? GiaiDoanId { get; set; }
        public decimal? DonGia { get; set; }
        public int? KhoiLuong { get; set; }
        public int? ReasonId { get; set; }
    }
}
