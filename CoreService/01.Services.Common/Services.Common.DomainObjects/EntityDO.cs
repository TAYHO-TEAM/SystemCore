using Services.Common.DomainObjects.Interfaces;
using System;



namespace Services.Common.DomainObjects
{
    public abstract class EntityDO : EntityBase, IAggregateRoot
    {
        public virtual bool? IsDelete { get; set; }
        public virtual bool? IsActive { get; set; }
        public virtual bool? IsVisible { get; set; }
        public virtual int? CreateBy { get; set; }
        public virtual DateTime? CreateDateUTC { get; set; }
        public virtual DateTime? CreateDate { get; set; }
        public virtual bool? IsModify { get; set; }
        public virtual int? ModifyBy { get; set; }
        public virtual DateTime? UpdateDateUTC { get; set; }
        public virtual DateTime? UpdateDate { get; set; }
        public virtual byte? Status { get; set; }
        protected EntityDO()
        {
            CreateDateUTC = DateTime.UtcNow;
            CreateDate = DateTime.Now;
            IsDelete = false;
        }
       
        public virtual void SetUpdate(int? modifyBy, byte? status)
        {
            UpdateDateUTC = DateTime.UtcNow;
            UpdateDate = DateTime.Now;
            IsModify = true;
            ModifyBy = modifyBy.HasValue? modifyBy: ModifyBy;
            Status = status.HasValue? status : Status;
            IsModify = true;
        }
    }
}