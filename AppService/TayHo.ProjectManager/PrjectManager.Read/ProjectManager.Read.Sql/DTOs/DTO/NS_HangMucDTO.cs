using ProjectManager.Read.Sql.DTOs.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManager.Read.Sql.DTOs.DTO
{
    public class NS_HangMucDTO: DTOChilCountBase
    {
        public int ParentId { get; set; }
        public string TenHangMuc { get; set; }
        public string KyHieu { get; set; }
        public int NhomChiPhiId { get; set; }
        public int ProjectId { get; set; }
    }
}
