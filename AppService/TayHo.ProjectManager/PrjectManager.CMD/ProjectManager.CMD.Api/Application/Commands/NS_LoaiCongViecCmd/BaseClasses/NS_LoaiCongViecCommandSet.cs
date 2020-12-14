namespace ProjectManager.CMD.Api.Application.Commands
{
    public class NS_LoaiCongViecCommandSet : BaseCommandClasses
    {
        public int? ParentId { get; set; }
        public string TenLoaiCongViec { get; set; }
        public string DienGiai { get; set; }
        public int? ProjectId { get; set; }
    }
}