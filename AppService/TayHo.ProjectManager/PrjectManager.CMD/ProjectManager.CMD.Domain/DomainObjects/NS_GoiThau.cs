﻿using ProjectManager.CMD.Domain.DomainObjects.BaseClasses;
using Services.Common.DomainObjects.Exceptions;
using System.ComponentModel.DataAnnotations;
using System;

namespace ProjectManager.CMD.Domain.DomainObjects
{
    public class NS_GoiThau : DOBase
    {
        #region Fields
        private int? _hangMucId;
        private int? _loaiThauId;
        private int? _giaiDoanId;
        private int? _hopDongId;
        private string _dienGiai;
        private decimal? _giaTri;
        private bool? _isLock;
        #endregion Fields

        #region Constructors
        private NS_GoiThau()
        {
        }

        public NS_GoiThau(int? HangMucId, int? LoaiThauId, int? GiaiDoanId, int? HopDongId, string DienGiai, decimal? GiaTri, bool? isLock) : this()
        {
            _hangMucId = HangMucId;
            _loaiThauId = LoaiThauId;
            _giaiDoanId = GiaiDoanId;
            _hopDongId = HopDongId;
            _dienGiai = DienGiai;
            _giaTri = GiaTri;
            _isLock = isLock;
        }
        #endregion Constructors

        #region Properties
        public int? HangMucId { get => _hangMucId; }
        public int? LoaiThauId { get => _loaiThauId; }
        public int? GiaiDoanId { get => _giaiDoanId; }
        public int? HopDongId { get => _hopDongId; }
        public string DienGiai { get => _dienGiai; }
        public decimal? GiaTri { get => _giaTri; }
        public bool? isLock { get => _isLock; }
        #endregion Properties

        #region Behaviours
        public void SetHangMucId(int? HangMucId)
        { _hangMucId = !HangMucId.HasValue ? _hangMucId : HangMucId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetLoaiThauId(int? LoaiThauId)
        { _loaiThauId = !LoaiThauId.HasValue ? _loaiThauId : LoaiThauId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetGiaiDoanId(int? GiaiDoanId)
        { _giaiDoanId = !GiaiDoanId.HasValue ? _giaiDoanId : GiaiDoanId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetHopDongId(int? HopDongId)
        { _hopDongId = !HopDongId.HasValue ? _hopDongId : HopDongId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetDienGiai(string DienGiai)
        { _dienGiai = DienGiai == null ? _dienGiai : DienGiai; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetGiaTri(decimal? GiaTri)
        { _giaTri = !GiaTri.HasValue ? _giaTri : GiaTri; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetisLock(bool? isLock)
        { _isLock = !isLock.HasValue ? _isLock : isLock; if (!IsValid()) throw new DomainException(_errorMessages); }

        public sealed override bool IsValid()
        {
            return base.IsValid();
        }
        #endregion Behaviours
    }
}