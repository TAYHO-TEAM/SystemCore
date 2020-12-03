using System;
namespace ProjectManager.CMD.Api.Application.Commands
{
    public class NS_HopDongCommandSet : BaseCommandClasses
    {
        public int? ParentID { get; set; }
        public string SoHopDong { get; set; }
        public int? ContractorInfoId { get; set; }
        public int? GoiThauID { get; set; }
        public decimal GiaTri { get; set; }
        public DateTime? NgayKy { get; set; }
        public string DienGiai { get; set; }
    }
}