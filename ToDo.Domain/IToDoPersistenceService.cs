using ToDo.Domain.Entities;

namespace ToDo.Domain
{
    public interface IToDoPersistenceService
    {
        Task<IEnumerable<ToDoItem>> GetAllPendingItemsAsync();
        Task<IEnumerable<ToDoItem>> GetFinishedItemsAsync();
        Task<int> AddNewItemAsync(ToDoItem item);
        Task<bool> PatchItemAsync(int id);
    }
}
