﻿using ProjectManager.Read.Api.ViewModels.BaseClasses;
using System;

namespace ProjectManager.Read.Api.ViewModels
{
    public class NS_CongViecDetailResponseViewModel : BaseResponseViewModel
    {
        public int? CongViecId { get; set; }
        public int? GiaiDoanId { get; set; }
        public decimal? DonGia { get; set; }
        public int? KhoiLuong { get; set; }
    }
}
