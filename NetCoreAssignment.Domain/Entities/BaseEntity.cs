namespace NetCoreAssignment.Domain.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public BaseEntity()
        {
        }

        public BaseEntity(int id) : this()
        {
            Id = id;
        }
    }
}
