using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Specification.UnitTests.Entities
{
    public class Department
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public ICollection<Person> Persons { get; set; } = new Collection<Person>();
    }
}