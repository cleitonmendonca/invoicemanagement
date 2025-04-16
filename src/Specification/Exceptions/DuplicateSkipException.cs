using System;

namespace Specification.Exceptions
{
    public class DuplicateSkipException : BaseSpecificationException
    {
        private const string DuplicateSkipMessage = "Duplicate use of the Skip(). Ensure you don't use both Paginate() and Skip() in the same specification!";
        public DuplicateSkipException() : base(DuplicateSkipMessage)
        {

        }

        public DuplicateSkipException(Exception innerException) : base(DuplicateSkipMessage, innerException)
        {

        }

        public DuplicateSkipException(string specificationName) : base(FormatMessage(DuplicateSkipMessage, specificationName))
        {
        }

        public DuplicateSkipException(string specificationName, Exception innerException) : base(FormatMessage(DuplicateSkipMessage, specificationName), innerException)
        {
        }
    }
}
