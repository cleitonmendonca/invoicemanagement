using Specification.UnitTests.Entities;

namespace Specification.UnitTests.Specifications
{
    public class DocumentIncludeMethodSpec : Specification<Document>
    {
        public DocumentIncludeMethodSpec()
        {
            Query.Include(x => x.DoSomethingFromDocument());
        }

    }
}