﻿using ProjectManager.Read.Sql.DTOs.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManager.Read.Sql.DTOs.DTO
{
    public class NS_GoiThauDTO: DTOChilCountBase
    {
        public int? ParentId { get; set; }
        public string SoHopDong { get; set; }
        public int? ContractorInfoId { get; set; }
        public DateTime? NgayKy { get; set; }
        public string DienGiai { get; set; }
        public double? TyLeTTTD { get; set; }
        public decimal? GiaTri { get; set; }
    }
}