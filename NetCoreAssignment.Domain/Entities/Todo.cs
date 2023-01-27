namespace NetCoreAssignment.Domain.Entities
{
    public class Todo: BaseEntity
    {
        public string Name { get; set; }

        public string? Description { get; set; }

        public int Status { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }
    }
}
