using System.Collections.Generic;
using System.Threading.Tasks;

using CountyRP.Forum.Domain.Models;
using CountyRP.Forum.WebAPI.ViewModels;

namespace CountyRP.Forum.WebAPI.Services.Interfaces
{
    public interface IForumService
    {
        Task<IEnumerable<ForumModel>> GetAllForums();
        Task<ForumModel> CreateForum(ForumModel forum);
        Task<IEnumerable<ForumInfoViewModel>> GetForumsInfo();
    }
}
