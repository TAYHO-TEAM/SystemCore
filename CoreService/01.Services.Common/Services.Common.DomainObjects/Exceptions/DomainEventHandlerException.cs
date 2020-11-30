using System.Collections.Generic;

namespace Services.Common.DomainObjects.Exceptions
{
    public class DomainEventHandlerException : BaseException
    {
        public DomainEventHandlerException(ErrorResult errorResult) : base(errorResult)
        {
        }

        public DomainEventHandlerException(IReadOnlyCollection<ErrorResult> errorResultList) : base(errorResultList)
        {
        }
    }
}