using ProjectManager.Read.Api.ViewModels.BaseClasses;
using System;

namespace ProjectManager.Read.Api.ViewModels
{
    public class NS_CongViecResponseViewModel : BaseResponseChilCountViewModel
    {
        public int? NhomCongViecId { get; set; }
        public string Nhom { get; set; }
        public string TenCongViec { get; set; }
        public string DienGiai { get; set; }
        public string DonViTinh { get; set; }
    }
}
