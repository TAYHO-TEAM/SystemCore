using ProjectManager.CMD.Domain.DomainObjects.BaseClasses;
using Services.Common.DomainObjects.Exceptions;
using System.ComponentModel.DataAnnotations;
using System;

namespace ProjectManager.CMD.Domain.DomainObjects
{
    public class NS_LoaiCongViec : DOBase
    {
        #region Fields
        private int? _parentId;
        private string _tenLoaiCongViec;
        private string _dienGiai;
        private int? _projectId;
        #endregion Fields

        #region Constructors
        private NS_LoaiCongViec()
        {
        }

        public NS_LoaiCongViec(int? ParentId,
string TenLoaiCongViec,
string DienGiai,
int? ProjectId) : this()
        {
            _parentId = ParentId;
            _tenLoaiCongViec = TenLoaiCongViec;
            _dienGiai = DienGiai;
            _projectId = ProjectId;
        }
        #endregion Constructors

        #region Properties
        public int? ParentId { get => _parentId; }
        [MaxLength(500, ErrorMessage = nameof(ErrorCodeInsert.IErr500))] public string TenLoaiCongViec { get => _tenLoaiCongViec; }
        [MaxLength(500, ErrorMessage = nameof(ErrorCodeInsert.IErr500))] public string DienGiai { get => _dienGiai; }
        public int? ProjectId { get => _projectId; }
        #endregion Properties

        #region Behaviours
        public void SetParentId(int? ParentId) { _parentId = !ParentId.HasValue ? _parentId : ParentId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetTenLoaiCongViec(string TenLoaiCongViec) { _tenLoaiCongViec = TenLoaiCongViec == null ? _tenLoaiCongViec : TenLoaiCongViec; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetDienGiai(string DienGiai) { _dienGiai = DienGiai == null ? _dienGiai : DienGiai; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetProjectId(int? ProjectId) { _projectId = !ProjectId.HasValue ? _projectId : ProjectId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public sealed override bool IsValid()
        {
            return base.IsValid();
        }
        #endregion Behaviours
    }
}
