using ProjectManager.Read.Api.ViewModels.BaseClasses;
using System;

namespace ProjectManager.Read.Api.ViewModels
{
    public class NS_CongViecResponseViewModel : BaseResponseChilCountViewModel
    {
        public int? NhomCongViecId { get; set; }
        public string CongViec { get; set; }
        public decimal? GiaTri { get; set; }
        public string DienGiai { get; set; }
        public bool? isLock { get; set; }
    }
}
