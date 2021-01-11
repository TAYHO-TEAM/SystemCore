using ProjectManager.Read.Api.ViewModels.BaseClasses;

namespace ProjectManager.Read.Api.ViewModels
{
    public class NS_NghiemThuResponseViewModel : BaseResponseAccountInfoViewModel
    {
        public int? CongViecDetailId { get; set; }
        public int? Dot { get; set; }
        public double? KhoiLuong { get; set; }
    }
}
