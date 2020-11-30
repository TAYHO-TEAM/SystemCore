﻿using Acc.Cmd.Domain.DomainObjects.BaseClasses;
using Services.Common.DomainObjects.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Acc.Cmd.Domain.DomainObjects
{
    public class DocumentType : DOBase
    {
        #region Fields
        private string _code;
        private string _title;
        private string _descriptions;
        #endregion Fields
        #region Constructors
        private DocumentType()
        {

        }

        public DocumentType(string Code,
                            string Title,
                            string Descriptions) : this()
        {
            _code = Code;
            _title = Title;
            _descriptions = Descriptions;
            if (!IsValid()) throw new DomainException(_errorMessages);
        }
        #endregion Constructors
        #region Properties
        [MaxLength(32, ErrorMessage = nameof(ErrorCodeInsert.IErr32))] public string Code { get => _code; }
        [MaxLength(256, ErrorMessage = nameof(ErrorCodeInsert.IErr256))] public string Title { get => _title; }
        [MaxLength(1024, ErrorMessage = nameof(ErrorCodeInsert.IErr1024))] public string Descriptions { get => _descriptions; }
        #endregion Properties

        #region Behaviours
        public void SetTitle(string Title)
        {
            _title = string.IsNullOrEmpty(Title) ? _title : Title;
            if (!IsValid()) throw new DomainException(_errorMessages);
        }
        public void SetCode(string Code)
        {
            _code = string.IsNullOrEmpty(Code) ? _code : Code;
            if (!IsValid()) throw new DomainException(_errorMessages);
        }
        public void SetDescription(string Descriptions)
        {
            _descriptions = string.IsNullOrEmpty(Descriptions) ? _descriptions : Descriptions;
            if (!IsValid()) throw new DomainException(_errorMessages);
        }
        public sealed override bool IsValid()
        {
            return base.IsValid();
        }
        #endregion Behaviours
    }
}
