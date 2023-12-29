using ToDo.Application.Dto;
using ToDo.Domain.Entities;

namespace ToDo.Application.Mapping
{
    public interface IManualMapper
    {
        GetToDoListResponse ConvertToDoItemToGetToDoListResponse(ToDoItem toDoItem);
        IEnumerable<GetToDoListResponse> ConvertEnumerableToDoItemToGetToDoListResponseEnumerable(IEnumerable<ToDoItem> toDoItem);
        ToDoItem ConvertAddNewToDoItemRequestToToDoItem(AddNewToDoItemRequest toDoItem);
    }
}
