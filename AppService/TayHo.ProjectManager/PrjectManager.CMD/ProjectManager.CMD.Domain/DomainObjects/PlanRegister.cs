using ProjectManager.CMD.Domain.DomainObjects.BaseClasses;
using Services.Common.DomainObjects.Exceptions;
using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectManager.CMD.Domain.DomainObjects
{
    public class PlanRegister : DOBase
    {
        #region Fields
        private string _code;
        private string _title;
        private int? _projectId;
        private int? _contractorInfoId;
        private string _description;
        private DateTime? _fromDate;
        private DateTime? _toDate;
        private DateTime? _expectFromDate;
        private DateTime? _expectToDate;
        #endregion Fields
        #region Constructors
        private PlanRegister()
        {
           
        }

        public PlanRegister(string Code,
                            string Title,
                            int? ProjectId,
                            int? ContractorInfoId,
                            string Description,
                            DateTime? FromDate,
                            DateTime? ToDate,
                            DateTime? ExpectFromDate,
                            DateTime? ExpectToDate) : this()
        {
            _code = Code;
            _title = Title;
            _projectId = ProjectId;
            _contractorInfoId = ContractorInfoId;
            _description = Description;
            _fromDate = FromDate;
            _toDate = ToDate;
            _expectFromDate = ExpectFromDate;
            _expectToDate = ExpectToDate;
            if (!IsValid()) throw new DomainException(_errorMessages);
        }
        #endregion Constructors
        #region Properties
        [MaxLength(128, ErrorMessage = nameof(ErrorCodeInsert.IErr128))] public string Code { get => _code; }
        [MaxLength(512, ErrorMessage = nameof(ErrorCodeInsert.IErr512))] public string Title { get => _title; }
        public int? ProjectId { get => _projectId; }
        public int? ContractorInfoId { get => _contractorInfoId; }
        public string Description { get => _description; }
        public DateTime? FromDate { get => _fromDate; }
        public DateTime? ToDate { get => _toDate; }
        public DateTime? ExpectFromDate { get => _expectFromDate; }
        public DateTime? ExpectToDate { get => _expectToDate; }
        #endregion Properties

        #region Behaviours
        public void SetCode(string Code) { _code = Code == null ? _code : Code; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetTitle(string Title) { _title = Title == null ? _title : Title; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetProjectId(int? ProjectId) { _projectId = !ProjectId.HasValue ? _projectId : ProjectId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetContractorInfoId(int? ContractorInfoId) { _contractorInfoId = !ContractorInfoId.HasValue ? _contractorInfoId : ContractorInfoId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetDescription(string Description) { _description = Description == null ? _description : Description; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetFromDate(DateTime? FromDate) { _fromDate = !FromDate.HasValue ? _fromDate : FromDate; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetToDate(DateTime? ToDate) { _toDate = !ToDate.HasValue ? _toDate : ToDate; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetExpectFromDate(DateTime? ExpectFromDate) { _expectFromDate = !ExpectFromDate.HasValue ? _expectFromDate : ExpectFromDate; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetExpectToDate(DateTime? ExpectToDate) { _expectToDate = !ExpectToDate.HasValue ? _expectToDate : ExpectToDate; if (!IsValid()) throw new DomainException(_errorMessages); }
        public sealed override bool IsValid()
        {
            return base.IsValid();
        }
        #endregion Behaviours
    }
}
