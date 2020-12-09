using ProjectManager.Read.Api.ViewModels.BaseClasses;

namespace ProjectManager.Read.Api.ViewModels
{
    public class NS_HangMucResponseViewModel : BaseResponseChilCountViewModel
    {
        public int? ParentId { get; set; }
        public string TenHangMuc { get; set; }
        public string KyHieu { get; set; }
        public int? ProjectId { get; set; }
    }
}
