﻿using ProjectManager.Read.Api.ViewModels.BaseClasses;
using System;

namespace ProjectManager.Read.Api.ViewModels
{
    public class NS_PhatResponseViewModel : BaseResponseAccountInfoViewModel
    {
        public int? GoiThauId { get; set; }
        public int? NhomPhatId { get; set; }
        public string NoiDung { get; set; }
        public string DienGiai { get; set; }
        public decimal? GiaTri { get; set; }
        public decimal? GiaTriCon { get; set; }
    }
}
