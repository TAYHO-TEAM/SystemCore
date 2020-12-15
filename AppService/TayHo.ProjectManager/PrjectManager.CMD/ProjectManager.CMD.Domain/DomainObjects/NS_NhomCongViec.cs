using ProjectManager.CMD.Domain.DomainObjects.BaseClasses;
using Services.Common.DomainObjects.Exceptions;
using System.ComponentModel.DataAnnotations;
using System;

namespace ProjectManager.CMD.Domain.DomainObjects
{
    public class NS_NhomCongViec : DOBase
    {
        #region Fields
        private int? _hangMucId;
        private int? _loaiCongViecId;
        private int? _goiThauId;
        private int? _nhomChiPhiId;
        private string _tenNhomCongViec;
        private string _dienGiai;
        #endregion Fields

        #region Constructors
        private NS_NhomCongViec()
        {
        }

        public NS_NhomCongViec(int? HangMucId,
int? LoaiCongViecId,
int? GoiThauId,
int? NhomChiPhiId,
string TenNhomCongViec,
string DienGiai) : this()
        {
            _hangMucId = HangMucId;
            _loaiCongViecId = LoaiCongViecId;
            _goiThauId = GoiThauId;
            _nhomChiPhiId = NhomChiPhiId;
            _tenNhomCongViec = TenNhomCongViec;
            _dienGiai = DienGiai;
        }
        #endregion Constructors

        #region Properties
        public int? HangMucId { get => _hangMucId; }
        public int? LoaiCongViecId { get => _loaiCongViecId; }
        public int? GoiThauId { get => _goiThauId; }
        public int? NhomChiPhiId { get => _nhomChiPhiId; }
        [MaxLength(500, ErrorMessage = nameof(ErrorCodeInsert.IErr500))] public string TenNhomCongViec { get => _tenNhomCongViec; }
        public string DienGiai { get => _dienGiai; }
        #endregion Properties

        #region Behaviours
        public void SetHangMucId(int? HangMucId) { _hangMucId = !HangMucId.HasValue ? _hangMucId : HangMucId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetLoaiCongViecId(int? LoaiCongViecId) { _loaiCongViecId = !LoaiCongViecId.HasValue ? _loaiCongViecId : LoaiCongViecId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetGoiThauId(int? GoiThauId) { _goiThauId = !GoiThauId.HasValue ? _goiThauId : GoiThauId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetNhomChiPhiId(int? NhomChiPhiId) { _nhomChiPhiId = !NhomChiPhiId.HasValue ? _nhomChiPhiId : NhomChiPhiId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetTenNhomCongViec(string TenNhomCongViec) { _tenNhomCongViec = TenNhomCongViec == null ? _tenNhomCongViec : TenNhomCongViec; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetDienGiai(string DienGiai) { _dienGiai = DienGiai == null ? _dienGiai : DienGiai; if (!IsValid()) throw new DomainException(_errorMessages); }
        public sealed override bool IsValid()
        {
            return base.IsValid();
        }
        #endregion Behaviours
    }
}
