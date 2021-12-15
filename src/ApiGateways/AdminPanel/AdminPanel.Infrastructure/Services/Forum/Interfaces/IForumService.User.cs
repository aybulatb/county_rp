using System.Threading.Tasks;

namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Forum.Interfaces
{
    public partial interface IForumService
    {
        Task DeleteUserAsync(int id);
    }
}
