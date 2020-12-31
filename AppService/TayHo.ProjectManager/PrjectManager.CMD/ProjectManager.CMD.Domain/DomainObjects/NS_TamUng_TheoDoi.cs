﻿using ProjectManager.CMD.Domain.DomainObjects.BaseClasses;
using Services.Common.DomainObjects.Exceptions;
using System.ComponentModel.DataAnnotations;
using System;

namespace ProjectManager.CMD.Domain.DomainObjects
{
    public class NS_TamUng_TheoDoi : DOBase
    {
        #region Fields
        private int? _tamUngId;
        private string _noiDung;
        private string _dienGiai;
        private decimal? _giaTri;
        private int? _dot;
        #endregion Fields

        #region Constructors
        private NS_TamUng_TheoDoi()
        {
        }

        public NS_TamUng_TheoDoi(int? TamUngId,
string NoiDung,
string DienGiai,
decimal? GiaTri,
int? Dot) : this()
        {
            _tamUngId = TamUngId;
            _noiDung = NoiDung;
            _dienGiai = DienGiai;
            _giaTri = GiaTri;
            _dot = Dot;
        }
        #endregion Constructors

        #region Properties
        [Required(ErrorMessage = nameof(ErrorCodeInsert.IErr000))] public int? TamUngId { get => _tamUngId; }
        [MaxLength(500, ErrorMessage = nameof(ErrorCodeInsert.IErr500))] public string NoiDung { get => _noiDung; }
        public string DienGiai { get => _dienGiai; }
        public decimal? GiaTri { get => _giaTri; }
        public int? Dot { get => _dot; }
        #endregion Properties

        #region Behaviours
        public void SetTamUngId(int? TamUngId) { _tamUngId = !TamUngId.HasValue ? _tamUngId : TamUngId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetNoiDung(string NoiDung) { _noiDung = NoiDung == null ? _noiDung : NoiDung; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetDienGiai(string DienGiai) { _dienGiai = DienGiai == null ? _dienGiai : DienGiai; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetGiaTri(decimal? GiaTri) { _giaTri = !GiaTri.HasValue ? _giaTri : GiaTri; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetDot(int? Dot) { _dot = !Dot.HasValue ? _dot : Dot; if (!IsValid()) throw new DomainException(_errorMessages); }
        public sealed override bool IsValid()
        {
            return base.IsValid();
        }
        #endregion Behaviours
    }
}