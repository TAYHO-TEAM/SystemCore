using ProjectManager.CMD.Domain.DomainObjects.BaseClasses;
using Services.Common.DomainObjects.Exceptions;
using System.ComponentModel.DataAnnotations;
using System;

namespace ProjectManager.CMD.Domain.DomainObjects
{
    public class NS_NganSachDetail : DOBase
    {
        #region Fields
        private int? _nganSachId;
        private string _congViec;
        private decimal? _giaTri;
        private DateTime? _ngayCapNhat;
        private string _dienGiai;
        private bool? _isLock;
        #endregion Fields

        #region Constructors
        private NS_NganSachDetail()
        {
        }

        public NS_NganSachDetail(int? NganSachId, string CongViec, decimal? GiaTri, DateTime? NgayCapNhat, string DienGiai, bool? isLock) : this()
        {
            _nganSachId = NganSachId;
            _congViec = CongViec;
            _giaTri = GiaTri;
            _ngayCapNhat = NgayCapNhat;
            _dienGiai = DienGiai;
            _isLock = isLock;
        }
        #endregion Constructors

        #region Properties
        [Required(ErrorMessage = nameof(ErrorCodeInsert.IErr000))] public int? NganSachId { get => _nganSachId; }
        [MaxLength(500, ErrorMessage = nameof(ErrorCodeInsert.IErr500))] public string CongViec { get => _congViec; }
        public decimal? GiaTri { get => _giaTri; }
        public DateTime? NgayCapNhat { get => _ngayCapNhat; }
        public string DienGiai { get => _dienGiai; }
        public bool? isLock { get => _isLock; }
        #endregion Properties

        #region Behaviours
        public void SetNganSachId(int? NganSachId)
        { _nganSachId = !NganSachId.HasValue ? _nganSachId : NganSachId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetCongViec(string CongViec)
        { _congViec = CongViec == null ? _congViec : CongViec; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetGiaTri(decimal? GiaTri)
        { _giaTri = !GiaTri.HasValue ? _giaTri : GiaTri; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetNgayCapNhat(DateTime? NgayCapNhat)
        { _ngayCapNhat = !NgayCapNhat.HasValue ? _ngayCapNhat : NgayCapNhat; if (!IsValid()) throw new DomainException(_errorMessages); }
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
