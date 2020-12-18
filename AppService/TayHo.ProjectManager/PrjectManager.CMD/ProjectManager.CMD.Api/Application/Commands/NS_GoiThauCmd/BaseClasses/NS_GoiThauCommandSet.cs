
using System;
namespace ProjectManager.CMD.Api.Application.Commands
{
    public class NS_GoiThauCommandSet : BaseCommandClasses
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