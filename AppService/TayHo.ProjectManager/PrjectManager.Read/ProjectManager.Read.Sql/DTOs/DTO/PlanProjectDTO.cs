﻿using ProjectManager.Read.Sql.DTOs.BaseClasses;
using System.Collections.Generic;

namespace ProjectManager.Read.Sql.DTOs.DTO
{
    public class PlanProjectDTO : DTOBase
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int? Priority { get; set; }
        public int? ProjectId { get; set; }
    }
}
