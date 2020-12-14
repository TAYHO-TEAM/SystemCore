using ProjectManager.CMD.Domain.DomainObjects.BaseClasses;
using Services.Common.DomainObjects.Exceptions;
using System.ComponentModel.DataAnnotations;
using System;

namespace ProjectManager.CMD.Domain.DomainObjects
{
    public class NS_GoiThau : DOBase
    {
        #region Fields
        private int? _parentId;
        private string _soHopDong;
        private int? _contractorInfoId;
        private DateTime? _ngayKy;
        private string _dienGiai;
        private double? _tyLeTTTD;
        private decimal? _giaTri;
        #endregion Fields

        #region Constructors
        private NS_GoiThau()
        {
        }

        public NS_GoiThau(int? ParentId,
string SoHopDong,
int? ContractorInfoId,
DateTime? NgayKy,
string DienGiai,
double? TyLeTTTD,
decimal? GiaTri) : this()
        {
            _parentId = ParentId;
            _soHopDong = SoHopDong;
            _contractorInfoId = ContractorInfoId;
            _ngayKy = NgayKy;
            _dienGiai = DienGiai;
            _tyLeTTTD = TyLeTTTD;
            _giaTri = GiaTri;
        }
        #endregion Constructors

        #region Properties
        public int? ParentId { get => _parentId; }
        [MaxLength(50, ErrorMessage = nameof(ErrorCodeInsert.IErr50))] public string SoHopDong { get => _soHopDong; }
        public int? ContractorInfoId { get => _contractorInfoId; }
        public DateTime? NgayKy { get => _ngayKy; }
        public string DienGiai { get => _dienGiai; }
        public double? TyLeTTTD { get => _tyLeTTTD; }
        public decimal? GiaTri { get => _giaTri; }
        #endregion Properties

        #region Behaviours
        public void SetParentId(int? ParentId) { _parentId = !ParentId.HasValue ? _parentId : ParentId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetSoHopDong(string SoHopDong) { _soHopDong = SoHopDong == null ? _soHopDong : SoHopDong; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetContractorInfoId(int? ContractorInfoId) { _contractorInfoId = !ContractorInfoId.HasValue ? _contractorInfoId : ContractorInfoId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetNgayKy(DateTime? NgayKy) { _ngayKy = !NgayKy.HasValue ? _ngayKy : NgayKy; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetDienGiai(string DienGiai) { _dienGiai = DienGiai == null ? _dienGiai : DienGiai; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetTyLeTTTD(double? TyLeTTTD) { _tyLeTTTD = !TyLeTTTD.HasValue ? _tyLeTTTD : TyLeTTTD; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetGiaTri(decimal? GiaTri) { _giaTri = !GiaTri.HasValue ? _giaTri : GiaTri; if (!IsValid()) throw new DomainException(_errorMessages); }

        public sealed override bool IsValid()
        {
            return base.IsValid();
        }
        #endregion Behaviours
    }
}
