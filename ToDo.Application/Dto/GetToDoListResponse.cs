namespace ToDo.Application.Dto
{
    //public record GetToDoListResponse(IEnumerable<GetToDoItem> ToDoListItems);
    public record GetToDoListResponse(int Id, string Description);
}
