using ProjectManager.Read.Api.ViewModels.BaseClasses;
using System;

namespace ProjectManager.Read.Api.ViewModels
{
    public class NS_HopDongResponseViewModel : BaseResponseChilCountViewModel
    {
        public int ParentID { get; set; }
        public string SoHopDong { get; set; }
        public int ContractorInfoId { get; set; }
        public int GoiThauID { get; set; }
        public decimal GiaTri { get; set; }
        public DateTime? NgayKy { get; set; }
        public string DienGiai { get; set; }
    }
}
