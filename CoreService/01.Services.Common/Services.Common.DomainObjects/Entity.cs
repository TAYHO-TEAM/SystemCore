using MediatR;
using Services.Common.DomainObjects.Interfaces;
using Services.Common.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace Services.Common.DomainObjects
{
    public abstract class Entity : EntityBase, IAggregateRoot
    {
        public virtual int? CreatedById { get; set; }
        public virtual bool IsDelete { get; set; }
        public virtual int? DeletedById { get; set; }
        public virtual int? UpdatedById { get; set; }
        public virtual DateTime CreationDate { get; set; }
        public virtual DateTime UpdateDate { get; set; }
        public virtual DateTime? DeletionDate { get; set; }
        protected Entity()
        {
            var dateTimeUTC = DateTime.UtcNow;
            CreationDate = dateTimeUTC;
            UpdateDate = dateTimeUTC;
            DeletionDate = null;
            DeletedById = null;
            IsDelete = false; 
        }
        public virtual void SetUpdateDate()
        {
            UpdateDate = DateTime.UtcNow;
        }
    }
}