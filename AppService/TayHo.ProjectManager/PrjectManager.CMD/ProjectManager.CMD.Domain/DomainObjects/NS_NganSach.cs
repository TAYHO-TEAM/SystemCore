using ProjectManager.CMD.Domain.DomainObjects.BaseClasses;
using Services.Common.DomainObjects.Exceptions;
using System.ComponentModel.DataAnnotations;
using System;

namespace ProjectManager.CMD.Domain.DomainObjects
{
    public class NS_NganSach : DOBase
    {
        #region Fields
        private int? _projectId;
        private int? _hangMucId;
        private int? _goiThauId;
        private int? _giaiDoanId;
        private string _dienGiai;
        private decimal? _giaTri;
        private bool? _isLock;
        #endregion Fields

        #region Constructors
        private NS_NganSach()
        {
        }

        public NS_NganSach(int? ProjectId,
int? HangMucId,
int? GoiThauId,
int? GiaiDoanId,
string DienGiai,
decimal? GiaTri,
bool? isLock) : this()
        {
             _projectId = ProjectId;
            _hangMucId = HangMucId;
            _goiThauId = GoiThauId;
            _giaiDoanId = GiaiDoanId;
            _dienGiai = DienGiai;
            _giaTri = GiaTri;
            _isLock = isLock;
        }
        #endregion Constructors

        #region Properties
        public int? ProjectId { get => _projectId; }
        public int? HangMucId { get => _hangMucId; }
        public int? GoiThauId { get => _goiThauId; }
        public int? GiaiDoanId { get => _giaiDoanId; }
        [MaxLength(-1, ErrorMessage = nameof(ErrorCodeInsert.IErr000))] public string DienGiai { get => _dienGiai; }
        public decimal? GiaTri { get => _giaTri; }
        public bool? isLock { get => _isLock; }
        #endregion Properties

        #region Behaviours
        public void SetProjectId(int? ProjectId)
        { _projectId = !ProjectId.HasValue ? _projectId : ProjectId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetHangMucId(int? HangMucId)
        { _hangMucId = HangMucId.HasValue ? _hangMucId : HangMucId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetGoiThauId(int? GoiThauId)
        { _goiThauId = GoiThauId.HasValue ? _goiThauId : GoiThauId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetGiaiDoanId(int? GiaiDoanId)
        { _giaiDoanId = GiaiDoanId.HasValue ? _giaiDoanId : GiaiDoanId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetDienGiai(string DienGiai)
        { _dienGiai = string.IsNullOrEmpty(DienGiai) ? _dienGiai : DienGiai; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetGiaTri(decimal? GiaTri)
        { _giaTri = GiaTri.HasValue ? _giaTri : GiaTri; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetisLock(bool? isLock)
        { _isLock = isLock.HasValue ? _isLock : isLock; if (!IsValid()) throw new DomainException(_errorMessages); }

        public sealed override bool IsValid()
        {
            return base.IsValid();
        }
        #endregion Behaviours
    }
}
