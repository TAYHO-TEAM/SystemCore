using ProjectManager.Read.Sql.DTOs.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManager.Read.Sql.DTOs.DTO
{
    public class NS_HopDongDTO: DTOBase
    {
        public int ParentID { get; set; }
        public string SoHopDong { get; set; }
        public int ContractorInfoId { get; set; }
        public int GoiThauID { get; set; }
        public decimal GiaTri { get; set; }
        public DateTime NgayKy { get; set; }
        public string DienGiai { get; set; }
    }
}
