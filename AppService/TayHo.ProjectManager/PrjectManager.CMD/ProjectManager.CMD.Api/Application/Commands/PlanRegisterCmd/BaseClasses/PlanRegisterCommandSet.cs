using System;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class PlanRegisterCommandSet : BaseCommandClasses
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public int? ProjectId { get; set; }
        public int? ContractorInfoId { get; set; }
        public string Description { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public DateTime? ExpectFromDate { get; set; }
        public DateTime? ExpectToDate { get; set; }
    }
}