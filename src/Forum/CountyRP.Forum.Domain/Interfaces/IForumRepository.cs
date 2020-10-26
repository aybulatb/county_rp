using System.Collections.Generic;
using System.Threading.Tasks;

namespace CountyRP.Forum.Domain.Interfaces
{
    public interface IForumRepository
    {
        Task<IEnumerable<ForumModel>> GetAll();
        Task<ForumModel> CreateForum(ForumModel forum);
    }
}
