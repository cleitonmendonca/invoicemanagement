using Specification.UnitTests.Entities;

namespace Specification.UnitTests.Specifications
{
    public class DocumentIncludeOwnerSpec : Specification<Document>
    {
        public DocumentIncludeOwnerSpec()
        {
            Query.Include(x => x.Owner);
        }
    }
}