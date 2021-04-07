using Specification.UnitTests.Entities;

namespace Specification.UnitTests.Specifications
{
    public class DocumentWithFaultyIncludeSpec : Specification<Document>
    {
        public DocumentWithFaultyIncludeSpec()
        {
            Query.Include(x => x.Id == 1 && x.Name == "Doing something");
        }
    }
}