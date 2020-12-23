namespace ProjectManager.CMD.Api.Application.Commands
{
    public class DocumentReleasedCommandSet : BaseCommandClasses
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int? DocumentTypeId { get; set; }
        public byte? NoAttachment { get; set; }
    }
}