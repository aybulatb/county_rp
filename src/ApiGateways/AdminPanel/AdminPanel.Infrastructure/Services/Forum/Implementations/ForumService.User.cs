using System.Threading.Tasks;

namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Forum.Implementations
{
    public partial class ForumService
    {
        public async Task DeleteUserAsync(int id)
        {
            await _userClient.DeleteAsync(id);
        }
    }
}
