using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Specification.UnitTests.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Department Department { get; set; }
        public ICollection<Document> Documents { get; set; } = new Collection<Document>();
        public object GetSomethingFromOwner()
        {
            return new object();
        }
    }
}