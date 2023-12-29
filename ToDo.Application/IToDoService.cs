using ToDo.Application.Dto;

namespace ToDo.Application
{
    public interface IToDoService
    {
        Task<IEnumerable<GetToDoListResponse>> GetPendingToDoListAsync(int userId);
        Task<IEnumerable<GetToDoListResponse>> GetFinishedToDoListAsync(int userId);
        Task<int> AddNewToDoItemAsync(AddNewToDoItemRequest addNewToDoItemRequest);
        Task<bool> PatchToDoItemAsync(int id);
    }
}
