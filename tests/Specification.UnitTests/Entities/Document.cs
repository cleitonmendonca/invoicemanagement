using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Specification.UnitTests.Entities
{
    public class Document
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public int StateId { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public Person Owner { get; set; }
        public State State { get; set; }
        public ICollection<Tag> Tags { get; set; } = new Collection<Tag>();

        public object DoSomethingFromDocument()
        {
            return new object();
        }
    }
}