using System.Collections.Generic;
using System.Threading.Tasks;

using CountyRP.Forum.Domain.Models;
using CountyRP.Forum.WebAPI.ViewModels;

namespace CountyRP.Forum.WebAPI.Services.Interfaces
{
    public interface IForumService
    {
        Task<IEnumerable<ForumModel>> GetAllForums();
        Task<ForumModel> GetForumById(int id);
        Task<ForumModel> Edit(int id, ForumViewModel forumViewModel);
        Task<ForumModel> CreateForum(ForumViewModel forumViewModel);
        Task<IEnumerable<ForumInfoViewModel>> GetForumsInfo();
        Task Delete(int id);
        Task<StatisticsViewModel> GetStatistics();
    }
}
