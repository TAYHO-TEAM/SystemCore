﻿namespace ProjectManager.CMD.Api.Application.Commands
{
    public class NS_NganSachCommandSet : BaseCommandClasses
    {
        public int? ProjectId { get; set; }
        public int? HangMucId { get; set; }
        public int? LoaiThauId { get; set; }
        public int? GiaiDoanId { get; set; }
        public string DienGiai { get; set; }
        public decimal? GiaTri { get; set; }
        public bool? isLock { get; set; }
    }
}