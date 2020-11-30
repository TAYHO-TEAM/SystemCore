using ProjectManager.Read.Api.ViewModels.BaseClasses;
using System;

namespace ProjectManager.Read.Api.ViewModels
{
    public class RequestsResponseViewModel : BaseResponseViewModel
    {
        public int? ProjectId { get; set; }
        public string Code { get; set; }
        public int? RequestFromId { get; set; }
        public int? StageId { get; set; }
        public byte? Priority { get; set; }
        public int? ReplyById { get; set; }
        public DateTime? SendDateTime { get; set; }
        public byte? NoAttachment { get; set; }
    }
}
