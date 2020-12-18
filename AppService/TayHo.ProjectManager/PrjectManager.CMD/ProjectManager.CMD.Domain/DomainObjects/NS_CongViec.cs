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
        private string _tenCongViec;
        private string _dienGiai;
        private string _donViTinh;
        #endregion Fields

        #region Constructors
        private NS_CongViec()
        {
        }

        public NS_CongViec(int? NhomCongViecId,
string TenCongViec,
string DienGiai,
string DonViTinh) : this()
        {
            _nhomCongViecId = NhomCongViecId;
            _tenCongViec = TenCongViec;
            _dienGiai = DienGiai;
            _donViTinh = DonViTinh;
        }
        #endregion Constructors

        #region Properties
        [Required(ErrorMessage = nameof(ErrorCodeInsert.IErr000))] public int? NhomCongViecId { get => _nhomCongViecId; }
        [MaxLength(500, ErrorMessage = nameof(ErrorCodeInsert.IErr500))] public string TenCongViec { get => _tenCongViec; }
        public string DienGiai { get => _dienGiai; }
        [MaxLength(500, ErrorMessage = nameof(ErrorCodeInsert.IErr500))] public string DonViTinh { get => _donViTinh; }
        #endregion Properties

        #region Behaviours
        public void SetNhomCongViecId(int? NhomCongViecId) { _nhomCongViecId = !NhomCongViecId.HasValue ? _nhomCongViecId : NhomCongViecId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetTenCongViec(string TenCongViec) { _tenCongViec = TenCongViec == null ? _tenCongViec : TenCongViec; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetDienGiai(string DienGiai) { _dienGiai = DienGiai == null ? _dienGiai : DienGiai; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetDonViTinh(string DonViTinh) { _donViTinh = DonViTinh == null ? _donViTinh : DonViTinh; if (!IsValid()) throw new DomainException(_errorMessages); }
        public sealed override bool IsValid()
        {
            return base.IsValid();
        }
        #endregion Behaviours
    }
}
