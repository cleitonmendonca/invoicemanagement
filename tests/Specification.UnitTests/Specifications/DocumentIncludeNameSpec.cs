using Specification.UnitTests.Entities;

namespace Specification.UnitTests.Specifications
{
    public class DocumentIncludeNameSpec : Specification<Document>
    {
        public DocumentIncludeNameSpec()
        {
            Query.Include(x => x.Name);
        }
    }
}