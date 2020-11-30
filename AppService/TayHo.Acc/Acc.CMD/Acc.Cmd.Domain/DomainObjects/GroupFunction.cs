using Acc.Cmd.Domain.DomainObjects.BaseClasses;
using Services.Common.DomainObjects.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Acc.Cmd.Domain.DomainObjects
{
    public class GroupFunction : DOBase
    {
        #region Fields
        private int? _functionId;
        private int? _groupId;
        #endregion Fields
        #region Constructors

        private GroupFunction()
        {
        }

        public GroupFunction(int? FunctionId,
                            int? GroupId) : this()
        {
            _functionId = FunctionId;
            _groupId = GroupId;

        }
        #endregion Constructors
        #region Properties
        public int? FunctionId { get => _functionId; }
        public int? GroupId { get => _groupId; }
        #endregion Properties

        #region Behaviours
        public void SetFunctionId(int? FunctionId) { _functionId = FunctionId.HasValue ? _functionId : FunctionId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetGroupId(int? GroupId) { _groupId = GroupId.HasValue ? _groupId : GroupId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public sealed override bool IsValid()
        {
            return base.IsValid();
        }
        #endregion Behaviours
    }
}
