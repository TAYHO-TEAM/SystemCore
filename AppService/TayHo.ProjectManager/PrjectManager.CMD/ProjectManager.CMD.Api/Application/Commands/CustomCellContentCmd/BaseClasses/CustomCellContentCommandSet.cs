using Microsoft.AspNetCore.Http;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class CustomCellContentCommandSet : BaseCommandClasses
    {
        public int? CustomFormContentId { get; set; }
        public int? CustomFormBodyId { get; set; }
        public int? CustomColumId { get; set; }
        public string Contents { get; set; }
        public int? NoRown { get; set; }
    }
}