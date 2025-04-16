using System;

namespace Specification.Exceptions
{
    public class SelectorNotFoundException : BaseSpecificationException
    {
        private const string SelectorNotFoundMessage = "The specification must have Selector defined.";

        public SelectorNotFoundException() : base(SelectorNotFoundMessage)
        {

        }

        public SelectorNotFoundException(Exception innerException) : base(SelectorNotFoundMessage, innerException)
        {

        }

        public SelectorNotFoundException(string specificationName) : base(FormatMessage(SelectorNotFoundMessage, specificationName))
        {
        }

        public SelectorNotFoundException(string specificationName, Exception innerException) : base(FormatMessage(SelectorNotFoundMessage, specificationName), innerException)
        {
        }
    }
}
