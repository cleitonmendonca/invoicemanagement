using System;

namespace Specification.Exceptions
{
    public class DuplicateTakeException : BaseSpecificationException
    {
        private const string DuplicateTakeMessage = "Duplicate use of Take(), Ensure you don't use both Paginate() and Take() in the same specification!";
        public DuplicateTakeException() : base(DuplicateTakeMessage)
        {

        }

        public DuplicateTakeException(Exception innerException) : base(DuplicateTakeMessage, innerException)
        {

        }

        public DuplicateTakeException(string specificationName) : base(FormatMessage(DuplicateTakeMessage, specificationName))
        {
        }

        public DuplicateTakeException(string specificationName, Exception innerException) : base(FormatMessage(DuplicateTakeMessage, specificationName), innerException)
        {
        }
    }
}
