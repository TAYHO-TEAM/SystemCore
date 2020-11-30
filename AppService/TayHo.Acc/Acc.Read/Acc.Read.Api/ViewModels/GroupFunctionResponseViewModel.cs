using Acc.Read.Api.ViewModels.BaseClasses;

namespace Acc.Read.Api.ViewModels
{
    public class GroupFunctionResponseViewModel : BaseResponseViewModel
    {
        public int? GroupId { get; set; }
        public int? FunctionId { get; set; }
    }
}
