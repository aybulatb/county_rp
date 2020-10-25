using System.Threading.Tasks;

namespace CountyRP.Forum.Domain.Interfaces
{
    public interface IForumRepository
    {
        Task CreateForum(ForumModel forum);
    }
}
