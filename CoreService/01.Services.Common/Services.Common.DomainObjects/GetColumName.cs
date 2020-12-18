
using System.Linq;

namespace Services.Common.DomainObjects
{
    public class GetColumName <T>  where T : class
    {
        public string GetColumnTableName()
        {
            var properties = typeof(T).GetProperties();
            return string.Join(",", properties.Select(x => x.Name));
        }
    }
}
