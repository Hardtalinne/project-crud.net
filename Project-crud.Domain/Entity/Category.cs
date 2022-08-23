namespace ProjectCrud.Domain.Entity
{
    public class Category
    {
        public Guid Id { get; private set; }
        public string Description { get; set; }

        public Category(Guid id, string description)
        {
            Id = id;
            Description = description;
        }

        public Category(string description)
        {
            Description = description;
        }
    }
}
