﻿using ProjectManager.Read.Sql.DTOs.BaseClasses;

namespace ProjectManager.Read.Api.ViewModels.BaseClasses
{
    public class BaseResponseViewModel : DTOBase
    {
    }
    public class BaseResponseChilCountViewModel : DTOBase
    {
        public int? ChilCount { get; set; }
    }
}
