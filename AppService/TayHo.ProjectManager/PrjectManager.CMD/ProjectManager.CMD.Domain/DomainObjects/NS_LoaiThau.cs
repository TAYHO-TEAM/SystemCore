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
        private string _tenLoaiThau;
        private string _dienGiai;
        private int? _projectId;
        #endregion Fields

        #region Constructors
        private NS_LoaiThau()
        {
        }

        public NS_LoaiThau(int? ParentId,
string TenLoaiThau,
string DienGiai,
int? ProjectId) : this()
        {
            _parentId = ParentId;
            _tenLoaiThau = TenLoaiThau;
            _dienGiai = DienGiai;
            _projectId = ProjectId;
        }
        #endregion Constructors

        #region Properties
        public int? ParentId { get => _parentId; }
        [MaxLength(500, ErrorMessage = nameof(ErrorCodeInsert.IErr500))] public string TenLoaiThau { get => _tenLoaiThau; }
        [MaxLength(500, ErrorMessage = nameof(ErrorCodeInsert.IErr500))] public string DienGiai { get => _dienGiai; }
        public int? ProjectId { get => _projectId; }
        #endregion Properties

        #region Behaviours
        public void SetParentId(int? ParentId) { _parentId = !ParentId.HasValue ? _parentId : ParentId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetTenLoaiThau(string TenLoaiThau) { _tenLoaiThau = TenLoaiThau == null ? _tenLoaiThau : TenLoaiThau; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetDienGiai(string DienGiai) { _dienGiai = DienGiai == null ? _dienGiai : DienGiai; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetProjectId(int? ProjectId) { _projectId = !ProjectId.HasValue ? _projectId : ProjectId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public sealed override bool IsValid()
        {
            return base.IsValid();
        }
        #endregion Behaviours
    }
}
