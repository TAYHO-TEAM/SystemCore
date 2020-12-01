using ProjectManager.Read.Api.ViewModels.BaseClasses;
using System;

namespace ProjectManager.Read.Api.ViewModels
{
    public class NS_NganSachDetailResponseViewModel : BaseResponseViewModel
    {
        public int NganSachId { get; set; }
        public string CongViec { get; set; }
        public decimal GiaTri { get; set; }
        public DateTime? NgayCapNhat { get; set; }
        public string DienGiai { get; set; }
        public bool isLock { get; set; }
    }
}
