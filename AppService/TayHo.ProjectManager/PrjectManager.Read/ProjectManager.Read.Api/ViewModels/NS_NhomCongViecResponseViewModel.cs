using ProjectManager.Read.Api.ViewModels.BaseClasses;

namespace ProjectManager.Read.Api.ViewModels
{
    public class NS_NhomCongViecResponseViewModel : BaseResponseChilCountViewModel
    { 
        public int? HangMucId { get; set; }
        public int? LoaiCongViecId { get; set; }
        public int? GoiThauId { get; set; }
        public int? NhomChiPhiId { get; set; }
        public int? ProjectId { get; set; }
        public string TenNhomCongViec { get; set; }
        public string DienGiai { get; set; }
    }
}
