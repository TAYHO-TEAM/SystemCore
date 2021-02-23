using ProjectManager.Read.Api.ViewModels.BaseClasses;
using System;

namespace ProjectManager.Read.Api.ViewModels
{
    public class NS_DuChiResponseViewModel : BaseResponseAccountInfoViewModel
    {
        public int? NhomCongViecId { get; set; }
        public int? GoiThauId { get; set; }
        public DateTime? ThoiGianBaoCao { get; set; }
        public DateTime? ThoiGianDuChi { get; set; }
        public decimal? GiaTri { get; set; }
    }
}
