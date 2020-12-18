using ProjectManager.Read.Api.ViewModels.BaseClasses;
using System;

namespace ProjectManager.Read.Api.ViewModels
{
    public class NS_GoiThauResponseViewModel : BaseResponseChilCountViewModel
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
