using System;

namespace Specification.Exceptions
{
    public class DuplicateOrderChainException : BaseSpecificationException
    {
        private const string DuplicateOrderMessage = "The specification contains more than one Order chain!";

        public DuplicateOrderChainException() : base(DuplicateOrderMessage)
        {

        }

        public DuplicateOrderChainException(Exception innerException) : base(DuplicateOrderMessage, innerException)
        {

        }

        public DuplicateOrderChainException(string specificationName) : base(FormatMessage(DuplicateOrderMessage, specificationName))
        {
        }

        public DuplicateOrderChainException(string specificationName, Exception innerException) : base(FormatMessage(DuplicateOrderMessage, specificationName), innerException)
        {
        }
    }
}
