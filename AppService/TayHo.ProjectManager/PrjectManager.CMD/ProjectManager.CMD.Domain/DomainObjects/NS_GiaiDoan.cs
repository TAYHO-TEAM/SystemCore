using ProjectManager.CMD.Domain.DomainObjects.BaseClasses;
using Services.Common.DomainObjects.Exceptions;
using System.ComponentModel.DataAnnotations;

namespace ProjectManager.CMD.Domain.DomainObjects
{
    public class NS_GiaiDoan : DOBase
    {
        #region Fields
        private string _tenGiaiDoan;
        private string _dienGiai;
        #endregion Fields

        #region Constructors
        private NS_GiaiDoan()
        {
        }

        public NS_GiaiDoan(string TenGiaiDoan, string DienGiai) : this()
        {
            _tenGiaiDoan = TenGiaiDoan;
            _dienGiai = DienGiai;
        }
        #endregion Constructors

        #region Properties
        [MaxLength(500, ErrorMessage = nameof(ErrorCodeInsert.IErr500))] public string TenGiaiDoan { get => _tenGiaiDoan; }
        [MaxLength(500, ErrorMessage = nameof(ErrorCodeInsert.IErr500))] public string DienGiai { get => _dienGiai; }
        #endregion Properties

        #region Behaviours 
        public void SetTenGiaiDoan(string TenGiaiDoan)
        { _tenGiaiDoan = TenGiaiDoan == null ? _tenGiaiDoan : TenGiaiDoan; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetDienGiai(string DienGiai)
        { _dienGiai = DienGiai == null ? _dienGiai : DienGiai; if (!IsValid()) throw new DomainException(_errorMessages); }

        public sealed override bool IsValid()
        {
            return base.IsValid();
        }
        #endregion Behaviours
    }
}
