namespace SUKiiServer.Application.DTOs
{
    public class TodoItemDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public bool IsComplete { get; set; }
    }
}
