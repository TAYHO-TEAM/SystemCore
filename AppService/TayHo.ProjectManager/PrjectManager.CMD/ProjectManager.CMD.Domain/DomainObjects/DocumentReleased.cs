using ProjectManager.CMD.Domain.DomainObjects.BaseClasses;
using Services.Common.DomainObjects.Exceptions;
using System.ComponentModel.DataAnnotations;


namespace ProjectManager.CMD.Domain.DomainObjects
{
    public class DocumentReleased : DOBase
    {
        #region Fields
        private string _code;
        private string _title;
        private string _description;
        private int? _documentTypeId;
        private int? _projectId;
        private int? _workItemId;
        private string _tagWorkItem;
        private byte? _noAttachment;
        #endregion Fields
        #region Constructors
        private DocumentReleased()
        {
           
        }

        public DocumentReleased(string Code,
                                string Title,
                                string Description,
                                int? DocumentTypeId,
                                int? ProjectId,
                                int? WorkItemId,
                                string TagWorkItem,
                                byte? NoAttachment) : this()
        {
            _code = Code;
            _title = Title;
            _description = Description;
            _documentTypeId = DocumentTypeId;
            _projectId = ProjectId;
            _workItemId = WorkItemId;
            _tagWorkItem = TagWorkItem;
            _noAttachment = NoAttachment;
            if (!IsValid()) throw new DomainException(_errorMessages);
        }
        #endregion Constructors
        #region Properties
        [MaxLength(128, ErrorMessage = nameof(ErrorCodeInsert.IErr128))] public string Code { get => _code; }
        [MaxLength(512, ErrorMessage = nameof(ErrorCodeInsert.IErr512))] public string Title { get => _title; }
        public string Description { get => _description; }
        public int? DocumentTypeId { get => _documentTypeId; }
        public int? ProjectId { get => _projectId; }
        public int? WorkItemId { get => _workItemId; }
        public string TagWorkItem { get => _tagWorkItem; }
        public byte? NoAttachment { get => _noAttachment; }
        #endregion Properties

        #region Behaviours
        public void SetCode(string Code) { _code = Code == null ? _code : Code; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetTitle(string Title) { _title = Title == null ? _title : Title; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetDescription(string Description) { _description = Description == null ? _description : Description; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetDocumentTypeId(int? DocumentTypeId) { _documentTypeId = !DocumentTypeId.HasValue ? _documentTypeId : DocumentTypeId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetProjectId(int? ProjectId) { _projectId = !ProjectId.HasValue ? _projectId : ProjectId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetWorkItemId(int? WorkItemId) { _workItemId = !WorkItemId.HasValue ? _workItemId : WorkItemId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetTagWorkItem(string TagWorkItem) { _tagWorkItem = TagWorkItem == null ? _tagWorkItem : TagWorkItem; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetNoAttachment(byte? NoAttachment) { _noAttachment = !NoAttachment.HasValue ? _noAttachment : NoAttachment; if (!IsValid()) throw new DomainException(_errorMessages); }
        public sealed override bool IsValid()
        {
            return base.IsValid();
        }
        #endregion Behaviours
    }
}
