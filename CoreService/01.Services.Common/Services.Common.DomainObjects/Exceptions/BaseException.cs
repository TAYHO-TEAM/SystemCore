using System;
using System.Collections.Generic;
using System.Linq;

namespace Services.Common.DomainObjects.Exceptions
{
    public class BaseException : Exception
    {
        private readonly List<ErrorResult> _errorResultList;

        private BaseException()
        {
            _errorResultList ??= new List<ErrorResult>();
        }

        public BaseException(ErrorResult errorResult) : this()
        {
            if (errorResult != null)
                _errorResultList.Add(errorResult);
        }

        public BaseException(IReadOnlyCollection<ErrorResult> errorResultList) : this()
        {
            if (errorResultList != null && errorResultList.Any())
                _errorResultList.AddRange(errorResultList);
        }

        public IReadOnlyCollection<ErrorResult> ErrorResultList => _errorResultList;
    }
}