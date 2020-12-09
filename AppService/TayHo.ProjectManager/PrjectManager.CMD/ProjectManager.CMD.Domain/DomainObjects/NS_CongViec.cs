using ProjectManager.CMD.Domain.DomainObjects.BaseClasses;
using Services.Common.DomainObjects.Exceptions;
using System.ComponentModel.DataAnnotations;
using System;

namespace ProjectManager.CMD.Domain.DomainObjects
{
    public class NS_CongViec : DOBase
    {
        #region Fields
        private int? _goiThauId;
        private string _congViec;
        private decimal? _giaTri;
        private string _dienGiai;
        private bool? _isLock;
        #endregion Fields

        #region Constructors
        private NS_CongViec()
        {
        }

        public NS_CongViec(int? GoiThauId,
string CongViec,
decimal? GiaTri,
string DienGiai,
bool? isLock) : this()
        {
            _goiThauId = GoiThauId;
            _congViec = CongViec;
            _giaTri = GiaTri;
            _dienGiai = DienGiai;
            _isLock = isLock;
        }
        #endregion Constructors

        #region Properties
        [Required(ErrorMessage = nameof(ErrorCodeInsert.IErr000))] public int? GoiThauId { get => _goiThauId; }
        [MaxLength(500, ErrorMessage = nameof(ErrorCodeInsert.IErr500))] public string CongViec { get => _congViec; }
        public decimal? GiaTri { get => _giaTri; }
        public string DienGiai { get => _dienGiai; }
        public bool? isLock { get => _isLock; }
        #endregion Properties

        #region Behaviours
        public void SetGoiThauId(int? GoiThauId)
        { _goiThauId = !GoiThauId.HasValue ? _goiThauId : GoiThauId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetCongViec(string CongViec)
        { _congViec = CongViec == null ? _congViec : CongViec; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetGiaTri(decimal? GiaTri)
        { _giaTri = !GiaTri.HasValue ? _giaTri : GiaTri; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetDienGiai(string DienGiai)
        { _dienGiai = DienGiai == null ? _dienGiai : DienGiai; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetisLock(bool? isLock)
        { _isLock = !isLock.HasValue ? _isLock : isLock; if (!IsValid()) throw new DomainException(_errorMessages); }
        public sealed override bool IsValid()
        {
            return base.IsValid();
        }
        #endregion Behaviours
    }
}
