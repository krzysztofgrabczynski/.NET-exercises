﻿namespace CQRSTodoApp.Domain.Exceptions.TodoTask
{
    public class TodoTaskNotFoundException : Exception
    {
        public TodoTaskNotFoundException(int todoTaskId) : base($"Todo task with id: {todoTaskId} not found.") { }
    }
}
