﻿using System;
namespace ProjectManager.CMD.Api.Application.Commands
{
    public class NS_CongViecCommandSet : BaseCommandClasses
    {
        public int? NhomCongViecId { get; set; }
        public int? ReasonId { get; set; }
        public string TenCongViec { get; set; }
        public string DienGiai { get; set; }
        public string DonViTinh { get; set; }
    }
}