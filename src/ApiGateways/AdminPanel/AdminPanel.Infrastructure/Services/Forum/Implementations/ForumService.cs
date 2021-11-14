using CountyRP.ApiGateways.AdminPanel.Infrastructure.RestClients.ServiceForum;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Forum.Interfaces;
using System;

namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Forum.Implementations
{
    public partial class ForumService : IForumService
    {
        private readonly IForumClient _forumClient;
        private readonly IModeratorClient _moderatorClient;

        public ForumService(
            IForumClient forumClient,
            IModeratorClient moderatorClient
        )
        {
            _forumClient = forumClient ?? throw new ArgumentNullException(nameof(forumClient));
            _moderatorClient = moderatorClient ?? throw new ArgumentNullException(nameof(moderatorClient));
        }
    }
}
