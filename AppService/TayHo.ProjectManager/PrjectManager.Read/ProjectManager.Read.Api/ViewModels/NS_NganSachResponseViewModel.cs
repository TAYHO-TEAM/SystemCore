using ProjectManager.Read.Api.ViewModels.BaseClasses;

namespace ProjectManager.Read.Api.ViewModels
{
    public class NS_NganSachResponseViewModel : BaseResponseViewModel
    {
        public int ProjectId { get; set; }
        public int HangMucId { get; set; }
        public int GoiThauId { get; set; }
        public int GiaiDoanId { get; set; }
        public string DienGiai { get; set; }
        public decimal GiaTri { get; set; }
        public bool isLock { get; set; }
    }
}
