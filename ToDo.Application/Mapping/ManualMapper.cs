using ToDo.Application.Dto;
using ToDo.Domain.Entities;

namespace ToDo.Application.Mapping
{
    public class ManualMapper : IManualMapper
    {
        public GetToDoListResponse ConvertToDoItemToGetToDoListResponse(ToDoItem toDoItem)
        {
            return new GetToDoListResponse(toDoItem.Id, toDoItem.Description);
        }

        public IEnumerable<GetToDoListResponse> ConvertEnumerableToDoItemToGetToDoListResponseEnumerable(IEnumerable<ToDoItem> toDoItem)
        {
            List<GetToDoListResponse> getToDoListResponses = [];

            foreach(var item in toDoItem)
            {
                getToDoListResponses.Add(ConvertToDoItemToGetToDoListResponse(item));
            }
            
            return getToDoListResponses;
        }

        public ToDoItem ConvertAddNewToDoItemRequestToToDoItem(AddNewToDoItemRequest toDoItem)
        {
            return new ToDoItem(0, toDoItem.Description, ToDoStatus.Pending, new User(1, "test", "test", "test1"));
        }
    }
}
