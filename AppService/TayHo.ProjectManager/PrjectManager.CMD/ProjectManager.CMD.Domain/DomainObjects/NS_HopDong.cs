using ProjectManager.CMD.Domain.DomainObjects.BaseClasses;
using Services.Common.DomainObjects.Exceptions;
using System.ComponentModel.DataAnnotations;
using System;

namespace ProjectManager.CMD.Domain.DomainObjects
{
    public class NS_HopDong : DOBase
    {
        #region Fields
        private int? _parentID;
        private string _soHopDong;
        private int? _contractorInfoId;
        private int? _goiThauID;
        private decimal? _giaTri;
        private DateTime? _ngayKy;
        private string _dienGiai;
        #endregion Fields

        #region Constructors
        private NS_HopDong()
        {
        }

        public NS_HopDong(int? ParentID,
            string SoHopDong,
            int? ContractorInfoId,
            int? GoiThauID,
            decimal? GiaTri,
            DateTime? NgayKy,
            string DienGiai) : this()
        {
            _parentID = ParentID;
            _soHopDong = SoHopDong;
            _contractorInfoId = ContractorInfoId;
            _goiThauID = GoiThauID;
            _giaTri = GiaTri;
            _ngayKy = NgayKy;
            _dienGiai = DienGiai;
        }
        #endregion Constructors

        #region Properties
        public int? ParentID { get => _parentID; }
        [MaxLength(50, ErrorMessage = nameof(ErrorCodeInsert.IErr50))] public string SoHopDong { get => _soHopDong; }
        public int? ContractorInfoId { get => _contractorInfoId; }
        public int? GoiThauID { get => _goiThauID; }
        public decimal? GiaTri { get => _giaTri; }
        public DateTime? NgayKy { get => _ngayKy; }
        [MaxLength(-1, ErrorMessage = nameof(ErrorCodeInsert.IErr000))] public string DienGiai { get => _dienGiai; }
        #endregion Properties

        #region Behaviours
        public void SetParentID(int? ParentID)
        { _parentID = ParentID.HasValue ? _parentID : ParentID; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetSoHopDong(string SoHopDong)
        { _soHopDong = string.IsNullOrEmpty(SoHopDong) ? _soHopDong : SoHopDong; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetContractorInfoId(int? ContractorInfoId)
        { _contractorInfoId = ContractorInfoId.HasValue ? _contractorInfoId : ContractorInfoId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetGoiThauID(int? GoiThauID)
        { _goiThauID = GoiThauID.HasValue ? _goiThauID : GoiThauID; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetGiaTri(decimal? GiaTri)
        { _giaTri = GiaTri.HasValue ? _giaTri : GiaTri; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetNgayKy(DateTime? NgayKy)
        { _ngayKy = NgayKy.HasValue ? _ngayKy : NgayKy; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetDienGiai(string DienGiai)
        { _dienGiai = string.IsNullOrEmpty(DienGiai) ? _dienGiai : DienGiai; if (!IsValid()) throw new DomainException(_errorMessages); }

        public sealed override bool IsValid()
        {
            return base.IsValid();
        }
        #endregion Behaviours
    }
}
