using System.Collections.Generic;
using System.Threading.Tasks;

using CountyRP.Forum.Domain.Models;
using CountyRP.Forum.WebAPI.ViewModels;

namespace CountyRP.Forum.WebAPI.Services.Interfaces
{
    public interface IPostService
    {
        public Task<Post> Create(PostCreateViewModel postViewModel);
        public Task<IEnumerable<PostFilterViewModel>> FilterBy(int topicId, int page);
        public Task<Post> Edit(int id, PostEditViewModel postViewModel);
        public Task Delete(int id);
    }
}
