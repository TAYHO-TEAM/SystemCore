﻿using ProjectManager.Read.Api.ViewModels.BaseClasses;
using System;

namespace ProjectManager.Read.Api.ViewModels
{
    public class PlanJobResponseViewModel : BaseResponseViewModel
    {
        public int? PlanMasterId { get; set; }
        public int? ParentId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Unit { get; set; }
        public int? Amount { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? ModifyTimes { get; set; }
        public int? Priority { get; set; }
        public byte? ImportantLevel { get; set; }
        public bool? IsDone { get; set; }
    }
}
