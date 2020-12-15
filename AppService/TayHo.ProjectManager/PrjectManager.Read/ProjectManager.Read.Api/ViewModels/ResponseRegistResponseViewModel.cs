using ProjectManager.Read.Api.ViewModels.BaseClasses;
using ProjectManager.Read.Sql.DTOs.DTO;
using System;
using System.Collections.Generic;

namespace ProjectManager.Read.Api.ViewModels
{
    public class ResponseRegistResponseViewModel : BaseResponseChilCountViewModel
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
        public string AccountName { get; set; }
        public bool? Insert { get; set; }
        public bool? Update { get; set; }
        public bool? Delate { get; set; }
        public bool? View { get; set; }
        
    }
    public class ResponseRegistResponseDetailViewModel : ResponseRegistResponseViewModel
    {
      
        public List<ResponseRegistDTO> ResponseRegistDTOs { get; set; }

    }
}
