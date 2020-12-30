using ProjectManager.Read.Sql.DTOs.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManager.Read.Sql.DTOs.DTO
{
    public class NS_KhauTru_TheoDoiDTO : DTOAccountInfoBase
    {
        private int? _khauTruId;
        private string _noiDung;
        private string _dienGiai;
        private decimal? _giaTri;
        private int? _dot;
    }
}
