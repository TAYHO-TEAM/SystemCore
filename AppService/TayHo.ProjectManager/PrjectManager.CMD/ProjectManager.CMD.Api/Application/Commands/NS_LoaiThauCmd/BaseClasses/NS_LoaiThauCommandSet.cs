namespace ProjectManager.CMD.Api.Application.Commands
{
    public class NS_LoaiThauCommandSet : BaseCommandClasses
    {
        public int? ParentId { get; set; }
        public string TenLoaiThau { get; set; }
        public string DienGiai { get; set; }
        public int? ProjectId { get; set; }
    }
}