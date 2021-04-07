using Specification.UnitTests.Entities;

namespace Specification.UnitTests.Specifications
{
    public class DocumentIncludeMethodOfNavigationSpec : Specification<Document>
    {
        public DocumentIncludeMethodOfNavigationSpec()
        {
            Query.Include(x => x.Owner.GetSomethingFromOwner());
        }

    }
}