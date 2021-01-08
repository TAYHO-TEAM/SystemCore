using ProjectManager.Read.Api.ViewModels.BaseClasses;

namespace ProjectManager.Read.Api.ViewModels
{
    public class CustomFormContentResponseViewModel : BaseResponseViewModel
    {
        public string Code { get; set; }
        public int? CustomFormId { get; set; }
    }
}
