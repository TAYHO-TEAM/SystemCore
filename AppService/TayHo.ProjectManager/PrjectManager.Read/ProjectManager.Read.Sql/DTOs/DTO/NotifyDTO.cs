﻿using ProjectManager.Read.Sql.DTOs.BaseClasses;
using System.Collections.Generic;

namespace ProjectManager.Read.Sql.DTOs.DTO
{
    public class NotifyDTO : DTOBase
    {
        public int? Type { get; set; }
        public string Category { get; set; }
        public string Message { get; set; }
        public string Link { get; set; }
        public int? NotifyTemplateId { get; set; }
        public string Title { get; set; }
        public string Sub { get; set; }
        public string BodyContent { get; set; }
    }
}
