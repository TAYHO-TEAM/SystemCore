using ProjectManager.CMD.Domain.DomainObjects.BaseClasses;
using Services.Common.DomainObjects.Exceptions;
using System.ComponentModel.DataAnnotations;
using System;

namespace ProjectManager.CMD.Domain.DomainObjects
{
    public class NS_NhomChiPhi : DOBase
    {
        #region Fields
        private string _tenNhomChiPhi;
        private string _dienGiai;
        #endregion Fields

        #region Constructors
        private NS_NhomChiPhi()
        {
        }

        public NS_NhomChiPhi(string TenNhomChiPhi, string DienGiai,) : this()
        {
            _tenNhomChiPhi = TenNhomChiPhi;
            _dienGiai = DienGiai;
        }
        #endregion Constructors

        #region Properties
        [MaxLength(500, ErrorMessage = nameof(ErrorCodeInsert.IErr500))] public string TenNhomChiPhi { get => _tenNhomChiPhi; }
        [MaxLength(500, ErrorMessage = nameof(ErrorCodeInsert.IErr500))] public string DienGiai { get => _dienGiai; }
        #endregion Properties

        #region Behaviours
        public void SetTenNhomChiPhi(string TenNhomChiPhi)
        { _tenNhomChiPhi = TenNhomChiPhi == null ? _tenNhomChiPhi : TenNhomChiPhi; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetDienGiai(string DienGiai)
        { _dienGiai = DienGiai == null ? _dienGiai : DienGiai; if (!IsValid()) throw new DomainException(_errorMessages); }
        public sealed override bool IsValid()
        {
            return base.IsValid();
        }
        #endregion Behaviours
    }
}
