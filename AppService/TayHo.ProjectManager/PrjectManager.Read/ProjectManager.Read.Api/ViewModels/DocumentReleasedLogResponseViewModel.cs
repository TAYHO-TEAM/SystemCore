using ProjectManager.Read.Api.ViewModels.BaseClasses;

namespace ProjectManager.Read.Api.ViewModels
{
    public class DocumentReleasedLogResponseViewModel : BaseResponseViewModel
    {
        public int? AccountId { get; set; }
        public int? DocumentReleasedLogId { get; set; }
        public string Note { get; set; }
    }
}
