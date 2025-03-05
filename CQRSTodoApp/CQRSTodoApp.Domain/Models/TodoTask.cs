namespace CQRSTodoApp.Domain.Models
{
    public class ToDoTask
    {
        public int Id { get; set; }
        public required string Content { get; set; }
        public bool Done { get; set; } = false;
    }
}
