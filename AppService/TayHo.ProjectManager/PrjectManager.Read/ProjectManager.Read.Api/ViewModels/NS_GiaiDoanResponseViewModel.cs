﻿using ProjectManager.Read.Api.ViewModels.BaseClasses;

namespace ProjectManager.Read.Api.ViewModels
{
    public class NS_GiaiDoanResponseViewModel : BaseResponseViewModel
    {
        public string TenGiaiDoan { get; set; }
        public string DienGiai { get; set; }
        public int? ProjectId { get; set; }
        public int? GroupId { get; set; }
        public string CapDo { get; set; }
    }
}
