namespace CQRSTodoApp.Domain.Models
{
    public class TodoTask
    {
        public int Id { get; set; }
        public required string Content { get; set; }
        public bool Done { get; set; } = false;
    }
}
