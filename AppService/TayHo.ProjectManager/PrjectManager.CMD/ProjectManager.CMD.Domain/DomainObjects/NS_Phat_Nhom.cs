using ProjectManager.CMD.Domain.DomainObjects.BaseClasses;
using Services.Common.DomainObjects.Exceptions;
using System.ComponentModel.DataAnnotations;
using System;

namespace ProjectManager.CMD.Domain.DomainObjects
{
    public class NS_Phat_Nhom : DOBase
    {
        #region Fields
        private string _tenNhomPhat;
        private string _dienGiai;
        #endregion Fields

        #region Constructors
        private NS_Phat_Nhom()
        {
        }

        public NS_Phat_Nhom(string TenNhomPhat,
            string DienGiai) : this()
        {
            _tenNhomPhat = TenNhomPhat;
            _dienGiai = DienGiai;
        }
        #endregion Constructors

        #region Properties
        [MaxLength(500, ErrorMessage = nameof(ErrorCodeInsert.IErr500))] public string TenNhomPhat { get => _tenNhomPhat; }
        public string DienGiai { get => _dienGiai; }
        #endregion Properties

        #region Behaviours
        public void SetTenNhomPhat(string TenNhomPhat) { _tenNhomPhat = TenNhomPhat == null ? _tenNhomPhat : TenNhomPhat; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetDienGiai(string DienGiai) { _dienGiai = DienGiai == null ? _dienGiai : DienGiai; if (!IsValid()) throw new DomainException(_errorMessages); }
        public sealed override bool IsValid()
        {
            return base.IsValid();
        }
        #endregion Behaviours
    }
}
