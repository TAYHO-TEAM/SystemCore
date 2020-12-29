﻿namespace ProjectManager.CMD.Api.Application.Commands
{
    public class DocumentReleasedCommandSet : BaseCommandClasses
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int? DocumentTypeId { get; set; }
        public int? ProjectId { get; set; }
        public int? WorkItemId { get; set; }
        public string TagWorkItem { get; set; }
        public byte? NoAttachment { get; set; }
    }
}