﻿using ProjectManager.Read.Api.ViewModels.BaseClasses;
using System;

namespace ProjectManager.Read.Api.ViewModels
{
    public class RequestRegistResponseViewModel : BaseResponseViewModel
    {
        public string Code { get; set; }
        public string BarCode { get; set; }
        public string Title { get; set; }
        public string Descriptions { get; set; }
        public int? ParentId { get; set; }
        public int? Level { get; set; }
        public byte? NoAttachment { get; set; }
        public int? ProjectId { get; set; }
        public int? WorkItemId { get; set; }
        public int? DocumentTypeId { get; set; }
        public int? Rev { get; set; }
    }
}