﻿using System;
namespace ProjectManager.CMD.Api.Application.Commands
{
    public class NS_CongViecCommandSet : BaseCommandClasses
    {
        public int? NganSachId { get; set; }
        public string CongViec { get; set; }
        public decimal? GiaTri { get; set; }
        public DateTime? NgayCapNhat { get; set; }
        public string DienGiai { get; set; }
        public bool? isLock { get; set; }
    }
}