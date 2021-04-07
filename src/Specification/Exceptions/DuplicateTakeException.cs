using System;

namespace Specification.Exceptions
{
    public class DuplicateTakeException : Exception
    {
        private new const string Message = "Duplicate use of Take(), Ensure you don't use both Paginate() and Take() in the same specification!";
        public DuplicateTakeException() : base(Message)
        {

        }

        public DuplicateTakeException(Exception innerException) : base(Message, innerException)
        {

        }
    }
}
