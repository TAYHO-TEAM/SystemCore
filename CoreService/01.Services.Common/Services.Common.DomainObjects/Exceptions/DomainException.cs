using System.Collections.Generic;

namespace Services.Common.DomainObjects.Exceptions
{
    public class DomainException : BaseException
    {
        public DomainException(ErrorResult errorResult) : base(errorResult)
        {
        }
        public DomainException(IReadOnlyCollection<ErrorResult> errorResultList) : base(errorResultList)
        {
        }
    }
}