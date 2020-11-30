using System.Collections.Generic;

namespace Services.Common.DomainObjects.Exceptions
{
    public class ServiceException : BaseException
    {
        public ServiceException(ErrorResult errorResult) : base(errorResult)
        {
        }

        public ServiceException(IReadOnlyCollection<ErrorResult> errorResultList) : base(errorResultList)
        {
        }
    }
}