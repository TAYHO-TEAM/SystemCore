using ProjectManager.CMD.Domain.DomainObjects.BaseClasses;
using Services.Common.DomainObjects.Exceptions;
using System.ComponentModel.DataAnnotations;
using System;

namespace ProjectManager.CMD.Domain.DomainObjects
{
    public class NS_LoaiThau : DOBase
    {
        #region Fields
        private int? _parentId;
        private string _tenGoiThau;
        private string _dienGiai;
        private int? _projectId;
        #endregion Fields

        #region Constructors
        private NS_LoaiThau()
        {
        }

        public NS_LoaiThau(
            int? ParentId,
string TenGoiThau,
string DienGiai,
int? ProjectId) : this()
        {
            _parentId = ParentId;
            _tenGoiThau = TenGoiThau;
            _dienGiai = DienGiai;
            _projectId = ProjectId;
        }
        #endregion Constructors

        #region Properties
        public int? ParentId { get => _parentId; }
        [MaxLength(500, ErrorMessage = nameof(ErrorCodeInsert.IErr500))] public string TenGoiThau { get => _tenGoiThau; }
        [MaxLength(500, ErrorMessage = nameof(ErrorCodeInsert.IErr500))] public string DienGiai { get => _dienGiai; }
        public int? ProjectId { get => _projectId; }
        #endregion Properties

        #region Behaviours
        public void SetParentId(int? ParentId)
        { _parentId = !ParentId.HasValue ? _parentId : ParentId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetTenGoiThau(string TenGoiThau)
        { _tenGoiThau = TenGoiThau == null ? _tenGoiThau : TenGoiThau; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetDienGiai(string DienGiai)
        { _dienGiai = DienGiai == null ? _dienGiai : DienGiai; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetProjectId(int? ProjectId)
        { _projectId = !ProjectId.HasValue ? _projectId : ProjectId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public sealed override bool IsValid()
        {
            return base.IsValid();
        }
        #endregion Behaviours
    }
}
