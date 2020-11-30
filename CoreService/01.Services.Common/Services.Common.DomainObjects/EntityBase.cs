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
    public abstract class EntityBase : IAggregateRoot
    {
        private int? _requestedHashCode;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }

        protected EntityBase()
        {
            var dateTimeUTC = DateTime.UtcNow;
            _domainEvents = new List<INotification>();
        }

        private List<INotification> _domainEvents;
        public List<INotification> DomainEvents => _domainEvents;

        public void AddDomainEvent(INotification eventItem)
        {
            _domainEvents ??= new List<INotification>();
            _domainEvents.Add(eventItem);
        }

        public void RemoveDomainEvent(INotification eventItem)
        {
            _domainEvents?.Remove(eventItem);
        }

        public void ClearDomainEvents()
        {
            _domainEvents?.Clear();
        }

        public bool IsTransient()
        {
            return this.Id == default(Int32);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Entity))
                return false;

            if (Object.ReferenceEquals(this, obj))
                return true;

            if (this.GetType() != obj.GetType())
                return false;

            Entity item = (Entity)obj;

            if (item.IsTransient() || this.IsTransient())
                return false;
            else
                return item.Id == this.Id;
        }

        public override int GetHashCode()
        {
            if (!IsTransient())
            {
                if (!_requestedHashCode.HasValue)
                    _requestedHashCode = this.Id.GetHashCode() ^ 31; // XOR for random distribution (http://blogs.msdn.com/b/ericlippert/archive/2011/02/28/guidelines-and-rules-for-gethashcode.aspx)

                return _requestedHashCode.Value;
            }
            else
                return base.GetHashCode();
        }

        public static bool operator ==(EntityBase left, EntityBase right)
        {
            if (Object.Equals(left, null))
                return (Object.Equals(right, null)) ? true : false;
            else
                return left.Equals(right);
        }

        public static bool operator !=(EntityBase left, EntityBase right)
        {
            return !(left == right);
        }

        protected Assembly GetAssembly() => GetType().Assembly;

        protected List<ErrorResult> _errorMessages = new List<ErrorResult>();

        [NotMapped]
        public IReadOnlyCollection<ErrorResult> ErrorMessages => _errorMessages;

        public virtual bool IsValid()
        {
            var context = new ValidationContext(this, null, null);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(this, context, results, true);
            if (!isValid)
            {
                foreach (var result in results)
                {
                    var errorResult = new ErrorResult
                    {
                        ErrorCode = result.ErrorMessage
                    };
                    errorResult.ErrorMessage = errorResult.ErrorCode.StartsWith(Settings.CommonErrorPrefix, StringComparison.InvariantCulture) ? ErrorHelpers.GetCommonErrorMessage(result.ErrorMessage) : ErrorHelpers.GetErrorMessage(result.ErrorMessage, GetAssembly());
                    foreach (var property in result.MemberNames)
                    {
                        var propertyInfo = context.ObjectType.GetProperty(property);
                        var value = propertyInfo.GetValue(context.ObjectInstance, null);
                        errorResult.ErrorValues.Add(ErrorHelpers.GenerateErrorResult(property, value));
                    }
                    _errorMessages.Add(errorResult);
                }
            }

            return _errorMessages.Count == 0;
        }
    }
}