using System.Collections.Generic;
using System.Threading.Tasks;

using CountyRP.Forum.Domain.Models;

namespace CountyRP.Forum.Domain.Interfaces
{
    public interface IForumRepository
    {
        Task<IEnumerable<ForumModel>> GetAll();
        Task<ForumModel> CreateForum(ForumModel forum);
    }
}
