using System.Collections.Generic;
using System.Threading.Tasks;

using CountyRP.Forum.Domain.Models;
using CountyRP.Forum.WebAPI.ViewModels;

namespace CountyRP.Forum.WebAPI.Services.Interfaces
{
    public interface IPostService
    {
        Task<Post> Create(PostCreateViewModel postModel);
        Task<IEnumerable<PostFilterViewModel>> Filter(int topicId, int page);
        Task<Post> Edit(int id, PostEditViewModel postModel);
        Task Delete(int id);
        Task<IEnumerable<Post>> GetPosts(int topicId);
    }
}
