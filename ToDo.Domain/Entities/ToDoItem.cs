namespace ToDo.Domain.Entities
{
    public record ToDoItem(int Id, string Description, ToDoStatus Status, User User);
}
