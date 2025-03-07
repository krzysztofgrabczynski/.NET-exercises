namespace CQRSTodoApp.Application.Dto.TodoTask
{
    public record UpdateTodoTaskDto(int Id, string? Content, bool? Done);
}
