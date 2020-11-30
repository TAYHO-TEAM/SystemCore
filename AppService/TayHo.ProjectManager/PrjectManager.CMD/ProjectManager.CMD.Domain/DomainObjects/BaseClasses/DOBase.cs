using Services.Common.DomainObjects;
using Services.Common.DomainObjects.Interfaces;

namespace ProjectManager.CMD.Domain.DomainObjects.BaseClasses
{
    public abstract class DOBase : EntityDO, IAggregateRoot
    {
        #region Fields
        protected int? _createBy;
        #endregion Fields
        #region Constructors
        public DOBase()
        {
        }
        public DOBase(int? CreateBy)
        {
            if (!CreateBy.HasValue) _createBy = CreateBy;
        }
        public virtual void SetCreateAccount(int? createBy)
        {
            CreateBy = createBy.HasValue ? createBy : CreateBy;

        }
        #endregion Constructors

    }
}
