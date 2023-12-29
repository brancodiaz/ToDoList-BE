using ToDo.Domain;
using ToDo.Domain.Entities;

namespace ToDo.Persistence
{
    public class ToDoPersistenceService : IToDoPersistenceService
    {
        private List<ToDoItem> getToDoListResponses;

        public ToDoPersistenceService()
        {
            getToDoListResponses =
            [
                new ToDoItem(1, "Do the dishes", ToDoStatus.Pending, new User(1, "test", "test", "test1")),
                new ToDoItem(2, "Clean the house", ToDoStatus.Pending, new User(1, "test", "test", "test1")),
                new ToDoItem(3, "Pay the bills", ToDoStatus.Pending, new User(1, "test", "test", "test1")),
                new ToDoItem(4, "Buy some food", ToDoStatus.Pending, new User(1, "test", "test", "test1")),
                new ToDoItem(5, "Do the laundry", ToDoStatus.Finished, new User(1, "test", "test", "test1"))
            ];
        }
        public async Task<int> AddNewItemAsync(ToDoItem item)
        {
            var lastItem = getToDoListResponses.LastOrDefault();

            if (lastItem is not null)
            { 
                item = item with { Id = lastItem.Id + 1 };
            }
            else
            { 
                item = item with { Id = 1 };
            }

            getToDoListResponses.Add(item);
            return await Task.FromResult(item.Id);
        }

        public async Task<bool> PatchItemAsync(int id)
        {
            var item = getToDoListResponses.Find(item => item.Id == id);
            if (item is not null)
            {
                var updatedItem = item with { Status = (item.Status == ToDoStatus.Pending ? ToDoStatus.Finished : ToDoStatus.Pending) };
                int index = getToDoListResponses.IndexOf(item);
                getToDoListResponses[index] = updatedItem;

                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }

        public async Task<IEnumerable<ToDoItem>> GetAllPendingItemsAsync()
        {
            return await Task.FromResult(getToDoListResponses.Where(item => item.Status == ToDoStatus.Pending));
        }

        public async Task<IEnumerable<ToDoItem>> GetFinishedItemsAsync()
        {
            return await Task.FromResult(getToDoListResponses.Where(item => item.Status == ToDoStatus.Finished).Take(10));
        }
    }
}
