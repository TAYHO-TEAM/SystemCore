﻿using ProjectManager.Read.Api.ViewModels.BaseClasses;

namespace ProjectManager.Read.Api.ViewModels
{
    public class DocumentReleasedResponseViewModel : BaseResponseViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int? DocumentTypeId { get; set; }
        public byte? NoAttachment { get; set; }
    }
}