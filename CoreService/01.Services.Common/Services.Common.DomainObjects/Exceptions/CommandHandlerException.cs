using System.Collections.Generic;

namespace Services.Common.DomainObjects.Exceptions
{
    public class CommandHandlerException : BaseException
    {
        public CommandHandlerException(ErrorResult errorResult) : base(errorResult)
        {
        }

        public CommandHandlerException(IReadOnlyCollection<ErrorResult> errorResultList) : base(errorResultList)
        {
        }
    }
}