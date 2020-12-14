using System;
namespace ProjectManager.CMD.Api.Application.Commands
{
    public class NS_CongViecCommandSet : BaseCommandClasses
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