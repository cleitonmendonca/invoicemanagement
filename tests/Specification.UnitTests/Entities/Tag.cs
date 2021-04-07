namespace Specification.UnitTests.Entities
{
    public class Tag
    {
        public int Id { get; set; }
        public int TagRootId { get; set; }
        public string Name { get; set; }
        public Tag TagRoot { get; set; }
    }
}