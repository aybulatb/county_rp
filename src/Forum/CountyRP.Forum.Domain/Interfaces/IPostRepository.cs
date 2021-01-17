using System.Collections.Generic;
using System.Threading.Tasks;

using CountyRP.Forum.Domain.Models;

namespace CountyRP.Forum.Domain.Interfaces
{
    public interface IPostRepository
    {
        Task<IEnumerable<Post>> GetPosts(int topicId);
        Task<Post> Create(Post post);
        Task<Post> Edit(int id, Post post);
        Task Delete(int postId);
        Task<Post> GetLastPostInTopic(int topicId);
    }
}
