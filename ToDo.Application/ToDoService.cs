using ToDo.Application.Dto;
using ToDo.Application.Mapping;
using ToDo.Domain;

namespace ToDo.Application
{
    public sealed class ToDoService(IToDoPersistenceService toDoPersistenceService, IManualMapper manualMapper) : IToDoService
    {
        public async Task<int> AddNewToDoItemAsync(AddNewToDoItemRequest addNewToDoItemRequest)
        {
            var todoItem = manualMapper.ConvertAddNewToDoItemRequestToToDoItem(addNewToDoItemRequest);
            return await toDoPersistenceService.AddNewItemAsync(todoItem);
        }

        public async Task<bool> PatchToDoItemAsync(int id)
        {
            return await toDoPersistenceService.PatchItemAsync(id);
        }

        public async Task<IEnumerable<GetToDoListResponse>> GetFinishedToDoListAsync(int userId)
        {
            var result = await toDoPersistenceService.GetFinishedItemsAsync();

            var response = manualMapper.ConvertEnumerableToDoItemToGetToDoListResponseEnumerable(result);

            return response;
        }

        public async Task<IEnumerable<GetToDoListResponse>> GetPendingToDoListAsync(int userId)
        {
            var result = await toDoPersistenceService.GetAllPendingItemsAsync();

            var response = manualMapper.ConvertEnumerableToDoItemToGetToDoListResponseEnumerable(result);
            
            return response;
        }
    }
}
