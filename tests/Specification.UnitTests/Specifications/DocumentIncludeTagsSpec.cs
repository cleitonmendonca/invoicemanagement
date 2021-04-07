using Specification.UnitTests.Entities;

namespace Specification.UnitTests.Specifications
{
    public class DocumentIncludeTagsSpec : Specification<Document>
    {
        public DocumentIncludeTagsSpec()
        {
            Query.Include(x => x.Tags);
        }

    }
}