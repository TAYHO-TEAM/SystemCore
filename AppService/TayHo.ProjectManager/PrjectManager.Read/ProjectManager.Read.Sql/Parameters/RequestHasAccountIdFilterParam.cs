using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManager.Read.Sql.Parameters
{
    public class RequestHasAccountIdFilterParam : RequestBaseFilterParam
    {
        public int? AccountId { get; set; }
    }
}
