using ProjectManager.Read.Api.ViewModels.BaseClasses;

namespace ProjectManager.Read.Api.ViewModels
{
    public class NS_LoaiThauResponseViewModel : BaseResponseViewModel
    {
        public int ParentId { get; set; }
        public string TenGoiThau { get; set; }
        public string DienGiai { get; set; }
        public int ProjectId { get; set; }
    }
}
