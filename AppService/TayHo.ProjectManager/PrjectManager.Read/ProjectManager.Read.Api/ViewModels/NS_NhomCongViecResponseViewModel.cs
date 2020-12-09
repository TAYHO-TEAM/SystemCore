using ProjectManager.Read.Api.ViewModels.BaseClasses;

namespace ProjectManager.Read.Api.ViewModels
{
    public class NS_NhomCongViecResponseViewModel : BaseResponseChilCountViewModel
    {
        public int? HangMucId { get; set; }
        public int? LoaiThauId { get; set; }
        public int? GiaiDoanId { get; set; }
        public int? HopDongId { get; set; }
        public int? NhomChiPhiId { get; set; }
        public string TenNhomCongViec { get; set; }
        public string DienGiai { get; set; }
        public decimal? GiaTri { get; set; }
        public bool? isLock { get; set; }
    }
}
