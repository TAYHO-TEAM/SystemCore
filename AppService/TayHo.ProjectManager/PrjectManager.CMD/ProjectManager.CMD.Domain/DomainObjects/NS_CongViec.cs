using ProjectManager.CMD.Domain.DomainObjects.BaseClasses;
using Services.Common.DomainObjects.Exceptions;
using System.ComponentModel.DataAnnotations;
using System;

namespace ProjectManager.CMD.Domain.DomainObjects
{
    public class NS_CongViec : DOBase
    {
        #region Fields
        private int? _nhomCongViecId;
        private int? _giaiDoanId;
        private string _tenCongViec;
        private string _dienGiai;
        private decimal? _donGia;
        private int? _khoiLuong;
        private string _donViTinh;
        private bool? _isLock;
        #endregion Fields

        #region Constructors
        private NS_CongViec()
        {
        }

        public NS_CongViec(int? NhomCongViecId,
            int? GiaiDoanId,
            string TenCongViec,
            string DienGiai,
            decimal? DonGia,
            int? KhoiLuong,
            string DonViTinh,
            bool? isLock) : this()
        {
            _nhomCongViecId = NhomCongViecId;
            _giaiDoanId = GiaiDoanId;
            _tenCongViec = TenCongViec;
            _dienGiai = DienGiai;
            _donGia = DonGia;
            _khoiLuong = KhoiLuong;
            _donViTinh = DonViTinh;
            _isLock = isLock;
        }
        #endregion Constructors

        #region Properties
        [Required(ErrorMessage = nameof(ErrorCodeInsert.IErr000))] public int? NhomCongViecId { get => _nhomCongViecId; }
        public int? GiaiDoanId { get => _giaiDoanId; }
        [MaxLength(500, ErrorMessage = nameof(ErrorCodeInsert.IErr500))] public string TenCongViec { get => _tenCongViec; }
        public string DienGiai { get => _dienGiai; }
        public decimal? DonGia { get => _donGia; }
        public int? KhoiLuong { get => _khoiLuong; }
        [MaxLength(500, ErrorMessage = nameof(ErrorCodeInsert.IErr500))] public string DonViTinh { get => _donViTinh; }
        public bool? isLock { get => _isLock; }
        #endregion Properties

        #region Behaviours
        public void SetNhomCongViecId(int? NhomCongViecId) { _nhomCongViecId = !NhomCongViecId.HasValue ? _nhomCongViecId : NhomCongViecId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetGiaiDoanId(int? GiaiDoanId) { _giaiDoanId = !GiaiDoanId.HasValue ? _giaiDoanId : GiaiDoanId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetTenCongViec(string TenCongViec) { _tenCongViec = TenCongViec == null ? _tenCongViec : TenCongViec; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetDienGiai(string DienGiai) { _dienGiai = DienGiai == null ? _dienGiai : DienGiai; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetDonGia(decimal? DonGia) { _donGia = !DonGia.HasValue ? _donGia : DonGia; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetKhoiLuong(int? KhoiLuong) { _khoiLuong = !KhoiLuong.HasValue ? _khoiLuong : KhoiLuong; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetDonViTinh(string DonViTinh) { _donViTinh = DonViTinh == null ? _donViTinh : DonViTinh; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetisLock(bool? isLock) { _isLock = !isLock.HasValue ? _isLock : isLock; if (!IsValid()) throw new DomainException(_errorMessages); }
        public sealed override bool IsValid()
        {
            return base.IsValid();
        }
        #endregion Behaviours
    }
}
