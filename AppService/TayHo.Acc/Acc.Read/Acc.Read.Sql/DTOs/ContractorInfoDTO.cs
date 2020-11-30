﻿using Acc.Read.Sql.DTOs.BaseClasses;

namespace Acc.Read.Sql.DTOs
{
    public class ContractorInfoDTO : SysDTOBase
    {
        public string Code { get; set; }
        public string AvatarImg { get; set; }
        public string Name { get; set; }
        public string Descriptions { get; set; }
        public string BusinessAreas { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
