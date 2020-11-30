using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManager.Read.Sql.DTOs.BaseClasses
{
    public class DTOBase
    {
        public int Id { get; set; }
        public bool? IsVisible { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
    }
}
